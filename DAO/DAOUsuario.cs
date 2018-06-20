using System;
using TO;

namespace DAO
{

    public class DAOUsuario
    {

        private BDConexion bdConexion = new BDConexion();

        public Boolean Mostrar(TO_Usuario usuario)
        {
            //falta hacer el metodo, solo se puso para llamarlo en Maneajador_Usuario
            return false;
        }

        public Boolean Insertar(TO_Usuario usuario)
        {
            Boolean completado = true;
            try
            {
                formatoIngreso("INSERT INTO Usuario VALUES (@correo, @nom, @dir, @contrasena, @tipo)", usuario);
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

        private void formatoIngreso(string consulta, TO_Usuario plato) // Se utiliza para no repetir el mismo codigo en actualizar y en agregar
        {
            try
            {
                bdConexion.Conectar();
                bdConexion.Inicializar();

                bdConexion.GenerarConsulta(consulta);
                bdConexion.AsignarParametro("@correo", plato.Correo);
                bdConexion.AsignarParametro("@nom", plato.Nombre_Completo);
                bdConexion.AsignarParametro("@dir", plato.Direccion);
                bdConexion.AsignarParametro("@contrasena", plato.Contrasena);
                bdConexion.AsignarParametro("@tipo", plato.Tipo);

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
