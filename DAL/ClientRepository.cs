using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace DAL
{
   
    public class ClientRepository
    {
        private readonly SqlConnection sqlConnection;
        public ClientRepository(ConnectionManager connection)
        {
            sqlConnection = connection.sqlConnection;
        }

        public void Save(Client client)
        {
            using (var command = sqlConnection.CreateCommand())
            {
                command.CommandText = @"insert_client";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@firstName", client.FirstName);
                command.Parameters.AddWithValue("@secondName", client.SecondName);
                command.Parameters.AddWithValue("@lastName", client.LastName);
                command.Parameters.AddWithValue("@secondLastName", client.SecondLastName);
                command.Parameters.AddWithValue("@cedula", client.Cedula);
                command.Parameters.AddWithValue("@sex", client.Sex);
                command.Parameters.AddWithValue("@dateOfBorn", client.DateOfBorn);
                command.Parameters.AddWithValue("@Age", client.Age);
                command.Parameters.AddWithValue("@Telephone", client.Telephone);
                command.Parameters.AddWithValue("@E_mail", client.E_mail);
                command.Parameters.AddWithValue("@AddressHome", client.AddressHome);
                command.Parameters.AddWithValue("@Neighborhood", client.Neighborhood);
                command.Parameters.AddWithValue("@City", client.City);
                command.ExecuteNonQuery();


            }
        }

        public bool Remove(string cedula)
        {
            using (var command = sqlConnection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Clients WHERE Cedula = @Cedula";
                command.Parameters.AddWithValue("@Cedula", cedula);
                return command.ExecuteNonQuery() > 0;
            }
        }

        public IList<Client> Consult()
        {
            SqlDataReader sqlDataReader;
            IList<Client> clients = new List<Client>();
            using (var command = sqlConnection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Clients";
                sqlDataReader = command.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        Client client = DataReaderMapToClient(sqlDataReader);
                        clients.Add(client);
                    }
                }
            }

            return clients;
        }

        private Client DataReaderMapToClient(SqlDataReader sqlDataReader)
        {
            if (!sqlDataReader.HasRows) return null;

            Client client = new Client();

            client.FirstName = sqlDataReader.GetString(0);
            client.SecondName = sqlDataReader.GetString(1);
            client.LastName = sqlDataReader.GetString(2);
            client.SecondLastName = sqlDataReader.GetString(3);
            client.Cedula = sqlDataReader.GetString(4);
            client.Sex = sqlDataReader.GetString(5);
            client.DateOfBorn = sqlDataReader.GetDateTime(6);
            client.Age = (int)sqlDataReader.GetInt32(7);
            client.Telephone = sqlDataReader.GetString(8);
            client.E_mail = sqlDataReader.GetString(9);
            client.AddressHome = sqlDataReader.GetString(10);
            client.Neighborhood = sqlDataReader.GetString(11);
            client.City = sqlDataReader.GetString(12);


            return client;
        }

        public Client Search(string Cedula)
        {
            SqlDataReader sqlDataReader;
            using (var command = sqlConnection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Clients WHERE Cedula = @Cedula";
                command.Parameters.AddWithValue("@Cedula", Cedula);
                sqlDataReader = command.ExecuteReader();

                return sqlDataReader.Read() ? DataReaderMapToClient(sqlDataReader) : null;

            }
        }

        public bool Modify(Client client)
        {
            using (var command = sqlConnection.CreateCommand())
            {
                command.CommandText = "UPDATE Clients SET FirstName = @FirstName, SecondName = @SecondName, LastName = @LastName," +
                                                        " SecondLastName = @SecondLastName, Cedula = @Cedula, Sex = @Sex, DateOfBorn = @DateOfBorn," +
                                                        "Age = @Age, Telephone = @Telephone, E_mail = @E_mail, AddressHome = @AddressHome," +
                                                        "Neighborhood = @Neighborhood, City = @City WHERE Cedula = @Cedula ";
                command.Parameters.AddWithValue("@FirstName", client.FirstName);
                command.Parameters.AddWithValue("@SecondName", client.SecondName);
                command.Parameters.AddWithValue("@LastName", client.LastName);
                command.Parameters.AddWithValue("@SecondLastName", client.SecondLastName);
                command.Parameters.AddWithValue("@Cedula", client.Cedula);
                command.Parameters.AddWithValue("@Sex", client.Sex);
                command.Parameters.AddWithValue("@DateOfBorn", client.DateOfBorn);
                command.Parameters.AddWithValue("@Age", client.Age);
                command.Parameters.AddWithValue("@Telephone", client.Telephone);
                command.Parameters.AddWithValue("@E_mail", client.E_mail);
                command.Parameters.AddWithValue("@AddressHome", client.AddressHome);
                command.Parameters.AddWithValue("@Neighborhood ", client.Neighborhood);
                command.Parameters.AddWithValue("@City", client.City);
                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}
