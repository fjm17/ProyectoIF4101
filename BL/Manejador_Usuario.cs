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

        public Boolean InsertarUsuario(string correo, string nombre_completo, string direccion, string contrasenna, string tipo)
        {
            DAOUsuario daoUsuario = new DAOUsuario();
            TO_Usuario to_usuario = new TO_Usuario(correo, nombre_completo, direccion, contrasenna, 
                tipo, (tipo.Equals("Cliente") ? "Habilitado" : "Otro"));
            return daoUsuario.Insertar(to_usuario);
        }

        public Boolean SeleccionarUsuario(string correo, string contrasena)
        {
            DAOUsuario daoUsuario = new DAOUsuario();
            TO_Usuario to_usuario = new TO_Usuario();
            to_usuario.Correo = correo;
            to_usuario.Contrasena = contrasena;
            if (daoUsuario.Mostrar(to_usuario))
            {
                if (to_usuario.Tipo.Equals("Cliente") && !to_usuario.EstadoCuenta.Equals("Habilitado"))
                {
                    return false;
                }
                else
                {
                    Usuario.Correo = to_usuario.Correo;
                    Usuario.Nombre_Completo = to_usuario.Nombre_Completo;
                    Usuario.Direccion = to_usuario.Direccion;
                    Usuario.Contrasena = "";
                    Usuario.Tipo = to_usuario.Tipo;
                    return true;
                }
            }
            return false;
        }

        public Boolean ActualizarUsuario(string correo, string nombre_completo, string direccion, string contrasenna, string tipo, string estadoCuenta)
        {
            DAOUsuario daoUsuario = new DAOUsuario();
            TO_Usuario toUsuario = new TO_Usuario(correo, nombre_completo, direccion, tipo, estadoCuenta);
            return daoUsuario.Actualizar(toUsuario);
        }


        public Boolean EliminarUsuario(string correo)
        {
            DAOUsuario daoUsuario = new DAOUsuario();
            TO_Usuario toUsuario = new TO_Usuario();
            toUsuario.Correo = correo;
            return daoUsuario.Eliminar(toUsuario);
        }

    }
}
