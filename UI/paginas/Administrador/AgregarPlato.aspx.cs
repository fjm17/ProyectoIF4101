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
            Manejador_Plato m = new Manejador_Plato();
            Boolean resultado = m.InsertarPlato(tbNombre.Text, tbDescripcion.Text, double.Parse(tbPrecio.Text),
                fileFoto.FileName, tbEstado.Text);
            if (resultado)
            {
                mostrarMensaje("El plato se agregó correctamente");
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

    }
}