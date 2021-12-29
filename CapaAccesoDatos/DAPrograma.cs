using CapaEntidades;
using System;
using System.Data.SqlClient; // UTILIZAR ADO .NET
using System.Data; // Se utiliza para el acceso a datos
using System.Linq;
using System.Collections.Generic;

namespace CapaAccesoDatos
{
    public class DAPrograma
    {
        #region Atributos

        private string _cadenaConexion;
        private string _mensaje;

        #endregion

        #region Propiedades

        public string CadenaConexion { get => _cadenaConexion; set => _cadenaConexion = value; }
        public string Mensaje { get => _mensaje; set => _mensaje = value; }

        #endregion

        #region Constructores

        // Al que le llega la cadena de construcción al crear 
        public DAPrograma(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = String.Empty;
        }

        public DAPrograma()
        {
            _cadenaConexion = String.Empty;
            _mensaje = String.Empty;
        }

        #endregion

        #region Método para ingresar un nuevo programa

        public int Insertar(EntidadPrograma programa)
        {
            int cod = 0; // El retorno

            // Siempre se debe hacer un objeto para usar la cadena de conexion
            SqlConnection conexion = new SqlConnection(_cadenaConexion);

            // El command es el que tiene casi todos los necesario para leer los comandos SQL
            SqlCommand comando = new SqlCommand();

            //Se le debe asignar lo que será añadido o modificado en la base de datos con esta sentencia
            //Se debe hacer como si fuera en la misma, se puede hacer todo junto sin concatenar
            string sentencia = "INSERT INTO PROGRAMAS (NOMBRE_PROGRAMA, DESCRIPCION_PROGRAMA, ESTADO, CUPO_PROGRAMA, TELEFONO_PROGRAMA, EMAIL_PROGRAMA, PROVINCIA_PROGRAMA, FECHA_INICIO_PROGRAMA, OBSERVACIONES_PROGRAMA)" + " VALUES (@nombre_programa,  @descripcion_programa, @estado, @cupo_programa, @telefono_programa, @email_programa, @provincia_programa, @fecha_inicio_programa, @observaciones_programa)" + " SELECT @@IDENTITY";

            comando.Connection = conexion; // Se le pasa la conexión al atributo del objeto comando creado

            // Se le pasan los parámetros que recibirá por el objeto comando
            comando.Parameters.AddWithValue("@nombre_programa", programa.Nombre_programa);
            comando.Parameters.AddWithValue("@descripcion_programa", programa.Descripcion_programa);

            byte estado_Actual = 0;
            if (programa.Estado == "Activo") 
            {
                estado_Actual = 1;
            }
            else if (programa.Estado == "Inactivo")
            {
                estado_Actual = 0;
            }
            
            comando.Parameters.AddWithValue("@estado", estado_Actual);
            comando.Parameters.AddWithValue("@cupo_programa", programa.Cupo_programa);
            comando.Parameters.AddWithValue("@telefono_programa", programa.Telefono_programa);
            comando.Parameters.AddWithValue("@email_programa", programa.Email_programa);
            comando.Parameters.AddWithValue("@provincia_programa", programa.Provincia_programa);
            comando.Parameters.AddWithValue("@fecha_inicio_programa", programa.Fecha_inicio_programa);
            comando.Parameters.AddWithValue("@observaciones_programa", programa.Observaciones_programa);

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

        #region Modificar

        public int Modificar(EntidadPrograma programa)
        {
            int filasAfectadas = -1;

            SqlConnection conexion = new SqlConnection(_cadenaConexion);

            SqlCommand comando = new SqlCommand();

            string sentencia =
                 "UPDATE PROGRAMAS " +
                "SET NOMBRE_PROGRAMA=@nombre_programa, " +
                "DESCRIPCION_PROGRAMA=@descripcion_programa, " +
                "ESTADO=@estado, " +
                "CUPO_PROGRAMA=@cupo_programa, " +
                "TELEFONO_PROGRAMA=@telefono_programa, " +
                "PROVINCIA_PROGRAMA=@provincia_programa, " +
                "FECHA_INICIO_PROGRAMA=@fecha_inicio_programa, " +
                "OBSERVACIONES_PROGRAMA=@observaciones_programa " +
                    "WHERE COD_PROGRAMA=@cod_programa";

            comando.Connection = conexion;
            comando.CommandText = sentencia;

            comando.Parameters.AddWithValue("@cod_programa", programa.Cod_programa);
            comando.Parameters.AddWithValue("@nombre_programa", programa.Nombre_programa);
            comando.Parameters.AddWithValue("@descripcion_programa", programa.Descripcion_programa);

            byte estado_Actual = 0;
            if (programa.Estado == "Activo")
            {
                estado_Actual = 1;
            }
            else if (programa.Estado == "Inactivo")
            {
                estado_Actual = 0;
            }
            comando.Parameters.AddWithValue("@estado", estado_Actual);

            comando.Parameters.AddWithValue("@cupo_programa", programa.Cupo_programa);
            comando.Parameters.AddWithValue("@telefono_programa", programa.Telefono_programa);
            comando.Parameters.AddWithValue("@email_programa", programa.Email_programa);
            comando.Parameters.AddWithValue("@provincia_programa", programa.Provincia_programa);
            comando.Parameters.AddWithValue("@fecha_inicio_programa", programa.Fecha_inicio_programa);
            comando.Parameters.AddWithValue("@observaciones_programa", programa.Observaciones_programa);

            try
            {
                conexion.Open();
                filasAfectadas = comando.ExecuteNonQuery(); // ExecuteNonQuery devuelve las filas afectadas
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //Se desase de las conexiones
                conexion.Dispose();
                comando.Dispose();
            }
            return filasAfectadas;

        }
        #endregion

        #region Método para leer los programas

        // Devuelve un DataSet con los clientes, para mostrarlo en el DataGridView
        public DataSet listarProgramas(string condicion, string orden)
        {
            DataSet tablaDS = new DataSet(); //Está tabla guardará las consultas SQL

            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adaptador; // Es el puente entre el DataSet y la BD

            string sentencia = "SELECT COD_PROGRAMA, NOMBRE_PROGRAMA, DESCRIPCION_PROGRAMA, ESTADO, CUPO_PROGRAMA, TELEFONO_PROGRAMA ,EMAIL_PROGRAMA, PROVINCIA_PROGRAMA, FECHA_INICIO_PROGRAMA, OBSERVACIONES_PROGRAMA FROM PROGRAMAS";

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
                adaptador.Fill(tablaDS, "Programas"); // La tabla DataSet creada anteriormente se rellena con lo devuelto de la consulta (sentencia)
            }
            catch (Exception)
            {
                throw;
            }
            return tablaDS;
        }

        #endregion

        #region Método para leer los programas pero esta devuelve una lista, esta pueda ser más dinamica 

        public List<EntidadPrograma> listarProgramas(String condicion)
        {
            List<EntidadPrograma> listaProgramas; //Se inicializa lo que se creará
            DataSet TablaDS = new DataSet();

            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adaptador;

            string sentencia = "SELECT COD_PROGRAMA, NOMBRE_PROGRAMA, DESCRIPCION_PROGRAMA, ESTADO, CUPO_PROGRAMA, TELEFONO_PROGRAMA ,EMAIL_PROGRAMA, PROVINCIA_PROGRAMA, FECHA_INICIO_PROGRAMA, OBSERVACIONES_PROGRAMA FROM PROGRAMAS";

            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = string.Format("{0} WHERE {1}", sentencia, condicion); //Format funciona para concatenar variables
            }

            try
            {
                adaptador = new SqlDataAdapter(sentencia, conexion); // Aquí se usa el adaptador para unirse BD 
                adaptador.Fill(TablaDS, "Programas"); // Se llena el DataSer con la BD

                //***Sentencia linQ para convertir el DataSet en una lista 
                listaProgramas = (from DataRow fila in TablaDS.Tables["Programas"].Rows
                                  select new EntidadPrograma()
                                  {
                                      Cod_programa = (int)fila[0],
                                      Nombre_programa = fila[1].ToString(),
                                      Descripcion_programa = fila[2].ToString(),
                                      Estado = fila[3].ToString(),
                                      Cupo_programa = (int)fila[4],
                                      Telefono_programa = fila[5].ToString(),
                                      Email_programa = fila[6].ToString(),
                                      Provincia_programa = fila[7].ToString(),
                                      Fecha_inicio_programa = (DateTime)fila[8],
                                      Observaciones_programa = fila[9].ToString(),
                                      Existe = true
                                  }).ToList();
                //Lo anterior convierte el DataSet en una lista, y cada elemento de la lista tiene Objeto EntidadCliente que 
                //representa cada fila de la tabla de la BD;
            }
            catch (Exception)
            {
                throw;
            }

            return listaProgramas;
        }
        #endregion

        #region Método para obtener un programa

        // Devuelve una entidad porque permite tener solo un registro
        public EntidadPrograma ObtenerPrograma(int cod_programa)
        {
            EntidadPrograma programa = null; // Se inicaliza null porque lo puede devolver vacío
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();

            SqlDataReader dataReader;
            // Para llenarlo se hace mediante un EXECUTE, permitiendo obtener datos de la base de datos

            string sentencia = string.Format("SELECT COD_PROGRAMA, NOMBRE_PROGRAMA, DESCRIPCION_PROGRAMA, ESTADO, CUPO_PROGRAMA, TELEFONO_PROGRAMA ,EMAIL_PROGRAMA, PROVINCIA_PROGRAMA, FECHA_INICIO_PROGRAMA, OBSERVACIONES_PROGRAMA FROM PROGRAMAS WHERE COD_PROGRAMA = {0}", cod_programa);

            comando.Connection = conexion;
            comando.CommandText = sentencia;

            try
            {
                conexion.Open();
                // Lo que hace este método de comando es crear el dataReader con lo que se tiene arriba
                dataReader = comando.ExecuteReader();

                if (dataReader.HasRows)
                {
                    programa = new EntidadPrograma();
                    dataReader.Read();

                    //Obtiene el valor de cada columna
                    programa.Cod_programa = dataReader.GetInt32(0); // Se convierte por ser un número
                    programa.Nombre_programa = dataReader.GetString(1);
                    programa.Descripcion_programa = dataReader.GetString(2);

                    // En la BD es booleano y la entidad maneja String entonces se hace un cast
                    bool estado = dataReader.GetBoolean(3);
                    if (estado == true)
                    {
                        programa.Estado = "Activo";
                    }
                    else if (estado == false)
                    {
                        programa.Estado = "Inactivo";

                    }

                    programa.Cupo_programa = dataReader.GetByte(4);
                    programa.Telefono_programa = dataReader.GetString(5);
                    programa.Email_programa = dataReader.GetString(6);
                    programa.Provincia_programa = dataReader.GetString(7);
                    programa.Fecha_inicio_programa = dataReader.GetDateTime(8);

                    //Al dejar ese espacio en blanco da error, entonces preguntando si el valor esta vacío
                    if (dataReader[9] != DBNull.Value)
                    {
                        programa.Observaciones_programa = dataReader.GetString(9);
                    }

                    programa.Existe = true;
                }
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return programa;
        }
        #endregion

        #region Método para eliminar un programa

        public int EliminarRegistro(int cod_programa)
        {
            int filasEliminadas = 0;

            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();

            String sentencia = string.Format("DELETE FROM PROGRAMAS WHERE cod_programa= {0} ", cod_programa);

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