namespace CapaDatos
{
    using CapaEntidades;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    public class DTipo_solicitudes
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
        public DTipo_solicitudes()
        {

        }

        #endregion

        #region METODO INSERTAR
        public string InsertarTipoSolicitudes(out int id_tipo_solicitud, Tipo_solicitudes tipo_solicitudes)
        {
            id_tipo_solicitud = 0;
            int contador = 0;
            string rpta = "";

            string consulta = "INSERT INTO Tipo_solicitudes (Nombre_tipo_solicitud, Estado_tipo_solicitud) " +
                "VALUES(@Nombre_tipo_solicitud, @Estado_tipo_solicitud) " +
                "SET @Id_tipo_solicitud = SCOPE_IDENTITY() ";

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

                SqlParameter Id_tipo_solicitud = new SqlParameter
                {
                    ParameterName = "@Id_tipo_solicitud",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_tipo_solicitud);

                SqlParameter Nombre_tipo_solicitud = new SqlParameter
                {
                    ParameterName = "@Nombre_tipo_solicitud",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = tipo_solicitudes.Nombre_tipo_solicitud.Trim().ToUpper(),
                };
                SqlCmd.Parameters.Add(Nombre_tipo_solicitud);
                contador += 1;

                SqlParameter Estado_tipo_solicitud = new SqlParameter
                {
                    ParameterName = "@Estado_tipo_solicitud",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = tipo_solicitudes.Estado_tipo_solicitud.Trim().ToUpper(),
                };
                SqlCmd.Parameters.Add(Estado_tipo_solicitud);
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
                    id_tipo_solicitud = Convert.ToInt32(SqlCmd.Parameters["@Id_tipo_solicitud"].Value);
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
        public string EditarTipoSolicitudes(int id_tipo_solicitud, Tipo_solicitudes tipo_solicitudes)
        {
            int contador = 0;
            string rpta = "";

            string consulta = "UPDATE Tipo_solicitudes SET " +
                "Nombre_tipo_solicitud = @Nombre_tipo_solicitud, " +
                "Estado_tipo_solicitud = @Estado_tipo_solicitud " +
                "WHERE Id_tipo_solicitud = @Id_tipo_solicitud ";

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

                SqlParameter Id_tipo_solicitud = new SqlParameter
                {
                    ParameterName = "@Id_tipo_solicitud",
                    SqlDbType = SqlDbType.Int,
                    Value = id_tipo_solicitud,
                };
                SqlCmd.Parameters.Add(Id_tipo_solicitud);

                SqlParameter Nombre_tipo_solicitud = new SqlParameter
                {
                    ParameterName = "@Nombre_tipo_solicitud",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = tipo_solicitudes.Nombre_tipo_solicitud.Trim().ToUpper(),
                };
                SqlCmd.Parameters.Add(Nombre_tipo_solicitud);
                contador += 1;

                SqlParameter Estado_tipo_solicitud = new SqlParameter
                {
                    ParameterName = "@Estado_tipo_solicitud",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = tipo_solicitudes.Estado_tipo_solicitud.Trim().ToUpper(),
                };
                SqlCmd.Parameters.Add(Estado_tipo_solicitud);
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

        #region METODO BUSCAR TIPOS
        public DataTable BuscarTiposSolicitudes(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            rpta = "OK";

            StringBuilder consulta = new StringBuilder();

            consulta.Append("SELECT * FROM Tipo_solicitudes tp ");

            if (tipo_busqueda.Equals("ID TIPO SOLICITUD"))
            {
                consulta.Append("WHERE tp.Id_tipo_solicitud = @Texto_busqueda ");
            }

            consulta.Append("ORDER BY tp.Id_tipo_solicitud DESC");

            DataTable DtResultado = new DataTable("TiposSolicitud");
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
