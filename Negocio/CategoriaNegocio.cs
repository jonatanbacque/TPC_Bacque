using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Negocio;

namespace Negocio
{
    public class CategoriaNegocio
    {
        AccesoDatos conexion = new AccesoDatos();
        List<Categoria> lista = new List<Categoria>();

        Categoria categoria;
        public List<Categoria> listar()
        {

            try
            {
                conexion.abrirConexion();
                conexion.setearConsulta("Select ID, Nombre, Descripcion from CATEGORIA");
                conexion.ejecutarConsulta();

                while (conexion.Lector.Read())
                {
                    categoria = new Categoria
                    {
                        Id = conexion.Lector.GetInt32(0),
                        Nombre = conexion.Lector.GetString(1),
                        Descripcion = conexion.Lector.GetString(2)
                    };

                    lista.Add(categoria);

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
