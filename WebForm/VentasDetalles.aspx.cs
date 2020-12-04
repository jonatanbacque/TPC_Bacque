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

    public partial class VentasDetalles : System.Web.UI.Page
    {
        EnvioNegocio envioNegocio = new EnvioNegocio();
        CompraNegocio compraNegocio = new CompraNegocio();
        MetodoPagoNegocio metodoPagoNegocio = new MetodoPagoNegocio();
        EstadoEnvioNegocio estadoEnvioNegocio = new EstadoEnvioNegocio();

        void cargarDgv(List<Elemento> lista)
        {
            List<ListaCarrito> listaCarrito = new List<ListaCarrito>();
            //
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
            //
            dgvCompra.DataSource = listaCarrito;
            dgvCompra.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //
                    if (Session["listaVenta"] != null) cargarDgv((List<Elemento>)Session["listaVenta"]);
                    //
                    ddlEnvioEstado.DataSource = estadoEnvioNegocio.listar();
                    ddlEnvioEstado.DataTextField = "Nombre";
                    ddlEnvioEstado.DataValueField = "ID";
                    ddlEnvioEstado.DataBind();
                    //
                    if (Session["compra"] != null)
                    {
                        Compra compra = compraNegocio.listarID(Convert.ToInt32(Session["compra"]));
                        txtPrecio.Text = "$ " + compra.ImporteFinal.ToString();
                        txtPrecioMetodo.Text = metodoPagoNegocio.listarID(compra.metodoPago.Id).Nombre;
                        txtEnvio.Text = envioNegocio.listarID(compra.envio.Id).metodoEnvio.Nombre;
                        txtEnvioPrecio.Text = "$ " + envioNegocio.listarID(compra.envio.Id).metodoEnvio.Precio.ToString();
                        ddlEnvioEstado.SelectedIndex = ddlEnvioEstado.Items.IndexOf(
                            ddlEnvioEstado.Items.FindByText(envioNegocio.listarID(compra.envio.Id).estadoEnvio.Nombre.ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //
                Compra compra = compraNegocio.listarID(Convert.ToInt32(Session["compra"]));
                Envio envio = envioNegocio.listarID(compra.envio.Id);
                //
                envio.estadoEnvio.Id = ddlEnvioEstado.SelectedIndex + 1;
                envioNegocio.modificar(envio);
                //
                lblResultado.Text = "Guardado";
            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Remove("listaVenta");
            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }
            //
            Response.Redirect("Ventas.aspx");
        }
    }
}