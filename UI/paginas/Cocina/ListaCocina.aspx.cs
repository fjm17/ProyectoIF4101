using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.paginas.Cocina
{
    public partial class ListaCocina : System.Web.UI.Page
    {

        string[] strs = new string[] { "Hola", "Cruel es bueno", "Prueba" };
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Array"] = strs;

            //pruebas();
            
        }
        public void pruebas ()
        {
            foreach (string var in strs)
            {
                PlaceHolder PlaceHolder1 = new PlaceHolder();

                    Label l2 = new Label();
                    //l2.ID = "lblPedido1" + i;
                    l2.Text = var ;

                    Button b1 = new Button();
                    //b1.ID = "btn1" + i;
                    b1.Text = var;
                    b1.Click += new System.EventHandler(btn_click);

                    PlaceHolder1.Controls.Add(l2);
                    PlaceHolder1.Controls.Add(b1);

          
                Panel1.Controls.Add(PlaceHolder1);
            }

        }
        protected void btn_click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            Response.Write("<script>alert('Esto es magia, " + bt.Text + "');</script>");
            
        }
    }
}