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

        public List<Articulo> aux;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["listaCarrito"] != null)
                {
                    aux = (List<Articulo>)Session["listaCarrito"];
                }
                else
                {
                    aux = new List<Articulo>();
                }

                if (Request.QueryString["ID"] != null)
                {
                    aux.Add(negocio.listarID(Convert.ToInt32(Request.QueryString["ID"])));
                    Session.Add("listaCarrito", aux);
                }

                dgvCarrito.DataSource = Session["listaCarrito"];
                dgvCarrito.DataBind();
                //dgvCarrito.Columns[3].Visible = false;
                //dgvCarrito.Columns[4].Visible = false;

            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }

        }
    }
}