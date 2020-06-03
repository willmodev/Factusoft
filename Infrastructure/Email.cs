using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using Entity;
using System.Windows.Forms;

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

            smtpClient.Credentials = new System.Net.NetworkCredential("gutierrezjk18@gmail.com", "juank200141");
        }
        private void ConfigureEmail(Client client)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            string ruta = string.Empty;

            mailMessage = new MailMessage();
            mailMessage.To.Add(client.E_mail);
            mailMessage.From = new MailAddress("gutierrezjk18@gmail.com");
            mailMessage.Subject = "Juan Carlos Gutierrez - Reporte de productos - " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            mailMessage.Body = $"<b>Sr {client.FirstName} </b> <br " +
                $"> Reportes de productos de la app Factusoft";

            openFileDialog.ShowDialog();

            if(openFileDialog.FileName.Equals("") == false)
                ruta = openFileDialog.FileName;

            mailMessage.Attachments.Add( new Attachment(ruta));
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
