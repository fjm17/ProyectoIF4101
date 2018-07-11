using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace UI
{
    public partial class AdministrarPedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Manejador_Lista_Pedidos manejador = new Manejador_Lista_Pedidos();
            manejador.MostrarTodosPedidos();
            grdListaPediso.DataSource = manejador.Pedidos;
            grdListaPediso.DataBind();
        }
    }
}