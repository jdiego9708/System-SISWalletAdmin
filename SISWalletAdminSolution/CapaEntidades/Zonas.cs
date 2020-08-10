namespace CapaEntidades
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class Zonas
    {
        public Zonas()
        {

        }

        public Zonas(DataRow row)
        {
            try
            {
                this.Id_zona = Convert.ToInt32(row["Id_zona"]);
                this.Id_ciudad = Convert.ToInt32(row["Id_ciudad"]);
                this.Ciudad = new Ciudades(row);
                this.Nombre_zona = Convert.ToString(row["Nombre_zona"]);
                this.Observaciones_zona = Convert.ToString(row["Observaciones_zona"]);
                this.Estado_zona = Convert.ToString(row["Estado_zona"]);
            }
            catch (Exception ex)
            {

            }
        }

        public int Id_zona { get; set; }
        public int Id_ciudad { get; set; }
        public virtual Ciudades Ciudad { get; set; }
        public string Nombre_zona { get; set; }
        public string Observaciones_zona { get; set; }
        public string Estado_zona { get; set; }
    }
}
