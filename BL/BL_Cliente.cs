﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public class BL_Cliente
    {
        public string Correo { get; set; }
        public string Nombre_Completo { get; set; }
        public string Direccion { get; set; }
        public string Contrasena { get; set; }
        public string Tipo { get; set; }

        public BL_Cliente()
        {

        }

        public BL_Cliente (string correo, string nombre_completo, string direccion, string contrasenna, string tipo)
        {
            this.Correo = correo;
            this.Nombre_Completo = nombre_completo;
            this.Direccion = direccion;
            this.Contrasena = Contrasena;
            this.Tipo = tipo;
        }
    }
}
