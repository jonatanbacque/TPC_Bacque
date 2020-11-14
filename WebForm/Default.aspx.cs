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

        public List<Articulo> aux;

        public bool auxBit = new bool();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Consulto si la lista esta vacia para inicializarla
                if (Session["listado"] != null)
                {
                    listaArticulos = (List<Articulo>)Session["listado"];
                }
                else
                {
                    listaArticulos = new List<Articulo>();
                }

                //Consulto si la lista esta vacia para inicializarla
                if (Session["listaCarrito"] != null)
                {
                    aux = (List<Articulo>)Session["listaCarrito"];
                }
                else
                {
                    aux = new List<Articulo>();
                }


                //Si no hay busqueda, muestro lista completa
                listaArticulos = negocio.listar();
                Session.Add("listado", listaArticulos);

                //Filtrado por busqueda
                if (Request.QueryString["nombre"] != null)
                {
                    listaArticulos = negocio.Buscar(Request.QueryString["nombre"]);
                    Session.Add("listado", listaArticulos);
                }

                //Filtrado por articulo
                if (Request.QueryString["categ"] != null)
                {
                    listaArticulos = negocio.BuscarCateg(Request.QueryString["categ"]);
                    Session.Add("listado", listaArticulos);
                }

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