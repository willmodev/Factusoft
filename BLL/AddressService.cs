using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;
namespace BLL
{
  
    public class AddressService
    {
        private readonly ConnectionManager connectionManager;
        private readonly AddressRepository addressRepository;

        public AddressService(string  connectionString)
        {
            connectionManager = new ConnectionManager(connectionString);
            addressRepository = new AddressRepository(connectionManager);
        }


        public SaveAddressAnswer Save(Address address)
        {
            SaveAddressAnswer saveAnswer = new SaveAddressAnswer();

            try
            {
                connectionManager.OpenConnection();
                saveAnswer.Error = false;
                addressRepository.Save(address);
                saveAnswer.Message = $"Domicilio registrado!";

                return saveAnswer;
            }
            catch (Exception e)
            {

                saveAnswer.Error =  true;
                saveAnswer.Message = $"Error de aplicacion: {e.Message}";
                return saveAnswer;
            }
            finally { connectionManager.CloseConnection(); }
        }

    }

    public class SaveAddressAnswer
    {
        public bool Error { get; set; }
        public string Message { get; set; }
    }
        
}
