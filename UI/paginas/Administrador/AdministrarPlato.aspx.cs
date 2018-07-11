using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using System.Text;

namespace UI.paginas.Administrador
{
    public partial class ActualizarPlato : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {

            Manejador_Plato m = new Manejador_Plato();

            Boolean resultado = m.SeleccionarPlato(tbNombre.Text.Trim());

            string ruta = "";

            if (resultado)
            {
                ruta = m.Plato.Foto;
                string nombreArchivo = "";
                if (FileFoto.HasFile)
                {
                    nombreArchivo = FileFoto.FileName;
                    ruta = "/images/" + nombreArchivo;
                    FileFoto.SaveAs(Server.MapPath(ruta));
                }
            }
            m = new Manejador_Plato();

            resultado = m.ActualizarPlato(tbNombre.Text, tbDescripcion.Text, double.Parse(tbPrecio.Text), ruta, tbEstado.Text);
            if (resultado)
            {
                mostrarMensaje("El plato se actualizó correctamente");
                limpiar();
            }
            else
            {
                mostrarMensaje("El plato no se pudo actualizar");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Manejador_Plato m = new Manejador_Plato();
            Boolean resultado = m.SeleccionarPlato(tbNombre.Text.Trim());

            if (resultado)
            {
                tbDescripcion.Text = m.Plato.Descripcion;
                tbPrecio.Text = m.Plato.Precio.ToString();
                tbEstado.Text = m.Plato.Estado;
                Session["nombreFoto"] = m.Plato.Foto;
                ScriptManager.RegisterStartupScript(this, GetType(), "key", "establecerFoto()", true);
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

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Manejador_Plato m = new Manejador_Plato();
            if(m.EliminarPlato(tbNombre.Text))
            {
                mostrarMensaje("El plato se eliminó correctamente");
                limpiar();
            } else
            {
                mostrarMensaje("El plato no se pudo eliminar");
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuAdministrador.aspx");
        }

        private void limpiar()
        {
            tbNombre.Text = "";
            tbDescripcion.Text = "";
            tbEstado.Text = "";
            tbPrecio.Text = "";
            
        }

    }
}
