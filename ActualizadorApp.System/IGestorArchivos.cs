using System;
using System.Collections.Generic;
using System.IO;

namespace MundiAudit.ActualizadorApp.Definiciones
{
	public interface IGestorArchivos
	{
		/// <summary>
		/// Carga un fichero en memoria.
		/// </summary>
		/// <param name="Fichero"></param>
		/// <param name="Config"></param>
		/// <param name="Version"></param>
		/// <returns></returns>
		Stream CargarArchivo(string Fichero, int Version, ref long fileSize, ref long downladedBytes);
		StreamReader CargarArchivoTexto(string Fichero, int Version);

		/// <summary>
		/// Carga un fichero en memoria.
		/// </summary>
		/// <param name="Fichero"></param>
		/// <param name="Config"></param>
		/// <param name="Version"></param>
		/// <returns></returns>
		bool ExisteArchivo(string Fichero, int Version);

		/// <summary>
		/// Devuelve una lista de directorios dependendiendo de la configuración del actualizador.
		/// </summary>
		/// <param name="RutaRelativa"></param>
		/// <param name="Config"></param>
		/// <returns></returns>
		string[] ObtenerListaDirectorios(string RutaRelativa);

		long ObtenerTamañoTotalDescarga(List<string> archivos, int Version);

		/// <summary>
		/// Obtiene la lista de archivos existentes dentro de la ruta relativa dentro del repositorio indicado en configuración del actualizador.
		/// </summary>
		/// <param name="RutaRelativa"></param>
		/// <param name="Config"></param>
		/// <param name="Version"></param>
		/// <param name="IncluirSubDirectorios"></param>
		/// <returns></returns>
		string[] ObtenerListaFicheros(string RutaRelativa, int Version, bool IncluirSubDirectorios);

	}
}
