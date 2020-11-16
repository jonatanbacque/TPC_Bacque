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
            try
            {
                aux = (Articulo)Session["articulo"];

                txtNombre.Text = aux.Producto;
                txtURLImagen.Text = aux.ImagenUrl;
                txtPrecio.Text = aux.Precio.ToString();
            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }
            Response.Redirect("Articulos.aspx");
        }
    }
}