using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public class BL_Plato
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public string Foto { get; set; }
        public string Estado { get; set; }

        public BL_Plato()
        {

        }

        public BL_Plato(string nombre, string descripcion, double precio, string foto, string estado)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Precio = precio;
            this.Foto = foto;
            this.Estado = estado;
        }


        public void prueba(string name)
        {
            throw new Exception("Hello world");
        }
    }
}
