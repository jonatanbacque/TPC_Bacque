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
        ArticuloNegocio articulosNegocio = new ArticuloNegocio();
        CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

        public Articulo aux = new Articulo();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["articulo"] != null)
                    {
                        aux = (Articulo)Session["articulo"];
                        //aux = negocio.listarID(1);

                        txtNombre.Text = aux.Producto;
                        ddlCategorias.DataSource = categoriaNegocio.listar();
                        ddlCategorias.DataTextField = "Nombre";
                        ddlCategorias.DataValueField = "ID";// aux.categoria.ToString();
                        ddlCategorias.DataBind();
                        ddlCategorias.SelectedIndex = ddlCategorias.Items.IndexOf(
                            ddlCategorias.Items.FindByText(aux.categoria.ToString()));
                        txtDescripcion.Text = aux.Descripcion;
                        txtURLImagen.Text = aux.ImagenUrl;
                        imgImagen.ImageUrl = aux.ImagenUrl;
                        txtPrecio.Text = aux.Precio.ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void txtURLImagen_TextChanged(object sender, EventArgs e)
        {
            imgImagen.ImageUrl = txtURLImagen.Text;
        }
    }
}