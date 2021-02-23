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

            this.dateFechaVenta.ValueChanged += DateFechaVenta_ValueChanged;
        }

        public event EventHandler OnRefresh;

        private void DateFechaVenta_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker date = (DateTimePicker)sender;
            this.dateUltimoPago.MinDate = date.Value;
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
                this.gbFechaVenta.Visible = true;
                this.gbArticulosSelected.Enabled = false;
                this.gbBusquedaArticulos.Enabled = false;
                this.gbResultados.Enabled = false;
                this.gbUltimoPago.Text = "Fecha de último pago";
            }
        }

        private void RdActual_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rd = (RadioButton)sender;
            if (rd.Checked)
            {
                this.gbValorVenta.Visible = true;
                this.gbUltimoPago.Visible = true;
                this.gbFechaVenta.Visible = true;
                this.gbArticulosSelected.Enabled = true;
                this.gbBusquedaArticulos.Enabled = true;
                this.gbResultados.Enabled = true;

                this.gbUltimoPago.Text = "Fecha de abono";
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
            agendamiento = new Agendamiento_cobros();
            int id_cobro = 0;
            int id_tipo_producto = 0;

            if (this.IsEditar)
            {
                id_tipo_producto = this.Venta.Id_tipo_producto;
                id_cobro = this.Venta.Id_cobro;
                usuario = this.Venta.Cliente;
                direccion = this.Venta.Direccion;
                venta = this.Venta;

                venta.Id_cobro = id_cobro;

                venta.Id_tipo_producto = id_tipo_producto;

                venta.Id_turno = main.Turno.Id_turno;

                this.Total_articulos = venta.Total_venta;
            }
            else
            {
                usuario = new Usuarios();
                direccion = new Direccion_clientes();
                venta = new Ventas();

                id_tipo_producto = 2;
                id_cobro = main.Turno.Id_cobro;

                usuario.Fecha_ingreso = DateTime.Now;
                usuario.Tipo_usuario = "CLIENTE";
                usuario.Estado_usuario = "ACTIVO";
                usuario.Email = string.Empty;

                direccion.Estado_direccion = "ACTIVO";

                venta.Id_cobro = id_cobro;
                venta.Id_tipo_producto = id_tipo_producto;
                venta.Id_turno = main.Turno.Id_turno;
                venta.Hora_venta = DateTime.Now.TimeOfDay;
                venta.Valor_venta = this.Total_articulos;
                venta.Total_venta = this.Total_articulos;
                venta.Fecha_venta = this.dateFechaVenta.Value;
                venta.Tipo_venta = "NUEVA";
                venta.Interes_venta = 0;
                venta.Estado_venta = "ACTIVO";

                agendamiento.Orden_cobro = 0;
            }

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

            if (!int.TryParse(this.listaBarrios.SelectedValue.ToString(), out int id_barrio))
            {
                Mensajes.MensajeInformacion("Verifique el barrio seleccionado", "Entendido");
                return false;
            }

            usuario.Alias = this.txtNombres.Text;
            usuario.Nombres = this.txtNombres.Text;
            usuario.Apellidos = this.txtApellidos.Text;
            usuario.Identificacion = this.txtIdentificacion.Text;

            if (string.IsNullOrEmpty(this.txtTelResidencia.Text))
                usuario.Celular = this.txtTelCliente.Text;
            else
                usuario.Celular = this.txtTelCliente.Text + " - " + this.txtTelResidencia.Text;

            direccion.Id_zona = id_barrio;
            direccion.Direccion = this.txtDireccionResidencia.Text;

            venta.Numero_cuotas = Convert.ToInt32(numericPlazo.Value);
            venta.Frecuencia_cobro = this.listaFrecuencia.Text;
            venta.Valor_cuota = (this.Total_articulos / Convert.ToInt32(numericPlazo.Value));

            if (!this.IsEditar)
            {
                if (!decimal.TryParse(this.txtValorAbono.Tag.ToString(), out decimal valor_abono))
                {
                    Mensajes.MensajeInformacion("Verifique el valor del abono", "Entendido");
                    return false;
                }

                agendamiento.Id_turno = main.Turno.Id_turno;

                if (this.rdActual.Checked)
                    agendamiento.Fecha_cobro = dateUltimoPago.Value;
                else
                    agendamiento.Fecha_cobro = dateUltimoPago.Value;

                agendamiento.Hora_cobro = DateTime.Now.TimeOfDay;
                agendamiento.Valor_cobro = venta.Valor_cuota;
                agendamiento.Valor_pagado = valor_abono;
                agendamiento.Saldo_restante = this.Total_saldo;
                agendamiento.Tipo_cobro = this.listaFrecuencia.Text;
                agendamiento.Observaciones_cobro = "";
                agendamiento.Estado_cobro = "TERMINADO";
            }

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
                    string rpta = "";

                    if (this.IsEditar)
                        rpta = NUsuarios.EditarUsuario(usuario.Id_usuario, usuario);
                    else
                    {
                        rpta = NUsuarios.InsertarUsuario(out int id_usuario, usuario);
                        direccion.Id_usuario = id_usuario;
                        venta.Id_cliente = id_usuario;
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsEditar)
                            rpta = NDireccion_clientes.EditarDireccion(direccion.Id_direccion, direccion);
                        else
                        {
                            rpta = NDireccion_clientes.InsertarDireccion(out int id_direccion, direccion);
                            venta.Id_direccion = id_direccion;
                        }

                        if (rpta.Equals("OK"))
                        {
                            if (this.IsEditar)
                                rpta = NVentas.EditarVenta(venta.Id_venta, venta);
                            else
                            {
                                rpta = NVentas.InsertarVenta(out int id_venta, venta);
                                venta.Id_venta = id_venta;
                            }

                            if (rpta.Equals("OK"))
                            {
                                if (this.rdActual.Checked && !this.IsEditar && this.Total_articulos == 0)
                                {
                                    foreach (Articulos art in this.ArticulosSelected)
                                    {
                                        Detalle_articulos_venta detalle = new Detalle_articulos_venta
                                        {
                                            Articulo = art,
                                            Id_articulo = art.Id_articulo,
                                            Venta = venta,
                                            Id_venta = venta.Id_venta,
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

                                if (!this.IsEditar)
                                {
                                    rpta = NUsuariosVentas.InsertarUsuarioVenta(new Usuarios_ventas
                                    {
                                        Id_usuario = main.Usuario.Id_usuario,
                                        Id_venta = venta.Id_venta,
                                    });

                                    if (rpta.Equals("OK"))
                                    {
                                        agendamiento.Id_venta = venta.Id_venta;
                                        rpta = NAgendamiento_cobros.InsertarAgendamiento(out int id_agendamiento, agendamiento);
                                        if (rpta.Equals("OK"))
                                        {
                                            MensajeEspera.CloseForm();
                                            Mensajes.MensajeInformacion("Se guardó correctamente el cliente, número asignado: " + usuario.Id_usuario, "Entendido");
                                            this.Close();
                                        }
                                        else
                                            throw new Exception(rpta);
                                    }
                                    else
                                        throw new Exception(rpta);
                                }
                                else
                                {
                                    //Obtener el último agendamiento
                                    var (rptaAg, dt) =
                                        await NAgendamiento_cobros.BuscarAgendamientos("ID VENTA", venta.Id_venta.ToString());
                                    if (dt != null)
                                    {
                                        agendamiento = new Agendamiento_cobros(dt.Rows[0]);
                                        agendamiento.Valor_cobro = venta.Valor_cuota;
                                        rptaAg = await NAgendamiento_cobros.EditarAgendamiento(agendamiento.Id_agendamiento, agendamiento);
                                        if (rptaAg != "OK")
                                        {
                                            Mensajes.MensajeInformacion("Se actualizó el cliente pero no su último pago, número asignado: " + usuario.Id_usuario, "Entendido");
                                            this.OnRefresh?.Invoke(sender, e);
                                            this.Close();
                                        }
                                        else
                                        {
                                            Mensajes.MensajeInformacion("Se actualizó correctamente el cliente, número asignado: " + usuario.Id_usuario, "Entendido");
                                            this.OnRefresh?.Invoke(sender, e);
                                            this.Close();
                                        }
                                    }
                                    else
                                    {
                                        Mensajes.MensajeInformacion("Se actualizó correctamente el cliente pero no se encontraron sus agendamientos, número asignado: " + usuario.Id_usuario, "Entendido");
                                        this.OnRefresh?.Invoke(sender, e);
                                        this.Close();
                                    }                               
                                }
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
            if (int.TryParse(Convert.ToString(this.listaCiudades.SelectedValue), out int id_ciudad))
            {
                this.LoadBarrios("ID CIUDAD", id_ciudad.ToString());
            }
        }

        private async void FrmNuevoCliente_Load(object sender, EventArgs e)
        {
            //Verificamos conexión
            Response connection = await ConnectionHelper.CheckConnection();
            this.IsConnectedSuccess = connection.IsSuccess;

            if (!this.IsEditar)
            {
                this.LoadCiudades("ID PAIS", "2020");
                await this.LoadArticulos("COMPLETO", "");
                this.LoadListaFrecuencia();
            }
        }

        private void LoadBarrios(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                DataTable dtZonas =
                    NZonas.BuscarZonas(tipo_busqueda, texto_busqueda, out string rpta);

                if (this.listaBarrios.DataSource != null)
                    this.listaBarrios.DataSource = null;

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

                if (this.listaCiudades.DataSource != null)
                    this.listaCiudades.DataSource = null;

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

        private void AsignarDatos(Ventas venta)
        {
            this.IsEditar = true;

            this.gbValorAbono.Visible = false;
            this.rdActual.Visible = false;
            this.rdAnterior.Visible = false;
            this.gbUltimoPago.Visible = false;

            this.txtNombres.Text = venta.Cliente.Nombres;
            this.txtApellidos.Text = venta.Cliente.Apellidos;
            this.txtIdentificacion.Text = venta.Cliente.Identificacion;
            this.txtValorTotalVenta.Tag = venta.Total_venta;
            this.txtValorTotalVenta.Text = venta.Total_venta.ToString("C");

            this.txtDireccionResidencia.Text = venta.Direccion.Direccion;
            this.txtTelCliente.Text = venta.Cliente.Celular;

            this.numericPlazo.Value = venta.Numero_cuotas;

            this.dateFechaVenta.Value = venta.Fecha_venta;

            this.LoadListaFrecuencia();
            this.listaFrecuencia.Text = venta.Frecuencia_cobro;

            this.LoadCiudades("ID PAIS", "2020");
            this.listaCiudades.SelectedValue = venta.Direccion.Zona.Id_ciudad.ToString();

            this.LoadBarrios("ID CIUDAD", venta.Direccion.Zona.Id_ciudad.ToString());
            this.listaBarrios.SelectedValue = venta.Direccion.Zona.Id_zona;
        }

        private bool isConnectedSuccess;

        private List<Articulos> _articulosList;
        private List<Articulos> _articulosSelected;
        private Ventas _venta;
        private bool _isEditar;

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
        public Ventas Venta
        {
            get => _venta;
            set
            {
                _venta = value;
                this.AsignarDatos(value);
            }
        }

        public bool IsEditar { get => _isEditar; set => _isEditar = value; }
    }
}