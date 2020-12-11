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
    public partial class Compras : System.Web.UI.Page
    {
        CarritoNegocio carritoNegocio = new CarritoNegocio();
        ElementoNegocio elementoNegocio = new ElementoNegocio();
        CompraNegocio compraNegocio = new CompraNegocio();
        UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

        List<ListaCompra> listaCompra = new List<ListaCompra>();

        public List<Compra> aux;

        void cargarLista()
        {
            if (Session["usuario"] != null)
            {
                //
                foreach (Compra item in compraNegocio.listarXusuario(((Usuario)(Session["usuario"])).Id))
                {
                    ListaCompra listaAux = new ListaCompra
                    {
                        ID=item.Id,
                        IdCarrito = item.carrito.Id,
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
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                cargarLista();
            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void dgvCompra_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(dgvCompra.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text) != 0)
                {
                    Session.Add("compra", Convert.ToInt32(dgvCompra.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text));
                    Session.Add("listaCompra", elementoNegocio.listarID(
                        Convert.ToInt32(dgvCompra.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text)));
                }
                else
                {
                    dgvCompra.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Text = "Error";
                }
            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }
            //
            Response.Redirect("CompraDetalle.aspx");
        }
    }
}