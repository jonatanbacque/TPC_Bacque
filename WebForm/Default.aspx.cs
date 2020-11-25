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
        public ArticuloNegocio articuloNegocio = new ArticuloNegocio();
        public ElementoNegocio elementoNegocio = new ElementoNegocio();
        public CarritoNegocio carritoNegocio = new CarritoNegocio();
        public List<Articulo> listaArticulos;
        public List<Elemento> listaElementos;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //Cargo el carrito
                    if (Request.QueryString["ID"] != null)
                    {
                        Elemento elemento = new Elemento
                        {
                            carrito = new Carrito(),
                            articulo = new Articulo()
                        };
                        //
                        if (Convert.ToInt32(Session["carrito"]) != 0)
                        {
                            //ya existe un carrito asi que lo cargo en la variable local para saber el ID
                            elemento.carrito.Id = Convert.ToInt32(Session["carrito"]);
                        }
                        else
                        {
                            //Guardo nuevo ID de carrito y agrego articulo  
                            carritoNegocio.agregar(elemento.carrito);
                            elemento.carrito.Id = carritoNegocio.UltimoCarrito();
                            Session.Add("carrito", elemento.carrito.Id);
                        };

                        elemento.articulo.Id = Convert.ToInt32(Request.QueryString["ID"]);
                        elemento.Cantidad = 1;

                        elementoNegocio.agregarArticulo(elemento);

                        Session.Remove("listaElementos");
                        Session.Add("listaElementos", elementoNegocio.listarID(elemento.carrito.Id));
                    }
                }
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
                if (Session["listaElementos"] != null)
                {
                    listaElementos = (List<Elemento>)Session["listaElementos"];
                }
                else
                {
                    listaElementos = new List<Elemento>();
                }


                //Si no hay busqueda, muestro lista completa
                listaArticulos = articuloNegocio.listar();
                Session.Add("listado", listaArticulos);

                //Filtrado por busqueda
                if (Request.QueryString["nombre"] != null)
                {
                    listaArticulos = articuloNegocio.Buscar(Request.QueryString["nombre"]);
                    Session.Add("listado", listaArticulos);
                }

                //Filtrado por articulo
                if (Request.QueryString["categ"] != null)
                {
                    listaArticulos = articuloNegocio.BuscarCateg(Request.QueryString["categ"]);
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