using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using Entity;

namespace Infrastructure
{
    public class Email
    {

        private  MailMessage mailMessage;
        private SmtpClient smtpClient;

        public Email()
        {
            smtpClient = new SmtpClient();
        }

        private void ConfigureSmtp()
        {
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;

            smtpClient.Credentials = new System.Net.NetworkCredential("email", "password");
        }
        private void ConfigureEmail(Client client)
        {
            mailMessage = new MailMessage();
            mailMessage.To.Add(client.E_mail);
            mailMessage.From = new MailAddress("email");
            mailMessage.Subject = "Registro de usuario - " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            mailMessage.Body = $"<b>Sr {client.FirstName} </b> <br " +
                $"> Se ha realizado el registro satisfactoriamente";

            mailMessage.IsBodyHtml = true;
            mailMessage.Priority = MailPriority.Normal;

        }

        public string SendEmail(Client client)
        {
            try
            {
                ConfigureSmtp();
                ConfigureEmail(client);
                smtpClient.Send(mailMessage);

                return "Correo enviado Satisfactoriamente";
            }
            catch (Exception e)
            {

                return $"Error al enviar el correo {e.Message}";
            }
            finally { mailMessage.Dispose(); }

        }


    }
}
