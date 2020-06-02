using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entity;

namespace DAL
{
    public class AddressRepository
    {
        private readonly SqlConnection sqlConnection;

        public AddressRepository(ConnectionManager connection)
        {
            sqlConnection = connection.sqlConnection;
        }


        public void Save(Address address)
        {
            using (var command =  sqlConnection.CreateCommand())
            {
                command.CommandText = @"insert_address";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@AddressHome",address.AddressHome);
                command.Parameters.AddWithValue("@Neighborhood", address.Neighborhood);
                command.Parameters.AddWithValue("@City", address.City);
                command.Parameters.AddWithValue("@Cedula", address.Cedula);

                command.ExecuteNonQuery();

            }
        }
    }
}
