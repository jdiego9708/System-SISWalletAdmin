namespace CapaEntidades
{
    using System;
    using System.Data;
    using System.Windows.Input;

    public class Agendamiento_cobros
    {

        public Agendamiento_cobros()
        {

        }

        public Agendamiento_cobros(DataRow row)
        {
            try
            {
                this.Id_agendamiento = Convert.ToInt32(row["Id_agendamiento"]);
                this.Id_venta = Convert.ToInt32(row["Id_venta"]);
                this.Venta = new Ventas(row);
                this.Fecha_cobro = Convert.ToDateTime(row["Fecha_cobro"]);
                this.Valor_cobro = Convert.ToDecimal(row["Valor_cobro"]);
                this.Valor_pagado = Convert.ToDecimal(row["Valor_pagado"]);
                this.Saldo_restante = Convert.ToDecimal(row["Saldo_restante"]);
                this.Tipo_cobro = Convert.ToString(row["Tipo_cobro"]);
                this.Observaciones_cobro = Convert.ToString(row["Observaciones_cobro"]);
                this.Estado_cobro = Convert.ToString(row["Estado_cobro"]);
            }
            catch (Exception)
            {

            }
        }

        public int Id_agendamiento { get; set; }

        public int Id_venta { get; set; }

        public virtual Ventas Venta { get; set; }
        public DateTime Fecha_cobro { get; set; } = DateTime.Now;
        public TimeSpan Hora_cobro { get; set; } = DateTime.Now.TimeOfDay;
        public decimal Valor_cobro { get; set; }
        public decimal Valor_pagado { get; set; }
        public decimal Saldo_restante { get; set; }
        public string Tipo_cobro { get; set; }
        public string Observaciones_cobro { get; set; }
        public string Estado_cobro { get; set; }
    }
}
