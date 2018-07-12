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
        public List<BL_Detalle_Pedido> Detalles { get; set; }

        public BL_Pedido()
        {
            Detalles = new List<BL_Detalle_Pedido>();
        }

        public BL_Pedido(int numero, string correoCliente, DateTime fecha, string codigoEstado)
        {
            this.Numero = numero;
            this.CorreoCliente = correoCliente;
            this.Fecha = fecha;
            this.CodigoEstado = codigoEstado;
            Detalles = new List<BL_Detalle_Pedido>();
        }

        public void AgregarDetalle(int numeroPedido, string nombrePlato)
        {
            BL_Detalle_Pedido detalle = new BL_Detalle_Pedido(numeroPedido, nombrePlato);
            Detalles.Add(detalle);     
        }

    }
}