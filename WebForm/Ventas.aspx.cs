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
    public partial class Ventas : System.Web.UI.Page
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
                int id = Convert.ToInt32(e.CommandArgument)+1;
                Session.Add("articuloId", id);
            }
            catch (Exception ex)
            {
                Session.Add("errorEncontrado", ex.ToString());
                Response.Redirect("Error.aspx");
            }

            Response.Redirect("Articulos.aspx");
        }
    }
}