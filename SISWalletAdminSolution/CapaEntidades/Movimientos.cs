namespace CapaEntidades
{
    using CapaEntidades.Helpers;
    using System;
    using System.Data;
    using System.Threading.Tasks;

    public class Movimientos
    {
        public Movimientos()
        {

        }

        public Movimientos(DataRow row)
        {
            try
            {
                this.Id_movimiento = Convert.ToInt32(row["Id_movimiento"]);
                this.Tipo_movimiento = Convert.ToString(row["Tipo_movimiento"]);
                this.Id_concepto_articulo = Convert.ToInt32(row["Id_concepto_articulo"]);
                this.Id_usuario = Convert.ToInt32(row["Id_usuario"]);
                this.Usuario = new Usuarios(row);
                this.Fecha_movimiento = Convert.ToDateTime(row["Fecha_movimiento"]);
                this.Hora_movimiento = TimeSpanConvert.StringToTimeSpan(Convert.ToString(row["Hora_movimiento"]));
                this.Cantidad_movimiento = Convert.ToInt32(row["Cantidad_movimiento"]);
                this.Valor_movimiento = Convert.ToDecimal(row["Valor_movimiento"]);
            }
            catch (Exception)
            {

            }
        }

        public int Id_movimiento { get; set; }

        public int Id_concepto_articulo{ get; set; }

        public object ConceptoArticulo { get; set; }

        public int Id_usuario { get; set; }

        public Usuarios Usuario { get; set; }

        public DateTime Fecha_movimiento { get; set; }

        public TimeSpan Hora_movimiento { get; set; }

        public int Cantidad_movimiento { get; set; }

        public decimal Valor_movimiento { get; set; }

        public string Tipo_movimiento { get; set; }    
    }
}
