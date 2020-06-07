using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;

namespace BLL
{
    public class InvoiceService
    {
        private readonly InvoiceRepository invoiceRepository;
        private readonly ConnectionManager connectionManager;

        public InvoiceService(string connectionString)
        {
            connectionManager = new ConnectionManager(connectionString);
            invoiceRepository = new InvoiceRepository(connectionManager);
        }


        public SaveInvoiceAnswer SaveInvoice(Invoice invoice)
        {
            SaveInvoiceAnswer answer = new SaveInvoiceAnswer();
            try
            {
                connectionManager.OpenConnection();
                answer.Error = false;
                invoiceRepository.SaveInvoice(invoice);
                answer.Message =  $"Proceso de facturacion Exitoso!";

                return answer;
            }
            catch (Exception e)
            {
                answer.Error = true;
                answer.Message =  $"Error de aplicacion: {e.Message}";

                return answer;
            }
            finally { connectionManager.CloseConnection(); }
        }

        public InvoiceCountAnswer InvoiceCount
        {
            get
            {
                InvoiceCountAnswer answer = new InvoiceCountAnswer();
                try
                {
                    connectionManager.OpenConnection();
                    answer.Error = false;
                    answer.Count = invoiceRepository.CountInvoice;

                    return answer;

                }
                catch (Exception e)
                {
                    answer.Error = true;
                    answer.Message = $"Error al asignar numero de factura: {e.Message}";
                    return answer;
                }
                finally { connectionManager.CloseConnection(); }
            }
        }

    }

    public class InvoiceCountAnswer
    {
        public bool Error { get; set; }
        public string Message { get; set; }
        public int Count { get; set; }
    }

    public class SaveInvoiceAnswer
    {
        public bool Error { get; set; }
        public string Message { get; set; }
    }
}
