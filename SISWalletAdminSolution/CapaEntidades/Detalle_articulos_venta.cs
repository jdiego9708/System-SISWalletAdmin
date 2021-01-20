namespace CapaEntidades
{
    using System;
    using System.Data;

    public class Detalle_articulos_venta
    {
        public Detalle_articulos_venta()
        {

        }

        public Detalle_articulos_venta(DataRow row)
        {
            try
            {
                this.Id_detalle_venta = Convert.ToInt32(row["Id_detalle_venta"]);
                this.Id_articulo = Convert.ToInt32(row["Id_articulo"]);
                this.Articulo = new Articulos(row);
                this.Id_venta = Convert.ToInt32(row["Id_venta"]);
                this.Venta = new Ventas(row);
                this.Cantidad_articulo = Convert.ToInt32(row["Cantidad_articulo"]);
                this.Estado_detalle = Convert.ToString(row["Estado_detalle"]);
            }
            catch (Exception)
            {

            }
        }

        public int Id_detalle_venta { get; set; }

        public int Id_articulo { get; set; }

        public Articulos Articulo { get; set; }

        public int Id_venta{ get; set; }

        public Ventas Venta { get; set; }

        public int Cantidad_articulo { get; set; }

        public string Estado_detalle{ get; set; }    
    }
}
