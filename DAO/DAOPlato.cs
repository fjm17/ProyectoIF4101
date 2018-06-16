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
            try
            {
                formatoIngreso("Insert Into Plato Values (@nom, @desc, @prec, @foto, @estado)", plato);
            }
            catch(SqlException e)
            {
                return false;
            }
            catch(InvalidOperationException iex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public Boolean Actualizar(TO_Plato plato)
        {
            try
            {
                formatoIngreso("Update Plato Set Descripcion = @desc, Precio = @prec, Foto = @foto, Estado = @estado Where Nombre = @nom", plato);
            }
            catch (SqlException e)
            {
                return false;
            }
            catch (InvalidOperationException iex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        private void formatoIngreso(string consulta, TO_Plato plato) // Se utiliza para no repetir el mismo codigo en actualizar y en agregar
        {
            try
            {
                bdConexion.Conectar();
                bdConexion.Inicializar();

                bdConexion.Comando.CommandText = consulta;
                bdConexion.Comando.Parameters.AddWithValue("@nom", plato.Nombre);
                bdConexion.Comando.Parameters.AddWithValue("@desc", plato.Descripcion);
                bdConexion.Comando.Parameters.AddWithValue("@prec", plato.Precio);
                bdConexion.Comando.Parameters.AddWithValue("@foto", plato.Foto);
                bdConexion.Comando.Parameters.AddWithValue("@estado", plato.Estado);

                bdConexion.Comando.ExecuteNonQuery();
                bdConexion.Finalizar();
            }
            catch (SqlException e)
            {
                bdConexion.Finalizar();
                throw;
            }
            catch (InvalidOperationException iex)
            {
                bdConexion.Finalizar();
                throw;
            }
            catch (Exception ex)
            {
                bdConexion.Finalizar();
                throw;
            }
        }

    }
}
