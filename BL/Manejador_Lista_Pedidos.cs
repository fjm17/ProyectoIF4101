﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;
using DAO;

namespace BL
{
    public class Manejador_Lista_Pedidos
    {
        public List<BL_Pedido> Pedidos { get; set; }

        public Manejador_Lista_Pedidos()
        {
            Pedidos = new List<BL_Pedido>();
        }

        public void AgregarPedido(BL_Pedido entrada)
        {
            Pedidos.Add(entrada);
        }

        public void BuscarPedidos(TO_Manejador_Lista_Pedidos toPedidos, string correo)
        {
            DAOPedido daoPedido = new DAOPedido();
            daoPedido.MostrarPedidos(toPedidos, correo);
            ConvertirLista(toPedidos);
        }

        public void MostrarTodosPedidos()
        {
            TO_Manejador_Lista_Pedidos toPedidos = new TO_Manejador_Lista_Pedidos();


            DAOPedido daoPedido = new DAOPedido();
            daoPedido.MostrarTodosPedidos(toPedidos);
            ConvertirLista(toPedidos);
        }

        public void ConvertirLista(TO_Manejador_Lista_Pedidos toPedidos)
        {
            foreach (TO_Pedido toPedido in toPedidos.Pedidos)
            {
                //foreach
                AgregarPedido(new BL_Pedido(toPedido.Numero, toPedido.CorreoCliente,
                    toPedido.Fecha, toPedido.CodigoEstado));
            }
        }
    }
}
