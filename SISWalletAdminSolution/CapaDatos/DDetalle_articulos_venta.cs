namespace CapaDatos
{
    using CapaEntidades;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;
    using System.Threading.Tasks;

    public class DDetalle_articulos_venta
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
        public DDetalle_articulos_venta()
        {

        }

        #endregion

        #region METODO INSERTAR
        public async Task<(string rpta, int id_detalle)> InsertarDetalle(Detalle_articulos_venta detalle)
        {
            int id_detalle = 0;
            int contador = 0;
            string rpta = "";

            string consulta = "INSERT INTO Detalle_articulos_venta (Id_articulo, Id_venta, Cantidad_articulo, Valor_articulo, Estado_detalle) " +
                "VALUES(@Id_articulo, @Id_venta, @Cantidad_articulo, @Valor_articulo, @Estado_detalle) " +
                "SET @Id_detalle_venta = SCOPE_IDENTITY() ";

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

                SqlParameter Id_detalle_venta = new SqlParameter
                {
                    ParameterName = "@Id_detalle_venta",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_detalle_venta);

                SqlParameter Id_articulo = new SqlParameter
                {
                    ParameterName = "@Id_articulo",
                    SqlDbType = SqlDbType.Int,
                    Value = detalle.Id_articulo,
                };
                SqlCmd.Parameters.Add(Id_articulo);
                contador += 1;

                SqlParameter Id_venta = new SqlParameter
                {
                    ParameterName = "@Id_venta",
                    SqlDbType = SqlDbType.Int,
                    Value = detalle.Id_venta,
                };
                SqlCmd.Parameters.Add(Id_venta);
                contador += 1;

                SqlParameter Cantidad_articulo = new SqlParameter
                {
                    ParameterName = "@Cantidad_articulo",
                    SqlDbType = SqlDbType.Int,
                    Value = detalle.Cantidad_articulo,
                };
                SqlCmd.Parameters.Add(Cantidad_articulo);
                contador += 1;

                SqlParameter Valor_articulo = new SqlParameter
                {
                    ParameterName = "@Valor_articulo",
                    SqlDbType = SqlDbType.Decimal,
                    Value = detalle.Cantidad_articulo,
                };
                SqlCmd.Parameters.Add(Valor_articulo);
                contador += 1;

                SqlParameter Estado_detalle = new SqlParameter
                {
                    ParameterName = "@Estado_detalle",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = detalle.Estado_detalle.Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Estado_detalle);
                contador += 1;

                //Ejecutamos nuestro comando
                rpta = await SqlCmd.ExecuteNonQueryAsync() >= 1 ? "OK" : "NO SE INGRESÓ";
                if (!rpta.Equals("OK"))
                {
                    tran.Rollback();
                    if (this.Mensaje_respuesta != null)
                    {
                        rpta = this.Mensaje_respuesta;
                    }
                }
                else
                {
                    tran.Commit();
                    id_detalle = Convert.ToInt32(SqlCmd.Parameters["@Id_detalle_venta"].Value);
                }
                tran.Dispose();
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
            return (rpta, id_detalle);
        }
        #endregion

        #region METODO BUSCAR DETALLE
        public async Task<(DataTable dtDetalle, string rpta)> BuscarDetalle(string tipo_busqueda, string texto_busqueda)
        {
            string rpta = "OK";

            StringBuilder consulta = new StringBuilder();

            consulta.Append("SELECT * FROM Detalle_articulos_venta dar " +
                "INNER JOIN Articulos art ON dar.Id_articulo = art.Id_articulo " +
                "INNER JOIN Ventas ve ON dar.Id_venta = ve.Id_venta ");

            if (tipo_busqueda.Equals("ID VENTA"))
            {
                consulta.Append("WHERE ve.Id_venta = @Texto_busqueda ");
            }

            consulta.Append("ORDER BY dar.Id_detalle_venta DESC");

            DataTable DtResultado = new DataTable("DetalleVentas");
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
