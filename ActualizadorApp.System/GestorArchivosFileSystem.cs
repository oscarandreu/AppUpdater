using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using MundiAudit.ActualizadorApp.Definiciones;

namespace MundiAudit.ActualizadorApp.Definiciones
{
	public class GestorArchivosFileSystem : IGestorArchivos
	{
		ConfiguracionActualizador Config;

		public long ObtenerTamañoTotalDescarga(List<string> archivos, int Version)
		{ return 0; }

		public GestorArchivosFileSystem(ConfiguracionActualizador Config)
		{
			this.Config = Config;
		}

		/// <summary>
		/// Carga un fichero en memoria.
		/// </summary>
		/// <param name="Fichero"></param>
		/// <param name="Config"></param>
		/// <param name="Version"></param>
		/// <returns></returns>
		public Stream CargarArchivo(string Fichero, int Version, ref long fileSize, ref long downladedBytes)
		{
			string ruta = string.Format("{0}\\{1}\\{2}\\{3}", Config.RutaRepositorio, Config.NombreAplicacion, Version.ToString().PadLeft(10, '0'), Fichero);

			if (File.Exists(ruta))
			{
				FileStream fs = new FileStream(ruta, FileMode.Open, FileAccess.Read);
				fileSize = 0;
				downladedBytes = 0;
				return fs;
			}
			else
				throw new FileNotFoundException(string.Format("No se encontró el archivo {0}",Fichero ));
		}

		public StreamReader CargarArchivoTexto(string Fichero, int Version)
		{
			string ruta = string.Format("{0}\\{1}\\{2}\\{3}", Config.RutaRepositorio, Config.NombreAplicacion, Version.ToString().PadLeft(10, '0'), Fichero);
			if (File.Exists(ruta))
			{
				StreamReader fs = new StreamReader(ruta, Encoding.UTF8, true);
				return fs;
			}
			else
				throw new FileNotFoundException();
		}

		/// <summary>
		/// Carga un fichero en memoria.
		/// </summary>
		/// <param name="Fichero"></param>
		/// <param name="Config"></param>
		/// <param name="Version"></param>
		/// <returns></returns>
		public bool ExisteArchivo(string Fichero, int Version)
		{
			if (Config.TipoRepositorio == TipoRepositorio.Sistema_de_archivos)
			{
				string ruta = string.Format("{0}\\{1}\\{2}\\{3}", Config.RutaRepositorio, Config.NombreAplicacion, Version.ToString().PadLeft(10, '0'), Fichero);
				if (File.Exists(ruta))
				{
					return true;
				}
				else
					return false;
			}
			else
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// Devuelve una lista de directorios dependendiendo de la configuración del actualizador.
		/// </summary>
		/// <param name="RutaRelativa"></param>
		/// <param name="Config"></param>
		/// <returns></returns>
		public string[] ObtenerListaDirectorios(string RutaRelativa)
		{

			if (!string.IsNullOrEmpty(RutaRelativa) && !RutaRelativa.EndsWith("\\"))
				RutaRelativa += "\\";

			if (Config.TipoRepositorio == TipoRepositorio.Sistema_de_archivos)
			{
				string ruta = string.Format("{0}\\{1}\\{2}", Config.RutaRepositorio, Config.NombreAplicacion, RutaRelativa);
				if (Directory.Exists(ruta))
				{
					string[] result = Directory.GetDirectories(ruta);
					for (int n = 0; n < result.Length; n++)
						result[n] = result[n].Replace(string.Format("{0}\\{1}\\{2}", Config.RutaRepositorio, Config.NombreAplicacion, RutaRelativa), string.Empty);

					return result;

				}
				else
					throw new DirectoryNotFoundException();

			}
			else
				throw new NotImplementedException();
		}

		/// <summary>
		/// Obtiene la lista de archivos existentes dentro de la ruta relativa dentro del repositorio indicado en configuración del actualizador.
		/// </summary>
		/// <param name="RutaRelativa"></param>
		/// <param name="Config"></param>
		/// <param name="Version"></param>
		/// <param name="IncluirSubDirectorios"></param>
		/// <returns></returns>
		public string[] ObtenerListaFicheros(string RutaRelativa, int Version, bool IncluirSubDirectorios)
		{

			if (!string.IsNullOrEmpty(RutaRelativa) && !RutaRelativa.EndsWith("\\"))
				RutaRelativa += "\\";

			if (Config.TipoRepositorio == TipoRepositorio.Sistema_de_archivos)
			{
				string ruta = string.Format("{0}\\{1}\\{2}\\{3}", Config.RutaRepositorio, Config.NombreAplicacion, Version.ToString().PadLeft(10, '0'), RutaRelativa);
				if (Directory.Exists(ruta))
				{
					string[] result = Directory.GetFiles(ruta, "*.*", IncluirSubDirectorios ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
					for (int n = 0; n < result.Length; n++)
						result[n] = result[n].Replace(string.Format("{0}\\{1}\\{2}\\", Config.RutaRepositorio, Config.NombreAplicacion, Version.ToString().PadLeft(10, '0')), string.Empty);

					return result;

				}
				else
					throw new DirectoryNotFoundException();
			}
			else
				throw new NotImplementedException();
		}

	}
}
