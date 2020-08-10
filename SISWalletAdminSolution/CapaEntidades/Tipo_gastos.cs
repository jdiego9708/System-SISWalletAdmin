namespace CapaEntidades
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class Tipo_gastos
    {
        public Tipo_gastos()
        {

        }

        public Tipo_gastos(DataRow row)
        {
            try
            {
                this.Id_tipo_gasto = Convert.ToInt32(row["Id_tipo_gasto"]);
                this.Nombre_tipo_gasto = Convert.ToString(row["Nombre_tipo_gasto"]);
                this.Estado_tipo_gasto = Convert.ToString(row["Estado_tipo_gasto"]);     
            }
            catch (Exception)
            {

            }
        }
        public int Id_tipo_gasto { get; set; }
        public string Nombre_tipo_gasto { get; set; }
        public string Estado_tipo_gasto { get; set; }

    }
}
