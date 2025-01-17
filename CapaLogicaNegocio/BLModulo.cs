﻿using System;
using CapaAccesoDatos;
using CapaEntidades;
using System.Data;
using System.Collections.Generic;

namespace CapaLogicaNegocio
{
    public class BLModulo
    {
        #region Atributos

        private String _cadenaConexion;

        #endregion

        #region Propiedades

        public string CadenaConexion { get => _cadenaConexion; set => _cadenaConexion = value; }

        #endregion

        #region Constructores

        public BLModulo(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
        }

        public BLModulo()
        {
            _cadenaConexion = string.Empty;
        }

        #endregion

        #region Método Insertar        

        public int Insertar(EntidadModulo modulo)
        {
            int cod = 0;

            DAModulo accesoDatos = new DAModulo(_cadenaConexion);

            try
            {
                cod = accesoDatos.Insertar(modulo);
            }
            catch (Exception)
            {
                throw;
            }
            return cod;
        }

        #endregion

        #region Método Modificar (Actualizar)

        public int Modificar(EntidadModulo modulo)
        {
            int filasAfectadas = 0;
            DAModulo accesoDatos = new DAModulo(_cadenaConexion);

            try
            {
                filasAfectadas = accesoDatos.Modificar(modulo);
            }
            catch (Exception)
            {
                throw;
            }

            return filasAfectadas;
        }

        #endregion

        #region Para el método lista un registro

        public DataSet listarModulos(string condicion, string orden)
        {
            DataSet DS;
            DAModulo accesoDatos = new DAModulo(_cadenaConexion);

            try
            {
                DS = accesoDatos.listarModulos(condicion, orden);
            }
            catch (Exception)
            {
                throw;
            }
            return DS;
        }

        #endregion

        #region listarModulos con un parámetro

        public List<EntidadModulo> listarModulos(string condicion)
        {
            List<EntidadModulo> listaModulos;
            DAModulo accesoDatos = new DAModulo(_cadenaConexion);

            try
            {
                listaModulos = accesoDatos.listarModulos(condicion);
            }
            catch (Exception)
            {
                throw;
            }
            return listaModulos;
        }

        #endregion

        #region ObtenerModulo

        public EntidadModulo ObtenerModulo(int cod)
        {
            EntidadModulo modulo;
            DAModulo accesoDatos = new DAModulo(_cadenaConexion);

            try
            {
                modulo = accesoDatos.ObtenerModulo(cod);

            }
            catch (Exception)
            {
                throw;
            }
            return modulo;
        }

        #endregion

        #region EliminarModulo

        public int EliminarModulo(int cod)
        {
            int filasEliminadas = 0; // Se inicializa lo que se devolverá
            DAModulo accesoDatos = new DAModulo(_cadenaConexion);

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
