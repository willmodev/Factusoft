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
    }
}
