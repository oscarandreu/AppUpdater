using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MundiAudit.ActualizadorApp.Definiciones;

namespace MundiAudit.ActualizadorApp
{
    public partial class AsistenteActualizacionBD : Form
    {
        int paso_asistente = 1;
        ConfiguracionBaseDatos configurador = new ConfiguracionBaseDatos();
        ActualizadorBD actualizador;
        ConfiguracionActualizador Config;
        List<DefinicionVersion> Versiones;
        SortedList<int, string> SqlScripts;
        string CadenaConexion;

        public AsistenteActualizacionBD(ConfiguracionActualizador Config, List<DefinicionVersion> Versiones, SortedList<int, string> SqlScripts,string CadenaConexion)
        {            
            InitializeComponent();
            configurador.ConexionConfigurada += new EventHandler(configurador_ConexionConfigurada);
           // MostrarPaso();
            this.Config = Config;
            this.Versiones = Versiones;
            this.SqlScripts = SqlScripts;
            this.CadenaConexion = CadenaConexion;
            MostrarPaso();
        }

        private void MostrarPaso()
        {
            this.pnlWizard.Controls.Clear();

            lbPaso.Text = string.Format("Paso {0} de 2", paso_asistente);

            switch (paso_asistente)
            {
                case 1:
                    this.cmdSiguiente.Text = "Siguiente >";
                    configurador.CadenaConexion = CadenaConexion;
                    this.pnlWizard.Controls.Add(configurador);
                    break;
                case 2:
                    this.cmdSiguiente.Text = "Finalizar";
                    this.pnlWizard.Controls.Add(actualizador);
                    break;
            }
        }

        void configurador_ConexionConfigurada(object sender, EventArgs e)
        {
            cmdSiguiente.Enabled = configurador.ConexionValida;
        }

        private void cmdSiguiente_Click(object sender, EventArgs e)
        {
            switch (paso_asistente)
            {
                case 1:
                    if (!configurador.ConexionValida)
                    {
                        MessageBox.Show("No ha sido posible conectar con la base de datos, configure la conexión y haga clic en 'probar conexión'", "Error en la conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cmdSiguiente.Enabled = false;
                        return;
                    }
                    actualizador = new ActualizadorBD(configurador.CadenaConexion, Config.SQLConsultaVersion, Versiones, SqlScripts);
                    actualizador.ProcesoFinalizado += new ActualizadorBD.ProcesoFinalizadoEventHandler(actualizador_ProcesoFinalizado);
                    paso_asistente = 2;
                    cmdSiguiente.Enabled = false;
                    cmdAnterior.Enabled = true;
                    MostrarPaso();
                    break;
                case 2:
                    DialogResult = DialogResult.OK;
                    Close();                    
                    break;
            }
        }

        void actualizador_ProcesoFinalizado(object sender, ActualizadorBD.ProcesoFinalizadoEventArgs e)
        {
            if (e.Resultado)
            {
                this.cmdSiguiente.Enabled = true;
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;            
            Close();
        }

        private void cmdAnterior_Click(object sender, EventArgs e)
        {
            if (paso_asistente == 2)
            {
                paso_asistente = 1;
                MostrarPaso();
                cmdAnterior.Enabled = false;
                cmdSiguiente.Enabled = true;
            }
        }
    }
}
