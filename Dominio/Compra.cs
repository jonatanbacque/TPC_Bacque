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
        public Usuario usuario { get; set; }
        public Carrito carrito { get; set; }
        public Envio envio { get; set; }
        public string MetodoPago { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal ImporteFinal { get; set; }
    }
}
