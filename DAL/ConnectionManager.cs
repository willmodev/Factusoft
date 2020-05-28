using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace DAL
{
    public class ConnectionManager
    {
        internal SqlConnection sqlConnection;

        public ConnectionManager(string connectionString)
        {
            sqlConnection = new SqlConnection(connectionString);
        }


        public void OpenConnection()
        {
             sqlConnection.Open();
        }

        public void CloseConnection()
        {
            sqlConnection.Close();
        }
    }
}
