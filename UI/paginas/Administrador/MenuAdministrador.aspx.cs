using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.paginas.Administrador
{
    public partial class MenuAdministrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (Session["Rol"] == null || !Session["Rol"].ToString().Equals("Administrador")) 
            {
                Response.Redirect("~/InicioSesion.aspx");
            }*/
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdministrarPlatos.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdministrarPlatos.aspx");
        }
    }
}