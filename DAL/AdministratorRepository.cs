using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Entity;

namespace DAL
{
    public class AdministratorRepository
    {
        private readonly SqlConnection sqlConnection;

        public AdministratorRepository(ConnectionManager connection)
        {
            sqlConnection = connection.sqlConnection;
        }


        public bool Login(Administrator administrator)
        {
            SqlDataReader sqlDataReader;

            using (var command = sqlConnection.CreateCommand())
            {
                command.CommandText = "validate_user";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@userName", administrator.User);
                command.Parameters.AddWithValue("@passwordName", administrator.Password);

                sqlDataReader = command.ExecuteReader();

               return  sqlDataReader.HasRows;


            }
        }

    }
}
