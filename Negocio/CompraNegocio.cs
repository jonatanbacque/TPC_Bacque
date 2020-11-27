using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Negocio;

namespace Negocio
{
    public class CompraNegocio
    {
        Compra compra;
        public List<Compra> listar()
        {
            AccesoDatos conexion = new AccesoDatos();
            List<Compra> lista = new List<Compra>();
            try
            {
                conexion.abrirConexion();
                conexion.setearConsulta("Select Id, IdUsuario, IdCarrito, IdEnvio, IdMetodo, FechaCompra, ImporteFinal from COMPRA");
                conexion.ejecutarConsulta();

                while (conexion.Lector.Read())
                {
                    compra = new Compra()
                    {
                        Id = conexion.Lector.GetInt32(0),
                        usuario = new Usuario
                        {
                            Id = conexion.Lector.GetInt32(1)
                        },
                        carrito = new Carrito
                        {
                            Id = conexion.Lector.GetInt32(2)
                        },
                        envio = new Envio
                        {
                            Id = conexion.Lector.GetInt32(3)
                        },
                        metodoPago = new MetodoPago
                        {
                            Id = conexion.Lector.GetInt32(4)
                        },
                        FechaCompra = conexion.Lector.GetDateTime(5),
                        ImporteFinal = conexion.Lector.GetDecimal(6)
                    };

                    lista.Add(compra);

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
        public List<Compra> listarXusuario(int id)
        {
            AccesoDatos conexion = new AccesoDatos();
            List<Compra> lista = new List<Compra>();
            try
            {
                conexion.abrirConexion();
                conexion.setearConsulta("Select c.Id, c.IdUsuario, c.IdCarrito, e.Id, es.Id, es.Nombre, e.FechaEntrega, c.IdMetodo, c.FechaCompra, " +
                    "c.ImporteFinal from COMPRA as c " +
                    "INNER JOIN ENVIO as e on e.id = c.IdEnvio " +
                    "INNER JOIN ESTADOENVIO as es on es.ID = e.IdEstado " +
                    "where IdUsuario = " + id.ToString());
                conexion.ejecutarConsulta();

                while (conexion.Lector.Read())
                {
                    compra = new Compra()
                    {
                        Id = conexion.Lector.GetInt32(0),
                        usuario = new Usuario
                        {
                            Id = conexion.Lector.GetInt32(1)
                        },
                        carrito = new Carrito
                        {
                            Id = conexion.Lector.GetInt32(2)
                        },
                        envio = new Envio
                        {
                            Id = conexion.Lector.GetInt32(3),
                            estadoEnvio = new EstadoEnvio
                            {
                                Id = conexion.Lector.GetInt32(4),
                                Nombre = conexion.Lector.GetString(5)
                            },
                            fechaEntrega= conexion.Lector.GetDateTime(6)
                        },
                        metodoPago = new MetodoPago
                        {
                            Id = conexion.Lector.GetInt32(7)
                        },
                        FechaCompra = conexion.Lector.GetDateTime(8),
                        ImporteFinal = conexion.Lector.GetDecimal(9)
                    };

                    lista.Add(compra);

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

        public Compra listarID(int ID)
        {
            AccesoDatos conexion = new AccesoDatos();
            List<Compra> lista = new List<Compra>();
            try
            {
                conexion.abrirConexion();
                conexion.setearConsulta("Select Id, IdUsuario, IdCarrito, IdEnvio, IdMetodo, FechaCompra, ImporteFinal from COMPRA " +
                    "Where ID = " + ID.ToString());
                conexion.ejecutarConsulta();

                while (conexion.Lector.Read())
                {
                    compra = new Compra()
                    {
                        Id = conexion.Lector.GetInt32(0),
                        usuario = new Usuario
                        {
                            Id = conexion.Lector.GetInt32(1)
                        },
                        carrito = new Carrito
                        {
                            Id = conexion.Lector.GetInt32(2)
                        },
                        envio = new Envio
                        {
                            Id = conexion.Lector.GetInt32(3)
                        },
                        metodoPago = new MetodoPago
                        {
                            Id = conexion.Lector.GetInt32(4)
                        },
                        FechaCompra = conexion.Lector.GetDateTime(5),
                        ImporteFinal = conexion.Lector.GetDecimal(6)
                    };
                }
                return compra;
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
                int ultimo = 0;

                conexion.abrirConexion();
                conexion.setearConsulta("select top(1) id from COMPRA order by id desc");
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

        public void eliminar(int id)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                //
                conexion.setearConsulta("Delete from COMPRA Where Id=@id");
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
        public void modificar(Compra compra)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                //
                conexion.abrirConexion();
                conexion.setearConsulta("Update COMPRA Set IdUsuario=@idUsuario, IdCarrito=@idCarrito, IdEnvio=@idEnvio, " +
                    "FechaCompra=@fechaCompra, ImporteFinal=@importeFinal Where Id=@id");
                //
                conexion.Comando.Parameters.Clear();
                conexion.Comando.Parameters.AddWithValue("@idUsuario", compra.usuario.Id);
                conexion.Comando.Parameters.AddWithValue("@idCarrito", compra.carrito.Id);
                conexion.Comando.Parameters.AddWithValue("@idEnvio", compra.envio.Id);
                conexion.Comando.Parameters.AddWithValue("@fechaCompra", compra.FechaCompra);
                conexion.Comando.Parameters.AddWithValue("@importeFinal", compra.ImporteFinal);
                conexion.Comando.Parameters.AddWithValue("@id", compra.Id);
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
        public void agregar(Compra compra)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                //
                conexion.setearConsulta("INSERT into COMPRA (IdUsuario, IdCarrito, IdEnvio, IdMetodo, FechaCompra, ImporteFinal) " +
                    "VALUES(@idUsuario, @idCarrito, @idEnvio, @idMetodo, @fechaCompra, @importeFinal)");
                //
                conexion.Comando.Parameters.Clear();
                conexion.Comando.Parameters.AddWithValue("@idUsuario", compra.usuario.Id);
                conexion.Comando.Parameters.AddWithValue("@idCarrito", compra.carrito.Id);
                conexion.Comando.Parameters.AddWithValue("@idEnvio", compra.envio.Id);
                conexion.Comando.Parameters.AddWithValue("@idMetodo", compra.metodoPago.Id);
                conexion.Comando.Parameters.AddWithValue("@fechaCompra", compra.FechaCompra);
                conexion.Comando.Parameters.AddWithValue("@importeFinal", compra.ImporteFinal);
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
