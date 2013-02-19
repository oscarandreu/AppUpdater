using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;
using System.IO;

namespace MundiAudit.ActualizadorApp.Definiciones
{
	[Serializable]
	public class ConfiguracionActualizador
	{
		/// <summary>
		/// Define el tipo de repositorio, FTP o FS (file system)
		/// </summary>
		[Category("General"), Description("Define el tipo de repositorio, FTP o FS (file system)")]
		public TipoRepositorio TipoRepositorio { get; set; }
		/// <summary>
		/// Ruta del repositorio
		/// </summary>
		[Category("General"), Description("Ruta del repositorio")]
		public string RutaRepositorio { get; set; }
		/// <summary>
		/// URL en caso que el repositorio sea FTP
		/// </summary>
		[Category("General"), Description("URL en caso que el repositorio sea FTP")]
		public string UrlFTP { get; set; }
		/// <summary>
		/// Usuario en caso que el repositorio sea FTP
		/// </summary>
		[Category("Datos FTP")]
		[Description(" Usuario en caso que el repositorio sea FTP")]
		public string UsuarioFTP { get; set; }
		/// <summary>
		/// Contraseña en caso de que el repositorio sea por FTP
		/// </summary>
		[Category("Datos FTP")]
		[Description("Contraseña en caso de que el repositorio sea por FTP")]
		public string PasswordFTP { get; set; }
		/// <summary>
		/// Nombre de la aplicación en el repositorio
		/// </summary>
		[Category("General"), Description("Nombre de la aplicación en el repositorio")]
		public string NombreAplicacion { get; set; }
		/// <summary>
		/// Indica la versión actual de la aplicación.
		/// </summary>
		public int VersionActual { get; set; }
		/// <summary>
		/// Define la ruta de la aplicación a actualizar.
		/// </summary>
		[Description("Define la ruta de la aplicación a actualizar."), Category("General")]
		public string RutaDeLaAplicacion { get; set; }
		/// <summary>
		/// Define el punto de entrada de la aplicación, se ejecutará al terminar el proceso de actualización
		/// </summary>
		[Description("Define la aplicación que se iniciará al terminar la actualización")]
		public string EjecutableEntrada { get; set; }
		[Description("Indica si se debe mostrar el actualizador de base de datos a los usuarios"), Category("Base de datos"), DisplayName("Mostrar actualizador SQL")]
		public bool MostrarAsistenteActualizacionBD { get; set; }
		[Description("Opcional: permite definir una consulta sql que debe devolver la versión de la base de datos, si se especifica una versión necesaria en la configuración de una actualización esta se validará"), Category("Base de datos")]
		public string SQLConsultaVersion { get; set; }

		public static ConfiguracionActualizador Cargar(string ruta)
		{
			//TODO: Quitar esto, Interrupción para poder engacharme a hacer debug (Óscar)
			//System.Windows.Forms.MessageBox.Show("AHH");

			XmlSerializer serializer = new XmlSerializer(typeof(ConfiguracionActualizador));
			FileStream fs = new FileStream(ruta, FileMode.Open);
			var c = (ConfiguracionActualizador)serializer.Deserialize(fs);
			fs.Close();

			return c;

		}
		public static void Guardar(string ruta, ConfiguracionActualizador objeto)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(ConfiguracionActualizador));
			if (File.Exists(ruta))
				File.Delete(ruta);

			FileStream fs = new FileStream(ruta, FileMode.CreateNew);
			serializer.Serialize(fs, objeto);
			fs.Close();
		}

	}

	public enum TipoRepositorio
	{
		Sistema_de_archivos,
		FTP,
        IIS_HttpFileSystem
	}
}
