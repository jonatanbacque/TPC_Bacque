using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace WebForm
{
    public partial class SiteMaster : MasterPage
    {
        public List<Articulo> listaArticulos { get; set; }

        public List<Articulo> aux = new List<Articulo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["listaCarrito"] != null)
                {
                    aux = (List<Articulo>)Session["listaCarrito"];
                }

                lblCarrito.Text = aux.Count().ToString();
            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Response.Redirect("?nombre=" + txtBuscar.Text);
        }

        protected void btnCategPerf_Click(object sender, EventArgs e)
        {
            Response.Redirect("?categ=" + btnCategPerf.Text);
        }

        protected void btnCategLimp_Click(object sender, EventArgs e)
        {
            Response.Redirect("?categ=" + btnCategLimp.Text);
        }

        protected void btnCategDeco_Click(object sender, EventArgs e)
        {
            Response.Redirect("?categ=" + btnCategDeco.Text);
        }

        protected void btnContacto_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contacto.aspx");
        }
    }
}