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
                invoiceRepository.SaveTransaction(invoice);
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

        public InvoiceSearchAnswer SearchInvoice(int invoice_id)
        {
            InvoiceSearchAnswer answer = new InvoiceSearchAnswer();
            try
            {
                connectionManager.OpenConnection();
                answer.Error = false;
                answer.Invoice = invoiceRepository.SearchInvoice(invoice_id);
                answer.Message = answer.Invoice != null ? "Factura encontrada" : "La factura no existe";

                return answer;
            }
            catch (Exception e)
            {
                answer.Error = true;
                answer.Message = $"Error de aplicacion: {e.Message}";
                answer.Invoice = null;

                return answer;
            }
            finally { connectionManager.CloseConnection(); }

        }

        public InvoiceDetailConsultAnswer ConsultInvoiceDetail(int invoice_id)
        {
            InvoiceDetailConsultAnswer answer = new InvoiceDetailConsultAnswer();

            try
            {
                connectionManager.OpenConnection();
                answer.Error = false;
                answer.invoiceDetails = invoiceRepository.ConsultInvoiceDetail(invoice_id);
                answer.Message = answer.invoiceDetails.Count != 0 ? "Detalles encontrados" : "Los detalles no existen!";

                return answer;
            }
            catch (Exception e)
            {
                answer.Error = false;
                answer.Message = $"Error de aplicacion: {e.Message}";
                answer.invoiceDetails = null;

                return answer;

            }
            finally { connectionManager.CloseConnection(); }

        }

        public InvoiceConsultAnswer ConsultInvoices()
        {
            InvoiceConsultAnswer answer = new InvoiceConsultAnswer();

            try
            {
                connectionManager.OpenConnection();
                answer.Error = false;
                answer.Invoices = invoiceRepository.ConsultInvoices();
                answer.Message = answer.Invoices != null ? "Cunsulta de facturas exitosa!" : "No existen facturas registradas!";
                return answer;


            }
            catch (Exception e)
            {
                answer.Error = true;
                answer.Message = $"Error de aplicacion: {e.Message}";
                answer.Invoices = null;

                return answer;
            }
            finally { connectionManager.CloseConnection(); }
        }


        public InvoiceDetailDTO MapInvoiceDetailDTO(Product product, float quantity,float discount, decimal price)
        {
            InvoiceDetailDTO invoiceDetailDTO = new InvoiceDetailDTO();
            InvoiceDetail invoiceDetail = new InvoiceDetail(product,quantity,discount,price);

            invoiceDetailDTO.ID =  invoiceDetail.Product.ID;
            invoiceDetailDTO.NameProduct = invoiceDetail.Product.Name;
            invoiceDetailDTO.Quantity = invoiceDetail.Quantity;
            invoiceDetailDTO.UnitValue = invoiceDetail.UnitValue;
            invoiceDetailDTO.IVA = invoiceDetail.Product.IVA;
            invoiceDetailDTO.Discount = invoiceDetail.Discount;
            invoiceDetailDTO.TolalDetail = invoiceDetail.TolalDetail;

            return invoiceDetailDTO;
            

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

        public IList<Invoice> FilerByType(string invoiceType)
        {
            InvoiceConsultAnswer answer = ConsultInvoices();

            return answer.Invoices.Where(i => i.InvoiceType.Equals(invoiceType)).ToList();
        }

        public decimal TotalByType(string invoiceType)
        {
            return FilerByType(invoiceType).Sum(i => i.Total);
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

    public class InvoiceDetailDTO
    {
        public string ID { get; set; }
        public string NameProduct { get; set; }
        public decimal UnitValue { get; set; }
        public float Quantity { get; set; }
        public float Discount { get; set; }
        public decimal IVA { get; set; }
        public decimal TolalDetail { get; set; }
    }

    public class InvoiceSearchAnswer
    {
        public bool Error { get; set; }
        public string Message { get; set; }
        public Invoice Invoice { get; set; }
    }

    public class InvoiceConsultAnswer
    {
        public bool Error { get; set; }
        public string Message { get; set; }
        public IList<Invoice> Invoices { get; set; }
    }

    public class InvoiceDetailConsultAnswer
    {
        public bool Error { get; set; }
        public string Message { get; set; }
        public IList<InvoiceDetail> invoiceDetails { get; set; }
    }
}
