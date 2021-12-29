using System;
using System.Data.SqlClient; // UTILIZAR ADO .NET
using System.Data; // Se utiliza para el acceso a datos
using System.Linq;
using System.Collections.Generic;
using CapaEntidades;

namespace CapaAccesoDatos
{
    public class DA_Atleta
    {
        #region Atributos

        private string _cadenaConexion;

        #endregion

        #region Propiedades

        public string CadenaConexion { get => _cadenaConexion; set => _cadenaConexion = value; }

        #endregion

        #region Constructores

        public DA_Atleta(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
        }

        public DA_Atleta()
        {
            _cadenaConexion = String.Empty;
        }

        #endregion

        #region Método para ingresar un nuevo registro

        public int Insertar(EntidadAtleta atleta)
        {
            int cod = 0; // El retorno

            // Siempre se debe hacer un objeto para usar la cadena de conexion
            SqlConnection conexion = new SqlConnection(_cadenaConexion);

            // El command es el que tiene casi todos los necesario para leer los comandos SQL
            SqlCommand comando = new SqlCommand();

            //Se le debe asignar lo que será añadido o modificado en la base de datos con esta sentencia
            //Se debe hacer como si fuera en la misma, se puede hacer todo junto sin concatenar
            string sentencia = "INSERT INTO ATLETAS (ID_ATLETA, NOMBRE_ATLETA, APELLIDO1_ATLETA, APELLIDO2_ATLETA, TELEFONO1_ATLETA, TELEFONO2_ATLETA, GENERO,PROVINCIA_ATLETA, DISTRITO_ATLETA, CANTON_ATLETA, FECHA_NACIMIENTO_ATLETA, ESTADO_ATLETA)" + " VALUES (@id_atleta,  @nombre_atleta, @apellido1, @apellido2, @telefono1, @telefono2,@genero, @provincia, @distrito,@canton,@fecha_nacimiento ,@estado)" + "SELECT @@IDENTITY"; // Devuelve el último IDENTITY generado, en este caso el que se ingreso

            comando.Connection = conexion; // Se le pasa la conexión al atributo del objeto comando creado

            // Se le pasan los parámetros que recibirá por el objeto comando
            comando.Parameters.AddWithValue("@id_atleta", atleta.Identificacion);
            comando.Parameters.AddWithValue("@nombre_atleta", atleta.Nombre);
            comando.Parameters.AddWithValue("@apellido1", atleta.Apellido1);
            comando.Parameters.AddWithValue("@apellido2", atleta.Apellido2);
            comando.Parameters.AddWithValue("@telefono1", atleta.Telefono1);
            comando.Parameters.AddWithValue("@telefono2", atleta.Telefono2);
            comando.Parameters.AddWithValue("@genero", atleta.Genero);
            comando.Parameters.AddWithValue("@provincia", atleta.Provincia);
            comando.Parameters.AddWithValue("@distrito", atleta.Distrito);
            comando.Parameters.AddWithValue("@canton", atleta.Canton);
            comando.Parameters.AddWithValue("@fecha_nacimiento", atleta.Fecha_nacimiento);
            comando.Parameters.AddWithValue("@estado", atleta.Estado);

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

        public int Modificar(EntidadAtleta atleta)
        {
            int filasAfectadas = -1;

            SqlConnection conexion = new SqlConnection(_cadenaConexion);

            SqlCommand comando = new SqlCommand();

            String sentencia =
                "UPDATE ATLETAS " +
                "SET NOMBRE_ATLETA = @nombre_atleta, " +
                "APELLIDO1_ATLETA = @apellido1, " +
                "APELLIDO2_ATLETA = @apellido2, " +
                "TELEFONO1_ATLETA = @telefono1, " +
                "TELEFONO2_ATLETA = @telefono2, " +
                "GENERO = @genero, " +
                "PROVINCIA_ATLETA = @provincia, " +
                "DISTRITO_ATLETA = @distrito, " +
                "CANTON_ATLETA = @canton, " +
                "FECHA_NACIMIENTO_ATLETA = @fecha_nacimiento, " +
                    "ESTADO_ATLETA=@estado" +
                    " WHERE COD_ATLETA = @cod_atleta";

            comando.CommandText = sentencia;
            comando.Connection = conexion;

            comando.Parameters.AddWithValue("@cod_atleta", atleta.Cod_atleta);
            //comando.Parameters.AddWithValue("@id_atleta", atleta.Identificacion);
            comando.Parameters.AddWithValue("@nombre_atleta", atleta.Nombre);
            comando.Parameters.AddWithValue("@apellido1", atleta.Apellido1);
            comando.Parameters.AddWithValue("@apellido2", atleta.Apellido2);
            comando.Parameters.AddWithValue("@telefono1", atleta.Telefono1);
            comando.Parameters.AddWithValue("@telefono2", atleta.Telefono2);
            comando.Parameters.AddWithValue("@genero", atleta.Genero);
            comando.Parameters.AddWithValue("@provincia", atleta.Provincia);
            comando.Parameters.AddWithValue("@distrito", atleta.Distrito);
            comando.Parameters.AddWithValue("@canton", atleta.Canton);
            comando.Parameters.AddWithValue("@fecha_nacimiento", atleta.Fecha_nacimiento);
            comando.Parameters.AddWithValue("@estado", atleta.Estado);

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
        public DataSet listarAtletas(string condicion, string orden)
        {
            DataSet tablaDS = new DataSet(); //Está tabla guardará las consultas SQL

            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adaptador; // Es el puente entre el DataSet y la BD

            String sentencia = "SELECT COD_ATLETA,ID_ATLETA, NOMBRE_ATLETA, APELLIDO1_ATLETA, APELLIDO2_ATLETA, TELEFONO1_ATLETA, TELEFONO2_ATLETA, GENERO,PROVINCIA_ATLETA, DISTRITO_ATLETA, CANTON_ATLETA, FECHA_NACIMIENTO_ATLETA, ESTADO_ATLETA FROM ATLETAS";

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
                adaptador.Fill(tablaDS, "atletas"); // La tabla DataSet creada anteriormente se rellena con lo devuelto de la consulta (sentencia)
            }
            catch (Exception)
            {
                throw;
            }
            return tablaDS;
        }
        #endregion

        #region Método para leer las tablas pero esta devuelve una lista, esta pueda ser más dinamica 

        public List<EntidadAtleta> listarAtletas(String condicion)
        {
            List<EntidadAtleta> listaAtletas; //Se inicializa lo que se creará
            DataSet TablaDS = new DataSet();

            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adaptador;

            String sentencia = "SELECT COD_ATLETA,ID_ATLETA, NOMBRE_ATLETA, APELLIDO1_ATLETA, APELLIDO2_ATLETA, TELEFONO1_ATLETA, TELEFONO2_ATLETA, GENERO,PROVINCIA_ATLETA, DISTRITO_ATLETA, CANTON_ATLETA, FECHA_NACIMIENTO_ATLETA, ESTADO_ATLETA FROM ATLETAS";

            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = string.Format("{0} WHERE {1}", sentencia, condicion); //Format funciona para concatenar variables
            }

            try
            {
                adaptador = new SqlDataAdapter(sentencia, conexion); // Aquí se usa el adaptador para unirse BD 
                adaptador.Fill(TablaDS, "atletas"); // Se llena el DataSer con la BD

                //***Sentencia linQ para convertir el DataSet en una lista 
                listaAtletas = (from DataRow fila in TablaDS.Tables["atletas"].Rows
                                select new EntidadAtleta()
                                {
                                    Cod_atleta = (int)fila[0],
                                    Identificacion = fila[1].ToString(),
                                    Nombre = fila[2].ToString(),
                                    Apellido1 = fila[3].ToString(),
                                    Apellido2 = fila[4].ToString(),
                                    Telefono1 = fila[5].ToString(),
                                    Telefono2 = fila[6].ToString(),
                                    Genero = fila[7].ToString(),
                                    Provincia = fila[8].ToString(),
                                    Distrito = fila[9].ToString(),
                                    Canton = fila[10].ToString(),
                                    Fecha_nacimiento = Convert.ToDateTime(fila[11]),
                                    Estado = true
                                }).ToList();

                //Lo anterior convierte el DataSet en una lista, y cada elemento de la lista tiene Objeto Entidad que 
                //representa cada fila de la tabla de la BD;
            }
            catch (Exception)
            {
                throw;
            }

            return listaAtletas;
        }
        #endregion

        #region Método para obtener un registro

        // Devuelve una entidad porque permite tener solo un registro
        public EntidadAtleta ObtenerAtleta(int cod_atleta)
        {
            EntidadAtleta atletaActivo = null; // Se inicaliza null porque lo puede devolver vacío

            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();

            SqlDataReader dataReader;
            // Para llenarlo se hace mediante un EXECUTE, permitiendo obtener datos de la base de datos

            string sentencia = string.Format("SELECT COD_ATLETA,ID_ATLETA, NOMBRE_ATLETA, APELLIDO1_ATLETA, APELLIDO2_ATLETA, TELEFONO1_ATLETA, TELEFONO2_ATLETA, GENERO,PROVINCIA_ATLETA, DISTRITO_ATLETA, CANTON_ATLETA, FECHA_NACIMIENTO_ATLETA, ESTADO_ATLETA FROM ATLETAS WHERE COD_ATLETA = {0}", cod_atleta);

            comando.Connection = conexion;
            comando.CommandText = sentencia;

            try
            {
                conexion.Open();
                // Lo que hace este método de comando es crear el dataReader con lo que se tiene arriba
                dataReader = comando.ExecuteReader();

                if (dataReader.HasRows)
                {
                    atletaActivo = new EntidadAtleta();
                    dataReader.Read();

                    //Obtiene el valor de cada columna
                    atletaActivo.Cod_atleta = dataReader.GetInt32(0); // Se convierte por ser un número
                    atletaActivo.Identificacion = dataReader.GetString(1);
                    atletaActivo.Nombre = dataReader.GetString(2);
                    atletaActivo.Apellido1 = dataReader.GetString(3);
                    atletaActivo.Apellido2 = dataReader.GetString(4);
                    atletaActivo.Telefono1 = dataReader.GetString(5);
                    if (dataReader[6] != DBNull.Value)
                    {
                        atletaActivo.Telefono2 = dataReader.GetString(6); // Si esa posición de dataReader tiene algo que se ejecute el proceso
                    }
                    atletaActivo.Genero = dataReader.GetString(7);
                    atletaActivo.Provincia = dataReader.GetString(8);
                    atletaActivo.Distrito = dataReader.GetString(9);
                    atletaActivo.Canton = dataReader.GetString(10);
                    atletaActivo.Fecha_nacimiento = dataReader.GetDateTime(11);
                    atletaActivo.Estado = true;
                }
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return atletaActivo;
        }
        #endregion

        #region Método para eliminar un registro

        public int EliminarRegistro(int cod_atleta)
        {
            int filasEliminadas = 0;

            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();

            String sentencia = string.Format("DELETE FROM ATLETAS WHERE COD_ATLETA= {0} ", cod_atleta);

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
