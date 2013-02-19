using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MundiAudit.ActualizadorApp.Definiciones;
using MundiAudit.ActualizadorApp.Definiciones.Helpers;
using System.Threading;

namespace MundiAudit.ActualizadorApp
{
	public partial class AsistenteActualizacion : Form
	{
		private ActualizadorBIN actualizador;
		private string pasoAnterior;
		private long TamañoTotalDescarga = 0;
		private DateTime startTime = DateTime.Now;

		private object syncFinalizar = new object();
		private bool finalizar = false;
		public bool Finalizar
		{
			get
			{
				lock (syncFinalizar)
				{
					return finalizar;
				}
			}
			set
			{
				lock (syncFinalizar)
				{
					finalizar = value;
				}
			}
		}

		public AsistenteActualizacion(ActualizadorBIN actualizador)
		{
			InitializeComponent();
			this.actualizador = actualizador;
			actualizador.AccionIniciada += new EventHandler(actualizador_AccionIniciada);
			tmActualizador.Start();
			Application.DoEvents();
		}

		void actualizador_AccionIniciada(object sender, EventArgs e)
		{
			//Ha cambiado la acción actual del actualizador.

			if (!string.IsNullOrEmpty(pasoAnterior))
				Resultado(pasoAnterior, true);

			Log(actualizador.Accion, actualizador.Accion);
			pasoAnterior = actualizador.Accion;

		}

		private void tmActualizador_Tick(object sender, EventArgs e)
		{
			if (pbArchivos.Maximum != actualizador.TotalArchivos)
				pbArchivos.Maximum = actualizador.TotalArchivos;
			if (pbArchivos.Value != actualizador.ArchivosDescargados)
				pbArchivos.Value = actualizador.ArchivosDescargados;

			if (pbArchivo.Maximum != actualizador.BytesArchivo)
				pbArchivo.Maximum = Convert.ToInt32(actualizador.BytesArchivo);
			if (pbArchivo.Value != actualizador.BytesDescargados && actualizador.BytesDescargados < pbArchivo.Maximum)
				pbArchivo.Value = Convert.ToInt32(actualizador.BytesDescargados);

			if (lblArchivo.Text != actualizador.ArchivoEnDescarga)
				lblArchivo.Text = string.IsNullOrEmpty(actualizador.ArchivoEnDescarga) ? string.Empty : string.Format("Descargando: {0} ({1} kb)", actualizador.ArchivoEnDescarga, Convert.ToInt32(actualizador.BytesArchivo / 1024));

			if (TamañoTotalDescarga != actualizador.TamañoTotalDescarga)
				TamañoTotalDescarga = actualizador.TamañoTotalDescarga;

			if (finalizar)
			{
				Close();
			}
			//FormatETA();

			Application.DoEvents();
		}

		private void Log(string texto, string tag)
		{
			TreeNode node;
			node = new TreeNode(texto);
			node.Tag = tag;
			node.ImageIndex = 2;
			node.SelectedImageIndex = 2;
			tvUpdate.Invoke(new MethodInvoker(delegate()
			{
				tvUpdate.Nodes.Add(node);
			}));

			Application.DoEvents();
		}
		private void Resultado(string tag, bool result)
		{
			tvUpdate.Invoke(new MethodInvoker(delegate()
			{
				foreach (TreeNode node in tvUpdate.Nodes)
					if (node.Tag.Equals(tag))
					{
						node.ImageIndex = result ? 1 : 0;
						node.SelectedImageIndex = node.ImageIndex;
					}
			}));

			Application.DoEvents();

		}

		private void AsistenteActualizacion_Load(object sender, EventArgs e)
		{
			lock (actualizador.threadSinc)
			{
				Monitor.Pulse(actualizador.threadSinc);
			}
		}

		//private void FormatETA()
		//{
		//    double eta = getETA();

		//    if (eta != 0)
		//    {
		//        StringBuilder texto = new StringBuilder("Tiempo estimado: ");

		//        int hor = (int)Math.Truncate(eta / 3600);
		//        eta = eta - hor * 3600;
		//        int min = (int)Math.Truncate(eta / 60);
		//        eta = eta - min * 60;
		//        int sec = (int)(eta);

		//        if (hor != 0) texto.AppendFormat("{0} h. ", hor);
		//        if (min != 0) texto.AppendFormat("{0} min. ", min);
		//        if (sec != 0) texto.AppendFormat("{0} sec. ", sec);

		//        lblETA.Text = texto.ToString();
		//    }
		//    else
		//        lblETA.Text = string.Empty;
		//}
		//private double getETA()
		//{
		//    DateTime lapse = DateTime.Now;
		//    TimeSpan duration = lapse - startTime;

		//    if (actualizador.TotalBytesDescargados == 0 || TamañoTotalDescarga == 0 || actualizador.TotalBytesDescargados >= TamañoTotalDescarga)
		//        return 0;

		//    return (duration.Seconds * (TamañoTotalDescarga - actualizador.TotalBytesDescargados)) / actualizador.TotalBytesDescargados;
		//}
	}
}
