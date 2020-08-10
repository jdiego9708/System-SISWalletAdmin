namespace CapaDatos
{
    using CapaEntidades;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    public class DSolicitudes
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
        public DSolicitudes()
        {

        }

        #endregion

        #region METODO INSERTAR
        public string InsertarSolicitud(out int id_solicitud, Solicitudes solicitud)
        {
            id_solicitud = 0;
            int contador = 0;
            string rpta = "";

            string consulta = "INSERT INTO Solicitudes (Id_tipo_solicitud, Fecha_solicitud, Hora_solicitud, " +
                "Asunto_solicitud, Descripcion_solicitud, Estado_solicitud) " +
                "VALUES(@Id_tipo_solicitud, @Fecha_solicitud, @Hora_solicitud, " +
                "@Asunto_solicitud, @Descripcion_solicitud, @Estado_solicitud) " +
                "SET @Id_solicitud = SCOPE_IDENTITY() ";

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

                SqlParameter Id_solicitud = new SqlParameter
                {
                    ParameterName = "@Id_solicitud",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_solicitud);

                SqlParameter Id_tipo_solicitud = new SqlParameter
                {
                    ParameterName = "@Id_tipo_solicitud",
                    SqlDbType = SqlDbType.Int,
                    Value = solicitud.Id_tipo_solicitud
                };
                SqlCmd.Parameters.Add(Id_tipo_solicitud);
                contador += 1;

                SqlParameter Fecha_solicitud = new SqlParameter
                {
                    ParameterName = "@Fecha_solicitud",
                    SqlDbType = SqlDbType.Date,
                    Value = solicitud.Fecha_solicitud,
                };
                SqlCmd.Parameters.Add(Fecha_solicitud);
                contador += 1;

                SqlParameter Hora_solicitud = new SqlParameter
                {
                    ParameterName = "@Hora_solicitud",
                    SqlDbType = SqlDbType.Time,
                    Value = solicitud.Hora_solicitud,
                };
                SqlCmd.Parameters.Add(Hora_solicitud);
                contador += 1;
             
                SqlParameter Asunto_solicitud = new SqlParameter
                {
                    ParameterName = "@Asunto_solicitud",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = solicitud.Asunto_solicitud.Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Asunto_solicitud);
                contador += 1;

                SqlParameter Descripcion_solicitud = new SqlParameter
                {
                    ParameterName = "@Descripcion_solicitud",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150,
                    Value = solicitud.Descripcion_solicitud.Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Descripcion_solicitud);
                contador += 1;

                SqlParameter Estado_solicitud = new SqlParameter
                {
                    ParameterName = "@Estado_solicitud",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = solicitud.Estado_solicitud.Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Estado_solicitud);
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
                    id_solicitud = Convert.ToInt32(SqlCmd.Parameters["@Id_solicitud"].Value);
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
        public string EditarSolicitud(int id_solicitud, Solicitudes solicitud)
        {
            int contador = 0;
            string rpta = "";

            string consulta = "UPDATE Solicitudes SET " +
                "Id_tipo_solicitud = @Id_tipo_solicitud, " +
                "Fecha_solicitud = @Fecha_solicitud, " +
                "Hora_solicitud, = @Hora_solicitud" +
                "Asunto_solicitud = @Asunto_solicitud, " +
                "Descripcion_solicitud = @Descripcion_solicitud, " +
                "Estado_solicitud = @Estado_solicitud " +
                "WHERE Id_solicitud = @Id_solicitud ";

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

                SqlParameter Id_solicitud = new SqlParameter
                {
                    ParameterName = "@Id_solicitud",
                    SqlDbType = SqlDbType.Int,
                    Value = id_solicitud,
                };
                SqlCmd.Parameters.Add(Id_solicitud);

                SqlParameter Id_tipo_solicitud = new SqlParameter
                {
                    ParameterName = "@Id_tipo_solicitud",
                    SqlDbType = SqlDbType.Int,
                    Value = solicitud.Id_tipo_solicitud
                };
                SqlCmd.Parameters.Add(Id_tipo_solicitud);
                contador += 1;

                SqlParameter Fecha_solicitud = new SqlParameter
                {
                    ParameterName = "@Fecha_solicitud",
                    SqlDbType = SqlDbType.Date,
                    Value = solicitud.Fecha_solicitud,
                };
                SqlCmd.Parameters.Add(Fecha_solicitud);
                contador += 1;

                SqlParameter Hora_solicitud = new SqlParameter
                {
                    ParameterName = "@Hora_solicitud",
                    SqlDbType = SqlDbType.Time,
                    Value = solicitud.Hora_solicitud,
                };
                SqlCmd.Parameters.Add(Hora_solicitud);
                contador += 1;

                SqlParameter Asunto_solicitud = new SqlParameter
                {
                    ParameterName = "@Asunto_solicitud",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = solicitud.Asunto_solicitud.Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Asunto_solicitud);
                contador += 1;

                SqlParameter Descripcion_solicitud = new SqlParameter
                {
                    ParameterName = "@Descripcion_solicitud",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150,
                    Value = solicitud.Descripcion_solicitud.Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Descripcion_solicitud);
                contador += 1;

                SqlParameter Estado_solicitud = new SqlParameter
                {
                    ParameterName = "@Estado_solicitud",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = solicitud.Estado_solicitud.Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Estado_solicitud);
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

        #region METODO BUSCAR SOLICITUDES
        public DataTable BuscarSolicitudes(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            rpta = "OK";

            StringBuilder consulta = new StringBuilder();
            consulta.Append("SELECT * " +
                "FROM Solicitudes sol " +
                "INNER JOIN Tipo_solicitudes tp ON sol.Id_tipo_solicitud = tp.Id_tipo_solicitud ");

            if (tipo_busqueda.Equals("ID SOLICITUD"))
            {
                consulta.Append("WHERE sol.Id_solicitud = @Texto_busqueda ");
            }
            else if (tipo_busqueda.Equals("FECHA ACTUAL"))
            {
                consulta.Append("WHERE sol.Fecha_solicitud = '" + texto_busqueda + "'  ");
            }

            consulta.Append("ORDER BY sol.Id_solicitud DESC ");

            DataTable DtResultado = new DataTable("Solicitudes");
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
