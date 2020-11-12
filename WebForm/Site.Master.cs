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
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            //btnBuscar.Text = txtBuscar.Text;
        }
    }
}