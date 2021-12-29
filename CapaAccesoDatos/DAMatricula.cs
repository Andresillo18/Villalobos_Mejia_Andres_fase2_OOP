using System;
using System.Data.SqlClient; // UTILIZAR ADO .NET
using System.Data; // Se utiliza para el acceso a datos
using System.Linq;
using System.Collections.Generic;
using CapaEntidades;

namespace CapaAccesoDatos
{
    class DAMatricula
    {
        #region Atributos

        private string _cadenaConexion;

        #endregion

        #region Propiedades

        public string CadenaConexion { get => _cadenaConexion; set => _cadenaConexion = value; }

        #endregion

        #region Constructores

        public DAMatricula(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
        }

        public DAMatricula()
        {
            _cadenaConexion = String.Empty;
        }

        #endregion

        #region Método para ingresar un nuevo registro

        public int Insertar(EntidadModAbier modAbierto)
        {
            int cod = 0; // El retorno

            // Siempre se debe hacer un objeto para usar la cadena de conexion
            SqlConnection conexion = new SqlConnection(_cadenaConexion);

            // El command es el que tiene casi todos los necesario para leer los comandos SQL
            SqlCommand comando = new SqlCommand();

            //Se le debe asignar lo que será añadido o modificado en la base de datos con esta sentencia
            //Se debe hacer como si fuera en la misma, se puede hacer todo junto sin concatenar
            string sentencia = "INSERT INTO MODULOS_ABIERTOS (COD_ENTRENADOR, COD_MODULO,COD_HORARIO_MODULOS,FECHA_INICIO_MODULO,OBSERVACIONES_MODULO_ABIERTO)" + " VALUES (@cod_entrenador,  @cod_mod, @cod_horar_mod, @fecha_inicio, @observaciones)" + "SELECT @@IDENTITY"; // Devuelve el último IDENTITY generado, en este caso el que se ingreso

            comando.Connection = conexion; // Se le pasa la conexión al atributo del objeto comando creado

            // Se le pasan los parámetros que recibirá por el objeto comando
            comando.Parameters.AddWithValue("@cod_entrenador", modAbierto.Cod_entrenador);
            comando.Parameters.AddWithValue("@cod_mod", modAbierto.Cod_mod);
            comando.Parameters.AddWithValue("@cod_horar_mod", modAbierto.Cod_hora_mod);
            comando.Parameters.AddWithValue("@fecha_inicio", modAbierto.Fecha_inicio);
            comando.Parameters.AddWithValue("@observaciones", modAbierto.Observaciones);

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

        public int Modificar(EntidadModAbier modAbierto)
        {
            int filasAfectadas = -1;

            SqlConnection conexion = new SqlConnection(_cadenaConexion);

            SqlCommand comando = new SqlCommand();

            String sentencia =
                "UPDATE MODULOS_ABIERTOS " +
                "SET COD_ENTRENADOR=@cod_entrenador, " +
                "COD_MODULO = @cod_mod, " +
                "COD_HORARIO_MODULOS = @cod_horar_mod, " +
                "FECHA_INICIO_MODULO = @fecha_inicio, " +
                    "OBSERVACIONES_MODULO_ABIERTO=@observaciones" +
                    " WHERE COD_MODULO_ABIERTO=@cod_modAbier";

            comando.CommandText = sentencia;
            comando.Connection = conexion;

            comando.Parameters.AddWithValue("@cod_entrenador", modAbierto.Cod_entrenador);
            comando.Parameters.AddWithValue("@cod_mod", modAbierto.Cod_mod);
            comando.Parameters.AddWithValue("@cod_horar_mod", modAbierto.Cod_hora_mod);
            comando.Parameters.AddWithValue("@fecha_inicio", modAbierto.Fecha_inicio);
            comando.Parameters.AddWithValue("@observaciones", modAbierto.Observaciones);
            comando.Parameters.AddWithValue("@cod_modAbier", modAbierto.Cod_mod_abierto);

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
        public DataSet listarModulo(string condicion, string orden)
        {
            DataSet tablaDS = new DataSet(); //Está tabla guardará las consultas SQL

            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adaptador; // Es el puente entre el DataSet y la BD

            string sentencia = "SELECT COD_MODULO_ABIERTO, COD_ENTRENADOR, COD_MODULO, COD_HORARIO_MODULOS, FECHA_INICIO_MODULO,FECHA_FINAL_MODULO, OBSERVACIONES_MODULO_ABIERTO  FROM MODULOS_ABIERTOS";

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
                adaptador.Fill(tablaDS, "ModulosAbiertos"); // La tabla DataSet creada anteriormente se rellena con lo devuelto de la consulta (sentencia)
            }
            catch (Exception)
            {
                throw;
            }
            return tablaDS;
        }
        #endregion

        #region Método para leer las tablas pero esta devuelve una lista, esta pueda ser más dinamica 

        public List<EntidadModAbier> listarModulo(String condicion)
        {
            List<EntidadModAbier> listaModulos; //Se inicializa lo que se creará
            DataSet TablaDS = new DataSet();

            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adaptador;

            string sentencia = "SELECT COD_MODULO_ABIERTO, COD_ENTRENADOR, COD_MODULO, COD_HORARIO_MODULOS, FECHA_INICIO_MODULO,FECHA_FINAL_MODULO, OBSERVACIONES_MODULO_ABIERTO  FROM MODULOS_ABIERTOS";

            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = string.Format("{0} WHERE {1}", sentencia, condicion); //Format funciona para concatenar variables
            }

            try
            {
                adaptador = new SqlDataAdapter(sentencia, conexion); // Aquí se usa el adaptador para unirse BD 
                adaptador.Fill(TablaDS, "ModulosAbiertos"); // Se llena el DataSer con la BD

                //***Sentencia linQ para convertir el DataSet en una lista 
                listaModulos = (from DataRow fila in TablaDS.Tables["ModulosAbiertos"].Rows
                                select new EntidadModAbier()
                                {
                                    Cod_mod_abierto = (int)fila[0],
                                    Cod_entrenador = (int)fila[1],
                                    Cod_mod = (int)fila[2],
                                    Cod_hora_mod = (int)fila[3],
                                    Fecha_inicio = Convert.ToDateTime(fila[4]),
                                    Fecha_fin = Convert.ToDateTime(fila[5]),
                                    Observaciones = fila[6].ToString(),
                                    Existe = true
                                }).ToList();

                //Lo anterior convierte el DataSet en una lista, y cada elemento de la lista tiene Objeto Entidad que 
                //representa cada fila de la tabla de la BD;
            }
            catch (Exception)
            {
                throw;
            }

            return listaModulos;
        }
        #endregion

        #region Método para obtener un registro

        // Devuelve una entidad porque permite tener solo un registro
        public EntidadModAbier ObtenerModulo(int cod_moduloAbierto)
        {
            EntidadModAbier moduloAbierto = null; // Se inicaliza null porque lo puede devolver vacío

            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();

            SqlDataReader dataReader;
            // Para llenarlo se hace mediante un EXECUTE, permitiendo obtener datos de la base de datos

            string sentencia = string.Format("SELECT COD_MODULO_ABIERTO, COD_ENTRENADOR, COD_MODULO, COD_HORARIO_MODULOS, FECHA_INICIO_MODULO,FECHA_FINAL_MODULO, OBSERVACIONES_MODULO_ABIERTO  FROM MODULOS_ABIERTOS WHERE COD_MODULO_ABIERTO = {0}", cod_moduloAbierto);

            comando.Connection = conexion;
            comando.CommandText = sentencia;

            try
            {
                conexion.Open();
                // Lo que hace este método de comando es crear el dataReader con lo que se tiene arriba
                dataReader = comando.ExecuteReader();

                if (dataReader.HasRows)
                {
                    moduloAbierto = new EntidadModAbier();
                    dataReader.Read();

                    //Obtiene el valor de cada columna
                    moduloAbierto.Cod_mod_abierto = dataReader.GetInt32(0); // Se convierte por ser un número
                    moduloAbierto.Cod_entrenador = dataReader.GetInt32(1);
                    moduloAbierto.Cod_mod = dataReader.GetInt32(2);
                    moduloAbierto.Cod_hora_mod = dataReader.GetInt32(3);
                    moduloAbierto.Fecha_inicio = dataReader.GetDateTime(4);
                    moduloAbierto.Fecha_fin = dataReader.GetDateTime(5);
                    if (dataReader[6] != DBNull.Value)
                    {
                        moduloAbierto.Observaciones = dataReader.GetString(6); // Si esa posición de dataReader tiene algo que se ejecute el proceso
                    }

                    moduloAbierto.Existe = true;
                }
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return moduloAbierto;
        }
        #endregion

        #region Método para eliminar un registro

        public int EliminarRegistro(int cod_moduloAbierto)
        {
            int filasEliminadas = 0;

            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();

            String sentencia = string.Format("DELETE FROM MODULOS_ABIERTOS WHERE COD_MODULO_ABIERTO= {0} ", cod_moduloAbierto);

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
