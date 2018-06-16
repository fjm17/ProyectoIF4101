using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TO;
using DAO;


namespace BL
{
    public class Manejador_Usuario
    {
        public BL_Usuario cliente { get; }
        public List<BL_Usuario> lista { get; }

        public Manejador_Usuario()
        {
            cliente = new BL_Usuario();
            lista = new List<BL_Usuario>();
        }

        public void seleccionarCliente(string correo)
        {
            cliente.Correo = correo;

            TO_Usuario to_cliente = new TO_Usuario();
            to_cliente.Correo = cliente.Correo;

            // Aqui se llama al metodo en DAO para selEccionar un cliente 

            cliente.Nombre_Completo = to_cliente.Nombre_Completo;
            cliente.Direccion = to_cliente.Direccion;
            cliente.Contrasena = to_cliente.Contrasena;
            cliente.Tipo = to_cliente.Tipo;
        }
    }
}
