using System;
using CapaAccesoDatos;
using CapaEntidades;
using System.Data;
using System.Collections.Generic;

namespace CapaLogicaNegocio
{
    public class BLCertificacion
    {
        #region Atributos

        private String _cadenaConexion;

        #endregion

        #region Propiedades

        public string CadenaConexion { get => _cadenaConexion; set => _cadenaConexion = value; }

        #endregion

        #region Constructores

        public BLCertificacion(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
        }

        public BLCertificacion()
        {
            _cadenaConexion = string.Empty;
        }

        #endregion

        #region Método Insertar        

        public int Insertar(EntidadCertificacion certificacion)
        {
            int cod = 0;

            DACertificacion accesoDatos = new DACertificacion(_cadenaConexion);

            try
            {
                cod = accesoDatos.Insertar(certificacion);
            }
            catch (Exception)
            {
                throw;
            }
            return cod;
        }

        #endregion

        #region Método Modificar (Actualizar)

        public int Modificar(EntidadCertificacion certificacion)
        {
            int filasAfectadas = 0;
            DACertificacion accesoDatos = new DACertificacion(_cadenaConexion);

            try
            {
                filasAfectadas = accesoDatos.Modificar(certificacion);
            }
            catch (Exception)
            {
                throw;
            }

            return filasAfectadas;
        }

        #endregion

        #region Para el método lista un registro

        public DataSet listarCertificacion(string condicion, string orden)
        {
            DataSet DS;
            DACertificacion accesoDatos = new DACertificacion(_cadenaConexion);

            try
            {
                DS = accesoDatos.listarCertificaciones(condicion, orden);
            }
            catch (Exception)
            {
                throw;
            }
            return DS;
        }

        #endregion

        #region listarModulos con un parámetro

        public List<EntidadCertificacion> listarCertificacion(string condicion)
        {
            List<EntidadCertificacion> listarCertificaciones;
            DACertificacion accesoDatos = new DACertificacion(_cadenaConexion);

            try
            {
                listarCertificaciones = accesoDatos.listarCertificaciones(condicion);
            }
            catch (Exception)
            {
                throw;
            }
            return listarCertificaciones;
        }

        #endregion

        #region ObtenerHorario

        public EntidadCertificacion ObtenerCertificacion(int cod)
        {
            EntidadCertificacion certificacion;
            DACertificacion accesoDatos = new DACertificacion(_cadenaConexion);

            try
            {
                certificacion = accesoDatos.ObtenerCertificacion(cod);

            }
            catch (Exception)
            {
                throw;
            }
            return certificacion;
        }

        #endregion

        #region EliminarHorarEntrenador

        public int EliminarHorarEntrenador(int cod)
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
