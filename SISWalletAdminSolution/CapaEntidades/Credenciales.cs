namespace CapaEntidades
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class Credenciales
    {
        public Credenciales()
        {

        }

        public Credenciales(DataRow row)
        {
            try
            {
                this.Id_credencial = Convert.ToInt32(row["Id_credencial"]);
                this.Id_usuario = Convert.ToInt32(row["Id_usuario"]);
                this.Usuario = new Usuarios(row);
                this.Fecha_credencial = Convert.ToDateTime(row["Fecha_credencial"]);
                this.Hora_credencial = TimeSpanConvert.StringToTimeSpan(row["Hora_credencial"].ToString());
                this.Password = Convert.ToString(row["Password"]);
                this.Estado_credencial = Convert.ToString(row["Estado_credencial"]);

            }
            catch (Exception ex)
            {

            }
        }

        public int Id_credencial { get; set; }

        public int Id_usuario { get; set; }
        public virtual Usuarios Usuario { get; set; }
        public DateTime Fecha_credencial { get; set; } = DateTime.Now;
        public TimeSpan Hora_credencial { get; set; } = DateTime.Now.TimeOfDay;
        public string Password { get; set; }
        public string Estado_credencial { get; set; }
    }
}
