namespace CapaEntidades
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class Gastos
    {
        public Gastos()
        {

        }

        public Gastos(DataRow row)
        {
            try
            {
                this.Id_gasto = Convert.ToInt32(row["Id_gasto"]);
                this.Id_tipo_gasto = Convert.ToInt32(row["Id_tipo_gasto"]);
                this.Tipo_gasto = new Tipo_gastos(row);
                this.Id_usuario = Convert.ToInt32(row["Id_usuario"]);
                this.Usuario = new Usuarios(row);
                this.Id_turno = Convert.ToInt32(row["Id_turno"]);
                this.Turno = new Turnos(row);
                this.Fecha_gasto = Convert.ToDateTime(row["Fecha_gasto"]);
                this.Hora_gasto = TimeSpanConvert.StringToTimeSpan(row["Hora_gasto"].ToString());
                this.Valor_gasto = Convert.ToDecimal(row["Valor_gasto"]);
                this.Observaciones_gasto = Convert.ToString(row["Observaciones_gasto"]);
                this.Estado_gasto = Convert.ToString(row["Estado_gasto"]);
            }
            catch (Exception ex)
            {

            }
        }

        public int Id_gasto { get; set; }

        public int Id_tipo_gasto { get; set; }
        public virtual Tipo_gastos Tipo_gasto { get; set; }

        public int Id_usuario { get; set; }
        public virtual Usuarios Usuario { get; set; }

        public int Id_turno { get; set; }
        public virtual Turnos Turno { get; set; }
        public DateTime Fecha_gasto { get; set; } = DateTime.Now;
        public TimeSpan Hora_gasto { get; set; } = DateTime.Now.TimeOfDay;
        public decimal Valor_gasto { get; set; }
        public string Observaciones_gasto { get; set; }
        public string Estado_gasto { get; set; }
    }
}
