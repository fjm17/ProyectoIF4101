using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using BL;

namespace UI.WS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WSRESTCliente" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select WSRESTCliente.svc or WSRESTCliente.svc.cs at the Solution Explorer and start debugging.
    /*[AspNetCompatibilityRequirements
        (RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]*/
    public class WSRESTCliente : IWSRESTCliente
    { 

        Boolean IWSRESTCliente.IniciarSesion(string correo, string contrasena)
        {
            Manejador_Usuario manUsuario = new Manejador_Usuario();
            return manUsuario.SeleccionarUsuario(correo, contrasena);
        }

        List<BL_Plato> IWSRESTCliente.VerPlatos(string nombre)
        {
            Manejador_Lista_Platos listaPlatos = new Manejador_Lista_Platos();
            listaPlatos.BuscarPlatos(nombre);
            return listaPlatos.Platos;
        }
    }
}
