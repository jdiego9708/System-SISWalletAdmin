namespace CapaDatos
{
    using CapaEntidades;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    public class DCiudades
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
        public DCiudades()
        {

        }

        #endregion

        #region METODO INSERTAR
        public string InsertarCiudad(out int id_ciudad, Ciudades ciudad)
        {
            id_ciudad = 0;
            int contador = 0;
            string rpta = "";

            string consulta = "INSERT INTO Ciudades (Id_pais, Nombre_ciudad, Observaciones_ciudad, Estado_ciudad) " +
                "VALUES(@Id_pais, @Nombre_ciudad, @Observaciones_ciudad, @Estado_ciudad) " +
                "SET @Id_ciudad = SCOPE_IDENTITY() ";

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

                SqlParameter Id_ciudad = new SqlParameter
                {
                    ParameterName = "@Id_ciudad",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_ciudad);

                SqlParameter Id_pais = new SqlParameter
                {
                    ParameterName = "@Id_pais",
                    SqlDbType = SqlDbType.Int,
                    Value = ciudad.Id_pais
                };
                SqlCmd.Parameters.Add(Id_pais);
                contador += 1;

                SqlParameter Nombre_ciudad = new SqlParameter
                {
                    ParameterName = "@Nombre_ciudad",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = ciudad.Nombre_ciudad.Trim()
                };
                SqlCmd.Parameters.Add(Nombre_ciudad);
                contador += 1;

                SqlParameter Observaciones_ciudad = new SqlParameter
                {
                    ParameterName = "@Observaciones_ciudad",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = ciudad.Observaciones_ciudad.Trim()
                };
                SqlCmd.Parameters.Add(Observaciones_ciudad);
                contador += 1;

                SqlParameter Estado_ciudad = new SqlParameter
                {
                    ParameterName = "@Estado_ciudad",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = ciudad.Estado_ciudad.Trim()
                };
                SqlCmd.Parameters.Add(Estado_ciudad);
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
                    id_ciudad = Convert.ToInt32(SqlCmd.Parameters["@Id_ciudad"].Value);
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
        public string EditarCiudad(int id_ciudad, Ciudades ciudad)
        {
            int contador = 0;
            string rpta = "";

            string consulta = "UPDATE Ciudades SET " +
                "Id_pais = @Id_pais, " +
                "Nombre_ciudad = @Nombre_ciudad, " +
                "Observaciones_ciudad = @Observaciones_ciudad, " +
                "Estado_ciudad = @Estado_ciudad " +
                "WHERE Id_ciudad = @Id_ciudad ";

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

                SqlParameter Id_ciudad = new SqlParameter
                {
                    ParameterName = "@Id_ciudad",
                    SqlDbType = SqlDbType.Int,
                    Value = id_ciudad,
                };
                SqlCmd.Parameters.Add(Id_ciudad);

                SqlParameter Id_pais = new SqlParameter
                {
                    ParameterName = "@Id_pais",
                    SqlDbType = SqlDbType.Int,
                    Value = ciudad.Id_pais
                };
                SqlCmd.Parameters.Add(Id_pais);
                contador += 1;

                SqlParameter Nombre_ciudad = new SqlParameter
                {
                    ParameterName = "@Nombre_ciudad",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = ciudad.Nombre_ciudad.Trim()
                };
                SqlCmd.Parameters.Add(Nombre_ciudad);
                contador += 1;

                SqlParameter Observaciones_ciudad = new SqlParameter
                {
                    ParameterName = "@Observaciones_ciudad",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = ciudad.Observaciones_ciudad.Trim()
                };
                SqlCmd.Parameters.Add(Observaciones_ciudad);
                contador += 1;

                SqlParameter Estado_ciudad = new SqlParameter
                {
                    ParameterName = "@Estado_ciudad",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = ciudad.Estado_ciudad.Trim()
                };
                SqlCmd.Parameters.Add(Estado_ciudad);
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

        #region METODO BUSCAR CIUDADES
        public DataTable BuscarCiudades(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            rpta = "OK";

            StringBuilder consulta = new StringBuilder();

            consulta.Append("SELECT * " +
                "FROM Ciudades cd " +
                "INNER JOIN Paises pa ON cd.Id_pais = pa.Id_pais ");

            if (tipo_busqueda.Equals("ID CIUDAD"))
            {
                consulta.Append("WHERE cd.Id_ciudad = @Texto_busqueda ");
            }
            else if (tipo_busqueda.Equals("ID PAIS"))
            {
                consulta.Append("WHERE cd.Id_pais = @Texto_busqueda ");
            }

            consulta.Append("ORDER BY cd.Id_ciudad DESC");

            DataTable DtResultado = new DataTable("Ciudades");
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
