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
        public List<BL_Plato> Lista { get; }

        public Manejador_Lista_Platos()
        {
            Lista = new List<BL_Plato>();
        }

        public void listaPlatos()
        {
            List<TO_Plato> lista_TO = new List<TO_Plato>();

            //Se llama al metodo de mostrar todos los platos en DAO y le madno el TO como parametro

            foreach (TO_Plato platoTO in lista_TO)
            {
                Lista.Add(new BL_Plato(platoTO.Nombre, platoTO.Descripcion, platoTO.Precio, platoTO.Foto, platoTO.Estado));
            }

        }
    }
}
