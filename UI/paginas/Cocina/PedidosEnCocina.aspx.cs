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
                if(var.CodigoEstado == "1" || var.CodigoEstado == "2")
                {

                } else
                {
                    crearLabel(var);
                    crearPedidos(var);
                    crearButton(var);
                }
                
            }
            //limpiarPaneles();
            


        }

        protected void crearLabel(BL_Pedido pedido)
        {
            PH_NombrePedido = new PlaceHolder();
            lbNombrePedido = new Label();
            lbNombrePedido.Text = "Numero de pedido: " + pedido.Numero;
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
        protected void crearPedidos(BL_Pedido pedido)
        {            
            List<BL_Detalle_Pedido> listaDetalle = pedido.Detalles;
            PH_DetallePedidos = new PlaceHolder();

            Literal lite = new Literal();
            lite.Text = "<h4>Platos del pedido</h4>";
            PH_DetallePedidos.Controls.Add(lite);

            foreach (BL_Detalle_Pedido var in listaDetalle)
            {
                lbDetallePedido = new Label();
                lbDetallePedido.Text = var.NombrePlato + ". ";
                PH_DetallePedidos.Controls.Add(lbDetallePedido);
            }
            lite = new Literal();
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