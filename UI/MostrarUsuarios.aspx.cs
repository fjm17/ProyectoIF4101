using System;
using BL;


namespace UI
{
    public partial class MostrarUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbBusqueda.Text))
            {
                mostrarMensaje("¡No hay criterio de busqueda!");
            }
            else
            {
                buscar();
            }
        }

        private void buscar()
        {
            Manejador_Lista_Usuario usuarios = new Manejador_Lista_Usuario();
            usuarios.BuscarUsuarios(tbBusqueda.Text);
            gvUsuarios.DataSource = usuarios.Usuarios;
            gvUsuarios.DataBind();
        }

        private void mostrarMensaje(string mensaje)
        {
            Response.Write("<script>alert('" + mensaje + "');</script>");
        }

        protected void tbBusqueda_TextChanged(object sender, EventArgs e)
        {
            mostrarMensaje("I'm being changed");
            if (!String.IsNullOrEmpty(tbBusqueda.Text))
            {
                buscar();
                mostrarMensaje("I'm being changed");
            }
        }
    }
}