using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TO;
using DAO;

namespace BL
{
    public class Manejador_Lista_Usuario
    {
        public List<BL_Usuario> Usuarios { get; set; }

        public Manejador_Lista_Usuario()
        {
            Usuarios = new List<BL_Usuario>();
        }

        public void AgregarUsuario(BL_Usuario entrada)
        {
            Usuarios.Add(entrada);
        }

        public void BuscarUsuarios(string nombre)
        {
            TO_Manejador_Lista_Usuario toUsuarios = new TO_Manejador_Lista_Usuario();
            DAOUsuario daoUsuario = new DAOUsuario();
            daoUsuario.MostrarUsuarios(toUsuarios, nombre);
            ConvertirLista(toUsuarios);
        }

        public void ConvertirLista(TO_Manejador_Lista_Usuario toUsuarios)
        {
            foreach (TO_Usuario toUsuario in toUsuarios.Usuarios)
            {
                AgregarUsuario(new BL_Usuario(toUsuario.Correo, toUsuario.Nombre_Completo, 
                    toUsuario.Direccion, toUsuario.Tipo, toUsuario.EstadoCuenta));
            }
        }

    }
}
