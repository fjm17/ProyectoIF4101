using System;
using System.Data.SqlClient;
using TO;

namespace DAO
{

    public class DAOUsuario
    {

        private BDConexion bdConexion = new BDConexion();

        /**
        * El metodo puede usarse para buscar la informacion de un usuario o para
        * hacer login, por lo que si el Property Contrasena en el parametro usuario
        * esta vacio o no determinara cual de estas operaciones se esta llevando a cabo.
        */
        public Boolean Mostrar(TO_Usuario usuario)
        {
            Boolean encontrado = false;
            Boolean completado = true;
            Boolean login = false;

            try
            {
                bdConexion.Conectar();
                bdConexion.Inicializar();
                string query = "SELECT * FROM Usuario WHERE ";
                string where = "";

                where = "Correo = @correo";
                bdConexion.AsignarParametro("@correo", usuario.Correo);

                if (!String.IsNullOrEmpty(usuario.Contrasena))
                {
                    login = true;
                    where += " AND Contrasena = @contr";
                    bdConexion.AsignarParametro("@contr", usuario.Contrasena);
                }
                query += where;
                bdConexion.GenerarConsulta(query);

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
                        usuario.Estado_Cuenta = lector["Estado_Cuenta"].ToString();
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
            return encontrado && completado;
        }

        public Boolean MostrarUsuarios(TO_Manejador_Lista_Usuario usuarios, string correo)
        {
            bdConexion.Conectar();
            bdConexion.Inicializar();
            try
            {

                string query = "SELECT * FROM Usuario WHERE Correo LIKE @nom";
                bdConexion.AsignarParametro("@nom", '%' + correo + '%');
                bdConexion.GenerarConsulta(query);

                SqlDataReader lector = bdConexion.Comando.ExecuteReader();
                llenarLista(lector, usuarios);
                lector.Close();
                return true;
            }

            catch (Exception e)
            {

                bdConexion.RealizarRollBack();
                return false;
            }
        }

        private void llenarLista(SqlDataReader lector, TO_Manejador_Lista_Usuario usuarios)
        {
            while (lector.Read())
            {
                usuarios.AgregarUsuario(new TO_Usuario(lector["Correo"].ToString(), 
                    lector["Nombre_Completo"].ToString(), lector["Direccion"].ToString(), 
                    lector["Tipo"].ToString(), lector["Estado_Cuenta"].ToString()));
            }
        }



        public Boolean Insertar(TO_Usuario usuario)
        {
            Boolean completado = true;
            try
            {
                formatoIngreso("INSERT INTO Usuario VALUES (@correo, @nom, @dir, @contr, @tipo, @estado)", usuario);
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

        public Boolean Actualizar(TO_Usuario usuario)
        {
            try
            {
                if (usuario.Contrasena.Equals(""))
                {
                    formatoIngreso("UPDATE Usuario SET Nombre_Completo = @nom, "
                    + "Direccion = @dir, Tipo = @tipo, Estado_Cuenta = @estado "
                    + "WHERE Correo = @correo", usuario);
                    return true;
                }
                else {
                    formatoIngreso("UPDATE Usuario SET Nombre_Completo = @nom, "
                        + "Direccion = @dir, Contrasena = @contr, Tipo = @tipo, Estado_Cuenta = @estado "
                        + "WHERE Correo = @correo", usuario);
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                bdConexion.Finalizar();
            }
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
                bdConexion.AsignarParametro("@estado", usuario.Estado_Cuenta);


                bdConexion.Comando.ExecuteNonQuery();
                bdConexion.RealizarCommit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void formatoIngresoSinContrasena(string consulta, TO_Usuario usuario)
        {
            try
            {
                bdConexion.Conectar();
                bdConexion.Inicializar();

                bdConexion.GenerarConsulta(consulta);
                bdConexion.AsignarParametro("@correo", usuario.Correo);
                bdConexion.AsignarParametro("@nom", usuario.Nombre_Completo);
                bdConexion.AsignarParametro("@dir", usuario.Direccion);
                bdConexion.AsignarParametro("@tipo", usuario.Tipo);
                bdConexion.AsignarParametro("@estado", usuario.Estado_Cuenta);


                bdConexion.Comando.ExecuteNonQuery();
                bdConexion.RealizarCommit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean Eliminar(TO_Usuario toUsuario)
        {
            Boolean completado = true;

            if (!Mostrar(toUsuario))
            {
                completado = false;
            }
            else
            {
                try
                {
                    bdConexion.Conectar();
                    bdConexion.Inicializar();
                    bdConexion.GenerarConsulta("DELETE FROM Usuario WHERE Correo = @correo");
                    bdConexion.AsignarParametro("@correo", toUsuario.Correo);
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

    }
}
