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

                

            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            //btnBuscar.Text = txtBuscar.Text;
        }
    }
}