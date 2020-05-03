using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public  class DetalleFactura
    {
        public string Factura_ID { get; set; }
        public Producto Productos { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Total { get; set; }
        public decimal Iva { get; set; }

        public void CalcularTotal()
        {
            Total = Cantidad * Productos.PrecioPorKg;
        }

        public decimal CalcularIva()
        {
            return Total * (Iva / 100); // iva que se aplica al detalle
        }

    }
}
