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


        public string SaveInvoice(Invoice invoice)
        {
            try
            {
                connectionManager.OpenConnection();
                invoiceRepository.SaveInvoice(invoice);
                return $"Proceso de facturacion Exitoso!";

            }
            catch (Exception e)
            {

                return $"Error de aplicacion: {e.Message}";
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
            }
        }

    }

    public class InvoiceCountAnswer
    {
        public bool Error { get; set; }
        public string Message { get; set; }
        public int Count { get; set; }
    }
}
