using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
namespace UI
{
    public partial class BlquearClientes : System.Web.UI.Page
    {
        static Manejador_Usuario manejador = new Manejador_Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCorreo.Enabled = false;
            txtDireccion.Enabled = false;
            txtEstado.Enabled = false;
            txtNombre.Enabled = false;
            txtTipo.Enabled = false;
            rdbHabilitar.Visible = false;
            rdbInhabilitar.Visible = false;
            btnActualizar.Visible = false;
            lblModificar.Visible = false;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            Boolean encontrado = manejador.SeleccionarUsuario(txtCorreoBuscar.Text, "");

            if (encontrado)
            {
                if (manejador.Usuario.Tipo.Equals("Cliente"))
                {

                    txtNombre.Text = manejador.Usuario.Nombre_Completo;
                    txtCorreo.Text = manejador.Usuario.Correo;
                    txtDireccion.Text = manejador.Usuario.Direccion;
                    txtTipo.Text = manejador.Usuario.Tipo;
                    txtEstado.Text = manejador.Usuario.EstadoCuenta;

                    rdbHabilitar.Visible = true;
                    rdbInhabilitar.Visible = true;
                    btnActualizar.Visible = true;
                    lblModificar.Visible = true;
                }
                else
                {
                    mostrarMensaje("Lo encontro pero no lo valido correcto");
                }
            }
            else
            {
                mostrarMensaje("Usuario no encontrado, verifique que el correo electronico este correcto");
            }
        }
 
        private void mostrarMensaje(string mensaje)
        {
            Response.Write("<script>alert('" + mensaje + "');</script>");
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string estado;
            if (rdbHabilitar.Checked)
            {
                estado = "Habilitado";
            }
            else
            {
                estado = "Deshabilitado";
            }

            Boolean actualizado = manejador.ActualizarUsuario(manejador.Usuario.Correo, manejador.Usuario.Nombre_Completo, manejador.Usuario.Direccion, manejador.Usuario.Contrasena, manejador.Usuario.Tipo, estado);

            if (actualizado)
            {
                mostrarMensaje("Estado de cuenta del usuario ha sido cambiado con exito");

                txtCorreoBuscar.Text = "";
                txtNombre.Text = "";
                txtCorreo.Text = "";
                txtDireccion.Text = "";
                txtTipo.Text = "";
                txtEstado.Text = "";

                rdbHabilitar.Visible = false;
                rdbInhabilitar.Visible = false;
                btnActualizar.Visible = false;
                lblModificar.Visible = false;
            }
            else
            {
                mostrarMensaje("No se pudo actualizar el estado de la cuenta");

                txtCorreoBuscar.Text = "";
                txtNombre.Text = "";
                txtCorreo.Text = "";
                txtDireccion.Text = "";
                txtTipo.Text = "";
                txtEstado.Text = "";

                rdbHabilitar.Visible = false;
                rdbInhabilitar.Visible = false;
                btnActualizar.Visible = false;
                lblModificar.Visible = false;
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuAdministrador.aspx");
        }
    }
}