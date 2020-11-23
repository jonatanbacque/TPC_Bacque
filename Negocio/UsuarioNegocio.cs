using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class UsuarioNegocio
    {
        Usuario usuario;
        public Usuario listarID(int id)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                conexion.abrirConexion();
                conexion.setearConsulta("Select u.ID, p.ID, p.Nombre, p.Apellido, p.DNI, p.Direccion, " +
                    "p.Email, p.Telefono, p.condicion , u.nombre, u.password, u.nivel from USUARIO as u " +
                    "INNER JOIN PERSONA as p on p.id=u.idPersona " +
                    "Where u.ID = " + id.ToString() + " and p.condicion =1");
                conexion.ejecutarConsulta();

                while (conexion.Lector.Read())
                {
                    usuario = new Usuario()
                    {
                        Id = conexion.Lector.GetInt32(0),
                        persona = new Persona
                        {
                            Id = conexion.Lector.GetInt32(1),
                            Nombre = conexion.Lector.GetString(2),
                            Apellido = conexion.Lector.GetString(3),
                            DNI = conexion.Lector.GetInt32(4),
                            Direccion = conexion.Lector.GetString(5),
                            Email = conexion.Lector.GetString(6),
                            Telefono = conexion.Lector.GetInt32(7),
                            Condicion = conexion.Lector.GetInt32(8)
                        },
                        Nombre = conexion.Lector.GetString(9),
                        Password = conexion.Lector.GetString(10),
                        Nivel = conexion.Lector.GetInt32(11)
                    };
                }
                return usuario;
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

        public bool nombreOK(string nombre)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                conexion.abrirConexion();
                conexion.setearConsulta("Select ID from USUARIO Where Nombre = '" + nombre + "'");
                conexion.ejecutarConsulta();

                int aux = 0;

                while (conexion.Lector.Read())
                {
                    aux = conexion.Lector.GetInt32(0);
                }

                if (aux != 0) return false;
                else return true;
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

        //public void eliminar(int id)
        //{
        //    AccesoDatos conexion = new AccesoDatos();
        //    try
        //    {
        //        //
        //        //conexion.setearConsulta("Delete from Persona Where Id@id");
        //        conexion.setearConsulta("update Usuario set Condicion = 0 Where Id@id");
        //        //
        //        conexion.Comando.Parameters.AddWithValue("@id", id);
        //        //
        //        conexion.abrirConexion();
        //        conexion.ejecutarAccion();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        conexion.cerrarConexion();
        //    }
        //}

        public void agregar(Usuario usuario)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                //
                conexion.setearConsulta("INSERT into Usuario(IdPersona, Nombre, Password, Nivel) " +
                    "VALUES(@idPersona, @nombre, @password, @nivel)");
                //
                conexion.Comando.Parameters.Clear();
                conexion.Comando.Parameters.AddWithValue("@idpersona", usuario.persona.Id);
                conexion.Comando.Parameters.AddWithValue("@nombre", usuario.Nombre);
                conexion.Comando.Parameters.AddWithValue("@password", usuario.Password);
                conexion.Comando.Parameters.AddWithValue("@nivel", usuario.Nivel);
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
        public int loguear(Usuario usuario)//Devuelve ID
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                int id=0;
                //
                conexion.abrirConexion();
                conexion.setearConsulta("Select Id, Nombre, Password from Usuario " +
                    "Where Nombre = '" + usuario.Nombre + "' and Password = '" + usuario.Password + "'");
                conexion.ejecutarConsulta();
                //
                while (conexion.Lector.Read())
                {
                    id = conexion.Lector.GetInt32(0);
                }
                //
                return id;
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
