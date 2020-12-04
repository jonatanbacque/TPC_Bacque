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
                conexion.setearConsulta("Select Id, IdUsuario, IdCarrito, IdEnvio, IdMetodo, FechaCompra, ImporteFinal from COMPRA " +
                    "WHERE Condicion = 1");
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
        public List<Compra> listarActivas()
        {
            AccesoDatos conexion = new AccesoDatos();
            List<Compra> lista = new List<Compra>();
            try
            {
                conexion.abrirConexion();
                conexion.setearConsulta("Select c.Id, c.idUsuario, p.Nombre, p.Apellido, p.Direccion, c.idCarrito, e.id, ee.Nombre, " +
                    "me.Nombre, e.FechaEntrega, mp.id, mp.Nombre, c.FechaCompra, c.ImporteFinal from COMPRA as c " +
                    "INNER JOIN USUARIO as u on u.id = c.IdUsuario " +
                    "INNER JOIN PERSONA as p on p.id = u.IdPersona " +
                    "INNER JOIN ENVIO as e on e.id = c.idenvio " +
                    "INNER JOIN ESTADOENVIO as ee on ee.id = e.idestado " +
                    "INNER JOIN METODOENVIO as me on me.Id = e.IdMetodo " +
                    "INNER JOIN METODOPAGO as mp on mp.Id = c.IdMetodo " +
                    "WHERE c.Condicion = 1 AND ee.id != 0");
                conexion.ejecutarConsulta();

                while (conexion.Lector.Read())
                {
                    compra = new Compra()
                    {
                        Id = conexion.Lector.GetInt32(0),
                        usuario = new Usuario
                        {
                            Id = conexion.Lector.GetInt32(1),
                            persona = new Persona
                            {
                                Nombre = conexion.Lector.GetString(2),
                                Apellido = conexion.Lector.GetString(3),
                                Direccion = conexion.Lector.GetString(4)
                            }
                        },
                        carrito = new Carrito
                        {
                            Id = conexion.Lector.GetInt32(5)
                        },
                        envio = new Envio
                        {
                            Id = conexion.Lector.GetInt32(6),
                            estadoEnvio = new EstadoEnvio
                            {
                                Nombre = conexion.Lector.GetString(7)
                            },
                            metodoEnvio = new MetodoEnvio
                            {
                                Nombre = conexion.Lector.GetString(8)
                            },
                            fechaEntrega = conexion.Lector.GetDateTime(9)
                        },
                        metodoPago = new MetodoPago
                        {
                            Id = conexion.Lector.GetInt32(10),
                            Nombre = conexion.Lector.GetString(11)
                        },
                        FechaCompra = conexion.Lector.GetDateTime(12),
                        ImporteFinal = conexion.Lector.GetDecimal(13)
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
        public List<Compra> listarCanceladas()
        {
            AccesoDatos conexion = new AccesoDatos();
            List<Compra> lista = new List<Compra>();
            try
            {
                conexion.abrirConexion();
                conexion.setearConsulta("Select c.Id, c.idUsuario, p.Nombre, p.Apellido, p.Direccion, c.idCarrito, e.id, ee.Nombre, " +
                    "me.Nombre, e.FechaEntrega, mp.id, mp.Nombre, c.FechaCompra, c.ImporteFinal from COMPRA as c " +
                    "INNER JOIN USUARIO as u on u.id = c.IdUsuario " +
                    "INNER JOIN PERSONA as p on p.id = u.IdPersona " +
                    "INNER JOIN ENVIO as e on e.id = c.idenvio " +
                    "INNER JOIN ESTADOENVIO as ee on ee.id = e.idestado " +
                    "INNER JOIN METODOENVIO as me on me.Id = e.IdMetodo " +
                    "INNER JOIN METODOPAGO as mp on mp.Id = c.IdMetodo " +
                    "WHERE c.Condicion = 0 AND ee.id != 0");
                conexion.ejecutarConsulta();

                while (conexion.Lector.Read())
                {
                    compra = new Compra()
                    {
                        Id = conexion.Lector.GetInt32(0),
                        usuario = new Usuario
                        {
                            Id = conexion.Lector.GetInt32(1),
                            persona = new Persona
                            {
                                Nombre = conexion.Lector.GetString(2),
                                Apellido = conexion.Lector.GetString(3),
                                Direccion = conexion.Lector.GetString(4)
                            }
                        },
                        carrito = new Carrito
                        {
                            Id = conexion.Lector.GetInt32(5)
                        },
                        envio = new Envio
                        {
                            Id = conexion.Lector.GetInt32(6),
                            estadoEnvio = new EstadoEnvio
                            {
                                Nombre = conexion.Lector.GetString(7)
                            },
                            metodoEnvio = new MetodoEnvio
                            {
                                Nombre = conexion.Lector.GetString(8)
                            },
                            fechaEntrega = conexion.Lector.GetDateTime(9)
                        },
                        metodoPago = new MetodoPago
                        {
                            Id = conexion.Lector.GetInt32(10),
                            Nombre = conexion.Lector.GetString(11)
                        },
                        FechaCompra = conexion.Lector.GetDateTime(12),
                        ImporteFinal = conexion.Lector.GetDecimal(13)
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
                conexion.setearConsulta("Select c.Id, c.IdUsuario, c.IdCarrito, e.Id, es.Id, es.Nombre, e.FechaEntrega, " +
                    "c.IdMetodo, c.FechaCompra, c.ImporteFinal from COMPRA as c " +
                    "INNER JOIN ENVIO as e on e.id = c.IdEnvio " +
                    "INNER JOIN ESTADOENVIO as es on es.ID = e.IdEstado " +
                    "where c.Condicion = 1 AND c.IdUsuario = " + id.ToString());
                conexion.ejecutarConsulta();
                //
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
                            fechaEntrega = conexion.Lector.GetDateTime(6)
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
                conexion.abrirConexion();
                conexion.setearConsulta("Update COMPRA Set Condicion=0 Where Id=@id");
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


        public void modificar(Compra compra)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                string usuario = "";
                string carrito = "";
                string envio = "";
                string metodo = "";
                string fecha = "";
                string importe = "";
                if (compra.usuario != null)
                {
                    usuario = "IdUsuario=@idUsuario ";
                    if (compra.carrito != null || compra.metodoPago != null || compra.envio != null || compra.FechaCompra > Convert.ToDateTime("1-1-2000") || 
                        compra.ImporteFinal != 0) usuario = "IdUsuario=@idUsuario, ";
                }
                if (compra.carrito != null)
                {
                    carrito = "IdCarrito = @idCarrito ";
                    if (compra.envio != null || compra.metodoPago != null || compra.FechaCompra > Convert.ToDateTime("1-1-2000") || 
                        compra.ImporteFinal != 0) carrito = "IdCarrito = @idCarrito, ";
                }
                if (compra.envio != null)
                {
                    envio = "IdEnvio = @idEnvio ";
                    if (compra.metodoPago != null || compra.FechaCompra > Convert.ToDateTime("1-1-2000") ||
                        compra.ImporteFinal != 0) envio = "IdEnvio = @idEnvio, ";
                }
                if (compra.metodoPago != null)
                {
                    metodo = "IdMetodo = @IdMetodo ";
                    if (compra.FechaCompra > Convert.ToDateTime("1-1-2000") ||
                        compra.ImporteFinal != 0) metodo = "IdMetodo = @IdMetodo, ";
                }
                if (compra.FechaCompra > Convert.ToDateTime("1-1-2000"))
                {
                    fecha = "FechaCompra=@fechaCompra ";
                    if (compra.ImporteFinal != 0) fecha = "FechaCompra=@fechaCompra, ";
                }
                if (compra.ImporteFinal != 0) importe = "ImporteFinal=@importeFinal ";
                //
                conexion.abrirConexion();
                conexion.setearConsulta("Update COMPRA Set " + usuario + carrito + envio + metodo +fecha + importe +
                    " Where Condicion = 1 AND Id=@id");
                //
                conexion.Comando.Parameters.Clear();
                if (compra.usuario != null) 
                    conexion.Comando.Parameters.AddWithValue("@idUsuario", compra.usuario.Id);
                if (compra.carrito != null) 
                    conexion.Comando.Parameters.AddWithValue("@idCarrito", compra.carrito.Id);
                if (compra.envio != null) 
                    conexion.Comando.Parameters.AddWithValue("@idEnvio", compra.envio.Id);
                if (compra.metodoPago != null)
                    conexion.Comando.Parameters.AddWithValue("@idMetodo", compra.metodoPago.Id);
                if (compra.FechaCompra > Convert.ToDateTime("1-1-2000")) 
                    conexion.Comando.Parameters.AddWithValue("@fechaCompra", compra.FechaCompra);
                if (compra.ImporteFinal != 0) 
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
                conexion.setearConsulta("INSERT into COMPRA (IdCarrito) VALUES(@idCarrito)");
                //
                conexion.Comando.Parameters.Clear();
                conexion.Comando.Parameters.AddWithValue("@idCarrito", compra.carrito.Id);
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
        //public void agregar(Compra compra)
        //{
        //    AccesoDatos conexion = new AccesoDatos();
        //    try
        //    {
        //        //
        //        conexion.setearConsulta("INSERT into COMPRA (IdUsuario, IdCarrito, IdEnvio, IdMetodo, FechaCompra, ImporteFinal) " +
        //            "VALUES(@idUsuario, @idCarrito, @idEnvio, @idMetodo, @fechaCompra, @importeFinal)");
        //        //
        //        conexion.Comando.Parameters.Clear();
        //        conexion.Comando.Parameters.AddWithValue("@idUsuario", compra.usuario.Id);
        //        conexion.Comando.Parameters.AddWithValue("@idCarrito", compra.carrito.Id);
        //        conexion.Comando.Parameters.AddWithValue("@idEnvio", compra.envio.Id);
        //        conexion.Comando.Parameters.AddWithValue("@idMetodo", compra.metodoPago.Id);
        //        conexion.Comando.Parameters.AddWithValue("@fechaCompra", compra.FechaCompra);
        //        conexion.Comando.Parameters.AddWithValue("@importeFinal", compra.ImporteFinal);
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
    }
}
