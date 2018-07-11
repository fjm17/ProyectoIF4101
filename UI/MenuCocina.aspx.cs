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

        private Label l2;
        private Button b1;
        private PlaceHolder PH_NombrePedido;
        private PlaceHolder PH_ButtonPedido;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void crearLabel(string nombre)
        {
            PH_NombrePedido = new PlaceHolder();
            l2 = new Label();
            l2.ID = "lb"+ nombre;
            l2.Text = nombre;
            PanelNombres.Controls.Add(PH_NombrePedido);
            PH_NombrePedido.Controls.Add(l2);
        }

        protected void btnDeshacer_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('button');</script>");
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            Response.Write("<script>alert('Esto es magia, " + bt.Text + "');</script>");

        }

        protected void btnDeshacer_Click1(object sender, EventArgs e)
        {
            
            Response.Write("<script>alert('" + lb.Text + "');</script>");

        }
    }
}