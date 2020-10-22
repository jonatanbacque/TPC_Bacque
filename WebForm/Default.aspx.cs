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
    public partial class _Default : Page
    {
        ArticuloNegocio negocio = new ArticuloNegocio();
        public List<Articulo> listaArticulos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["nombre"] == null)
                {
                    listaArticulos = negocio.listar();
                    Session.Add("listado", listaArticulos);
                }
                else
                {
                    listaArticulos = negocio.Buscar(Request.QueryString["nombre"]);
                    Session.Add("listado", listaArticulos);
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