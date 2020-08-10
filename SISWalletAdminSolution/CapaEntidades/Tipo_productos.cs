namespace CapaEntidades
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class Tipo_productos
    {
        public Tipo_productos()
        {

        }

        public Tipo_productos(DataRow row)
        {
            try
            {
                this.Id_tipo_producto = Convert.ToInt32(row["Id_tipo_producto"]);
                this.Nombre_producto = Convert.ToString(row["Nombre_producto"]);
                this.Descripcion_producto = Convert.ToString(row["Descripcion_producto"]);
                this.Estado_producto = Convert.ToString(row["Estado_producto"]);              
            }
            catch (Exception)
            {

            }
        }

        public int Id_tipo_producto { get; set; }
        public string Nombre_producto { get; set; }
        public string Descripcion_producto { get; set; }
        public string Estado_producto { get; set; } = "ACTIVO";

    }
}
