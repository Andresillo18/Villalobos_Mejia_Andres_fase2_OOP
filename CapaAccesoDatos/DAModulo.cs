using System;
using System.Data.SqlClient; // UTILIZAR ADO .NET
using System.Data; // Se utiliza para el acceso a datos
using System.Linq;
using System.Collections.Generic;
using CapaEntidades;

namespace CapaAccesoDatos
{
    public class DAModulo
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

        #region Método para ingresar un nuevo registro

        public int Insertar(EntidadModulo modulo)
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
            comando.Parameters.AddWithValue("@requesitos_modulo", modulo.Requesitos_modulo);


            //Esta sentencia y su inicialización de los parámetros es para poder actualizar la tabla de unión MODULOS_PROGRAMA***
            //string sentencia2 = "INSERT INTO MODULOS_PROGRAMA (COD_PROGRAMA, COD_MODULO)" + "VALUES (@cod_programa,  @cod_modulo)";
            //comando.Parameters.AddWithValue("@cod_programa", ModProg.Cod_programa);
            //comando.Parameters.AddWithValue("@cod_modulo", ModProg.Cod_modulo);

            //ModProg.IdentityGenerado = Convert.ToInt32(sentencia2);


            // La sentencia a alterar se guarda en el CommandText porque es la sentencia dado por el provedor
            comando.CommandText = sentencia;
            //comando.CommandText = sentencia2;

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

        public int Modificar(EntidadModulo modulo)
        {
            int filasAfectadas = -1;

            SqlConnection conexion = new SqlConnection(_cadenaConexion);

            SqlCommand comando = new SqlCommand();


            String sentencia =
                "UPDATE MODULOS " +
                "SET HORAS_DURACION_MODULO=@horas_duracion, " +
                    "REQUESITOS_MODULO=@requesitos WHERE COD_MODULO=@cod_modulo";

            //comando.Parameters.AddWithValue("@nombre", modulo.Nombre_modulo); ***No se actualiza el nombre por la creación de un Trigger en la BD

            comando.CommandText = sentencia;
            comando.Connection = conexion;

            comando.Parameters.AddWithValue("@horas_duracion", modulo.Horas_duracion);
            comando.Parameters.AddWithValue("@requesitos", modulo.Requesitos_modulo);
            comando.Parameters.AddWithValue("@cod_modulo", modulo.Cod_modulo);

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

        // Devuelve un DataSet con los registros, para mostrarlo en el DataGridView
        public DataSet listarModulos(string condicion, string orden)
        {
            DataSet tablaDS = new DataSet(); //Está tabla guardará las consultas SQL

            DataSet tablaDS2 = new DataSet();

            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adaptador; // Es el puente entre el DataSet y la BD

            string sentencia = "SELECT COD_MODULO, NOMBRE_MODULO, HORAS_DURACION_MODULO, REQUESITOS_MODULO FROM MODULOS";

            string sentencia2 = "SELECT COD_MODULO FROM MODULOS_PROGRAMA"; //**

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
                adaptador.Fill(tablaDS, "Modulos"); // La tabla DataSet creada anteriormente se rellena con lo devuelto de la consulta (sentencia)

                adaptador = new SqlDataAdapter(sentencia2, conexion);//***
                adaptador.Fill(tablaDS2, "Modulos_Programa");
            }
            catch (Exception)
            {
                throw;
            }
            return tablaDS;
        }
        #endregion

        #region Método para leer las tablas pero esta devuelve una lista, esta pueda ser más dinamica 

        public List<EntidadModulo> listarModulos(String condicion)
        {
            List<EntidadModulo> listaModulos; //Se inicializa lo que se creará
            DataSet TablaDS = new DataSet();

            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adaptador;

            string sentencia = "SELECT COD_MODULO, NOMBRE_MODULO, HORAS_DURACION_MODULO, REQUESITOS_MODULO FROM MODULOS";

            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = string.Format("{0} WHERE {1}", sentencia, condicion); //Format funciona para concatenar variables
            }

            try
            {
                adaptador = new SqlDataAdapter(sentencia, conexion); // Aquí se usa el adaptador para unirse BD 
                adaptador.Fill(TablaDS, "Modulos"); // Se llena el DataSer con la BD

                //***Sentencia linQ para convertir el DataSet en una lista 
                listaModulos = (from DataRow fila in TablaDS.Tables["Modulos"].Rows
                                  select new EntidadModulo()
                                  {
                                      Cod_modulo = (int)fila[0],
                                      Nombre_modulo= fila[1].ToString(),
                                      Horas_duracion= (int)fila[2],
                                      Requesitos_modulo= fila[3].ToString(),
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
        public EntidadModulo ObtenerModulo(int cod_modulo)
        {
            EntidadModulo modulo= null; // Se inicaliza null porque lo puede devolver vacío

            EntidadModulosPrograma modulo_programa = null;

            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();

            SqlDataReader dataReader;
            // Para llenarlo se hace mediante un EXECUTE, permitiendo obtener datos de la base de datos

            string sentencia = string.Format("SELECT COD_MODULO, NOMBRE_MODULO, HORAS_DURACION_MODULO, REQUESITOS_MODULO FROM MODULOS WHERE COD_MODULO = {0}", cod_modulo);

            comando.Connection = conexion;
            comando.CommandText = sentencia;

            try
            {
                conexion.Open();
                // Lo que hace este método de comando es crear el dataReader con lo que se tiene arriba
                dataReader = comando.ExecuteReader();

                if (dataReader.HasRows)
                {
                    modulo = new EntidadModulo();
                    dataReader.Read();

                    //Obtiene el valor de cada columna
                    modulo.Cod_modulo = dataReader.GetInt32(0); // Se convierte por ser un número
                    modulo.Nombre_modulo = dataReader.GetString(1);
                    modulo.Horas_duracion = dataReader.GetInt16(2);
                    modulo.Requesitos_modulo = dataReader.GetString(3);
                    modulo.Existe = true;
                }
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return modulo;
        }
        #endregion

        #region Método para eliminar un registro

        public int EliminarRegistro(int cod_modulo)
        {
            int filasEliminadas = 0;

            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();

            String sentencia = string.Format("DELETE FROM MODULOS WHERE cod_modulo= {0} ", cod_modulo);

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
