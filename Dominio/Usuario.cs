using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public int Id { get; set; }
        public Persona persona { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Nivel { get; set; }

        public override string ToString()//Al requerir un string de la clase Usuario devuelve el nombre
        {
            return persona.Apellido + ", " + persona.Nombre + ".";
        }
    }
}
