using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TO;
using DAO;


namespace BL
{
    public class Manejador_Usuario
    {
        public BL_Usuario Usuario { get; }

        public Manejador_Usuario()
        {
            Usuario = new BL_Usuario();
        }

        public Boolean SeleccionarCliente(string correo)
        {
            DAOUsuario daoUsuario = new DAOUsuario();
            TO_Usuario to_usuario = new TO_Usuario();
            to_usuario.Correo = correo;
            if (daoUsuario.Mostrar(to_usuario))
            {
                Usuario.Correo = to_usuario.Correo;
                Usuario.Nombre_Completo = to_usuario.Nombre_Completo;
                Usuario.Direccion = to_usuario.Direccion;
                Usuario.Contrasena = to_usuario.Contrasena;
                Usuario.Tipo = to_usuario.Tipo;
                return true;
            }
            return false;
        }
    }
}
