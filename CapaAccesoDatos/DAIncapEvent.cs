using System;
using System.Data.SqlClient; // UTILIZAR ADO .NET
using System.Data; // Se utiliza para el acceso a datos
using System.Linq;
using System.Collections.Generic;
using CapaEntidades;

namespace CapaAccesoDatos
{
    public class DAIncapEvent
    {
        #region Atributos

        private string _cadenaConexion;

        #endregion

        #region Propiedades

        public string CadenaConexion { get => _cadenaConexion; set => _cadenaConexion = value; }

        #endregion

        #region Constructores

        public DAIncapEvent(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
        }

        public DAIncapEvent()
        {
            _cadenaConexion = String.Empty;
        }

        #endregion

        #region Método para ingresar un nuevo registro

        public int Insertar(EntidadIncapEvent incapEvent)
        {
            int cod = 0; // El retorno

            // Siempre se debe hacer un objeto para usar la cadena de conexion
            SqlConnection conexion = new SqlConnection(_cadenaConexion);

            // El command es el que tiene casi todos los necesario para leer los comandos SQL
            SqlCommand comando = new SqlCommand();

            //Se le debe asignar lo que será añadido o modificado en la base de datos con esta sentencia
            //Se debe hacer como si fuera en la misma, se puede hacer todo junto sin concatenar
            string sentencia = "INSERT INTO INCAPACIDADES_EVENTOS (COD_ENTRENADOR, DIA_INICIO_INCAPACIDADES_EVENTOS, DIA_FINAL_INCAPACIDADES_EVENTOS, OBSERVACIONES_INCAPACIDADES_EVENTOS)" + " VALUES (@cod_entrenador, @dia_inicio_IE, @dia_fin_IE, @observaciones)" + "SELECT @@IDENTITY"; // Devuelve el último IDENTITY generado, en este caso el que se ingreso

            comando.Connection = conexion; // Se le pasa la conexión al atributo del objeto comando creado

            // Se le pasan los parámetros que recibirá por el objeto comando
            comando.Parameters.AddWithValue("@cod_entrenador", incapEvent.Cod_entrenador);
            comando.Parameters.AddWithValue("@dia_inicio_IE", incapEvent.Dia_inicio_IE);
            comando.Parameters.AddWithValue("@dia_fin_IE", incapEvent.Dia_fin_IE);
            comando.Parameters.AddWithValue("@observaciones", incapEvent.Observaciones);

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

        public int Modificar(EntidadIncapEvent incapEvent)
        {
            int filasAfectadas = -1;

            SqlConnection conexion = new SqlConnection(_cadenaConexion);

            SqlCommand comando = new SqlCommand();

            String sentencia =
                "UPDATE INCAPACIDADES_EVENTOS " +
                "SET COD_ENTRENADOR=@cod_entrenador, " +
                "DIA_INICIO_INCAPACIDADES_EVENTOS = @dia_inicio_IE, " +
                "DIA_FINAL_INCAPACIDADES_EVENTOS = @dia_fin_IE, " +
                "OBSERVACIONES_INCAPACIDADES_EVENTOS = @observaciones " +
                    " WHERE COD_INCAPACIDADES_EVENTOS=@cod_incapac_event";

            comando.CommandText = sentencia;
            comando.Connection = conexion;

            comando.Parameters.AddWithValue("@cod_incapac_event", incapEvent.Cod_incap_event);
            comando.Parameters.AddWithValue("@cod_entrenador", incapEvent.Cod_entrenador);
            comando.Parameters.AddWithValue("@dia_inicio_IE", incapEvent.Dia_inicio_IE);
            comando.Parameters.AddWithValue("@dia_fin_IE", incapEvent.Dia_fin_IE);
            comando.Parameters.AddWithValue("@observaciones", incapEvent.Observaciones);

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
        public DataSet listarIncapEvents(string condicion, string orden)
        {
            DataSet tablaDS = new DataSet(); //Está tabla guardará las consultas SQL

            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adaptador; // Es el puente entre el DataSet y la BD

            string sentencia = "SELECT COD_INCAPACIDADES_EVENTOS, COD_ENTRENADOR, DIA_INICIO_INCAPACIDADES_EVENTOS,DIA_FINAL_INCAPACIDADES_EVENTOS,OBSERVACIONES_INCAPACIDADES_EVENTOS FROM INCAPACIDADES_EVENTOS";

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
                adaptador.Fill(tablaDS, "incapacidades_eventos"); // La tabla DataSet creada anteriormente se rellena con lo devuelto de la consulta (sentencia)
            }
            catch (Exception)
            {
                throw;
            }
            return tablaDS;
        }
        #endregion

        #region Método para leer las tablas pero esta devuelve una lista, esta pueda ser más dinamica 

        public List<EntidadIncapEvent> listarIncapEvents(String condicion)
        {
            List<EntidadIncapEvent> listaIncapEvents; //Se inicializa lo que se creará
            DataSet TablaDS = new DataSet();

            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adaptador;

            string sentencia = "SELECT COD_INCAPACIDADES_EVENTOS, COD_ENTRENADOR, DIA_INICIO_INCAPACIDADES_EVENTOS,DIA_FINAL_INCAPACIDADES_EVENTOS,OBSERVACIONES_INCAPACIDADES_EVENTOS FROM INCAPACIDADES_EVENTOS";

            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = string.Format("{0} WHERE {1}", sentencia, condicion); //Format funciona para concatenar variables
            }

            try
            {
                adaptador = new SqlDataAdapter(sentencia, conexion); // Aquí se usa el adaptador para unirse BD 
                adaptador.Fill(TablaDS, "incapacidades_eventos"); // Se llena el DataSer con la BD

                //***Sentencia linQ para convertir el DataSet en una lista 
                listaIncapEvents = (from DataRow fila in TablaDS.Tables["incapacidades_eventos"].Rows
                                    select new EntidadIncapEvent()
                                    {
                                        Cod_incap_event = (int)fila[0],
                                        Cod_entrenador = (int)fila[1],
                                        Dia_inicio_IE = Convert.ToDateTime(fila[2]),
                                        Dia_fin_IE = Convert.ToDateTime(fila[3]),
                                        Observaciones = Convert.ToString(fila[4]),
                                    }).ToList();

                //Lo anterior convierte el DataSet en una lista, y cada elemento de la lista tiene Objeto Entidad que 
                //representa cada fila de la tabla de la BD;
            }
            catch (Exception)
            {
                throw;
            }

            return listaIncapEvents;
        }
        #endregion

        #region Método para obtener un registro

        // Devuelve una entidad porque permite tener solo un registro
        public EntidadIncapEvent ObtenerIncapEvent(int cod_incap_event)
        {
            EntidadIncapEvent incap_event = null; // Se inicaliza null porque lo puede devolver vacío

            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();

            SqlDataReader dataReader;
            // Para llenarlo se hace mediante un EXECUTE, permitiendo obtener datos de la base de datos

            string sentencia = string.Format("SELECT COD_INCAPACIDADES_EVENTOS, COD_ENTRENADOR, DIA_INICIO_INCAPACIDADES_EVENTOS,DIA_FINAL_INCAPACIDADES_EVENTOS,OBSERVACIONES_INCAPACIDADES_EVENTOS FROM INCAPACIDADES_EVENTOS WHERE COD_INCAPACIDADES_EVENTOS = {0}", cod_incap_event);

            comando.Connection = conexion;
            comando.CommandText = sentencia;

            try
            {
                conexion.Open();
                // Lo que hace este método de comando es crear el dataReader con lo que se tiene arriba
                dataReader = comando.ExecuteReader();

                if (dataReader.HasRows)
                {
                    incap_event = new EntidadIncapEvent();
                    dataReader.Read();

                    //Obtiene el valor de cada columna
                    incap_event.Cod_incap_event = dataReader.GetInt32(0); // Se convierte por ser un número
                    incap_event.Cod_entrenador = dataReader.GetInt32(1); // Se convierte por ser un número                    
                    incap_event.Dia_inicio_IE = dataReader.GetDateTime(2);
                    incap_event.Dia_fin_IE = dataReader.GetDateTime(3);                    

                    if (dataReader[4] != DBNull.Value)
                    {
                        incap_event.Observaciones = dataReader.GetString(4);
                    }
                    incap_event.Existe = true;

                }
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return incap_event;
        }
        #endregion

        #region Método para eliminar un registro

        public int EliminarRegistro(int cod_incap_event)
        {
            int filasEliminadas = 0;

            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();

            String sentencia = string.Format("DELETE FROM INCAPACIDADES_EVENTOS WHERE COD_INCAPACIDADES_EVENTOS= {0} ", cod_incap_event);

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
