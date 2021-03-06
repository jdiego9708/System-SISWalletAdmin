﻿namespace CapaEntidades
{
    using System;
    using System.Data;

    public class Articulos
    {
        public Articulos()
        {

        }

        public Articulos(DataRow row)
        {
            try
            {
                this.Id_articulo = Convert.ToInt32(row["Id_articulo"]);
                this.Id_proveedor = Convert.ToInt32(row["Id_proveedor"]);
                this.Proveedor = new Proveedores(row);
                this.Valor_proveedor = Convert.ToDecimal(row["Valor_proveedor"]);
                this.Referencia_articulo = Convert.ToString(row["Referencia_articulo"]);
                this.Descripcion_articulo = Convert.ToString(row["Descripcion_articulo"]);
                this.Tipo_cantidad = Convert.ToString(row["Tipo_cantidad"]);
                this.Cantidad_articulo = Convert.ToDecimal(row["Cantidad_articulo"]);
                this.Cantidad_inicial = Convert.ToDecimal(row["Cantidad_inicial"]);
                this.Valor_articulo = Convert.ToDecimal(row["Valor_articulo"]);
                this.Estado_articulo = Convert.ToString(row["Estado_articulo"]);
            }
            catch (Exception)
            {

            }
        }

        public int Id_articulo { get; set; }

        public int Id_proveedor { get; set; }

        public Proveedores Proveedor { get; set; }

        public decimal Valor_proveedor { get; set; }

        public string Referencia_articulo { get; set; }

        public string Descripcion_articulo { get; set; }

        public string Tipo_cantidad { get; set; }

        public decimal Cantidad_articulo { get; set; }

        public decimal Cantidad_inicial { get; set; }

        public decimal Valor_articulo { get; set; }

        public string Estado_articulo { get; set; }    
    }
}
