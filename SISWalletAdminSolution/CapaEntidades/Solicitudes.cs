namespace CapaEntidades
{
    using System;
    using System.Data;
    using System.Windows.Input;

    public class Solicitudes
    {
        public Solicitudes()
        {

        }

        public Solicitudes(DataRow row)
        {
            try
            {
                this.Id_solicitud = Convert.ToInt32(row["Id_solicitud"]);
                this.Id_tipo_solicitud = Convert.ToInt32(row["Id_tipo_solicitud"]);
                this.Tipo_solicitud = new Tipo_solicitudes(row);
                this.Fecha_solicitud = Convert.ToDateTime(row["Fecha_solicitud"]);
                this.Hora_solicitud = TimeSpanConvert.StringToTimeSpan((row["Hora_solicitud"]).ToString());
                this.Asunto_solicitud = Convert.ToString(row["Asunto_solicitud"]);
                this.Descripcion_solicitud = Convert.ToString(row["Descripcion_solicitud"]);
                this.Estado_solicitud = Convert.ToString(row["Estado_solicitud"]);
            }
            catch (Exception)
            {

            }
        }
        public int Id_solicitud { get; set; }

        public int Id_tipo_solicitud { get; set; }

        public virtual Tipo_solicitudes Tipo_solicitud { get; set; }
        public DateTime Fecha_solicitud { get; set; } = DateTime.Now;
        public TimeSpan Hora_solicitud { get; set; } = DateTime.Now.TimeOfDay;
        public string Asunto_solicitud { get; set; }
        public string Descripcion_solicitud { get; set; }
        public string Estado_solicitud { get; set; }
    }
}
