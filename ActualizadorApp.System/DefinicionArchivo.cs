using System;
using System.Collections.Generic;
using System.Text;

namespace MundiAudit.ActualizadorApp.Definiciones
{
	[Serializable]
	public class DefinicionArchivo
	{
		public string RutaArchivo { get; set; }

		public string HashArchivo { get; set; }

		public DateTime FechaCreacion { get; set; }
	}
}
