using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;

namespace UpdaterActualizador
{
	class Program
	{
		private const string CARPETA_ACTUALIZACION = "ActUpdtr";

		static void Main(string[] args)
		{
			Console.Out.WriteLine("Aplicando cambios en el actualizador...");

			//MessageBox.Show("WHOW");
			//Damos un segundo para que se termine de cerrar el actualizador
			Thread.Sleep(1000);
			var stb = new StringBuilder();
			var psi = new ProcessStartInfo(string.Format(@"{0}\ActualizadorApp.exe", Application.StartupPath));

			if (args != null && args.Length > 0)
			{
				psi.UseShellExecute = false;

				foreach (string arg in args)
				{
					if (stb.Length > 0) stb.Append(" ");
					stb.Append(arg);
				}
			}
			psi.Arguments = stb.ToString();

			try
			{
				int numErrores = 0;
				if (Directory.Exists(CARPETA_ACTUALIZACION))
				{
					foreach (string file in Directory.GetFiles(CARPETA_ACTUALIZACION))
					{
						do
						{
							try
							{
								if (numErrores > 0) Thread.Sleep(1000);
								File.Copy(string.Format(@"{0}\{1}", Application.StartupPath, file), string.Format(@"{0}\{1}", Application.StartupPath, Path.GetFileName(file)), true);
								numErrores = 0;
							}
							catch
							{ numErrores++; }
						} while (numErrores > 0 && numErrores < 5);
					}
				}
			}
			finally
			{
				Process.Start(psi);
			}
		}
	}
}
