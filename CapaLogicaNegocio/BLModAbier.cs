using System;
using CapaAccesoDatos;
using CapaEntidades;
using System.Data;
using System.Collections.Generic;

namespace CapaLogicaNegocio
{
    public class BLModAbier
    {
        #region Atributos

        private String _cadenaConexion;

        #endregion

        #region Propiedades

        public string CadenaConexion { get => _cadenaConexion; set => _cadenaConexion = value; }

        #endregion

        #region Constructores
        
        public BLModAbier(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
        }

        public BLModAbier()
        {
            _cadenaConexion = string.Empty;
        }

        #endregion

        #region Método Insertar        

        public int Insertar(EntidadModAbier modulo)
        {
            int cod = 0;

            DAModAbier accesoDatos = new DAModAbier (_cadenaConexion);

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

        public int Modificar(EntidadModAbier modulo)
        {
            int filasAfectadas = 0;
            DAModAbier accesoDatos = new DAModAbier(_cadenaConexion);

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
            DAModAbier accesoDatos = new DAModAbier(_cadenaConexion);

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

        public List<EntidadModAbier> listarModulos(string condicion)
        {
            List<EntidadModAbier> listaModulos;
            DAModAbier accesoDatos = new DAModAbier(_cadenaConexion);

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

        public EntidadModAbier ObtenerModulo(int cod)
        {
            EntidadModAbier modulo;
            DAModAbier accesoDatos = new DAModAbier(_cadenaConexion);

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

        #region EliminarModuloAbier

        public int EliminarModuloAbier(int cod)
        {
            int filasEliminadas = 0; // Se inicializa lo que se devolverá
            DAModAbier accesoDatos = new DAModAbier(_cadenaConexion);

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
