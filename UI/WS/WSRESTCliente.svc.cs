﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BL;

namespace UI.WS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WSRESTCliente" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select WSRESTCliente.svc or WSRESTCliente.svc.cs at the Solution Explorer and start debugging.
    public class WSRESTCliente : IWSRESTCliente
    {
        public void DoWork()
        {
        }

        public ObjetoLogico IniciarSesion(string correo, string contrasena)
        {
            Manejador_Usuario manUsuario = new Manejador_Usuario();
            ObjetoLogico resultado = new ObjetoLogico();
            resultado.Valor = manUsuario.SeleccionarUsuario(correo, contrasena);
            return resultado;
        }

        public ObjetoLogico ModificarCliente(string correo, string nombre, string contrasena, string direccion)
        {
            Manejador_Usuario manUsuario = new Manejador_Usuario();
            ObjetoLogico resultado = new ObjetoLogico();
            resultado.Valor = manUsuario.ActualizarUsuario(correo, nombre, direccion, correo, "Cliente", "Habilitado");
            return resultado;
        }

        public BL_Usuario MostrarCliente(string correo)
        {
            Manejador_Usuario manUsuario = new Manejador_Usuario();
            manUsuario.SeleccionarUsuario(correo, "");
            return manUsuario.Usuario;
        }


        public List<bool> Registrarse(string correo, string nombreCompleto, string direccion, string contrasena)
        {
            Manejador_Usuario manejador = new Manejador_Usuario();
            return new List<bool> { manejador.InsertarUsuario(correo, nombreCompleto, direccion, contrasena, "Cliente") };
        }

        public List<BL_Plato> VerPlatos(string nombre)
        {
            Manejador_Lista_Platos listaPlatos = new Manejador_Lista_Platos();
            listaPlatos.BuscarPlatos(nombre);
            return listaPlatos.Platos;
        }

        public List<BL_Plato> MostrarPlatos(string nombre)
        {
            Manejador_Lista_Platos listaPlatos = new Manejador_Lista_Platos();
            listaPlatos.BuscarPlatos(nombre);
            return listaPlatos.Platos;
        }

        public BL_Plato MostrarDetallePlato(string nombre)
        {
            Manejador_Plato manPlato = new Manejador_Plato();
            manPlato.SeleccionarPlato(nombre);
            return manPlato.Plato;
        }


        public int InsertarPedido(string correo)
        {
            Manejador_Pedido m = new Manejador_Pedido();
            return m.InsertarPedido(correo);
        }

        public ObjetoLogico InsertarDetalle(int numero, string nombre)
        {
            numero++;
            Manejador_Pedido m = new Manejador_Pedido();
            ObjetoLogico o = new ObjetoLogico();
            o.Valor = m.InsertarDetallePedido(numero, nombre);
            return o;
        }
    }
}
