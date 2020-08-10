namespace CapaEntidades
{
    using System;
    using System.Data;

    public class Cobros
    {
        public Cobros()
        {

        }

        public Cobros(DataRow row)
        {
            try
            {
                this.Id_cobro = Convert.ToInt32(row["Id_cobro"]);
                this.Id_usuario = Convert.ToInt32(row["Id_usuario"]);
                this.Usuario = new Usuarios(row);
                this.Id_tipo_producto = Convert.ToInt32(row["Id_tipo_producto"]);
                this.Tipo_producto = new Tipo_productos(row);
                this.Id_zona = Convert.ToInt32(row["Id_zona"]);
                this.Zona = new Zonas(row);
                this.Fecha_apertura = Convert.ToDateTime(row["Fecha_apertura"]);
                this.Hora_apertura = TimeSpanConvert.StringToTimeSpan(row["Hora_apertura"].ToString());
                this.Valor_cobro = Convert.ToDecimal(row["Valor_cobro"]);
                this.Estado_cobro = Convert.ToString(row["Estado_cobro"]);
                this.Observaciones = Convert.ToString(row["Observaciones"]);

            }
            catch (Exception ex)
            {

            }
        }

        public int Id_cobro { get; set; }

        public int Id_usuario { get; set; }
        public virtual Usuarios Usuario { get; set; }

        public int Id_tipo_producto { get; set; }
        public virtual Tipo_productos Tipo_producto { get; set; }

        public int Id_zona { get; set; }
        public virtual Zonas Zona { get; set; }
        public DateTime Fecha_apertura { get; set; } = DateTime.Now;
        public TimeSpan Hora_apertura { get; set; } = DateTime.Now.TimeOfDay;
        public decimal Valor_cobro { get; set; }
        public string Estado_cobro { get; set; } = "ACTIVO";
        public string Observaciones { get; set; }
    }
}
