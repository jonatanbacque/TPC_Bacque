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
        Articulo aux;
        //
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ddlCategorias.DataSource = categoriaNegocio.listar();
                    ddlCategorias.DataTextField = "Nombre";
                    ddlCategorias.DataValueField = "ID";
                    ddlCategorias.DataBind();

                    if (Session["articuloId"] != null)
                    {
                        if ((int)Session["articuloId"] != 0)
                        {
                            int idLocal = (int)Session["articuloId"];
                            aux = articulosNegocio.listarID(idLocal);
                            btnEliminar.Visible = true;

                            txtNombre.Text = aux.Producto;
                            txtPresentacion.Text = aux.Presentacion;
                            txtDescripcion.Text = aux.Descripcion;
                            txtPrecio.Text = aux.Precio.ToString();
                            imgImagen.ImageUrl = aux.ImagenUrl;
                            txtMarca.Text = aux.Marca;
                            txtURLImagen.Text = aux.ImagenUrl;

                            ddlCategorias.SelectedIndex = ddlCategorias.Items.IndexOf(
                                ddlCategorias.Items.FindByText(aux.categoria.ToString()));

                        }
                        else
                        {
                            btnGuardar.Text = "Guardar nuevo producto";
                            aux = new Articulo
                            {
                                categoria = new Categoria()
                            };
                        }
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

                //Decido si modifico articulo o creo uno nuevo
                if (Session["articuloId"] != null && (int)Session["articuloId"] != 0) articulosNegocio.modificar(nuevo);
                else articulosNegocio.agregar(nuevo);

                lblGuardar.Text = "Guardado";
            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                articulosNegocio.eliminar((int)Session["articuloId"]);

                lblGuardar.Text = "Eliminado";
            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }

            Response.Redirect("Listado.aspx");
        }
    }
}