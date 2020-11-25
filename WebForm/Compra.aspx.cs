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
    public partial class Compra : System.Web.UI.Page
    {
        CarritoNegocio carritoNegocio = new CarritoNegocio();
        MetodoEnvioNegocio metodoEnvioNegocio = new MetodoEnvioNegocio();

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
                    //Cargo importe final
                    txtPrecio.Text = carritoNegocio.listarID(Convert.ToInt32(Session["carrito"])).ToString();
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
        protected void ddlMetodoEnvio_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtFechaEntrega.ReadOnly = false;

                lblFechaEntrega.Visible = true;
                txtFechaEntrega.Visible = true;

                txtDomicilioEntrega.Visible = true;
                lblDomicilioEntrega.Visible = true;

                switch (Convert.ToInt32(ddlMetodoEnvio.SelectedValue) - 1)
                {
                    case 1:
                        lblFechaEntrega.Visible = false;
                        txtFechaEntrega.Visible = false;
                        lblDomicilioEntrega.Visible = false;
                        txtDomicilioEntrega.Visible = false;
                        break;
                    case 2:
                        txtFechaEntrega.Text = DateTime.Now.AddDays(7).ToString("d");
                        break;
                    case 3:
                        txtFechaEntrega.Text = DateTime.Now.AddDays(12).ToString("d");
                        break;
                    case 4:
                        txtFechaEntrega.Text = DateTime.Now.AddDays(3).ToString("d");
                        break;
                }
                txtFechaEntrega.ReadOnly = true;
            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}