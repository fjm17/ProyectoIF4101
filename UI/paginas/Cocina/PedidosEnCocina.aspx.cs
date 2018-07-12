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
        private Estatico ultimoFinalizado = Estatico.getInstance();
        private int contador = 0;
        private bool masPedidos = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Rol"] != null)
            {
                string rol = Session["Rol"].ToString();
                if (!String.IsNullOrEmpty(rol))
                {
                    if (!rol.Equals("Cocina"))
                    {
                        string pagina = rol.Equals("Administrador") ?
                            "~/paginas/Administrador/MenuAdministrador.aspx" : "~/Aplicacion Cliente/PaginaInicio.html";

                        Response.Redirect(pagina);
                    }
                }
            }
            else
            {
                Response.Redirect("~/InicioSesion.aspx");
            }

            Manejador_Lista_Pedidos manejar = new Manejador_Lista_Pedidos();
            manejar.MostrarTodosPedidos();
            listaPedidos = manejar.Pedidos;

            //Session["Array"] = listaPedidos;

            pruebas();
        }

        protected void pruebas()
        {
            foreach (BL_Pedido var in listaPedidos)
            {
                
                if(var.CodigoEstado == "1" || var.CodigoEstado == "2")
                {

                }
                else
                {
                    if (contador < 7)
                    {
                        crearLabel(var);
                        crearPedidos(var);
                        crearButton(var);
                        contador++;
                    }else
                    {
                        if (masPedidos)
                        {
                            lbNombrePedido = new Label();
                            lbNombrePedido.Text = "Hay mas pedidos";
                            Panel1.Controls.Add(lbNombrePedido);
                            masPedidos = false;
                        }
                    }
                    
                }
                
            }
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
            if (Int32.Parse(pedido.CodigoEstado) == 3)
            {
                b1.BackColor = System.Drawing.Color.Green;
            }
            else if (Int32.Parse(pedido.CodigoEstado) == 4)
            {
                b1.BackColor = System.Drawing.Color.Gold;
            }
            else if (Int32.Parse(pedido.CodigoEstado) == 5)
            {
                b1.BackColor = System.Drawing.Color.Red;
            }
            
            b1.ID = "" + pedido.Numero;
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
            Manejador_Pedido manejador = new Manejador_Pedido();

            manejador.SeleccionarPedido(Int32.Parse(bt.ID));
            ultimoFinalizado.pedido = manejador.Pedido;
            ultimoFinalizado.pedido.Numero = Int32.Parse(bt.ID);
            ultimoFinalizado.usado = false;

            bool cambio = manejador.modificarEstado(Int32.Parse(bt.ID), 1);

            if (cambio)
            {
                //Response.Write("<script>alert('Se finalizo el pedido');</script>");
                Response.Redirect("/paginas/Cocina/PedidosEnCocina.aspx");
            } else
            {
               // Response.Write("<script>alert('No se pudo finalizar');</script>");
                Response.Redirect("/paginas/Cocina/PedidosEnCocina.aspx");
            }

        }
        protected void btnDeshacer_Click1(object sender, EventArgs e)
        {
            if(ultimoFinalizado.usado)
            {
                Response.Write("<script>alert('Ya se devolvio el ultimo pedido');</script>");
            } else
            {
                Manejador_Pedido manejador = new Manejador_Pedido();
                manejador.modificarEstado(ultimoFinalizado.pedido.Numero, Int32.Parse(ultimoFinalizado.pedido.CodigoEstado));
                ultimoFinalizado.usado = true;
                Response.Redirect("/paginas/Cocina/PedidosEnCocina.aspx");
            }
        }
    }

}
