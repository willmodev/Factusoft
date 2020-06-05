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
        private AdministratorService adminService;

        public ClientesFrm()
        {
            InitializeComponent();
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            clientService = new ClientService(connectionString);
            adminService = new AdministratorService(connectionString);
        }

        private Administrator MapOutAdministrator()
        {
            GetAdministratorAnswer answer = adminService.GetAdministrator();

            if(!answer.Error)
            {
                if (answer.Admin == null) MessageBox.Show(answer.Message);
            }else
            {
                MessageBox.Show(answer.Message);
            }

            return answer.Admin;
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
            client.AddressHome = TxtAddressHome.Text;
            client.Neighborhood = TxtNeighborhood.Text;
            client.City = TxtCity.Text;
            
            return client;
        }

     

        private void SaveBtn_Click(object sender, EventArgs e)
        {

            SaveClientAnswer answerClient = clientService.Save(MapOutClient(), MapOutAdministrator());
            MessageBox.Show(answerClient.Message);

        }
    }
}
