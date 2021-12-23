using System;
using CapaAccesoDatos;
using CapaEntidades;
using System.Data;
using System.Collections.Generic;
namespace CapaLogicaNegocio
{
    public class BLHorarEntrenador
    {
        #region Atributos

        private String _cadenaConexion;

        #endregion

        #region Propiedades

        public string CadenaConexion { get => _cadenaConexion; set => _cadenaConexion = value; }

        #endregion

        #region Constructores

        public BLHorarEntrenador(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
        }

        public BLHorarEntrenador()
        {
            _cadenaConexion = string.Empty;
        }

        #endregion

        #region Método Insertar        

        public int Insertar(EntidadHorarEntrenador horarEntrenador)
        {
            int cod = 0;

            DAHorarEntrenador accesoDatos = new DAHorarEntrenador(_cadenaConexion);

            try
            {
                cod = accesoDatos.Insertar(horarEntrenador);
            }
            catch (Exception)
            {
                throw;
            }
            return cod;
        }

        #endregion

        #region Método Modificar (Actualizar)

        public int Modificar(EntidadHorarEntrenador horarEntrenador)
        {
            int filasAfectadas = 0;
            DAHorarEntrenador accesoDatos = new DAHorarEntrenador(_cadenaConexion);

            try
            {
                filasAfectadas = accesoDatos.Modificar(horarEntrenador);
            }
            catch (Exception)
            {
                throw;
            }

            return filasAfectadas;
        }

        #endregion

        #region Para el método lista un registro

        public DataSet listarHorario(string condicion, string orden)
        {
            DataSet DS;
            DAHorarEntrenador accesoDatos = new DAHorarEntrenador(_cadenaConexion);

            try
            {
                DS = accesoDatos.listarHorarios(condicion, orden);
            }
            catch (Exception)
            {
                throw;
            }
            return DS;
        }

        #endregion

        #region listarModulos con un parámetro

        public List<EntidadHorarEntrenador> listarHorario(string condicion)
        {
            List<EntidadHorarEntrenador> listaModulos;
            DAHorarEntrenador accesoDatos = new DAHorarEntrenador(_cadenaConexion);

            try
            {
                listaModulos = accesoDatos.listarHorarios(condicion);
            }
            catch (Exception)
            {
                throw;
            }
            return listaModulos;
        }

        #endregion

        #region ObtenerHorario

        public EntidadHorarEntrenador ObtenerHorario(int cod)
        {
            EntidadHorarEntrenador modulo;
            DAHorarEntrenador accesoDatos = new DAHorarEntrenador(_cadenaConexion);

            try
            {
                modulo = accesoDatos.ObtenerHorario(cod);

            }
            catch (Exception)
            {
                throw;
            }
            return modulo;
        }

        #endregion

        #region EliminarHorarEntrenador

        public int EliminarHorarEntrenador(int cod)
        {
            int filasEliminadas = 0; // Se inicializa lo que se devolverá
            DAHorarEntrenador accesoDatos = new DAHorarEntrenador(_cadenaConexion);

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
