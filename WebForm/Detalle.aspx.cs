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
    public partial class Detalle : System.Web.UI.Page
    {
        ArticuloNegocio negocio = new ArticuloNegocio();

        public int id;

        public List<Articulo> listaArticulos { get; set; }

        public List<Articulo> aux;

        public bool auxBit = new bool();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Consulto si la lista esta vacia para inicializarla
                if (Session["listaCarrito"] != null)
                {
                    aux = (List<Articulo>)Session["listaCarrito"];
                }
                else
                {
                    aux = new List<Articulo>();
                }

                if (Request.QueryString["ID"] != null)
                {
                    id = Convert.ToInt32(Request.QueryString["ID"]);

                    if (Session["Listado"] != null)
                    {
                        //Consulto si el articulo ya fue agregado
                        Articulo seleccionado = negocio.listarID(id);

                        imgImagen.ImageUrl = seleccionado.ImagenUrl;
                        lblNombre.Text = seleccionado.Producto;
                        lblDescripcion.Text = seleccionado.Descripcion;
                        lblPrecio.Text = seleccionado.Precio.ToString();

                    }
                    else
                    {
                        lblNombre.Text = "Selección inválida";

                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }

        }

        protected void btnCarritoAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                //Cargo el carrito
                if (Request.QueryString["ID"] != null)
                {
                    //Consulto si el articulo ya fue agregado
                    foreach (Articulo item in aux)
                    {
                        if (item.Id == Convert.ToInt32(Request.QueryString["ID"]))
                        {
                            auxBit = true;
                        }
                    }

                    //Cargo el articulo en la lista
                    if (!auxBit)
                    {
                        aux.Add(negocio.listarID(Convert.ToInt32(Request.QueryString["ID"])));
                        Session.Add("listaCarrito", aux);
                    }
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