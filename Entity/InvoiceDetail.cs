using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public  class InvoiceDetail
    {
        public string Invoice_ID { get; set; }
        public Product Product { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public decimal Discount { get; set; }

        public void CalculateAmound()
        {
            Amount = (Quantity * Product.UnitValue) * (1 - (Discount/100));
        }


        public decimal CalculateIva()
        {
            return Amount * (Product.IVA  / 100) ;
        }

    }
}
