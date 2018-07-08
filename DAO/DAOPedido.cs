using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using TO;

namespace DAO
{
    public class DAOPedido
    {
        private BDConexion bdConexion = new BDConexion();

        public Boolean Insertar(TO_Pedido toPedido)
        {
            Boolean completado = true;
            toPedido.Fecha = DateTime.Now;//Muy forzado?

            TO_Estado_Pedido toEstadoPedido = new TO_Estado_Pedido();
            toEstadoPedido.Estado = "Habilitado";
            MostrarEstadoPedido(toEstadoPedido);

            toPedido.CodigoEstado = toEstadoPedido.Codigo;
            try
            {
                formatoIngreso("INSERT INTO Pedido VALUES (@numero, @correo, @fecha, @codestado)", toPedido);
            }
            catch (Exception ex)
            //Creo que es necesario tener varios catch para los mensajes. Debemos discutirlo.
            {
                completado = false;
                bdConexion.RealizarRollBack();
            }
            finally
            {
                bdConexion.Finalizar();
            }
            return completado;
        }

        public Boolean MostrarPedidos(TO_Manejador_Lista_Pedidos toPedidos, string correoCliente)
        {
            bdConexion.Conectar();
            bdConexion.Inicializar();
            try
            {
                string query = "SELECT * FROM Pedido WHERE Correo_Cliente LIKE @correo";
                bdConexion.AsignarParametro("@correo", '%' + correoCliente + '%');
                bdConexion.GenerarConsulta(query);

                SqlDataReader lector = bdConexion.Comando.ExecuteReader();
                llenarLista(lector, toPedidos);
                lector.Close();
                return true;
            }

            catch (Exception e)
            {
                throw e;
                bdConexion.RealizarRollBack();
                return false;
            }
        }

        private void llenarLista(SqlDataReader lector, TO_Manejador_Lista_Pedidos pedidos)
        {
            while (lector.Read())
            {
                pedidos.AgregarPedido(new TO_Pedido(int.Parse(lector["Numero"].ToString()),
                    lector["Correo_Cliente"].ToString(), (DateTime)lector["Fecha"],
                    lector["Codigo_Estado"].ToString()));
            }
        }

        public bool Mostrar(TO_Pedido toPedido)
        {
            Boolean encontrado = false;
            Boolean completado = true;
            try
            {
                bdConexion.Conectar();
                bdConexion.Inicializar();
                bdConexion.GenerarConsulta("SELECT * FROM Pedido WHERE Numero = @numero");
                bdConexion.AsignarParametro("@numero", toPedido.Numero);

                SqlDataReader lector = bdConexion.Comando.ExecuteReader();

                if (lector.HasRows)
                {
                    encontrado = true;

                    while (lector.Read())
                    {
                        toPedido.CorreoCliente = lector["Correo_Cliente"].ToString();
                        toPedido.Fecha = (DateTime)lector["Fecha"];
                        toPedido.CodigoEstado = lector["Codigo_Estado"].ToString();
                    }
                }

                lector.Close();
                bdConexion.RealizarCommit();
            }
            catch (Exception ex)
            {
                completado = false;
                bdConexion.RealizarRollBack();
            }
            finally
            {
                bdConexion.Finalizar();
            }
            if (encontrado && completado)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*public bool Actualizar(TO_Pedido toPedido, string estado)
        {
            Boolean completado = true;
            try
            {
                TO_Estado_Pedido toEstadoPedido = new TO_Estado_Pedido();
                toEstadoPedido.Estado = estado;
                MostrarEstadoPedido(toEstadoPedido);
                toPedido.CodigoEstado = toEstadoPedido.Codigo;
                formatoIngreso("UPDATE Pedido SET Precio = @prec, Foto = @foto, Estado = @estado Where Nombre = @nom", plato);
            }
            catch (Exception ex)
            {
                completado = false;
                bdConexion.RealizarRollBack();
            }
            finally
            {
                bdConexion.Finalizar();
            }
            return completado;
        }*/

        private void formatoIngreso(string consulta, TO_Pedido pedido)
        {
            try
            {
                bdConexion.Conectar();
                bdConexion.Inicializar();

                bdConexion.GenerarConsulta(consulta);
                bdConexion.AsignarParametro("@numero", pedido.Numero);
                bdConexion.AsignarParametro("@correo", pedido.CorreoCliente);
                bdConexion.AsignarParametro("@fecha", pedido.Fecha);
                bdConexion.AsignarParametro("@codestado", pedido.CodigoEstado);

                bdConexion.Comando.ExecuteNonQuery();
                bdConexion.RealizarCommit();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //--------------------------- Manejo de Detalle Pedido -----------------------------------------

        public Boolean AgregarDetalle(TO_Detalle_Pedido toDetalle)
        {
            Boolean completado = true;
            try
            {
                string consulta = "INSERT INTO Detalle Pedido VALUES (@num, @nom)";
                bdConexion.GenerarConsulta(consulta);

                bdConexion.AsignarParametro("@num", toDetalle.NumeroPedido);
                bdConexion.AsignarParametro("@nom", toDetalle.NombrePlato);

                bdConexion.Comando.ExecuteNonQuery();
                bdConexion.RealizarCommit();
            }
            catch (Exception ex)
            {
                completado = false;
                bdConexion.RealizarRollBack();
            }
            finally
            {
                bdConexion.Finalizar();
            }
            return completado;
        }

        //--------------------------- Manejo de Estado Pedido ------------------------------------------

        public Boolean ModificarEstadoPedido(TO_Estado_Pedido estadoPedido)
        {
            Boolean completado = true;
            try
            {
                string consulta = "UPDATE Estado_Pedido SET Tiempo = @tiempo WHERE Estado = @estado";
                bdConexion.GenerarConsulta(consulta);

                bdConexion.AsignarParametro("@tiempo", estadoPedido.Tiempo);
                bdConexion.AsignarParametro("@estado", estadoPedido.Estado);

                bdConexion.Comando.ExecuteNonQuery();
                bdConexion.RealizarCommit();
            }
            catch (Exception ex)
            {
                completado = false;
                bdConexion.RealizarRollBack();
            }
            finally
            {
                bdConexion.Finalizar();
            }
            return completado;
        }

        public Boolean MostrarEstadoPedido(TO_Estado_Pedido toEstadoPedido)
        {
            try
            {
                bdConexion.Conectar();
                bdConexion.Inicializar();
                bdConexion.GenerarConsulta("SELECT * FROM Estado_Pedido WHERE Estado = @estado OR Codigo = @codestado");
                bdConexion.AsignarParametro("@codestado", toEstadoPedido.Codigo);
                bdConexion.AsignarParametro("@estado", toEstadoPedido.Estado);

                SqlDataReader lector = bdConexion.Comando.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        toEstadoPedido.Codigo = lector["Codigo"].ToString();
                        toEstadoPedido.Tiempo = int.Parse(lector["Tiempo_Estado"].ToString());
                    }
                }

                lector.Close();
                bdConexion.RealizarCommit();
            }
            catch (Exception ex)
            {
                bdConexion.RealizarRollBack();
            }
            finally
            {
                bdConexion.Finalizar();
            }
            return true;
        }

    }
}
