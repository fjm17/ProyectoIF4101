using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;//Se utiliza este namespace para manejar el control de acceso.
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class BarraNavegacion : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string tipo = Session["Rol"] == null ? "" : Session["Rol"].ToString();
            if (tipo == null)
            {
                Response.Redirect("InicioSesion.aspx");
            }
            else if (tipo.Equals("Cocina"))
            {
                linkInicio.Visible = false;
                linkInicio.Enabled = false;
            }
        }

        protected void linkInicio_Click(object sender, EventArgs e)
        {
            string tipo = Session["Rol"] == null ? "" : Session["Rol"].ToString();
            string pagInicio = "";
            if (tipo == null)
            {
                pagInicio = "~/InicioSesion.aspx";
            }
            else
            {
                pagInicio = "~/paginas/Administrador/MenuAdministrador.aspx";
                Response.Redirect(pagInicio);
            }
        }

        protected void linkCerrarSesion_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();//Para cerrar la sesion
            Session.Abandon();//Eliminar datos de sesion
            Response.Redirect("InicioSesion.aspx");
        }
    }
}