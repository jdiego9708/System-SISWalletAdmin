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
using CapaEntidades;

namespace CapaPresentacion.Formularios.FormsZonas
{
    public partial class AddZonaSmall : UserControl
    {
        public AddZonaSmall()
        {
            InitializeComponent();
            this.btnSave.Click += BtnSave_Click;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(this.txtZona.Text))
            {
                Mensajes.MensajeInformacion("Verifique el nombre del barrio", "Entendido");
                return;
            }

            string rpta = NZonas.InsertarZona(out int id_zona, new CapaEntidades.Zonas
            {
                Id_ciudad = this.Id_ciudad,
                Nombre_zona = this.txtZona.Text,
                Observaciones_zona = "",
                Estado_zona = "ACTIVO",
            });

            if (rpta.Equals("OK"))
                OnBtnSaveSuccess?.Invoke(this.Id_ciudad, e);
            else
                Mensajes.MensajeInformacion("No se pudo guardar el barrio", "Entendido");
        }

        public event EventHandler OnBtnSaveSuccess;
        public int Id_ciudad { get; set; }
    }
}
