using System;
using CapaAccesoDatos;
using CapaEntidades;
using System.Data;
using System.Collections.Generic;

namespace CapaLogicaNegocio
{
    public class BLIncapEvent
    {
        #region Atributos

        private String _cadenaConexion;

        #endregion

        #region Propiedades

        public string CadenaConexion { get => _cadenaConexion; set => _cadenaConexion = value; }

        #endregion

        #region Constructores

        public BLIncapEvent(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
        }

        public BLIncapEvent()
        {
            _cadenaConexion = string.Empty;
        }

        #endregion

        #region Método Insertar        

        public int Insertar(EntidadIncapEvent incapEvent)
        {
            int cod = 0;

            DAIncapEvent accesoDatos = new DAIncapEvent(_cadenaConexion);

            try
            {
                cod = accesoDatos.Insertar(incapEvent);
            }
            catch (Exception)
            {
                throw;
            }
            return cod;
        }

        #endregion

        #region Método Modificar (Actualizar)

        public int Modificar(EntidadIncapEvent incapEvent)
        {
            int filasAfectadas = 0;
            DAIncapEvent accesoDatos = new DAIncapEvent(_cadenaConexion);

            try
            {
                filasAfectadas = accesoDatos.Modificar(incapEvent);
            }
            catch (Exception)
            {
                throw;
            }

            return filasAfectadas;
        }

        #endregion

        #region Para el método lista un registro

        public DataSet listarIncapEvent(string condicion, string orden)
        {
            DataSet DS;
            DAIncapEvent accesoDatos = new DAIncapEvent(_cadenaConexion);

            try
            {
                DS = accesoDatos.listarIncapEvents(condicion, orden);
            }
            catch (Exception)
            {
                throw;
            }
            return DS;
        }

        #endregion

        #region listarModulos con un parámetro

        public List<EntidadIncapEvent> listarIncapEvent(string condicion)
        {
            List<EntidadIncapEvent> listaIncapEvent;
            DAIncapEvent accesoDatos = new DAIncapEvent(_cadenaConexion);

            try
            {
                listaIncapEvent = accesoDatos.listarIncapEvents(condicion);
            }
            catch (Exception)
            {
                throw;
            }
            return listaIncapEvent;
        }

        #endregion

        #region ObtenerHorario

        public EntidadIncapEvent ObtenerIncapEvent(int cod)
        {
            EntidadIncapEvent incapEvent;
            DAIncapEvent accesoDatos = new DAIncapEvent(_cadenaConexion);

            try
            {
                incapEvent = accesoDatos.ObtenerIncapEvent(cod);

            }
            catch (Exception)
            {
                throw;
            }
            return incapEvent;
        }

        #endregion

        #region EliminarHorarEntrenador

        public int EliminarIncapEvent(int cod)
        {
            int filasEliminadas = 0; // Se inicializa lo que se devolverá
            DACertificacion accesoDatos = new DACertificacion(_cadenaConexion);

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
