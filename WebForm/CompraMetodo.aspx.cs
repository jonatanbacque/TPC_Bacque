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
    public partial class CompraMetodo : System.Web.UI.Page
    {
        UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
        CarritoNegocio carritoNegocio = new CarritoNegocio();
        MetodoPagoNegocio metodoPagoNegocio = new MetodoPagoNegocio();
        EnvioNegocio envioNegocio = new EnvioNegocio();
        CompraNegocio compraNegocio = new CompraNegocio();
        ElementoNegocio elementoNegocio = new ElementoNegocio();

        Compra compra;

        decimal importeFinal;

        public List<Elemento> listaElementos;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //
                if (!IsPostBack)
                {
                    ddlMetodoPago.DataSource = metodoPagoNegocio.listar();
                    ddlMetodoPago.DataTextField = "Nombre";
                    ddlMetodoPago.DataValueField = "ID";
                    ddlMetodoPago.DataBind();
                }
                //
                if (Session["listaElementos"] != null)
                {
                    listaElementos = (List<Elemento>)Session["listaElementos"];
                }
                else
                {
                    listaElementos = new List<Elemento>();
                }
                //
                if (Session["carrito"] != null)
                {
                }

            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }

            if (Session["usuario"] == null)
            {
                if (Session["carrito"] != null)
                {
                    Response.Redirect("IniciarSesion.aspx?ID=" + Session["carrito"].ToString());
                }
            }
        }

        protected void ddlMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Cargo nombre
                txtNombre.Text = ((Usuario)Session["usuario"]).ToString();
                txtEnvio.Text = ((Usuario)Session["usuario"]).persona.Direccion;
                //Cargo importe final
                decimal preciocarrito = carritoNegocio.listarID(Convert.ToInt32(Session["carrito"])).Importe;
                decimal precioenvio = envioNegocio.listarID(Convert.ToInt32(Session["envio"])).metodoEnvio.Precio;
                decimal interes = metodoPagoNegocio.listarID(ddlMetodoPago.SelectedIndex + 1).Precio;

                importeFinal = (preciocarrito + precioenvio) * interes;
                txtPrecio.Text = importeFinal.ToString();

                if (ddlMetodoPago.SelectedIndex != 0) btnFinalizar.Enabled = true;
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
                elementoNegocio.eliminarCarrito(Convert.ToInt32(Session["carrito"]));
                carritoNegocio.eliminar(Convert.ToInt32(Session["carrito"]));
                envioNegocio.eliminar(Convert.ToInt32(Session["envio"]));

                Session.Remove("listaElementos");
                Session.Remove("carrito");
                Session.Remove("envio");
            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }
            //
            Response.Redirect("/");
        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            decimal a = importeFinal;
            try
            {
                //Cargo importe final
                decimal preciocarrito = carritoNegocio.listarID(Convert.ToInt32(Session["carrito"])).Importe;
                decimal precioenvio = envioNegocio.listarID(Convert.ToInt32(Session["envio"])).metodoEnvio.Precio;
                decimal interes = metodoPagoNegocio.listarID(ddlMetodoPago.SelectedIndex + 1).Precio;

                importeFinal = (preciocarrito + precioenvio) * interes;

                compra = new Compra
                {
                    usuario = usuarioNegocio.listarID(((Usuario)(Session["usuario"])).Id),
                    carrito = carritoNegocio.listarID(Convert.ToInt32(Session["carrito"])),
                    envio = envioNegocio.listarID(Convert.ToInt32(Session["envio"])),
                    metodoPago = metodoPagoNegocio.listarID(ddlMetodoPago.SelectedIndex + 1),
                    FechaCompra = DateTime.Now,
                    ImporteFinal = importeFinal
                };

                compraNegocio.agregar(compra);

                Session.Remove("listaElementos");
                Session.Remove("carrito");
                Session.Remove("envio");
            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }
            //
            Response.Redirect("CompraListado.aspx");

        }
    }
}