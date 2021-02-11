namespace CapaPresentacion.Formularios.FormsPrincipales
{
    partial class FrmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.panelBotones = new System.Windows.Forms.Panel();
            this.listaCobros = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNotificaciones = new System.Windows.Forms.Button();
            this.panelBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBotones
            // 
            this.panelBotones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBotones.BackColor = System.Drawing.Color.SteelBlue;
            this.panelBotones.Controls.Add(this.btnNotificaciones);
            this.panelBotones.Controls.Add(this.listaCobros);
            this.panelBotones.Location = new System.Drawing.Point(0, 0);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(932, 42);
            this.panelBotones.TabIndex = 0;
            // 
            // listaCobros
            // 
            this.listaCobros.BackColor = System.Drawing.Color.SteelBlue;
            this.listaCobros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listaCobros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listaCobros.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listaCobros.ForeColor = System.Drawing.Color.White;
            this.listaCobros.FormattingEnabled = true;
            this.listaCobros.Location = new System.Drawing.Point(8, 5);
            this.listaCobros.Name = "listaCobros";
            this.listaCobros.Size = new System.Drawing.Size(276, 33);
            this.listaCobros.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(0, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(932, 547);
            this.panel1.TabIndex = 1;
            // 
            // btnNotificaciones
            // 
            this.btnNotificaciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNotificaciones.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnNotificaciones.FlatAppearance.BorderSize = 0;
            this.btnNotificaciones.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnNotificaciones.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleTurquoise;
            this.btnNotificaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotificaciones.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNotificaciones.ForeColor = System.Drawing.Color.White;
            this.btnNotificaciones.Image = ((System.Drawing.Image)(resources.GetObject("btnNotificaciones.Image")));
            this.btnNotificaciones.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNotificaciones.Location = new System.Drawing.Point(300, 5);
            this.btnNotificaciones.Name = "btnNotificaciones";
            this.btnNotificaciones.Size = new System.Drawing.Size(211, 31);
            this.btnNotificaciones.TabIndex = 20;
            this.btnNotificaciones.Text = "Notificaciones";
            this.btnNotificaciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNotificaciones.UseVisualStyleBackColor = true;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(933, 588);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelBotones);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmPrincipal";
            this.Text = "Administración SISWallet";
            this.panelBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox listaCobros;
        public System.Windows.Forms.Button btnNotificaciones;
    }
}