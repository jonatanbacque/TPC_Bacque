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
        //
        Articulo aux = new Articulo
        {
            categoria = new Categoria()
        };
        //
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ddlCategorias.DataSource = categoriaNegocio.listar();
                    ddlCategorias.DataTextField = "Nombre";
                    ddlCategorias.DataValueField = "ID";// aux.categoria.ToString();
                    ddlCategorias.DataBind();

                    //Filtrado por busqueda
                    if (Request.QueryString["nuevo"] != null)
                    {
                        btnGuardar.Text = "Guardar nuevo producto";
                    }
                    else
                    {
                        if (Session["articuloId"] != null)
                        {
                            int idlocal = (int)Session["articuloId"];
                            aux = articulosNegocio.listarID(idlocal);
                        }

                        txtNombre.Text = aux.Producto;
                        txtPresentacion.Text = aux.Presentacion;
                        txtDescripcion.Text = aux.Descripcion;
                        txtPrecio.Text = aux.Precio.ToString();
                        imgImagen.ImageUrl = aux.ImagenUrl;
                        txtMarca.Text = aux.Marca;

                        ddlCategorias.SelectedIndex = ddlCategorias.Items.IndexOf(
                            ddlCategorias.Items.FindByText(aux.categoria.ToString()));

                        txtURLImagen.Text = aux.ImagenUrl;
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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo nuevo = new Articulo
                {
                    Id = (int)Session["articuloId"],
                    Producto = txtNombre.Text,
                    Presentacion = txtPresentacion.Text,
                    Descripcion = txtDescripcion.Text,
                    ImagenUrl = imgImagen.ImageUrl,
                    Precio = Convert.ToDecimal(txtPrecio.Text),
                    Marca = txtMarca.Text,

                    categoria = new Categoria
                    {
                        Id = Convert.ToInt32(ddlCategorias.SelectedValue),
                    }
                };

                articulosNegocio.modificar(nuevo);
                lblGuardar.Text = "Guardado";
            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}