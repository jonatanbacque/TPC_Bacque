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
    public partial class CompraDetalle : System.Web.UI.Page
    {
        CarritoNegocio carritoNegocio = new CarritoNegocio();
        ElementoNegocio elementoNegocio = new ElementoNegocio();
        UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
        CompraNegocio compraNegocio = new CompraNegocio();
        Carrito carrito;

        void cargarDgv(List<Elemento> lista)
        {
            List<ListaCarrito> listaCarrito = new List<ListaCarrito>();

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
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["listaElementos"] != null) cargarDgv((List<Elemento>)Session["listaElementos"]);
                //
                if (Session["compra"] != null)
                {
                    Compra compra = compraNegocio.listarID(Convert.ToInt32(Session["compra"]));
                    lblImporte.Text = compra.ImporteFinal.ToString();
                }
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
                    compraNegocio.eliminar(Convert.ToInt32(dgvCompra.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text));
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
