using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MundiAudit.ActualizadorApp.Definiciones;
using MundiAudit.ActualizadorApp.Definiciones.Helpers;
using System.Data.SqlClient;

namespace MundiAudit.ActualizadorApp
{
	public partial class ActualizadorBD : UserControl
	{
		public string ConnectionString { get; set; }
		List<DefinicionVersion> Versiones;
		SortedList<int, string> SqlScripts;
		string CadenaConexion;
		string SQLObtenerVersion;

		public event ProcesoFinalizadoEventHandler ProcesoFinalizado;
		public delegate void ProcesoFinalizadoEventHandler(object sender, ProcesoFinalizadoEventArgs e);
		public class ProcesoFinalizadoEventArgs
		{
			public bool Resultado { get; private set; }
			public ProcesoFinalizadoEventArgs(bool Resultado)
			{
				this.Resultado = Resultado;
			}
		}

		public ActualizadorBD(string CadenaConexion, string SQLObtenerVersion, List<DefinicionVersion> Versiones, SortedList<int, string> SqlScripts)
		{
			InitializeComponent();
			this.Versiones = Versiones;
			this.SqlScripts = SqlScripts;
			this.CadenaConexion = CadenaConexion;
			this.SQLObtenerVersion = SQLObtenerVersion;
		}

		private void ActualizadorBD_Load(object sender, EventArgs e)
		{
			//ToDo: pasar a clase genérica.

			//Inicio testeo de scripts.

			//Validar la versión original de la BBDD
			//cojo la versión más baja.
			string versionNecesaria = "x";
			string versionActual = "y";
			bool result = true;

			try
			{
				Log("Comprobando versión actual", "checkVersion");
				int? min = null;
				foreach (int v in Versiones.ConvertAll<int>((x) => x.Version))
					if ((!min.HasValue) || min.Value > v)
						min = v;
				//y la compruebo
				versionNecesaria = Versiones.Find((x) => x.Version == min).VersionBaseDatosRequerida;
				versionActual = Convert.ToString(DBHelper.ExecuteScalar(CadenaConexion, SQLObtenerVersion));
			}
			catch
			{
				result = false;
			}
			if (versionActual.Equals(versionNecesaria))
			{
				Resultado("checkVersion", true);
			}
			else
			{
				Resultado("checkVersion", false);
				Log("No coinciden las versiones requerida y actual.");
				return;
			}
            
			//Iniciamos la ejecución de scripts transaccionalmente.

			SqlConnection connection = new SqlConnection(CadenaConexion);
			connection.Open();
			SqlTransaction transaction = connection.BeginTransaction();
			string key = string.Empty;
            bool hasError = false;
            try
            {
                foreach (var id in SqlScripts.Keys)
                {
                    key = "s:" + Convert.ToString(id);
                    Log(string.Format("Ejecutando actualización  a revisión {0}", Versiones.Find((x) => x.Version == id).Version), key);
                    string[] scripts = LimpiarScript(SqlScripts[id]).Split(new string[] { "\nGO" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string script in scripts)
                        new SqlCommand(script, connection, transaction).ExecuteNonQuery();

                    Resultado(key, true);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error en sql:\n" + ex.Message);
                Resultado(key, false);
                result = false;
                transaction.Rollback();
                hasError = true;
                return;
            }
            catch (Exception ex)
            {
                //ToDO: error al actualizar
                Resultado(key, false);
                result = false;
                transaction.Rollback();
                return;
            }
			finally
			{
                if (!hasError)
				    transaction.Commit();
			}

			if (ProcesoFinalizado != null)
				ProcesoFinalizado(this, new ProcesoFinalizadoEventArgs(result));
		}

		private void Log(string texto)
		{
			Log(texto, "");
		}
		private void Log(string texto, string tag)
		{
			TreeNode node;
			node = new TreeNode(texto);
			node.Tag = tag;
			node.ImageIndex = 2;
			node.SelectedImageIndex = 2;
			tvUpdate.Nodes.Add(node);
			Application.DoEvents();
		}
        private string LimpiarScript(string script)
        {
            string res = script.Replace("\r\n", "\n");

            string[] borrar = new string[]{
                "IF EXISTS (SELECT * FROM #tmpErrors) ROLLBACK TRANSACTION",
                "GO\nIF EXISTS (SELECT * FROM tempdb..sysobjects WHERE id=OBJECT_ID('tempdb..#tmpErrors')) DROP TABLE #tmpErrors\nGO\nCREATE TABLE #tmpErrors (Error int)\nGO\nSET XACT_ABORT ON\nGO\nSET TRANSACTION ISOLATION LEVEL SERIALIZABLE\nGO\nBEGIN TRANSACTION",
                "GO\nIF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION\nGO\nIF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END\nGO",
                "IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION\nGO\nIF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END\nGO",
                "GO\nIF @@TRANCOUNT>0 BEGIN\nPRINT 'The database update succeeded'\nCOMMIT TRANSACTION\nEND\nELSE PRINT 'The database update failed'\nGO\nDROP TABLE #tmpErrors"
            };
            foreach (string rep in borrar)
                res = res.Replace(rep, "GO\n");
            return res;
        }
		private void Resultado(string tag, bool result)
		{
			foreach (TreeNode node in tvUpdate.Nodes)
				if (node.Tag.Equals(tag))
				{
					node.ImageIndex = result ? 1 : 0;
					node.SelectedImageIndex = node.ImageIndex;
				}

			Application.DoEvents();

		}
	}
}
