namespace CapaEntidades
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Data;

    //using SQLite;

    public class Ciudades
    {
        public Ciudades()
        {

        }

        public Ciudades(DataRow row)
        {
            try
            {
                this.Id_ciudad = Convert.ToInt32(row["Id_ciudad"]);
                this.Id_pais = Convert.ToInt32(row["Id_pais"]);
                this.Pais = new Paises(row);
                this.Nombre_ciudad = Convert.ToString(row["Nombre_ciudad"]);
                this.Observaciones_ciudad = Convert.ToString(row["Observaciones_ciudad"]);
                this.Estado_ciudad = Convert.ToString(row["Estado_ciudad"]);
            }
            catch (Exception)
            {

            }
        }

        public int Id_ciudad { get; set; }

        public int Id_pais { get; set; }
        public Paises Pais { get; set; }
        public string Nombre_ciudad { get; set; }
        public string Observaciones_ciudad { get; set; }
        public string Estado_ciudad { get; set; }
       
    }
}
