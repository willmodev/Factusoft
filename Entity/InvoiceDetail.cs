using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class InvoiceDetail
    {
        public int Invoice_ID { get; set; }
        public Product Product { get; set; }
        public string NameProduct {get;set;}
        public decimal UnitValue { get; set; }
        public decimal Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal IVA { get; set; }
        public decimal TolalDetail { get; set; }


        public void CalculateTotalDetail()
        {
            TolalDetail = Decimal.Round((Quantity * Product.UnitValue) * (1 - (Discount/100)), 1);
        }


        public decimal CalculateIva()
        {
            return TolalDetail * (Product.IVA  / 100) ;
        }

    }
}
