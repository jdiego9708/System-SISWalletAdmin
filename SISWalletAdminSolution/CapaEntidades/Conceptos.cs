namespace CapaEntidades
{
    using System;
    using System.Data;

    public class Conceptos
    {
        public Conceptos()
        {

        }

        public Conceptos(DataRow row)
        {
            try
            {
                this.Id_concepto = Convert.ToInt32(row["Id_concepto"]);
                this.Concepto = Convert.ToString(row["Concepto"]);
                this.Estado_concepto = Convert.ToString(row["Estado_concepto"]);
            }
            catch (Exception)
            {

            }
        }

        public int Id_concepto { get; set; }

        public string Concepto { get; set; }

        public string Estado_concepto { get; set; }    
    }
}
