using CapaEntidades;
using CapaEntidades.Helpers;
using CapaNegocio;
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
    public partial class FrmObservarArticulos : Form
    {
        public FrmObservarArticulos()
        {
            InitializeComponent();
            this.btnNuevoArticulo.Click += BtnNuevoArticulo_Click;
            this.btnRefresh.Click += BtnRefresh_Click;
        }

        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            await this.LoadArticulos("COMPLETO", "");
        }

        private void BtnNuevoArticulo_Click(object sender, EventArgs e)
        {
            FrmNuevoArticulo frmNuevoArticulo = new FrmNuevoArticulo
            {
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal,
            };
            frmNuevoArticulo.OnArticuloSuccess += FrmNuevoArticulo_OnArticuloSuccess;
            frmNuevoArticulo.Show();
        }

        private async void FrmNuevoArticulo_OnArticuloSuccess(object sender, EventArgs e)
        {     
            await this.LoadArticulos("COMPLETO", "");
        }

        public async Task LoadArticulos(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                //Verificamos conexión
                Response connection = await ConnectionHelper.CheckConnection();
                //Si la conexión es false mostraremos un mensaje
                if (connection.IsSuccess)
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
                            ArticuloItem artItem = new ArticuloItem
                            {
                                Articulo = art,
                            };
                            artItem.OnBtnAddStock += ArtItem_OnBtnAddStock;
                            controls.Add(artItem);
                        }

                        this.panelArticulos.PageSize = 30;
                        this.panelArticulos.OnBsPositionChanged += PanelArticulos_OnBsPositionChanged;
                        this.panelArticulos.SetPagedDataSource(controls, this.bindingNavigator1);
                        this.positionChanged = 1;

                        if (this.ArticulosList.Count <= 0)
                            this.lblResultados.Text = "No hay articulos";
                        else if (this.ArticulosList.Count == 1)
                            this.lblResultados.Text = "Hay un articulo";
                        else if (this.ArticulosList.Count > 1)
                            this.lblResultados.Text = "Se encontraron " + this.ArticulosList.Count + " articulos.";
                    }
                    else
                    {
                        this.lblResultados.Text = "No hay articulos";

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

        private void ArtItem_OnBtnAddStock(object sender, EventArgs e)
        {
            Articulos articulo = (Articulos)sender;
            FrmNuevoArticulo frmNuevoArticulo = new FrmNuevoArticulo
            {
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal,
                Articulo = articulo,
            };
            frmNuevoArticulo.OnArticuloSuccess += FrmNuevoArticulo_OnArticuloSuccess;
            frmNuevoArticulo.Show();
            frmNuevoArticulo.AsignarDatos(articulo);
        }

        public void LoadArticulos(DataTable dtArticulos)
        {
            try
            {
                if (this.ArticulosList != null)
                    this.ArticulosList.Clear();

                if (this.panelArticulos.Controls.Count > 0)
                    this.panelArticulos.Controls.Clear();

                if (dtArticulos != null)
                {
                    List<Articulos> articulos = (from DataRow dr in dtArticulos.Rows
                                                 select new Articulos(dr)).ToList();

                    this.ArticulosList = articulos;

                    List<UserControl> controls = new List<UserControl>();
                    foreach (Articulos art in articulos)
                    {
                        ArticuloItem artItem = new ArticuloItem
                        {
                            Articulo = art,
                        };
                        artItem.OnBtnAddStock += ArtItem_OnBtnAddStock;
                        controls.Add(artItem);
                    }

                    this.panelArticulos.PageSize = 30;
                    this.panelArticulos.OnBsPositionChanged += PanelArticulos_OnBsPositionChanged;
                    this.panelArticulos.SetPagedDataSource(controls, this.bindingNavigator1);

                    if (this.ArticulosList.Count <= 0)
                        this.lblResultados.Text = "No hay articulos";
                    else if (this.ArticulosList.Count == 1)
                        this.lblResultados.Text = "Hay un articulo";
                    else if (this.ArticulosList.Count > 1)
                        this.lblResultados.Text = "Se encontraron " + this.ArticulosList.Count + " articulos.";
                }
                else
                {
                    this.lblResultados.Text = "No hay articulos";
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "public async Task LoadArticulos",
                    "Hubo un error al buscar artículos", ex.Message);
            }
        }

        private List<Articulos> _articulosList;

        public List<Articulos> ArticulosList { get => _articulosList; set => _articulosList = value; }
    }
}
