using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace UI
{
    public partial class AdministrarUsuario : System.Web.UI.Page
    {
        static Manejador_Usuario manejador = new Manejador_Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            txtNombre.Enabled = false;
            txtDireccion.Enabled = false;
            txtTipo.Enabled = false;

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Boolean usuarioEncontrado = manejador.SeleccionarUsuario(txtCorreoBuscar.Text, "");

            if (usuarioEncontrado)
            {
                txtNombre.Enabled = true;
                txtDireccion.Enabled = true;

                txtNombre.Text = manejador.Usuario.Nombre_Completo;
                txtDireccion.Text = manejador.Usuario.Direccion;
                txtTipo.Text = manejador.Usuario.Tipo;
                

            }
            else {
                mostrarMensaje("No se encontro el usuario, verifique que el correo este correcto o que el mismo pertenezca a un usuario valido");
            }
        }

        private void mostrarMensaje(string mensaje)
        {
            Response.Write("<script>alert('" + mensaje + "');</script>");
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Boolean actualizado = manejador.ActualizarUsuario(manejador.Usuario.Correo, txtNombre.Text, txtDireccion.Text, manejador.Usuario.Contrasena, manejador.Usuario.Tipo, manejador.Usuario.EstadoCuenta);

            txtCorreoBuscar.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTipo.Text = "";

            if (actualizado)
            {
                mostrarMensaje("Usuario actualizado con exito");
            }
            else
            {
                mostrarMensaje("Ocurrio un error al actualizar el usuario");
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Boolean eliminado = manejador.EliminarUsuario(txtCorreoBuscar.Text);

            if (eliminado)
            {
                mostrarMensaje("Usuario eliminado con exito");
            }
            else
            {
                mostrarMensaje("Ocurrio un error al intentar eliminar el usuario");
            }

            txtCorreoBuscar.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTipo.Text = "";
        }
    }
}