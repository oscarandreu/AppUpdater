using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MundiAudit.ActualizadorApp.Definiciones;

namespace MundiAudit.ConfiguradorActualizaciones
{
	public partial class ConfiguradorActualizador : Form
	{
		ConfiguracionActualizador config = new ConfiguracionActualizador();
		
		public ConfiguradorActualizador()
		{
			InitializeComponent();
			PropertyEditor.SelectedObject = config;
		}

		private void salirToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			saveFileDialog.FileName = "actualizador.config.xml";
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
				ConfiguracionActualizador.Guardar(saveFileDialog.FileName,config);
		}

		private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
		{			
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				config = ConfiguracionActualizador.Cargar(openFileDialog.FileName);
				PropertyEditor.SelectedObject = config;
			}
		}
	}
}
