using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using BLL;
using System.Configuration;

namespace PulsacionesGUI
{
    public partial class ClientesFrm : Form
    {
        private ClientService clientService;
        private AddressService addressService;
        public ClientesFrm()
        {
            InitializeComponent();
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            clientService = new ClientService(connectionString);
            addressService = new AddressService(connectionString);
        }




        private Client MapOutClient()
        {
            Client client = new Client();

            client.FirstName = TxtFistName.Text;
            client.SecondName = TxtSocondName.Text;
            client.LastName = TxtLastName.Text;
            client.SecondLastName = TxtSecondLastName.Text;
            client.Cedula = TxtCedula.Text;
            client.Sex = CmbSex.Text;
            client.DateOfBorn = DtpDateOfBorn.Value;
            client.Telephone = TxtTelephone.Text;
            client.E_mail = TxtEmail.Text;
            client.Address_ID = 0;

            return client;

        }

        private Address MapOutAddress()
        {
            Address address = new Address();

            address.AddressHome = TxtAddressHome.Text;
            address.Neighborhood = TxtNeighborhood.Text;
            address.City = TxtCity.Text;
            address.Cedula = TxtCedula.Text;

            return address;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {

            SaveClientAnswer answerClient = clientService.Save(MapOutClient());
            SaveAddressAnswer answerAddress = addressService.Save(MapOutAddress());

                MessageBox.Show(answerClient.Message);

            if (answerAddress.Error)
                MessageBox.Show(answerAddress.Message);
        }
    }
}
