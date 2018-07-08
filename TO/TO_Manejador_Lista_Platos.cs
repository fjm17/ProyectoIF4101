using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TO
{
    public class TO_Manejador_Lista_Platos
    {
        public List<TO_Plato> Platos { get; set; }

        public TO_Manejador_Lista_Platos()
        {
            Platos = new List<TO_Plato>();
        }

        public void AgregarPlato(TO_Plato entrada)
        {
            Platos.Add(entrada);
        }
    }
}
