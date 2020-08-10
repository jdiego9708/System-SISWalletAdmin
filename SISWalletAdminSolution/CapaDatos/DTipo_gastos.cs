namespace CapaDatos
{
    using CapaEntidades;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    public class DTipo_gastos
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
        public DTipo_gastos()
        {

        }

        #endregion

        #region METODO INSERTAR
        public string InsertarTipoGastos(out int id_tipo_gasto, Tipo_gastos gasto)
        {
            id_tipo_gasto = 0;
            int contador = 0;
            string rpta = "";

            string consulta = "INSERT INTO Gastos (Nombre_tipo_gasto, Estado_tipo_gasto) " +
                "VALUES(@Nombre_tipo_gasto, @Estado_tipo_gasto) " +
                "SET @Id_tipo_gasto = SCOPE_IDENTITY() ";

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

                SqlParameter Id_tipo_gasto = new SqlParameter
                {
                    ParameterName = "@Id_tipo_gasto",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_tipo_gasto);

                SqlParameter Nombre_tipo_gasto = new SqlParameter
                {
                    ParameterName = "@Nombre_tipo_gasto",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = gasto.Nombre_tipo_gasto.Trim().ToUpper(),
                };
                SqlCmd.Parameters.Add(Nombre_tipo_gasto);
                contador += 1;

                SqlParameter Estado_tipo_gasto = new SqlParameter
                {
                    ParameterName = "@Estado_tipo_gasto",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = gasto.Estado_tipo_gasto.Trim().ToUpper(),
                };
                SqlCmd.Parameters.Add(Estado_tipo_gasto);
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
                    id_tipo_gasto = Convert.ToInt32(SqlCmd.Parameters["@Id_tipo_gasto"].Value);
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
        public string EditarTipoGastos(int id_tipo_gasto, Tipo_gastos gasto)
        {
            int contador = 0;
            string rpta = "";

            string consulta = "UPDATE Gastos SET " +
                "Nombre_tipo_gasto = @Nombre_tipo_gasto, " +
                "Estado_tipo_gasto = @Estado_tipo_gasto " +
                "WHERE Id_tipo_gasto = @Id_tipo_gasto ";

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

                SqlParameter Id_tipo_gasto = new SqlParameter
                {
                    ParameterName = "@Id_tipo_gasto",
                    SqlDbType = SqlDbType.Int,
                    Value = id_tipo_gasto
                };
                SqlCmd.Parameters.Add(Id_tipo_gasto);

                SqlParameter Nombre_tipo_gasto = new SqlParameter
                {
                    ParameterName = "@Nombre_tipo_gasto",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = gasto.Nombre_tipo_gasto.Trim().ToUpper(),
                };
                SqlCmd.Parameters.Add(Nombre_tipo_gasto);
                contador += 1;

                SqlParameter Estado_tipo_gasto = new SqlParameter
                {
                    ParameterName = "@Estado_tipo_gasto",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = gasto.Estado_tipo_gasto.Trim().ToUpper(),
                };
                SqlCmd.Parameters.Add(Estado_tipo_gasto);
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

        #region METODO BUSCAR GASTOS
        public DataTable BuscarGastos(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            rpta = "OK";

            StringBuilder consulta = new StringBuilder();

            consulta.Append("SELECT * FROM Tipo_gastos tpg ");

            if (tipo_busqueda.Equals("ID GASTO"))
            {
                consulta.Append("WHERE tpg.Id_tipo_gasto = @Texto_busqueda ");
            }

            consulta.Append("ORDER BY tpg.Id_tipo_gasto DESC");

            DataTable DtResultado = new DataTable("TiposGasto");
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
