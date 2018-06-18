using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace UI
{
    public partial class EliminarPlato : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Manejador_Plato m = new Manejador_Plato();
            Boolean resultado = m.EliminarPlato(tbNombre.Text.Trim());
            if(resultado)
            {
                mostrarMensaje("El plato se eliminó correctamente");
            }
            else
            {
                mostrarMensaje("El plato no se encuentra en el menú o no se pudo eliminar");
            }
        }

        private void mostrarMensaje(string mensaje)
        {
            Response.Write("<script>alert('" + mensaje + "');</script>");
        }
    }
}