using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Collections;

namespace MundiAudit.ActualizadorApp.Definiciones
{
	public class GestorArchivosFTP : IGestorArchivos, IDisposable
	{
		#region Variables

		private ConfiguracionActualizador config;
		private FTP conexion;
		private string UrlFtp { get { return string.Format("ftp://{0}/", config.UrlFTP); } }

		#endregion

		#region Propiedades

		public FTP Conexion
		{
			get
			{
				if (conexion == null) conexion = new FTP(config.UrlFTP, config.UsuarioFTP, config.PasswordFTP);
				if (!conexion.IsConnected) conexion.Connect();
				return conexion;
			}
		}

		#endregion

		#region Constructores

		public GestorArchivosFTP(ConfiguracionActualizador config)
		{
			this.config = config;
		}

		#endregion

		#region IGestorArchivos Members

		public long ObtenerTamañoTotalDescarga(List<string> archivos, int Version)
		{
			long total = 0;

			foreach (string archivo in archivos)
			{
				Conexion.ChangeDir(ObtenerRuta("Bin", Version));
				total += Conexion.GetFileSize(archivo);
			}

			return total;
		}

		public Stream CargarArchivo(string Fichero, int Version, ref long fileSize, ref long downladedBytes)
		{
			MemoryStream st = new MemoryStream();
			byte[] bytes;
			long readBytes = 0;

			Fichero = ObtenerRuta(Fichero, Version);
			readBytes = Conexion.PrepareDownload(Fichero);
			fileSize = readBytes;
			readBytes = 0;
			do
			{
				bytes = Conexion.Download(Fichero, ref readBytes);
				downladedBytes += readBytes;
				if (bytes != null)
					st.Write(bytes, 0, (int)readBytes);
			}
			while (readBytes > 0);

			st.Position = 0;
			return st;
		}

		public StreamReader CargarArchivoTexto(string Fichero, int Version)
		{
			long i = 0;
			var st = CargarArchivo(Fichero, Version, ref i, ref i);

			return new StreamReader(st);
		}

		public bool ExisteArchivo(string Fichero, int Version)
		{
			string[] files;

			Fichero = FormatearRuta(Fichero);
			files = ObtenerListaFicheros(Path.GetDirectoryName(Fichero), Version, false);
			for (int i = 0; i < files.Length; i++)
			{
				if (files[i] == Fichero)
					return true;
			}

			return false;
		}

		public string[] ObtenerListaDirectorios(string RutaRelativa)
		{
			Conexion.ChangeDir(ObtenerRuta(RutaRelativa));

			List<string> listadoDirs = Conexion.ListDirectories();
			for (int i = 0; i < listadoDirs.Count; i++)
			{
                listadoDirs[i] = listadoDirs[i].Substring(listadoDirs[i].LastIndexOf(' ')+1, listadoDirs[i].Length - listadoDirs[i].LastIndexOf(' ')-1);
			}

			return listadoDirs.ToArray();
		}

		public string[] ObtenerListaFicheros(string RutaRelativa, int Version, bool IncluirSubDirectorios)
		{
			RutaRelativa = FormatearRuta(RutaRelativa);
			List<string> listadoFiles = new List<string>();
			var ruta = ObtenerRuta(RutaRelativa, Version);
			ObtenerListaFicherosRecursiva(RutaRelativa, ref listadoFiles, IncluirSubDirectorios, ruta);

			return listadoFiles.ToArray();
		}

		#endregion

		#region Métodos privados

		private string ObtenerRuta(string RutaRelativa, int Version)
		{
			RutaRelativa = FormatearRuta(RutaRelativa);

			return string.Format("/{0}/{1}/{2}{3}", config.RutaRepositorio, config.NombreAplicacion, Version.ToString().PadLeft(10, '0'), RutaRelativa);
		}

		private string ObtenerRuta(string RutaRelativa)
		{
			RutaRelativa = FormatearRuta(RutaRelativa);

			return string.Format("/{0}/{1}{2}", config.RutaRepositorio, config.NombreAplicacion, RutaRelativa);
		}


		private void ObtenerListaFicherosRecursiva(string RutaRelativa, ref List<string> listadoFiles, bool IncluirSubDirectorios, string rutaBase)
		{
			Conexion.ChangeDir(rutaBase);
			rutaBase = string.Format("{0}{1}", rutaBase, RutaRelativa);

			var tmpList = Conexion.ListFiles();
			for (int i = 0; i < tmpList.Count; i++)
			{
				tmpList[i] = "/" + tmpList[i].Substring(tmpList[i].LastIndexOf(' ')+1, tmpList[i].Length - tmpList[i].LastIndexOf(' ')-1);
			}
			listadoFiles.AddRange(tmpList);

			if (IncluirSubDirectorios)
			{
				tmpList = Conexion.ListDirectories();
				foreach (string dir in tmpList)
				{
					ObtenerListaFicherosRecursiva(string.Format("{0}/{1}", RutaRelativa, dir.Substring(dir.LastIndexOf(' ')+1, dir.Length - dir.LastIndexOf(' ')-1)), ref listadoFiles, true, rutaBase);
				}
			}
		}

		private string FormatearRuta(string ruta)
		{
			if (!string.IsNullOrEmpty(ruta))
			{
				ruta = ruta.Replace(@"\", "/");
				if (ruta.EndsWith("/")) ruta = ruta.Substring(0, ruta.Length - 1);
				if (!ruta.StartsWith("/")) ruta = string.Format("/{0}", ruta);
				ruta = ruta.Replace("//", "/");
				if (ruta == "/") ruta = string.Empty;
			}
			return ruta;
		}
		#endregion

		#region IDisposable Members

		public void Dispose()
		{
			if (conexion != null)
			{
				if (conexion.IsConnected) conexion.Disconnect();
				conexion = null;
			}
		}

		#endregion
	}
}
