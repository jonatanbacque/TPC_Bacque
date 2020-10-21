using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Negocio
{
    public class ArticuloNegocio
    {
        Articulo articulo;
        public List<Articulo> listar()
        {
            AccesoDatos conexion = new AccesoDatos();
            List<Articulo> lista = new List<Articulo>();
            try
            {
                conexion.abrirConexion();
                conexion.setearConsulta("Select ID, codigo, Nombre, Descripcion,IdMarca" +
                                        ", IdCategoria, ImagenUrl, Precio from ARTICULOS");
                conexion.ejecutarConsulta();

                while (conexion.Lector.Read())
                {
                    articulo = new Articulo
                    {
                        Id = conexion.Lector.GetInt32(0),
                        Codigo = conexion.Lector.GetString(1),
                        Nombre = conexion.Lector.GetString(2),
                        Descripcion = conexion.Lector.GetString(3),
                        IdMarca = conexion.Lector.GetInt32(4),
                        IdCategoria = conexion.Lector.GetInt32(5),
                        ImagenUrl = conexion.Lector.GetString(6),
                        //Precio = conexion.Lector.GetSqlMoney(7).ToDecimal(),
                    };

                    lista.Add(articulo);

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

        public Articulo listarID(int ID)
        {
            AccesoDatos conexion = new AccesoDatos();
            List<Articulo> lista = new List<Articulo>();
            try
            {
                conexion.abrirConexion();
                conexion.setearConsulta("Select ID, codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio from ARTICULOS where id =" + ID);
                conexion.ejecutarConsulta();

                while (conexion.Lector.Read())
                {
                    articulo = new Articulo
                    {
                        Id = conexion.Lector.GetInt32(0),
                        Codigo = conexion.Lector.GetString(1),
                        Nombre = conexion.Lector.GetString(2),
                        Descripcion = conexion.Lector.GetString(3),
                        IdMarca = conexion.Lector.GetInt32(4),
                        IdCategoria = conexion.Lector.GetInt32(5),
                        ImagenUrl = conexion.Lector.GetString(6),
                        Precio = conexion.Lector.GetDecimal(7),
                    };
                }
                return articulo;
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
