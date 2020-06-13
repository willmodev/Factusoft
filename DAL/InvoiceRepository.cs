using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entity;

namespace DAL
{
    public class InvoiceRepository
    {
        private readonly SqlConnection sqlConnection;

        public InvoiceRepository(ConnectionManager connection)
        {
            sqlConnection = connection.sqlConnection;
        }


        public void SaveInvoice(Invoice invoice, SqlTransaction sqlTransaction)
        {
            using (var command = sqlConnection.CreateCommand())
            {
                command.Transaction = sqlTransaction;

                command.CommandText = "insert_invoice";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Invoice_ID", invoice.Invoice_ID );
                command.Parameters.AddWithValue("@SaleDate", invoice.SaleDate);
                command.Parameters.AddWithValue("@DueDate", invoice.DueData);
                command.Parameters.AddWithValue("@InvoiceType", invoice.InvoiceType);
                command.Parameters.AddWithValue("@Cedula", invoice.Client.Cedula);
                command.Parameters.AddWithValue("@SubTotal", invoice.Subtotal);
                command.Parameters.AddWithValue("@Total_IVA", invoice.TotalIva);
                command.Parameters.AddWithValue("@Total", invoice.Total);
            
                command.ExecuteNonQuery();

                
            }
        }

        public void SaveTransaction(Invoice invoice)
        {
            using (SqlTransaction transaction = sqlConnection.BeginTransaction())
            {
                SaveInvoice(invoice, transaction);
                SaveInvoiceDetail(invoice.InvoiceDetails, transaction);
                transaction.Commit();
            }

        }

        public void SaveInvoiceDetail(IList<InvoiceDetail> invoiceDetails, SqlTransaction sqlTransaction)
        {
            foreach (var item in invoiceDetails)
            {
                using (var command = sqlConnection.CreateCommand())
                {
                    command.Transaction = sqlTransaction;

                    command.CommandText = "insert_InvoiceDetail";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Quantity", item.Quantity);
                    command.Parameters.AddWithValue("@Discount", item.Discount);
                    command.Parameters.AddWithValue("@product_ID", item.Product.ID);
                    command.Parameters.AddWithValue("@Invoice_ID",item.Invoice_ID);
                    command.Parameters.AddWithValue("@TolalDetail", item.TolalDetail);

                    command.ExecuteNonQuery();
                }

            }

        }

        public Invoice SearchInvoice(int invoice_id)
        {
            SqlDataReader sqlDataReader;
            Invoice invoice = new Invoice();

            using (var command = sqlConnection.CreateCommand())
            {
                command.CommandText = "selectInvoiceAndClients";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Invoice_ID", invoice_id);

                sqlDataReader = command.ExecuteReader();

                if (sqlDataReader.Read())
                {
                    invoice = MapInvoice(sqlDataReader);
                    sqlDataReader.Close();
                    invoice.InvoiceDetails = ConsultInvoiceDetail(invoice.Invoice_ID);
                } else
                    invoice = null;
            }
            
            return invoice;
        }

        public IList<Invoice> ConsultInvoices()
        {
            SqlDataReader sqlDataReader;
            IList<Invoice> invoices = new List<Invoice>();

            using (var command = sqlConnection.CreateCommand())
            {
                command.CommandText = @"selectInvoiceAndClients2";
                command.CommandType = CommandType.StoredProcedure;
                sqlDataReader = command.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        Invoice invoice = MapInvoice(sqlDataReader);
                        invoices.Add(invoice);
                    }
                }
                else
                    invoices = null;

            }

            return invoices;
        }

        public IList<InvoiceDetail> ConsultInvoiceDetail(int invoice_id)
        {
            SqlDataReader sqlDataReader;
            IList<InvoiceDetail> invoiceDetails = new List<InvoiceDetail>();

            using (var command = sqlConnection.CreateCommand())
            {
                command.CommandText = "selectInvoiceDetailAndProducts";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Invoice_ID", invoice_id);

                sqlDataReader = command.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        InvoiceDetail invoiceDetail = MapInvoiceDetail(sqlDataReader);
                        invoiceDetails.Add(invoiceDetail);
                    }
                }
                else
                    invoiceDetails = null;

            }
            sqlDataReader.Close();
            return invoiceDetails;
        }

        public InvoiceDetail MapInvoiceDetail(SqlDataReader sqlDataReader)
        {
            Product product = new Product();
            InvoiceDetail invoiceDetail = new InvoiceDetail();

            product.ID = sqlDataReader.GetString(3);
            product.Name = sqlDataReader.GetString(4);
            product.SalePrice = sqlDataReader.GetDecimal(5);
            product.PurchasePrice = sqlDataReader.GetDecimal(6);
            product.UnitMeasure = sqlDataReader.GetString(7);
            product.IVA = sqlDataReader.GetDecimal(8);
            product.Quantity = (float)sqlDataReader.GetDouble(9);

            invoiceDetail.Product = product;
            invoiceDetail.Quantity = (float)sqlDataReader.GetDouble(0);
            invoiceDetail.Discount  = (float)sqlDataReader.GetDouble(1);
            invoiceDetail.TolalDetail = sqlDataReader.GetDecimal(2);

            return invoiceDetail;
        }

        public Invoice MapInvoice(SqlDataReader sqlDataReader)
        {
            Client client = new Client();
            Invoice invoice = new Invoice();

            invoice.SaleDate = sqlDataReader.GetDateTime(0);
            invoice.DueData = sqlDataReader.GetDateTime(1);
            invoice.InvoiceType = sqlDataReader.GetString(2);
            invoice.Invoice_ID = sqlDataReader.GetInt32(3);
            invoice.Subtotal = sqlDataReader.GetDecimal(4);
            invoice.TotalIva = sqlDataReader.GetDecimal(5);
            invoice.Total = sqlDataReader.GetDecimal(6);

            client.Cedula = sqlDataReader.GetString(7);
            client.FirstName = sqlDataReader.GetString(8);
            client.SecondName = sqlDataReader.GetString(9);
            client.LastName = sqlDataReader.GetString(10);
            client.SecondLastName = sqlDataReader.GetString(11);
            client.Sex = sqlDataReader.GetString(12);
            client.DateOfBorn = sqlDataReader.GetDateTime(13);
            client.Age = sqlDataReader.GetInt32(14);
            client.Telephone = sqlDataReader.GetString(15);
            client.E_mail = sqlDataReader.GetString(16);
            client.AddressHome = sqlDataReader.GetString(17);
            client.Neighborhood = sqlDataReader.GetString(18);

            invoice.Client = client;

            return invoice;

        }

        public int CountInvoice
        {
            get
            {
                using (var command = sqlConnection.CreateCommand())
                {
                    command.CommandText = "SELECT COUNT(*) FROM Invoice";
                    return (int)command.ExecuteScalar();
                }
            }
        }

       
    }
}
