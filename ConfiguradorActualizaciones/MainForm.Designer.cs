namespace MundiAudit.ConfiguradorActualizaciones
{
	partial class MainForm
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
			this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cbAplicacion
			// 
			this.cbAplicacion.FormattingEnabled = true;
			this.cbAplicacion.Location = new System.Drawing.Point(131, 50);
			this.cbAplicacion.Name = "cbAplicacion";
			this.cbAplicacion.Size = new System.Drawing.Size(316, 21);
			this.cbAplicacion.TabIndex = 0;
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
			this.tbRepositorio.Location = new System.Drawing.Point(131, 24);
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
			// checkedListBox1
			// 
			this.checkedListBox1.FormattingEnabled = true;
			this.checkedListBox1.Location = new System.Drawing.Point(131, 77);
			this.checkedListBox1.Name = "checkedListBox1";
			this.checkedListBox1.Size = new System.Drawing.Size(316, 139);
			this.checkedListBox1.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 77);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Versiones:";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(453, 77);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(82, 23);
			this.button1.TabIndex = 6;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(729, 676);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.checkedListBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbRepositorio);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cbAplicacion);
			this.Name = "MainForm";
			this.Text = "MainForm";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cbAplicacion;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbRepositorio;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckedListBox checkedListBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button1;
	}
}