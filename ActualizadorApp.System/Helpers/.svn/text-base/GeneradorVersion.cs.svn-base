using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace MundiAudit.ActualizadorApp.Definiciones.Helpers
{
	public static class GeneradorVersion
	{
		public const string CARPETA_ACTUALIZACION = "ActUpdtr";


		public static void GenerarVersion(string RutaRepositorio, string Aplicacion, string Version, string RutaBinarios, string RutaSQL, string Comentarios, string VersionBBDDAnterior, string versionBBDDRequerida, MultiValueDictionary<string, string> forbiddenFiles)
		{
			//Hacer comprobaciones.

			string directorio = string.Empty;
			try
			{
				//Estructura de directorios del repositorio.
				directorio = string.Format("{0}\\{1}\\{2}\\", RutaRepositorio, Aplicacion, Version);
				Directory.CreateDirectory(directorio);
				Directory.CreateDirectory(directorio + "\\Bin");
				Directory.CreateDirectory(directorio + "\\BBDD");

				//Creamos el fichero de definición de versión
				DefinicionVersion definicion = new DefinicionVersion();
				definicion.FechaGeneracion = DateTime.Now;
				definicion.Comentarios = Comentarios;
				definicion.ListadoArchivos = new List<DefinicionArchivo>();
				definicion.Version = Convert.ToInt32(Version);
				definicion.VersionBaseDatosRequerida = versionBBDDRequerida;
				definicion.VersionBaseDatosAnterior = VersionBBDDAnterior;

				//Copiamos los archivos al bin.
				if (!RutaBinarios.EndsWith("\\"))
					RutaBinarios += "\\";

				//Se prepara la lista de archivos teniendo en cuenta cuales no se deben actualizar
				string[] archivosRaw = Directory.GetFiles(RutaBinarios, "*.*", SearchOption.AllDirectories);
				var archivos = new List<string>();
				if (forbiddenFiles != null && forbiddenFiles.Count > 0)
				{
					foreach (string r in archivosRaw)
					{
						if (forbiddenFiles.Contains("*", Path.GetExtension(r))) continue;
						if (r.Contains("vshost")) continue;
						if (forbiddenFiles.Contains(Path.GetFileNameWithoutExtension(r), Path.GetExtension(r))) continue;

						archivos.Add(r);
					}
				}
				else
				{
					archivos.AddRange(archivosRaw);
				}

				string archivoDestino = string.Empty;
				foreach (string archivo in archivos)
				{
					archivoDestino = archivo.Replace(RutaBinarios, directorio + "Bin\\");
					//si no existe el sub-directorio lo creamos.
					if (!Directory.Exists(Path.GetDirectoryName(archivoDestino)))
						Directory.CreateDirectory(Path.GetDirectoryName(archivoDestino));

					//Copiar y hash
					File.Copy(archivo, archivoDestino);
					definicion.ListadoArchivos.Add(new DefinicionArchivo()
					{
						FechaCreacion = File.GetLastWriteTime(archivo),
						HashArchivo = HashHelper.CalcularHashArchivo(archivoDestino),
						RutaArchivo = archivoDestino.Replace(directorio + "Bin\\", string.Empty)
					});
				}

				//Preparamos los archivos de actualizacion del actualizador
				archivosRaw = Directory.GetFiles(Application.StartupPath);
				string rutaActualizadorUpdate = string.Format(@"{0}Bin\{1}", directorio, CARPETA_ACTUALIZACION);
				string rutaActualizadorUpdate2 = string.Format(@"{0}Bin", directorio);

				if (!Directory.Exists(rutaActualizadorUpdate))
					Directory.CreateDirectory(rutaActualizadorUpdate);

				foreach (string r in archivosRaw)
				{
					string fileName = Path.GetFileName(r);
					if (fileName.Contains("vshost")) continue;
					if (fileName.Contains("obj")) continue;
					if (fileName.Contains("config.xml")) continue;
					if (fileName.Contains("txt")) continue;
					if (fileName.Contains("Configurador")) continue;

					if (fileName.Contains("UpdaterActualizador"))
						archivoDestino = r.Replace(Application.StartupPath, rutaActualizadorUpdate2);
					else
						archivoDestino = r.Replace(Application.StartupPath, rutaActualizadorUpdate);

					//Copiar y hash
                    archivoDestino = archivoDestino.Replace("\\\\", "\\");
                    File.Copy(r, archivoDestino);

					definicion.ListadoArchivos.Add(new DefinicionArchivo()
					{
						FechaCreacion = File.GetLastWriteTime(r),
						HashArchivo = HashHelper.CalcularHashArchivo(archivoDestino),
						RutaArchivo = archivoDestino.Replace(directorio + "Bin\\", string.Empty)
					});
				}

				//BBDD
				if (File.Exists(RutaSQL))
				{
					File.Copy(RutaSQL, directorio + "BBDD//update.sql");
					definicion.RequiereActualizarBBDD = true;
				}

				//último paso ya que define que el repositorio está listo.
				DefinicionVersion.Guardar(definicion, string.Format("{0}\\version.xml", directorio));
			}
			catch
			{
				//Borramos el directorio del repositorio
				if (Directory.Exists(directorio))
					Directory.Delete(directorio, true);

				throw;
			}
			finally
			{
				//Marcamos la versión como válida para que sea utilizable por el actualizador.
			}
		}

	}
}
