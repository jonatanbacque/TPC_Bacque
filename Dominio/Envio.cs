using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Envio
    {
        public Envio(int id, MetodoEnvio metodoEnvio, string estado, DateTime fechaEntrega, decimal precio)
        {
            Id = id;
            this.metodoEnvio = metodoEnvio;
            Estado = estado;
            FechaEntrega = fechaEntrega;
            Precio = precio;
        }
        public Envio() { }

        public int Id { get; set; }
        public MetodoEnvio metodoEnvio { get; set; }
        public string Estado { get; set; }
        public DateTime FechaEntrega { get; set; }
        public decimal Precio { get; set; }
    }
}
