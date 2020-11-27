using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ElementoNegocio
    {
        Elemento elemento;
        CarritoNegocio carritoNegocio = new CarritoNegocio();
        ArticuloNegocio articuloNegocio = new ArticuloNegocio();
        public List<Elemento> listar()
        {
            AccesoDatos conexion = new AccesoDatos();
            List<Elemento> lista = new List<Elemento>();
            try
            {
                conexion.abrirConexion();
                conexion.setearConsulta("Select ca.Id, ca.Importe, a.ID, a.Producto, a.Presentacion, a.Descripcion, " +
                    "a.ImagenUrl, a.Precio, a.Marca, c.ID, c.Nombre, c.Detalle, e.cantidad from Elemento as e " +
                    "INNER JOIN ARTICULO as a on a.id = e.idArticulo " +
                    "INNER JOIN CATEGORIA as c on c.ID = a.IdCategoria " +
                    "INNER JOIN CARRITO as ca on ca.id = e.idCarrito");
                conexion.ejecutarConsulta();

                while (conexion.Lector.Read())
                {
                    elemento = new Elemento()
                    { 
                        carrito = new Carrito
                        {
                            Id = conexion.Lector.GetInt32(0),
                            Importe = conexion.Lector.GetDecimal(1)
                        },


                        articulo = new Articulo
                        {
                            Id = conexion.Lector.GetInt32(2),
                            Producto = conexion.Lector.GetString(3),
                            Presentacion = conexion.Lector.GetString(4),
                            Descripcion = conexion.Lector.GetString(5),
                            ImagenUrl = conexion.Lector.GetString(6),
                            Precio = conexion.Lector.GetDecimal(7),
                            Marca = conexion.Lector.GetString(8),

                            categoria = new Categoria
                            {
                                Id = conexion.Lector.GetInt32(9),
                                Nombre = conexion.Lector.GetString(10),
                                Detalle = conexion.Lector.GetString(11),
                            }
                        },

                        Cantidad = conexion.Lector.GetInt32(12)
                    };

                    lista.Add(elemento);

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

        public List<Elemento> listarID(int ID)
        {
            AccesoDatos conexion = new AccesoDatos();
            List<Elemento> lista = new List<Elemento>();
            try
            {
                conexion.abrirConexion();
                conexion.setearConsulta("Select ca.Id, ca.Importe, a.ID, a.Producto, a.Presentacion, a.Descripcion, " +
                    "a.ImagenUrl, a.Precio, a.Marca, c.ID, c.Nombre, c.Detalle, e.cantidad from Elemento as e " +
                    "INNER JOIN ARTICULO as a on a.id = e.idArticulo " +
                    "INNER JOIN CATEGORIA as c on c.ID = a.IdCategoria " +
                    "INNER JOIN CARRITO as ca on ca.id = e.idCarrito " +
                    "WHERE ca.ID =" + ID);
                conexion.ejecutarConsulta();

                while (conexion.Lector.Read())
                {
                    elemento = new Elemento
                    {
                        carrito = new Carrito
                        {
                            Id = conexion.Lector.GetInt32(0),
                            Importe = conexion.Lector.GetDecimal(1)
                        },


                        articulo = new Articulo
                        {
                            Id = conexion.Lector.GetInt32(2),
                            Producto = conexion.Lector.GetString(3),
                            Presentacion = conexion.Lector.GetString(4),
                            Descripcion = conexion.Lector.GetString(5),
                            ImagenUrl = conexion.Lector.GetString(6),
                            Precio = conexion.Lector.GetDecimal(7),
                            Marca = conexion.Lector.GetString(8),

                            categoria = new Categoria
                            {
                                Id = conexion.Lector.GetInt32(9),
                                Nombre = conexion.Lector.GetString(10),
                                Detalle = conexion.Lector.GetString(11),
                            }
                        },

                        Cantidad = conexion.Lector.GetInt32(12)

                    };

                    lista.Add(elemento);
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

        public void eliminarCarrito(int idCarrito)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                //
                conexion.setearConsulta("Delete from ELEMENTO Where IdCarrito=@idCarrito");
                //
                conexion.Comando.Parameters.AddWithValue("@idCarrito", idCarrito);
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

        public void eliminarArticulo(int idCarrito, int idArticulo)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                //
                conexion.setearConsulta("Delete from ELEMENTO Where IdArticulo=@idArticulo and IdCarrito=@idCarrito");
                //
                conexion.Comando.Parameters.AddWithValue("@idCarrito", idCarrito);
                conexion.Comando.Parameters.AddWithValue("@idArticulo", idArticulo);
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

        public void agregarArticulo(Elemento elemento)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                //
                conexion.setearConsulta("IF (EXISTS (SELECT * from ELEMENTO WHERE IdCarrito=@idCarrito and IdArticulo=@idArticulo)) " +
                    "BEGIN update ELEMENTO set Cantidad = (select SUM(cantidad) FROM ELEMENTO " +
                    "WHERE IdCarrito = @idCarrito and IdArticulo = @idArticulo) + @cantidad " +
                    "WHERE IdCarrito = @idCarrito and IdArticulo = @idArticulo END " +
                    "ELSE BEGIN INSERT into ELEMENTO(IdCarrito, IdArticulo, Cantidad) VALUES(@idCarrito, @idArticulo, @cantidad) END");
                //
                conexion.Comando.Parameters.Clear();
                conexion.Comando.Parameters.AddWithValue("@idCarrito", elemento.carrito.Id);
                conexion.Comando.Parameters.AddWithValue("@idArticulo", elemento.articulo.Id);
                conexion.Comando.Parameters.AddWithValue("@cantidad", elemento.Cantidad);
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
    }
}
