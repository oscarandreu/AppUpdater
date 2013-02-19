using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MundiAudit.ActualizadorApp.Definiciones;
using System.Diagnostics;
using System.Collections;
using System.Threading;
using System.Text;
using System.IO;
using MundiAudit.ActualizadorApp.Definiciones.Helpers;

namespace MundiAudit.ActualizadorApp
{
	static class Program
	{

		/// <summary>
		/// Punto de entrada principal para la aplicación.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			//MessageBox.Show("WHOW");

			ProcessStartInfo psi = null;
			Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);

			ConfiguracionActualizador config = null;
			bool actualizarActualizador = false;
			try
			{
				config = ConfiguracionActualizador.Cargar("actualizador.config.xml");
				new ProcesoActualizacion(config).Iniciar();

				

				//Comprobamos is existen actualizaciones de actualizador
				string carpetaActualizacion = string.Format(@"{0}\{1}", Application.StartupPath, GeneradorVersion.CARPETA_ACTUALIZACION);
				if (Directory.Exists(carpetaActualizacion))
				{
					foreach (string file in Directory.GetFiles(carpetaActualizacion))
					{
						//TODO: Falta implemetar el borrado de archivos obsoletos
						if (HashHelper.CalcularHashArchivo(string.Format(@"{0}\{1}", Application.StartupPath, Path.GetFileName(file))) != HashHelper.CalcularHashArchivo(file))
						{
							actualizarActualizador = true;
							break;
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Se ha producido un error tratando de actualizar la aplicación.\n\n" + ex.Message, "Error al actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
                if (actualizarActualizador)
                {
                    psi = new ProcessStartInfo(config.EjecutableEntrada);
                    psi.FileName = string.Format(@"{0}\UpdaterActualizador.exe", Application.StartupPath);
                }
                else
                {
                    //Preparamos la invocacion de la aplicacion
                    var stb = new StringBuilder();
                    psi = new ProcessStartInfo(config.EjecutableEntrada);

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
                }

				if (psi != null && !string.IsNullOrEmpty(psi.FileName))
				{
					Process.Start(psi);
				}
			}
		}

		static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
		{
			MessageBox.Show("No ha sido posible actualizar la aplicación, contacte con su administrador", "Error al actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
			Application.Exit();
		}
	}
}
