using System;
using System.Data.SqlClient;
using TO;

namespace DAO
{

    public class DAOUsuario
    {

        private BDConexion bdConexion = new BDConexion();

        public Boolean Mostrar(TO_Usuario usuario)
        {
            Boolean encontrado = false;
            Boolean completado = true;
            Boolean login = false;

            try
            {
                bdConexion.Conectar();
                bdConexion.Inicializar();
                string query = "SELECT * FROM Usuario WHERE Correo = @correo";

                if (!String.IsNullOrEmpty(usuario.Contrasena))
                {
                    login = true;
                    query += " AND Contrasena = @contr";
                }
                bdConexion.GenerarConsulta(query);
                bdConexion.AsignarParametro("@correo", usuario.Correo);
                if (login)
                {
                    bdConexion.AsignarParametro("@contr", usuario.Contrasena);
                }

                SqlDataReader lector = bdConexion.Comando.ExecuteReader();

                if (lector.HasRows)
                {
                    encontrado = true;

                    while (lector.Read())
                    {
                        usuario.Correo = lector["Correo"].ToString();
                        usuario.Nombre_Completo = lector["Nombre_Completo"].ToString();
                        usuario.Direccion = lector["Direccion"].ToString();
                        usuario.Tipo = lector["Tipo"].ToString();
                    }
                }

                lector.Close();
                bdConexion.RealizarCommit();
            }
            catch (Exception ex)
            {
                throw ex;
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

        public Boolean Insertar(TO_Usuario usuario)
        {
            Boolean completado = true;
            try
            {
                formatoIngreso("INSERT INTO Usuario VALUES (@correo, @nom, @dir, @contr, @tipo)", usuario);
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

        private void formatoIngreso(string consulta, TO_Usuario usuario)
        {
            try
            {
                bdConexion.Conectar();
                bdConexion.Inicializar();

                bdConexion.GenerarConsulta(consulta);
                bdConexion.AsignarParametro("@correo", usuario.Correo);
                bdConexion.AsignarParametro("@nom", usuario.Nombre_Completo);
                bdConexion.AsignarParametro("@dir", usuario.Direccion);
                bdConexion.AsignarParametro("@contr", usuario.Contrasena);
                bdConexion.AsignarParametro("@tipo", usuario.Tipo);

                bdConexion.Comando.ExecuteNonQuery();
                bdConexion.RealizarCommit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
