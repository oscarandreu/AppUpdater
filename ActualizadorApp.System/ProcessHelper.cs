using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace MundiAudit.ActualizadorApp.Definiciones
{
	public class ProcessHelper
	{
		public static string GetFileProcessName(string filePath)
		{
			try
			{
				Process[] procs = Process.GetProcesses();
				string fileName = Path.GetFileName(filePath);

				foreach (Process proc in procs)
				{
					if (!proc.HasExited)//proc.MainWindowHandle != new IntPtr(0) && 
					{
						Debug.Print("---" + proc.ProcessName);
						ProcessModule[] arr = new ProcessModule[proc.Modules.Count];
						foreach (ProcessModule pm in proc.Modules)
						{
							Debug.Print(pm.ModuleName);
							if (pm.ModuleName == fileName)
								return proc.ProcessName;
						}
					}
				}
			}
			catch { }

			return null;
		}
	}
}
