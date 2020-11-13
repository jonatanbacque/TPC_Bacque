﻿using System;
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
                if (Session["listaCarrito"] != null)
                {
                    aux = (List<Articulo>)Session["listaCarrito"];
                }
                else
                {
                    aux = new List<Articulo>();
                }

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

                if (Request.QueryString["ID"] != null)
                {
                    foreach (Articulo item in aux)
                    {
                        if (item.Id == Convert.ToInt32(Request.QueryString["ID"]))
                        {
                            auxBit = true;
                        }
                    }

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