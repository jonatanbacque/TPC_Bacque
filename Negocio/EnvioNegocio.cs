using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Negocio;

namespace Negocio
{
    public class EnvioNegocio
    {
        Envio envio;
        public List<Envio> listar()
        {
            AccesoDatos conexion = new AccesoDatos();
            List<Envio> lista = new List<Envio>();
            try
            {
                conexion.abrirConexion();
                conexion.setearConsulta("select en.id, m.id, m.Nombre, e.id, e.nombre, en.FechaEntrega from ENVIO as en " +
                    "INNER JOIN METODOENVIO as m on m.id = en.IdMetodo " +
                    "INNER JOIN ESTADOENVIO as e on e.id = en.IdEstado");
                conexion.ejecutarConsulta();

                while (conexion.Lector.Read())
                {
                    envio = new Envio()
                    {
                        Id = conexion.Lector.GetInt32(0),
                        metodoEnvio = new MetodoEnvio
                        {
                            Id = conexion.Lector.GetInt32(1),
                            Nombre = conexion.Lector.GetString(2)
                        },
                        estadoEnvio = new EstadoEnvio
                        {
                            Id = conexion.Lector.GetInt32(3),
                            Nombre = conexion.Lector.GetString(4)
                        },
                        FechaEntrega = conexion.Lector.GetDateTime(4)
                    };

                    lista.Add(envio);

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
            List<Envio> lista = new List<Envio>();
            try
            {
                conexion.abrirConexion();
                conexion.setearConsulta("select en.id, m.id, m.Nombre, e.id, e.nombre, en.FechaEntrega from ENVIO as en " +
                    "INNER JOIN METODOENVIO as m on m.id = en.IdMetodo " +
                    "INNER JOIN ESTADOENVIO as e on e.id = en.IdEstado " +
                    "WHERE en.id = " + ID.ToString());
                conexion.ejecutarConsulta();

                while (conexion.Lector.Read())
                {
                    envio = new Envio()
                    {
                        Id = conexion.Lector.GetInt32(0),
                        metodoEnvio = new MetodoEnvio
                        {
                            Id = conexion.Lector.GetInt32(1),
                            Nombre = conexion.Lector.GetString(2)
                        },
                        estadoEnvio = new EstadoEnvio
                        {
                            Id = conexion.Lector.GetInt32(3),
                            Nombre = conexion.Lector.GetString(4)
                        },
                        FechaEntrega = conexion.Lector.GetDateTime(4)
                    };

                    lista.Add(envio);

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
