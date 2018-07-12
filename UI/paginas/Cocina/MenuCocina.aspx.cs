using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace UI
{
    public partial class MenuCocina : System.Web.UI.Page
    {
        string[] strs = new string[] { "Hola", "Mundo", "Cruel", "es", "Bueno"};

        private Label lbNombrePedido;
        private Label lbDetallePedido;
        private Button b1;
        private PlaceHolder PH_NombrePedido;
        private PlaceHolder PH_ButtonPedido;
        private PlaceHolder PH_DetallePedidos;
        private List<BL_Pedido> listaPedidos;
        private List<Button> listaBotones;

        public BL_Pedido pe { get; set; }

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

                        mostrarMensaje("Get Out.");
                        Response.Redirect(pagina);
                    }
                }
            }
            else
            {
                Response.Redirect("~/InicioSesion.aspx");
            }

            
            
            if (!IsPostBack)
            {
                
                
            }
            listaBotones = new List<Button>();
            manejarBotones();


        }
        protected void manejarBotones()
        {
            foreach(BL_Pedido var in listaPedidos)
            {
                crearButton(var);
                listaBotones.Add(b1);
            }
        }
        protected void pruebas()
        {            
                limpiarPaneles();
                crearLabel(pe);
                crearPedidos(pe);
                
                
        }

        protected void limpiarPaneles()
        {
            PanelNombres.Controls.Remove(PH_NombrePedido);
            //PanelBotones.Controls.Remove(PH_ButtonPedido);
            PanelDetallesPedidos.Controls.Remove(PH_DetallePedidos);
        }

        protected void crearLabel(BL_Pedido pedido)
        {
            PH_NombrePedido = new PlaceHolder();
            lbNombrePedido = new Label();
            lbNombrePedido.ID = "lb"+ pedido.CorreoCliente;
            lbNombrePedido.Text = pedido.Numero + "";
            PanelNombres.Controls.Add(PH_NombrePedido);
            PH_NombrePedido.Controls.Add(lbNombrePedido);
        }
        protected void crearButton(BL_Pedido pedido)
        {
            
            b1 = new Button();
            b1.ID = "btn" + pedido.Numero;
            b1.Text = "Finalizar: " + pedido.Numero;
            b1.Click += new System.EventHandler(Button1_Click);
            
        }

        protected void asignarBoton(int posicion)
        {
            PanelBotones.Controls.Remove(PH_ButtonPedido);
            PH_ButtonPedido = new PlaceHolder();
            PanelBotones.Controls.Add(PH_ButtonPedido);
            PH_ButtonPedido.Controls.Add(listaBotones[posicion]);
            
        }
        protected void crearPedidos(BL_Pedido pedido)
        {
            PH_DetallePedidos = new PlaceHolder();
            string[] vec = { "Pedido 1", "Pedido 2", "Pedido 3" };
            foreach (string var in vec)
            {
                lbDetallePedido = new Label();
                lbDetallePedido.Text = var;
                PH_DetallePedidos.Controls.Add(lbDetallePedido);
                Literal lite = new Literal();
                lite.Text = "<br/>";
                PH_DetallePedidos.Controls.Add(lite);
            }
            PanelDetallesPedidos.Controls.Add(PH_DetallePedidos);

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            Response.Write("<script>alert('Esto es magia, " + bt.Text + "');</script>");
            btnDeshacer.Text = "Si dentra al metodo";
        }

        protected void btnDeshacer_Click1(object sender, EventArgs e)
        {            
            Response.Write("<script>alert('Algo paso aqui');</script>");
        }

        private void mostrarMensaje(string mensaje)
        {
            Response.Write("<script>alert('" + mensaje + "');</script>");
        }
    }
}