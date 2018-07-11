﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace UI.paginas.Administrador
{
    public partial class AgregarPlato : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string ruta = "";
            if (fileFoto.HasFile)
            {
                string nombreArchivo = fileFoto.FileName;
                ruta = "/images/" + nombreArchivo;
                fileFoto.SaveAs(Server.MapPath(ruta));
            }

            Manejador_Plato m = new Manejador_Plato();
            Boolean resultado = m.InsertarPlato(tbNombre.Text, tbDescripcion.Text, double.Parse(tbPrecio.Text),
                ruta, tbEstado.Text);
            if (resultado)
            {
                mostrarMensaje("El plato se agregó correctamente");
                limpiar();
            }
            else
            {
                mostrarMensaje("El plato no se pudo agregar al menú");
            }
        }

        private void mostrarMensaje(string mensaje)
        {
            Response.Write("<script>alert('" + mensaje + "');</script>");
        }

        private void limpiar()
        {
            tbNombre.Text = "";
            tbDescripcion.Text = "";
            tbEstado.Text = "";
            fileFoto.Dispose();
            tbPrecio.Text = "";
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuAdministrador.aspx");
        }
    }
}