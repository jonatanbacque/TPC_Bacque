using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulo
    {

        public Articulo() { }

        public Articulo(int id, string producto, string presentacion, string descripcion, string imagenUrl, decimal precio, string marca, Categoria categoria, int condicion)
        {
            Id = id;
            Producto = producto;
            Presentacion = presentacion;
            Descripcion = descripcion;
            ImagenUrl = imagenUrl;
            Precio = precio;
            Marca = marca;
            this.categoria = categoria;
            Condicion = condicion;
        }

        public int Id { get; set; }
        public string Producto { get; set; }
        public string Presentacion { get; set; }
        public string Descripcion { get; set; }
        public string ImagenUrl { get; set; }
        public decimal Precio { get; set; }
        public string Marca { get; set; }
        public Categoria categoria { get; set; }
        public int Condicion { get; set; }

        public override string ToString()//Al requerir un string de la clase articulo devuelve el nombre
        {
            return Producto + ", " + Marca + ".";
        }
    }
}
