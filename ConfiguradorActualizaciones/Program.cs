using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MundiAudit.ActualizadorApp;

namespace MundiAudit.ConfiguradorActualizaciones
{
	static class Program
	{
		/// <summary>
		/// Punto de entrada principal para la aplicación.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Main());
			//Application.Run(new ConfiguradorActualizador());
			//Application.Run(new NuevaVersion());
		}
	}
}
