namespace MundiAudit.ActualizadorApp
{
    partial class ConfiguracionBaseDatos
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbServidor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlLoginInfo = new System.Windows.Forms.Panel();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbUsuario = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlLoginInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Servidor:";
            // 
            // tbServidor
            // 
            this.tbServidor.Location = new System.Drawing.Point(120, 89);
            this.tbServidor.Name = "tbServidor";
            this.tbServidor.Size = new System.Drawing.Size(220, 22);
            this.tbServidor.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Usuario:";
            // 
            // pnlLoginInfo
            // 
            this.pnlLoginInfo.Controls.Add(this.tbPassword);
            this.pnlLoginInfo.Controls.Add(this.label3);
            this.pnlLoginInfo.Controls.Add(this.tbUsuario);
            this.pnlLoginInfo.Controls.Add(this.label2);
            this.pnlLoginInfo.Enabled = false;
            this.pnlLoginInfo.Location = new System.Drawing.Point(47, 148);
            this.pnlLoginInfo.Name = "pnlLoginInfo";
            this.pnlLoginInfo.Size = new System.Drawing.Size(302, 55);
            this.pnlLoginInfo.TabIndex = 3;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(73, 29);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '#';
            this.tbPassword.Size = new System.Drawing.Size(220, 22);
            this.tbPassword.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Contraseña:";
            // 
            // tbUsuario
            // 
            this.tbUsuario.Location = new System.Drawing.Point(73, 3);
            this.tbUsuario.Name = "tbUsuario";
            this.tbUsuario.Size = new System.Drawing.Size(220, 22);
            this.tbUsuario.TabIndex = 3;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(120, 117);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(132, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Seguridad integrada";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(9, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(483, 50);
            this.label4.TabIndex = 7;
            this.label4.Text = "Introduzca los datos de conexión de su servidor SQL y haga clic en \'probar conexi" +
                "ón\'.\r\nEl usuario deberá tener privilegios administrativos para poder actualizar " +
                "el modelo de base de datos.";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(367, 150);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Probar conexión";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(236, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Configuración del servidor de base de datos";
            // 
            // ConfiguracionBaseDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.pnlLoginInfo);
            this.Controls.Add(this.tbServidor);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ConfiguracionBaseDatos";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(500, 220);
            this.pnlLoginInfo.ResumeLayout(false);
            this.pnlLoginInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbServidor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlLoginInfo;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbUsuario;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
    }
}
