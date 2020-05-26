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
        public Producto Producto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Importe { get; set; }
        public decimal Descuento { get; set; }

        public void CalcularImporte()
        {
            Importe = (Cantidad * Producto.ValorUnitario) * (1 - (Descuento/100));
        }


        public decimal CalcularIva()
        {
            return Importe * (Producto.IVA  / 100) ; // iva que se aplica al detalle
        }

    }
}
