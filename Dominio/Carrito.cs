﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Carrito
    {   
        public int Id { get; set; }
        public Usuario usuario { get; set; }
        public Envio envio { get; set; }
        public Compra compra { get; set; }
    }
}
