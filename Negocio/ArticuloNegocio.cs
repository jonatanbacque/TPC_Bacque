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
                conexion.setearConsulta("Select a.ID, a.Producto, a.Presentacion, a.Descripcion, a.ImagenUrl, a.Precio, a.Marca, c.ID, " +
                                        "c.Nombre, c.Descripcion from ARTICULO as a INNER JOIN CATEGORIA as c on c.ID = a.IdCategoria");
                conexion.ejecutarConsulta();

                while (conexion.Lector.Read())
                {
                    articulo = new Articulo
                    {
                        Id = conexion.Lector.GetInt32(0),
                        Producto = conexion.Lector.GetString(1),
                        Presentacion = conexion.Lector.GetString(2),
                        Descripcion = conexion.Lector.GetString(3),
                        ImagenUrl = conexion.Lector.GetString(4),
                        Precio = conexion.Lector.GetDecimal(5),
                        Marca = conexion.Lector.GetString(6),

                        categoria = new Categoria
                        {
                            Id = conexion.Lector.GetInt32(7),
                            Nombre = conexion.Lector.GetString(8),
                            Descripcion = conexion.Lector.GetString(9),
                        }
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
                conexion.setearConsulta("Select a.ID, a.Producto, a.Presentacion, a.Descripcion, a.ImagenUrl, a.Precio, a.Marca, c.ID, " +
                                        "c.Nombre, c.Descripcion from ARTICULO as a INNER JOIN CATEGORIA as c on c.ID = a.IdCategoria " +
                                        "WHERE a.ID =" + ID);
                conexion.ejecutarConsulta();

                while (conexion.Lector.Read())
                {
                    articulo = new Articulo
                    {
                        Id = conexion.Lector.GetInt32(0),
                        Producto = conexion.Lector.GetString(1),
                        Presentacion = conexion.Lector.GetString(2),
                        Descripcion = conexion.Lector.GetString(3),
                        ImagenUrl = conexion.Lector.GetString(4),
                        Precio = conexion.Lector.GetDecimal(5),
                        Marca = conexion.Lector.GetString(6),

                        categoria = new Categoria
                        {
                            Id = conexion.Lector.GetInt32(7),
                            Nombre = conexion.Lector.GetString(8),
                            Descripcion = conexion.Lector.GetString(9),
                        }
                    };

                    lista.Add(articulo);

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
                conexion.setearConsulta("Select a.ID, a.Producto, a.Presentacion, a.Descripcion, a.ImagenUrl, a.Precio, a.Marca, c.ID, " +
                                        "c.Nombre, c.Descripcion from ARTICULO as a INNER JOIN CATEGORIA as c on c.ID = a.IdCategoria " +
                                        "WHERE a.Producto LIKE '%" + nombre + "%'");
                conexion.ejecutarConsulta();

                while (conexion.Lector.Read())
                {
                    articulo = new Articulo
                    {
                        Id = conexion.Lector.GetInt32(0),
                        Producto = conexion.Lector.GetString(1),
                        Presentacion = conexion.Lector.GetString(2),
                        Descripcion = conexion.Lector.GetString(3),
                        ImagenUrl = conexion.Lector.GetString(4),
                        Precio = conexion.Lector.GetDecimal(5),
                        Marca = conexion.Lector.GetString(6),

                        categoria = new Categoria
                        {
                            Id = conexion.Lector.GetInt32(7),
                            Nombre = conexion.Lector.GetString(8),
                            Descripcion = conexion.Lector.GetString(9),
                        }
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
                conexion.setearConsulta("Select a.ID, a.Producto, a.Presentacion, a.Descripcion, a.ImagenUrl, a.Precio, a.Marca, c.ID, " +
                                        "c.Nombre, c.Descripcion from ARTICULO as a INNER JOIN CATEGORIA as c on c.ID = a.IdCategoria " +
                                        "WHERE c.nombre LIKE '%" + nombre + "%'");
                conexion.ejecutarConsulta();

                while (conexion.Lector.Read())
                {
                    articulo = new Articulo
                    {
                        Id = conexion.Lector.GetInt32(0),
                        Producto = conexion.Lector.GetString(1),
                        Presentacion = conexion.Lector.GetString(2),
                        Descripcion = conexion.Lector.GetString(3),
                        ImagenUrl = conexion.Lector.GetString(4),
                        Precio = conexion.Lector.GetDecimal(5),
                        Marca = conexion.Lector.GetString(6),

                        categoria = new Categoria
                        {
                            Id = conexion.Lector.GetInt32(7),
                            Nombre = conexion.Lector.GetString(8),
                            Descripcion = conexion.Lector.GetString(9),
                        }
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
