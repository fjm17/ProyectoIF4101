using System;
using System.Collections.Generic;
using BL;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebServices.WS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WSRESTCliente" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select WSRESTCliente.svc or WSRESTCliente.svc.cs at the Solution Explorer and start debugging.
    public class WSRESTCliente : IWSRESTCliente
    {
        public void DoWork()
        {
        }

        public List<bool> IniciarSesion(string correo, string contrasena)
        {
            Manejador_Usuario manUsuario = new Manejador_Usuario();
            return new List<bool>() { manUsuario.SeleccionarUsuario(correo, contrasena) };
        }
    }
}
