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
        public List<Articulo> listaArticulos { get; set; }
        public List<Articulo> aux;
        public Elemento elemento = new Elemento();
        public Carrito carrito;

        bool auxBit = new bool();

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

                //Cargo el carrito
                if (Request.QueryString["ID"] != null)
                {
                    int id;
                    if (Convert.ToInt32(Session["carrito"]) != 0)
                    {
                        //ya existe un carrito asi que lo cargo en la variable local para saber el ID
                        id = Convert.ToInt32(Session["carrito"]);
                    }
                    else
                    {
                        carritoNegocio.agregar(carrito);
                        id = carritoNegocio.UltimoCarrito();
                    };

                    elementoNegocio.agregarArticulo(id, Convert.ToInt32(Request.QueryString["ID"]), 1, 1);

                    Session.Remove("listaCarrito");
                    Session.Add("listaCarrito", elementoNegocio.listarID(id));
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