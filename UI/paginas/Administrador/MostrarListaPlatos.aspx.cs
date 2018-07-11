using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.paginas.Administrador
{
    public partial class MostrarListaPlatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Rol"] != null)
            {
                string rol = Session["Rol"].ToString();
                if (!String.IsNullOrEmpty(rol))
                {
                    if (!rol.Equals("Administrador"))
                    {
                        string pagina = rol.Equals("Cocina") ?
                            "~/paginas/Cocina/MenuCocina.aspx" : "~/Aplicacion Cliente/PaginaInicio.html";

                        Response.Redirect(pagina);
                    }
                }
            }
            else
            {
                Response.Redirect("~/InicioSesion.aspx");
            }
        }
    }
}