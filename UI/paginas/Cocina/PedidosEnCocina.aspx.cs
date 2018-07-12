using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace UI.paginas.Cocina
{
    public partial class PedidosEnCocina : System.Web.UI.Page
    {
        private List<BL_Pedido> listaPedidos;
        private Label lbNombrePedido;
        private Label lbDetallePedido;
        private Button b1;
        private PlaceHolder PH_NombrePedido;
        private PlaceHolder PH_ButtonPedido;
        private PlaceHolder PH_DetallePedidos;

        protected void Page_Load(object sender, EventArgs e)
        {
            Manejador_Lista_Pedidos manejar = new Manejador_Lista_Pedidos();
            manejar.MostrarTodosPedidos();
            listaPedidos = manejar.Pedidos;

            Session["Array"] = listaPedidos;

            pruebas();
        }

        protected void pruebas()
        {
            foreach (BL_Pedido var in listaPedidos)
            {
                crearLabel(var);
                crearPedidos(var);
                crearButton(var);
            }
            //limpiarPaneles();
            


        }

        //protected void limpiarPaneles()
        //{
        //    PanelNombres.Controls.Remove(PH_NombrePedido);
        //    //PanelBotones.Controls.Remove(PH_ButtonPedido);
        //    PanelDetallesPedidos.Controls.Remove(PH_DetallePedidos);
        //}

        protected void crearLabel(BL_Pedido pedido)
        {
            PH_NombrePedido = new PlaceHolder();
            lbNombrePedido = new Label();
            lbNombrePedido.ID = "lb" + pedido.CorreoCliente;
            lbNombrePedido.Text = "Persona que realizo el pedido, Numero de pedido: " + pedido.Numero;
            Panel1.Controls.Add(PH_NombrePedido);
            Literal lite = new Literal();
            lite.Text = "<br/>";
            Panel1.Controls.Add(lite);
            
            PH_NombrePedido.Controls.Add(lbNombrePedido);
        }
        protected void crearButton(BL_Pedido pedido)
        {

            b1 = new Button();
            b1.ID = "btn" + pedido.Numero;
            b1.Text = "Finalizar: " + pedido.Numero;
            b1.Click += new System.EventHandler(Button1_Click);
            PH_ButtonPedido = new PlaceHolder();
            Panel1.Controls.Add(PH_ButtonPedido);
            PH_ButtonPedido.Controls.Add(b1);
            Literal lite = new Literal();
            lite.Text = "<br/> <br/>";
            Panel1.Controls.Add(lite);
        }

        //protected void asignarBoton(int posicion)
        //{
            
        //    PH_ButtonPedido = new PlaceHolder();
        //    Panel1.Controls.Add(PH_ButtonPedido);
        //    PH_ButtonPedido.Controls.Add(b1);

        //}
        protected void crearPedidos(BL_Pedido pedido)
        {
            PH_DetallePedidos = new PlaceHolder();
            string[] vec = { "Pedido 1", "Pedido 2", "Pedido 3" };
            foreach (string var in vec)
            {
                lbDetallePedido = new Label();
                lbDetallePedido.Text = var + ". ";
                PH_DetallePedidos.Controls.Add(lbDetallePedido);
            }
            Literal lite = new Literal();
            lite.Text = "<br/>";
            PH_DetallePedidos.Controls.Add(lite);
            Panel1.Controls.Add(PH_DetallePedidos);

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            Response.Write("<script>alert('Esto es magia, " + bt.Text + "');</script>");
            //btnDeshacer.Text = "Si dentra al metodo";
        }
        protected void btnDeshacer_Click1(object sender, EventArgs e)
        {
            Response.Write("<script>alert('Algo paso aqui');</script>");
        }
    }
}