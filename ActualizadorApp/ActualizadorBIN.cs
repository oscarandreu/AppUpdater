using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace MundiAudit.ActualizadorApp.Definiciones.Helpers
{
	/// <summary>
	/// Se encarga de bajar los binarios a temporal y aplicar los datos
	/// </summary>
	public class ActualizadorBIN
	{
		#region Const

		private const string CARPETA_TEMPORAL = "TmpActualizaciones";

		#endregion

		#region Propiedades

		public event EventHandler AccionIniciada;

		public string Accion { get; set; }
		private object lockAccion = new object();

		public string ArchivoEnDescarga { get; set; }
		private object lockArchivoEnDescarga = new object();


		public bool EnProceso { get; private set; }

		private long bytesDescargados;
		public long BytesDescargados { get { return bytesDescargados; } set { bytesDescargados = value; } }
		private object lockBytesDescargados = new object();

		private long bytesArchivo;
		public long BytesArchivo { get { return bytesArchivo; } set { bytesArchivo = value; } }
		private object lockBytesArchivo = new object();

		public int TotalArchivos { get; set; }
		private object lockTotalArchivos = new object();

		public int ArchivosDescargados { get; set; }
		private object lockArchivosDescargados = new object();

		public long TamañoTotalDescarga { get; set; }
		private object lockTamañoTotalDescarga = new object();

		private long totalBytesDescargados;
		public long TotalBytesDescargados { get { return bytesArchivo + totalBytesDescargados; } }

		#endregion

		#region Variables

		private List<DefinicionVersion> versionesPosterioresDef;
		private List<string> listaDescargaArchivos = new List<string>();
		private IGestorArchivos gestorArchivos;
		private string rutaTemporal;
		private int ultimaVersion;


		private AsistenteActualizacion form;
		private object form_lock = new object();
		internal object threadSinc = new object();
		private AsistenteActualizacion Form
		{
			get
			{
				lock (form_lock)
					return form;
			}
			set
			{
				lock (form_lock)
					form = value;
			}
		}

		#endregion

		#region Constructor

		public ActualizadorBIN(List<DefinicionVersion> versionesPosterioresDef, IGestorArchivos gestorArchivos)
		{
			this.versionesPosterioresDef = versionesPosterioresDef;
			this.gestorArchivos = gestorArchivos;
		}

		#endregion

		#region Métodos  publicos

		public int AplicarActualizacion()
		{
			Monitor.TryEnter(threadSinc);

			Thread th = new Thread(new ThreadStart(delegate
			{
				lock (threadSinc)
				{
					Form = new AsistenteActualizacion(this);
					// Monitor.Pulse(threadSinc);
				}

				Form.ShowDialog();

			}));
			th.Start();


			Monitor.Wait(threadSinc);
			Application.DoEvents();

			try
			{

				EnProceso = true;
				SetAccion("Preparando la actualización.");
				CrearCarpetaTemporal();

				MontarListaActualizaciones();

				SetAccion("Descargando archivos para la actualización.");
				DescargarArchivos();

				SetAccion("Aplicando actualizaciones.");
				AplicarCambios();

				SetAccion("Actualización correcta.");
				EnProceso = false;

				return ultimaVersion;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				Form.Finalizar = true;
			}
		}

		#endregion

		#region Métodos privadors

		private void LanzarInterfaz()
		{
			form = new AsistenteActualizacion(this);
			form.ShowDialog();

			Application.DoEvents();
		}

		private void AplicarCambios()
		{
			foreach (string fich in listaDescargaArchivos)
			{
				string path = Path.GetDirectoryName(fich);
				if (!string.IsNullOrEmpty(path) && !Directory.Exists(string.Format(@"{0}\{1}", Application.StartupPath, path)))
					Directory.CreateDirectory(path);

				File.Delete(string.Format(@"{0}\{1}", Application.StartupPath, fich));
				File.Move(string.Format("{0}{1}", rutaTemporal, fich), string.Format(@"{0}\{1}", Application.StartupPath, fich));
			}
			EliminarCarpetaTemporal();
		}

		private void DescargarArchivos()
		{
			string rutaFichero = null;
			bytesDescargados = 0;

            foreach (string arch in listaDescargaArchivos)
            {

                    lock (lockBytesDescargados)
                    {
                        totalBytesDescargados += BytesDescargados;
                        BytesDescargados = 0;
                    }
                    SetArchivoEnDescarga(arch);

                    rutaFichero = string.Format("{0}{1}", rutaTemporal, arch);
                    if (!Directory.Exists(Path.GetDirectoryName(rutaFichero)))
                        Directory.CreateDirectory(Path.GetDirectoryName(rutaFichero));

                    using (var fs = new FileStream(rutaFichero, FileMode.Create))
                    {
                        Stream st = gestorArchivos.CargarArchivo(string.Format(@"\Bin\{0}", arch), ultimaVersion, ref bytesArchivo, ref bytesDescargados);

                        int readCount;
                        var buffer = new byte[8192];
                        while ((readCount = st.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            fs.Write(buffer, 0, readCount);
                        }
                        fs.Close();
                        st.Close();
                    }
                    lock (lockArchivosDescargados)
                    {
                        ArchivosDescargados++;
                    }
                }
                SetArchivoEnDescarga(string.Empty);
           
		}

		private void MontarListaActualizaciones()
		{
			DefinicionVersion uVersion = null;
			foreach (DefinicionVersion def in versionesPosterioresDef)
			{
				if (uVersion == null || uVersion.Version < def.Version)
					uVersion = def;
			}

			ultimaVersion = uVersion.Version;

			foreach (DefinicionArchivo def in uVersion.ListadoArchivos)
			{
				string ruta = string.Format(@"{0}\{1}", Application.StartupPath, def.RutaArchivo);

				if (!File.Exists(ruta))
				{
					listaDescargaArchivos.Add(def.RutaArchivo);
				}
				else if (HashHelper.CalcularHashArchivo(ruta) != def.HashArchivo)
				{
					try
					{
						//Si no se puede abrir el fichero para escritura dificilmente podremos sobreescribirlo
						//ToDO: Ver como penaliza en rendimiento
						FileStream fs = File.Open(ruta, FileMode.Append, FileAccess.Write);
						fs.Close();
					}
					catch
					{
						string nombreProc = ProcessHelper.GetFileProcessName(def.RutaArchivo);
						//ToDO: permitir retry o cancel 
						throw new Exception(string.Format("Debe cerrar el programa {0} para poder actualizar la aplicación", nombreProc));
					}

					listaDescargaArchivos.Add(def.RutaArchivo);
				}
			}
			long tmp = gestorArchivos.ObtenerTamañoTotalDescarga(listaDescargaArchivos, ultimaVersion);
			lock (lockTamañoTotalDescarga)
			{
				TamañoTotalDescarga = tmp;
			}
			lock (lockTotalArchivos)
			{
				TotalArchivos = listaDescargaArchivos.Count;
			}
		}

		private void CrearCarpetaTemporal()
		{
			rutaTemporal = string.Format(@"{0}\{1}\", Application.StartupPath, CARPETA_TEMPORAL);
			if (Directory.Exists(rutaTemporal))
				EliminarCarpetaTemporal();
			Directory.CreateDirectory(rutaTemporal);
		}

		private void EliminarCarpetaTemporal()
		{
			Directory.Delete(string.Format(@"{0}\{1}", Application.StartupPath, CARPETA_TEMPORAL), true);
		}

		private void SetAccion(string Accion)
		{
			lock (lockAccion)
			{
				this.Accion = Accion;
				if (AccionIniciada != null)
					AccionIniciada(this, new EventArgs());
			}
		}

		private void SetArchivoEnDescarga(string ArchivoEnDescarga)
		{
			lock (lockArchivoEnDescarga)
			{
				this.ArchivoEnDescarga = ArchivoEnDescarga;
			}
		}

		#endregion
	}
}
