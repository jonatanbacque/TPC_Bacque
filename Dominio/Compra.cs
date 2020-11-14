using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Compra
    {
        public int Id { get; set; }
        public string MetodoPago { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal Importe { get; set; }
    }
}
