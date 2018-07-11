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

        string[] strs = new string[] { "Hola" };
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Array"] = strs;

            foreach (string var in strs)
            {
                Label l2 = new Label();
                l2.ID = "lblPedido1";
                l2.Text = var;

                Button b1 = new Button();
                b1.ID = "btn1";
                b1.Text = var;
                b1.Click += new System.EventHandler(btn_click);

                Button b2 = new Button();
                b2.ID = "btn2";
                b2.Text = "Cruel es bueno";
                b2.Click += new System.EventHandler(btn_click);

                PlaceHolder1.Controls.Add(l2);
                PlaceHolder1.Controls.Add(b1);
                PlaceHolder1.Controls.Add(b2);


                //Page.Controls.Add(b1);
            }

        }
        protected void btn_click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            Response.Write("<script>alert('Esto es magia, " + bt.Text + "');</script>");
        }
    }
}