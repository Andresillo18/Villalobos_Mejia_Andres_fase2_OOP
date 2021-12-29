using System;
using CapaAccesoDatos;
using CapaEntidades;
using System.Data;
using System.Collections.Generic;

namespace CapaLogicaNegocio
{
    public class BLRegisHoraLabo
    {
        #region Atributos

        private String _cadenaConexion;

        #endregion

        #region Propiedades

        public string CadenaConexion { get => _cadenaConexion; set => _cadenaConexion = value; }

        #endregion

        #region Constructores

        public BLRegisHoraLabo(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
        }

        public BLRegisHoraLabo()
        {
            _cadenaConexion = string.Empty;
        }

        #endregion

        #region Método Insertar        

        public int Insertar(EntidadRegisHoraLabo horaLabo)
        {
            int cod = 0;

            DARegisHoraLabo accesoDatos = new DARegisHoraLabo(_cadenaConexion);

            try
            {
                cod = accesoDatos.Insertar(horaLabo);
            }
            catch (Exception)
            {
                throw;
            }
            return cod;
        }

        #endregion

        #region Método Modificar (Actualizar)

        public int Modificar(EntidadRegisHoraLabo horaLabo)
        {
            int filasAfectadas = 0;
            DARegisHoraLabo accesoDatos = new DARegisHoraLabo(_cadenaConexion);

            try
            {
                filasAfectadas = accesoDatos.Modificar(horaLabo);
            }
            catch (Exception)
            {
                throw;
            }

            return filasAfectadas;
        }

        #endregion

        #region Para el método lista un registro

        public DataSet listarRegisHorasLabo(string condicion, string orden)
        {
            DataSet DS;
            DARegisHoraLabo accesoDatos = new DARegisHoraLabo(_cadenaConexion);

            try
            {
                DS = accesoDatos.listarHorasLabo(condicion, orden);
            }
            catch (Exception)
            {
                throw;
            }
            return DS;
        }

        #endregion

        #region listarModulos con un parámetro

        public List<EntidadRegisHoraLabo> listarRegisHorasLabo(string condicion)
        {
            List<EntidadRegisHoraLabo> listaHorasLabo;
            DARegisHoraLabo accesoDatos = new DARegisHoraLabo(_cadenaConexion);

            try
            {
                listaHorasLabo = accesoDatos.listarHorasLabo(condicion);
            }
            catch (Exception)
            {
                throw;
            }
            return listaHorasLabo;
        }

        #endregion

        #region ObtenerHorasLabo

        public EntidadRegisHoraLabo ObtenerRegisHorasLabo(int cod)
        {
            EntidadRegisHoraLabo horasLabo;
            DARegisHoraLabo accesoDatos = new DARegisHoraLabo(_cadenaConexion);

            try
            {
                horasLabo = accesoDatos.ObtenerIncapEvent(cod);

            }
            catch (Exception)
            {
                throw;
            }
            return horasLabo;
        }

        #endregion

        #region EliminarHorasLabo

        public int EliminarHorasLabo(int cod)
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
