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
        EnvioNegocio envioNegocio = new EnvioNegocio();
        CompraNegocio compraNegocio = new CompraNegocio();
        MetodoPagoNegocio metodoPagoNegocio = new MetodoPagoNegocio();

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

            dgvCompra.DataSource = listaCarrito;
            dgvCompra.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["listaCompra"] != null) cargarDgv((List<Elemento>)Session["listaCompra"]);
                //
                if (Session["compra"] != null)
                {
                    Compra compra = compraNegocio.listarID(Convert.ToInt32(Session["compra"]));
                    lblEstado.Text = envioNegocio.listarID(compra.envio.Id).estadoEnvio.Nombre;
                    txtPrecio.Text = "$ " + compra.ImporteFinal.ToString();
                    txtPrecioMetodo.Text = metodoPagoNegocio.listarID(compra.metodoPago.Id).Nombre;
                    txtEnvio.Text = envioNegocio.listarID(compra.envio.Id).metodoEnvio.Nombre;
                    txtEnvioPrecio.Text = "$ " + envioNegocio.listarID(compra.envio.Id).metodoEnvio.Precio.ToString();
                }
            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                compraNegocio.eliminar(Convert.ToInt32(Session["compra"]));
            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }
            //
            Response.Redirect("Compras.aspx");
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Remove("listaCompra");
            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }
            //
            Response.Redirect("Compras.aspx");
        }
    }
}
