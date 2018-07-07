using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BL_Detalle_Pedido
    {
        public int NumeroPedido { get; set; }
        public string NombrePlato { get; set; }

        public BL_Detalle_Pedido(int numeroPedido, string nombrePlato)
        {
            this.NumeroPedido = numeroPedido;
            this.NombrePlato = nombrePlato;
        }

        public BL_Detalle_Pedido()
        {

        }
    }
}
