namespace CapaPresentacion.Formularios.FormsClientes
{
    partial class FrmConfiguracionCargaClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfiguracionCargaClientes));
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.gb2 = new System.Windows.Forms.GroupBox();
            this.listaProductos = new System.Windows.Forms.ComboBox();
            this.gb4 = new System.Windows.Forms.GroupBox();
            this.listaInteres = new System.Windows.Forms.ComboBox();
            this.gb5 = new System.Windows.Forms.GroupBox();
            this.listaFrecuencia = new System.Windows.Forms.ComboBox();
            this.btnIniciarImportacion = new System.Windows.Forms.Button();
            this.listaCobro = new System.Windows.Forms.ComboBox();
            this.gb1.SuspendLayout();
            this.gb2.SuspendLayout();
            this.gb4.SuspendLayout();
            this.gb5.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.listaCobro);
            this.gb1.Location = new System.Drawing.Point(5, 6);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(291, 79);
            this.gb1.TabIndex = 21;
            this.gb1.TabStop = false;
            this.gb1.Text = "Seleccione un cobro";
            // 
            // gb2
            // 
            this.gb2.Controls.Add(this.listaProductos);
            this.gb2.Location = new System.Drawing.Point(302, 6);
            this.gb2.Name = "gb2";
            this.gb2.Size = new System.Drawing.Size(294, 79);
            this.gb2.TabIndex = 22;
            this.gb2.TabStop = false;
            this.gb2.Text = "Seleccione un producto";
            // 
            // listaProductos
            // 
            this.listaProductos.BackColor = System.Drawing.Color.White;
            this.listaProductos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listaProductos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listaProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listaProductos.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listaProductos.FormattingEnabled = true;
            this.listaProductos.Items.AddRange(new object[] {
            "20%",
            "0%"});
            this.listaProductos.Location = new System.Drawing.Point(6, 33);
            this.listaProductos.Name = "listaProductos";
            this.listaProductos.Size = new System.Drawing.Size(282, 28);
            this.listaProductos.TabIndex = 2;
            // 
            // gb4
            // 
            this.gb4.Controls.Add(this.listaInteres);
            this.gb4.Location = new System.Drawing.Point(5, 91);
            this.gb4.Name = "gb4";
            this.gb4.Size = new System.Drawing.Size(144, 79);
            this.gb4.TabIndex = 24;
            this.gb4.TabStop = false;
            this.gb4.Text = "Interés de las ventas";
            // 
            // listaInteres
            // 
            this.listaInteres.BackColor = System.Drawing.Color.White;
            this.listaInteres.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listaInteres.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listaInteres.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listaInteres.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listaInteres.FormattingEnabled = true;
            this.listaInteres.Items.AddRange(new object[] {
            "20%",
            "0%"});
            this.listaInteres.Location = new System.Drawing.Point(6, 33);
            this.listaInteres.Name = "listaInteres";
            this.listaInteres.Size = new System.Drawing.Size(132, 28);
            this.listaInteres.TabIndex = 1;
            // 
            // gb5
            // 
            this.gb5.Controls.Add(this.listaFrecuencia);
            this.gb5.Location = new System.Drawing.Point(155, 91);
            this.gb5.Name = "gb5";
            this.gb5.Size = new System.Drawing.Size(144, 79);
            this.gb5.TabIndex = 25;
            this.gb5.TabStop = false;
            this.gb5.Text = "Frecuencia";
            // 
            // listaFrecuencia
            // 
            this.listaFrecuencia.BackColor = System.Drawing.Color.White;
            this.listaFrecuencia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listaFrecuencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listaFrecuencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listaFrecuencia.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listaFrecuencia.FormattingEnabled = true;
            this.listaFrecuencia.Items.AddRange(new object[] {
            "DIARIA",
            "SEMANAL",
            "QUINCENAL",
            "MENSUAL"});
            this.listaFrecuencia.Location = new System.Drawing.Point(6, 33);
            this.listaFrecuencia.Name = "listaFrecuencia";
            this.listaFrecuencia.Size = new System.Drawing.Size(132, 28);
            this.listaFrecuencia.TabIndex = 1;
            // 
            // btnIniciarImportacion
            // 
            this.btnIniciarImportacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIniciarImportacion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnIniciarImportacion.FlatAppearance.BorderSize = 0;
            this.btnIniciarImportacion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnIniciarImportacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnIniciarImportacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciarImportacion.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarImportacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnIniciarImportacion.Image = ((System.Drawing.Image)(resources.GetObject("btnIniciarImportacion.Image")));
            this.btnIniciarImportacion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIniciarImportacion.Location = new System.Drawing.Point(353, 111);
            this.btnIniciarImportacion.Name = "btnIniciarImportacion";
            this.btnIniciarImportacion.Size = new System.Drawing.Size(197, 47);
            this.btnIniciarImportacion.TabIndex = 26;
            this.btnIniciarImportacion.Text = "Iniciar importación";
            this.btnIniciarImportacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIniciarImportacion.UseVisualStyleBackColor = true;
            // 
            // listaCobro
            // 
            this.listaCobro.BackColor = System.Drawing.Color.White;
            this.listaCobro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listaCobro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listaCobro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listaCobro.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listaCobro.FormattingEnabled = true;
            this.listaCobro.Items.AddRange(new object[] {
            "20%",
            "0%"});
            this.listaCobro.Location = new System.Drawing.Point(3, 33);
            this.listaCobro.Name = "listaCobro";
            this.listaCobro.Size = new System.Drawing.Size(282, 28);
            this.listaCobro.TabIndex = 3;
            // 
            // FrmConfiguracionCargaClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 185);
            this.Controls.Add(this.btnIniciarImportacion);
            this.Controls.Add(this.gb5);
            this.Controls.Add(this.gb4);
            this.Controls.Add(this.gb2);
            this.Controls.Add(this.gb1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfiguracionCargaClientes";
            this.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Style.MdiChild.IconHorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            this.Text = "Configuración de carga";
            this.gb1.ResumeLayout(false);
            this.gb2.ResumeLayout(false);
            this.gb4.ResumeLayout(false);
            this.gb5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.GroupBox gb2;
        private System.Windows.Forms.GroupBox gb4;
        private System.Windows.Forms.ComboBox listaInteres;
        private System.Windows.Forms.GroupBox gb5;
        private System.Windows.Forms.ComboBox listaFrecuencia;
        private System.Windows.Forms.Button btnIniciarImportacion;
        private System.Windows.Forms.ComboBox listaProductos;
        private System.Windows.Forms.ComboBox listaCobro;
    }
}