namespace MundiAudit.ConfiguradorActualizaciones
{
	partial class NuevaVersion
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
			this.cbAplicacion = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tbRepositorio = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbRutaBinarios = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.tbSql = new System.Windows.Forms.TextBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.tbComentarios = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.button4 = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.lbinfo = new System.Windows.Forms.Label();
			this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.label7 = new System.Windows.Forms.Label();
			this.tbVersionBBDD = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.tbVersionBBDDActual = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// cbAplicacion
			// 
			this.cbAplicacion.FormattingEnabled = true;
			this.cbAplicacion.Location = new System.Drawing.Point(192, 50);
			this.cbAplicacion.Name = "cbAplicacion";
			this.cbAplicacion.Size = new System.Drawing.Size(316, 21);
			this.cbAplicacion.TabIndex = 0;
			this.cbAplicacion.SelectedIndexChanged += new System.EventHandler(this.cbAplicacion_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(101, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Ruta del repositorio:";
			// 
			// tbRepositorio
			// 
			this.tbRepositorio.Enabled = false;
			this.tbRepositorio.Location = new System.Drawing.Point(192, 24);
			this.tbRepositorio.Name = "tbRepositorio";
			this.tbRepositorio.Size = new System.Drawing.Size(316, 20);
			this.tbRepositorio.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 53);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Aplicación:";
			// 
			// tbRutaBinarios
			// 
			this.tbRutaBinarios.Location = new System.Drawing.Point(192, 132);
			this.tbRutaBinarios.Name = "tbRutaBinarios";
			this.tbRutaBinarios.Size = new System.Drawing.Size(316, 20);
			this.tbRutaBinarios.TabIndex = 4;
			this.tbRutaBinarios.Text = "C:\\Desarrollo\\Mundiaudit\\SIAudit\\Contratadas\\Contratadas\\ControlFinanciero\\WinUI\\" +
				"bin\\Debug";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 135);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(87, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Ruta de binarios:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 184);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(92, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Ruta fichero SQL:";
			// 
			// tbSql
			// 
			this.tbSql.Location = new System.Drawing.Point(192, 181);
			this.tbSql.Name = "tbSql";
			this.tbSql.Size = new System.Drawing.Size(316, 20);
			this.tbSql.TabIndex = 6;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Location = new System.Drawing.Point(192, 158);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(121, 17);
			this.checkBox1.TabIndex = 8;
			this.checkBox1.Text = "incluir subdirectorios";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(514, 132);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(35, 20);
			this.button1.TabIndex = 9;
			this.button1.Text = "...";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(514, 181);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(35, 20);
			this.button2.TabIndex = 10;
			this.button2.Text = "...";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// tbComentarios
			// 
			this.tbComentarios.Location = new System.Drawing.Point(192, 295);
			this.tbComentarios.Multiline = true;
			this.tbComentarios.Name = "tbComentarios";
			this.tbComentarios.Size = new System.Drawing.Size(316, 88);
			this.tbComentarios.TabIndex = 11;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 295);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(131, 13);
			this.label5.TabIndex = 12;
			this.label5.Text = "Comentarios de la versión:";
			// 
			// button4
			// 
			this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button4.Location = new System.Drawing.Point(435, 418);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(109, 23);
			this.button4.TabIndex = 14;
			this.button4.Text = "Generar versión";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 79);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(117, 13);
			this.label6.TabIndex = 15;
			this.label6.Text = "Información de versión:";
			// 
			// lbinfo
			// 
			this.lbinfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbinfo.Location = new System.Drawing.Point(192, 79);
			this.lbinfo.Name = "lbinfo";
			this.lbinfo.Size = new System.Drawing.Size(316, 45);
			this.lbinfo.TabIndex = 16;
			this.lbinfo.Text = "Seleccione una aplicación...";
			// 
			// openFileDialog
			// 
			this.openFileDialog.FileName = "openFileDialog1";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(12, 210);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(131, 13);
			this.label7.TabIndex = 18;
			this.label7.Text = "Versión anterior de BBDD:";
			// 
			// tbVersionBBDD
			// 
			this.tbVersionBBDD.Location = new System.Drawing.Point(192, 207);
			this.tbVersionBBDD.Name = "tbVersionBBDD";
			this.tbVersionBBDD.Size = new System.Drawing.Size(90, 20);
			this.tbVersionBBDD.TabIndex = 17;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(12, 236);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(140, 13);
			this.label8.TabIndex = 20;
			this.label8.Text = "Versión requerida de BBDD:";
			// 
			// tbVersionBBDDActual
			// 
			this.tbVersionBBDDActual.Location = new System.Drawing.Point(192, 233);
			this.tbVersionBBDDActual.Name = "tbVersionBBDDActual";
			this.tbVersionBBDDActual.Size = new System.Drawing.Size(90, 20);
			this.tbVersionBBDDActual.TabIndex = 19;
			// 
			// NuevaVersion
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(556, 453);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.tbVersionBBDDActual);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.tbVersionBBDD);
			this.Controls.Add(this.lbinfo);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.tbComentarios);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tbSql);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tbRutaBinarios);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbRepositorio);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cbAplicacion);
			this.Name = "NuevaVersion";
			this.Text = "Crear nueva versión.";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cbAplicacion;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbRepositorio;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbRutaBinarios;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbSql;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox tbComentarios;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lbinfo;
		private System.Windows.Forms.FolderBrowserDialog folderDialog;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbVersionBBDD;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbVersionBBDDActual;
	}
}