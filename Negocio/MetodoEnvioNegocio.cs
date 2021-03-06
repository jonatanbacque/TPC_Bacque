﻿using System;
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
                conexion.setearConsulta("Select ID, Nombre, Detalle, Demora, Precio from METODOENVIO WHERE Condicion = 1");
                conexion.ejecutarConsulta();

                while (conexion.Lector.Read())
                {
                    metodoEnvio = new MetodoEnvio
                    {
                        Id = conexion.Lector.GetInt32(0),
                        Nombre = conexion.Lector.GetString(1),
                        Detalle = conexion.Lector.GetString(2),
                        Demora = conexion.Lector.GetInt32(3),
                        Precio = conexion.Lector.GetDecimal(4)
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

        public MetodoEnvio listarID(int id)
        {

            try
            {
                conexion.abrirConexion();
                conexion.setearConsulta("Select ID, Nombre, Detalle, Demora, Precio from METODOENVIO " +
                    "WHERE Condicion = 1 and ID =" + id.ToString());
                conexion.ejecutarConsulta();

                while (conexion.Lector.Read())
                {
                    metodoEnvio = new MetodoEnvio
                    {
                        Id = conexion.Lector.GetInt32(0),
                        Nombre = conexion.Lector.GetString(1),
                        Detalle = conexion.Lector.GetString(2),
                        Demora = conexion.Lector.GetInt32(3),
                        Precio = conexion.Lector.GetDecimal(4)
                    };

                }
                return metodoEnvio;
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

        public void modificar(MetodoEnvio metodoEnvio)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                //
                conexion.abrirConexion();
                conexion.setearConsulta("Update METODOENVIO Set Nombre=@nombre, Detalle=@Detalle, Demora=@demora, " +
                                        "Precio=@precio Where Id=@id");
                //
                conexion.Comando.Parameters.Clear();
                conexion.Comando.Parameters.AddWithValue("@nombre", metodoEnvio.Nombre);
                conexion.Comando.Parameters.AddWithValue("@detalle", metodoEnvio.Detalle);
                conexion.Comando.Parameters.AddWithValue("@demora", metodoEnvio.Demora);
                conexion.Comando.Parameters.AddWithValue("@precio", metodoEnvio.Precio);
                conexion.Comando.Parameters.AddWithValue("@id", metodoEnvio.Id);
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
                conexion.setearConsulta("Update METODOENVIO Set Condicion=0 Where Id=@id");
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

        public void agregar(MetodoEnvio metodoEnvio)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                conexion.abrirConexion();
                conexion.setearConsulta("INSERT INTO METODOENVIO (Nombre, Detalle, Demora, Precio, Condicion) " +
                    "VALUES (@nombre, @detalle, @demora, @precio, 1)");
                //
                conexion.Comando.Parameters.Clear();
                conexion.Comando.Parameters.AddWithValue("@nombre", metodoEnvio.Nombre);
                conexion.Comando.Parameters.AddWithValue("@detalle", metodoEnvio.Detalle);
                conexion.Comando.Parameters.AddWithValue("@demora", metodoEnvio.Demora);
                conexion.Comando.Parameters.AddWithValue("@precio", metodoEnvio.Precio);
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