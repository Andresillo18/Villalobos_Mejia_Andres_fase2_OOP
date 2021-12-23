using System;
using CapaAccesoDatos;
using CapaEntidades;
using System.Data;
using System.Collections.Generic;

namespace CapaLogicaNegocio
{
    public class BLEntrenador
    {
        #region Atributos

        private String _cadenaConexion;

        #endregion

        #region Propiedades

        public string CadenaConexion { get => _cadenaConexion; set => _cadenaConexion = value; }

        #endregion

        #region Constructores

        public BLEntrenador(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
        }

        public BLEntrenador()
        {
            _cadenaConexion = string.Empty;
        }

        #endregion

        #region Método Insertar        

        public int Insertar(EntidadEntrenador entrenador)
        {
            int cod = 0;

            DAEntrenadores accesoDatos = new DAEntrenadores(_cadenaConexion);

            try
            {
                cod = accesoDatos.Insertar(entrenador);
            }
            catch (Exception)
            {
                throw;
            }
            return cod;
        }

        #endregion

        #region Método Modificar (Actualizar)

        public int Modificar(EntidadEntrenador entrenador)
        {
            int filasAfectadas = 0;
            DAEntrenadores accesoDatos = new DAEntrenadores(_cadenaConexion);

            try
            {
                filasAfectadas = accesoDatos.Modificar(entrenador);
            }
            catch (Exception)
            {
                throw;
            }

            return filasAfectadas;
        }

        #endregion

        #region Para el método lista un registro

        public DataSet listarEntrenadores(string condicion, string orden)
        {
            DataSet DS;
            DAEntrenadores accesoDatos = new DAEntrenadores(_cadenaConexion);

            try
            {
                DS = accesoDatos.listarEntrenador(condicion, orden);
            }
            catch (Exception)
            {
                throw;
            }
            return DS;
        }

        #endregion

        #region listarModulos con un parámetro

        public List<EntidadEntrenador> listarEntrenadores(string condicion)
        {
            List<EntidadEntrenador> listaModulos;
            DAEntrenadores accesoDatos = new DAEntrenadores(_cadenaConexion);

            try
            {
                listaModulos = accesoDatos.listarEntrenador(condicion);
            }
            catch (Exception)
            {
                throw;
            }
            return listaModulos;
        }

        #endregion

        #region ObtenerEntrenador

        public EntidadEntrenador ObtenerEntrenador(int cod)
        {
            EntidadEntrenador entrenador;
            DAEntrenadores accesoDatos = new DAEntrenadores(_cadenaConexion);

            try
            {
                entrenador = accesoDatos.ObtenerEntrenador(cod);

            }
            catch (Exception)
            {
                throw;
            }
            return entrenador;
        }

        #endregion

        #region EliminarHorarioMod

        public int EliminarHorarioMod(int cod)
        {
            int filasEliminadas = 0; // Se inicializa lo que se devolverá
            DAEntrenadores accesoDatos = new DAEntrenadores(_cadenaConexion);

            try
            {
                filasEliminadas = accesoDatos.EliminarRegistro(cod);
            }
            catch (Exception)
            {
                throw;
            }
            return filasEliminadas;
        }
        #endregion
    }
}
