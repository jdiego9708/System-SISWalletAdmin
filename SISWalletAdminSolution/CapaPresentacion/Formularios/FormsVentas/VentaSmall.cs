using CapaEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.FormsVentas
{
    public partial class VentaSmall : UserControl
    {
        public VentaSmall()
        {
            InitializeComponent();
            this.btnNext.Click += BtnNext_Click;
            this.btnEdit.Click += BtnEdit_Click;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            this.OnBtnEdit?.Invoke(this.Venta, e);
        }

        public event EventHandler OnBtnNext;

        public event EventHandler OnBtnEdit;

        private void BtnNext_Click(object sender, EventArgs e)
        {
            this.OnBtnNext?.Invoke(this.Venta, e);
        }

        private void AsignarDatos(Ventas venta)
        {
            StringBuilder info = new StringBuilder();
            info.Append("(" + venta.Id_venta + ") Fecha venta: ").Append(venta.Fecha_venta.ToLongDateString()).Append(Environment.NewLine);
            info.Append("Valor sin interés: ").Append(venta.Valor_venta.ToString("C")).Append(" - Interés aplicado: %" + (venta.Interes_venta * 100) + " - Total venta: ").Append(Venta.Total_venta.ToString("C")).Append(Environment.NewLine);
            info.Append("Tipo de venta: ").Append(venta.Tipo_producto.Nombre_producto).Append(Environment.NewLine);
            info.Append("Cuotas: ").Append(venta.Numero_cuotas).Append(" Valor de la cuota: " + venta.Valor_cuota.ToString("C")).Append(Environment.NewLine);
            info.Append("Estado de la venta: ").Append(Venta.Estado_venta);
            this.txtInfoVenta.Text = info.ToString();

            if (venta.Estado_venta.Equals("ACTIVO"))
                this.panel1.BackColor = Color.FromArgb(255, 128, 128);
            else
                this.panel1.BackColor = Color.SteelBlue;
        }

        private Ventas _venta;

        public Ventas Venta
        {
            get => _venta;
            set
            {
                _venta = value;
                this.AsignarDatos(value);
            }
        }
    }
}
