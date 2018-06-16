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
        private BDConexion bdConexion;

        public Boolean Agregar(TO_Plato plato)
        {
            try
            {
                bdConexion = new BDConexion();
                bdConexion.Abrir();
                SqlCommand comando = bdConexion.GenerarComando();
                comando.CommandText = "Insert Into Plato Values (@nom, @desc, @prec, @foto, @estado)";
                comando.Parameters.AddWithValue("@nom", plato.nombre);
                comando.Parameters.AddWithValue("@desc", plato.descripcion);
                comando.Parameters.AddWithValue("@prec", plato.precio);
                comando.Parameters.AddWithValue("@foto", plato.foto);
                comando.Parameters.AddWithValue("@estado", plato.estado);
                comando.ExecuteNonQuery();
                bdConexion.Cerrar();
            }
            catch(SqlException e)
            {
                return false;
            }
            catch(Exception ex )
            {
                return false;
            }

            return true;
        }
    }
}
