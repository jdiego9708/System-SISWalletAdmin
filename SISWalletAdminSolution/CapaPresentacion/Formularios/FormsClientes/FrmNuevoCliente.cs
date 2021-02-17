using CapaEntidades;
using CapaEntidades.Helpers;
using CapaNegocio;
using CapaPresentacion.Formularios.FormsArticulos;
using CapaPresentacion.Formularios.FormsPrincipales;
using CapaPresentacion.Formularios.FormsZonas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.FormsClientes
{
    public partial class FrmNuevoCliente : Form
    {
        PoperContainer container;

        public FrmNuevoCliente()
        {
            InitializeComponent();
            this.Load += FrmNuevoCliente_Load;
            this.listaCiudades.SelectedIndexChanged += ListaCiudades_SelectedIndexChanged;
            this.txtBuscarArticulos.OnCustomKeyPress += TxtBuscarArticulos_OnCustomKeyPress;

            this.txtValorAbono.KeyPress += Txt_KeyPress;
            this.txtValorAbono.GotFocus += Txt_GotFocus;
            this.txtValorAbono.LostFocus += Txt_LostFocus;
            this.txtValorAbono.TextChanged += TxtValorAbono_TextChanged;

            this.txtValorTotalVenta.KeyPress += Txt_KeyPress;
            this.txtValorTotalVenta.GotFocus += Txt_GotFocus;
            this.txtValorTotalVenta.LostFocus += Txt_LostFocus;
            this.txtValorTotalVenta.TextChanged += TxtValorTotalVenta_TextChanged;

            this.btnAddBarrio.Click += BtnAddBarrio_Click;
            this.btnSave.Click += BtnSave_Click;
            this.btnRefresh.Click += BtnRefresh_Click;

            this.rdActual.CheckedChanged += RdActual_CheckedChanged;
            this.rdAnterior.CheckedChanged += RdAnterior_CheckedChanged;
        }

        private void TxtValorTotalVenta_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (int.TryParse(txt.Text, out int total_venta))
            {
                this.Total_articulos = total_venta;
                this.Calcular();
            }
        }

        private void RdAnterior_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rd = (RadioButton)sender;
            if (rd.Checked)
            {
                this.gbValorVenta.Visible = true;
                this.gbUltimoPago.Visible = true;
                this.gbArticulosSelected.Enabled = false;
                this.gbBusquedaArticulos.Enabled = false;
                this.gbResultados.Enabled = false;
            }
        }

        private void RdActual_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rd = (RadioButton)sender;
            if (rd.Checked)
            {
                this.gbValorVenta.Visible = true;
                this.gbUltimoPago.Visible = false;
                this.gbArticulosSelected.Enabled = true;
                this.gbBusquedaArticulos.Enabled = true;
                this.gbResultados.Enabled = true;
            }
        }

        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            await this.LoadArticulos("COMPLETO", "");
        }

        private bool Comprobaciones(out Usuarios usuario, out Direccion_clientes direccion,
            out Ventas venta, out Agendamiento_cobros agendamiento)
        {
            MainController main = MainController.GetInstance();
            usuario = new Usuarios();
            direccion = new Direccion_clientes();
            venta = new Ventas();
            agendamiento = new Agendamiento_cobros();

            if (string.IsNullOrEmpty(this.txtNombres.Text))
            {
                Mensajes.MensajeInformacion("Verifique el nombre del cliente", "Entendido");
                return false;
            }

            if (string.IsNullOrEmpty(this.txtDireccionResidencia.Text))
            {
                Mensajes.MensajeInformacion("Verifique la dirección del cliente", "Entendido");
                return false;
            }

            if (string.IsNullOrEmpty(this.txtTelCliente.Text))
            {
                Mensajes.MensajeInformacion("Verifique el teléfono del cliente", "Entendido");
                return false;
            }

            if (string.IsNullOrEmpty(this.listaFrecuencia.Text))
            {
                Mensajes.MensajeInformacion("Verifique la frecuencia de cobro", "Entendido");
                return false;
            }

            if (this.numericPlazo.Value == 0)
            {
                Mensajes.MensajeInformacion("Verifique el plazo de cobro", "Entendido");
                return false;
            }

            if (!decimal.TryParse(this.txtValorAbono.Tag.ToString(), out decimal valor_abono))
            {
                Mensajes.MensajeInformacion("Verifique el valor del abono", "Entendido");
                return false;
            }

            if (!int.TryParse(this.listaBarrios.SelectedValue.ToString(), out int id_barrio))
            {
                Mensajes.MensajeInformacion("Verifique el barrio seleccionado", "Entendido");
                return false;
            }

            usuario.Fecha_ingreso = DateTime.Now;
            usuario.Alias = this.txtNombres.Text;
            usuario.Nombres = this.txtNombres.Text;
            usuario.Apellidos = this.txtApellidos.Text;
            usuario.Identificacion = this.txtIdentificacion.Text;
            usuario.Email = string.Empty;
            usuario.Tipo_usuario = "CLIENTE";
            usuario.Estado_usuario = "ACTIVO";

            if (string.IsNullOrEmpty(this.txtTelResidencia.Text))
                usuario.Celular = this.txtTelCliente.Text;
            else
                usuario.Celular = this.txtTelCliente.Text + " - " + this.txtTelResidencia.Text;

            direccion.Id_usuario = 0;
            direccion.Id_zona = id_barrio;
            direccion.Direccion = this.txtDireccionResidencia.Text;
            direccion.Estado_dirección = "ACTIVO";

            venta.Id_cobro = main.Turno.Id_cobro;
            venta.Id_tipo_producto = 2;
            venta.Id_cliente = 0;
            venta.Id_direccion = 0;
            venta.Id_turno = main.Turno.Id_turno;

            if (this.rdActual.Checked)
            {
                venta.Fecha_venta = DateTime.Now;
                venta.Tipo_venta = "NUEVA";
            }
            else
            {
                venta.Fecha_venta = dateUltimoPago.Value;
                venta.Tipo_venta = "MIGRACION";
            }

            venta.Hora_venta = DateTime.Now.TimeOfDay;
            venta.Valor_venta = this.Total_articulos;
            venta.Interes_venta = 0;
            venta.Total_venta = this.Total_articulos;
            venta.Numero_cuotas = Convert.ToInt32(numericPlazo.Value);
            venta.Frecuencia_cobro = this.listaFrecuencia.Text;
            venta.Valor_cuota = (this.Total_articulos / Convert.ToInt32(numericPlazo.Value));
            venta.Estado_venta = "ACTIVO";
            
            agendamiento.Id_venta = 0;
            agendamiento.Id_turno = main.Turno.Id_turno;
            agendamiento.Orden_cobro = 0;

            if (this.rdActual.Checked)
                agendamiento.Fecha_cobro = DateTime.Now;
            else
                agendamiento.Fecha_cobro = dateUltimoPago.Value;

            agendamiento.Hora_cobro = DateTime.Now.TimeOfDay;
            agendamiento.Valor_cobro = venta.Valor_cuota;
            agendamiento.Valor_pagado = valor_abono;
            agendamiento.Saldo_restante = this.Total_saldo;
            agendamiento.Tipo_cobro = this.listaFrecuencia.Text;
            agendamiento.Observaciones_cobro = "";
            agendamiento.Estado_cobro = "TERMINADO";
            return true;
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Comprobaciones(out Usuarios usuario, out Direccion_clientes direccion,
                         out Ventas venta, out Agendamiento_cobros agendamiento))
                {
                    MensajeEspera.ShowWait("Guardando...");
                    List<string> errores = new List<string>();
                    string rpta = NUsuarios.InsertarUsuario(out int id_usuario, usuario);
                    if (rpta.Equals("OK"))
                    {
                        direccion.Id_usuario = id_usuario;
                        rpta = NDireccion_clientes.InsertarDireccion(out int id_direccion, direccion);
                        if (rpta.Equals("OK"))
                        {
                            venta.Id_cliente = id_usuario;
                            venta.Id_direccion = id_direccion;
                            rpta = NVentas.InsertarVenta(out int id_venta, venta);
                            if (rpta.Equals("OK"))
                            {
                                venta.Id_venta = id_venta;
                                if (this.rdActual.Checked)
                                {
                                    foreach (Articulos art in this.ArticulosSelected)
                                    {
                                        Detalle_articulos_venta detalle = new Detalle_articulos_venta
                                        {
                                            Articulo = art,
                                            Id_articulo = art.Id_articulo,
                                            Venta = venta,
                                            Id_venta = id_venta,
                                            Cantidad_articulo = (int)art.Cantidad_articulo,
                                            Valor_articulo = art.Valor_articulo,
                                            Estado_detalle = "ACTIVO",
                                        };

                                        var (rptaDetalle, id_detalle) =
                                            await NDetalle_articulos_venta.InsertarDetalle(detalle);
                                        if (!rptaDetalle.Equals("OK"))
                                            errores.Add(rptaDetalle);
                                    }
                                }

                                MainController main = MainController.GetInstance();
                                rpta = NUsuariosVentas.InsertarUsuarioVenta(new Usuarios_ventas
                                {
                                    Id_usuario = main.Usuario.Id_usuario,
                                    Id_venta = id_venta,
                                });

                                if (rpta.Equals("OK"))
                                {
                                    agendamiento.Id_venta = id_venta;
                                    rpta = NAgendamiento_cobros.InsertarAgendamiento(out int id_agendamiento, agendamiento);
                                    if (rpta.Equals("OK"))
                                    {
                                        MensajeEspera.CloseForm();
                                        Mensajes.MensajeInformacion("Se guardó correctamente el cliente, número asignado: " + id_usuario, "Entendido");
                                        this.Close();
                                    }
                                    else
                                        throw new Exception(rpta);
                                }
                                else
                                    throw new Exception(rpta);
                            }
                        }
                        else
                            throw new Exception(rpta);
                    }
                    else
                        throw new Exception(rpta);
                }
                MensajeEspera.CloseForm();
            }
            catch (Exception ex)
            {
                MensajeEspera.CloseForm();
                Mensajes.MensajeErrorCompleto(this.Name, "BtnSave_Click",
                    "Hubo un error al guardar el cliente", ex.Message);
            }
        }

        private void LoadListaFrecuencia()
        {
            this.listaFrecuencia.Items.Clear();
            this.listaFrecuencia.Items.Add("DIARIO");
            this.listaFrecuencia.Items.Add("SEMANAL");
            this.listaFrecuencia.Items.Add("QUINCENAL");
            this.listaFrecuencia.Items.Add("MENSUAL");
        }

        private void BtnAddBarrio_Click(object sender, EventArgs e)
        {
            if (int.TryParse(this.listaCiudades.SelectedValue.ToString(), out int id_ciudad))
            {
                AddZonaSmall addZonaSmall = new AddZonaSmall
                {
                    Id_ciudad = id_ciudad,
                };
                addZonaSmall.OnBtnSaveSuccess += AddZonaSmall_OnBtnSaveSuccess;
                this.container = new PoperContainer(addZonaSmall);
                this.container.Show(this.btnAddBarrio);
            }
            else
                Mensajes.MensajeInformacion("Verifique la ciudad seleccionada", "Entendido");
        }

        private void AddZonaSmall_OnBtnSaveSuccess(object sender, EventArgs e)
        {
            int id_ciudad = (int)sender;
            this.LoadBarrios("ID CIUDAD", id_ciudad.ToString());
            this.container.Close();
        }

        private void TxtValorAbono_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (int.TryParse(txt.Text, out int abono))
            {
                this.Total_abono = abono;
                this.Calcular();
            }
        }

        private void Txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void Txt_GotFocus(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.Text = Convert.ToString(txt.Tag);
            txt.SelectAll();
        }

        private void Txt_LostFocus(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;

            if (txt.Text.Equals(""))
            {
                string precio = "0";
                txt.Text = string.Format("{0:C}", precio);
            }
            else
            {
                bool result = int.TryParse(txt.Text, out int num);
                if (result)
                {
                    txt.Tag = num;
                    txt.Text = string.Format("{0:C}", txt.Tag);
                }
            }
        }

        private async void TxtBuscarArticulos_OnCustomKeyPress(object sender, KeyPressEventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if (e.KeyChar == (int)Keys.Enter)
            {
                if (txt.Texto.Equals(txt.Texto_inicial) | txt.Texto.Equals(""))
                    await this.LoadArticulos("COMPLETO", "");
                else
                    await this.LoadArticulos("REFERENCIA", txt.Texto);
            }
        }

        private void ListaCiudades_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(this.listaCiudades.SelectedValue.ToString(), out int id_ciudad))
            {
                this.LoadBarrios("ID CIUDAD", id_ciudad.ToString());
            }
        }

        private async void FrmNuevoCliente_Load(object sender, EventArgs e)
        {
            //Verificamos conexión
            Response connection = await ConnectionHelper.CheckConnection();
            this.IsConnectedSuccess = connection.IsSuccess;

            this.LoadCiudades("ID PAIS", "2020");
            await this.LoadArticulos("COMPLETO", "");
            this.LoadListaFrecuencia();
        }

        private void LoadBarrios(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                DataTable dtZonas =
                    NZonas.BuscarZonas(tipo_busqueda, texto_busqueda, out string rpta);

                if (this.listaBarrios.Items.Count > 0)
                    this.listaBarrios.Items.Clear();

                if (dtZonas != null)
                {
                    this.listaBarrios.DataSource = dtZonas;
                    this.listaBarrios.ValueMember = "Id_zona";
                    this.listaBarrios.DisplayMember = "Nombre_zona";
                }
                else
                    if (!rpta.Equals("OK"))
                    throw new Exception(rpta);
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "LoadBarrios",
                    "Hubo un error al cargar los barrios o zonas", ex.Message);
            }
        }

        private void LoadCiudades(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                DataTable dtCiudades =
                    NCiudades.BuscarCiudades(tipo_busqueda, texto_busqueda, out string rpta);

                if (this.listaCiudades.Items.Count > 0)
                    this.listaCiudades.Items.Clear();

                if (dtCiudades != null)
                {
                    this.listaCiudades.DataSource = dtCiudades;
                    this.listaCiudades.ValueMember = "Id_ciudad";
                    this.listaCiudades.DisplayMember = "Nombre_ciudad";
                }
                else
                    if (!rpta.Equals("OK"))
                    throw new Exception(rpta);
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "LoadCiudades",
                    "Hubo un error al cargar las ciudades", ex.Message);
            }
        }

        public async Task LoadArticulos(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                if (this.IsConnectedSuccess)
                {
                    var Comprobaciones =
                        await NArticulos.BuscarArticulos(tipo_busqueda, texto_busqueda);

                    if (this.ArticulosList != null)
                        this.ArticulosList.Clear();

                    if (this.panelArticulos.Controls.Count > 0)
                        this.panelArticulos.Controls.Clear();

                    if (Comprobaciones.dtArticulos != null)
                    {
                        List<Articulos> articulos = (from DataRow dr in Comprobaciones.dtArticulos.Rows
                                                     select new Articulos(dr)).ToList();

                        this.ArticulosList = articulos;

                        List<UserControl> controls = new List<UserControl>();
                        foreach (Articulos art in articulos)
                        {
                            ArticuloSmall artItem = new ArticuloSmall
                            {
                                Articulo = art,
                            };
                            artItem.OnBtnNext += ArtItem_OnBtnNext;
                            controls.Add(artItem);
                        }

                        this.panelArticulos.PageSize = 30;
                        this.panelArticulos.OnBsPositionChanged += PanelArticulos_OnBsPositionChanged;
                        this.panelArticulos.SetPagedDataSource(controls, this.bindingNavigator1);
                        this.positionChanged = 1;

                        if (this.ArticulosList.Count <= 0)
                            this.gbResultados.Text = "No hay articulos";
                        else if (this.ArticulosList.Count == 1)
                            this.gbResultados.Text = "Hay un articulo";
                        else if (this.ArticulosList.Count > 1)
                            this.gbResultados.Text = "Se encontraron " + this.ArticulosList.Count + " articulos.";
                    }
                    else
                    {
                        this.gbResultados.Text = "No hay articulos";

                        if (!Comprobaciones.rpta.Equals("OK"))
                            throw new Exception(Comprobaciones.rpta);
                    }
                }
                else
                    Mensajes.MensajeInformacion("Verifique la conexión a internet", "Entendido");
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "public async Task LoadArticulos",
                    "Hubo un error al buscar artículos", ex.Message);
            }
        }

        int positionChanged = 1;
        private void PanelArticulos_OnBsPositionChanged(object sender, EventArgs e)
        {
            if (positionChanged != this.panelArticulos.bs.Position)
            {
                this.positionChanged = this.panelArticulos.bs.Position;
                List<UserControl> controls = (List<UserControl>)sender;
                this.panelArticulos.AddArrayControl(controls);
            }
        }

        private void ArtItem_OnBtnNext(object sender, EventArgs e)
        {
            Articulos art = (Articulos)sender;

            if (this.ArticulosSelected == null)
                this.ArticulosSelected = new List<Articulos>();

            List<Articulos> artFind =
                this.ArticulosSelected.Where(x => x.Id_articulo == art.Id_articulo).ToList();

            if (artFind.Count < 1)
            {
                this.ArticulosSelected.Add(art);
                this.LoadArticulosSelected();
                //this.Total_articulos += art.Valor_articulo * art.Cantidad_articulo;
                this.Calcular();
            }
        }

        private void Calcular()
        {
            this.Total_saldo = this.Total_articulos - this.Total_abono;
            this.lblSaldo.Text = "SALDO: " + this.Total_saldo.ToString("C");
        }

        private void LoadArticulosSelected()
        {
            this.panelArticulosSelected.clearDataSource();

            List<UserControl> controls = new List<UserControl>();
            foreach (Articulos art in this.ArticulosSelected)
            {
                ArticuloSmall artItem = new ArticuloSmall
                {
                    Articulo = art,
                    IsAdd = true,
                };
                artItem.OnBtnRemover += ArtItem_OnBtnRemover;
                artItem.OnBtnNext += ArtItem_OnBtnNext;
                artItem.OnCantidadChanged += ArtItem_OnCantidadChanged;
                controls.Add(artItem);
            }

            this.panelArticulosSelected.AddArrayControl(controls);
        }

        private void ArtItem_OnCantidadChanged(object sender, EventArgs e)
        {
            object[] obj = (object[])sender;
            Articulos art = (Articulos)obj[0];
            decimal cantidad = (decimal)obj[1];
            //decimal total_resta = 0;
            //int resta = 0;

            if (cantidad < art.Cantidad_articulo)
            {
                //resta = (int)art.Cantidad_articulo - (int)cantidad;
                //total_resta = art.Valor_articulo * resta;
                //this.Total_articulos -= art.Valor_articulo;
            }
            else
            {
                //resta = (int)cantidad - (int)art.Cantidad_articulo;
                //total_resta = art.Valor_articulo * resta;
                //this.Total_articulos += art.Valor_articulo;
            }
            this.Calcular();
        }

        private void ArtItem_OnBtnRemover(object sender, EventArgs e)
        {
            Articulos art = (Articulos)sender;
            List<Articulos> artFind =
               this.ArticulosSelected.Where(x => x.Id_articulo == art.Id_articulo).ToList();
            if (artFind.Count > 0)
            {
                this.ArticulosSelected.Remove(artFind[0]);
                //this.Total_articulos -= art.Cantidad_articulo * art.Valor_articulo;
                this.Calcular();
                this.LoadArticulosSelected();
            }
        }

        private bool isConnectedSuccess;

        private List<Articulos> _articulosList;
        private List<Articulos> _articulosSelected;

        public List<Articulos> ArticulosList
        {
            get => _articulosList;
            set => _articulosList = value;
        }
        public List<Articulos> ArticulosSelected
        {
            get => _articulosSelected;
            set
            {
                _articulosSelected = value;
                this.LoadArticulosSelected();
            }
        }
        public bool IsConnectedSuccess
        {
            get => isConnectedSuccess;
            set => isConnectedSuccess = value;
        }

        public decimal Total_articulos { get; set; }
        public decimal Total_abono { get; set; }
        public decimal Total_saldo { get; set; }

    }
}