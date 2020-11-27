using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ListaCompra
    {
        public int ID { get; set; }
        public string Estado { get; set; }
        public string ImagenUrl { get; set; }
        public DateTime FechaEntrega { get; set; }
        public decimal Precio { get; set; }
    }
}
