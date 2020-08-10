namespace CapaEntidades
{
    using System;
    using System.Data;
    using System.Windows.Input;

    public class Agendamiento_cobros
    {
       
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
