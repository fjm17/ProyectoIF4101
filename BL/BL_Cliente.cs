using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public class BL_Cliente
    {
        public string correo { get; set; }
        public string nombre_completo { get; set; }
        public string direccion { get; set; }
        public string contrasena { get; set; }
        public string tipo { get; set; }

        public BL_Cliente()
        {

        }

        public BL_Cliente (string correo, string nombre_completo, string direccion, string contrasenna, string tipo)
        {
            this.correo = correo;
            this.nombre_completo = nombre_completo;
            this.direccion = direccion;
            this.contrasena = contrasena;
            this.tipo = tipo;
        }
    }
}
