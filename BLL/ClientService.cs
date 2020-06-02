using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Infrastructure;

namespace BLL
{
    public class ClientService
    {

        private readonly ConnectionManager connectionManager;
        private readonly ClientRepository clientRepository;

        public ClientService(string connectionString)
        {
            connectionManager = new ConnectionManager(connectionString);
            clientRepository = new ClientRepository(connectionManager);
        }
        public SaveClientAnswer Save(Client client)
        {
             Email email = new Email();
            SaveClientAnswer answer = new SaveClientAnswer();

             string messageEmail = string.Empty;

            try
            {
                connectionManager.OpenConnection();
                answer.Error = false;
                clientRepository.Save(client);
                messageEmail = email.SendEmail(client);
                answer.Message = $"Los Datos del cliete {client.FirstName} se han guardado satisfactoriamente { messageEmail}" ;

                return answer;
            }
            catch (Exception e)
            {
                answer.Error = true;
                answer.Message = $"Error de aplicacion: {e.Message}";
                return answer;
            }
            finally { connectionManager.CloseConnection(); }

        }

    }

    public class SaveClientAnswer
    {
        public bool Error { get; set; }
        public string Message { get; set; }
    }
}
