using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace WebForm
{
    public partial class CompraListado : System.Web.UI.Page
    {
        CarritoNegocio carritoNegocio = new CarritoNegocio();
        ElementoNegocio elementoNegocio = new ElementoNegocio();
        CompraNegocio compraNegocio = new CompraNegocio();
        UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

        List<ListaCompra> listaCompra = new List<ListaCompra>();
        Carrito carrito;

        public List<Compra> aux;

        protected void Page_Load(object sender, EventArgs e)
        {
            //
            decimal importeFinal = 0;
            try
            {
                if (Session["usuario"] != null)
                {
                    foreach (Compra item in compraNegocio.listarXusuario(((Usuario)(Session["usuario"])).Id))
                    {
                        ListaCompra listaAux = new ListaCompra
                        {
                            ID = item.Id,
                            Estado = item.envio.estadoEnvio.Nombre,
                            FechaCompra = item.FechaCompra,
                            FechaEntrega = item.envio.fechaEntrega,
                            Precio = item.ImporteFinal,
                        };

                        listaCompra.Add(listaAux);

                    }
                    //
                    dgvCompra.DataSource = listaCompra;
                    dgvCompra.DataBind();
                    //Cargo importe final en el carrito
                    carrito = new Carrito
                    {
                        Id = Convert.ToInt32(Session["carrito"]),
                        Importe = importeFinal
                    };
                }
            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        //Borrar articulo de la lista del carrito
        protected void dgvCompra_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
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
        }

    }
}