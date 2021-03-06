﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using BL;
using System.Text;

namespace UI.WS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWSRESTCliente" in both code and config file together.
    [ServiceContract]
    public interface IWSRESTCliente
    {
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        ObjetoLogico IniciarSesion(string correo, string contrasena);

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        BL_Usuario MostrarCliente(string correo);

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        ObjetoLogico ModificarCliente(string correo, string nombre, string contrasena, string direccion);

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        List<Boolean> Registrarse(string correo, string nombreCompleto, string direccion, string contrasena);

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        List<BL_Plato> VerPlatos(string nombre);

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        List<BL_Plato> MostrarPlatos(string nombre);

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        BL_Plato MostrarDetallePlato(string nombre);

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        int InsertarPedido(string correo);

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        ObjetoLogico InsertarDetalle(int numero, string nombre);
    }
}
