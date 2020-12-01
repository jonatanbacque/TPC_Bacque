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
    public partial class Ventas : System.Web.UI.Page
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
                    foreach (Compra item in compraNegocio.listarActivas())
                    {
                        ListaCompra listaAux = new ListaCompra
                        {
                            ID = item.carrito.Id,
                            Nombre = item.usuario.persona.Nombre + ", " + item.usuario.persona.Apellido,
                            Direccion = item.usuario.persona.Direccion,
                            Estado = item.envio.estadoEnvio.Nombre,
                            FechaCompra = item.FechaCompra,
                            MetodoCompra=item.metodoPago.Nombre,
                            Precio = item.ImporteFinal,
                            MetodoEnvio = item.envio.metodoEnvio.Nombre,
                            FechaEntrega = item.envio.fechaEntrega
                        };

                        listaCompra.Add(listaAux);

                    }
                    //
                    dgvVentas.DataSource = listaCompra;
                    dgvVentas.DataBind();
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
                Session.Remove("carrito");

                Session.Add("carrito", Convert.ToInt32(dgvVentas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text));

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

        protected void btnListado_Click(object sender, EventArgs e)
        {
            Response.Redirect("Listado.aspx");
        }

        protected void btnEdicion_Click(object sender, EventArgs e)
        {
            Response.Redirect("VentasEditar.aspx");
        }

        protected void dgvVentas_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}