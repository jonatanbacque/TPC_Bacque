using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace WebForm
{
    public partial class Detalle : System.Web.UI.Page
    {
        public int id;
                public List<Articulo> listaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                id = Convert.ToInt32(Request.QueryString["ID"]);

                if (Session["Listado"] != null)
                {
                    listaArticulos = (List<Articulo>)Session["listado"];
                    Articulo seleccionado = ((List<Articulo>)Session["listado"])[id - 1];
                    imgImagen.ImageUrl = seleccionado.ImagenUrl;
                    lblNombre.Text = seleccionado.Nombre + ":";
                    lblDescripcion.Text = seleccionado.Descripcion;
                }
                else
                {
                    lblNombre.Text = "Selección inválida";
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