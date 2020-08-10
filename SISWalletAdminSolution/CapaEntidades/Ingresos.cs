namespace CapaEntidades
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class Ingresos
    {
        public Ingresos()
        {

        }

        public Ingresos(DataRow row)
        {
            try
            {
                this.Id_ingreso = Convert.ToInt32(row["Id_ingreso"]);
                this.Id_usuario = Convert.ToInt32(row["Id_usuario"]);
                this.Usuario = new Usuarios(row);
                this.Id_turno = Convert.ToInt32(row["Id_turno"]);
                this.Turno = new Turnos(row);
                this.Fecha_ingreso = Convert.ToDateTime(row["Fecha_ingreso"]);
                this.Hora_ingreso = TimeSpanConvert.StringToTimeSpan(row["Hora_ingreso"].ToString());
                this.Valor_ingreso = Convert.ToDecimal(row["Valor_ingreso"]);
                this.Observaciones_ingreso = Convert.ToString(row["Observaciones_ingreso"]);
                this.Estado_ingreso = Convert.ToString(row["Estado_ingreso"]);
            }
            catch (Exception ex)
            {

            }
        }

        public int Id_ingreso { get; set; }

        public int Id_usuario { get; set; }
        public virtual Usuarios Usuario { get; set; }

        public int Id_turno { get; set; }
        public virtual Turnos Turno { get; set; }
        public DateTime Fecha_ingreso { get; set; } = DateTime.Now;
        public TimeSpan Hora_ingreso { get; set; } = DateTime.Now.TimeOfDay;
        public decimal Valor_ingreso { get; set; }
        public string Observaciones_ingreso { get; set; }
        public string Estado_ingreso { get; set; }
    }
}
