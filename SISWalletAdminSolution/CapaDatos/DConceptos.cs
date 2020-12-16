namespace CapaDatos
{
    using CapaEntidades;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;
    using System.Threading.Tasks;

    public class DConceptos
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
        public DConceptos()
        {

        }

        #endregion

        #region METODO INSERTAR
        public async Task<(string rpta, int id_concepto)> InsertarConcepto(Conceptos concepto)
        {
            int id_concepto = 0;
            int contador = 0;
            string rpta = "";

            string consulta = "INSERT INTO Conceptos (Concepto, Estado_concepto) " +
                "VALUES(@Concepto, @Estado_concepto) " +
                "SET @Id_concepto = SCOPE_IDENTITY() ";

            SqlConnection SqlCon = new SqlConnection();
            SqlCon.InfoMessage += new SqlInfoMessageEventHandler(SqlCon_InfoMessage);
            SqlCon.FireInfoMessageEventOnUserErrors = true;
            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                await SqlCon.OpenAsync();
                SqlTransaction tran = SqlCon.BeginTransaction();
                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = consulta,
                    CommandType = CommandType.Text,
                    Transaction = tran,
                };

                SqlParameter Id_concepto = new SqlParameter
                {
                    ParameterName = "@Id_concepto",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_concepto);

                SqlParameter Concepto = new SqlParameter
                {
                    ParameterName = "@Concepto",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 200,
                    Value = concepto.Concepto.Trim().ToUpper(),
                };
                SqlCmd.Parameters.Add(Concepto);
                contador += 1;

                SqlParameter Estado_concepto = new SqlParameter
                {
                    ParameterName = "@Estado_concepto",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = concepto.Estado_concepto.Trim().ToUpper(),
                };
                SqlCmd.Parameters.Add(Estado_concepto);
                contador += 1;
              
                try
                {
                    //Ejecutamos nuestro comando
                    rpta = await SqlCmd.ExecuteNonQueryAsync() >= 1 ? "OK" : "NO SE INGRESÓ";
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    rpta = ex.Message;
                    tran.Rollback();
                }
                tran.Dispose();

                if (!rpta.Equals("OK"))
                {
                    if (this.Mensaje_respuesta != null)
                    {
                        rpta = this.Mensaje_respuesta;
                    }
                }
                else
                {
                    id_concepto = Convert.ToInt32(SqlCmd.Parameters["@Id_concepto"].Value);
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
            return (rpta, id_concepto);
        }
        #endregion

        #region METODO EDITAR
        public async Task<string> EditarConcepto(int id_concepto, Conceptos concepto)
        {
            int contador = 0;
            string rpta = "";

            string consulta = "UPDATE Conceptos SET " +
                "Concepto = @Concepto, " +
                "Estado_concepto = @Estado_concepto " +
                 "WHERE Id_concepto = @Id_concepto ";

            SqlConnection SqlCon = new SqlConnection();
            SqlCon.InfoMessage += new SqlInfoMessageEventHandler(SqlCon_InfoMessage);
            SqlCon.FireInfoMessageEventOnUserErrors = true;
            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                await SqlCon.OpenAsync();
                SqlTransaction tran = SqlCon.BeginTransaction();
                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = consulta,
                    CommandType = CommandType.Text,
                    Transaction = tran,
                };

                SqlParameter Id_concepto = new SqlParameter
                {
                    ParameterName = "@Id_concepto",
                    SqlDbType = SqlDbType.Int,
                    Value = id_concepto,
                };
                SqlCmd.Parameters.Add(Id_concepto);

                SqlParameter Concepto = new SqlParameter
                {
                    ParameterName = "@Concepto",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 200,
                    Value = concepto.Concepto.Trim().ToUpper(),
                };
                SqlCmd.Parameters.Add(Concepto);
                contador += 1;

                SqlParameter Estado_concepto = new SqlParameter
                {
                    ParameterName = "@Estado_concepto",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = concepto.Estado_concepto.Trim()
                };
                SqlCmd.Parameters.Add(Estado_concepto);
                contador += 1;
               
                try
                {
                    rpta = await SqlCmd.ExecuteNonQueryAsync() >= 1 ? "OK" : "NO SE INGRESÓ";
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    rpta = ex.Message;
                    tran.Rollback();
                }
                tran.Dispose();

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

        #region METODO BUSCAR CONCEPTOS
        public async Task<(DataTable dtConcepto, string rpta)> BuscarConceptos(string tipo_busqueda, string texto_busqueda)
        {
            string rpta = "OK";

            StringBuilder consulta = new StringBuilder();

            consulta.Append("SELECT * FROM Conceptos con ");

            if (tipo_busqueda.Equals("ID CONCEPTO"))
            {
                consulta.Append("WHERE con.Id_concepto = @Texto_busqueda ");
            }

            consulta.Append("ORDER BY con.Id_concepto DESC");

            DataTable DtResultado = new DataTable("Conceptos");
            SqlConnection SqlCon = new SqlConnection();
            SqlCon.InfoMessage += new SqlInfoMessageEventHandler(SqlCon_InfoMessage);
            SqlCon.FireInfoMessageEventOnUserErrors = true;
            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                await SqlCon.OpenAsync();
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
            return (DtResultado, rpta);
        }
        #endregion
    }
}
