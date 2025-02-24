﻿using System;
using System.Data.SqlClient; // UTILIZAR ADO .NET
using System.Data; // Se utiliza para el acceso a datos
using System.Linq;
using System.Collections.Generic;
using CapaEntidades;

namespace CapaAccesoDatos
{
    public class DAHorarEntrenador
    {
        #region Atributos

        private string _cadenaConexion;

        #endregion

        #region Propiedades

        public string CadenaConexion { get => _cadenaConexion; set => _cadenaConexion = value; }

        #endregion

        #region Constructores

        public DAHorarEntrenador(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
        }

        public DAHorarEntrenador()
        {
            _cadenaConexion = String.Empty;
        }

        #endregion

        #region Método para ingresar un nuevo registro

        public int Insertar(EntidadHorarEntrenador horarEntrenador)
        {
            int cod = 0; // El retorno

            // Siempre se debe hacer un objeto para usar la cadena de conexion
            SqlConnection conexion = new SqlConnection(_cadenaConexion);

            // El command es el que tiene casi todos los necesario para leer los comandos SQL
            SqlCommand comando = new SqlCommand();

            //Se le debe asignar lo que será añadido o modificado en la base de datos con esta sentencia
            //Se debe hacer como si fuera en la misma, se puede hacer todo junto sin concatenar
            string sentencia = "INSERT INTO HORARIO_ENTRENADORES ( COD_ENTRENADOR, DIA_LUNES,DIA_MARTES,DIA_MIERCOLES,DIA_JUEVES, DIA_VIERNES, DIA_SABADO, DIA_DOMINGO, HORA_INICIO_HORARIO, HORA_FIN_HORARIO)" + " VALUES (@cod_entrenador, @dia_lunes, @dia_martes, @dia_miercoles, @dia_jueves, @dia_viernes, @dia_sabado, @dia_domingo, @hora_inicio,@hora_fin)" + "SELECT @@IDENTITY"; // Devuelve el último IDENTITY generado, en este caso el que se ingreso

            comando.Connection = conexion; // Se le pasa la conexión al atributo del objeto comando creado

            // Se le pasan los parámetros que recibirá por el objeto comando
            comando.Parameters.AddWithValue("@cod_entrenador", horarEntrenador.Cod_entrenador);
            comando.Parameters.AddWithValue("@dia_lunes", horarEntrenador.Dia_lunes);
            comando.Parameters.AddWithValue("@dia_martes", horarEntrenador.Dia_martes);
            comando.Parameters.AddWithValue("@dia_miercoles", horarEntrenador.Dia_miercoles);
            comando.Parameters.AddWithValue("@dia_jueves", horarEntrenador.Dia_jueves);
            comando.Parameters.AddWithValue("@dia_viernes", horarEntrenador.Dia_viernes);
            comando.Parameters.AddWithValue("@dia_sabado", horarEntrenador.Dia_sabado);
            comando.Parameters.AddWithValue("@dia_domingo", horarEntrenador.Dia_domingo);
            comando.Parameters.AddWithValue("@hora_inicio", horarEntrenador.Hora_inicio);
            comando.Parameters.AddWithValue("@hora_fin", horarEntrenador.Hora_fin);

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

        public int Modificar(EntidadHorarEntrenador horarEntrenador)
        {
            int filasAfectadas = -1;

            SqlConnection conexion = new SqlConnection(_cadenaConexion);

            SqlCommand comando = new SqlCommand();

            String sentencia =
                "UPDATE HORARIO_ENTRENADORES " +
                "SET DIA_LUNES=@dia_lunes, " +
                "DIA_MARTES = @dia_martes, " +
                "DIA_MIERCOLES = @dia_miercoles, " +
                "DIA_JUEVES = @dia_jueves, " +
                    "DIA_VIERNES=@dia_viernes," +
                    "DIA_SABADO=@dia_sabado," +
                    "DIA_DOMINGO=@dia_domingo," +
                    "HORA_INICIO_HORARIO=@hora_inicio," +
                    "HORA_FIN_HORARIO=@hora_fin" +
                    " WHERE COD_HORARIO_ENTRENADOR=@cod_horarEntrenador";

            comando.CommandText = sentencia;
            comando.Connection = conexion;

            comando.Parameters.AddWithValue("@cod_horarEntrenador", horarEntrenador.Cod_Horario_entrenador);
            comando.Parameters.AddWithValue("@dia_lunes", horarEntrenador.Dia_lunes);
            comando.Parameters.AddWithValue("@dia_martes", horarEntrenador.Dia_martes);
            comando.Parameters.AddWithValue("@dia_miercoles", horarEntrenador.Dia_miercoles);
            comando.Parameters.AddWithValue("@dia_jueves", horarEntrenador.Dia_jueves);
            comando.Parameters.AddWithValue("@dia_viernes", horarEntrenador.Dia_viernes);
            comando.Parameters.AddWithValue("@dia_sabado", horarEntrenador.Dia_sabado);
            comando.Parameters.AddWithValue("@dia_domingo", horarEntrenador.Dia_domingo);
            comando.Parameters.AddWithValue("@hora_inicio", horarEntrenador.Hora_inicio);
            comando.Parameters.AddWithValue("@hora_fin", horarEntrenador.Hora_fin);

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
        public DataSet listarHorarios(string condicion, string orden)
        {
            DataSet tablaDS = new DataSet(); //Está tabla guardará las consultas SQL

            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adaptador; // Es el puente entre el DataSet y la BD

            string sentencia = "SELECT COD_HORARIO_ENTRENADOR, COD_ENTRENADOR , DIA_LUNES, DIA_MARTES, DIA_MIERCOLES, DIA_JUEVES,DIA_VIERNES, DIA_SABADO, DIA_DOMINGO, HORA_INICIO_HORARIO, HORA_FIN_HORARIO FROM HORARIO_ENTRENADORES";

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
                adaptador.Fill(tablaDS, "HorarEntrenador"); // La tabla DataSet creada anteriormente se rellena con lo devuelto de la consulta (sentencia)
            }
            catch (Exception)
            {
                throw;
            }
            return tablaDS;
        }
        #endregion

        #region Método para leer las tablas pero esta devuelve una lista, esta pueda ser más dinamica 

        public List<EntidadHorarEntrenador> listarHorarios(String condicion)
        {
            List<EntidadHorarEntrenador> listaHorarios; //Se inicializa lo que se creará
            DataSet TablaDS = new DataSet();

            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adaptador;

            string sentencia = "SELECT COD_HORARIO_ENTRENADOR, COD_ENTRENADOR, DIA_LUNES, DIA_MARTES, DIA_MIERCOLES, DIA_JUEVES,DIA_VIERNES, DIA_SABADO, DIA_DOMINGO, HORA_INICIO_HORARIO, HORA_FIN_HORARIO FROM HORARIO_ENTRENADORES";

            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = string.Format("{0} WHERE {1}", sentencia, condicion); //Format funciona para concatenar variables
            }

            try
            {
                adaptador = new SqlDataAdapter(sentencia, conexion); // Aquí se usa el adaptador para unirse BD 
                adaptador.Fill(TablaDS, "HorarioMod"); // Se llena el DataSer con la BD

                //***Sentencia linQ para convertir el DataSet en una lista 
                listaHorarios = (from DataRow fila in TablaDS.Tables["HorarioMod"].Rows
                                select new EntidadHorarEntrenador()
                                {
                                    Cod_Horario_entrenador = (int)fila[0],
                                    Cod_entrenador = (int)fila[1],
                                    Dia_lunes = Convert.ToBoolean(fila[2]),
                                    Dia_martes = Convert.ToBoolean(fila[3]),
                                    Dia_miercoles = Convert.ToBoolean(fila[4]),
                                    Dia_jueves = Convert.ToBoolean(fila[5]),
                                    Dia_viernes = Convert.ToBoolean(fila[6]),
                                    Dia_sabado = Convert.ToBoolean(fila[7]),
                                    Dia_domingo = Convert.ToBoolean(fila[8]),
                                    Hora_inicio = (TimeSpan)fila[9],
                                    Hora_fin = (TimeSpan)fila[10]
                                }).ToList();

                //Lo anterior convierte el DataSet en una lista, y cada elemento de la lista tiene Objeto Entidad que 
                //representa cada fila de la tabla de la BD;
            }
            catch (Exception)
            {
                throw;
            }

            return listaHorarios;
        }
        #endregion

        #region Método para obtener un registro

        // Devuelve una entidad porque permite tener solo un registro
        public EntidadHorarEntrenador ObtenerHorario(int cod_horarEntrenador)
        {
            EntidadHorarEntrenador horarEntrenador= null; // Se inicaliza null porque lo puede devolver vacío

            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();

            SqlDataReader dataReader;
            // Para llenarlo se hace mediante un EXECUTE, permitiendo obtener datos de la base de datos

            string sentencia = string.Format("SELECT COD_HORARIO_ENTRENADOR,COD_ENTRENADOR, DIA_LUNES, DIA_MARTES, DIA_MIERCOLES, DIA_JUEVES,DIA_VIERNES, DIA_SABADO, DIA_DOMINGO, HORA_INICIO_HORARIO, HORA_FIN_HORARIO FROM HORARIO_ENTRENADORES WHERE COD_HORARIO_ENTRENADOR = {0}", cod_horarEntrenador);

            comando.Connection = conexion;
            comando.CommandText = sentencia;

            try
            {
                conexion.Open();
                // Lo que hace este método de comando es crear el dataReader con lo que se tiene arriba
                dataReader = comando.ExecuteReader();

                if (dataReader.HasRows)
                {
                    horarEntrenador = new EntidadHorarEntrenador();
                    dataReader.Read();

                    //Obtiene el valor de cada columna
                    horarEntrenador.Cod_Horario_entrenador = dataReader.GetInt32(0); // Se convierte por ser un número
                    horarEntrenador.Cod_entrenador = dataReader.GetInt32(1); // Se convierte por ser un número
                    if (dataReader[2] != DBNull.Value)
                    {
                        horarEntrenador.Dia_lunes =  dataReader.GetBoolean(2);
                    }
                    if (dataReader[3] != DBNull.Value)
                    {
                        horarEntrenador.Dia_martes = dataReader.GetBoolean(3);
                    }
                    if (dataReader[4] != DBNull.Value)
                    {
                        horarEntrenador.Dia_miercoles = dataReader.GetBoolean(4);
                    }
                    if (dataReader[5] != DBNull.Value)
                    {
                        horarEntrenador.Dia_jueves = dataReader.GetBoolean(5);
                    }
                    if (dataReader[6] != DBNull.Value)
                    {
                        horarEntrenador.Dia_viernes = dataReader.GetBoolean(6);
                    }
                    if (dataReader[7] != DBNull.Value)
                    {
                        horarEntrenador.Dia_sabado = dataReader.GetBoolean(7);
                    }
                    if (dataReader[8] != DBNull.Value)
                    {
                        horarEntrenador.Dia_domingo = dataReader.GetBoolean(8);
                    }

                    horarEntrenador.Hora_inicio = dataReader.GetTimeSpan(9);
                    horarEntrenador.Hora_fin = dataReader.GetTimeSpan(10);
                    horarEntrenador.Existe = true;
                }
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return horarEntrenador;
        }
        #endregion

        #region Método para eliminar un registro

        public int EliminarRegistro(int cod_horarEntrenador)
        {
            int filasEliminadas = 0;

            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();

            String sentencia = string.Format("DELETE FROM HORARIO_ENTRENADORES WHERE COD_HORARIO_ENTRENADOR= {0} ", cod_horarEntrenador);

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
