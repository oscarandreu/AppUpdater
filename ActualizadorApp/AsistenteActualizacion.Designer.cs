namespace MundiAudit.ActualizadorApp
{
	partial class AsistenteActualizacion
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AsistenteActualizacion));
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblTituloPrincipal = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pnlBotones = new System.Windows.Forms.Panel();
			this.pbArchivo = new System.Windows.Forms.ProgressBar();
			this.pbArchivos = new System.Windows.Forms.ProgressBar();
			this.label5 = new System.Windows.Forms.Label();
			this.tvUpdate = new System.Windows.Forms.TreeView();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.lblArchivo = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tmActualizador = new System.Windows.Forms.Timer(this.components);
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.pnlBotones.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.Controls.Add(this.lblTituloPrincipal);
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Location = new System.Drawing.Point(-2, -2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(512, 76);
			this.panel1.TabIndex = 1;
			// 
			// lblTituloPrincipal
			// 
			this.lblTituloPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lblTituloPrincipal.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTituloPrincipal.Location = new System.Drawing.Point(94, 11);
			this.lblTituloPrincipal.Name = "lblTituloPrincipal";
			this.lblTituloPrincipal.Size = new System.Drawing.Size(329, 55);
			this.lblTituloPrincipal.TabIndex = 1;
			this.lblTituloPrincipal.Text = "Actualizando aplicación.";
			this.lblTituloPrincipal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::MundiAudit.ActualizadorApp.Properties.Resources.system_software_update;
			this.pictureBox1.Location = new System.Drawing.Point(4, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(84, 70);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// pnlBotones
			// 
			this.pnlBotones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlBotones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlBotones.Controls.Add(this.pbArchivo);
			this.pnlBotones.Controls.Add(this.pbArchivos);
			this.pnlBotones.Controls.Add(this.label5);
			this.pnlBotones.Controls.Add(this.tvUpdate);
			this.pnlBotones.Location = new System.Drawing.Point(-14, 144);
			this.pnlBotones.Name = "pnlBotones";
			this.pnlBotones.Size = new System.Drawing.Size(537, 236);
			this.pnlBotones.TabIndex = 4;
			// 
			// pbArchivo
			// 
			this.pbArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pbArchivo.Location = new System.Drawing.Point(24, 194);
			this.pbArchivo.Name = "pbArchivo";
			this.pbArchivo.Size = new System.Drawing.Size(479, 23);
			this.pbArchivo.TabIndex = 1;
			// 
			// pbArchivos
			// 
			this.pbArchivos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pbArchivos.Location = new System.Drawing.Point(24, 165);
			this.pbArchivos.Name = "pbArchivos";
			this.pbArchivos.Size = new System.Drawing.Size(479, 23);
			this.pbArchivos.TabIndex = 0;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(24, 147);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(134, 13);
			this.label5.TabIndex = 15;
			this.label5.Text = "Progreso de la descarga.";
			// 
			// tvUpdate
			// 
			this.tvUpdate.BackColor = System.Drawing.Color.White;
			this.tvUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tvUpdate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tvUpdate.ImageIndex = 0;
			this.tvUpdate.ImageList = this.imageList1;
			this.tvUpdate.Indent = 20;
			this.tvUpdate.ItemHeight = 22;
			this.tvUpdate.Location = new System.Drawing.Point(24, 9);
			this.tvUpdate.Name = "tvUpdate";
			this.tvUpdate.SelectedImageIndex = 0;
			this.tvUpdate.ShowLines = false;
			this.tvUpdate.ShowPlusMinus = false;
			this.tvUpdate.ShowRootLines = false;
			this.tvUpdate.Size = new System.Drawing.Size(477, 130);
			this.tvUpdate.TabIndex = 14;
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.White;
			this.imageList1.Images.SetKeyName(0, "stop.png");
			this.imageList1.Images.SetKeyName(1, "Aceptado.png");
			this.imageList1.Images.SetKeyName(2, "none.bmp");
			// 
			// lblArchivo
			// 
			this.lblArchivo.AutoSize = true;
			this.lblArchivo.Location = new System.Drawing.Point(12, 392);
			this.lblArchivo.Name = "lblArchivo";
			this.lblArchivo.Size = new System.Drawing.Size(0, 13);
			this.lblArchivo.TabIndex = 16;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 89);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(482, 52);
			this.label2.TabIndex = 3;
			this.label2.Text = "Hay una nueva versión de la aplicación disponible.\r\nA continuación se procederá a" +
				" la descarga de las actualizaciones, este proceso puede tardar unos minutos.\r\n\r\n" +
				"";
			// 
			// tmActualizador
			// 
			this.tmActualizador.Tick += new System.EventHandler(this.tmActualizador_Tick);
			// 
			// AsistenteActualizacion
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(506, 424);
			this.Controls.Add(this.lblArchivo);
			this.Controls.Add(this.pnlBotones);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AsistenteActualizacion";
			this.Text = "AsistenteActualizacion";
			this.Load += new System.EventHandler(this.AsistenteActualizacion_Load);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.pnlBotones.ResumeLayout(false);
			this.pnlBotones.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblTituloPrincipal;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Panel pnlBotones;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ProgressBar pbArchivo;
		private System.Windows.Forms.ProgressBar pbArchivos;
		private System.Windows.Forms.TreeView tvUpdate;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Timer tmActualizador;
		private System.Windows.Forms.Label lblArchivo;
		private System.Windows.Forms.ImageList imageList1;
	}
}