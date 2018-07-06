using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class BarraNavegacion : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void linkInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.html");
        }

        protected void linkCerrarSesion_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("InicioSesion.aspx");
        }
    }
}