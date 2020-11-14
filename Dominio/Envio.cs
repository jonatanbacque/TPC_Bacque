using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Envio
    {
        public int Id { get; set; }
        public string Metodo { get; set; }
        public string Estado { get; set; }
        public DateTime FechaEntrega { get; set; }
        public decimal Precio { get; set; }
    }
}
