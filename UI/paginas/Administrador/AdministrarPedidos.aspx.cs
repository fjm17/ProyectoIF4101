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

        Manejador_Lista_Pedidos manejador = new Manejador_Lista_Pedidos();
        Manejador_Pedido manePedido = new Manejador_Pedido();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                esconderComponentes();
                activarFiltracion();
                asignarManejador();
                activarPorEstados();


                
            }
        }

        private void mostrarMensaje(string mensaje)
        {
            Response.Write("<script>alert('" + mensaje + "');</script>");
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuAdministrador.aspx");
        }

        private void asignarManejador()
        {
            manejador.MostrarTodosPedidos();
            Session["manejador"] = manejador.Pedidos;
        }

        protected void ddlFiltrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            if(ddlFiltrar.SelectedValue.Equals("Por Cliente")){
                esconderComponentes();
                lblXCliente.Visible = true;
                txtCliente.Visible = true;
                btnBuscarCliente.Visible = true;
            }

            if (ddlFiltrar.SelectedValue.Equals("Por Fecha"))
            {
                esconderComponentes();
                lblFecha1.Visible = true;
                lblFecha2.Visible = true;
                txtFecha1.Visible = true;
                txtFecha2.Visible = true;
                btnBuscarFecha.Visible = true;
                lblFormato.Visible = true;

            }

            if(ddlFiltrar.SelectedValue.Equals("Por Estado"))
            {
                esconderComponentes();
                lblXEstado.Visible = true;
                ddlEstados.Visible = true;
            }
        }

        private void esconderComponentes()
        {
            lblXCliente.Visible = false;
            lblFecha1.Visible = false;
            lblFecha2.Visible = false;
            lblXEstado.Visible = false;
            lblFormato.Visible = false;

            txtCliente.Visible = false;
            txtFecha1.Visible = false;
            txtFecha2.Visible = false;

            ddlEstados.Visible = false;

            btnBuscarCliente.Visible = false;
            btnBuscarFecha.Visible = false;
        }

        private void activarFiltracion()
        {
            ddlFiltrar.Items.Add("Por Cliente");
            ddlFiltrar.Items.Add("Por Fecha");
            ddlFiltrar.Items.Add("Por Estado");
            ddlFiltrar.DataBind();
        }

        private void activarPorEstados()
        {
            List<BL_Estado_Pedido> estados = new List<BL_Estado_Pedido>();
            estados.Add(new BL_Estado_Pedido("1", "Entregado", 0));
            estados.Add(new BL_Estado_Pedido("2", "Anulado", 0));
            estados.Add(new BL_Estado_Pedido("3", "A Tiempo", 0));
            estados.Add(new BL_Estado_Pedido("4", "Sobre Tiempo", 0));
            estados.Add(new BL_Estado_Pedido("5", "Demorado", 0));

            ddlEstados.DataTextField = "Estado";
            ddlEstados.DataValueField = "Codigo";
            ddlEstados.DataSource = estados;
            ddlEstados.DataBind();

            List<BL_Estado_Pedido> estadosCambiar = new List<BL_Estado_Pedido>();
            estadosCambiar.Add(new BL_Estado_Pedido("1", "Entregado", 0));
            estadosCambiar.Add(new BL_Estado_Pedido("2", "Anulado", 0));

            ddlEstadosModificar.DataTextField = "Estado";
            ddlEstadosModificar.DataValueField = "Codigo";
            ddlEstadosModificar.DataSource = estadosCambiar;
            ddlEstadosModificar.DataBind();
        }

        protected void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            manejador.BuscarPedidos(txtCliente.Text);
            Session["manejador"] = manejador.Pedidos;
        }

        protected void ddlEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            manejador.MostrarPedidoEstados(ddlEstados.SelectedValue);
            Session["manejador"] = manejador.Pedidos;

        }

        protected void btnBuscarFecha_Click(object sender, EventArgs e)
        {
            DateTime fe1 = DateTime.Parse(txtFecha1.Text);
            DateTime fe2 = DateTime.Parse(txtFecha2.Text);

            manejador.MostrarPedidoFecha(fe1, fe2);
            Session["manejador"] = manejador.Pedidos;
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Manejador_Pedido manejadorPe = new Manejador_Pedido();
            Boolean cambioEstado = manejadorPe.ActualizarPedido(int.Parse(txtModificar.Text), ddlEstadosModificar.SelectedValue);

            if (cambioEstado)
            {
                mostrarMensaje("Cambio de Estado con Exito");
            }
            else
            {
                mostrarMensaje("Ocurrio un error al intentar cambiar el estado del Estado");
            }

            txtModificar.Text = "";
            manejador.MostrarTodosPedidos();
            Session["manejador"] = manejador.Pedidos;
        }

        protected void ddlEstadosModificar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}