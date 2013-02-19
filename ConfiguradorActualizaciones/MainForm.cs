using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

namespace MundiAudit.ConfiguradorActualizaciones
{
	public partial class MainForm : Form
	{
		private string rutaRepositorio = string.Empty;

		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			//Cargamos los valores de configuración
			
			
			try
			{
				rutaRepositorio = ConfigurationSettings.AppSettings["RutaRepositorio"];
				if (!rutaRepositorio.EndsWith("\\"))
					rutaRepositorio += "\\";

				tbRepositorio.Text = rutaRepositorio;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Se ha producido un error leyendo el fichero de configuración, revise los parámetros");
			}

			if (!Directory.Exists(rutaRepositorio))
			{
				MessageBox.Show("No se ha encontrado la ruta del repositorio");
				Close();
			}

			//mostramos la lista de aplicaciones en el repositorio
			CargarListaAplicaciones();

		}

		private void CargarListaAplicaciones()
		{
			var dirs = Directory.GetDirectories(rutaRepositorio);
			foreach (string dir in dirs)
				cbAplicacion.Items.Add(dir.Replace(rutaRepositorio, string.Empty));

		}
	}
}
