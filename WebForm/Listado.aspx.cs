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
    public partial class Listado : System.Web.UI.Page
    {
        ArticuloNegocio negocio = new ArticuloNegocio();

        Articulo aux;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Cargo lista completa
                dgvArticulos.DataSource = negocio.listar();
                dgvArticulos.DataBind();


            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void dgvArticulos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int aux = 1;
                int idLocal = new int();

                foreach (Articulo item in negocio.listar())
                {
                    if (aux == Convert.ToInt32(e.CommandArgument) + 1) idLocal = item.Id;
                    aux++;
                }

                Session.Add("articuloId", idLocal);
            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }

            Response.Redirect("Articulos.aspx");
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Add("articuloId", 0);
            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }

            Response.Redirect("Articulos.aspx");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

    }
}
