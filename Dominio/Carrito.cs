﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Carrito
    {
        public Carrito()
        {
            Id = 0;
            Importe = 0;
        }

        public int Id { get; set; }
        public decimal Importe { get; set; }

        public override string ToString()//Al requerir un string de la clase articulo devuelve el nombre
        {
            return Importe.ToString();
        }
    }
}
