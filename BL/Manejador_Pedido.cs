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

        public Boolean InsertarPedido(int numero, string correoCliente, DateTime fecha)
        {
            DAOPedido daoPedido = new DAOPedido();
            TO_Pedido toPedido = new TO_Pedido(numero, correoCliente, fecha, "");
            return daoPedido.Insertar(toPedido);
        }

        public Boolean SeleccionarPedido(int numero)//Para buscar, solo seria necesario el numero? 
        {
            DAOPedido daoPedido = new DAOPedido();
            TO_Pedido toPedido = new TO_Pedido();
            toPedido.Numero = numero;
            if (daoPedido.Mostrar(toPedido))
            {
                //Pedido.Numero = toPedido.Numero;
                Pedido.CorreoCliente = toPedido.CorreoCliente;
                Pedido.Fecha = toPedido.Fecha;
                Pedido.CodigoEstado = toPedido.CodigoEstado;
                return true;
            }
            return false;
        }

        /*public Boolean ActualizarPedido(int numero, string correoCliente, DateTime fecha, string estado)
        {
            DAOPedido daoPedido = new DAOPedido();
            TO_Pedido toUsuario = new TO_Pedido(numero, correoCliente, fecha, "");
            return daoPedido.Actualizar(toUsuario, estado);
        }*/

        public Boolean EliminarPedido(string correo)
        {
            //TODO
            return false;
        }

        //------------------------- Detalles -----------------------------------


        public Boolean AgregarDetallePedido(int numeroPedido, string nombrePlato)
        {
            TO_Detalle_Pedido toDetalle = new TO_Detalle_Pedido(numeroPedido, nombrePlato);
            DAOPedido daoPedido = new DAOPedido();
            return daoPedido.AgregarDetalle(toDetalle);
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

    }
}
