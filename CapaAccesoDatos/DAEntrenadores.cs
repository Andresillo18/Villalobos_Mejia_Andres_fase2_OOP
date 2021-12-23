using System;
using System.Data.SqlClient; // UTILIZAR ADO .NET
using System.Data; // Se utiliza para el acceso a datos
using System.Linq;
using System.Collections.Generic;
using CapaEntidades;

namespace CapaAccesoDatos
{
    public class DAEntrenadores
    {
        #region Atributos

        private string _cadenaConexion;

        #endregion

        #region Propiedades

        public string CadenaConexion { get => _cadenaConexion; set => _cadenaConexion = value; }

        #endregion

        #region Constructores

        public DAEntrenadores(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
        }

        public DAEntrenadores()
        {
            _cadenaConexion = String.Empty;
        }

        #endregion

        #region Método para ingresar un nuevo registro

        public int Insertar(EntidadEntrenador entrenador)
        {
            int cod = 0; // El retorno

            // Siempre se debe hacer un objeto para usar la cadena de conexion
            SqlConnection conexion = new SqlConnection(_cadenaConexion);

            // El command es el que tiene casi todos los necesario para leer los comandos SQL
            SqlCommand comando = new SqlCommand();

            //Se le debe asignar lo que será añadido o modificado en la base de datos con esta sentencia
            //Se debe hacer como si fuera en la misma, se puede hacer todo junto sin concatenar
            string sentencia = "INSERT INTO ENTRENADORES (ID_ENTRENADOR, NOMBRE_ENTRENADOR, APELLIDO1_ENTRENADOR, APELLIDO2_ENTRENADOR, TELEFONO1_ENTRENADOR, TELEFONO2_ENTRENADOR, CORREO_ENTRENADOR,FECHA_NACIMIENTO_ENTRENADOR, PROVINCIA_ENTRENADOR, DISTRITO_ENTRENADOR, CANTON_ENTRENADOR, ESTADO_ENTRENADOR)" + " VALUES (@id_entrenador,  @nombre_entrenador, @apellido1, @apellido2, @telefono1, @telefono2,@correo, @fechaNacimiento ,@provincia, @distrito,@canton,@estado)" + "SELECT @@IDENTITY"; // Devuelve el último IDENTITY generado, en este caso el que se ingreso

            comando.Connection = conexion; // Se le pasa la conexión al atributo del objeto comando creado

            // Se le pasan los parámetros que recibirá por el objeto comando
            comando.Parameters.AddWithValue("@id_entrenador", entrenador.Identificacion);
            comando.Parameters.AddWithValue("@nombre_entrenador", entrenador.Nombre);
            comando.Parameters.AddWithValue("@apellido1", entrenador.Apellido1);
            comando.Parameters.AddWithValue("@apellido2", entrenador.Apellido2);
            comando.Parameters.AddWithValue("@telefono1", entrenador.Telefono1);
            comando.Parameters.AddWithValue("@telefono2", entrenador.Telefono2);
            comando.Parameters.AddWithValue("@correo", entrenador.Correo);
            comando.Parameters.AddWithValue("@fechaNacimiento", entrenador.Fecha_nacimiento);
            comando.Parameters.AddWithValue("@provincia", entrenador.Provincia);
            comando.Parameters.AddWithValue("@distrito", entrenador.Distrito);
            comando.Parameters.AddWithValue("@canton", entrenador.Canton);
            comando.Parameters.AddWithValue("@estado", entrenador.Estado);

            // La sentencia a alterar se guarda en el CommandText porque es la sentencia dado por el provedor
            comando.CommandText = sentencia;

            //Hasta este punto el objeto SqlCommnado (comando) ya está prepadado para ejecutar la instrucción SQL

            // Ejecutar la consulta SQL:
            try
            {
                conexion.Open();

                cod = Convert.ToInt32(comando.ExecuteScalar()); // Devuelve un valor fijo o en este caso el IDENTITY generado
                conexion.Close();
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

        #region Método Modificar (actualizar)

        public int Modificar(EntidadEntrenador entrenador)
        {
            int filasAfectadas = -1;

            SqlConnection conexion = new SqlConnection(_cadenaConexion);

            SqlCommand comando = new SqlCommand();

            String sentencia =
                "UPDATE ENTRENADORES " +
                "SET ID_ENTRENADOR=@id_entrenador, " +
                "NOMBRE_ENTRENADOR = @nombre_entrenador, " +
                "APELLIDO1_ENTRENADOR = @apellido1, " +
                "APELLIDO2_ENTRENADOR = @apellido2, " +
                "TELEFONO1_ENTRENADOR = @telefono1, " +
                "TELEFONO2_ENTRENADOR = @telefono2, " +
                "CORREO_ENTRENADOR = @correo, " +
                "FECHA_NACIMIENTO_ENTRENADOR = @fechaNacimiento, " +
                "PROVINCIA_ENTRENADOR = @provincia, " +
                "DISTRITO_ENTRENADOR = @distrito, " +
                "CANTON_ENTRENADOR = @canton, " +
                    "ESTADO_ENTRENADOR=@estado" +
                    " WHERE COD_ENTRENADOR=@cod_entrenador";

            comando.CommandText = sentencia;
            comando.Connection = conexion;

            comando.Parameters.AddWithValue("@cod_entrenador", entrenador.Cod_entrenador);
            comando.Parameters.AddWithValue("@id_entrenador", entrenador.Identificacion);
            comando.Parameters.AddWithValue("@nombre_entrenador", entrenador.Nombre);
            comando.Parameters.AddWithValue("@apellido1", entrenador.Apellido1);
            comando.Parameters.AddWithValue("@apellido2", entrenador.Apellido2);
            comando.Parameters.AddWithValue("@telefono1", entrenador.Telefono1);
            comando.Parameters.AddWithValue("@telefono2", entrenador.Telefono2);
            comando.Parameters.AddWithValue("@correo", entrenador.Correo);
            comando.Parameters.AddWithValue("@fechaNacimiento", entrenador.Fecha_nacimiento);
            comando.Parameters.AddWithValue("@provincia", entrenador.Provincia);
            comando.Parameters.AddWithValue("@distrito", entrenador.Distrito);
            comando.Parameters.AddWithValue("@canton", entrenador.Canton);
            comando.Parameters.AddWithValue("@estado", entrenador.Estado);

            try
            {
                conexion.Open();
                filasAfectadas = comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Dispose();
                comando.Dispose();
            }

            return filasAfectadas;
        }

        #endregion

        #region Método DataSet para leer los registros

        // Devuelve un DataSet con los registros a buscar, para mostrarlo en el DataGridView
        public DataSet listarEntrenador(string condicion, string orden)
        {
            DataSet tablaDS = new DataSet(); //Está tabla guardará las consultas SQL

            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adaptador; // Es el puente entre el DataSet y la BD

            String sentencia = "SELECT COD_ENTRENADOR, ID_ENTRENADOR, NOMBRE_ENTRENADOR,APELLIDO1_ENTRENADOR,APELLIDO2_ENTRENADOR,TELEFONO1_ENTRENADOR, TELEFONO2_ENTRENADOR, CORREO_ENTRENADOR,FECHA_NACIMIENTO_ENTRENADOR, PROVINCIA_ENTRENADOR, DISTRITO_ENTRENADOR, CANTON_ENTRENADOR, ESTADO_ENTRENADOR  FROM ENTRENADORES";

            // El uso de las condicion y el orden
            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = string.Format("{0} WHERE {1}", sentencia, condicion); //Format funciona para concatenar variables
            }
            if (!string.IsNullOrEmpty(orden))
            {
                sentencia = string.Format("{0} ORDER BY {1}", sentencia, orden);
            }

            try
            {
                adaptador = new SqlDataAdapter(sentencia, conexion);
                adaptador.Fill(tablaDS, "entrenadores"); // La tabla DataSet creada anteriormente se rellena con lo devuelto de la consulta (sentencia)
            }
            catch (Exception)
            {
                throw;
            }
            return tablaDS;
        }
        #endregion

        #region Método para leer las tablas pero esta devuelve una lista, esta pueda ser más dinamica 

        public List<EntidadEntrenador> listarEntrenador(String condicion)
        {
            List<EntidadEntrenador> listaEntrenadores; //Se inicializa lo que se creará
            DataSet TablaDS = new DataSet();

            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adaptador;

            String sentencia = "SELECT COD_ENTRENADOR, ID_ENTRENADOR, NOMBRE_ENTRENADOR,APELLIDO1_ENTRENADOR,APELLIDO2_ENTRENADOR,TELEFONO1_ENTRENADOR, TELEFONO2_ENTRENADOR, CORREO_ENTRENADORCORREO_ENTRENADOR,FECHA_NACIMIENTO_ENTRENADOR, PROVINCIA_ENTRENADOR, DISTRITO_ENTRENADOR, CANTON_ENTRENADOR, ESTADO_ENTRENADOR  FROM ENTRENADORES";

            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = string.Format("{0} WHERE {1}", sentencia, condicion); //Format funciona para concatenar variables
            }

            try
            {
                adaptador = new SqlDataAdapter(sentencia, conexion); // Aquí se usa el adaptador para unirse BD 
                adaptador.Fill(TablaDS, "entrenadores"); // Se llena el DataSer con la BD

                //***Sentencia linQ para convertir el DataSet en una lista 
                listaEntrenadores = (from DataRow fila in TablaDS.Tables["entrenadores"].Rows
                                     select new EntidadEntrenador()
                                     {
                                         Cod_entrenador = (int)fila[0],
                                         Nombre = fila[1].ToString(),
                                         Apellido1 = fila[2].ToString(),
                                         Apellido2 = fila[3].ToString(),
                                         Telefono1 = fila[4].ToString(),
                                         Telefono2 = fila[5].ToString(),
                                         Correo = fila[6].ToString(),
                                         Fecha_nacimiento = Convert.ToDateTime(fila[7]),
                                         Provincia = fila[8].ToString(),
                                         Distrito = fila[9].ToString(),
                                         Canton = fila[10].ToString(),
                                         Estado = true
                                     }).ToList();

                //Lo anterior convierte el DataSet en una lista, y cada elemento de la lista tiene Objeto Entidad que 
                //representa cada fila de la tabla de la BD;
            }
            catch (Exception)
            {
                throw;
            }

            return listaEntrenadores;
        }
        #endregion

        #region Método para obtener un registro

        // Devuelve una entidad porque permite tener solo un registro
        public EntidadEntrenador ObtenerEntrenador(int cod_entrenador)
        {
            EntidadEntrenador entrenadorActivo = null; // Se inicaliza null porque lo puede devolver vacío

            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();

            SqlDataReader dataReader;
            // Para llenarlo se hace mediante un EXECUTE, permitiendo obtener datos de la base de datos

            string sentencia = string.Format("SELECT COD_ENTRENADOR, ID_ENTRENADOR, NOMBRE_ENTRENADOR ,APELLIDO1_ENTRENADOR, APELLIDO2_ENTRENADOR,TELEFONO1_ENTRENADOR, TELEFONO2_ENTRENADOR, CORREO_ENTRENADOR,FECHA_NACIMIENTO_ENTRENADOR, PROVINCIA_ENTRENADOR, DISTRITO_ENTRENADOR, CANTON_ENTRENADOR, ESTADO_ENTRENADOR  FROM ENTRENADORES WHERE COD_ENTRENADOR = {0}", cod_entrenador);

            comando.Connection = conexion;
            comando.CommandText = sentencia;

            try
            {
                conexion.Open();
                // Lo que hace este método de comando es crear el dataReader con lo que se tiene arriba
                dataReader = comando.ExecuteReader();

                if (dataReader.HasRows)
                {
                    entrenadorActivo = new EntidadEntrenador();
                    dataReader.Read();

                    //Obtiene el valor de cada columna
                    entrenadorActivo.Cod_entrenador = dataReader.GetInt32(0); // Se convierte por ser un número
                    entrenadorActivo.Identificacion = dataReader.GetString(1);
                    entrenadorActivo.Nombre = dataReader.GetString(2);
                    entrenadorActivo.Apellido1 = dataReader.GetString(3);
                    entrenadorActivo.Apellido2 = dataReader.GetString(4);
                    entrenadorActivo.Telefono1 = dataReader.GetString(5);
                    if (dataReader[6] != DBNull.Value)
                    {
                        entrenadorActivo.Telefono2 = dataReader.GetString(6); // Si esa posición de dataReader tiene algo que se ejecute el proceso
                    }
                    if (dataReader[7] != DBNull.Value)
                    {
                        entrenadorActivo.Correo = dataReader.GetString(7);
                    }
                    entrenadorActivo.Fecha_nacimiento = dataReader.GetDateTime(8);
                    entrenadorActivo.Provincia = dataReader.GetString(9);
                    entrenadorActivo.Distrito = dataReader.GetString(10);
                    entrenadorActivo.Canton = dataReader.GetString(11);
                    entrenadorActivo.Estado = true;
                }
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return entrenadorActivo;
        }
        #endregion

        #region Método para eliminar un registro

        public int EliminarRegistro(int cod_entrenador)
        {
            int filasEliminadas = 0;

            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();

            String sentencia = string.Format("DELETE FROM ENTRENADORES WHERE COD_ENTRENADOR= {0} ", cod_entrenador);

            comando.CommandText = sentencia;
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                filasEliminadas = comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Dispose();
                comando.Dispose();
            }

            return filasEliminadas;
        }
        #endregion
    }
}
