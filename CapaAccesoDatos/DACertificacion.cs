using System;
using System.Data.SqlClient; // UTILIZAR ADO .NET
using System.Data; // Se utiliza para el acceso a datos
using System.Linq;
using System.Collections.Generic;
using CapaEntidades;

namespace CapaAccesoDatos
{
    public class DACertificacion
    {
        #region Atributos

        private string _cadenaConexion;

        #endregion

        #region Propiedades

        public string CadenaConexion { get => _cadenaConexion; set => _cadenaConexion = value; }

        #endregion

        #region Constructores

        public DACertificacion(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
        }

        public DACertificacion()
        {
            _cadenaConexion = String.Empty;
        }

        #endregion

        #region Método para ingresar un nuevo registro

        public int Insertar(EntidadCertificacion certificacion)
        {
            int cod = 0; // El retorno

            // Siempre se debe hacer un objeto para usar la cadena de conexion
            SqlConnection conexion = new SqlConnection(_cadenaConexion);

            // El command es el que tiene casi todos los necesario para leer los comandos SQL
            SqlCommand comando = new SqlCommand();

            //Se le debe asignar lo que será añadido o modificado en la base de datos con esta sentencia
            //Se debe hacer como si fuera en la misma, se puede hacer todo junto sin concatenar
            string sentencia = "INSERT INTO CERTIFICACIONES ( COD_ENTRENADOR, GIMNASIO_ESPECIFICACION,NATACION_ESPECIFICACION,MARATON_ESPECIFICACION,CICLISMO_ESPECIFICACION)" + " VALUES (@cod_entrenador, @gimnasio_especifi, @natacion_especifi, @maraton_especifi, @ciclismo_especifi)" + "SELECT @@IDENTITY"; // Devuelve el último IDENTITY generado, en este caso el que se ingreso

            comando.Connection = conexion; // Se le pasa la conexión al atributo del objeto comando creado

            // Se le pasan los parámetros que recibirá por el objeto comando
            comando.Parameters.AddWithValue("@cod_entrenador", certificacion.Cod_entrenador);
            comando.Parameters.AddWithValue("@gimnasio_especifi", certificacion.Gimnasio_especifi);
            comando.Parameters.AddWithValue("@natacion_especifi", certificacion.Natacion_especifi);
            comando.Parameters.AddWithValue("@maraton_especifi", certificacion.Maraton_especifi);
            comando.Parameters.AddWithValue("@ciclismo_especifi", certificacion.Ciclismo_especifi);            

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

        public int Modificar(EntidadCertificacion certificacion)
        {
            int filasAfectadas = -1;

            SqlConnection conexion = new SqlConnection(_cadenaConexion);

            SqlCommand comando = new SqlCommand();

            String sentencia =
                "UPDATE CERTIFICACIONES " +
                "SET COD_ENTRENADOR=@cod_entrenador, " +
                "GIMNASIO_ESPECIFICACION = @gimnasio_especifi, " +
                "NATACION_ESPECIFICACION = @natacion_especifi, " +
                "MARATON_ESPECIFICACION = @maraton_especifi, " +
                    "CICLISMO_ESPECIFICACION=@ciclismo_especifi " +
                    " WHERE COD_CERTIFICACION=@cod_certificacion";

            comando.CommandText = sentencia;
            comando.Connection = conexion;

            comando.Parameters.AddWithValue("@cod_certificacion", certificacion.Cod_certificacion);
            comando.Parameters.AddWithValue("@cod_entrenador", certificacion.Cod_entrenador);
            comando.Parameters.AddWithValue("@gimnasio_especifi", certificacion.Gimnasio_especifi);
            comando.Parameters.AddWithValue("@natacion_especifi", certificacion.Natacion_especifi);
            comando.Parameters.AddWithValue("@maraton_especifi", certificacion.Maraton_especifi);
            comando.Parameters.AddWithValue("@ciclismo_especifi", certificacion.Ciclismo_especifi);

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
        public DataSet listarCertificaciones(string condicion, string orden)
        {
            DataSet tablaDS = new DataSet(); //Está tabla guardará las consultas SQL

            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adaptador; // Es el puente entre el DataSet y la BD

            string sentencia = "SELECT COD_CERTIFICACION, COD_ENTRENADOR, GIMNASIO_ESPECIFICACION,NATACION_ESPECIFICACION,MARATON_ESPECIFICACION,CICLISMO_ESPECIFICACION FROM CERTIFICACIONES";

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
                adaptador.Fill(tablaDS, "certificaciones"); // La tabla DataSet creada anteriormente se rellena con lo devuelto de la consulta (sentencia)
            }
            catch (Exception)
            {
                throw;
            }
            return tablaDS;
        }
        #endregion

        #region Método para leer las tablas pero esta devuelve una lista, esta pueda ser más dinamica 

        public List<EntidadCertificacion> listarCertificaciones(String condicion)
        {
            List<EntidadCertificacion> listaCertificaciones; //Se inicializa lo que se creará
            DataSet TablaDS = new DataSet();

            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adaptador;

            string sentencia = "SELECT COD_CERTIFICACION, COD_ENTRENADOR, GIMNASIO_ESPECIFICACION,NATACION_ESPECIFICACION,MARATON_ESPECIFICACION,CICLISMO_ESPECIFICACION FROM CERTIFICACIONES";

            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = string.Format("{0} WHERE {1}", sentencia, condicion); //Format funciona para concatenar variables
            }

            try
            {
                adaptador = new SqlDataAdapter(sentencia, conexion); // Aquí se usa el adaptador para unirse BD 
                adaptador.Fill(TablaDS, "certificaciones"); // Se llena el DataSer con la BD

                //***Sentencia linQ para convertir el DataSet en una lista 
                listaCertificaciones = (from DataRow fila in TablaDS.Tables["certificaciones"].Rows
                                 select new EntidadCertificacion()
                                 {
                                     Cod_certificacion = (int)fila[0],
                                     Cod_entrenador = (int)fila[1],
                                     Gimnasio_especifi= Convert.ToBoolean(fila[2]),
                                    Natacion_especifi= Convert.ToBoolean(fila[3]),
                                     Maraton_especifi= Convert.ToBoolean(fila[4]),
                                     Ciclismo_especifi= Convert.ToBoolean(fila[5]),                              
                                 }).ToList();

                //Lo anterior convierte el DataSet en una lista, y cada elemento de la lista tiene Objeto Entidad que 
                //representa cada fila de la tabla de la BD;
            }
            catch (Exception)
            {
                throw;
            }

            return listaCertificaciones;
        }
        #endregion

        #region Método para obtener un registro

        // Devuelve una entidad porque permite tener solo un registro
        public EntidadCertificacion ObtenerCertificacion(int cod_certificacion )
        {
            EntidadCertificacion certificacion = null; // Se inicaliza null porque lo puede devolver vacío

            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();

            SqlDataReader dataReader;
            // Para llenarlo se hace mediante un EXECUTE, permitiendo obtener datos de la base de datos

            string sentencia = string.Format("SELECT COD_CERTIFICACION, COD_ENTRENADOR, GIMNASIO_ESPECIFICACION,NATACION_ESPECIFICACION,MARATON_ESPECIFICACION,CICLISMO_ESPECIFICACION FROM CERTIFICACIONES WHERE COD_CERTIFICACION = {0}", cod_certificacion);

            comando.Connection = conexion;
            comando.CommandText = sentencia;

            try
            {
                conexion.Open();
                // Lo que hace este método de comando es crear el dataReader con lo que se tiene arriba
                dataReader = comando.ExecuteReader();

                if (dataReader.HasRows)
                {
                    certificacion = new EntidadCertificacion();
                    dataReader.Read();

                    //Obtiene el valor de cada columna
                    certificacion.Cod_certificacion = dataReader.GetInt32(0); // Se convierte por ser un número
                    certificacion.Cod_entrenador = dataReader.GetInt32(1); // Se convierte por ser un número
                    if (dataReader[2] != DBNull.Value)
                    {
                        certificacion.Gimnasio_especifi= dataReader.GetBoolean(2);
                    }
                    if (dataReader[3] != DBNull.Value)
                    {
                        certificacion.Natacion_especifi = dataReader.GetBoolean(3);
                    }
                    if (dataReader[4] != DBNull.Value)
                    {
                        certificacion.Maraton_especifi= dataReader.GetBoolean(4);
                    }
                    if (dataReader[5] != DBNull.Value)
                    {
                        certificacion.Ciclismo_especifi= dataReader.GetBoolean(5);
                    }
                    certificacion.Existe = true; //***
                    
                }
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return certificacion;
        }
        #endregion

        #region Método para eliminar un registro

        public int EliminarRegistro(int cod_certificacion)
        {
            int filasEliminadas = 0;

            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();

            String sentencia = string.Format("DELETE FROM CERTIFICACIONES WHERE COD_CERTIFICACION= {0} ", cod_certificacion);

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
