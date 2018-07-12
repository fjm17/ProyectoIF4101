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
        private int estadoAtual;
        private DAOPedido dao;

        public MonitorEstado(int numero)
        {
            dao = new DAOPedido();
            tiempo = new Timer(controlar, null, 1000, 1000);
            numeroPedido = numero;
            estadoAtual = dao.ObtenerEstado(numeroPedido);

            switch (estadoAtual)
            {
                case 1:
                    tiempo.Dispose();
                    break;
                case 2:
                    tiempo.Dispose();
                    break;
                case 3:
                    maximo = obtenerTiempo("A Tiempo");
                    temporal = "A Tiempo";
                    contador = 0;
                    break;
                case 4:
                    maximo = obtenerTiempo("Sobre Tiempo");
                    temporal = "Sobre Tiempo";
                    contador = dao.ObtenerTiempo("A Tiempo");
                    break;
                case 5:
                    maximo = obtenerTiempo("Demorado");
                    temporal = "Demorado";
                    contador = dao.ObtenerTiempo("Sobre Tiempo");
                    break;
            }

        }

        private void controlar(object args)
        {
            if (contador == maximo)
            {
                estadoAtual = dao.ObtenerEstado(numeroPedido);
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


    }
}
