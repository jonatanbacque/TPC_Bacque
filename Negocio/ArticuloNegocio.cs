using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Negocio
{
    public class ArticuloNegocio
    {
        Articulo articulo;
        public List<Articulo> listar()
        {
            AccesoDatos conexion = new AccesoDatos();
            List<Articulo> lista = new List<Articulo>();
            try
            {
                conexion.abrirConexion();
                conexion.setearConsulta("Select a.ID, a.Nombre, a.Descripcion, a.ImagenUrl, a.Precio, a.Marca, c.Nombre from ARTICULO as a " +
                                        "INNER JOIN CATEGORIA as c on c.Id = a.IdCategoria");
                conexion.ejecutarConsulta();

                while (conexion.Lector.Read())
                {
                    articulo = new Articulo
                    {
                        Id = conexion.Lector.GetInt32(0),
                        Nombre = conexion.Lector.GetString(1),
                        Descripcion = conexion.Lector.GetString(2),
                        ImagenUrl = conexion.Lector.GetString(3),
                        Precio = conexion.Lector.GetDecimal(4),
                        Marca = conexion.Lector.GetString(5),
                        Categoria = conexion.Lector.GetString(6),
                    };

                    lista.Add(articulo);

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

        public Articulo listarID(int ID)
        {
            AccesoDatos conexion = new AccesoDatos();
            List<Articulo> lista = new List<Articulo>();
            try
            {
                conexion.abrirConexion();
                conexion.setearConsulta("Select a.ID, a.Nombre, a.Descripcion, a.ImagenUrl, a.Precio, a.Marca, c.Nombre from ARTICULO as a " +
                                        "INNER JOIN CATEGORIA as c on c.Id = a.IdCategoria where a.id =" + ID);
                conexion.ejecutarConsulta();

                while (conexion.Lector.Read())
                {
                    articulo = new Articulo
                    {
                        Id = conexion.Lector.GetInt32(0),
                        Nombre = conexion.Lector.GetString(1),
                        Descripcion = conexion.Lector.GetString(2),
                        ImagenUrl = conexion.Lector.GetString(3),
                        Precio = conexion.Lector.GetDecimal(4),
                        Marca = conexion.Lector.GetString(5),
                        Categoria = conexion.Lector.GetString(6),
                    };
                }
                return articulo;
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

        public List<Articulo> Buscar(string nombre)
        {
            AccesoDatos conexion = new AccesoDatos();
            List<Articulo> lista = new List<Articulo>();
            try
            {
                conexion.abrirConexion();
                conexion.setearConsulta("Select a.ID, a.Nombre, a.Descripcion, a.ImagenUrl, a.Precio, a.Marca, c.Nombre from ARTICULO as a " +
                                        "INNER JOIN CATEGORIA as c on c.Id = a.IdCategoria WHERE a.nombre LIKE '%" + nombre + "%'");
                conexion.ejecutarConsulta();

                while (conexion.Lector.Read())
                {
                    articulo = new Articulo
                    {
                        Id = conexion.Lector.GetInt32(0),
                        Nombre = conexion.Lector.GetString(1),
                        Descripcion = conexion.Lector.GetString(2),
                        ImagenUrl = conexion.Lector.GetString(3),
                        Precio = conexion.Lector.GetDecimal(4),
                        Marca = conexion.Lector.GetString(5),
                        Categoria = conexion.Lector.GetString(6),
                    };

                    lista.Add(articulo);

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

        public List<Articulo> BuscarCateg(string nombre)
        {
            AccesoDatos conexion = new AccesoDatos();
            List<Articulo> lista = new List<Articulo>();
            try
            {
                conexion.abrirConexion();
                conexion.setearConsulta("Select a.ID, a.Nombre, a.Descripcion, a.ImagenUrl, a.Precio, a.Marca, c.Nombre from ARTICULO as a " +
                                        "INNER JOIN CATEGORIA as c on c.Id = a.IdCategoria WHERE c.nombre LIKE '%" + nombre + "%'");
                conexion.ejecutarConsulta();

                while (conexion.Lector.Read())
                {
                    articulo = new Articulo
                    {
                        Id = conexion.Lector.GetInt32(0),
                        Nombre = conexion.Lector.GetString(1),
                        Descripcion = conexion.Lector.GetString(2),
                        ImagenUrl = conexion.Lector.GetString(3),
                        Precio = conexion.Lector.GetDecimal(4),
                        Marca = conexion.Lector.GetString(5),
                        Categoria = conexion.Lector.GetString(6),
                    };

                    lista.Add(articulo);

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
    }
}
