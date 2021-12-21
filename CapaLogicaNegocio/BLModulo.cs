using System;
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

        public int Insertar(EntidadModulo modulo, EntidadModulosPrograma ModProg)
        {
            int cod = 0;

            DAModulo accesoDatos = new DAModulo(_cadenaConexion);

            try
            {
                cod = accesoDatos.Insertar(modulo, ModProg);
            }
            catch (Exception)
            {
                throw;
            }
            return cod;
        }

        #endregion

        //Modificar**

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

        #region listarProgramas con un parámetro

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

        #region ObtenerPrograma

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
