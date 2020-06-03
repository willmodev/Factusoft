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

            smtpClient.Credentials = new System.Net.NetworkCredential("toeyubu@gmail.com", "xxxxxxxxxxxx");
        }
        private void ConfigureEmail(Client client)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            string ruta = @"D: \University\Programacion III\productos.pdf";

            mailMessage = new MailMessage();
            mailMessage.To.Add(client.E_mail);
            mailMessage.From = new MailAddress("toeyubu@gmail.com");
            mailMessage.Subject = "Willinton Mora - Lista de productos - " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            mailMessage.Body = $"<b>Sr {client.FirstName} </b> <br " +
                $"> Se adjunta el informe de la lista de productos";

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
