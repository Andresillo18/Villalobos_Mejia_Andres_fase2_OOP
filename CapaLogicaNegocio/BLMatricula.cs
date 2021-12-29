using System;
using CapaAccesoDatos;
using CapaEntidades;
using System.Data;
using System.Collections.Generic;

namespace CapaLogicaNegocio
{
    public class BLMatricula
    {
        #region Atributos

        private String _cadenaConexion;

        #endregion

        #region Propiedades

        public string CadenaConexion { get => _cadenaConexion; set => _cadenaConexion = value; }

        #endregion

        #region Constructores

        public BLMatricula(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
        }

        public BLMatricula()
        {
            _cadenaConexion = string.Empty;
        }

        #endregion

        #region Método Insertar        

        public int Insertar(EntidadMatricula matricula)
        {
            int cod = 0;

            DAMatricula accesoDatos = new DAMatricula(_cadenaConexion);

            try
            {
                cod = accesoDatos.Insertar(matricula);
            }
            catch (Exception)
            {
                throw;
            }
            return cod;
        }

        #endregion

        #region Método Modificar (Actualizar)

        public int Modificar(EntidadMatricula matricula)
        {
            int filasAfectadas = 0;
            DAMatricula accesoDatos = new DAMatricula(_cadenaConexion);

            try
            {
                filasAfectadas = accesoDatos.Modificar(matricula);
            }
            catch (Exception)
            {
                throw;
            }

            return filasAfectadas;
        }

        #endregion

        #region Para el método lista un registro

        public DataSet listarMatriculas(string condicion, string orden)
        {
            DataSet DS;
            DAMatricula accesoDatos = new DAMatricula(_cadenaConexion);

            try
            {
                DS = accesoDatos.listarMatricula(condicion, orden);
            }
            catch (Exception)
            {
                throw;
            }
            return DS;
        }

        #endregion

        #region listarMatriculas con un parámetro

        public List<EntidadMatricula> listarMatriculas(string condicion)
        {
            List<EntidadMatricula> listaMatriculas;
            DAMatricula accesoDatos = new DAMatricula(_cadenaConexion);

            try
            {
                listaMatriculas = accesoDatos.listarMatricula(condicion);
            }
            catch (Exception)
            {
                throw;
            }
            return listaMatriculas;
        }

        #endregion

        #region ObtenerMatricula

        public EntidadMatricula ObtenerMatricula(int cod)
        {
            EntidadMatricula matricula;
            DAMatricula accesoDatos = new DAMatricula(_cadenaConexion);

            try
            {
                matricula = accesoDatos.ObtenerMatricula(cod);

            }
            catch (Exception)
            {
                throw;
            }
            return matricula;
        }

        #endregion

        #region EliminarMatricula

        public int EliminarMatricula(int cod)
        {
            int filasEliminadas = 0; // Se inicializa lo que se devolverá
            DAMatricula accesoDatos = new DAModAbier(_cadenaConexion);

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
