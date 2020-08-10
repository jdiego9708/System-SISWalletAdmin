﻿namespace CapaEntidades
{
    using System;
    using System.Data;

    public class Usuarios_ventas
    {
        public Usuarios_ventas()
        {

        }

        public Usuarios_ventas(DataRow row)
        {
            try
            {
                this.Id_usuario = Convert.ToInt32(row["Id_usuario"]);
                this.Usuario = new Usuarios(row);
                this.Id_venta = Convert.ToInt32(row["Id_venta"]);
                this.Venta = new Ventas(row);
            }
            catch (Exception)
            {

            }
        }

        public int Id_venta { get; set; }

        public int Id_usuario { get; set; }

        public virtual Usuarios Usuario { get; set; }

        public virtual Ventas Venta { get; set; }
    }
}
