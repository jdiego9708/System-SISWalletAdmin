
namespace CapaPresentacion.Formularios.FormsEstadisticas
{
    partial class FrmEstadisticasDiarias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEstadisticasDiarias));
            this.btnReporteClientes = new System.Windows.Forms.Button();
            this.gbBusqueda = new System.Windows.Forms.GroupBox();
            this.dateBusqueda = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbResultados = new System.Windows.Forms.GroupBox();
            this.gbBusqueda.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            // gbBusqueda
            // 
            this.gbBusqueda.Controls.Add(this.dateBusqueda);
            this.gbBusqueda.Location = new System.Drawing.Point(12, 12);
            this.gbBusqueda.Name = "gbBusqueda";
            this.gbBusqueda.Size = new System.Drawing.Size(296, 66);
            this.gbBusqueda.TabIndex = 13;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReporteClientes);
            this.groupBox1.Location = new System.Drawing.Point(12, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 66);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opciones";
            // 
            // gbResultados
            // 
            this.gbResultados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbResultados.Location = new System.Drawing.Point(314, 12);
            this.gbResultados.Name = "gbResultados";
            this.gbResultados.Size = new System.Drawing.Size(564, 470);
            this.gbResultados.TabIndex = 11;
            this.gbResultados.TabStop = false;
            this.gbResultados.Text = "Resultados";
            // 
            // FrmEstadisticasDiarias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(890, 494);
            this.Controls.Add(this.gbBusqueda);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbResultados);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmEstadisticasDiarias";
            this.Text = "Reporte diario";
            this.gbBusqueda.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReporteClientes;
        private System.Windows.Forms.GroupBox gbBusqueda;
        private System.Windows.Forms.DateTimePicker dateBusqueda;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.GroupBox gbResultados;
    }
}