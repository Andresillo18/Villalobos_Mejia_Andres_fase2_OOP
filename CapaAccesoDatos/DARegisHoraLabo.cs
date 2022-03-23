using System;
using System.Data.SqlClient; // UTILIZAR ADO .NET
using System.Data; // Se utiliza para el acceso a datos
using System.Linq;
using System.Collections.Generic;
using CapaEntidades;

namespace CapaAccesoDatos
{
    public class DARegisHoraLabo
    {
        #region Atributos

        private string _cadenaConexion;

        #endregion

        #region Propiedades

        public string CadenaConexion { get => _cadenaConexion; set => _cadenaConexion = value; }

        #endregion

        #region Constructores

        public DARegisHoraLabo(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
        }

        public DARegisHoraLabo()
        {
            _cadenaConexion = String.Empty;
        }

        #endregion

        #region Método para ingresar un nuevo registro

        public int Insertar(EntidadRegisHoraLabo horasLabo)
        {
            int cod = 0; // El retorno

            // Siempre se debe hacer un objeto para usar la cadena de conexion
            SqlConnection conexion = new SqlConnection(_cadenaConexion);

            // El command es el que tiene casi todos los necesario para leer los comandos SQL
            SqlCommand comando = new SqlCommand();

            //Se le debe asignar lo que será añadido o modificado en la base de datos con esta sentencia
            //Se debe hacer como si fuera en la misma, se puede hacer todo junto sin concatenar
            string sentencia = "INSERT INTO REGISTRO_HORAS_LABORADAS ( COD_ENTRENADOR, DIA_REGISTRO_HORALABO, HORA_INICIO_REGISTRO_HORALABO, HORA_FINAL_REGISTRO_HORALABO)" + " VALUES (@cod_entrenador, @dia_registrado_HL, @hora_inicio, @hora_final)" + "SELECT @@IDENTITY"; // Devuelve el último IDENTITY generado, en este caso el que se ingreso

            comando.Connection = conexion; // Se le pasa la conexión al atributo del objeto comando creado

            // Se le pasan los parámetros que recibirá por el objeto comando
            comando.Parameters.AddWithValue("@cod_entrenador", horasLabo.Cod_entrenador);
            comando.Parameters.AddWithValue("@dia_registrado_HL", horasLabo.Dia_regisHoraLabo);
            comando.Parameters.AddWithValue("@hora_inicio", horasLabo.Hora_inicio);
            comando.Parameters.AddWithValue("@hora_final", horasLabo.Hora_fin);

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

        public int Modificar(EntidadRegisHoraLabo horasLabo)
        {
            int filasAfectadas = -1;

            SqlConnection conexion = new SqlConnection(_cadenaConexion);

            SqlCommand comando = new SqlCommand();

            String sentencia =
                "UPDATE REGISTRO_HORAS_LABORADAS " +
                "SET COD_ENTRENADOR=@cod_entrenador, " +
                "DIA_REGISTRO_HORALABO = @dia_registrado_HL, " +
                "HORA_INICIO_REGISTRO_HORALABO = @hora_inicio, " +
                "HORA_FINAL_REGISTRO_HORALABO = @hora_final " +
                    " WHERE COD_REGISTRO_HORALABO=@cod_registro_HoraLabo";

            comando.CommandText = sentencia;
            comando.Connection = conexion;

            comando.Parameters.AddWithValue("@cod_registro_HoraLabo", horasLabo.Cod_regisHoraLabo);
            comando.Parameters.AddWithValue("@cod_entrenador", horasLabo.Cod_entrenador);
            comando.Parameters.AddWithValue("@dia_registrado_HL", horasLabo.Dia_regisHoraLabo);
            comando.Parameters.AddWithValue("@hora_inicio", horasLabo.Hora_inicio);
            comando.Parameters.AddWithValue("@hora_final", horasLabo.Hora_fin);

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
        public DataSet listarHorasLabo(string condicion, string orden)
        {
            DataSet tablaDS = new DataSet(); //Está tabla guardará las consultas SQL

            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adaptador; // Es el puente entre el DataSet y la BD

            string sentencia = "SELECT COD_REGISTRO_HORALABO, COD_ENTRENADOR, DIA_REGISTRO_HORALABO, HORA_INICIO_REGISTRO_HORALABO, HORA_FINAL_REGISTRO_HORALABO FROM REGISTRO_HORAS_LABORADAS";

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
                adaptador.Fill(tablaDS, "registro_horas_laboradas"); // La tabla DataSet creada anteriormente se rellena con lo devuelto de la consulta (sentencia)
            }
            catch (Exception)
            {
                throw;
            }
            return tablaDS;
        }
        #endregion

        #region Método para leer las tablas pero esta devuelve una lista, esta pueda ser más dinamica 

        public List<EntidadRegisHoraLabo> listarHorasLabo(String condicion)
        {
            List<EntidadRegisHoraLabo> listaHorasLabo; //Se inicializa lo que se creará
            DataSet TablaDS = new DataSet();

            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adaptador;

            string sentencia = "SELECT COD_REGISTRO_HORALABO, COD_ENTRENADOR, DIA_REGISTRO_HORALABO, HORA_INICIO_REGISTRO_HORALABO, HORA_FINAL_REGISTRO_HORALABO FROM REGISTRO_HORAS_LABORADAS";

            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = string.Format("{0} WHERE {1}", sentencia, condicion); //Format funciona para concatenar variables
            }

            try
            {
                adaptador = new SqlDataAdapter(sentencia, conexion); // Aquí se usa el adaptador para unirse BD 
                adaptador.Fill(TablaDS, "registro_horas_laboradas"); // Se llena el DataSer con la BD

                //***Sentencia linQ para convertir el DataSet en una lista 
                listaHorasLabo = (from DataRow fila in TablaDS.Tables["registro_horas_laboradas"].Rows
                                  select new EntidadRegisHoraLabo()
                                  {
                                      Cod_regisHoraLabo = (int)fila[0],
                                      Cod_entrenador = (int)fila[1],
                                      Dia_regisHoraLabo = Convert.ToDateTime(fila[2]),
                                      Hora_inicio = (TimeSpan)(fila[3]),
                                      Hora_fin = (TimeSpan)(fila[4]),
                                      Existe = true
                                  }).ToList();

                //Lo anterior convierte el DataSet en una lista, y cada elemento de la lista tiene Objeto Entidad que 
                //representa cada fila de la tabla de la BD;
            }
            catch (Exception)
            {
                throw;
            }

            return listaHorasLabo;
        }
        #endregion

        #region Método para obtener un registro

        // Devuelve una entidad porque permite tener solo un registro
        public EntidadRegisHoraLabo ObtenerIncapEvent(int cod_horasLabo)
        {
            EntidadRegisHoraLabo horasLabo = null; // Se inicaliza null porque lo puede devolver vacío

            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();

            SqlDataReader dataReader;
            // Para llenarlo se hace mediante un EXECUTE, permitiendo obtener datos de la base de datos

            string sentencia = string.Format("SELECT COD_REGISTRO_HORALABO, COD_ENTRENADOR, DIA_REGISTRO_HORALABO, HORA_INICIO_REGISTRO_HORALABO, HORA_FINAL_REGISTRO_HORALABO FROM REGISTRO_HORAS_LABORADAS WHERE COD_REGISTRO_HORALABO = {0}", cod_horasLabo);

            comando.Connection = conexion;
            comando.CommandText = sentencia;

            try
            {
                conexion.Open();
                // Lo que hace este método de comando es crear el dataReader con lo que se tiene arriba
                dataReader = comando.ExecuteReader();

                if (dataReader.HasRows)
                {
                    horasLabo = new EntidadRegisHoraLabo();
                    dataReader.Read();

                    //Obtiene el valor de cada columna
                    horasLabo.Cod_regisHoraLabo = dataReader.GetInt32(0); // Se convierte por ser un número
                    horasLabo.Cod_entrenador = dataReader.GetInt32(1); // Se convierte por ser un número                    
                    horasLabo.Dia_regisHoraLabo = dataReader.GetDateTime(2);
                    horasLabo.Hora_inicio = dataReader.GetTimeSpan(3);
                    horasLabo.Hora_fin = dataReader.GetTimeSpan(4);
                    horasLabo.Existe = true;
                }
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return horasLabo;
        }
        #endregion

        #region Método para eliminar un registro

        public int EliminarRegistro(int cod_horasLabo)
        {
            int filasEliminadas = 0;

            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();

            String sentencia = string.Format("DELETE FROM REGISTRO_HORAS_LABORADAS WHERE COD_REGISTRO_HORALABO= {0} ", cod_horasLabo);

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
