﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BL_Estado_Pedido
    {
        public string Codigo { get; set; }
        public string Estado { get; set; }
        public int Tiempo { get; set; }

        public BL_Estado_Pedido(string codigo, string estado, int tiempo)
        {
            this.Codigo = codigo;
            this.Estado = estado;
            this.Tiempo = tiempo;
        }

        public BL_Estado_Pedido()
        {

        }

    }
}
