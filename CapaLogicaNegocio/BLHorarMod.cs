using System;
using CapaAccesoDatos;
using CapaEntidades;
using System.Data;
using System.Collections.Generic;

namespace CapaLogicaNegocio
{
    public class BLHorarMod
    {
        #region Atributos

        private String _cadenaConexion;

        #endregion

        #region Propiedades

        public string CadenaConexion { get => _cadenaConexion; set => _cadenaConexion = value; }

        #endregion

        #region Constructores

        public BLHorarMod(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
        }

        public BLHorarMod()
        {
            _cadenaConexion = string.Empty;
        }

        #endregion

        #region Método Insertar        

        public int Insertar(EntidadHorarMod horarMod)
        {
            int cod = 0;

            DAHorarMod accesoDatos = new DAHorarMod(_cadenaConexion);

            try
            {
                cod = accesoDatos.Insertar(horarMod);
            }
            catch (Exception)
            {
                throw;
            }
            return cod;
        }

        #endregion

        #region Método Modificar (Actualizar)

        public int Modificar(EntidadHorarMod horarMod)
        {
            int filasAfectadas = 0;
            DAHorarMod accesoDatos = new DAHorarMod(_cadenaConexion);

            try
            {
                filasAfectadas = accesoDatos.Modificar(horarMod);
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
            DAHorarMod accesoDatos = new DAHorarMod(_cadenaConexion);

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

        public List<EntidadHorarMod> listarHorario(string condicion)
        {
            List<EntidadHorarMod> listaHorario;
            DAHorarMod accesoDatos = new DAHorarMod(_cadenaConexion);

            try
            {
                listaHorario = accesoDatos.listarHorarios(condicion);
            }
            catch (Exception)
            {
                throw;
            }
            return listaHorario;
        }

        #endregion

        #region ObtenerHorario

        public EntidadHorarMod ObtenerHorario(int cod)
        {
            EntidadHorarMod horario;
            DAHorarMod accesoDatos = new DAHorarMod(_cadenaConexion);

            try
            {
                horario = accesoDatos.ObtenerHorario(cod);

            }
            catch (Exception)
            {
                throw;
            }
            return horario;
        }

        #endregion

        #region EliminarHorarioMod

        public int EliminarHorarioMod(int cod)
        {
            int filasEliminadas = 0; // Se inicializa lo que se devolverá
            DAHorarMod accesoDatos = new DAHorarMod(_cadenaConexion);

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
