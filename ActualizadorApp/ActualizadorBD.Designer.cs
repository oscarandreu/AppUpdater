namespace MundiAudit.ActualizadorApp
{
    partial class ActualizadorBD
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActualizadorBD));
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tvUpdate = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Validando base de datos.";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(480, 47);
            this.label4.TabIndex = 10;
            this.label4.Text = "Se va a proceder con la actualización de la base de datos. Este proceso ejecutará" +
                " las actualizaciones incrementalmente hasta la versión instalada actualmente.\r\n\r" +
                "\n";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tvUpdate
            // 
            this.tvUpdate.BackColor = System.Drawing.Color.White;
            this.tvUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tvUpdate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvUpdate.ImageIndex = 2;
            this.tvUpdate.ImageList = this.imageList1;
            this.tvUpdate.Indent = 20;
            this.tvUpdate.ItemHeight = 22;
            this.tvUpdate.Location = new System.Drawing.Point(8, 74);
            this.tvUpdate.Name = "tvUpdate";
            this.tvUpdate.SelectedImageIndex = 2;
            this.tvUpdate.ShowLines = false;
            this.tvUpdate.ShowPlusMinus = false;
            this.tvUpdate.ShowRootLines = false;
            this.tvUpdate.Size = new System.Drawing.Size(477, 132);
            this.tvUpdate.TabIndex = 13;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.White;
            this.imageList1.Images.SetKeyName(0, "stop.png");
            this.imageList1.Images.SetKeyName(1, "Aceptado.png");
            this.imageList1.Images.SetKeyName(2, "none.bmp");
            // 
            // ActualizadorBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tvUpdate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ActualizadorBD";
            this.Size = new System.Drawing.Size(495, 220);
            this.Load += new System.EventHandler(this.ActualizadorBD_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TreeView tvUpdate;
        private System.Windows.Forms.ImageList imageList1;
    }
}
