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

        public void BuscarPlatos(string nombre)
        {
            TO_Manejador_Lista_Platos toPlatos = new TO_Manejador_Lista_Platos();
            DAOPlato daoPedido = new DAOPlato();
            daoPedido.MostrarPlatos(toPlatos, nombre);
            ConvertirLista(toPlatos);
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
