using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
namespace UI
{
    public partial class AdministrarEstados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<BL_Estado_Pedido> estados = new List<BL_Estado_Pedido>();
                estados.Add(new BL_Estado_Pedido("3", "A Tiempo", 0));
                estados.Add(new BL_Estado_Pedido("4", "Sobre Tiempo", 0));
                estados.Add(new BL_Estado_Pedido("5", "Demorado", 0));

                ddlEstados.DataTextField = "Estado";
                ddlEstados.DataValueField = "Codigo";
                ddlEstados.DataSource = estados;
                ddlEstados.DataBind();
            }

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuAdministrador.aspx");
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Manejador_Pedido manejador = new Manejador_Pedido();
            Boolean actualizado = manejador.ModificarTiempoEstado(ddlEstados.SelectedValue, int.Parse(txtTiempo.Text));
            if (actualizado)
            {
                mostrarMensaje("Se ha modificado con exito el tiempo del estado");
            }
            else
            {
                mostrarMensaje("Ha ocurrido un error al intentar modificar el tiempo del estado");
            }
            txtTiempo.Text = "";
        }

        private void mostrarMensaje(string mensaje)
        {
            Response.Write("<script>alert('" + mensaje + "');</script>");
        }

        protected void ddlEstados_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}