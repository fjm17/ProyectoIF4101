using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace UI
{
    public partial class MostrarPlato : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Manejador_Plato m = new Manejador_Plato();
            Boolean resultado = m.SeleccionarPlato(tbNombre.Text.Trim());

            if (resultado)
            {
                tbDescripcion.Text = m.Plato.Descripcion;
                tbPrecio.Text = m.Plato.Precio.ToString();
                tbFoto.Text = m.Plato.Foto;
                tbEstado.Text = m.Plato.Estado;
            }
            else
            {
                mostrarMensaje("No se puede mostrar el plato o no existe en el menú");
            }
        }

        private void mostrarMensaje(string mensaje)
        {
            Response.Write("<script>alert('" + mensaje + "');</script>");
        }
    }
}