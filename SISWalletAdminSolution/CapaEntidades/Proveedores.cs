namespace CapaEntidades
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class Proveedores
    {
        public Proveedores()
        {

        }

        public Proveedores(DataRow row)
        {
            try
            {
                this.Id_proveedor = Convert.ToInt32(row["Id_proveedor"]);
                this.Fecha_ingreso = Convert.ToDateTime(row["Fecha_ingreso"]);
                this.Nombre_proveedor = Convert.ToString(row["Nombre_proveedor"]);
                this.Descripcion_proveedor = Convert.ToString(row["Descripcion_proveedor"]);
                this.Contacto_proveedor = Convert.ToString(row["Contacto_proveedor"]);
                this.Estado_proveedor = Convert.ToString(row["Estado_proveedor"]);
            }
            catch (Exception ex)
            {

            }
        }

        public int Id_proveedor { get; set; }
        public DateTime Fecha_ingreso { get; set; } = DateTime.Now;
        public string Nombre_proveedor { get; set; }
        public string Descripcion_proveedor { get; set; }
        public string Contacto_proveedor { get; set; }
        public string Estado_proveedor { get; set; }
    }
}
