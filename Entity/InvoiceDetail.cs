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
        public decimal TolalDetail { get; set; }
        public decimal Discount { get; set; }
        public decimal IVA { get; set; }

        public void CalculateTotalDetail()
        {
            TolalDetail = (Quantity * Product.UnitValue) * (1 - (Discount/100));
        }


        public decimal CalculateIva()
        {
            return TolalDetail * (Product.IVA  / 100) ;
        }

    }
}
