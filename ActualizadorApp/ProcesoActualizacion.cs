using System;
using System.Collections.Generic;
using System.Text;
using MundiAudit.ActualizadorApp.Definiciones;
using System.IO;
using MundiAudit.ActualizadorApp.Definiciones.Helpers;

namespace MundiAudit.ActualizadorApp
{
	public class ProcesoActualizacion
	{
		ConfiguracionActualizador Config;
		IGestorArchivos GestorArchivos;

		string CadenaConexion;

		#region variables del flujo.

		internal List<string> versionesPosteriores;
		internal List<DefinicionVersion> versionesPosterioresDef;
		internal SortedList<int, string> sqlScript;

		#endregion

		#region Constructor y métodos de inicialización.

		public ProcesoActualizacion(ConfiguracionActualizador Config)
		{
			this.Config = Config;
			//inicialización
			GestorArchivos = InstanciarGestorArchivos(Config);

		}


		private static IGestorArchivos InstanciarGestorArchivos(ConfiguracionActualizador config)
		{
			IGestorArchivos result = null;
			switch (config.TipoRepositorio)
			{
				case TipoRepositorio.FTP:
					result = new GestorArchivosFTP(config);
					break;
				case TipoRepositorio.Sistema_de_archivos:
					result = new GestorArchivosFileSystem(config);
					break;
                case TipoRepositorio.IIS_HttpFileSystem:
                    result = new GestorArchivosIISFileSystem(config);
                    break;
			}
			return result;
		}

		#endregion

		public void Iniciar()
		{
			//Recuperamos si hay versiones posteriores del repo.            
			if (!HayVersionesPosterioresEnRepositorio(Config.VersionActual))
				return;

			DescargarDefinicionVersionesPosteriores();

			if (ActualizarBinarios())
			{

			}
		}

		public bool IniciarBaseDatos(int versionBBDD, string cadenaConexion)
		{
			this.CadenaConexion = cadenaConexion;

			if (!HayVersionesPosterioresBDEnRepositorio(versionBBDD))
				return true;

			DescargarDefinicionVersionesPosteriores();

			if (HayActualizacionesBaseDatos())
				if (UsuarioPuedeActualizarBaseDatos())
					return true;
				else
					return false;

			return false;
			//if (!HayActualizacionesBaseDatos())

			//if (!UsuarioPuedeActualizarBaseDatos())

		}


		#region Métodos del actualizador

		private bool HayVersionesPosterioresEnRepositorio(int versionActual)
		{
			string[] directorios = GestorArchivos.ObtenerListaDirectorios(null);

			versionesPosteriores = new List<string>();
			foreach (string x in directorios)
				if (Convert.ToInt32(x) > versionActual)
					versionesPosteriores.Add(x);

			return versionesPosteriores.Count > 0;
		}

		private bool HayVersionesPosterioresBDEnRepositorio(int versionActual)
		{
			string[] directorios = GestorArchivos.ObtenerListaDirectorios(null);

			versionesPosteriores = new List<string>();
			foreach (string x in directorios)
				if (Convert.ToInt32(x) > versionActual && Convert.ToInt32(x) <= Config.VersionActual)
					versionesPosteriores.Add(x);

			return versionesPosteriores.Count > 0;
		}

		private List<DefinicionVersion> DescargarDefinicionVersionesPosteriores()
		{
			if (versionesPosteriores.Count == 0)
				return null;

			List<DefinicionVersion> result = new List<DefinicionVersion>();

			foreach (string version in versionesPosteriores)
				if (GestorArchivos.ExisteArchivo("version.xml", Convert.ToInt32(version)))
				{
					long foo = 0;
					Stream st = GestorArchivos.CargarArchivo("version.xml", Convert.ToInt32(version), ref foo, ref foo);
					result.Add(DefinicionVersion.DeSerializar(st));
					st.Close();
				}

			versionesPosterioresDef = result;

			return result;
		}

		private bool HayActualizacionesBaseDatos()
		{
			sqlScript = new SortedList<int, string>();
			bool actualizaciones = false;
			foreach (var def in versionesPosterioresDef)
				if (def.RequiereActualizarBBDD)
				{
					sqlScript.Add(
						  def.Version,
						  GestorArchivos.CargarArchivoTexto("BBDD\\update.sql", def.Version).ReadToEnd()
						  );
					actualizaciones = true;
				}

			return actualizaciones;
		}

		private bool UsuarioPuedeActualizarBaseDatos()
		{

			if (!Config.MostrarAsistenteActualizacionBD)
				return false;
			else
				return new AsistenteActualizacionBD(Config, versionesPosterioresDef, sqlScript, CadenaConexion).ShowDialog() == System.Windows.Forms.DialogResult.OK;
		}

		private bool ActualizarBinarios()
		{
			//ToDo: Oscar; aquí la descarga de binarios...
			//la configuración etc... en estas propiedades.
			//borra los temp, las variables ya están instanciadas al llegar a este punto del flujo.

			var actualizardor = new ActualizadorBIN(versionesPosterioresDef, GestorArchivos);

			int res = actualizardor.AplicarActualizacion();
			if (res >= 0)
			{
				var c = ConfiguracionActualizador.Cargar("actualizador.config.xml");
				c.VersionActual = res;
				ConfiguracionActualizador.Guardar("actualizador.config.xml", c);

				return true;
			}

			return false;//aquí si el resultado fue correcto.
		}

		private bool ActualizarBaseDatos()
		{
			return false;
		}

		private void FinProceso()
		{
		}

		#endregion

		#region Soporte

		private string ReadText(FileStream stream)
		{
			//ToDo: check encoding.
			return Encoding.Unicode.GetString(ReadFile(stream));
		}
		public static byte[] ReadFile(FileStream fileStream)
		{
			byte[] buffer;
			try
			{
				int length = (int)fileStream.Length;  // get file length
				buffer = new byte[length];            // create buffer
				int count;                            // actual number of bytes read
				int sum = 0;                          // total number of bytes read

				// read until Read method returns 0 (end of the stream has been reached)
				while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
					sum += count;  // sum is a buffer offset for next reading
			}
			finally
			{
				fileStream.Close();
			}
			return buffer;
		}


		#endregion
	}
}
