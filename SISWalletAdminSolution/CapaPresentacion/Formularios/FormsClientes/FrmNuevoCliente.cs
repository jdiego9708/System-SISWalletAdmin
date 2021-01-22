using CapaEntidades;
using CapaEntidades.Helpers;
using CapaNegocio;
using CapaPresentacion.Formularios.FormsArticulos;
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
        public FrmNuevoCliente()
        {
            InitializeComponent();
            this.Load += FrmNuevoCliente_Load;
            this.listaCiudades.SelectedIndexChanged += ListaCiudades_SelectedIndexChanged;
            this.txtBuscarArticulos.OnCustomKeyPress += TxtBuscarArticulos_OnCustomKeyPress;
        }

        private void TxtBuscarArticulos_OnCustomKeyPress(object sender, KeyPressEventArgs e)
        {

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
            this.ArticulosSelected.Add(art);
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
            }
        }
        public bool IsConnectedSuccess
        {
            get => isConnectedSuccess;
            set => isConnectedSuccess = value;
        }
    }
}
