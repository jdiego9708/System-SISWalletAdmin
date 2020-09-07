namespace CapaPresentacion.Formularios.FormsClientes
{
    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.Drawing;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;
    using CapaNegocio;
    using Syncfusion.WinForms.Controls;

    public partial class FrmCargarClientes : SfForm
    {
        PoperContainer container;
        public FrmCargarClientes()
        {
            InitializeComponent();

            this.btnMostrarEsquema.Click += BtnMostrarEsquema_Click;
            this.listaBases.SelectedIndexChanged += ListaBases_SelectedIndexChanged;
            this.txtHoja.KeyPress += TxtHoja_KeyPress;
            this.btnImportar.Click += BtnImportar_Click;
            this.btnIniciar.Click += BtnIniciar_Click;
            this.btnOpciones.Click += BtnOpciones_Click;

            this.Load += FrmCargarClientes_Load;

            #region PROPIEDADES DE FORMULARIO
            this.Style.TitleBar.Height = 26;
            this.Style.TitleBar.BackColor = Color.White;
            this.Style.TitleBar.IconBackColor = Color.FromArgb(15, 161, 212);
            this.BackColor = Color.White;
            this.Style.TitleBar.ForeColor = ColorTranslator.FromHtml("#343434");
            this.Style.TitleBar.CloseButtonForeColor = Color.DarkGray;
            this.Style.TitleBar.MaximizeButtonForeColor = Color.DarkGray;
            this.Style.TitleBar.MinimizeButtonForeColor = Color.DarkGray;
            this.Style.TitleBar.HelpButtonForeColor = Color.DarkGray;
            this.Style.TitleBar.IconHorizontalAlignment = HorizontalAlignment.Left;
            this.Style.TitleBar.Font = this.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.Style.TitleBar.TextHorizontalAlignment = HorizontalAlignment.Center;
            this.Style.TitleBar.TextVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            #endregion
        }

        private void FrmCargarClientes_Load(object sender, EventArgs e)
        {
            this.Tipo_usuario = "CLIENTE";
        }

        private FrmConfiguracionCargaClientes FrmConfiguracionCargaClientes;

        private void BtnOpciones_Click(object sender, EventArgs e)
        {
            if (this.FrmConfiguracionCargaClientes == null)
            {
                this.FrmConfiguracionCargaClientes = new FrmConfiguracionCargaClientes
                {
                    StartPosition = FormStartPosition.CenterScreen,
                };
            }

            this.FrmConfiguracionCargaClientes.OnBtnContinuarClick += FrmConfiguracionCargaClientes_OnBtnContinuarClick;
            this.FrmConfiguracionCargaClientes.Show();
           
            
        }

        private void FrmConfiguracionCargaClientes_OnBtnContinuarClick(object sender, EventArgs e)
        {
            object[] objs = (object[])sender;
            this.FrmConfiguracionCargaClientes.Tag = objs;
            this.gbIniciar.Enabled = true;
        }

        private string _tipo_usuario;

        private bool VerificarClientes(out string consulta)
        {
            bool result = true;
            consulta = "";

            if (this.FrmConfiguracionCargaClientes == null)
            {
                this.AddError("Verifique la configuración");
                result = false;
            }

            if (this.FrmConfiguracionCargaClientes.Tag == null)
            {
                this.AddError("Verifique la configuración");
                result = false;
            }

            object[] objs = (object[])this.FrmConfiguracionCargaClientes.Tag;
            int id_cobro = (int)objs[0];
            int id_producto = (int)objs[1];
            decimal valor_interes = (decimal)objs[2];
            string frecuencia = (string)objs[3];
            int id_turno = 0;
            int id_zona = (int)objs[4];

            int contador = 1;

            StringBuilder consultaCompleta = new StringBuilder();
            consultaCompleta.Append("DECLARE @Id_usuario int, " +
                "@Id_direccion int, " +
                "@Id_venta int ");
            foreach (DataRow row in this.dtClientes.Rows)
            {
                string alias = Convert.ToString(row["Alias"]);
                string nombres = Convert.ToString(row["Nombres"]);
                string apellidos = Convert.ToString(row["Apellidos"]);
                string identificacion = Convert.ToString(row["Identificacion"]);
                string celular = Convert.ToString(row["Celular"]);
                string email = Convert.ToString(row["Email"]);
                string direccion = Convert.ToString(row["Direccion"]);
                string descripcion = Convert.ToString(row["Descripcion"]);
                direccion = direccion + " - " + descripcion;

                if (!decimal.TryParse(Convert.ToString(row["Total_venta"]), out decimal valor_venta))
                {
                    this.AddError("El total de la venta en la fila " + contador + " no tiene el formato de moneda correcto.");
                    result = false;
                }

                if (!decimal.TryParse(Convert.ToString(row["Saldo_restante"]), out decimal saldo_restante))
                {
                    this.AddError("El saldo restante en la fila " + contador + " no tiene el formato de moneda correcto.");
                    result = false;
                }

                if (!int.TryParse(Convert.ToString(row["Cuotas_totales"]), out int cuotas_totales))
                {
                    this.AddError("Las cuotas totales en la fila " + contador + " no tiene el formato de número correcto.");
                    result = false;
                }

                if (alias.Equals(""))
                {
                    this.AddError("El alias del cliente en la fila " + contador + " está vacío.");
                    result = false;
                }

                if (nombres.Equals(""))
                {
                    this.AddError("El nombre del cliente en la fila " + contador + " está vacío.");
                    result = false;
                }

                if (identificacion.Equals(""))
                {
                    this.AddError("El nombre del cliente en la fila " + contador + " está vacío.");
                    result = false;
                }

                if (celular.Equals(""))
                {
                    this.AddError("El nombre del cliente en la fila " + contador + " está vacío.");
                    result = false;
                }

                if (direccion.Equals(""))
                {
                    this.AddError("La dirección en la fila " + contador + " está vacío.");
                    result = false;
                }

                if (result)
                {
                    contador += 1;
                    decimal total_venta = (valor_venta * valor_interes) + valor_venta;
                    decimal total_x_cuota = total_venta / cuotas_totales;

                    consultaCompleta.Append(string.Format("INSERT INTO Usuarios (Fecha_ingreso, Alias, " +
                    "Nombres, Apellidos, Identificacion, " +
                    "Celular, Email, Tipo_usuario, Estado_usuario) " +
                    "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}'); " +
                    "SET @Id_usuario = SCOPE_IDENTITY(); " +
                    "INSERT INTO Direccion_clientes (Id_usuario, Id_zona, Direccion, Estado_direccion) " +
                    "VALUES (@Id_usuario, {9},'{10}', '{11}'); " +
                    "SET @Id_direccion = SCOPE_IDENTITY(); ",
                    DateTime.Now.ToString("yyyy-MM-dd"),
                    alias,
                    nombres,
                    apellidos,
                    identificacion,
                    celular,
                    email,
                    this.Tipo_usuario,
                    "ACTIVO",
                    id_zona,
                    direccion,
                    "ACTIVO"
                    ));

                    consultaCompleta.Append(string.Format("INSERT INTO Ventas (Id_cobro, Id_tipo_producto, " +
                        "Id_cliente, Id_direccion, Id_turno, Fecha_venta, Hora_venta, Valor_venta, " +
                        "Interes_venta, Total_venta, Numero_cuotas, Frecuencia_cobro, " +
                        "Valor_cuota, Estado_venta, Tipo_venta) " +
                        "VALUES ({0}, {1}, @Id_usuario, @Id_direccion, {2}, '{3}', '{4}', {5}, " +
                        "{6}, {7}, {8}, '{9}', {10}, '{11}', '{12}'); " +
                        "SET @Id_venta = SCOPE_IDENTITY(); ",
                        id_cobro,
                        id_producto,
                        id_turno,
                        DateTime.Now.ToString("yyyy-MM-dd"),
                        DateTime.Now.ToString("HH:mm"),
                        valor_venta.ToString().Replace(",", "."),
                        valor_interes.ToString().Replace(",", "."),
                        total_venta.ToString().Replace(",", "."),
                        cuotas_totales,
                        frecuencia,
                        total_x_cuota.ToString().Replace(",", "."),
                        "ACTIVO",
                        "NUEVA"));

                    consultaCompleta.Append(string.Format("INSERT INTO Agendamiento_cobros (Id_venta, Id_turno, Fecha_cobro, Hora_cobro, Valor_cobro, Valor_pagado, Saldo_restante, Tipo_cobro, Observaciones_cobro, Estado_cobro) " +
                        "VALUES (@Id_venta, 0, '{0}', '{1}', {2}, {3}, {4}, '{5}', '{6}', " +
                        "'{7}'); ",
                        DateTime.Now.ToString("yyyy-MM-dd"),
                        DateTime.Now.ToString("HH:mm"),
                        total_x_cuota.ToString().Replace(",", "."),
                        0,
                        saldo_restante.ToString().Replace(",", "."),
                        frecuencia,
                        "",
                        "ACTIVO"));
                }
            }
            consulta = Convert.ToString(consultaCompleta);
            return result;

        }

        private void CrearTablaErrores()
        {
            this.dtErrores = new DataTable("Errores");
            this.dtErrores.Columns.Add("Descripcion", typeof(string));
        }

        private void AddError(string descripcion)
        {
            DataRow row = this.dtErrores.NewRow();
            row["Descripcion"] = descripcion;
            this.dtErrores.Rows.Add(row);

            this.gbResultados.Text = "Se han encontrado errores " +
                "en el procesamiento, verifique";
            this.gbResultados.ForeColor = Color.Red;
        }

        private void BtnIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.VerificarEsquema())
                {
                    string rpta = "OK";
                    MensajeEspera.ShowWait("Cargando");
                    this.CrearTablaErrores();

                    if (this.VerificarClientes(out string consulta))
                    {
                        rpta = NUsuarios.InsertarUsuarios(consulta);
                        if (rpta.Equals("OK"))
                        {
                            MensajeEspera.CloseForm();
                            Mensajes.MensajeInformacion("Se importaron los clientes correctamente", "Entendido");
                            this.Close();
                        }
                        else
                            throw new Exception("Hubo un error al insertar los clientes en la consulta masiva, " + rpta);
                    }
                    MensajeEspera.CloseForm();
                }
            }
            catch (Exception ex)
            {
                MensajeEspera.CloseForm();
                Mensajes.MensajeErrorCompleto(this.Name, "BtnIniciar_Click",
                    "Hubo un error al cargar los clientes", ex.Message);
            }
        }

        private bool VerificarEsquema()
        {
            bool result = false;

            if (this.dtEsquema != null)
            {
                string columnText = "";
                foreach (DataColumn column in dtEsquema.Columns)
                {
                    columnText = column.ColumnName.ToUpper().Trim();
                    foreach (DataColumn columnClient in dtClientes.Columns)
                    {
                        if (columnText == columnClient.ColumnName.ToUpper().Trim())
                        {
                            result = true;
                            break;
                        }
                    }

                    if (result == false)
                    {
                        Mensajes.MensajeInformacion("No se encontró la columna " + columnText, "Entendido");
                        break;
                    }
                }
            }
            return result;
        }

        private void BtnImportar_Click(object sender, EventArgs e)
        {
            try
            {
                //Creo un objeto de tipo OpenFileDialog y lo instancio
                OpenFileDialog archivo = new OpenFileDialog();
                //Esta linea es para que solo se puedan visualizar los archivos con esta extension
                archivo.Filter = "Documentos válidos|*.doc;*.xls;*.ppt;*.pdf;*.xlsx";
                //Lo abro como un Dialog
                DialogResult result = archivo.ShowDialog();

                if (result == DialogResult.OK)
                {
                    //Asignamos el nombre del archivo a la caja de texto
                    this.txtArchivo.Text = archivo.SafeFileName;
                    //Asignamos a la propiedad tag del textbox la ruta completa del archivo
                    this.txtArchivo.Tag = archivo.FileName;

                    string hoja = this.txtHoja.Text;

                    if (hoja.Equals("Hoja") || hoja.Equals(""))
                    {
                        Mensajes.MensajeErrorForm("Debe ingresar un nombre de hoja válida, seleccione el archivo de nuevo");
                        this.txtHoja.SelectAll();
                    }
                    else
                    {
                        MensajeEspera.ShowWait("Cargando");
                        DataTable dt = new DataTable();
                        string fileName = archivo.FileName;
                        string query = "SELECT * FROM [" + hoja + "$]";
                        using (OleDbConnection cn = new OleDbConnection { ConnectionString = ConnectionString(fileName, "Yes") })
                        {
                            using (OleDbCommand cmd = new OleDbCommand { CommandText = query, Connection = cn })
                            {
                                cn.Open();

                                OleDbDataReader dr = cmd.ExecuteReader();
                                dt.Load(dr);
                            }
                        }

                        this.dtClientes = dt;
                        MensajeEspera.CloseForm();
                        if (this.VerificarEsquema())
                        {
                            if (dt != null)
                            {
                                if (dt.Rows.Count > 0)
                                {
                                    this.gbResultados.Text = "Se cargaron " + dt.Rows.Count + " registros";
                                    this.dgvListaClientes.Enabled = true;
                                }
                                else
                                {
                                    this.dgvListaClientes.Enabled = false;
                                    this.gbResultados.Text = "No se cargó ningún registro";
                                }
                            }
                            dt.AcceptChanges();
                            this.dgvListaClientes.DataSource = dt;
                            this.gbConfig.Enabled = true;

                            this.txtArchivo.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MensajeEspera.CloseForm();
                Mensajes.MensajeErrorCompleto(this.Name, "BtnImportar_Click",
                    "Hubo un error al importar el archivo", ex.Message);
            }
        }

        public string ConnectionString(string FileName, string Header)
        {
            OleDbConnectionStringBuilder Builder = new OleDbConnectionStringBuilder();
            if (Path.GetExtension(FileName).ToUpper() == ".XLS")
            {
                Builder.Provider = "Microsoft.Jet.OLEDB.4.0";
                Builder.Add("Extended Properties", string.Format("Excel 8.0;IMEX=1;HDR={0};", Header));
            }
            else
            {
                Builder.Provider = "Microsoft.ACE.OLEDB.12.0";
                Builder.Add("Extended Properties", string.Format("Excel 12.0;IMEX=1;HDR={0};", Header));
            }

            Builder.DataSource = FileName;

            return Builder.ConnectionString;
        }

        private void TxtHoja_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (txtHoja.Text.Equals("Hoja") || txtHoja.Text.Equals(""))
                {
                    this.gbImportar.Enabled = false;
                }
                else
                {
                    this.gbImportar.Enabled = true;
                    this.btnImportar.Focus();
                }
            }
        }

        private void ListaBases_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            this.gbHoja.Enabled = true;
            this.txtHoja.Focus();
            //if (int.TryParse(cb.SelectedValue.ToString(), out int id_base))
            //{
            //    if (this.DtBases != null)
            //    {
            //        DataRow[] rows = this.DtBases.Select(string.Format("Id_base = {0}", id_base));
            //        if (rows.Length > 0)
            //        {
            //            EBases_clientes eBase = new EBases_clientes(rows[0]);
            //            this.gbBd.Tag = eBase;
            //            this.gbBd.Text = "Base de datos (" + eBase.Alias_base + ")(2)";
            //        }
            //    }
            //}
            //else
            //    Mensajes.MensajeInformacion("Hubo un error al obtener el id de la base seleccionada", "Entendido");
        }

        private void BtnMostrarEsquema_Click(object sender, System.EventArgs e)
        {
            DataTable dtEsquema = new DataTable();
            dtEsquema.Columns.Add("Alias", typeof(string));
            dtEsquema.Columns.Add("Nombres", typeof(string));
            dtEsquema.Columns.Add("Apellidos", typeof(string));
            dtEsquema.Columns.Add("Identificacion", typeof(string));
            dtEsquema.Columns.Add("Celular", typeof(string));
            dtEsquema.Columns.Add("Email", typeof(string));
            dtEsquema.Columns.Add("Direccion", typeof(string));
            dtEsquema.Columns.Add("Total_venta", typeof(string));
            dtEsquema.Columns.Add("Saldo_restante", typeof(string));
            dtEsquema.Columns.Add("Cuotas_totales", typeof(string));
            dtEsquema.Columns.Add("Descripcion", typeof(string));

            this.dgvListaClientes.DataSource = dtEsquema;
            this.gbResultados.Text = "El archivo a cargar debe tener las mismas columnas, nombre igual y en el mismo orden";
            this.gbHoja.Enabled = true;
            this.dtEsquema = dtEsquema;
            this.listaBases.Focus();
        }

        private DataTable dtEsquema;
        private DataTable _dtBases;

        private DataTable dtClientes;
        private DataTable dtErrores;

        public DataTable DtBases { get => _dtBases; set => _dtBases = value; }
        public string Tipo_usuario { get => _tipo_usuario; set => _tipo_usuario = value; }
    }
}
