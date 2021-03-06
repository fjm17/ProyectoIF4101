﻿using System;
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

        public int ObtenerEstado(int numeroPedido)
        {
            
            try
            {
                bdConexion.Conectar();
                bdConexion.Inicializar();
                bdConexion.GenerarConsulta("SELECT Codigo_Estado FROM Pedido WHERE Numero = @num");
                bdConexion.AsignarParametro("@num", numeroPedido);

                int lector = (int)bdConexion.Comando.ExecuteScalar();
                bdConexion.RealizarCommit();
                return lector;
            }
            catch (Exception ex)
            {
                bdConexion.RealizarRollBack();
            }
            finally
            {
                bdConexion.Finalizar();
            }
            return 0;
        }

        public Boolean Insertar(TO_Pedido toPedido)
        {
            Boolean completado = true;
            
            try
            {
                formatoIngreso("INSERT INTO Pedido (Correo_Cliente, Fecha, Codigo_Estado) VALUES (@correo, @fecha, 3)", toPedido);
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

        public Boolean InsertarDetalle(TO_Detalle_Pedido to)
        {
            Boolean completado = true;
            try
            {
                bdConexion.Conectar();
                bdConexion.Inicializar();
                bdConexion.GenerarConsulta("Insert into Detalle_Pedido values (@num, @nom)");
                bdConexion.AsignarParametro("@num", to.NumeroPedido);
                bdConexion.AsignarParametro("@nom", to.NombrePlato);

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

        public int ObtenerNumeroPedido(DateTime fecha)
        {
            try
            {
                bdConexion.Conectar();
                bdConexion.Inicializar();
                bdConexion.GenerarConsulta("SELECT Numero FROM Pedido WHERE Fecha = @fecha");
                bdConexion.AsignarParametro("@fecha", fecha);

                int lector = (int)bdConexion.Comando.ExecuteScalar();
                bdConexion.RealizarCommit();
                return lector;
            }
            catch (Exception ex)
            {
                bdConexion.RealizarRollBack();
            }
            finally
            {
                bdConexion.Finalizar();
            }
            return 0;
        }

        public int ObtenerTiempo(string estado)
        {
            try
            {
                bdConexion.Conectar();
                bdConexion.Inicializar();
                bdConexion.GenerarConsulta("SELECT Tiempo_Estado FROM Estado_Pedido WHERE Estado = @codestado");
                bdConexion.AsignarParametro("@codestado", estado);

                int lector = (int)bdConexion.Comando.ExecuteScalar();
                bdConexion.RealizarCommit();
                return lector;
            }
            catch (Exception ex)
            {
                bdConexion.RealizarRollBack();
            }
            finally
            {
                bdConexion.Finalizar();
            }
            return 0;
        }

        public Boolean ModificarTiempoEstado(string codigo, int tiempo)
        {
            try
            {
                bdConexion.Conectar();
                bdConexion.Inicializar();
                bdConexion.GenerarConsulta("Update Estado_Pedido Set Tiempo_Estado = @tiempo Where Codigo = @cod");
                bdConexion.AsignarParametro("@tiempo", tiempo);
                bdConexion.AsignarParametro("@cod", codigo);

                bdConexion.Comando.ExecuteNonQuery();
                bdConexion.RealizarCommit();
            }
            catch (Exception ex)
            {
                bdConexion.RealizarRollBack();
                return false;
            }
            finally
            {
                bdConexion.Finalizar();
            }
            return true;
        }

        public Boolean CambiarEstado(int numeroPedido, int codigoEstado)
        {
            Boolean completado = true;
            try
            {
                bdConexion.Conectar();
                bdConexion.Inicializar();
                bdConexion.GenerarConsulta("UPDATE Pedido SET Codigo_Estado = @cod  Where Numero = @num");
                bdConexion.AsignarParametro("@cod", codigoEstado + "");
                bdConexion.AsignarParametro("@num", numeroPedido);
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
                bdConexion.RealizarRollBack();
                return false;
            }
        }

        public Boolean MostrarPedidosEstado(TO_Manejador_Lista_Pedidos toPedidos, string estado)
        {
            bdConexion.Conectar();
            bdConexion.Inicializar();
            try
            {
                string query = "SELECT * FROM Pedido WHERE Codigo_Estado = @codEstado";
                bdConexion.AsignarParametro("@codEstado", estado);
                bdConexion.GenerarConsulta(query);

                SqlDataReader lector = bdConexion.Comando.ExecuteReader();
                llenarLista(lector, toPedidos);
                lector.Close();
                return true;
            }

            catch (Exception e)
            {
                bdConexion.RealizarRollBack();
                return false;
            }
        }

        public Boolean MostrarPedidosFecha(TO_Manejador_Lista_Pedidos toPedidos, DateTime fecha1, DateTime fecha2)
        {
            bdConexion.Conectar();
            bdConexion.Inicializar();
            try
            {
                string query = "SELECT * FROM Pedido WHERE Fecha BETWEEN @fecha1 AND @fecha2";
                bdConexion.AsignarParametro("@fecha1", fecha1);
                bdConexion.AsignarParametro("@fecha2", fecha2);
                bdConexion.GenerarConsulta(query);

                SqlDataReader lector = bdConexion.Comando.ExecuteReader();
                llenarLista(lector, toPedidos);
                lector.Close();
                return true;
            }

            catch (Exception e)
            {
                bdConexion.RealizarRollBack();
                return false;
            }
        }

        public Boolean MostrarTodosPedidos(TO_Manejador_Lista_Pedidos toPedidos)
        {
            bdConexion.Conectar();
            bdConexion.Inicializar();
            try
            {
                string query = "SELECT * FROM Pedido";
                bdConexion.GenerarConsulta(query);

                SqlDataReader lector = bdConexion.Comando.ExecuteReader();
                llenarLista(lector, toPedidos);
                lector.Close();
                return true;
            }

            catch (Exception e)
            {
                bdConexion.RealizarRollBack();
                return false;
            }
        }

        private void llenarLista(SqlDataReader lector, TO_Manejador_Lista_Pedidos pedidos)
        {
            while (lector.Read())
            {
                TO_Pedido nuevoPedido = new TO_Pedido(int.Parse(lector["Numero"].ToString()),
                    lector["Correo_Cliente"].ToString(), (DateTime)lector["Fecha"],
                    lector["Codigo_Estado"].ToString());
                BuscarDetallesPedido(nuevoPedido);
                pedidos.AgregarPedido(nuevoPedido);

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

        private void formatoIngreso(string consulta, TO_Pedido pedido)
        {
            try
            {
                bdConexion.Conectar();
                bdConexion.Inicializar();

                bdConexion.GenerarConsulta(consulta);
                bdConexion.AsignarParametro("@correo", pedido.CorreoCliente);
                bdConexion.AsignarParametro("@fecha", pedido.Fecha);

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
                string consulta = "INSERT INTO Detalle_Pedido VALUES (@num, @nom)";
                bdConexion.Conectar();
                bdConexion.Inicializar();
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


        public Boolean BuscarDetallesPedido(TO_Pedido toPedido)
        {
            Boolean completado = true;
            try
            {
                string consulta = "SELECT * FROM Detalle_Pedido WHERE Numero_Pedido = @num";
                bdConexion.Conectar();
                bdConexion.Inicializar();
                bdConexion.GenerarConsulta(consulta);

                bdConexion.AsignarParametro("@num", toPedido.Numero);

                SqlDataReader lector = bdConexion.Comando.ExecuteReader();

                if (lector.HasRows)
                {
                    completado = true;

                    while (lector.Read())
                    {
                        toPedido.AgregarDetalle(int.Parse(lector["Numero_Pedido"].ToString()), lector["Nombre_Plato"].ToString());
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
