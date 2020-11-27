using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class MetodoEnvio
    {
        public MetodoEnvio() { }

        public MetodoEnvio(int id, string nombre, string detalle, int demora, decimal precio, int condicion)
        {
            Id = id;
            Nombre = nombre;
            Detalle = detalle;
            Demora = demora;
            Precio = precio;
            Condicion = condicion;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Detalle { get; set; }
        public int Demora { get; set; }
        public decimal Precio { get; set; }
        public int Condicion { get; set; }

        public override string ToString()//Al requerir un string de la clase articulo devuelve el nombre
        {
            return Nombre;
        }
    }
}
