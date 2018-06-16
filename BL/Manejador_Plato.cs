using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TO;
using DAO;

namespace BL
{
    public class Manejador_Plato
    {

        public BL_Plato Plato {get; }
        public List<BL_Plato> Lista { get; }
        
        public Manejador_Plato()
        {
            Plato = new BL_Plato();
            Lista = new List<BL_Plato>();
        } 

        public void seleccionarPlato(string nombre)
        {
            Plato.Nombre = nombre;

            TO_Plato to_plato = new TO_Plato();
            to_plato.Nombre = Plato.Nombre;

            //Se llama al metodo seleccionar un unico plato en DAO y le mando el TO como parametro

            Plato.Descripcion = to_plato.Descripcion;
            Plato.Precio = to_plato.Precio;
            Plato.Foto = to_plato.Foto;
            Plato.Estado = to_plato.Estado;

        }

        public void eliminarPlato(string nombre)
        {
            TO_Plato to_plato = new TO_Plato();
            to_plato.Nombre = Plato.Nombre;

            //Se llama al metodo de eliminar en DAO y le mando el TO como parametro
        }

        public void actualizarPlato(string nombre, string descripcion, double precio, string foto, string estado)
        {
            TO_Plato to_plato = new TO_Plato();
            to_plato.Nombre = nombre;
            to_plato.Descripcion = descripcion;
            to_plato.Precio = precio;
            to_plato.Foto = foto;
            to_plato.Estado = estado;

            //Se llama al metodo de actualizar en DAO y le mando el TO como parametro
        }

        public void insertarPlato(string nombre, string descripcion, double precio, string foto, string estado)
        {
            TO_Plato to_plato = new TO_Plato();
            to_plato.Nombre = nombre;
            to_plato.Descripcion = descripcion;
            to_plato.Precio = precio;
            to_plato.Foto = foto;
            to_plato.Estado = estado;

            //Se llama al metodo de insertar en DAO y le mando el TO como parametro
        }

        public void listaPlatos()
        {
            List<TO_Plato> lista_TO = new List<TO_Plato>();

            //Se llama al metodo de mostrar todos los platos en DAO y le madno el TO como parametro

            foreach(TO_Plato platoTO in lista_TO)
            {
                Lista.Add(new BL_Plato(platoTO.Nombre, platoTO.Descripcion, platoTO.Precio, platoTO.Foto, platoTO.Estado));
            }

        }
    }
}
