using System;
using System.Collections.Generic;
using System.Linq;

namespace Entity
{
    public class Invoice
    {
        public int Invoice_ID { get; set; }
        public Client Client { get; set; }
        public string  InvoiceType { get;set; }
        public decimal Subtotal { get; set; }
        public decimal TotalIva { get; set; }
        public decimal Total { get; set; }
        public DateTime SaleDate { get; set; }
        public DateTime DueData { get; set; }

        public List<InvoiceDetail> InvoiceDetails;

        public Invoice()
        {
            InvoiceDetails = new List<InvoiceDetail>();
        }

        public void AgregarDetalleFactura(int invoice_id, Product product, decimal quantity, decimal discount, decimal IVA)
        {
            InvoiceDetail invoicedetail = new InvoiceDetail();
            invoicedetail.Invoice_ID = invoice_id;
            invoicedetail.Product = product;
            invoicedetail.NameProduct = product.Name;
            invoicedetail.UnitValue = product.UnitValue;
            invoicedetail.Quantity= quantity;
            invoicedetail.Discount = discount;
            invoicedetail.IVA = product.IVA;
            invoicedetail.CalculateTotalDetail();
            invoicedetail.CalculateIva();
            InvoiceDetails.Add(invoicedetail);
        }

        public void CalculateSubtotal()
        {
            Subtotal = InvoiceDetails.Sum(d => d.TolalDetail);
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
