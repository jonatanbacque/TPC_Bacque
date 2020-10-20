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
    public partial class Carrito : System.Web.UI.Page
    {
        ArticuloNegocio negocio = new ArticuloNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["ID"] != null)
                    Session.Add("listaCarrito", negocio.listarID(Convert.ToInt32(Request.QueryString["ID"])));



                dgvCarrito.DataSource = Session["listaCarrito"];
                dgvCarrito.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }

        }
    }
}