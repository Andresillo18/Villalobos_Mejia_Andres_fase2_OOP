using System;
using CapaAccesoDatos;
using CapaEntidades;
using System.Data;
using System.Collections.Generic;

namespace CapaLogicaNegocio
{
    public class BLAtleta
    {
        #region Atributos

        private String _cadenaConexion;

        #endregion

        #region Propiedades

        public string CadenaConexion { get => _cadenaConexion; set => _cadenaConexion = value; }

        #endregion

        #region Constructores

        public BLAtleta(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
        }

        public BLAtleta()
        {
            _cadenaConexion = string.Empty;
        }

        #endregion

        #region Método Insertar        

        public int Insertar(EntidadAtleta atleta)
        {
            int cod = 0;

            DA_Atleta accesoDatos = new DA_Atleta(_cadenaConexion);

            try
            {
                cod = accesoDatos.Insertar(atleta);
            }
            catch (Exception)
            {
                throw;
            }
            return cod;
        }

        #endregion

        #region Método Modificar (Actualizar)

        public int Modificar(EntidadAtleta atleta)
        {
            int filasAfectadas = 0;
            DA_Atleta accesoDatos = new DA_Atleta(_cadenaConexion);

            try
            {
                filasAfectadas = accesoDatos.Modificar(atleta);
            }
            catch (Exception)
            {
                throw;
            }

            return filasAfectadas;
        }

        #endregion

        #region Para el método lista un registro

        public DataSet listarAtletas(string condicion, string orden)
        {
            DataSet DS;
            DA_Atleta accesoDatos = new DA_Atleta(_cadenaConexion);

            try
            {
                DS = accesoDatos.listarAtletas(condicion, orden);
            }
            catch (Exception)
            {
                throw;
            }
            return DS;
        }

        #endregion

        #region listarModulos con un parámetro

        public List<EntidadAtleta> listarAtletas(string condicion)
        {
            List<EntidadAtleta> listaAtleta;
            DA_Atleta accesoDatos = new DA_Atleta(_cadenaConexion);

            try
            {
                listaAtleta = accesoDatos.listarAtletas(condicion);
            }
            catch (Exception)
            {
                throw;
            }
            return listaAtleta;
        }

        #endregion

        #region ObtenerAtleta

        public EntidadAtleta ObtenerAtleta(int cod)
        {
            EntidadAtleta atleta;
            DA_Atleta accesoDatos = new DA_Atleta(_cadenaConexion);

            try
            {
                atleta= accesoDatos.ObtenerAtleta(cod);

            }
            catch (Exception)
            {
                throw;
            }
            return atleta;
        }

        #endregion

        #region EliminarAtleta

        public int EliminarAtleta(int cod)
        {
            int filasEliminadas = 0; // Se inicializa lo que se devolverá
            DA_Atleta accesoDatos = new DA_Atleta(_cadenaConexion);

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
