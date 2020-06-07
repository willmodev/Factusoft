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


        public void SaveInvoice(Invoice invoice)
        {
            using (var command = sqlConnection.CreateCommand())
            {
                SqlTransaction transaction = sqlConnection.BeginTransaction();
                command.Transaction = transaction;

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
                transaction.Commit();

                SaveInvoiceDetail(invoice.InvoiceDetails);

                
            }
        }

        public void SaveInvoiceDetail(IList<InvoiceDetail> invoiceDetails)
        {
            foreach (var item in invoiceDetails)
            {
                using (var command = sqlConnection.CreateCommand())
                {
                    SqlTransaction transaction = sqlConnection.BeginTransaction();
                    command.Transaction = transaction;

                    command.CommandText = "insert_InvoiceDetail";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Quantity", item.Quantity);
                    command.Parameters.AddWithValue("@Discount", item.Discount);
                    command.Parameters.AddWithValue("@IVA", item.IVA);
                    command.Parameters.AddWithValue("@product_ID", item.Product.ID);
                    command.Parameters.AddWithValue("@Invoice_ID",item.Invoice_ID);
                    command.Parameters.AddWithValue("@TolalDetail", item.TolalDetail);

                    command.ExecuteNonQuery();
                    transaction.Commit();
                }

            }

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
