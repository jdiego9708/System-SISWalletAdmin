namespace CapaEntidades.Helpers
{
    using System;
    using System.Threading.Tasks;

    public class ConnectionHelper
    {
        public static async Task<Response> CheckConnection()
        {
            try
            {
                Uri Url = new Uri("http://www.google.com/");
                System.Net.WebRequest WebRequest;
                WebRequest = System.Net.WebRequest.Create(Url);
                System.Net.WebResponse objResp;
                try
                {
                    objResp = await WebRequest.GetResponseAsync();
                    objResp.Close();
                    WebRequest = null;
                    return new Response
                    {
                        IsSuccess = true,
                        Message = "Correcta conexión a internet",
                    };
                }
                catch (Exception ex)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "Error con la conexión a internet, detalles: " + ex.Message
                    };
                }
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Error con la conexión a internet, detalles: " + ex.Message
                };
            }
        }
    }
}
