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

        string[] strs = new string[] { "Hola", "Mundo" };
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

                PlaceHolder1.Controls.Add(l2);
                PlaceHolder1.Controls.Add(b1);


                //Page.Controls.Add(b1);
            }
        }
    }
}