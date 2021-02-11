namespace CapaPresentacion.Formularios.FormsClientes
{
    partial class FrmClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClientes));
            this.btnReporteClientes = new System.Windows.Forms.Button();
            this.gbResultados = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbBusqueda = new System.Windows.Forms.GroupBox();
            this.dateBusqueda = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            this.gbBusqueda.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReporteClientes
            // 
            this.btnReporteClientes.BackColor = System.Drawing.Color.White;
            this.btnReporteClientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReporteClientes.FlatAppearance.BorderSize = 0;
            this.btnReporteClientes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnReporteClientes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnReporteClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporteClientes.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteClientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnReporteClientes.Image = ((System.Drawing.Image)(resources.GetObject("btnReporteClientes.Image")));
            this.btnReporteClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReporteClientes.Location = new System.Drawing.Point(6, 19);
            this.btnReporteClientes.Name = "btnReporteClientes";
            this.btnReporteClientes.Size = new System.Drawing.Size(182, 36);
            this.btnReporteClientes.TabIndex = 0;
            this.btnReporteClientes.Text = "Reporte de clientes";
            this.btnReporteClientes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReporteClientes.UseVisualStyleBackColor = false;
            // 
            // gbResultados
            // 
            this.gbResultados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbResultados.Location = new System.Drawing.Point(5, 73);
            this.gbResultados.Name = "gbResultados";
            this.gbResultados.Size = new System.Drawing.Size(880, 416);
            this.gbResultados.TabIndex = 6;
            this.gbResultados.TabStop = false;
            this.gbResultados.Text = "Resultados";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReporteClientes);
            this.groupBox1.Location = new System.Drawing.Point(5, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 66);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opciones";
            // 
            // gbBusqueda
            // 
            this.gbBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBusqueda.Controls.Add(this.dateBusqueda);
            this.gbBusqueda.Location = new System.Drawing.Point(221, 1);
            this.gbBusqueda.Name = "gbBusqueda";
            this.gbBusqueda.Size = new System.Drawing.Size(664, 66);
            this.gbBusqueda.TabIndex = 10;
            this.gbBusqueda.TabStop = false;
            this.gbBusqueda.Text = "Búsqueda por fecha";
            // 
            // dateBusqueda
            // 
            this.dateBusqueda.Location = new System.Drawing.Point(6, 24);
            this.dateBusqueda.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dateBusqueda.Name = "dateBusqueda";
            this.dateBusqueda.Size = new System.Drawing.Size(279, 25);
            this.dateBusqueda.TabIndex = 1;
            // 
            // FrmClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 494);
            this.Controls.Add(this.gbBusqueda);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbResultados);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmClientes";
            this.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Style.MdiChild.IconHorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            this.Text = "Clientes";
            this.groupBox1.ResumeLayout(false);
            this.gbBusqueda.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnReporteClientes;
        public System.Windows.Forms.GroupBox gbResultados;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbBusqueda;
        private System.Windows.Forms.DateTimePicker dateBusqueda;
    }
}