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

        public BDConexion()
        {
            conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
        }

        public void Abrir()
        {
            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }
        }

        public void Cerrar()
        {
            if (conexion.State != ConnectionState.Closed)
            {
                conexion.Close();
            }
        }

        public SqlCommand GenerarComando()
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            return comando;
        }
    }
}
