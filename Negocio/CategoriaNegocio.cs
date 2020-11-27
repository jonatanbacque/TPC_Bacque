using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Negocio;

namespace Negocio
{
    public class CategoriaNegocio
    {
        AccesoDatos conexion = new AccesoDatos();
        List<Categoria> lista = new List<Categoria>();

        Categoria categoria;
        public List<Categoria> listar()
        {

            try
            {
                conexion.abrirConexion();
                conexion.setearConsulta("Select ID, Nombre, Detalle from CATEGORIA WHERE Condicion = 1");
                conexion.ejecutarConsulta();

                while (conexion.Lector.Read())
                {
                    categoria = new Categoria
                    {
                        Id = conexion.Lector.GetInt32(0),
                        Nombre = conexion.Lector.GetString(1),
                        Detalle = conexion.Lector.GetString(2),
                    };

                    lista.Add(categoria);

                }
                return lista;
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

        public Categoria listarID(int id)
        {

            try
            {
                conexion.abrirConexion();
                conexion.setearConsulta("Select ID, Nombre, Detalle from CATEGORIA " +
                    "WHERE Condicion = 1 and ID =" + id.ToString());
                conexion.ejecutarConsulta();

                while (conexion.Lector.Read())
                {
                    categoria = new Categoria
                    {
                        Id = conexion.Lector.GetInt32(0),
                        Nombre = conexion.Lector.GetString(1),
                        Detalle = conexion.Lector.GetString(2)
                    };

                }
                return categoria;
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

        public void modificar(Categoria categoria)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                //
                conexion.abrirConexion();
                conexion.setearConsulta("Update CATEGORIA Set Nombre=@nombre, Detalle=@Detalle Where Id=@id");
                //
                conexion.Comando.Parameters.Clear();
                conexion.Comando.Parameters.AddWithValue("@nombre", categoria.Nombre);
                conexion.Comando.Parameters.AddWithValue("@detalle", categoria.Detalle);
                conexion.Comando.Parameters.AddWithValue("@id", categoria.Id);
                //
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

        public void eliminar(int id)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                //
                conexion.abrirConexion();
                conexion.setearConsulta("Update CATEGORIA Set Condicion=0 Where Id=@id");
                //
                conexion.Comando.Parameters.AddWithValue("@id", id);
                //
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

        public void agregar(Categoria categoria)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                conexion.abrirConexion();
                conexion.setearConsulta("INSERT INTO CATEGORIA (Nombre, Detalle, Condicion) " +
                    "VALUES (@nombre, @detalle, 1)");
                //
                conexion.Comando.Parameters.Clear();
                conexion.Comando.Parameters.AddWithValue("@nombre", categoria.Nombre);
                conexion.Comando.Parameters.AddWithValue("@detalle", categoria.Detalle);
                //
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
    }
}
