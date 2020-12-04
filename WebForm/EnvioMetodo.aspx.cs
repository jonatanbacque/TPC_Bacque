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
    public partial class EnvioMetodo : System.Web.UI.Page
    {
        CarritoNegocio carritoNegocio = new CarritoNegocio();
        ElementoNegocio elementoNegocio = new ElementoNegocio();
        MetodoEnvioNegocio metodoEnvioNegocio = new MetodoEnvioNegocio();
        EnvioNegocio envioNegocio = new EnvioNegocio();
        UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
        CompraNegocio compraNegocio = new CompraNegocio();

        public List<Elemento> listaElementos;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //
                if (!IsPostBack)
                {
                    ddlMetodoEnvio.DataSource = metodoEnvioNegocio.listar();
                    ddlMetodoEnvio.DataTextField = "Nombre";
                    ddlMetodoEnvio.DataValueField = "ID";
                    ddlMetodoEnvio.DataBind();
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
                //Cargo doimicilio del usuario
                if (Session["usuario"] != null)
                {
                    Usuario aux = (Usuario)Session["usuario"];
                    txtDomicilioEntrega.Text = aux.persona.Direccion;
                }
                //
                if (Session["carrito"] != null)
                {
                    //Cargo precio envio
                    txtPrecio.Text = metodoEnvioNegocio.listarID(Convert.ToInt32(ddlMetodoEnvio.SelectedValue)).Precio.ToString();

                }

                txtPrecio.ReadOnly = true;
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

        protected void ddlMetodoEnvio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnContinuar.Enabled = false;

                txtFechaEntrega.ReadOnly = false;

                lblFechaEntrega.Visible = true;
                txtFechaEntrega.Visible = true;

                txtDomicilioEntrega.Visible = true;
                lblDomicilioEntrega.Visible = true;

                txtFechaEntrega.Text = DateTime.Today.AddDays(metodoEnvioNegocio.listarID
                    (Convert.ToInt32(ddlMetodoEnvio.SelectedValue)).Demora).ToString("d");

                txtFechaEntrega.ReadOnly = true;

                if (ddlMetodoEnvio.SelectedIndex != 0) btnContinuar.Enabled = true;
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

        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            try
            {
                //Cargo datos elegidos en el ddlEnvio
                Envio envio = new Envio
                {
                    metodoEnvio = new MetodoEnvio
                    {
                        Id = Convert.ToInt32(ddlMetodoEnvio.SelectedValue)
                    },
                    estadoEnvio = new EstadoEnvio
                    {
                        Id = 2
                    },
                    fechaEntrega = DateTime.Today.AddDays(metodoEnvioNegocio.listarID
                (Convert.ToInt32(ddlMetodoEnvio.SelectedValue)).Demora),
                };

                envioNegocio.agregar(envio);

                Compra compra = new Compra
                {
                    Id = compraNegocio.ultimo(),
                    //cargo envio
                    envio = new Envio
                    {
                        Id = envioNegocio.ultimo()
                    },
                    //cargo usuario
                    usuario = usuarioNegocio.listarID(((Usuario)(Session["usuario"])).Id),
                };

                compraNegocio.modificar(compra);
                //Session.Add("envio", envioNegocio.ultimo());
            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }
            //
            Response.Redirect("CompraMetodo.aspx");
        }
    }
}
