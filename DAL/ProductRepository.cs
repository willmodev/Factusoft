using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entity;
using System.Data;
namespace DAL
{
    public class ProductRepository
    {
        private readonly SqlConnection sqlConnection;
        

        public ProductRepository(ConnectionManager connection)
        {
           
            sqlConnection = connection.sqlConnection;
            
        }
        
        public void Save(Product product)
        {
            using (var command = sqlConnection.CreateCommand())
            {
                command.CommandText = @"insertProducts";
                ParametersProduct(product, command);

                command.ExecuteNonQuery();


            }
        }

        private static void ParametersProduct(Product product, SqlCommand command)
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ID", product.ID);
            command.Parameters.AddWithValue("@Name", product.Name);
            command.Parameters.AddWithValue("@SalePrice", product.SalePrice);
            command.Parameters.AddWithValue("@PurchasePrice", product.PurchasePrice);
            command.Parameters.AddWithValue("@UnitMeasure", product.UnitMeasure);
            command.Parameters.AddWithValue("@Quantity", product.Quantity);
            command.Parameters.AddWithValue("@IVA", product.IVA);
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
            IList<Product> products = new List<Product>();
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
            product.SalePrice = sqlDataReader.GetDecimal(2);
            product.PurchasePrice = sqlDataReader.GetDecimal(3);
            product.UnitMeasure = sqlDataReader.GetString(4);
            product.Quantity = (float)sqlDataReader.GetDouble(5);
            product.IVA = sqlDataReader.GetDecimal(6);

            return product;
        }

        public Product Search(string ID)
        {
            SqlDataReader sqlDataReader;
            using (var command = sqlConnection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Products WHERE ID = @ID";
                command.Parameters.AddWithValue("@ID", ID);
                sqlDataReader = command.ExecuteReader();

                return sqlDataReader.Read() ? DataReaderMapToProduct(sqlDataReader) : null;

            }
        }

        public bool Modify(Product product)
        {
            using (var command = sqlConnection.CreateCommand())
            {
                command.CommandText = "updateProduct";
                ParametersProduct(product, command);
                return command.ExecuteNonQuery() > 0;
            }
        }


    }
}
