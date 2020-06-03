using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace BLL
{
    public class AdministratorService
    {
        private readonly ConnectionManager connectionManager;
        private readonly AdministratorRepository administratorRepository;

        public AdministratorService(string connectionString)
        {
            connectionManager = new ConnectionManager(connectionString);
            administratorRepository = new AdministratorRepository(connectionManager);
        }


        public LoginAnswer Login(Administrator administrator)
        {
            LoginAnswer loginAnswer = new LoginAnswer();

            try
            {
                loginAnswer.Error = false;
                connectionManager.OpenConnection();
                loginAnswer.ValidData = administratorRepository.Login(administrator);
                return loginAnswer;
            }
            catch (Exception e)
            {
                loginAnswer.Error = true;
                loginAnswer.Message = $"Error de aplicacion {e.Message}";
                return loginAnswer;
            }
            finally { connectionManager.CloseConnection(); }
        }

    }

    public class LoginAnswer
    {
        public bool ValidData { get; set; }
        public string Message { get; set; }

        public bool Error { get; set; }
    }
}
