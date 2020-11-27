using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class EstadoEnvioNegocio
    {
        AccesoDatos conexion = new AccesoDatos();
        List<EstadoEnvio> lista = new List<EstadoEnvio>();

        EstadoEnvio estadoEnvio;
        public List<EstadoEnvio> listar()
        {

            try
            {
                conexion.abrirConexion();
                conexion.setearConsulta("Select ID, Nombre, Detalle from ESTADOENVIO WHERE Condicion = 1");
                conexion.ejecutarConsulta();

                while (conexion.Lector.Read())
                {
                    estadoEnvio = new EstadoEnvio
                    {
                        Id = conexion.Lector.GetInt32(0),
                        Nombre = conexion.Lector.GetString(1),
                        Detalle = conexion.Lector.GetString(2),
                    };

                    lista.Add(estadoEnvio);

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

        public EstadoEnvio listarID(int id)
        {

            try
            {
                conexion.abrirConexion();
                conexion.setearConsulta("Select ID, Nombre, Detalle from ESTADOENVIO " +
                    "WHERE Condicion = 1 and ID =" + id.ToString());
                conexion.ejecutarConsulta();

                while (conexion.Lector.Read())
                {
                    estadoEnvio = new EstadoEnvio
                    {
                        Id = conexion.Lector.GetInt32(0),
                        Nombre = conexion.Lector.GetString(1),
                        Detalle = conexion.Lector.GetString(2)
                    };

                }
                return estadoEnvio;
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

        public void modificar(EstadoEnvio estadoEnvio)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                //
                conexion.abrirConexion();
                conexion.setearConsulta("Update ESTADOENVIO Set Nombre=@nombre, Detalle=@Detalle Where Id=@id");
                //
                conexion.Comando.Parameters.Clear();
                conexion.Comando.Parameters.AddWithValue("@nombre", estadoEnvio.Nombre);
                conexion.Comando.Parameters.AddWithValue("@detalle", estadoEnvio.Detalle);
                conexion.Comando.Parameters.AddWithValue("@id", estadoEnvio.Id);
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
                conexion.setearConsulta("Update ESTADOENVIO Set Condicion=0 Where Id=@id");
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

        public void agregar(EstadoEnvio estadoEnvio)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                conexion.abrirConexion();
                conexion.setearConsulta("INSERT INTO ESTADOENVIO (Nombre, Detalle, Condicion) " +
                    "VALUES (@nombre, @detalle, 1)");
                //
                conexion.Comando.Parameters.Clear();
                conexion.Comando.Parameters.AddWithValue("@nombre", estadoEnvio.Nombre);
                conexion.Comando.Parameters.AddWithValue("@detalle", estadoEnvio.Detalle);
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
