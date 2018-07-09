using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace UI
{
    public partial class AdministrarPlatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Manejador_Lista_Platos lista = new Manejador_Lista_Platos();
            lista.BuscarPlatos("");
            grdPlatos.DataSource = lista.Platos;
            grdPlatos.DataBind();

        }
    }
}