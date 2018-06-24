﻿using System;
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

                /*if (!String.IsNullOrEmpty(usuario.Nombre_Completo))
                {
                    where = "Nombre LIKE %@nom%";
                    bdConexion.AsignarParametro("@nom", usuario.Nombre_Completo);
                }
                else*/
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
                    }
                }

                lector.Close();
                bdConexion.RealizarCommit();
            }
            catch (Exception ex)
            {
                //throw ex;
                completado = false;
                bdConexion.RealizarRollBack();
            }
            finally
            {
                bdConexion.Finalizar();
            }
            return encontrado && completado;
        }

        public Boolean MostrarUsuarios(TO_Manejador_Lista_Usuario usuarios, string nombre)
        {
            bdConexion.Conectar();
            bdConexion.Inicializar();
            try
            {

                string query = "SELECT * FROM Usuario WHERE Nombre_Completo LIKE @nom";
                bdConexion.AsignarParametro("@nom", '%' + nombre + '%');
                bdConexion.GenerarConsulta(query);

                SqlDataReader lector = bdConexion.Comando.ExecuteReader();
                llenarLista(lector, usuarios);
                return true;
            }

            catch (Exception e)
            {
                throw e;
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
                    lector["Tipo"].ToString()));
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


        public Boolean Actualizar(TO_Usuario usuario)
        {
            try
            {
                formatoIngreso("UPDATE Usuario SET Nombre_Completo = @nom "
                    + "Direccion = @dir, Contrasena = @contr, Tipo = @tipo "
                    + "WHERE Correo = @correo", usuario);
                return true;
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
