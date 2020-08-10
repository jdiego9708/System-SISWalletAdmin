namespace CapaEntidades
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Data;

    //using SQLite;

    public class Usuarios
    {
        public Usuarios()
        {

        }

        public Usuarios(DataRow row)
        {
            try
            {
                this.Id_usuario = Convert.ToInt32(row["Id_usuario"]);
                this.Alias = Convert.ToString(row["Alias"]);
                this.Nombres = Convert.ToString(row["Nombres"]);
                this.Apellidos = Convert.ToString(row["Apellidos"]);
                this.Identificacion = Convert.ToString(row["Identificacion"]);
                this.Celular = Convert.ToString(row["Celular"]);
                this.Email = Convert.ToString(row["Email"]);
                this.Tipo_usuario = Convert.ToString(row["Tipo_usuario"]);
                this.Estado_usuario = Convert.ToString(row["Estado_usuario"]);
            }
            catch (Exception)
            {

            }
        }

        public int Id_usuario { get; set; }
        public DateTime Fecha_ingreso { get; set; } = DateTime.Now;
        public string Alias { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Identificacion { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Tipo_usuario { get; set; } = "JEFE";
        public string Estado_usuario { get; set; } = "ACTIVO";

        public string NombreCompleto
        {
            get
            {
                return string.Format("{0} {1}", this.Nombres, this.Apellidos);
            }
        }

        public override string ToString()
        {
            return this.Nombres;
        }
    }
}
