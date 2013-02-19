using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MundiAudit.ActualizadorApp
{
	public partial class ConfiguracionBaseDatos : UserControl
	{
		public event EventHandler ConexionConfigurada;

		public string CadenaConexion
		{
			get
			{
				return connectionBuilder.ConnectionString;
			}
			set
			{
				connectionBuilder.ConnectionString = value;
				tbPassword.Text = connectionBuilder.Password;
				tbServidor.Text = connectionBuilder.DataSource;
				tbUsuario.Text = connectionBuilder.UserID;
				checkBox1.Checked = connectionBuilder.IntegratedSecurity;
			}
		}

		public bool ConexionValida
		{
			get
			{
				return TestConexion();
			}
		}

		SqlConnectionStringBuilder connectionBuilder = new SqlConnectionStringBuilder();

		public ConfiguracionBaseDatos()
		{
			InitializeComponent();
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			pnlLoginInfo.Enabled = !checkBox1.Checked;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (TestConexion())
			{
				if (ConexionConfigurada != null)
					ConexionConfigurada(this, new EventArgs());
				MessageBox.Show("Conexión con la base de datos satisfactoria", "Conexión válida", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("No ha sido posible conectar con el servidor.", "Error al conectar", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private bool TestConexion()
		{
			ActualizarConexion();

			SqlConnection conn = new SqlConnection(connectionBuilder.ConnectionString);
			try
			{
				conn.Open();
				conn.Close();
				return true;
			}
			catch
			{
				return false;
			}
		}

		private void ActualizarConexion()
		{
			connectionBuilder.DataSource = tbServidor.Text;
			connectionBuilder.IntegratedSecurity = checkBox1.Checked;
			connectionBuilder.UserID = tbUsuario.Text;
			connectionBuilder.Password = tbPassword.Text;


		}

	}
}
