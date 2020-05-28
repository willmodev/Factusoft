using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entity;
namespace DAL
{
    public class ProductRepository
    {
        private readonly SqlConnection sqlConnection;
        private readonly IList<Product> products;

        public ProductRepository(ConnectionManager connection)
        {
            sqlConnection = connection.sqlConnection;
        }
        
        public void Save(Product product)
        {
            using (var command = sqlConnection.CreateCommand())
            {
                command.CommandText = @"INSERT INTO Products (ID, Name, UnitValue, UnitMeasure, Quantity, IVA)
                                                     VALUES (@ID, @Name, @UnitValue, @UnitMeasure, @Quantity, @IVA)";
                command.Parameters.AddWithValue("@ID", product.ID);                  
                command.Parameters.AddWithValue("@Name", product.Name);                  
                command.Parameters.AddWithValue("@UnitValue", product.UnitValue);                  
                command.Parameters.AddWithValue("@UnitMeasure", product.UnitMeasure);                  
                command.Parameters.AddWithValue("@Quantity", product.Quantity);                  
                command.Parameters.AddWithValue("@IVA", product.IVA);

                command.ExecuteNonQuery();

               
            }
        }

        public bool Remove(string ID)
        {
            using (var command = sqlConnection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Products WHERE ID = @ID";
                command.Parameters.AddWithValue("@ID",ID);
                return command.ExecuteNonQuery() > 0;
            }
        }

        public IList<Product> Consult()
        {
            SqlDataReader sqlDataReader;
            using (var command = sqlConnection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Products";
                sqlDataReader = command.ExecuteReader();

                if(sqlDataReader.HasRows)
                {
                    while(sqlDataReader.Read())
                    {
                        Product product = DataReaderMapToProduct(sqlDataReader);
                        products.Add(product);
                    }
                }
            }

            return products;
        }

        private Product DataReaderMapToProduct(SqlDataReader sqlDataReader)
        {
            if (!sqlDataReader.HasRows) return null;

            Product product = new Product();

            product.ID = sqlDataReader.GetString(0);
            product.Name = sqlDataReader.GetString(1);
            product.UnitValue = sqlDataReader.GetDecimal(2);
            product.UnitMeasure = sqlDataReader.GetString(3);
            product.Quantity = sqlDataReader.GetFloat(4);
            product.IVA = sqlDataReader.GetDecimal(5);

            return product;
        }

        public Product Search(string ID)
        {
            SqlDataReader sqlDataReader;
            using (var command = sqlConnection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Product WHERE ID = @ID";
                command.Parameters.AddWithValue("@ID", ID);
                sqlDataReader = command.ExecuteReader();

                return sqlDataReader.Read() ? DataReaderMapToProduct(sqlDataReader) : null;

            }
        }

        public bool Modify(Product product)
        {
            using (var command = sqlConnection.CreateCommand())
            {
                command.CommandText = "UPDATE Product SET ID = @ID, Name = @Name, UnitValue = @UnitValue," +
                                                        " UnitMeasure = @UnitMeasure, Quantity = @Quantity, IVA = @IVA " +
                                                        "WHERE ID = @ID ";
                command.Parameters.AddWithValue("@ID", product.ID);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@UnitValue", product.UnitValue);
                command.Parameters.AddWithValue("@UnitMeasure", product.UnitMeasure);
                command.Parameters.AddWithValue("@Quantity", product.Quantity);
                command.Parameters.AddWithValue("@IVA", product.IVA);

                return command.ExecuteNonQuery() > 0;
            }
        }


    }
}
