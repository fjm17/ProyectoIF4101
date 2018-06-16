using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            catch (SqlException e)
            {
                throw;
            }
            catch (InvalidOperationException iex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
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
            catch (SqlException e)
            {
                throw;
            }
            catch (InvalidOperationException iex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
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
            catch (SqlException e)
            {
                throw;
            }
            catch (InvalidOperationException iex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void generarComando()
        {
            try
            {
                comando = new SqlCommand();
                comando.Connection = conexion;
            }
            catch (SqlException e)
            {
                throw;
            }
            catch (InvalidOperationException iex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void generarTransaccion()
        {
            try
            {
                transaccion = conexion.BeginTransaction("Transaccion Activa");
                comando.Transaction = transaccion;
            }
            catch (SqlException e)
            {
                throw;
            }
            catch (InvalidOperationException iex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
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
            catch (SqlException e)
            {
                throw;
            }
            catch (InvalidOperationException iex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Finalizar()
        {
            try
            {
                transaccion.Commit();
                cerrar();
                conexion = null;
                comando = null;
                transaccion = null;
            }
            catch (SqlException e)
            {
                throw;
            }
            catch (InvalidOperationException iex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
