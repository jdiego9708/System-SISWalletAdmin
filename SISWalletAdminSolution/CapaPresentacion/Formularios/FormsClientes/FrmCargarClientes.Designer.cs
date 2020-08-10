namespace CapaPresentacion.Formularios.FormsClientes
{
    partial class FrmCargarClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCargarClientes));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbBd = new System.Windows.Forms.GroupBox();
            this.listaBases = new System.Windows.Forms.ComboBox();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.btnMostrarEsquema = new System.Windows.Forms.Button();
            this.gbIniciar = new System.Windows.Forms.GroupBox();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.gbHoja = new System.Windows.Forms.GroupBox();
            this.txtHoja = new System.Windows.Forms.TextBox();
            this.gbImportar = new System.Windows.Forms.GroupBox();
            this.txtArchivo = new System.Windows.Forms.TextBox();
            this.btnImportar = new System.Windows.Forms.Button();
            this.gbResultados = new System.Windows.Forms.GroupBox();
            this.dgvListaClientes = new CapaPresentacion.CustomDataGridView();
            this.gbConfig = new System.Windows.Forms.GroupBox();
            this.btnOpciones = new System.Windows.Forms.Button();
            this.gbBd.SuspendLayout();
            this.gb1.SuspendLayout();
            this.gbIniciar.SuspendLayout();
            this.gbHoja.SuspendLayout();
            this.gbImportar.SuspendLayout();
            this.gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaClientes)).BeginInit();
            this.gbConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbBd
            // 
            this.gbBd.Controls.Add(this.listaBases);
            this.gbBd.Location = new System.Drawing.Point(151, 6);
            this.gbBd.Name = "gbBd";
            this.gbBd.Size = new System.Drawing.Size(124, 79);
            this.gbBd.TabIndex = 21;
            this.gbBd.TabStop = false;
            this.gbBd.Text = "Base de datos (2)";
            // 
            // listaBases
            // 
            this.listaBases.BackColor = System.Drawing.Color.White;
            this.listaBases.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listaBases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listaBases.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listaBases.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listaBases.FormattingEnabled = true;
            this.listaBases.Items.AddRange(new object[] {
            "SISWalletBD"});
            this.listaBases.Location = new System.Drawing.Point(6, 33);
            this.listaBases.Name = "listaBases";
            this.listaBases.Size = new System.Drawing.Size(112, 28);
            this.listaBases.TabIndex = 0;
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.btnMostrarEsquema);
            this.gb1.Location = new System.Drawing.Point(5, 6);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(140, 79);
            this.gb1.TabIndex = 20;
            this.gb1.TabStop = false;
            this.gb1.Text = "Esquema (1)";
            // 
            // btnMostrarEsquema
            // 
            this.btnMostrarEsquema.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMostrarEsquema.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnMostrarEsquema.FlatAppearance.BorderSize = 0;
            this.btnMostrarEsquema.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnMostrarEsquema.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnMostrarEsquema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarEsquema.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrarEsquema.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMostrarEsquema.Image = ((System.Drawing.Image)(resources.GetObject("btnMostrarEsquema.Image")));
            this.btnMostrarEsquema.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMostrarEsquema.Location = new System.Drawing.Point(17, 26);
            this.btnMostrarEsquema.Name = "btnMostrarEsquema";
            this.btnMostrarEsquema.Size = new System.Drawing.Size(108, 41);
            this.btnMostrarEsquema.TabIndex = 9;
            this.btnMostrarEsquema.Text = "Ver \r\nesquema";
            this.btnMostrarEsquema.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMostrarEsquema.UseVisualStyleBackColor = true;
            // 
            // gbIniciar
            // 
            this.gbIniciar.Controls.Add(this.btnIniciar);
            this.gbIniciar.Enabled = false;
            this.gbIniciar.Location = new System.Drawing.Point(916, 6);
            this.gbIniciar.Name = "gbIniciar";
            this.gbIniciar.Size = new System.Drawing.Size(140, 79);
            this.gbIniciar.TabIndex = 24;
            this.gbIniciar.TabStop = false;
            this.gbIniciar.Text = "Iniciar import. (6)";
            // 
            // btnIniciar
            // 
            this.btnIniciar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIniciar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnIniciar.FlatAppearance.BorderSize = 0;
            this.btnIniciar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnIniciar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciar.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnIniciar.Image = ((System.Drawing.Image)(resources.GetObject("btnIniciar.Image")));
            this.btnIniciar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIniciar.Location = new System.Drawing.Point(17, 26);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(108, 41);
            this.btnIniciar.TabIndex = 9;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIniciar.UseVisualStyleBackColor = true;
            // 
            // gbHoja
            // 
            this.gbHoja.Controls.Add(this.txtHoja);
            this.gbHoja.Enabled = false;
            this.gbHoja.Location = new System.Drawing.Point(281, 6);
            this.gbHoja.Name = "gbHoja";
            this.gbHoja.Size = new System.Drawing.Size(179, 79);
            this.gbHoja.TabIndex = 23;
            this.gbHoja.TabStop = false;
            this.gbHoja.Text = "Hoja a importar (3)";
            // 
            // txtHoja
            // 
            this.txtHoja.BackColor = System.Drawing.Color.White;
            this.txtHoja.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoja.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtHoja.Location = new System.Drawing.Point(6, 34);
            this.txtHoja.Name = "txtHoja";
            this.txtHoja.Size = new System.Drawing.Size(141, 27);
            this.txtHoja.TabIndex = 9;
            this.txtHoja.Text = "Hoja";
            // 
            // gbImportar
            // 
            this.gbImportar.Controls.Add(this.txtArchivo);
            this.gbImportar.Controls.Add(this.btnImportar);
            this.gbImportar.Enabled = false;
            this.gbImportar.Location = new System.Drawing.Point(466, 6);
            this.gbImportar.Name = "gbImportar";
            this.gbImportar.Size = new System.Drawing.Size(279, 79);
            this.gbImportar.TabIndex = 22;
            this.gbImportar.TabStop = false;
            this.gbImportar.Text = "Archivo a cargar (4)";
            // 
            // txtArchivo
            // 
            this.txtArchivo.BackColor = System.Drawing.Color.White;
            this.txtArchivo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArchivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtArchivo.Location = new System.Drawing.Point(106, 34);
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.ReadOnly = true;
            this.txtArchivo.Size = new System.Drawing.Size(161, 27);
            this.txtArchivo.TabIndex = 8;
            this.txtArchivo.Text = "Archivo";
            // 
            // btnImportar
            // 
            this.btnImportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImportar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnImportar.FlatAppearance.BorderSize = 0;
            this.btnImportar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnImportar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnImportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportar.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnImportar.Image = ((System.Drawing.Image)(resources.GetObject("btnImportar.Image")));
            this.btnImportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportar.Location = new System.Drawing.Point(8, 26);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(92, 41);
            this.btnImportar.TabIndex = 7;
            this.btnImportar.Text = "Subir";
            this.btnImportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImportar.UseVisualStyleBackColor = true;
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.dgvListaClientes);
            this.gbResultados.Location = new System.Drawing.Point(5, 91);
            this.gbResultados.Name = "gbResultados";
            this.gbResultados.Size = new System.Drawing.Size(1051, 414);
            this.gbResultados.TabIndex = 25;
            this.gbResultados.TabStop = false;
            this.gbResultados.Text = "Resultados";
            // 
            // dgvListaClientes
            // 
            this.dgvListaClientes.AllowUserToAddRows = false;
            this.dgvListaClientes.AllowUserToDeleteRows = false;
            this.dgvListaClientes.AllowUserToResizeColumns = false;
            this.dgvListaClientes.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.dgvListaClientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListaClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvListaClientes.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaClientes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListaClientes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvListaClientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Bisque;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListaClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListaClientes.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvListaClientes.IsTextCenter = false;
            this.dgvListaClientes.Location = new System.Drawing.Point(6, 24);
            this.dgvListaClientes.Name = "dgvListaClientes";
            this.dgvListaClientes.PageSize = 10;
            this.dgvListaClientes.ReadOnly = true;
            this.dgvListaClientes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvListaClientes.RowHeadersVisible = false;
            this.dgvListaClientes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Bisque;
            this.dgvListaClientes.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvListaClientes.RowTemplate.Height = 30;
            this.dgvListaClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvListaClientes.Size = new System.Drawing.Size(1039, 384);
            this.dgvListaClientes.TabIndex = 7;
            // 
            // gbConfig
            // 
            this.gbConfig.Controls.Add(this.btnOpciones);
            this.gbConfig.Enabled = false;
            this.gbConfig.Location = new System.Drawing.Point(751, 6);
            this.gbConfig.Name = "gbConfig";
            this.gbConfig.Size = new System.Drawing.Size(159, 79);
            this.gbConfig.TabIndex = 26;
            this.gbConfig.TabStop = false;
            this.gbConfig.Text = "Configuración (5)";
            // 
            // btnOpciones
            // 
            this.btnOpciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpciones.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnOpciones.FlatAppearance.BorderSize = 0;
            this.btnOpciones.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnOpciones.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnOpciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpciones.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnOpciones.Image = ((System.Drawing.Image)(resources.GetObject("btnOpciones.Image")));
            this.btnOpciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpciones.Location = new System.Drawing.Point(17, 26);
            this.btnOpciones.Name = "btnOpciones";
            this.btnOpciones.Size = new System.Drawing.Size(136, 41);
            this.btnOpciones.TabIndex = 9;
            this.btnOpciones.Text = "Opciones";
            this.btnOpciones.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOpciones.UseVisualStyleBackColor = true;
            // 
            // FrmCargarClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 511);
            this.Controls.Add(this.gbConfig);
            this.Controls.Add(this.gbResultados);
            this.Controls.Add(this.gbIniciar);
            this.Controls.Add(this.gbHoja);
            this.Controls.Add(this.gbImportar);
            this.Controls.Add(this.gbBd);
            this.Controls.Add(this.gb1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmCargarClientes";
            this.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Style.MdiChild.IconHorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            this.Text = "Cargar clientes";
            this.gbBd.ResumeLayout(false);
            this.gb1.ResumeLayout(false);
            this.gbIniciar.ResumeLayout(false);
            this.gbHoja.ResumeLayout(false);
            this.gbHoja.PerformLayout();
            this.gbImportar.ResumeLayout(false);
            this.gbImportar.PerformLayout();
            this.gbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaClientes)).EndInit();
            this.gbConfig.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbBd;
        private System.Windows.Forms.ComboBox listaBases;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.Button btnMostrarEsquema;
        private System.Windows.Forms.GroupBox gbIniciar;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.GroupBox gbHoja;
        private System.Windows.Forms.TextBox txtHoja;
        private System.Windows.Forms.GroupBox gbImportar;
        private System.Windows.Forms.TextBox txtArchivo;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.GroupBox gbResultados;
        private CustomDataGridView dgvListaClientes;
        private System.Windows.Forms.GroupBox gbConfig;
        private System.Windows.Forms.Button btnOpciones;
    }
}