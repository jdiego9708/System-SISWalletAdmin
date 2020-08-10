namespace CapaDatos
{
    using CapaEntidades;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    public class DPaises
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
        public DPaises()
        {

        }

        #endregion

        #region METODO INSERTAR
        public string InsertarPais(out int id_pais, Paises pais)
        {
            id_pais = 0;
            int contador = 0;
            string rpta = "";

            string consulta = "INSERT INTO Paises (Nombre_pais, Observaciones_pais, Estado_pais) " +
                "VALUES(@Nombre_pais, @Observaciones_pais, @Estado_pais) " +
                "SET @Id_pais = SCOPE_IDENTITY() ";

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

                SqlParameter Id_pais = new SqlParameter
                {
                    ParameterName = "@Id_pais",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_pais);

                SqlParameter Nombre_pais = new SqlParameter
                {
                    ParameterName = "@Nombre_pais",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = pais.Nombre_pais.Trim()
                };
                SqlCmd.Parameters.Add(Nombre_pais);
                contador += 1;

                SqlParameter Observaciones_pais = new SqlParameter
                {
                    ParameterName = "@Observaciones_pais",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = pais.Observaciones_pais.Trim()
                };
                SqlCmd.Parameters.Add(Observaciones_pais);
                contador += 1;

                SqlParameter Estado_pais = new SqlParameter
                {
                    ParameterName = "@Estado_pais",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = pais.Estado_pais.Trim()
                };
                SqlCmd.Parameters.Add(Estado_pais);
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
                    id_pais = Convert.ToInt32(SqlCmd.Parameters["@Id_pais"].Value);
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
        public string EditarPais(int id_pais, Paises pais)
        {
            int contador = 0;
            string rpta = "";

            string consulta = "UPDATE Paises SET " +
                "Nombre_pais = @Nombre_pais, " +
                "Observaciones_pais = @Observaciones_pais, " +
                "Estado_pais = @Estado_pais " +
                "WHERE Id_pais = @Id_pais ";

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

                SqlParameter Id_pais = new SqlParameter
                {
                    ParameterName = "@Id_pais",
                    SqlDbType = SqlDbType.Int,
                    Value = id_pais,
                };
                SqlCmd.Parameters.Add(Id_pais);

                SqlParameter Nombre_pais = new SqlParameter
                {
                    ParameterName = "@Nombre_pais",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = pais.Nombre_pais.Trim()
                };
                SqlCmd.Parameters.Add(Nombre_pais);
                contador += 1;

                SqlParameter Observaciones_pais = new SqlParameter
                {
                    ParameterName = "@Observaciones_pais",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = pais.Observaciones_pais.Trim()
                };
                SqlCmd.Parameters.Add(Observaciones_pais);
                contador += 1;

                SqlParameter Estado_pais = new SqlParameter
                {
                    ParameterName = "@Estado_pais",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = pais.Estado_pais.Trim()
                };
                SqlCmd.Parameters.Add(Estado_pais);
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

        #region METODO BUSCAR PAISES
        public DataTable BuscarPaises(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            rpta = "OK";

            StringBuilder consulta = new StringBuilder();

            consulta.Append("SELECT * FROM Paises pa ");

            if (tipo_busqueda.Equals("ID PAIS"))
            {
                consulta.Append("WHERE pa.Id_pais = @Texto_busqueda ");
            }          

            consulta.Append("ORDER BY pa.Id_pais DESC");

            DataTable DtResultado = new DataTable("Paises");
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
