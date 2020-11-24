﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace WebForm
{
    public partial class CarritoCompra : System.Web.UI.Page
    {
        CarritoNegocio carritoNegocio = new CarritoNegocio();
        ElementoNegocio elementoNegocio = new ElementoNegocio();

        List<ListaCarrito> listaCarrito = new List<ListaCarrito>();

        public List<Elemento> aux;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["listaElementos"] != null)
                {
                    aux = (List<Elemento>)Session["listaElementos"];
                    //
                    foreach (Elemento item in aux)
                    {
                        ListaCarrito listaAux = new ListaCarrito
                        {
                            ID = item.articulo.Id,
                            Producto = item.articulo.Producto,
                            Descripcion = item.articulo.Descripcion,
                            ImagenUrl = item.articulo.ImagenUrl,
                            Precio = item.articulo.Precio,
                            Cantidad = item.Cantidad
                        };
                        listaCarrito.Add(listaAux);
                    }
                    //
                    dgvCarrito.DataSource = listaCarrito;
                    dgvCarrito.DataBind();
                }
                //
                else
                {
                    aux = new List<Elemento>();
                }
            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        //Borrar articulo de la lista del carrito
        protected void dgvCarrito_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //Con el índice tenés que agarrar el dgv.rows en el índice ese punto columns, la que quieras punto id y obtener el valor posta.
                elementoNegocio.eliminarArticulo(Convert.ToInt32(Session["carrito"]), Convert.ToInt32(dgvCarrito.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text));
                //
                Session.Remove("listaElementos");
                Session.Add("listaElementos", elementoNegocio.listarID(Convert.ToInt32(Session["carrito"])));
            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }
            //
            Response.Redirect("CarritoCompra.aspx");

        }

        protected void btnCarritoVaciar_Click(object sender, EventArgs e)
        {
            try
            {
                elementoNegocio.eliminarCarrito(Convert.ToInt32(Session["carrito"]));
                carritoNegocio.eliminar(Convert.ToInt32(Session["carrito"]));
                aux = new List<Elemento>();
                Session.Add("listaElementos", aux);
                Session.Remove("carrito");

            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }
            //
            Response.Redirect("CarritoCompra.aspx");
        }

    }
}