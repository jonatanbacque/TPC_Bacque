using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Negocio;

namespace Negocio
{
    public class MetodoPagoNegocio
    {
        AccesoDatos conexion = new AccesoDatos();
        List<MetodoPago> lista = new List<MetodoPago>();

        MetodoPago metodoPago;
        public List<MetodoPago> listar()
        {

            try
            {
                conexion.abrirConexion();
                conexion.setearConsulta("Select ID, Nombre, Detalle, Precio from METODOPAGO WHERE Condicion = 1");
                conexion.ejecutarConsulta();

                while (conexion.Lector.Read())
                {
                    metodoPago = new MetodoPago
                    {
                        Id = conexion.Lector.GetInt32(0),
                        Nombre = conexion.Lector.GetString(1),
                        Detalle = conexion.Lector.GetString(2),
                        Precio = conexion.Lector.GetDecimal(3)
                    };

                    lista.Add(metodoPago);

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

        public MetodoPago listarID(int id)
        {

            try
            {
                conexion.abrirConexion();
                conexion.setearConsulta("Select ID, Nombre, Detalle, Precio from METODOPAGO " +
                    "WHERE Condicion = 1 and ID =" + id.ToString());
                conexion.ejecutarConsulta();

                while (conexion.Lector.Read())
                {
                    metodoPago = new MetodoPago
                    {
                        Id = conexion.Lector.GetInt32(0),
                        Nombre = conexion.Lector.GetString(1),
                        Detalle = conexion.Lector.GetString(2),
                        Precio = conexion.Lector.GetDecimal(3)
                    };

                }
                return metodoPago;
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

        public void modificar(MetodoPago metodoPago)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                //
                conexion.abrirConexion();
                conexion.setearConsulta("Update METODOPAGO Set Nombre=@nombre, Detalle=@Detalle, " +
                                        "Precio=@precio Where Id=@id");
                //
                conexion.Comando.Parameters.Clear();
                conexion.Comando.Parameters.AddWithValue("@nombre", metodoPago.Nombre);
                conexion.Comando.Parameters.AddWithValue("@detalle", metodoPago.Detalle);
                conexion.Comando.Parameters.AddWithValue("@precio", metodoPago.Precio);
                conexion.Comando.Parameters.AddWithValue("@id", metodoPago.Id);
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
                conexion.setearConsulta("Update METODOPAGO Set Condicion=0 Where Id=@id");
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

        public void agregar(MetodoPago metodoPago)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                conexion.abrirConexion();
                conexion.setearConsulta("INSERT INTO METODOPAGO (Nombre, Detalle, Precio, Condicion) " +
                    "VALUES (@nombre, @detalle, @precio, 1)");
                //
                conexion.Comando.Parameters.Clear();
                conexion.Comando.Parameters.AddWithValue("@nombre", metodoPago.Nombre);
                conexion.Comando.Parameters.AddWithValue("@detalle", metodoPago.Detalle);
                conexion.Comando.Parameters.AddWithValue("@precio", metodoPago.Precio);
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
