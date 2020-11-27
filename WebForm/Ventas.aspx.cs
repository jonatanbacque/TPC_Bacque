using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm
{
    public partial class Ventas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnListado_Click(object sender, EventArgs e)
        {
            Response.Redirect("Listado.aspx");
        }

        protected void btnEdicion_Click(object sender, EventArgs e)
        {
            Response.Redirect("VentasEditar.aspx");
        }
    }
}