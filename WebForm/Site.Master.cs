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
        public List<Elemento> listaArticulos;

        public List<Elemento> aux = new List<Elemento>();

        public Usuario usuario = new Usuario();

        public string usuarioActual;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                usuarioActual = "Iniciar Sesión";

                if (Session["listaElementos"] != null)
                {
                    aux = (List<Elemento>)Session["listaElementos"];
                }

                lblCarrito.Text = " " + aux.Count().ToString();

                if (Session["usuario"] != null)
                {
                    usuario = (Usuario)Session["usuario"];
                    usuarioActual = "Usuario: " + usuario.Nombre;
                }
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

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Remove("usuario");
            Session.Remove("listaElementos");
            Session.Remove("carrito");
            Session.Remove("envio");
            Response.Redirect("/");
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            Session.Remove("usuario");
            Session.Remove("listaElementos");
            Session.Remove("carrito");
            Session.Remove("envio");
            Response.Redirect("IniciarSesion.aspx");
        }

        protected void btnCarrito_Click(object sender, EventArgs e)
        {
            if (aux.Count() > 0) Response.Redirect("CarritoCompra.aspx");
        }
    }
}