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

        public Administrator GetAdministrator()
        {
            SqlDataReader sqlDataReader;

            using (var command = sqlConnection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Administrator";
                 sqlDataReader  =  command.ExecuteReader();

                return sqlDataReader.Read() ? DataReaderMapToAdministrator(sqlDataReader) : null;
            }
        }

        public Administrator DataReaderMapToAdministrator(SqlDataReader sqlDataReader)
        {
            if (!sqlDataReader.HasRows) return null;

            Administrator admin = new Administrator();

            admin.User = sqlDataReader.GetString(0);
            admin.Password = sqlDataReader.GetString(1);
            admin.Email = sqlDataReader.GetString(2);
            admin.PasswordEmail = sqlDataReader.GetString(3);

            return admin;
        }

    }
}
