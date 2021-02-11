namespace CapaEntidades
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class Turnos
    {
        public Turnos()
        {

        }

        public Turnos(DataRow row)
        {
            try
            {
                this.Id_turno = Convert.ToInt32(row["Id_turno"]);
                this.Id_cobrador = Convert.ToInt32(row["Id_cobrador"]);
                this.Cobrador = new Usuarios(row);
                this.Id_cobro = Convert.ToInt32(row["Id_cobro"]);
                this.Cobro = new Cobros(row);
                this.Fecha_inicio_turno = Convert.ToDateTime(row["Fecha_inicio_turno"]);
                this.Fecha_fin_turno = Convert.ToDateTime(row["Fecha_fin_turno"]);
                this.Hora_inicio_turno = TimeSpanConvert.StringToTimeSpan(row["Hora_inicio_turno"].ToString());
                this.Hora_fin_turno = TimeSpanConvert.StringToTimeSpan(row["Hora_fin_turno"].ToString());
                this.Valor_inicial = Convert.ToDecimal(row["Valor_inicial"]);
                this.Clientes_iniciales = Convert.ToInt32(row["Clientes_iniciales"]);
                this.Clientes_nuevos = Convert.ToInt32(row["Clientes_nuevos"]);
                this.Clientes_cancelados = Convert.ToInt32(row["Clientes_cancelados"]);
                this.Clientes_total = Convert.ToInt32(row["Clientes_total"]);
                this.Recaudo_ventas_nuevas = Convert.ToDecimal(row["Recaudo_ventas_nuevas"]);
                this.Recaudo_cuotas = Convert.ToDecimal(row["Recaudo_cuotas"]);
                this.Recaudo_otros = Convert.ToDecimal(row["Recaudo_otros"]);
                this.Recaudo_pretendido_turno = Convert.ToDecimal(row["Recaudo_pretendido_turno"]);
                this.Recaudo_real = Convert.ToDecimal(row["Recaudo_real"]);
                this.Gastos_total = Convert.ToDecimal(row["Gastos_total"]);
                this.Estado_turno = Convert.ToString(row["Estado_turno"]);
            }
            catch (Exception ex)
            {

            }
        }

        public int Id_turno { get; set; }

        public int Id_cobrador { get; set; }
        public virtual Usuarios Cobrador { get; set; }

        public int Id_cobro { get; set; }
        public virtual Cobros Cobro { get; set; }
        public DateTime Fecha_inicio_turno { get; set; } = DateTime.Now;
        public DateTime Fecha_fin_turno { get; set; } = DateTime.Now;
        public TimeSpan Hora_inicio_turno { get; set; } = DateTime.Now.TimeOfDay;
        public TimeSpan Hora_fin_turno { get; set; } = DateTime.Now.TimeOfDay;
        public decimal Valor_inicial { get; set; }
        public int Clientes_iniciales { get; set; }
        public int Clientes_nuevos { get; set; }
        public int Clientes_cancelados { get; set; }
        public int Clientes_total { get; set; }
        public decimal Recaudo_ventas_nuevas { get; set; }
        public decimal Recaudo_cuotas { get; set; }
        public decimal Recaudo_otros { get; set; }
        public decimal Recaudo_pretendido_turno { get; set; }
        public decimal Recaudo_real { get; set; }
        public decimal Gastos_total { get; set; }
        public string Estado_turno { get; set; }
    }
}
