using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estatico
    {
        public BL_Pedido pedido { set; get; }
        private static Estatico estatico = null;
        public bool usado { set; get; } = true;


        
        private Estatico ()
            
        {

        }
        public static Estatico getInstance()
        {
            if (estatico == null)
            {
                estatico = new Estatico();
                
            }
            return estatico;
        }

    }
}
