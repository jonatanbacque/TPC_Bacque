using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class PersonaNegocio
    {
        Persona persona;
        public Persona listarID(int id)
        {
            AccesoDatos conexion = new AccesoDatos();
            List<Elemento> lista = new List<Elemento>();
            try
            {
                conexion.abrirConexion();
                conexion.setearConsulta("Select ID, Nombre, Apellido, DNI, Direccion, Email, Telefono, condicion from PERSONA " +
                    "Where Condicion = 1 and ID = " + id.ToString());
                conexion.ejecutarConsulta();

                while (conexion.Lector.Read())
                {
                    persona = new Persona()
                    {
                        Id = conexion.Lector.GetInt32(0),
                        Nombre = conexion.Lector.GetString(1),
                        Apellido = conexion.Lector.GetString(2),
                        DNI = conexion.Lector.GetInt32(3),
                        Direccion = conexion.Lector.GetString(4),
                        Email = conexion.Lector.GetString(5),
                        Telefono = conexion.Lector.GetInt32(6)
                    };
                }
                return persona;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }

        public void eliminar(int id)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                //
                //conexion.setearConsulta("Delete from Persona Where Id@id");
                conexion.setearConsulta("update Persona set Condicion = 0 Where Id@id");
                //
                conexion.Comando.Parameters.AddWithValue("@id", id);
                //
                conexion.abrirConexion();
                conexion.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }

        public void agregar(Persona persona)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                //
                conexion.setearConsulta("INSERT into PERSONA(Nombre, Apellido, DNI, Direccion, Email, Telefono, condicion) " +
                    "VALUES(@nombre, @apellido, @dNI, @direccion, @email, @telefono, @condicion)");
                //
                conexion.Comando.Parameters.Clear();
                conexion.Comando.Parameters.AddWithValue("@nombre", persona.Nombre);
                conexion.Comando.Parameters.AddWithValue("@apellido", persona.Apellido);
                conexion.Comando.Parameters.AddWithValue("@dNI", persona.DNI);
                conexion.Comando.Parameters.AddWithValue("@direccion", persona.Direccion);
                conexion.Comando.Parameters.AddWithValue("@email", persona.Email);
                conexion.Comando.Parameters.AddWithValue("@telefono", persona.Telefono);
                conexion.Comando.Parameters.AddWithValue("@condicion", 1);
                //
                conexion.abrirConexion();
                conexion.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }

        public int ultimo()
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                int ultimo = new int();
                //
                conexion.abrirConexion();
                conexion.setearConsulta("select top(1) id from PERSONA order by id desc");
                //
                conexion.ejecutarConsulta();

                while (conexion.Lector.Read())
                {
                    ultimo = conexion.Lector.GetInt32(0);
                }
                return ultimo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }
    }
}
