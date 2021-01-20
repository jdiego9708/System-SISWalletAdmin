using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Formularios.FormsProveedores;
using CapaPresentacion.Formularios.FormsReportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.FormsArticulos
{
    public partial class FrmNuevoArticulo : Form
    {
        public FrmNuevoArticulo()
        {
            InitializeComponent();
            this.Load += FrmNuevoArticulo_Load;
            this.txtValor.KeyPress += TxtValor_KeyPress;
            this.numericValorProveedor.KeyPress += TxtValor_KeyPress;
            this.btnGuardar.Click += BtnGuardar_Click;
            this.btnSeleccionarProveedor.Click += BtnSeleccionarProveedor_Click;
            this.numericCantidad.ValueChanged += NumericCantidad_ValueChanged;
        }

        private void NumericCantidad_ValueChanged(object sender, EventArgs e)
        {
            this.lblValorTotalProveedor.Text = "Total valor proveedor " + (this.numericCantidad.Value * this.numericValorProveedor.Value).ToString("C");
        }

        private void BtnSeleccionarProveedor_Click(object sender, EventArgs e)
        {
            FrmObservarProveedores frmObservarProveedores = new FrmObservarProveedores
            {
                StartPosition = FormStartPosition.CenterScreen,
                AddArticulo = true,
            };
            frmObservarProveedores.OnProveedorSelected += FrmObservarProveedores_OnProveedorSelected;
            frmObservarProveedores.ShowDialog();
        }

        private void FrmObservarProveedores_OnProveedorSelected(object sender, EventArgs e)
        {
            Proveedores proveedor = (Proveedores)sender;
            this.btnSeleccionarProveedor.Text = proveedor.Nombre_proveedor;
            this.btnSeleccionarProveedor.Tag = proveedor;
        }

        public event EventHandler OnArticuloSuccess;

        private void Limpiar()
        {
            this.txtReferencia.Clear();
            this.txtDescripcion.Clear();
            this.numericCantidad.Value = 1;
            this.txtValor.Text = "0";
        }

        private bool Comprobaciones(out Articulos articulo)
        {
            if (this.IsEditar)
                articulo = this.Articulo;
            else
                articulo = new Articulos();

            if (string.IsNullOrWhiteSpace(this.txtReferencia.Text))
            {
                Mensajes.MensajeInformacion("La referencia no puede estar vacía", "Entendido");
                return false;
            }

            if (this.numericCantidad.Value == 0)
            {
                Mensajes.MensajeInformacion("Verifique la cantidad no puede ser 0", "Entendido");
                return false;
            }

            if (string.IsNullOrWhiteSpace(this.listaTipoCantidad.Text))
            {
                Mensajes.MensajeInformacion("El tipo de cantidad no puede estar vacío", "Entendido");
                return false;
            }

            if (!decimal.TryParse(this.txtValor.Text, out decimal valor))
            {
                Mensajes.MensajeInformacion("Verifique el valor", "Entendido");
                return false;
            }
            else
            {
                if (valor == 0)
                {
                    Mensajes.MensajeInformacion("Verifique el valor no puede ser 0", "Entendido");
                    return false;
                }
            }

            Proveedores proveedor;
            if (this.btnSeleccionarProveedor.Tag == null)
            {
                Mensajes.MensajeInformacion("Verifique el proveedor seleccionado", "Entendido");
                return false;
            }

            proveedor = (Proveedores)this.btnSeleccionarProveedor.Tag;

            if (!decimal.TryParse(this.numericValorProveedor.Value.ToString(), out decimal valor_proveedor))
            {
                Mensajes.MensajeInformacion("Verifique el valor del proveedor", "Entendido");
                return false;
            }
            else
            {
                if (valor == 0)
                {
                    Mensajes.MensajeInformacion("Verifique el valor no puede ser 0", "Entendido");
                    return false;
                }
            }

            articulo.Proveedor = proveedor;
            articulo.Id_proveedor = proveedor.Id_proveedor;
            articulo.Valor_proveedor = valor_proveedor;
            articulo.Referencia_articulo = this.txtReferencia.Text.ToUpper();
            articulo.Tipo_cantidad = this.listaTipoCantidad.Text.ToUpper();
            articulo.Cantidad_articulo = this.numericCantidad.Value;
            articulo.Cantidad_inicial = this.numericCantidad.Value;
            articulo.Valor_articulo = valor;
            articulo.Descripcion_articulo = this.txtDescripcion.Text;

            if (this.rdPendiente.Checked)
            {
                articulo.Estado_articulo = "PENDIENTE";
            }
            else
            {
                articulo.Estado_articulo = "ACTIVO";
            }

            return true;
        }

        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Comprobaciones(out Articulos articulo))
                {
                    MensajeEspera.ShowWait("Guardando...");
                    string rpta = "OK";

                    if (this.IsEditar)
                    {
                        rpta = await NArticulos.EditarArticulos(articulo.Id_articulo, articulo);
                    }
                    else
                    {
                        var (rptaArticulo, id_articulo) = await NArticulos.InsertarArticulo(articulo);
                        rpta = rptaArticulo;
                        articulo.Id_articulo = id_articulo;

                        if (this.chkImprimir.Checked)
                        {
                            DataTable dtFacturaArticulos = new DataTable("dtArticulosFacturas");
                            dtFacturaArticulos.Columns.Add("Id_articulo", typeof(int));
                            dtFacturaArticulos.Columns.Add("Referencia_articulo", typeof(string));
                            dtFacturaArticulos.Columns.Add("Cantidad_articulo", typeof(string));
                            dtFacturaArticulos.Columns.Add("Id_proveedor", typeof(string));
                            dtFacturaArticulos.Columns.Add("Proveedor", typeof(string));
                            dtFacturaArticulos.Columns.Add("Valor_proveedor", typeof(string));
                            dtFacturaArticulos.Columns.Add("Descripcion_articulo", typeof(string));

                            DataRow newRow = dtFacturaArticulos.NewRow();
                            newRow["Id_articulo"] = articulo.Id_articulo;
                            newRow["Referencia_articulo"] = articulo.Referencia_articulo;
                            newRow["Cantidad_articulo"] = articulo.Cantidad_articulo;
                            newRow["Id_proveedor"] = articulo.Id_proveedor;
                            newRow["Proveedor"] = articulo.Proveedor.Nombre_proveedor;
                            newRow["Valor_proveedor"] = articulo.Valor_proveedor;
                            newRow["Descripcion_articulo"] = articulo.Descripcion_articulo;
                            dtFacturaArticulos.Rows.Add(newRow);

                            FrmReporteFactura frmReporte = new FrmReporteFactura
                            {
                                Id_articulo = articulo.Id_articulo.ToString(),
                                FechaHora = DateTime.Now.ToLongTimeString() + " " + DateTime.Now.ToLongTimeString(),
                                EstadoFactura = articulo.Estado_articulo,
                                TotalFactura = (this.numericCantidad.Value * this.numericValorProveedor.Value).ToString(),
                                WindowState = FormWindowState.Maximized,
                                dtArticulosFactura = dtFacturaArticulos,
                            };
                            frmReporte.Show();
                        }
                    }

                    MensajeEspera.CloseForm();
                    if (rpta.Equals("OK"))
                    {
                        this.Limpiar();
                        Mensajes.MensajeInformacion("Se guardó correctamente el artículo", "Entendido");
                        this.OnArticuloSuccess?.Invoke(articulo, e);
                        this.Close();
                    }
                    else
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                MensajeEspera.CloseForm();
                Mensajes.MensajeErrorCompleto(this.Name, "BtnGuardar_Click",
                    "Hubo un error con el botón guardar", ex.Message);
            }
        }

        private void TxtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TxtStockInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void ListaTipoCantidad()
        {
            this.listaTipoCantidad.Items.Clear();
            this.listaTipoCantidad.Items.Add("UNIDADES");
        }

        private void FrmNuevoArticulo_Load(object sender, EventArgs e)
        {
            this.ListaTipoCantidad();
        }

        public void AsignarDatos(Articulos articulo)
        {
            this.txtValor.Text = ((int)articulo.Valor_articulo).ToString();
            this.txtReferencia.Text = articulo.Referencia_articulo;
            this.numericCantidad.Value = articulo.Cantidad_articulo;
            this.txtDescripcion.Text = articulo.Descripcion_articulo;
            this.ListaTipoCantidad();
            this.listaTipoCantidad.SelectedIndex = listaTipoCantidad.FindStringExact(articulo.Tipo_cantidad);
            this.btnSeleccionarProveedor.Tag = articulo.Proveedor;
            this.btnSeleccionarProveedor.Text = articulo.Proveedor.Nombre_proveedor;
            this.numericValorProveedor.Value = articulo.Valor_proveedor;
            this.lblValorTotalProveedor.Text = 
                "(Cantidad inicial " + (int)articulo.Cantidad_inicial + ") Total valor proveedor $" + (articulo.Cantidad_inicial * articulo.Valor_proveedor).ToString("N2");

            if (articulo.Estado_articulo.Equals("ACTIVO"))
                this.rdPaga.Checked = true;
            else
                this.rdPendiente.Checked = true;
        }

        private bool isEditar;
        private Articulos _articulo;

        public bool IsEditar
        {
            get => isEditar;
            set
            {
                isEditar = value;
                this.Text = "Editar un artículo";
                this.txtReferencia.ReadOnly = false;
                this.txtDescripcion.ReadOnly = false;
                this.txtValor.ReadOnly = false;
                this.listaTipoCantidad.Enabled = false;
            }
        }

        public Articulos Articulo
        {
            get => _articulo;
            set
            {
                _articulo = value;
                this.IsEditar = true;
            }
        }
    }
}
