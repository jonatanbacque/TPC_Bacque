using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Envio
    {
        public Envio(int id, MetodoEnvio metodoEnvio, EstadoEnvio estadoEnvio, DateTime fechaEntrega)
        {
            Id = id;
            this.metodoEnvio = metodoEnvio;
            this.estadoEnvio = estadoEnvio;
            FechaEntrega = fechaEntrega;
        }
        public Envio() { }

        public int Id { get; set; }
        public MetodoEnvio metodoEnvio { get; set; }
        public EstadoEnvio estadoEnvio { get; set; }
        public DateTime FechaEntrega { get; set; }
    }
}
