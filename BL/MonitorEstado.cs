using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DAO;

namespace BL
{
    public class MonitorEstado
    {
        private Timer tiempo;
        private int maximo;
        private int contador;
        private int numeroPedido;
        private string temporal;
        

        public MonitorEstado(int numero)
        {
            tiempo = new Timer(controlar, null, 1000, 1000);
            numeroPedido = numero;
            contador = 0;
            temporal = "A Tiempo";
            maximo = obtenerTiempo("A Tiempo");
        }

        private void controlar(object args)
        {
            if (contador == maximo)
            {
                DAOPedido dao = new DAOPedido();
                int estadoAtual = dao.ObtenerEstado(numeroPedido);
                if (estadoAtual == 1 || estadoAtual == 2)
                {
                    tiempo.Dispose();
                }
                else {
                    if (temporal.Equals("A Tiempo"))
                    {
                        maximo = obtenerTiempo("Sobre Tiempo");
                        temporal = "Sobre Tiempo";
                        dao.CambiarEstado(numeroPedido, 4);
                    }
                    else if (temporal.Equals("Sobre Tiempo"))
                    {
                        maximo = obtenerTiempo("Demorado");
                        temporal = "Demorado";
                        dao.CambiarEstado(numeroPedido, 5);
                        tiempo.Dispose();
                    }
                }
            }
                contador++;
        }

        private int obtenerTiempo(string estado)
        {
            DAOPedido daoPedido = new DAOPedido();
            return daoPedido.ObtenerTiempo(estado);
        }

        private int obtenerEstado(int n)
        {
            DAOPedido daoPedido = new DAOPedido();
            return daoPedido.ObtenerEstado(n);
        }


    }
}
