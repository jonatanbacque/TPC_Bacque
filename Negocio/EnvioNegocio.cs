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
                conexion.setearConsulta("select en.id, m.id, m.Nombre, m.detalle, m.demora, m.precio, e.id, e.nombre, e.detalle from ENVIO as en " +
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
                            Nombre = conexion.Lector.GetString(2),
                            Detalle = conexion.Lector.GetString(3),
                            Demora = conexion.Lector.GetInt32(4),
                            Precio = conexion.Lector.GetDecimal(5),
                        },
                        estadoEnvio = new EstadoEnvio
                        {
                            Id = conexion.Lector.GetInt32(6),
                            Nombre = conexion.Lector.GetString(7),
                            Detalle = conexion.Lector.GetString(8)
                        }
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

        public Envio listarID(int ID)
        {
            AccesoDatos conexion = new AccesoDatos();
            List<Envio> lista = new List<Envio>();
            try
            {
                conexion.abrirConexion();
                conexion.setearConsulta("select en.id, m.id, m.Nombre, m.detalle, m.demora, m.precio, e.id, e.nombre, e.detalle from ENVIO as en " +
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
                            Nombre = conexion.Lector.GetString(2),
                            Detalle = conexion.Lector.GetString(3),
                            Demora = conexion.Lector.GetInt32(4),
                            Precio = conexion.Lector.GetDecimal(5),
                        },
                        estadoEnvio = new EstadoEnvio
                        {
                            Id = conexion.Lector.GetInt32(6),
                            Nombre = conexion.Lector.GetString(7),
                            Detalle = conexion.Lector.GetString(8)
                        }
                    };
                }
                return envio;
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
                conexion.setearConsulta("select top(1) id from ENVIO order by id desc");
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
                conexion.setearConsulta("Delete from ENVIO Where Id=@id");
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
        public void modificar(Envio envio)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                //
                conexion.abrirConexion();
                conexion.setearConsulta("Update ENVIO Set IdMetodo=@idMetodo, IdEstado=@idEstado " +
                    "Where Id=@id");
                //
                conexion.Comando.Parameters.Clear();
                conexion.Comando.Parameters.AddWithValue("@idMetodo", envio.metodoEnvio.Id);
                conexion.Comando.Parameters.AddWithValue("@idEstado", envio.estadoEnvio.Id);
                conexion.Comando.Parameters.AddWithValue("@id", envio.Id);
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
        public void agregar(Envio envio)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                //
                conexion.setearConsulta("INSERT into ENVIO(IdMetodo, IdEstado) VALUES(@idMetodo, 1)");
                //
                conexion.Comando.Parameters.Clear();
                conexion.Comando.Parameters.AddWithValue("@idMetodo", envio.metodoEnvio.Id);
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
