namespace MundiAudit.ActualizadorApp
{
    partial class AsistenteActualizacionBD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AsistenteActualizacionBD));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.pnlWizard = new System.Windows.Forms.Panel();
            this.cmdAnterior = new System.Windows.Forms.Button();
            this.cmdSiguiente = new System.Windows.Forms.Button();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.lbPaso = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(-3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(536, 76);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(83, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(446, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Asistente de configuración de base de datos";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MundiAudit.ActualizadorApp.Properties.Resources.Upload_Database;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(505, 61);
            this.label2.TabIndex = 1;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // pnlBotones
            // 
            this.pnlBotones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlBotones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBotones.Controls.Add(this.pnlWizard);
            this.pnlBotones.Location = new System.Drawing.Point(-3, 149);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(535, 277);
            this.pnlBotones.TabIndex = 2;
            // 
            // pnlWizard
            // 
            this.pnlWizard.Location = new System.Drawing.Point(13, 32);
            this.pnlWizard.Name = "pnlWizard";
            this.pnlWizard.Size = new System.Drawing.Size(505, 220);
            this.pnlWizard.TabIndex = 3;
            // 
            // cmdAnterior
            // 
            this.cmdAnterior.Enabled = false;
            this.cmdAnterior.Location = new System.Drawing.Point(235, 436);
            this.cmdAnterior.Name = "cmdAnterior";
            this.cmdAnterior.Size = new System.Drawing.Size(90, 28);
            this.cmdAnterior.TabIndex = 5;
            this.cmdAnterior.Text = "< Anterior";
            this.cmdAnterior.UseVisualStyleBackColor = true;
            this.cmdAnterior.Click += new System.EventHandler(this.cmdAnterior_Click);
            // 
            // cmdSiguiente
            // 
            this.cmdSiguiente.Enabled = false;
            this.cmdSiguiente.Location = new System.Drawing.Point(326, 436);
            this.cmdSiguiente.Name = "cmdSiguiente";
            this.cmdSiguiente.Size = new System.Drawing.Size(90, 28);
            this.cmdSiguiente.TabIndex = 4;
            this.cmdSiguiente.Text = "Siguiente >";
            this.cmdSiguiente.UseVisualStyleBackColor = true;
            this.cmdSiguiente.Click += new System.EventHandler(this.cmdSiguiente_Click);
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.Location = new System.Drawing.Point(432, 436);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(90, 28);
            this.cmdCancelar.TabIndex = 3;
            this.cmdCancelar.Text = "Cancelar";
            this.cmdCancelar.UseVisualStyleBackColor = true;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // lbPaso
            // 
            this.lbPaso.AutoSize = true;
            this.lbPaso.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPaso.Location = new System.Drawing.Point(23, 158);
            this.lbPaso.Name = "lbPaso";
            this.lbPaso.Size = new System.Drawing.Size(119, 21);
            this.lbPaso.TabIndex = 4;
            this.lbPaso.Text = "Paso {0} de {1}";
            // 
            // AsistenteActualizacionBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 474);
            this.Controls.Add(this.cmdAnterior);
            this.Controls.Add(this.lbPaso);
            this.Controls.Add(this.cmdSiguiente);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AsistenteActualizacionBD";
            this.Text = "Asistente actualizacion base de datos";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button cmdAnterior;
        private System.Windows.Forms.Button cmdSiguiente;
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.Panel pnlWizard;
        private System.Windows.Forms.Label lbPaso;
    }
}