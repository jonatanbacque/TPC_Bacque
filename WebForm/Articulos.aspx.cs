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
    public partial class Articulos : System.Web.UI.Page
    {
        ArticuloNegocio negocio = new ArticuloNegocio();

        public Articulo aux = new Articulo();

        protected void Page_Load(object sender, EventArgs e)
        {
            aux = (Articulo)Session["listado"];

        }
    }
}