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
        public decimal UnitValue { get; set; }
        public float Quantity { get; set; }
        public float Discount { get; set; }
        public decimal TolalDetail { get; set; }

       
        public InvoiceDetail(Product product, float quantity, float discount, decimal price)
        {
            Product = product;
            UnitValue = price;
            Quantity = quantity;
            Discount = discount;
            CalculateTotalDetail();
            CalculateIva();
        }

        public InvoiceDetail() {}

        public void CalculateTotalDetail()
        {
            
            TolalDetail = Decimal.Round((((decimal)Quantity) * Product.SalePrice) * (1 - ((decimal)Discount/100)), 1);
        }


        public decimal CalculateIva()
        {
            return TolalDetail * (Product.IVA  / 100) ;
        }

    }
}
