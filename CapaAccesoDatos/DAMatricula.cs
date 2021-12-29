using System;
using System.Data.SqlClient; // UTILIZAR ADO .NET
using System.Data; // Se utiliza para el acceso a datos
using System.Linq;
using System.Collections.Generic;
using CapaEntidades;

namespace CapaAccesoDatos
{
    public class DAMatricula
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

        public int Insertar(EntidadMatricula matricula)
        {
            int cod = 0; // El retorno

            // Siempre se debe hacer un objeto para usar la cadena de conexion
            SqlConnection conexion = new SqlConnection(_cadenaConexion);

            // El command es el que tiene casi todos los necesario para leer los comandos SQL
            SqlCommand comando = new SqlCommand();

            //Se le debe asignar lo que será añadido o modificado en la base de datos con esta sentencia
            //Se debe hacer como si fuera en la misma, se puede hacer todo junto sin concatenar
            string sentencia = "INSERT INTO MATRICULAS (COD_ATLETA, COD_MODULO_ABIERTO, FECHA_MATRICULA, ESTADO, NOTA_FINAL, MONTO_CANCELADO, TIPO_COBRO, TIPO_PAGO)" + " VALUES (@cod_atleta, @cod_mod_abierto, @fecha_matricula, @estado, @nota_final, @monto_cancelado, @tipo_cobro, @tipo_pago)" + "SELECT @@IDENTITY"; // Devuelve el último IDENTITY generado, en este caso el que se ingreso

            comando.Connection = conexion; // Se le pasa la conexión al atributo del objeto comando creado

            // Se le pasan los parámetros que recibirá por el objeto comando
            comando.Parameters.AddWithValue("@cod_atleta", matricula.Cod_atleta);
            comando.Parameters.AddWithValue("@cod_mod_abierto", matricula.Cod_mod_abierto);
            comando.Parameters.AddWithValue("@fecha_matricula", matricula.Fecha_matri);
            comando.Parameters.AddWithValue("@estado", matricula.Estado);
            comando.Parameters.AddWithValue("@nota_final", matricula.Nota_final);
            comando.Parameters.AddWithValue("@monto_cancelado", matricula.Monto_cancelado);
            comando.Parameters.AddWithValue("@tipo_cobro", matricula.Tipo_cobro);
            comando.Parameters.AddWithValue("@tipo_pago", matricula.Tipo_pago);

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

        public int Modificar(EntidadMatricula matricula)
        {
            int filasAfectadas = -1;

            SqlConnection conexion = new SqlConnection(_cadenaConexion);

            SqlCommand comando = new SqlCommand();

            String sentencia =
                "UPDATE MATRICULAS " +
                "SET COD_ATLETA=@cod_atleta, " +
                "COD_MODULO_ABIERTO = @cod_mod_abierto, " +
                "FECHA_MATRICULA = @fecha_matricula, " +
                "ESTADO = @estado, " +
                "NOTA_FINAL=@nota_final, " +
                "MONTO_CANCELADO = @monto_cancelado, " +
                "TIPO_COBRO = @tipo_cobro, " +
                "TIPO_PAGO = @tipo_pago " +
                    " WHERE COD_MATRICULA=@cod_matricula";

            comando.CommandText = sentencia;
            comando.Connection = conexion;

            comando.Parameters.AddWithValue("@cod_matricula", matricula.Cod_matricula);
            comando.Parameters.AddWithValue("@cod_atleta", matricula.Cod_atleta);
            comando.Parameters.AddWithValue("@cod_mod_abierto", matricula.Cod_mod_abierto);
            comando.Parameters.AddWithValue("@fecha_matricula", matricula.Fecha_matri);
            comando.Parameters.AddWithValue("@estado", matricula.Estado);
            comando.Parameters.AddWithValue("@nota_final", matricula.Nota_final);
            comando.Parameters.AddWithValue("@monto_cancelado", matricula.Monto_cancelado);
            comando.Parameters.AddWithValue("@tipo_cobro", matricula.Tipo_cobro);
            comando.Parameters.AddWithValue("@tipo_pago", matricula.Tipo_pago);

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
        public DataSet listarMatricula(string condicion, string orden)
        {
            DataSet tablaDS = new DataSet(); //Está tabla guardará las consultas SQL

            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adaptador; // Es el puente entre el DataSet y la BD

            string sentencia = "SELECT COD_MATRICULA, COD_ATLETA, COD_MODULO_ABIERTO, FECHA_MATRICULA, ESTADO, NOTA_FINAL, MONTO_CANCELADO, TIPO_COBRO, TIPO_PAGO FROM MATRICULAS";

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
                adaptador.Fill(tablaDS, "matriculas"); // La tabla DataSet creada anteriormente se rellena con lo devuelto de la consulta (sentencia)
            }
            catch (Exception)
            {
                throw;
            }
            return tablaDS;
        }
        #endregion

        #region Método para leer las tablas pero esta devuelve una lista, esta pueda ser más dinamica 

        public List<EntidadMatricula> listarMatricula(String condicion)
        {
            List<EntidadMatricula> listaMatriculas; //Se inicializa lo que se creará
            DataSet TablaDS = new DataSet();

            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adaptador;

            string sentencia = "SELECT COD_MATRICULA, COD_ATLETA, COD_MODULO_ABIERTO, FECHA_MATRICULA, ESTADO, NOTA_FINAL, MONTO_CANCELADO, TIPO_COBRO, TIPO_PAGO FROM MATRICULAS";

            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = string.Format("{0} WHERE {1}", sentencia, condicion); //Format funciona para concatenar variables
            }

            try
            {
                adaptador = new SqlDataAdapter(sentencia, conexion); // Aquí se usa el adaptador para unirse BD 
                adaptador.Fill(TablaDS, "matriculas"); // Se llena el DataSer con la BD

                //***Sentencia linQ para convertir el DataSet en una lista 
                listaMatriculas = (from DataRow fila in TablaDS.Tables["matriculas"].Rows
                                select new EntidadMatricula()
                                {
                                    Cod_matricula = (int)fila[0],
                                    Cod_atleta= (int)fila[1],
                                    Cod_mod_abierto= (int)fila[2],
                                    Fecha_matri = Convert.ToDateTime(fila[3]),
                                    Estado= fila[4].ToString(),
                                    Nota_final = (decimal)fila[5],
                                    Monto_cancelado = (int)fila[6],
                                    Tipo_cobro= fila[7].ToString(),
                                    Tipo_pago= fila[8].ToString(),
                                    Actividad = true
                                }).ToList();

                //Lo anterior convierte el DataSet en una lista, y cada elemento de la lista tiene Objeto Entidad que 
                //representa cada fila de la tabla de la BD;
            }
            catch (Exception)
            {
                throw;
            }

            return listaMatriculas;
        }
        #endregion

        #region Método para obtener un registro

        // Devuelve una entidad porque permite tener solo un registro
        public EntidadMatricula ObtenerMatricula(int cod_matricula)
        {
            EntidadMatricula matricula= null; // Se inicaliza null porque lo puede devolver vacío

            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();

            SqlDataReader dataReader;
            // Para llenarlo se hace mediante un EXECUTE, permitiendo obtener datos de la base de datos

            string sentencia = string.Format("SELECT COD_MATRICULA, COD_ATLETA, COD_MODULO_ABIERTO, FECHA_MATRICULA, ESTADO, NOTA_FINAL, MONTO_CANCELADO, TIPO_COBRO, TIPO_PAGO FROM MATRICULAS WHERE COD_MATRICULA = {0}", cod_matricula);

            comando.Connection = conexion;
            comando.CommandText = sentencia;

            try
            {
                conexion.Open();
                // Lo que hace este método de comando es crear el dataReader con lo que se tiene arriba
                dataReader = comando.ExecuteReader();

                if (dataReader.HasRows)
                {
                    matricula = new EntidadMatricula();
                    dataReader.Read();

                    //Obtiene el valor de cada columna
                    matricula.Cod_matricula= dataReader.GetInt32(0); // Se convierte por ser un número
                    matricula.Cod_atleta= dataReader.GetInt32(1);
                    matricula.Cod_mod_abierto = dataReader.GetInt32(2);
                    matricula.Fecha_matri = dataReader.GetDateTime(3);
                    matricula.Estado= dataReader.GetString(4);
                    if (dataReader[5] != DBNull.Value)
                    {
                        matricula.Nota_final = dataReader.GetDecimal(5);
                    }
                    matricula.Monto_cancelado= dataReader.GetInt32(6);
                    matricula.Tipo_cobro= dataReader.GetString(7);
                    matricula.Tipo_pago= dataReader.GetString(8);                    

                    matricula.Actividad= true;
                }
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return matricula;
        }
        #endregion

        #region Método para eliminar un registro

        public int EliminarRegistro(int cod_matricula)
        {
            int filasEliminadas = 0;

            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();

            String sentencia = string.Format("DELETE FROM MATRICULAS WHERE COD_MATRICULA= {0} ", cod_matricula);

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
