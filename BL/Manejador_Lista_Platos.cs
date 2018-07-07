using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TO;
using DAO;

namespace BL
{
    public class Manejador_Lista_Platos
    {
        public List<BL_Plato> Platos { get; }

        public Manejador_Lista_Platos()
        {
            Platos = new List<BL_Plato>();
        }

        public void AgregarPlato(BL_Plato entrada)
        {
            Platos.Add(entrada);
        }

        public void BuscarPlatos(TO_Manejador_Lista_Platos toPedidos, string correo)
        {
            DAOPlato daoPedido = new DAOPlato();
            daoPedido.MostrarPlatos(toPedidos, correo);
            ConvertirLista(toPedidos);
        }

        public void ConvertirLista(TO_Manejador_Lista_Platos toPedidos)
        {
            foreach (TO_Plato toPlato in toPedidos.Platos)
            {
                AgregarPlato(new BL_Plato(toPlato.Nombre, toPlato.Descripcion, toPlato.Precio, 
                    toPlato.Foto, toPlato.Estado));
            }
        }

    }
}
