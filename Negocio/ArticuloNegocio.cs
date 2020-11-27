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
                                        "c.Nombre, c.Detalle from ARTICULO as a INNER JOIN CATEGORIA as c on c.ID = a.IdCategoria");
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
                            Detalle = conexion.Lector.GetString(9),
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
                                        "c.Nombre, c.Detalle from ARTICULO as a INNER JOIN CATEGORIA as c on c.ID = a.IdCategoria " +
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
                            Detalle = conexion.Lector.GetString(9),
                        }
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
                conexion.setearConsulta("Select a.ID, a.Producto, a.Presentacion, a.Descripcion, a.ImagenUrl, a.Precio, a.Marca, c.ID, " +
                                        "c.Nombre, c.Detalle from ARTICULO as a INNER JOIN CATEGORIA as c on c.ID = a.IdCategoria " +
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
                            Detalle = conexion.Lector.GetString(9),
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
                                        "c.Nombre, c.Detalle from ARTICULO as a " +
                                        "INNER JOIN CATEGORIA as c on c.ID = a.IdCategoria " +
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
                            Detalle = conexion.Lector.GetString(9),
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
        public void modificar(Articulo articulo)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                //
                conexion.abrirConexion();
                conexion.setearConsulta("Update ARTICULO Set Producto=@producto, Presentacion=@Presentacion, Descripcion=@descripcion, " +
                                        "ImagenUrl=@imagenUrl, Precio=@precio, Marca=@marca, IdCategoria=@idCategoria Where Id=@id");
                //
                conexion.Comando.Parameters.Clear();
                conexion.Comando.Parameters.AddWithValue("@producto", articulo.Producto);
                conexion.Comando.Parameters.AddWithValue("@presentacion", articulo.Presentacion);
                conexion.Comando.Parameters.AddWithValue("@descripcion", articulo.Descripcion);
                conexion.Comando.Parameters.AddWithValue("@imagenURL", articulo.ImagenUrl);
                conexion.Comando.Parameters.AddWithValue("@precio", articulo.Precio);
                conexion.Comando.Parameters.AddWithValue("@marca", articulo.Marca);
                conexion.Comando.Parameters.AddWithValue("@idCategoria", articulo.categoria.Id);
                conexion.Comando.Parameters.AddWithValue("@iD", articulo.Id);
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
                conexion.setearConsulta("Delete from ARTICULO Where Id=@id");
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

        public void agregar(Articulo articulo)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                conexion.abrirConexion();
                conexion.setearConsulta("insert into ARTICULO (Producto, Presentacion, Descripcion, ImagenUrl, Precio, " +
                                        "Marca, IdCategoria) values (@Producto, @Presentacion, @Descripcion, @imagenURL, @precio, @marca, @idCategoria)");
                //
                conexion.Comando.Parameters.Clear();
                conexion.Comando.Parameters.AddWithValue("@producto", articulo.Producto);
                conexion.Comando.Parameters.AddWithValue("@presentacion", articulo.Presentacion);
                conexion.Comando.Parameters.AddWithValue("@descripcion", articulo.Descripcion);
                conexion.Comando.Parameters.AddWithValue("@imagenURL", articulo.ImagenUrl);
                conexion.Comando.Parameters.AddWithValue("@precio", articulo.Precio);
                conexion.Comando.Parameters.AddWithValue("@marca", articulo.Marca);
                conexion.Comando.Parameters.AddWithValue("@idCategoria", articulo.categoria.Id);
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
