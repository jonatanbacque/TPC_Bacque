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
        ElementoNegocio elementoNegocio = new ElementoNegocio();
        CompraNegocio compraNegocio = new CompraNegocio();

        List<ListaCompra> listaCompra = new List<ListaCompra>();

        public List<Compra> aux;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["usuario"] != null)
                {
                    foreach (Compra item in compraNegocio.listarActivas())
                    {
                        ListaCompra listaAux = new ListaCompra
                        {
                            ID = item.Id,
                            IdCarrito = item.carrito.Id,
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
                }
            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }
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
            try
            {
                if (Convert.ToInt32(dgvVentas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text) != 0)
                {
                    Session.Add("compra", Convert.ToInt32(dgvVentas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text));
                    Session.Add("listaVenta", elementoNegocio.listarID(
                        Convert.ToInt32(dgvVentas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text)));
                }
                else
                {
                    dgvVentas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Text = "Error";
                }
            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }
            //
            Response.Redirect("VentasDetalles.aspx");
        }
    }
}