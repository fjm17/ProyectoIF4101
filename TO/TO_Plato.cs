using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TO
{
    public class TO_Plato
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public double precio { get; set; }
        public string foto { get; set; }
        public string estado { get; set; }

        public TO_Plato()
        {

        }

        public TO_Plato(string nombre, string descripcion, double precio, string foto, string estado)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
            this.foto = foto;
            this.estado = estado;
        }
    }
}
