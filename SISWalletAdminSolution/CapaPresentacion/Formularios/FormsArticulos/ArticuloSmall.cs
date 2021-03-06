﻿using CapaEntidades;
using CapaPresentacion.Properties;
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
    public partial class ArticuloSmall : UserControl
    {
        PoperContainer container;

        public ArticuloSmall()
        {
            InitializeComponent();
            this.btnNext.Click += BtnNext_Click;
            this.numericCantidad.ValueChanged += NumericCantidad_ValueChanged;
            this.btnEditar.Click += BtnEditar_Click;
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            PrecioSmall precioSmall = new PrecioSmall
            {
                PrecioArticulo = this.Articulo.Valor_articulo,
            };
            precioSmall.OnBtnSaveClick += PrecioSmall_OnBtnSaveClick;
            this.container = new PoperContainer(precioSmall);
            this.container.Show(this.btnEditar);
        }

        private void PrecioSmall_OnBtnSaveClick(object sender, EventArgs e)
        {
            decimal num = (decimal)sender;

            if (this.Articulo.Valor_articulo != num)
            {
                this.Articulo.Valor_articulo = num;
                this.txtPrecio.Tag = num;
                this.txtPrecio.Text = num.ToString("C");
            }

            if (this.container != null)
                this.container.Close();
        }

        private void NumericCantidad_ValueChanged(object sender, EventArgs e)
        {
            //this.Articulo.Cantidad_articulo = this.numericCantidad.Value;
            if (this.OnCantidadChanged != null)
            {
                this.OnCantidadChanged.Invoke(new object[] { this.Articulo, this.numericCantidad.Value }, e);
                this.Articulo.Cantidad_articulo = this.numericCantidad.Value;
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (this.IsAdd)
            { 
                this.OnBtnRemover?.Invoke(this.Articulo, e);
            }
            else
            {
                this.Articulo.Cantidad_articulo = this.numericCantidad.Value;
                this.OnBtnNext?.Invoke(this.Articulo, e);
            }
        }

        public event EventHandler OnCantidadChanged;
        public event EventHandler OnBtnNext;
        public event EventHandler OnBtnRemover;

        private void AsignarDatos(Articulos articulo)
        {
            this.txtReferencia.Text =
                "Referencia: (" + articulo.Id_articulo + ")" + articulo.Referencia_articulo + ".";
            this.txtPrecio.Text = articulo.Valor_articulo.ToString("C");
            this.txtPrecio.Tag = articulo.Valor_articulo;
            this.numericCantidad.Minimum = 0;
            this.numericCantidad.Value = articulo.Cantidad_articulo;
        }

        private Articulos articulo;
        private bool _isAdd;

        public Articulos Articulo { get => articulo;
            set
            {
                articulo = value;
                this.AsignarDatos(value);
            }
        }

        public bool IsAdd
        {
            get => _isAdd;
            set
            {
                _isAdd = value;
                this.btnNext.BackgroundImage = Resources.negative;
            }
        }

    }
}
