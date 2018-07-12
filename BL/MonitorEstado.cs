using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BL
{
    public class MonitorEstado
    {
        private Timer tiempo;
        private int maximo;
        private int contador;

        public MonitorEstado(int max)
        {
            tiempo = new Timer(controlar, null, 0, 1000);
            maximo = max;
            contador = 0;
        }

        private void controlar(object args)
        {
            if (contador == maximo)
            {
                tiempo.Dispose();
                Console.WriteLine("Aqui termina");
            }
            else
            {
                contador++;
                Console.WriteLine("Va por el: " + contador);
            }
        }
    }
}
