using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Factura
    {
        public string Factura_ID { get; set; }
        public DateTime FechaVenta { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public Cliente Cliente { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Descuento { get; set; }
        public decimal TotalDescuento { get; set; }
        public decimal TotalIva { get; set; }
        public decimal Total { get; set; }
        public List<DetalleFactura> DetalleFacturas;

        public Factura()
        {
            DetalleFacturas = new List<DetalleFactura>();
        }

        public void AgregarDetalleFactura(string detalle_id, Producto producto, int cantidad, decimal Iva)
        {
            DetalleFactura detalleFactura = new DetalleFactura();
            detalleFactura.Factura_ID = detalle_id;
            detalleFactura.Productos = producto;
            detalleFactura.Cantidad = cantidad;
            detalleFactura.CalcularTotal();
            detalleFactura.Iva = Iva;
            DetalleFacturas.Add(detalleFactura);
        }

        public void CalcularSubtotal()
        {
            Subtotal = DetalleFacturas.Sum(d => d.Total);
        }
        public void CalcularDescuento()
        {
            TotalDescuento = Subtotal * Descuento;
        }

        public void CalcularTotalIva()
        {
            TotalIva = DetalleFacturas.Sum(d => d.CalcularIva());
        }

        public void CalcularTotal()
        {
            CalcularSubtotal();
            CalcularTotalIva();
            CalcularDescuento();
            Total = Subtotal + TotalIva - TotalDescuento;
        }



    }
}
