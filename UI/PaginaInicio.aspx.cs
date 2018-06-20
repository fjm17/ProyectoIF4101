using System;
using System.Net.Mail;
using BL;

namespace UI
{
    public partial class PaginaInicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (correoValido() && !camposVacios())
            {
                Manejador_Usuario m = new Manejador_Usuario();
                Boolean resultado = m.SeleccionarCliente(tbCorreo.Text, tbContrasena.Text);

                if (!resultado)
                {
                    mostrarMensaje("El usuario no se ha encontrado!");
                }
                else
                {
                    string tipo = m.Usuario.Tipo;
                    proximaPagina(tipo);
                    /*Para pruebas*/mostrarMensaje("Usuario Encontrado");
                    Session["Loggeado"] = true;
                }

            }
        }

        private void proximaPagina(string tipo)
        {
            /*Dependiendo del tipo de usuario que se recuperó, se
            redireccionara a la pagina correspondiente.*/
            switch (tipo)
            {
                case "Administrador":
                    
                    break;
                //El caso cocina, también caso por defecto.
                case "Cocina":
                default:

                    break;
            }
        }

        private Boolean camposVacios()
        {
            if (String.IsNullOrEmpty(tbContrasena.Text) || String.IsNullOrEmpty(tbContrasena.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Boolean correoValido()
        {
            try
            {
                MailAddress ma = new MailAddress(tbCorreo.Text);
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
    }
}