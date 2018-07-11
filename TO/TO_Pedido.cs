using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TO
{
    public class TO_Pedido
    {
        public int Numero { get; set; }
        public string CorreoCliente { get; set; }
        public DateTime Fecha { get; set; }
        public string CodigoEstado { get; set; }
        public List<TO_Detalle_Pedido> Detalles { get; set; }

        public TO_Pedido()
        {
            Detalles = new List<TO_Detalle_Pedido>();
        }

        public TO_Pedido(int numero, string correoCliente, DateTime fecha, string codigoEstado)
        {
            this.Numero = numero;
            this.CorreoCliente = correoCliente;
            this.Fecha = fecha;
            this.CodigoEstado = codigoEstado;

            Detalles = new List<TO_Detalle_Pedido>();
        }

        public void AgregarDetalle(int numeroPedido, string nombrePlato)
        {
            TO_Detalle_Pedido detalle = new TO_Detalle_Pedido(numeroPedido, nombrePlato);
            Detalles.Add(detalle);        
        }
    }
}
