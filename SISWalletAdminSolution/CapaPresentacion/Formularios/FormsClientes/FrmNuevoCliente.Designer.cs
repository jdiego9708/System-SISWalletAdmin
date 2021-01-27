
namespace CapaPresentacion.Formularios.FormsClientes
{
    partial class FrmNuevoCliente
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNuevoCliente));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listaCiudades = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnAddBarrio = new System.Windows.Forms.Button();
            this.listaBarrios = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtTelCliente = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtDireccionResidencia = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtTelResidencia = new System.Windows.Forms.TextBox();
            this.gbResultados = new System.Windows.Forms.GroupBox();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.gbArticulosSelected = new System.Windows.Forms.GroupBox();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.txtValorAbono = new System.Windows.Forms.TextBox();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.txtIdentificacion = new System.Windows.Forms.TextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.listaFrecuencia = new System.Windows.Forms.ComboBox();
            this.numericPlazo = new System.Windows.Forms.NumericUpDown();
            this.panelArticulosSelected = new CapaPresentacion.Controles.CustomGridPanel();
            this.txtBuscarArticulos = new CapaPresentacion.CustomTextBox();
            this.panelArticulos = new CapaPresentacion.Controles.CustomGridPanel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.gbArticulosSelected.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPlazo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listaCiudades);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 56);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ciudad";
            // 
            // listaCiudades
            // 
            this.listaCiudades.BackColor = System.Drawing.Color.White;
            this.listaCiudades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listaCiudades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listaCiudades.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listaCiudades.FormattingEnabled = true;
            this.listaCiudades.Location = new System.Drawing.Point(7, 21);
            this.listaCiudades.Name = "listaCiudades";
            this.listaCiudades.Size = new System.Drawing.Size(264, 28);
            this.listaCiudades.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtNombres);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.groupBox2.Location = new System.Drawing.Point(12, 125);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(177, 56);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nombres*";
            // 
            // txtNombres
            // 
            this.txtNombres.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombres.BackColor = System.Drawing.Color.White;
            this.txtNombres.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombres.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombres.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txtNombres.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNombres.Location = new System.Drawing.Point(7, 25);
            this.txtNombres.MaxLength = 200;
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(164, 20);
            this.txtNombres.TabIndex = 0;
            this.txtNombres.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnAddBarrio);
            this.groupBox3.Controls.Add(this.listaBarrios);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.groupBox3.Location = new System.Drawing.Point(12, 68);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(279, 56);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Barrio*";
            // 
            // btnAddBarrio
            // 
            this.btnAddBarrio.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddBarrio.BackgroundImage")));
            this.btnAddBarrio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddBarrio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddBarrio.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnAddBarrio.FlatAppearance.BorderSize = 0;
            this.btnAddBarrio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddBarrio.Location = new System.Drawing.Point(241, 20);
            this.btnAddBarrio.Name = "btnAddBarrio";
            this.btnAddBarrio.Size = new System.Drawing.Size(30, 30);
            this.btnAddBarrio.TabIndex = 31;
            this.toolTip1.SetToolTip(this.btnAddBarrio, "Agregar un barrio");
            this.btnAddBarrio.UseVisualStyleBackColor = true;
            // 
            // listaBarrios
            // 
            this.listaBarrios.BackColor = System.Drawing.Color.White;
            this.listaBarrios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listaBarrios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listaBarrios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listaBarrios.FormattingEnabled = true;
            this.listaBarrios.Location = new System.Drawing.Point(8, 21);
            this.listaBarrios.Name = "listaBarrios";
            this.listaBarrios.Size = new System.Drawing.Size(227, 28);
            this.listaBarrios.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtTelCliente);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.groupBox4.Location = new System.Drawing.Point(195, 296);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(182, 56);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Teléfono/Celular";
            // 
            // txtTelCliente
            // 
            this.txtTelCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTelCliente.BackColor = System.Drawing.Color.White;
            this.txtTelCliente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTelCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTelCliente.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txtTelCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtTelCliente.Location = new System.Drawing.Point(7, 25);
            this.txtTelCliente.MaxLength = 15;
            this.txtTelCliente.Name = "txtTelCliente";
            this.txtTelCliente.Size = new System.Drawing.Size(169, 20);
            this.txtTelCliente.TabIndex = 0;
            this.txtTelCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtDireccionResidencia);
            this.groupBox5.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.groupBox5.Location = new System.Drawing.Point(12, 239);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(365, 56);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Dirección de residencia*";
            // 
            // txtDireccionResidencia
            // 
            this.txtDireccionResidencia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDireccionResidencia.BackColor = System.Drawing.Color.White;
            this.txtDireccionResidencia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDireccionResidencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDireccionResidencia.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txtDireccionResidencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDireccionResidencia.Location = new System.Drawing.Point(7, 25);
            this.txtDireccionResidencia.MaxLength = 200;
            this.txtDireccionResidencia.Name = "txtDireccionResidencia";
            this.txtDireccionResidencia.Size = new System.Drawing.Size(352, 20);
            this.txtDireccionResidencia.TabIndex = 0;
            this.txtDireccionResidencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtTelResidencia);
            this.groupBox6.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.groupBox6.Location = new System.Drawing.Point(12, 296);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(177, 56);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Teléfono/Celular";
            // 
            // txtTelResidencia
            // 
            this.txtTelResidencia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTelResidencia.BackColor = System.Drawing.Color.White;
            this.txtTelResidencia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTelResidencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTelResidencia.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txtTelResidencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtTelResidencia.Location = new System.Drawing.Point(7, 25);
            this.txtTelResidencia.MaxLength = 15;
            this.txtTelResidencia.Name = "txtTelResidencia";
            this.txtTelResidencia.Size = new System.Drawing.Size(164, 20);
            this.txtTelResidencia.TabIndex = 0;
            this.txtTelResidencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.bindingNavigator1);
            this.gbResultados.Controls.Add(this.panelArticulos);
            this.gbResultados.Location = new System.Drawing.Point(397, 63);
            this.gbResultados.Name = "gbResultados";
            this.gbResultados.Size = new System.Drawing.Size(682, 294);
            this.gbResultados.TabIndex = 13;
            this.gbResultados.TabStop = false;
            this.gbResultados.Text = "Artículos";
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.None;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(7, 262);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(205, 25);
            this.bindingNavigator1.TabIndex = 8;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Número total de elementos";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Mover primero";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Mover anterior";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Posición";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Posición actual";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Mover siguiente";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Mover último";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.btnRefresh);
            this.groupBox11.Controls.Add(this.button2);
            this.groupBox11.Controls.Add(this.txtBuscarArticulos);
            this.groupBox11.Location = new System.Drawing.Point(397, 12);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(682, 51);
            this.groupBox11.TabIndex = 14;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Búsqueda de artículos";
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(646, 15);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 30);
            this.button2.TabIndex = 32;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSave.BackgroundImage")));
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(12, 414);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(50, 50);
            this.btnSave.TabIndex = 32;
            this.toolTip1.SetToolTip(this.btnSave, "Agregar un barrio");
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // gbArticulosSelected
            // 
            this.gbArticulosSelected.Controls.Add(this.panelArticulosSelected);
            this.gbArticulosSelected.Location = new System.Drawing.Point(397, 359);
            this.gbArticulosSelected.Name = "gbArticulosSelected";
            this.gbArticulosSelected.Size = new System.Drawing.Size(682, 285);
            this.gbArticulosSelected.TabIndex = 15;
            this.gbArticulosSelected.TabStop = false;
            this.gbArticulosSelected.Text = "Artículos seleccionados";
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.txtValorAbono);
            this.groupBox16.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBox16.Location = new System.Drawing.Point(201, 353);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(111, 55);
            this.groupBox16.TabIndex = 1;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Valor abono*";
            // 
            // txtValorAbono
            // 
            this.txtValorAbono.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValorAbono.BackColor = System.Drawing.Color.White;
            this.txtValorAbono.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtValorAbono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtValorAbono.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtValorAbono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtValorAbono.Location = new System.Drawing.Point(7, 25);
            this.txtValorAbono.MaxLength = 15;
            this.txtValorAbono.Name = "txtValorAbono";
            this.txtValorAbono.Size = new System.Drawing.Size(95, 22);
            this.txtValorAbono.TabIndex = 1;
            this.txtValorAbono.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldo.Location = new System.Drawing.Point(123, 429);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(60, 20);
            this.lblSaldo.TabIndex = 33;
            this.lblSaldo.Text = "SALDO:";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtApellidos);
            this.groupBox7.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.groupBox7.Location = new System.Drawing.Point(195, 125);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(191, 56);
            this.groupBox7.TabIndex = 34;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Apellidos*";
            // 
            // txtApellidos
            // 
            this.txtApellidos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApellidos.BackColor = System.Drawing.Color.White;
            this.txtApellidos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtApellidos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApellidos.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txtApellidos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtApellidos.Location = new System.Drawing.Point(7, 25);
            this.txtApellidos.MaxLength = 200;
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(178, 20);
            this.txtApellidos.TabIndex = 0;
            this.txtApellidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.txtIdentificacion);
            this.groupBox8.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.groupBox8.Location = new System.Drawing.Point(12, 181);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(177, 56);
            this.groupBox8.TabIndex = 35;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Identificación";
            // 
            // txtIdentificacion
            // 
            this.txtIdentificacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIdentificacion.BackColor = System.Drawing.Color.White;
            this.txtIdentificacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIdentificacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdentificacion.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txtIdentificacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtIdentificacion.Location = new System.Drawing.Point(7, 25);
            this.txtIdentificacion.MaxLength = 200;
            this.txtIdentificacion.Name = "txtIdentificacion";
            this.txtIdentificacion.Size = new System.Drawing.Size(164, 20);
            this.txtIdentificacion.TabIndex = 0;
            this.txtIdentificacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.numericPlazo);
            this.groupBox9.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBox9.Location = new System.Drawing.Point(12, 353);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(64, 55);
            this.groupBox9.TabIndex = 36;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Plazo*";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.listaFrecuencia);
            this.groupBox10.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBox10.Location = new System.Drawing.Point(82, 353);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(113, 55);
            this.groupBox10.TabIndex = 37;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Frecuencia*";
            // 
            // listaFrecuencia
            // 
            this.listaFrecuencia.BackColor = System.Drawing.Color.White;
            this.listaFrecuencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listaFrecuencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listaFrecuencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listaFrecuencia.FormattingEnabled = true;
            this.listaFrecuencia.Location = new System.Drawing.Point(5, 22);
            this.listaFrecuencia.Name = "listaFrecuencia";
            this.listaFrecuencia.Size = new System.Drawing.Size(102, 25);
            this.listaFrecuencia.TabIndex = 1;
            // 
            // numericPlazo
            // 
            this.numericPlazo.BackColor = System.Drawing.Color.White;
            this.numericPlazo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericPlazo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericPlazo.Location = new System.Drawing.Point(6, 23);
            this.numericPlazo.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericPlazo.Name = "numericPlazo";
            this.numericPlazo.Size = new System.Drawing.Size(50, 25);
            this.numericPlazo.TabIndex = 38;
            // 
            // panelArticulosSelected
            // 
            this.panelArticulosSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelArticulosSelected.AutoScroll = true;
            this.panelArticulosSelected.Location = new System.Drawing.Point(6, 23);
            this.panelArticulosSelected.Name = "panelArticulosSelected";
            this.panelArticulosSelected.PageSize = 10;
            this.panelArticulosSelected.Size = new System.Drawing.Size(670, 254);
            this.panelArticulosSelected.TabIndex = 0;
            // 
            // txtBuscarArticulos
            // 
            this.txtBuscarArticulos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txtBuscarArticulos.BackColor = System.Drawing.Color.White;
            this.txtBuscarArticulos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarArticulos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBuscarArticulos.Imagen = null;
            this.txtBuscarArticulos.Location = new System.Drawing.Point(6, 21);
            this.txtBuscarArticulos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBuscarArticulos.MaxLenght = 0;
            this.txtBuscarArticulos.Name = "txtBuscarArticulos";
            this.txtBuscarArticulos.Size = new System.Drawing.Size(598, 20);
            this.txtBuscarArticulos.TabIndex = 0;
            this.txtBuscarArticulos.Texto = "Búsqueda de artículos";
            this.txtBuscarArticulos.Texto_inicial = "Búsqueda de artículos";
            this.txtBuscarArticulos.Tipo_txt = null;
            this.txtBuscarArticulos.Visible_px = true;
            // 
            // panelArticulos
            // 
            this.panelArticulos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelArticulos.AutoScroll = true;
            this.panelArticulos.Location = new System.Drawing.Point(6, 23);
            this.panelArticulos.Name = "panelArticulos";
            this.panelArticulos.PageSize = 10;
            this.panelArticulos.Size = new System.Drawing.Size(670, 236);
            this.panelArticulos.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRefresh.BackgroundImage")));
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(610, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(30, 30);
            this.btnRefresh.TabIndex = 33;
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // FrmNuevoCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1084, 656);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.lblSaldo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbArticulosSelected);
            this.Controls.Add(this.groupBox16);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.gbResultados);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmNuevoCliente";
            this.Text = " Nuevo cliente";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.gbResultados.ResumeLayout(false);
            this.gbResultados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.gbArticulosSelected.ResumeLayout(false);
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericPlazo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.ComboBox listaCiudades;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox listaBarrios;
        private System.Windows.Forms.Button btnAddBarrio;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtTelCliente;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtDireccionResidencia;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtTelResidencia;
        private System.Windows.Forms.GroupBox gbResultados;
        private System.Windows.Forms.GroupBox groupBox11;
        private CustomTextBox txtBuscarArticulos;
        private System.Windows.Forms.Button button2;
        private Controles.CustomGridPanel panelArticulos;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox gbArticulosSelected;
        private Controles.CustomGridPanel panelArticulosSelected;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.TextBox txtValorAbono;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox txtIdentificacion;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.ComboBox listaFrecuencia;
        private System.Windows.Forms.NumericUpDown numericPlazo;
        private System.Windows.Forms.Button btnRefresh;
    }
}