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
        UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
        CompraNegocio compraNegocio = new CompraNegocio();
        Carrito carrito;

        void cargarDgv(List<Elemento> lista)
        {
            List<ListaCarrito> listaCarrito = new List<ListaCarrito>();
            decimal importeFinal = 0;

            foreach (Elemento item in lista)
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

                importeFinal += item.articulo.Precio * item.Cantidad;
            }
            //
            dgvCarrito.DataSource = listaCarrito;
            dgvCarrito.DataBind();

            if (Session["carrito"] != null)
            {
                //Cargo importe final en el carrito
                carrito = new Carrito
                {
                    Id = Convert.ToInt32(Session["carrito"]),
                    Importe = importeFinal
                };
                //
                carritoNegocio.modificar(carrito);
            }

            btnComprar.Visible = true;
            //
            lblImporte.Text = "$ " + importeFinal.ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["listaElementos"] != null) cargarDgv((List<Elemento>)Session["listaElementos"]);
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
                if (Session["carrito"] != null)
                {
                    //Con el índice tenés que agarrar el dgv.rows en el índice ese punto columns, la que quieras punto id y obtener el valor posta.
                    elementoNegocio.eliminarArticulo(Convert.ToInt32(Session["carrito"]),
                        Convert.ToInt32(dgvCarrito.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text));
                    //Session.Remove("listaElementos");
                    Session.Add("listaElementos", elementoNegocio.listarID(Convert.ToInt32(Session["carrito"])));
                    //
                    cargarDgv((List<Elemento>)Session["listaElementos"]);
                }
            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }
            //
            //Response.Redirect("CarritoCompra.aspx");
        }

        protected void btnCarritoVaciar_Click(object sender, EventArgs e)
        {
            try
            {
                elementoNegocio.eliminarCarrito(Convert.ToInt32(Session["carrito"]));
                carritoNegocio.eliminar(Convert.ToInt32(Session["carrito"]));
                Session.Remove("listaElementos");
                Session.Remove("carrito");

            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }
            //
            Response.Redirect("/");
        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            try
            {
                Compra compra = new Compra
                {
                    carrito = carritoNegocio.listarID(Convert.ToInt32(Session["carrito"]))
                };
                compraNegocio.agregar(compra);
            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }
            //
            Response.Redirect("EnvioMetodo.aspx");
        }
    }
}