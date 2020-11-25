﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class MetodoPago
    {
        public MetodoPago(int id, string nombre, string detalle)
        {
            Id = id;
            Nombre = nombre;
            Detalle = detalle;
        }
        public MetodoPago() { }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Detalle { get; set; }

        public override string ToString()//Al requerir un string de la clase articulo devuelve el nombre
        {
            return Nombre;
        }
    }
}