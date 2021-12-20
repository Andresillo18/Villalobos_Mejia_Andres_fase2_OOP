using System;
using System.Data.SqlClient; // UTILIZAR ADO .NET
using System.Data; // Se utiliza para el acceso a datos
using System.Linq;
using System.Collections.Generic;
using CapaEntidades;

namespace CapaAccesoDatos
{
    class DAModulo
    {
        #region Atributos

        private string _cadenaConexion;

        #endregion

        #region Propiedades

        public string CadenaConexion { get => _cadenaConexion; set => _cadenaConexion = value; }

        #endregion

        #region Constructores
        
        // Al que le llega la cadena de construcción al crear 
        public DAModulo(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
        }

        public DAModulo()
        {
            _cadenaConexion = String.Empty;            
        }

        #endregion

        #region Método para ingresar un nuevo programa

        public int Insertar(EntidadModulo modulo, EntidadModulosPrograma ModProg)
        {
            int cod = 0; // El retorno

            // Siempre se debe hacer un objeto para usar la cadena de conexion
            SqlConnection conexion = new SqlConnection(_cadenaConexion);

            // El command es el que tiene casi todos los necesario para leer los comandos SQL
            SqlCommand comando = new SqlCommand();

            //Se le debe asignar lo que será añadido o modificado en la base de datos con esta sentencia
            //Se debe hacer como si fuera en la misma, se puede hacer todo junto sin concatenar
            string sentencia = "INSERT INTO MODULOS (NOMBRE_MODULO, HORAS_DURACION_MODULO,REQUESITOS_MODULO)" + "VALUES (@nombre_modulo,  @horas_duracion_modulo, @requesitos_modulo)" + "SELECT @@IDENTITY"; // Devuelve el último IDENTITY generado, en este caso el que se ingreso

            comando.Connection = conexion; // Se le pasa la conexión al atributo del objeto comando creado

            // Se le pasan los parámetros que recibirá por el objeto comando
            comando.Parameters.AddWithValue("@nombre_modulo", modulo.Nombre_modulo);
            comando.Parameters.AddWithValue("@horas_duracion_modulo", modulo.Horas_duracion);
            comando.Parameters.AddWithValue("@requesitos_modulo", modulo.Horas_duracion);

            //Esta sentencia y su inicialización de los parámetros es para poder actualizar la tabla de unión MODULOS_PROGRAMA
            string sentencia2 = "INSERT INTO MODULOS_PROGRAMA (COD_PROGRAMA, COD_MODULO)" + "VALUES (@cod_programa,  @cod_modulo)";
            comando.Parameters.AddWithValue("@cod_programa", ModProg.Cod_programa);
            comando.Parameters.AddWithValue("@cod_modulo", ModProg.Cod_modulo);

            // La sentencia a alterar se guarda en el CommandText porque es la sentencia dado por el provedor
            comando.CommandText = sentencia;
            comando.CommandText = sentencia2;

            //Hasta este punto el objeto SqlCommnado (comando) ya está prepadado para ejecutar la instrucción SQL

            // Ejecutar la consulta SQL:
            try
            {
                conexion.Open();

                cod = Convert.ToInt32(comando.ExecuteScalar()); // Devuelve un valor fijo o en este caso el IDENTITY generado
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                // Dispose means throw away
                conexion.Dispose();
                conexion.Dispose();
            }

            return cod;
        }
        #endregion
    }
}
