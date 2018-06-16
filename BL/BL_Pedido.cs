using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public class BL_Pedido
    {
        public string Cliente { get; set; }
        public string Plato { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }

        public BL_Pedido()
        {

        }

        public BL_Pedido(string cliente, string plato, DateTime fecha, string estado)
        {
            this.Cliente = cliente;
            this.Plato = plato;
            this.Fecha = fecha;
            this.Estado = estado;
        }

    }
}
}
