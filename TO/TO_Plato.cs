using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TO
{
    public class TO_Plato
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public string Foto { get; set; }
        public string Estado { get; set; }

        public TO_Plato()
        {

        }

        public TO_Plato(string nombre, string descripcion, double precio, string foto, string estado)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Precio = precio;
            this.Foto = foto;
            this.Estado = estado;
        }
    }
}
