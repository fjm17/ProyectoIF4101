﻿using System;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (Session["Rol"] == null || !Session["Rol"].ToString().Equals("Cocina"))
            {
                Response.Redirect("~/InicioSesion.aspx");
            }*/
            //string script = "function f(){var button = $find(\'" + Pedido1.ClientID + "\');button.set_enabled(false); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            //ScriptManager.RegisterOnSubmitStatement(this, this.GetType(), "Onsubmit1", script);
            Session["Array"] = strs;

            



        }

        protected void Pedido1_Click(object sender, EventArgs e)
        {
            BL_Plato plato = new BL_Plato();
            //plato.prueba(lbPedido.Text);
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