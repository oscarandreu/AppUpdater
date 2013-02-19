using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MundiAudit.ConfiguradorActualizaciones;

namespace MundiAudit.ActualizadorApp
{
	public partial class Main : Form
	{
		public Main()
		{
			InitializeComponent();

			var f = new NuevaVersion();
			f.ControlBox = true;
			f.TopLevel = false;
			tabPage1.Controls.Add(f);
			f.FormBorderStyle = FormBorderStyle.None;
			f.Dock = DockStyle.Fill;
			f.Show();

			var g = new ConfiguradorActualizador();
			g.ControlBox = true;
			g.TopLevel = false;
			tabPage2.Controls.Add(g);
			g.FormBorderStyle = FormBorderStyle.None;
			g.Dock = DockStyle.Fill;
			g.Show();
		}
	}
}
