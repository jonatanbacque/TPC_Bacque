using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace WebForm
{
    public partial class Compra : System.Web.UI.Page
    {
        public List<Articulo> listaCarrito;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["listaCarrito"] != null)
                {
                    listaCarrito = (List<Articulo>)Session["listaCarrito"];
                }
                else
                {
                    listaCarrito = new List<Articulo>();
                }

            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}