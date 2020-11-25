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
                Session.Add("articuloId", Convert.ToInt32(dgvArticulos.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text));
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
    }
}
