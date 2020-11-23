using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Elemento
    {
        public Elemento(Carrito carrito, Articulo articulo, int cantidad, decimal descuento)
        {
            this.carrito = carrito ?? throw new ArgumentNullException(nameof(carrito));
            this.articulo = articulo ?? throw new ArgumentNullException(nameof(articulo));
            Cantidad = cantidad;
            Descuento = descuento;
        }

        public Elemento() { }

        public Carrito carrito { get; set; }
        public Articulo articulo { get; set; }
        public int Cantidad { get; set; }
        public decimal Descuento { get; set; }

    }
}