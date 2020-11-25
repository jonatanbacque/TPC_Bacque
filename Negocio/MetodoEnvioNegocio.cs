using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Negocio;

namespace Negocio
{
    public class MetodoEnvioNegocio
    {
        AccesoDatos conexion = new AccesoDatos();
        List<MetodoEnvio> lista = new List<MetodoEnvio>();

        MetodoEnvio metodoEnvio;
        public List<MetodoEnvio> listar()
        {

            try
            {
                conexion.abrirConexion();
                conexion.setearConsulta("Select ID, Nombre, Detalle from METODOENVIO");
                conexion.ejecutarConsulta();

                while (conexion.Lector.Read())
                {
                    metodoEnvio = new MetodoEnvio
                    {
                        Id = conexion.Lector.GetInt32(0),
                        Nombre = conexion.Lector.GetString(1),
                        Detalle = conexion.Lector.GetString(2)
                    };

                    lista.Add(metodoEnvio);

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