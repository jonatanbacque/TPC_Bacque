using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Compra
    {
        public Compra(int id, Usuario usuario, Carrito carrito, Envio envio, MetodoPago metodoPago, DateTime fechaCompra, decimal importeFinal)
        {
            Id = id;
            this.usuario = usuario;
            this.carrito = carrito;
            this.envio = envio;
            this.metodoPago = metodoPago;
            FechaCompra = fechaCompra;
            ImporteFinal = importeFinal;
        }
        public Compra() { }

        public int Id { get; set; }
        public Usuario usuario { get; set; }
        public Carrito carrito { get; set; }
        public Envio envio { get; set; }
        public MetodoPago metodoPago  { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal ImporteFinal { get; set; }
    }
}
