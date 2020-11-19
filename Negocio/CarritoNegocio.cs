using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class CarritoNegocio
    {
        Carrito carrito;
        public List<Carrito> listar()
        {
            AccesoDatos conexion = new AccesoDatos();
            List<Carrito> lista = new List<Carrito>();
            try
            {
                conexion.abrirConexion();
                conexion.setearConsulta("Select ID, Importe from CARRITO");
                conexion.ejecutarConsulta();

                while (conexion.Lector.Read())
                {
                    carrito = new Carrito
                    {
                        Id = conexion.Lector.GetInt32(0),
                        Importe = conexion.Lector.GetDecimal(1)
                    };

                    lista.Add(carrito);

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

        public Carrito listarID(int ID)
        {
            AccesoDatos conexion = new AccesoDatos();
            List<Carrito> lista = new List<Carrito>();
            try
            {
                conexion.abrirConexion();
                conexion.setearConsulta("Select ID, Importe CARRITO WHERE ID =" + ID);
                conexion.ejecutarConsulta();

                while (conexion.Lector.Read())
                {
                    carrito = new Carrito
                    {
                        Id = conexion.Lector.GetInt32(0),
                        Importe = conexion.Lector.GetDecimal(1)
                    };
                }
                return carrito;
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

        public void modificar(Carrito carrito)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                //
                conexion.setearConsulta("Update CARRITO Set Id=@id, Importe=@importe Where Id=@id");
                //
                conexion.Comando.Parameters.Clear();
                conexion.Comando.Parameters.AddWithValue("@importe", carrito.Importe);
                conexion.Comando.Parameters.AddWithValue("@id", carrito.Id);
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

        public void eliminar(int id)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                //
                conexion.setearConsulta("Delete from CARRITO Where Id=@id");
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

        public void agregar(Articulo articulo)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                //
                conexion.setearConsulta("Insert into CARRITO (Importe) VALUES (@importe)");
                //
                conexion.Comando.Parameters.Clear();
                conexion.Comando.Parameters.AddWithValue("@importe", carrito.Importe);
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
