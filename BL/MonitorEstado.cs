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
            maximo = obtenerTiempo("A Tiempo");
            temporal = "A Tiempo";
            contador = 0;
            numeroPedido = numero;
        }

        private void controlar(object args)
        {
            if (contador == maximo)
            {
                DAOPedido dao = new DAOPedido();

                if (temporal.Equals("A Tiempo"))
                {
                    maximo = obtenerTiempo("Sobre Tiempo");
                    temporal = "Sobre Tiempo";
                    dao.CambiarEstado(numeroPedido, 4);
                }

                if (temporal.Equals("Sobre Tiempo"))
                {
                    maximo = obtenerTiempo("Demorado");
                    temporal = "Demorado";
                    dao.CambiarEstado(numeroPedido, 5);
                    tiempo.Dispose();
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
