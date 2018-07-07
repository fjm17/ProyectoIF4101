using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public class BL_Usuario
    {
        public string Correo { get; set; }
        public string Nombre_Completo { get; set; }
        public string Direccion { get; set; }
        public string Contrasena { get; set; }
        public string Tipo { get; set; }
        public string EstadoCuenta  { get; set; }

        public BL_Usuario()
        {

        }

        public BL_Usuario(string correo, string nombre_completo, string direccion, string contrasena, string tipo, string estadoCuenta)
        {
            this.Correo = correo;
            this.Nombre_Completo = nombre_completo;
            this.Direccion = direccion;
            this.Contrasena = contrasena;
            this.Tipo = tipo;
            this.EstadoCuenta = estadoCuenta;
        }

        public BL_Usuario(string correo, string nombre_completo, string direccion, string tipo, string estadoCuenta)
        {
            this.Correo = correo;
            this.Nombre_Completo = nombre_completo;
            this.Direccion = direccion;
            this.Tipo = tipo;
            this.EstadoCuenta = estadoCuenta;
        }

    }
}
