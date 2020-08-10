namespace CapaDatos
{
    using CapaEntidades;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    public class DZonas
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
        public DZonas()
        {

        }

        #endregion

        #region METODO INSERTAR
        public string InsertarZona(out int id_zona, Zonas zona)
        {
            id_zona = 0;
            int contador = 0;
            string rpta = "";

            string consulta = "INSERT INTO Zonas (Id_ciudad, Nombre_zona, Observaciones_zona, Estado_zona) " +
                "VALUES(@Id_ciudad, @Nombre_zona, @Observaciones_zona, @Estado_zona) " +
                "SET @Id_zona = SCOPE_IDENTITY() ";

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

                SqlParameter Id_zona = new SqlParameter
                {
                    ParameterName = "@Id_zona",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_zona);

                SqlParameter Id_ciudad = new SqlParameter
                {
                    ParameterName = "@Id_ciudad",
                    SqlDbType = SqlDbType.Int,
                    Value = zona.Id_ciudad
                };
                SqlCmd.Parameters.Add(Id_ciudad);
                contador += 1;

                SqlParameter Nombre_zona = new SqlParameter
                {
                    ParameterName = "@Nombre_zona",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = zona.Nombre_zona.Trim()
                };
                SqlCmd.Parameters.Add(Nombre_zona);
                contador += 1;

                SqlParameter Observaciones_zona = new SqlParameter
                {
                    ParameterName = "@Observaciones_zona",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150,
                    Value = zona.Observaciones_zona.Trim()
                };
                SqlCmd.Parameters.Add(Observaciones_zona);
                contador += 1;

                SqlParameter Estado_zona = new SqlParameter
                {
                    ParameterName = "@Estado_zona",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = zona.Estado_zona.Trim()
                };
                SqlCmd.Parameters.Add(Estado_zona);
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
                    id_zona = Convert.ToInt32(SqlCmd.Parameters["@Id_zona"].Value);
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
        public string EditarZona(int id_zona, Zonas zona)
        {
            int contador = 0;
            string rpta = "";

            string consulta = "UPDATE Zonas SET " +
                "Id_ciudad = @Id_ciudad, " +
                "Nombre_zona = @Nombre_zona, " +
                "Observaciones_zona = @Observaciones_zona, " +
                "Estado_zona = @Estado_zona " +
                "WHERE Id_zona = @Id_zona ";

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

                SqlParameter Id_zona = new SqlParameter
                {
                    ParameterName = "@Id_zona",
                    SqlDbType = SqlDbType.Int,
                    Value = id_zona,
                };
                SqlCmd.Parameters.Add(Id_zona);

                SqlParameter Id_ciudad = new SqlParameter
                {
                    ParameterName = "@Id_ciudad",
                    SqlDbType = SqlDbType.Int,
                    Value = zona.Id_ciudad
                };
                SqlCmd.Parameters.Add(Id_ciudad);
                contador += 1;

                SqlParameter Nombre_zona = new SqlParameter
                {
                    ParameterName = "@Nombre_zona",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = zona.Nombre_zona.Trim()
                };
                SqlCmd.Parameters.Add(Nombre_zona);
                contador += 1;

                SqlParameter Observaciones_zona = new SqlParameter
                {
                    ParameterName = "@Observaciones_zona",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150,
                    Value = zona.Observaciones_zona.Trim()
                };
                SqlCmd.Parameters.Add(Observaciones_zona);
                contador += 1;

                SqlParameter Estado_zona = new SqlParameter
                {
                    ParameterName = "@Estado_zona",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = zona.Estado_zona.Trim()
                };
                SqlCmd.Parameters.Add(Estado_zona);
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

        #region METODO BUSCAR ZONAS
        public DataTable BuscarZonas(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            rpta = "OK";

            StringBuilder consulta = new StringBuilder();

            consulta.Append("SELECT * FROM Zonas zo " +
                "INNER JOIN Ciudades cd ON zo.Id_ciudad = cd.Id_ciudad ");

            if (tipo_busqueda.Equals("ID CIUDAD"))
            {
                consulta.Append("WHERE zo.Id_ciudad = @Texto_busqueda ");
            }
            else if (tipo_busqueda.Equals("ID ZONA"))
            {
                consulta.Append("WHERE zo.Id_zona = @Texto_busqueda ");
            }

            consulta.Append("ORDER BY zo.Id_zona DESC");

            DataTable DtResultado = new DataTable("Zonas");
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
