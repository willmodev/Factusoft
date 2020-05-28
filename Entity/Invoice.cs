using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Invoice
    {
        public string Invoice_ID { get; set; }
        public DateTime SaleDate { get; set; }
        public DateTime DueData { get; set; }
        public Client Client { get; set; }
        public decimal Subtotal { get; set; }
        public decimal TotalIva { get; set; }
        public decimal Total { get; set; }

        public List<InvoiceDetail> InvoiceDetails;

        public Invoice()
        {
            InvoiceDetails = new List<InvoiceDetail>();
        }

        public void AgregarDetalleFactura(string detail_id, Product product, int quantity, decimal discount)
        {
            InvoiceDetail invoicedetail = new InvoiceDetail();
            invoicedetail.Invoice_ID =detail_id;
            invoicedetail.Product = product;
            invoicedetail.Quantity= quantity;
            invoicedetail.Discount = discount;
            invoicedetail.CalculateAmound();
            invoicedetail.CalculateIva();
            InvoiceDetails.Add(invoicedetail);
        }

        public void CalculateSubtotal()
        {
            Subtotal = InvoiceDetails.Sum(d => d.Amount);
        }

        public void CalcularTotalIva()
        {
            TotalIva = InvoiceDetails.Sum(d => d.CalculateIva());
        }

        public void CalculaTeTotal()
        {
            CalculateSubtotal();
            CalcularTotalIva();
           
            Total = Subtotal + TotalIva ;
        }



    }
}
