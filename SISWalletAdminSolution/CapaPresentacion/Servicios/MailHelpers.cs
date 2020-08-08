namespace CapaPresentacion.Servicios
{
    using CapaPresentacion.Properties;
    using System;
    using System.IO;
    using System.Net.Mail;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    public class MailHelpers
    {
        public static bool EmailValidation(string email)
        {
            string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool SendEmailTest(string emailFrom, string emailTo,
                                    string smtpServer, int smtpPort, string emailPass, string subject, out string rpta)
        {
            rpta = "OK";
            try
            {
                string HTMLTemplateMail = this.templateEmail();
                string nameBusiness = "";
                string telBusiness = "";
                string direccionBusiness = "";
                string cityCountry = "";

                if (HTMLTemplateMail == null)
                {
                    throw new Exception("No se envió el correo, no se encontró la plantilla");
                }

                StringBuilder headerEmail = new StringBuilder();
                StringBuilder contentEmail = new StringBuilder();

                headerEmail.Append("<h4>Correo electrónico de prueba</h4>");
                headerEmail.Append("<br />");

                contentEmail.Append("Se ha enviado un correo de prueba.");
                contentEmail.Append("<br />");

                if (subject.Equals("ERRORES"))
                    contentEmail.Append("<strong>Este correo electrónico a sido asignado como el predeterminado para " +
                        "el recibo de los errores del software SISAgua.</strong>");
                else if (subject.Equals("REPORTES"))
                    contentEmail.Append("<strong>Este correo electrónico a sido asignado como el predeterminado para " +
                        "el recibo de los reportes del software SISAgua.</strong>");

                contentEmail.Append("<br />");
                contentEmail.Append("<strong>Fecha " + DateTime.Now.ToLongDateString() + "</strong>");

                HTMLTemplateMail = concatTemplateEmailWithHeaderBody(HTMLTemplateMail, headerEmail.ToString(), contentEmail.ToString(),
                    nameBusiness, telBusiness, direccionBusiness, cityCountry);

                MailMessage mail = new MailMessage(emailFrom, emailTo);
                mail.From = new MailAddress(emailFrom, "Software SISAgua", Encoding.UTF8);
                mail.IsBodyHtml = true;
                mail.Subject = subject;
                mail.Body = HTMLTemplateMail;
                //mail.Bcc.Add(ConfigurationManager.AppSettings["eMailRetail"].ToString());

                SmtpClient client = new SmtpClient(smtpServer);
                client.Credentials = new System.Net.NetworkCredential(emailFrom, emailPass);
                client.Port = smtpPort;
                client.EnableSsl = true;
                client.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
                return false;
            }
        }

        private string templateEmail()
        {
            return Resources.templateMail;
        }

        private string templateEmail1()
        {
            string _pathTemplate = "templateMail.htm";

            string eMailHTML = null;

            if (File.Exists(Path.Combine(Application.StartupPath, _pathTemplate)))
            {
                using (StreamReader reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + _pathTemplate))
                {
                    while (reader.Peek() >= 0)
                    {
                        eMailHTML += reader.ReadLine();
                    }
                }
            }

            return eMailHTML;
        }

        private string concatTemplateEmailWithHeaderBody(string HTMLTemplate, string header, string body,
            string name_business, string tel_business, string direccion_business, string city_country)
        {
            try
            {
                HTMLTemplate = HTMLTemplate.Replace(@"#_HEADER_MAIL", header);
                HTMLTemplate = HTMLTemplate.Replace(@"#_BODY_MAIL", body);
                HTMLTemplate = HTMLTemplate.Replace(@"#_NAME_BUSINESS", name_business);
                HTMLTemplate = HTMLTemplate.Replace(@"#_TEL_BUSINESS", tel_business);
                HTMLTemplate = HTMLTemplate.Replace(@"#_DIRECCION_BUSINESS", direccion_business);
                HTMLTemplate = HTMLTemplate.Replace(@"#_CITY_COUNTRY", city_country);
            }
            catch (Exception)
            {
                return HTMLTemplate;
            }
            return HTMLTemplate;
        }
    }
}
