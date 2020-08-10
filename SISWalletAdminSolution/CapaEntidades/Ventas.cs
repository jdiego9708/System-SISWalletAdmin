namespace CapaEntidades
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class Ventas
    {
        public Ventas()
        {

        }

        public Ventas(DataRow row)
        {
            try
            {
                this.Id_venta = Convert.ToInt32(row["Id_venta"]);
                this.Id_cobro = Convert.ToInt32(row["Id_cobro"]);
                this.Cobro = new Cobros(row);
                this.Id_tipo_producto = Convert.ToInt32(row["Id_tipo_producto"]);
                this.Tipo_producto = new Tipo_productos(row);
                this.Id_cliente = Convert.ToInt32(row["Id_usuario"]);
                this.Cliente = new Usuarios(row);
                this.Id_direccion = Convert.ToInt32(row["Id_direccion"]);
                this.Direccion = new Direccion_clientes(row);
                this.Id_turno = Convert.ToInt32(row["Id_turno"]);
                this.Turno = new Turnos(row);
                this.Fecha_venta = Convert.ToDateTime(row["Fecha_venta"]);
                this.Hora_venta = TimeSpanConvert.StringToTimeSpan(row["Hora_venta"].ToString());
                this.Valor_venta = Convert.ToDecimal(row["Valor_venta"]);
                this.Interes_venta = Convert.ToDecimal(row["Interes_venta"]);
                this.Total_venta = Convert.ToDecimal(row["Total_venta"]);
                this.Numero_cuotas = Convert.ToInt32(row["Numero_cuotas"]);
                this.Frecuencia_cobro = Convert.ToString(row["Frecuencia_cobro"]);
                this.Valor_cuota = Convert.ToDecimal(row["Valor_cuota"]);
                this.Estado_venta = Convert.ToString(row["Estado_venta"]);
                this.Tipo_venta = Convert.ToString(row["Tipo_venta"]);

            }
            catch (Exception ex)
            {

            }
        }

        public int Id_venta { get; set; }
        public int Id_cobro { get; set; }
        public virtual Cobros Cobro { get; set; }
        public int Id_tipo_producto { get; set; }
        public virtual Tipo_productos Tipo_producto { get; set; }
        public int Id_cliente { get; set; }
        public virtual Usuarios Cliente { get; set; }
        public int Id_direccion { get; set; }
        public virtual Direccion_clientes Direccion { get; set; }
        public int Id_turno { get; set; }
        public virtual Turnos Turno { get; set; }
        public DateTime Fecha_venta { get; set; } = DateTime.Now;
        public TimeSpan Hora_venta { get; set; } = DateTime.Now.TimeOfDay;
        public decimal Valor_venta { get; set; }
        public decimal Interes_venta { get; set; }
        public decimal Total_venta { get; set; }
        public int Numero_cuotas { get; set; }
        public string Frecuencia_cobro { get; set; }
        public decimal Valor_cuota { get; set; }
        public string Estado_venta { get; set; }
        public string Tipo_venta { get; set; }
    }
}
