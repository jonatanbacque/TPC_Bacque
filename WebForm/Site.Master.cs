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
    public partial class SiteMaster : MasterPage
    {
        ArticuloNegocio negocio = new ArticuloNegocio();
        public List<Articulo> listaArticulos { get; set; }

        public List<Articulo> aux = new List<Articulo>();

        public string auxString= null;
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (Session["listaCarrito"] != null)
                {
                    aux = (List<Articulo>)Session["listaCarrito"];
                }

                //Consulto el URL si ya se hizo una busqueda antes de ingresar la categoria
                if (Request.QueryString["nombre"] != null) auxString = "?nombre=" + Request.QueryString["nombre"] + "&";

                else auxString = "?";

            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["categ"] != null) auxString = "?categ=" + Request.QueryString["categ"] + "&";

            else auxString = "?";

            Response.Redirect(auxString + "nombre=" + txtBuscar.Text);
        }

        protected void btnCategPerf_Click(object sender, EventArgs e)
        {
            Response.Redirect(auxString + "categ=" + btnCategPerf.Text);
        }

        protected void btnCategLimp_Click(object sender, EventArgs e)
        {
            Response.Redirect(auxString + "categ=" + btnCategLimp.Text);
        }

        protected void btnCategDeco_Click(object sender, EventArgs e)
        {
            Response.Redirect(auxString + "categ=" + btnCategDeco.Text);
        }
    }
}