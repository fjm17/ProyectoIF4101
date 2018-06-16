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
        
        public Manejador_Plato()
        {
            Plato = new BL_Plato();
        } 

        public void SeleccionarPlato(string nombre)
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

        public void EliminarPlato(string nombre)
        {
            TO_Plato to_plato = new TO_Plato();
            to_plato.Nombre = Plato.Nombre;

            //Se llama al metodo de eliminar en DAO y le mando el TO como parametro
        }

        public void ActualizarPlato(string nombre, string descripcion, double precio, string foto, string estado)
        {
            TO_Plato to_plato = new TO_Plato();
            to_plato.Nombre = nombre;
            to_plato.Descripcion = descripcion;
            to_plato.Precio = precio;
            to_plato.Foto = foto;
            to_plato.Estado = estado;

            //Se llama al metodo de actualizar en DAO y le mando el TO como parametro
        }

        public Boolean InsertarPlato(string nombre, string descripcion, double precio, string foto, string estado)
        {
            DAOPlato daoPlato = new DAOPlato();
            TO_Plato to_plato = new TO_Plato();
            to_plato.Nombre = nombre;
            to_plato.Descripcion = descripcion;
            to_plato.Precio = precio;
            to_plato.Foto = foto;
            to_plato.Estado = estado;
            return daoPlato.Agregar(to_plato);
        }
    }
}
