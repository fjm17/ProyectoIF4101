using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TO
{
    public class TO_Manejador_Lista_Pedidos
    {

        public List<TO_Pedido> Pedidos { get; set; }

        public TO_Manejador_Lista_Pedidos()
        {
            Pedidos = new List<TO_Pedido>();
        }

        public void AgregarPedido(TO_Pedido entrada)
        {
            Pedidos.Add(entrada);
        }

    }
}
