using System;
using System.Net.Mail;
using System.Text;
using BL;
using System.Globalization;

namespace UI
{
    public partial class AgregarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Rol"] != null)
            {
                string rol = Session["Rol"].ToString();
                if (!String.IsNullOrEmpty(rol))
                {
                    if (!rol.Equals("Administrador"))
                    {
                        string pagina = rol.Equals("Cocina") ?
                            "~/paginas/Cocina/MenuCocina.aspx" : "~/Aplicacion Cliente/PaginaInicio.html";

                        Response.Redirect(pagina);
                    }
                }
            }
            else
            {
                Response.Redirect("~/InicioSesion.aspx");
            }
            //Session["TipoUsuario"] = "Cliente";
            //Habrá una variable de Sesión que determine el tipo de usuario que será insertado.
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string tipo = ddlTipo.SelectedValue.ToString();//Session["TipoUsuario"].ToString();
            string contrasena1 = tbContrasenaCrear.Text;
            string contrasena2 = tbContrasenaConfirmar.Text;
            if (camposVacios())
            {
                mostrarMensaje("Error: No pueden faltar datos.");
            }
            else if (!correoValido())
            {
                mostrarMensaje("Error: Dirección de correo electrónico no válida.");
            }
            else if (!contrasenasCoinciden(contrasena1, contrasena2))
            {
                mostrarMensaje("Error: ¡Las contraseñas no coinciden!");
            }
            else
            {
                Manejador_Usuario manejador_usuario = new Manejador_Usuario();
                bool resultado = manejador_usuario.InsertarUsuario(tbCorreo.Text, tbNombre.Text, 
                    tbDireccion.Text, contrasena1, tipo);
                if (resultado)
                {
                    mostrarMensaje("¡Insertado exitosamente!");
                }
                else
                {
                    mostrarMensaje("No se pudo insertar el usuario.");
                }
            }
        }

        private Boolean camposVacios()
        {
            if (valorVacio(tbNombre.Text) || valorVacio(tbCorreo.Text) || valorVacio(tbContrasenaCrear.Text)
                || valorVacio(tbContrasenaConfirmar.Text) || valorVacio(tbDireccion.Text))
            {
                return true;
            }
            else
            {
                return false;  
            }
        }

        private Boolean contrasenasCoinciden(string con1, string con2)
        {
            return con1.Equals(con2);
        }

        private Boolean valorVacio(string valor)
        {
            return String.IsNullOrEmpty(valor);
        }

        private Boolean correoValido()
        {
            try
            {
                MailAddress correo = new MailAddress(tbCorreo.Text);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void mostrarMensaje(string mensaje)
        {
            Response.Write("<script>alert('" + mensaje + "');</script>");
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {

        }
    }
}