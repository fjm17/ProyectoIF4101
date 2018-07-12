using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TO;
using DAO;

namespace BL
{
    public class Manejador_Pedido
    {
        public BL_Pedido Pedido { get; set; }

        public Manejador_Pedido()
        {
            Pedido = new BL_Pedido();
        }

        public int InsertarPedido(string correoCliente)
        {
            int n = 0;
            DAOPedido daoPedido = new DAOPedido();
            DateTime fecha = DateTime.Now;
            TO_Pedido toPedido = new TO_Pedido(0, correoCliente, fecha, "");
            Boolean resultado = daoPedido.Insertar(toPedido);
            if (resultado)
            {
                n = daoPedido.ObtenerNumeroPedido(fecha);
                MonitorEstado monitor = new MonitorEstado(n);
            }
            return n;
        }

        public Boolean SeleccionarPedido(int numero)
        {
            DAOPedido daoPedido = new DAOPedido();
            TO_Pedido toPedido = new TO_Pedido();
            toPedido.Numero = numero;
            if (daoPedido.Mostrar(toPedido))
            {
                Pedido.CorreoCliente = toPedido.CorreoCliente;
                Pedido.Fecha = toPedido.Fecha;
                Pedido.CodigoEstado = toPedido.CodigoEstado;
                return true;
            }
            return false;
        }

        public Boolean ActualizarPedido(int numero, string estado)
        {
            DAOPedido daoPedido = new DAOPedido();
            return daoPedido.CambiarEstado(numero, int.Parse(estado));
        }

        public Boolean ModificarTiempoEstado(string codigo, int tiempo)
        {
            DAOPedido daoPedido = new DAOPedido();
            return daoPedido.ModificarTiempoEstado(codigo, tiempo);
        }


        //------------------------- Estado -------------------------------------
        public Boolean MostrarEstadoPedido(string estado)
        {
            DAOPedido daoPedido = new DAOPedido();
            TO_Estado_Pedido toEstado = new TO_Estado_Pedido();
            toEstado.Estado = estado;
            return daoPedido.MostrarEstadoPedido(toEstado);
        }

        public Boolean ModificarEstadoPedido(int tiempo, string estado)
        {
            DAOPedido daoPedido = new DAOPedido();
            TO_Estado_Pedido toEstado = new TO_Estado_Pedido();
            toEstado.Tiempo = tiempo;
            toEstado.Estado = estado;
            return daoPedido.ModificarEstadoPedido(toEstado);
        }


        public bool modificarEstado(int numeroPedido, int estado)
        {
            DAOPedido datos = new DAOPedido();
            return datos.CambiarEstado(numeroPedido, estado);
        }
        

        public Boolean InsertarDetallePedido(int numero, string nombre)
        {
            DAOPedido dao = new DAOPedido();
            TO_Detalle_Pedido to = new TO_Detalle_Pedido(numero, nombre);
            return dao.InsertarDetalle(to);
        }

    }
}
