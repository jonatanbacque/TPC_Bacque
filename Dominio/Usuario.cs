using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public Usuario(int id, Persona persona, string nombre, string password, int nivel)
        {
            Id = id;
            this.persona = persona;
            Nombre = nombre;
            Password = password;
            Nivel = nivel;
        }

        public Usuario() { }

        public int Id { get; set; }
        public Persona persona { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public int Nivel { get; set; }

        public override string ToString()//Al requerir un string de la clase Usuario devuelve el nombre
        {
            return persona.Apellido + ", " + persona.Nombre + ".";
        }
    }
}
