using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Producto
    {
        public string ID { get; set; }
        public string Nombre { get; set; }
        public decimal ValorUnitario { get; set; }
        public string UnidadMedida { get; set; }
        public float CantidadBodega { get; set; }
        public decimal IVA { get; set; }


    }
}
