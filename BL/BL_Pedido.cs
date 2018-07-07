using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public class BL_Pedido
    {
        public int Numero { get; set; }
        public string CorreoCliente { get; set; }
        public DateTime Fecha { get; set; }
        public string CodigoEstado { get; set; }

        public BL_Pedido()
        {

        }

        public BL_Pedido(int numero, string correoCliente, DateTime fecha, string codigoEstado)
        {
            this.Numero = numero;
            this.CorreoCliente = correoCliente;
            this.Fecha = fecha;
            this.CodigoEstado = codigoEstado;
        }

    }
}