using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace MundiAudit.ActualizadorApp.Definiciones
{
	[Serializable]
	public class DefinicionVersion
	{
		/// <summary>
		/// Número de versión
		/// </summary>		
		public int Version { get; set; }
		/// <summary>
		/// Fecha de generación de la versión.
		/// </summary>
		public DateTime FechaGeneracion { get; set; }
		/// <summary>
		/// Comentarios de la versión
		/// </summary>
		public string Comentarios { get; set; }
		/// <summary>
		/// Fichero SQL con la actualización de la bbdd.
		/// </summary>
		public bool RequiereActualizarBBDD { get; set; }
        /// <summary>
        /// Define la versión requerida para la base de datos.
        /// </summary>
        public string VersionBaseDatosAnterior { get; set; }
        /// <summary>
        /// Indica la versión de base de datos requerida por esta actualización.
        /// </summary>
        public string VersionBaseDatosRequerida { get; set; }
		/// <summary>
		/// Lista de archivos de la versión
		/// </summary>
		public List<DefinicionArchivo> ListadoArchivos { get; set; }
		/// <summary>
		/// Serializa el objeto
		/// </summary>
		/// <param name="clase"></param>
		/// <param name="ruta"></param>
		public static void Guardar(DefinicionVersion objeto, string ruta)
		{
			FileStream fs = new FileStream(ruta, FileMode.CreateNew);
			new XmlSerializer(typeof(DefinicionVersion)).Serialize(fs,objeto);
			fs.Close();
		}
		/// <summary>
		/// Deserializa el objeto
		/// </summary>
		/// <param name="ruta"></param>
		/// <returns></returns>
		public DefinicionVersion Cargar(string ruta)
		{
			throw new NotImplementedException();
		}

		public static DefinicionVersion DeSerializar(Stream stream)
		{
            if (stream is MemoryStream)
                (stream as MemoryStream).Position = 0;

			DefinicionVersion def = (DefinicionVersion)new XmlSerializer(typeof(DefinicionVersion)).Deserialize(stream);
			stream.Close();
			return def;
		}

	}
}
