namespace CapaDatos
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;
    using CapaEntidades;

    public class DAgendamiento_cobros
    {
        #region MENSAJE
        private void SqlCon_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            this.Mensaje_respuesta = e.Message;
        }
        #endregion

        #region VARIABLES

        string _mensaje_respuesta;

        public string Mensaje_respuesta
        {
            get
            {
                return _mensaje_respuesta;
            }

            set
            {
                _mensaje_respuesta = value;
            }
        }


        #endregion

        #region CONSTRUCTOR
        public DAgendamiento_cobros()
        {

        }

        #endregion

        #region METODO INSERTAR
        public string InsertarAgendamiento(out int id_agendamiento, Agendamiento_cobros agendamiento)
        {
            id_agendamiento = 0;
            int contador = 0;
            string rpta = "";

            string consulta = "INSERT INTO Agendamiento_cobros (Id_venta, Id_turno, Orden_cobro, Fecha_cobro, Hora_cobro, " +
                "Valor_cobro, Valor_pagado, Saldo_restante, Tipo_cobro, Observaciones_cobro, Estado_cobro) " +
                "VALUES(@Id_venta, @Id_turno, @Orden_cobro, @Fecha_cobro, @Hora_cobro, " +
                "@Valor_cobro, @Valor_pagado, @Saldo_restante, @Tipo_cobro, @Observaciones_cobro, @Estado_cobro) " +
                "SET @Id_agendamiento = SCOPE_IDENTITY() ";

            SqlConnection SqlCon = new SqlConnection();
            SqlCon.InfoMessage += new SqlInfoMessageEventHandler(SqlCon_InfoMessage);
            SqlCon.FireInfoMessageEventOnUserErrors = true;
            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = consulta,
                    CommandType = CommandType.Text
                };

                SqlParameter Id_agendamiento = new SqlParameter
                {
                    ParameterName = "@Id_agendamiento",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_agendamiento);

                SqlParameter Id_venta = new SqlParameter
                {
                    ParameterName = "@Id_venta",
                    SqlDbType = SqlDbType.Int,
                    Value = agendamiento.Id_venta
                };
                SqlCmd.Parameters.Add(Id_venta);
                contador += 1;

                SqlParameter Id_turno = new SqlParameter
                {
                    ParameterName = "@Id_turno",
                    SqlDbType = SqlDbType.Int,
                    Value = agendamiento.Id_turno
                };
                SqlCmd.Parameters.Add(Id_turno);
                contador += 1;

                SqlParameter Orden_cobro = new SqlParameter
                {
                    ParameterName = "@Orden_cobro",
                    SqlDbType = SqlDbType.Int,
                    Value = agendamiento.Orden_cobro,
                };
                SqlCmd.Parameters.Add(Orden_cobro);
                contador += 1;

                SqlParameter Fecha_cobro = new SqlParameter
                {
                    ParameterName = "@Fecha_cobro",
                    SqlDbType = SqlDbType.Date,
                    Value = agendamiento.Fecha_cobro,
                };
                SqlCmd.Parameters.Add(Fecha_cobro);
                contador += 1;

                SqlParameter Hora_cobro = new SqlParameter
                {
                    ParameterName = "@Hora_cobro",
                    SqlDbType = SqlDbType.Time,
                    Value = agendamiento.Hora_cobro,
                };
                SqlCmd.Parameters.Add(Hora_cobro);
                contador += 1;

                SqlParameter Valor_cobro = new SqlParameter
                {
                    ParameterName = "@Valor_cobro",
                    SqlDbType = SqlDbType.Decimal,
                    Value = agendamiento.Valor_cobro,
                };
                SqlCmd.Parameters.Add(Valor_cobro);
                contador += 1;

                SqlParameter Valor_pagado = new SqlParameter
                {
                    ParameterName = "@Valor_pagado",
                    SqlDbType = SqlDbType.Decimal,
                    Value = agendamiento.Valor_pagado,
                };
                SqlCmd.Parameters.Add(Valor_pagado);
                contador += 1;

                SqlParameter Saldo_restante = new SqlParameter
                {
                    ParameterName = "@Saldo_restante",
                    SqlDbType = SqlDbType.Decimal,
                    Value = agendamiento.Saldo_restante,
                };
                SqlCmd.Parameters.Add(Saldo_restante);
                contador += 1;

                SqlParameter Tipo_cobro = new SqlParameter
                {
                    ParameterName = "@Tipo_cobro",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = agendamiento.Tipo_cobro.Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Tipo_cobro);
                contador += 1;

                SqlParameter Observaciones_cobro = new SqlParameter
                {
                    ParameterName = "@Observaciones_cobro",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150,
                    Value = agendamiento.Observaciones_cobro.Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Observaciones_cobro);
                contador += 1;

                SqlParameter Estado_cobro = new SqlParameter
                {
                    ParameterName = "@Estado_cobro",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = agendamiento.Estado_cobro.Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Estado_cobro);
                contador += 1;

                //Ejecutamos nuestro comando
                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "NO SE INGRESÓ";
                if (!rpta.Equals("OK"))
                {
                    if (this.Mensaje_respuesta != null)
                    {
                        rpta = this.Mensaje_respuesta;
                    }
                }
                else
                {
                    id_agendamiento = Convert.ToInt32(SqlCmd.Parameters["@Id_agendamiento"].Value);
                }
            }
            //Mostramos posible error que tengamos
            catch (SqlException ex)
            {
                rpta = ex.Message;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                //Si la cadena SqlCon esta abierta la cerramos
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }
            return rpta;
        }
        #endregion

        #region METODO EDITAR
        public string EditarAgendamiento(int id_agendamiento, Agendamiento_cobros agendamiento)
        {
            int contador = 0;
            string rpta = "";

            string consulta = "UPDATE Agendamiento_cobros SET " +
                "Id_venta = @Id_venta, " +
                "Fecha_cobro = @Fecha_cobro, " +
                "Hora_cobro = @Hora_cobro, " +
                "Valor_cobro = @Valor_cobro, " +
                "Valor_pagado = @Valor_pagado, " +
                "Saldo_restante = @Saldo_restante, " +
                "Tipo_cobro = @Tipo_cobro, " +
                "Observaciones_cobro = Observaciones_cobro, " +
                "Estado_cobro = @Estado_cobro " +
                "WHERE Id_agendamiento = @Id_agendamiento ";

            SqlConnection SqlCon = new SqlConnection();
            SqlCon.InfoMessage += new SqlInfoMessageEventHandler(SqlCon_InfoMessage);
            SqlCon.FireInfoMessageEventOnUserErrors = true;
            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = consulta,
                    CommandType = CommandType.Text
                };

                SqlParameter Id_agendamiento = new SqlParameter
                {
                    ParameterName = "@Id_agendamiento",
                    SqlDbType = SqlDbType.Int,
                    Value = id_agendamiento,
                };
                SqlCmd.Parameters.Add(Id_agendamiento);

                SqlParameter Id_venta = new SqlParameter
                {
                    ParameterName = "@Id_venta",
                    SqlDbType = SqlDbType.Int,
                    Value = agendamiento.Id_venta,
                };
                SqlCmd.Parameters.Add(Id_venta);
                contador += 1;

                SqlParameter Fecha_cobro = new SqlParameter
                {
                    ParameterName = "@Fecha_cobro",
                    SqlDbType = SqlDbType.Date,
                    Value = agendamiento.Fecha_cobro,
                };
                SqlCmd.Parameters.Add(Fecha_cobro);
                contador += 1;

                SqlParameter Hora_cobro = new SqlParameter
                {
                    ParameterName = "@Hora_cobro",
                    SqlDbType = SqlDbType.Time,
                    Value = agendamiento.Hora_cobro,
                };
                SqlCmd.Parameters.Add(Hora_cobro);
                contador += 1;

                SqlParameter Valor_cobro = new SqlParameter
                {
                    ParameterName = "@Valor_cobro",
                    SqlDbType = SqlDbType.Decimal,
                    Value = agendamiento.Valor_cobro,
                };
                SqlCmd.Parameters.Add(Valor_cobro);
                contador += 1;

                SqlParameter Valor_pagado = new SqlParameter
                {
                    ParameterName = "@Valor_pagado",
                    SqlDbType = SqlDbType.Decimal,
                    Value = agendamiento.Valor_pagado,
                };
                SqlCmd.Parameters.Add(Valor_pagado);
                contador += 1;

                SqlParameter Saldo_restante = new SqlParameter
                {
                    ParameterName = "@Saldo_restante",
                    SqlDbType = SqlDbType.Decimal,
                    Value = agendamiento.Saldo_restante,
                };
                SqlCmd.Parameters.Add(Saldo_restante);
                contador += 1;

                SqlParameter Tipo_cobro = new SqlParameter
                {
                    ParameterName = "@Tipo_cobro",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = agendamiento.Tipo_cobro.Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Tipo_cobro);
                contador += 1;

                SqlParameter Observaciones_cobro = new SqlParameter
                {
                    ParameterName = "@Observaciones_cobro",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150,
                    Value = agendamiento.Observaciones_cobro.Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Observaciones_cobro);
                contador += 1;

                SqlParameter Estado_cobro = new SqlParameter
                {
                    ParameterName = "@Estado_cobro",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = agendamiento.Estado_cobro.Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Estado_cobro);
                contador += 1;

                //Ejecutamos nuestro comando
                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "NO SE INGRESÓ";
                if (!rpta.Equals("OK"))
                {
                    if (this.Mensaje_respuesta != null)
                    {
                        rpta = this.Mensaje_respuesta;
                    }
                }
            }
            //Mostramos posible error que tengamos
            catch (SqlException ex)
            {
                rpta = ex.Message;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                //Si la cadena SqlCon esta abierta la cerramos
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }
            return rpta;
        }
        #endregion

        #region METODO BUSCAR AGENDAMIENTOS
        public DataTable BuscarAgendamiento(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            rpta = "OK";

            StringBuilder consulta = new StringBuilder();
            consulta.Append("SELECT ag.*, ve.*, tppr.*, us.*, drcl.*, " +
                "uss.Id_usuario as Id_cobrador, " +
                "uss.Fecha_ingreso as Fecha_ingreso_sobrador, " +
                "uss.Nombres as Nombre_cobrador, " +
                "uss.Apellidos as Apellidos_cobrador, " +
                "uss.Identificacion as Identificacion_cobrador, " +
                "uss.Email as Email_cobrador, " +
                "uss.Tipo_usuario as Tipo_cobrador, " +
                "uss.Estado_usuario as Estado_cobrador, " +
                "tu.* " +
                "FROM Agendamiento_cobros ag " +
                "INNER JOIN Ventas ve ON ve.Id_venta = ag.Id_venta " +
                "INNER JOIN Tipo_productos tppr ON ve.Id_tipo_producto = tppr.Id_tipo_producto " +
                "INNER JOIN Usuarios us ON ve.Id_cliente = us.Id_usuario " +
                "INNER JOIN Direccion_clientes drcl ON ve.Id_direccion = drcl.Id_direccion " +
                "INNER JOIN Usuarios_ventas usve ON ve.Id_venta = usve.Id_venta " +
                "INNER JOIN Usuarios uss ON usve.Id_usuario = uss.Id_usuario " +
                "INNER JOIN Turnos tu ON ag.Id_turno = tu.Id_turno ");

            if (tipo_busqueda.Equals("ID VENTA"))
            {
                consulta.Append("WHERE ve.Id_venta = @Texto_busqueda ");
            }
            else if (tipo_busqueda.Equals("FECHA ACTUAL"))
            {
                consulta.Append("WHERE ag.Fecha_cobro = '" + texto_busqueda + "'  ");
            }
            else if (tipo_busqueda.Equals("ID COBRADOR Y FECHA ACTUAL"))
            {
                consulta.Append("WHERE ag.Fecha_cobro = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and " +
                    "usve.Id_usuario = " + texto_busqueda + " ");
            }

            consulta.Append("ORDER BY ag.Id_agendamiento DESC ");

            DataTable DtResultado = new DataTable("Agendamientos");
            SqlConnection SqlCon = new SqlConnection();
            SqlCon.InfoMessage += new SqlInfoMessageEventHandler(SqlCon_InfoMessage);
            SqlCon.FireInfoMessageEventOnUserErrors = true;
            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCommand Sqlcmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = consulta.ToString(),
                    CommandType = CommandType.Text
                };

                SqlParameter Texto_busqueda = new SqlParameter
                {
                    ParameterName = "@Texto_busqueda",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = texto_busqueda.Trim()
                };
                Sqlcmd.Parameters.Add(Texto_busqueda);

                SqlDataAdapter SqlData = new SqlDataAdapter(Sqlcmd);
                SqlData.Fill(DtResultado);

                if (DtResultado.Rows.Count < 1)
                {
                    DtResultado = null;
                }
            }
            catch (SqlException ex)
            {
                rpta = ex.Message;
                DtResultado = null;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
                DtResultado = null;
            }
            return DtResultado;
        }
        #endregion
    }
}
