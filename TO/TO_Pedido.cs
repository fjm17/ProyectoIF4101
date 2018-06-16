using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TO
{
    public class TO_Pedido
    {
        public string cliente { get; set; }
        public string plato { get; set; }
        public DateTime fecha { get; set; }
        public string estado { get; set; }

        public TO_Pedido()
        {

        }

        public TO_Pedido(string cliente, string plato, DateTime fecha, string estado)
        {
            this.cliente = cliente;
            this.plato = plato;
            this.fecha = fecha;
            this.estado = estado;
        }
    }
}
