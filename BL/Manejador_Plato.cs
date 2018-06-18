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

        public Boolean SeleccionarPlato(string nombre)
        {

            DAOPlato daoPlato = new DAOPlato();
            TO_Plato to_plato = new TO_Plato();
            to_plato.Nombre = nombre;
            if(daoPlato.Mostrar(to_plato))
            {
                Plato.Nombre = to_plato.Nombre;
                Plato.Descripcion = to_plato.Descripcion;
                Plato.Precio = to_plato.Precio;
                Plato.Foto = to_plato.Foto;
                Plato.Estado = to_plato.Estado;
                return true;
            }
            return false;
        }

        public Boolean EliminarPlato(string nombre)
        {
            TO_Plato to_plato = new TO_Plato();
            DAOPlato daoPlato = new DAOPlato();
            to_plato.Nombre = nombre;
            return daoPlato.Eliminar(to_plato);
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
