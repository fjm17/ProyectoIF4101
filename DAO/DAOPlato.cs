using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TO;

namespace DAO
{
    public class DAOPlato
    {
        private BDConexion bdConexion = new BDConexion();

        public Boolean Agregar(TO_Plato plato)
        {
            Boolean completado = true;
            try
            {
                formatoIngreso("Insert Into Plato Values (@nom, @desc, @prec, @foto, @estado)", plato);
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

        public Boolean Actualizar(TO_Plato plato)
        {
            Boolean completado = true;
            try
            {
                formatoIngreso("Update Plato Set Descripcion = @desc, Precio = @prec, Foto = @foto, Estado = @estado Where Nombre = @nom", plato);
            }
            catch(Exception ex)
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

        private void formatoIngreso(string consulta, TO_Plato plato) // Se utiliza para no repetir el mismo codigo en actualizar y en agregar
        {
            try
            {
                bdConexion.Conectar();
                bdConexion.Inicializar();

                bdConexion.GenerarConsulta(consulta);
                bdConexion.AsignarParametro("@nom", plato.Nombre);
                bdConexion.AsignarParametro("@desc", plato.Descripcion);
                bdConexion.AsignarParametro("@prec", plato.Precio);
                bdConexion.AsignarParametro("@foto", plato.Foto);
                bdConexion.AsignarParametro("@estado", plato.Estado);

                bdConexion.Comando.ExecuteNonQuery();
                bdConexion.RealizarCommit();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Boolean Eliminar(TO_Plato plato)
        {
            Boolean completado = true;

            if (!Mostrar(plato))
            {
                completado = false;
            }
            else
            { 

            try
            {
                bdConexion.Conectar();
                bdConexion.Inicializar();
                bdConexion.GenerarConsulta("Delete From Plato Where Nombre = @nom");
                bdConexion.AsignarParametro("@nom", plato.Nombre);
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
            }
            return completado;
        }

        public Boolean Mostrar(TO_Plato plato)
        {
            Boolean encontrado = false;
            Boolean completado = true;
            try
            {
                bdConexion.Conectar();
                bdConexion.Inicializar();
                bdConexion.GenerarConsulta("Select * From Plato Where Nombre = @nom");
                bdConexion.AsignarParametro("@nom", plato.Nombre);

                SqlDataReader lector =  bdConexion.Comando.ExecuteReader();

                if(lector.HasRows)
                {
                    encontrado = true;

                    while (lector.Read())
                    {
                        plato.Descripcion = lector["Descripcion"].ToString();
                        plato.Precio = double.Parse(lector["Precio"].ToString());
                        plato.Foto = lector["Foto"].ToString();
                        plato.Estado = lector["Estado"].ToString();
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
            if(encontrado && completado)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
