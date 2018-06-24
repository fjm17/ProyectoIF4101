using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TO
{
    public class TO_Manejador_Lista_Usuario
    {
        public List<TO_Usuario> Usuarios { get; set; }

        public TO_Manejador_Lista_Usuario()
        {
            Usuarios = new List<TO_Usuario>();
        }

        public void AgregarUsuario(TO_Usuario entrada)
        {
            Usuarios.Add(entrada);
        }

    }
}
