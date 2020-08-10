namespace CapaEntidades
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class Paises
    {
        public Paises()
        {

        }

        public Paises(DataRow row)
        {
            try
            {
                this.Id_pais = Convert.ToInt32(row["Id_pais"]);
                this.Nombre_pais = Convert.ToString(row["Nombre_pais"]);
                this.Observaciones_pais = Convert.ToString(row["Observaciones_pais"]);
                this.Estado_pais = Convert.ToString(row["Estado_pais"]);
            }
            catch (Exception ex)
            {

            }
        }

        public int Id_pais { get; set; }
        public string Nombre_pais { get; set; }
        public string Observaciones_pais { get; set; }
        public string Estado_pais { get; set; }
    }
}
