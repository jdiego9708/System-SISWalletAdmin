namespace CapaDatos
{
    using CapaEntidades;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;
    using System.Threading.Tasks;

    public class DMovimientos
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
        public DMovimientos()
        {

        }

        #endregion

        #region METODO INSERTAR
        public async Task<(string rpta, int id_movimiento)> InsertarMovimiento(Movimientos movimiento)
        {
            int id_movimiento = 0;
            int contador = 0;
            string rpta = "";

            string consulta = "INSERT INTO Movimientos (Id_concepto_articulo, Id_usuario, " +
                "Fecha_movimiento, Hora_movimiento, Cantidad_movimiento, Valor_movimiento, Tipo_movimiento) " +
                "VALUES(@Id_concepto_articulo, @Id_usuario, " +
                "@Fecha_movimiento, @Hora_movimiento, @Cantidad_movimiento, @Valor_movimiento, @Tipo_movimiento) " +
                "SET @Id_movimiento = SCOPE_IDENTITY() ";

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

                SqlParameter Id_movimiento = new SqlParameter
                {
                    ParameterName = "@Id_movimiento",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_movimiento);

                SqlParameter Id_concepto_articulo = new SqlParameter
                {
                    ParameterName = "@Id_concepto_articulo",
                    SqlDbType = SqlDbType.Int,
                    Value = movimiento.Id_concepto_articulo,
                };
                SqlCmd.Parameters.Add(Id_concepto_articulo);
                contador += 1;

                SqlParameter Id_usuario = new SqlParameter
                {
                    ParameterName = "@Id_usuario",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = movimiento.Id_usuario,
                };
                SqlCmd.Parameters.Add(Id_usuario);
                contador += 1;

                SqlParameter Fecha_movimiento = new SqlParameter
                {
                    ParameterName = "@Fecha_movimiento",
                    SqlDbType = SqlDbType.Date,
                    Value = movimiento.Fecha_movimiento,
                };
                SqlCmd.Parameters.Add(Fecha_movimiento);
                contador += 1;

                SqlParameter Hora_movimiento = new SqlParameter
                {
                    ParameterName = "@Hora_movimiento",
                    SqlDbType = SqlDbType.Time,
                    Value = movimiento.Hora_movimiento,
                };
                SqlCmd.Parameters.Add(Hora_movimiento);
                contador += 1;

                SqlParameter Cantidad_movimiento = new SqlParameter
                {
                    ParameterName = "@Cantidad_movimiento",
                    SqlDbType = SqlDbType.Int,
                    Value = movimiento.Cantidad_movimiento
                };
                SqlCmd.Parameters.Add(Cantidad_movimiento);
                contador += 1;

                SqlParameter Valor_movimiento = new SqlParameter
                {
                    ParameterName = "@Valor_movimiento",
                    SqlDbType = SqlDbType.Decimal,
                    Value = movimiento.Valor_movimiento
                };
                SqlCmd.Parameters.Add(Valor_movimiento);
                contador += 1;

                SqlParameter Tipo_movimiento = new SqlParameter
                {
                    ParameterName = "@Tipo_movimiento",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = movimiento.Tipo_movimiento.Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Tipo_movimiento);
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
                    id_movimiento = Convert.ToInt32(SqlCmd.Parameters["@Id_movimiento"].Value);
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
            return (rpta, id_movimiento);
        }
        #endregion

        #region METODO EDITAR
        public async Task<string> EditarMovimiento(int id_movimiento, Movimientos movimiento)
        {
            int contador = 0;
            string rpta = "";

            string consulta = "UPDATE Movimientos SET " +
                "Id_articulo = @Id_articulo, " +
                "Id_concepto_articulo = @Id_concepto_articulo, " +
                "Fecha_movimiento = @Fecha_movimiento, " +
                "Hora_movimiento = @Hora_movimiento, " +
                "Cantidad_movimiento = @Cantidad_movimiento, " +
                "Valor_movimiento = @Valor_movimiento, " +
                "Tipo_movimiento = @Tipo_movimiento " +
                "WHERE Id_movimiento = @Id_movimiento ";

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

                SqlParameter Id_movimiento = new SqlParameter
                {
                    ParameterName = "@Id_movimiento",
                    SqlDbType = SqlDbType.Int,
                    Value = id_movimiento,
                };
                SqlCmd.Parameters.Add(Id_movimiento);

                SqlParameter Id_concepto_articulo = new SqlParameter
                {
                    ParameterName = "@Id_concepto_articulo",
                    SqlDbType = SqlDbType.Int,
                    Value = movimiento.Id_concepto_articulo,
                };
                SqlCmd.Parameters.Add(Id_concepto_articulo);
                contador += 1;

                SqlParameter Id_usuario = new SqlParameter
                {
                    ParameterName = "@Id_usuario",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = movimiento.Id_usuario,
                };
                SqlCmd.Parameters.Add(Id_usuario);
                contador += 1;

                SqlParameter Fecha_movimiento = new SqlParameter
                {
                    ParameterName = "@Fecha_movimiento",
                    SqlDbType = SqlDbType.Date,
                    Value = movimiento.Fecha_movimiento,
                };
                SqlCmd.Parameters.Add(Fecha_movimiento);
                contador += 1;

                SqlParameter Hora_movimiento = new SqlParameter
                {
                    ParameterName = "@Hora_movimiento",
                    SqlDbType = SqlDbType.Time,
                    Value = movimiento.Hora_movimiento,
                };
                SqlCmd.Parameters.Add(Hora_movimiento);
                contador += 1;

                SqlParameter Cantidad_movimiento = new SqlParameter
                {
                    ParameterName = "@Cantidad_movimiento",
                    SqlDbType = SqlDbType.Int,
                    Value = movimiento.Cantidad_movimiento
                };
                SqlCmd.Parameters.Add(Cantidad_movimiento);
                contador += 1;

                SqlParameter Valor_movimiento = new SqlParameter
                {
                    ParameterName = "@Valor_movimiento",
                    SqlDbType = SqlDbType.Decimal,
                    Value = movimiento.Valor_movimiento
                };
                SqlCmd.Parameters.Add(Valor_movimiento);
                contador += 1;

                SqlParameter Tipo_movimiento = new SqlParameter
                {
                    ParameterName = "@Tipo_movimiento",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = movimiento.Tipo_movimiento.Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Tipo_movimiento);
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

        #region METODO BUSCAR MOVIMIENTOS
        public async Task<(DataTable dtMovimientos, string rpta)> BuscarMovimientos(string tipo_busqueda, string texto_busqueda)
        {
            string rpta = "OK";

            StringBuilder consulta = new StringBuilder();

            consulta.Append("SELECT * " +
                "FROM Movimientos mov " +
                "INNER JOIN Articulos art ON mov.Id_articulo = art.Id_articulo " +
                "INNER JOIN Usuarios us ON mov.Id_usuario = us.Id_usuario ");

            if (tipo_busqueda.Equals("ID MOVIMIENTO"))
            {
                consulta.Append("WHERE mov.Id_movimiento = @Texto_busqueda ");
            }
            else if (tipo_busqueda.Equals("ID USUARIO"))
            {
                consulta.Append("WHERE mov.Id_usuario = @Texto_busqueda ");
            }
            else if (tipo_busqueda.Equals("FECHA"))
            {
                consulta.Append("WHERE mov.Fecha_movimiento = '@Texto_busqueda' ");
            }
            else if (tipo_busqueda.Equals("TIPO MOVIMIENTO"))
            {
                consulta.Append("WHERE mov.Tipo_movimiento = '@Texto_busqueda' ");
            }

            consulta.Append("ORDER BY mov.Id_movimiento DESC");

            DataTable DtResultado = new DataTable("Movimientos");
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
                await Task.Run(() => SqlData.Fill(DtResultado));

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
