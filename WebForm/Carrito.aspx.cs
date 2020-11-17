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

        public bool auxBit = new bool();

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

                dgvCarrito.DataSource = Session["listaCarrito"];
                dgvCarrito.DataBind();

            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnCarritoVaciar_Click(object sender, EventArgs e)
        {
            aux = new List<Articulo>();
            Session.Add("listaCarrito", aux);
            Response.Redirect("Carrito.aspx");
        }
    }
}