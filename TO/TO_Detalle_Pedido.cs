using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TO
{
    public class TO_Detalle_Pedido
    {
        public int NumeroPedido { get; set; }
        public string NombrePlato { get; set; }

        public TO_Detalle_Pedido(int numeroPedido, string nombrePlato)
        {
            this.NumeroPedido = numeroPedido;
            this.NombrePlato = nombrePlato;
        }

        public TO_Detalle_Pedido()
        {

        }
    }
}
