namespace CapaDatos
{
    using CapaEntidades;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;
    using System.Threading.Tasks;

    public class DArticulos
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
        public DArticulos()
        {

        }

        #endregion

        #region METODO INSERTAR
        public async Task<(string rpta, int id_articulo)> InsertarArticulo(Articulos articulo)
        {
            int id_articulo = 0;
            int contador = 0;
            string rpta = "";

            string consulta = "INSERT INTO Articulos (Referencia_articulo, Descripcion_articulo, " +
                "Tipo_cantidad, Cantidad_articulo, Valor_articulo, Estado_articulo) " +
                "VALUES(@Referencia_articulo, @Descripcion_articulo, " +
                "@Tipo_cantidad, @Cantidad_articulo, @Valor_articulo, @Estado_articulo) " +
                "SET @Id_articulo = SCOPE_IDENTITY() ";

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

                SqlParameter Id_articulo = new SqlParameter
                {
                    ParameterName = "@Id_articulo",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_articulo);

                SqlParameter Referencia_articulo = new SqlParameter
                {
                    ParameterName = "@Referencia_articulo",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = articulo.Referencia_articulo.Trim().ToUpper(),
                };
                SqlCmd.Parameters.Add(Referencia_articulo);
                contador += 1;

                SqlParameter Descripcion_articulo = new SqlParameter
                {
                    ParameterName = "@Descripcion_articulo",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = articulo.Descripcion_articulo.Trim().ToUpper(),
                };
                SqlCmd.Parameters.Add(Descripcion_articulo);
                contador += 1;

                SqlParameter Tipo_cantidad = new SqlParameter
                {
                    ParameterName = "@Tipo_cantidad",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = articulo.Tipo_cantidad.Trim(),
                };
                SqlCmd.Parameters.Add(Tipo_cantidad);
                contador += 1;

                SqlParameter Cantidad_articulo = new SqlParameter
                {
                    ParameterName = "@Cantidad_articulo",
                    SqlDbType = SqlDbType.Decimal,
                    Value = articulo.Cantidad_articulo,
                };
                SqlCmd.Parameters.Add(Cantidad_articulo);
                contador += 1;

                SqlParameter Valor_articulo = new SqlParameter
                {
                    ParameterName = "@Valor_articulo",
                    SqlDbType = SqlDbType.Decimal,
                    Value = articulo.Valor_articulo,
                };
                SqlCmd.Parameters.Add(Valor_articulo);
                contador += 1;

                SqlParameter Estado_articulo = new SqlParameter
                {
                    ParameterName = "@Estado_articulo",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = articulo.Estado_articulo.Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Estado_articulo);
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
                    id_articulo = Convert.ToInt32(SqlCmd.Parameters["@Id_articulo"].Value);
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
            return (rpta, id_articulo);
        }
        #endregion

        #region METODO EDITAR
        public async Task<string> EditarArticulo(int id_articulo, Articulos articulo)
        {
            int contador = 0;
            string rpta = "";

            string consulta = "UPDATE Articulos SET " +
                "Referencia_articulo = @Referencia_articulo, " +
                "Descripcion_articulo = @Descripcion_articulo, " +
                 "Tipo_cantidad = @Tipo_cantidad, " +
                 "Cantidad_articulo = @Cantidad_articulo, " +
                 "Valor_articulo = @Valor_articulo, " +
                 "Estado_articulo = @Estado_articulo " +
                 "WHERE Id_articulo = @Id_articulo ";

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

                SqlParameter Id_articulo = new SqlParameter
                {
                    ParameterName = "@Id_articulo",
                    SqlDbType = SqlDbType.Int,
                    Value = id_articulo,
                };
                SqlCmd.Parameters.Add(Id_articulo);

                SqlParameter Referencia_articulo = new SqlParameter
                {
                    ParameterName = "@Referencia_articulo",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = articulo.Referencia_articulo.Trim().ToUpper(),
                };
                SqlCmd.Parameters.Add(Referencia_articulo);
                contador += 1;

                SqlParameter Descripcion_articulo = new SqlParameter
                {
                    ParameterName = "@Descripcion_articulo",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = articulo.Descripcion_articulo.Trim()
                };
                SqlCmd.Parameters.Add(Descripcion_articulo);
                contador += 1;

                SqlParameter Tipo_cantidad = new SqlParameter
                {
                    ParameterName = "@Tipo_cantidad",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = articulo.Tipo_cantidad.Trim(),
                };
                SqlCmd.Parameters.Add(Tipo_cantidad);
                contador += 1;

                SqlParameter Cantidad_articulo = new SqlParameter
                {
                    ParameterName = "@Cantidad_articulo",
                    SqlDbType = SqlDbType.Decimal,
                    Value = articulo.Cantidad_articulo,
                };
                SqlCmd.Parameters.Add(Cantidad_articulo);
                contador += 1;

                SqlParameter Valor_articulo = new SqlParameter
                {
                    ParameterName = "@Valor_articulo",
                    SqlDbType = SqlDbType.Decimal,
                    Value = articulo.Valor_articulo,
                };
                SqlCmd.Parameters.Add(Valor_articulo);
                contador += 1;

                SqlParameter Estado_articulo = new SqlParameter
                {
                    ParameterName = "@Estado_articulo",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = articulo.Estado_articulo.Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Estado_articulo);
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

        #region METODO BUSCAR ARTICULOS
        public async Task<(DataTable dtArticulos, string rpta)> BuscarArticulos(string tipo_busqueda, string texto_busqueda)
        {
            string rpta = "OK";

            StringBuilder consulta = new StringBuilder();

            consulta.Append("SELECT * FROM Articulos art ");

            if (tipo_busqueda.Equals("ID ARTICULO"))
            {
                consulta.Append("WHERE art.Id_articulo = @Texto_busqueda ");
            }

            consulta.Append("ORDER BY art.Id_articulo DESC");

            DataTable DtResultado = new DataTable("Articulos");
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
