namespace CapaEntidades
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class Tipo_solicitudes
    {
        public Tipo_solicitudes()
        {

        }

        public Tipo_solicitudes(DataRow row)
        {
            try
            {
                this.Id_tipo_solicitud = Convert.ToInt32(row["Id_tipo_solicitud"]);
                this.Nombre_tipo_solicitud = Convert.ToString(row["Nombre_tipo_solicitud"]);
                this.Estado_tipo_solicitud = Convert.ToString(row["Estado_tipo_solicitud"]);              
            }
            catch (Exception)
            {

            }
        }
        public int Id_tipo_solicitud { get; set; }
        public string Nombre_tipo_solicitud { get; set; }
        public string Estado_tipo_solicitud { get; set; } = "ACTIVO";

    }
}
