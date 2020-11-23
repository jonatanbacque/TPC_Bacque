using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Persona
	{
        public Persona() { }

        public Persona(int id, string nombre, string apellido, string direccion, int dNI, string email, int telefono, int condicion)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Direccion = direccion;
            DNI = dNI;
            Email = email;
            Telefono = telefono;
            Condicion = condicion;
        }

        public int Id { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string Direccion { get; set; }
        public int DNI { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }
        public int Condicion { get; set; }
    }
}
