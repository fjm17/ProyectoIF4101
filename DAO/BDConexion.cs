using System;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class BDConexion
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlTransaction transaccion;

        public SqlCommand Comando
        {
            get
            {
                return comando;
            }
        }

        public BDConexion()
        {
        }

        public void Conectar()
        {
            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void abrir() 
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cerrar()
        {
            try
            {
                if (conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void generarComando()
        {
            try
            {
                comando = new SqlCommand();
                comando.Connection = conexion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void generarTransaccion()
        {
            try
            {
                transaccion = conexion.BeginTransaction("Transaccion Activa");
                comando.Transaction = transaccion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Inicializar()
        {
            try
            {
                abrir();
                generarComando();
                generarTransaccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AsignarParametro(string parametro, object valor)
        {
            try
            { 
                comando.Parameters.AddWithValue(parametro, valor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GenerarConsulta(string consulta)
        {
            try
            {
                comando.CommandText = consulta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RealizarCommit()
        {
            try
            {
                transaccion.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       public void RealizarRollBack()
        {
            try
            {
                transaccion.Rollback();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Finalizar()
        {
            try
            {
                cerrar();
                conexion = null;
                comando = null;
                transaccion = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
