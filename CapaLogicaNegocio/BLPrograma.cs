using System;
using CapaAccesoDatos;
using CapaEntidades;
using System.Data;
using System.Collections.Generic;

namespace CapaLogicaNegocio
{
    public class BLPrograma
    {
        #region Atributos

        private String _cadenaConexion;
        private String _mensaje; // No se utilizará en varias capas y entidades ya que no se utilizan muchos procesos en la BD que devuelvan

        #endregion

        #region Propiedades

        public string CadenaConexion { get => _cadenaConexion; set => _cadenaConexion = value; }
        public string Mensaje { get => _mensaje; set => _mensaje = value; }

        #endregion

        #region Constructores

        public BLPrograma(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        public BLPrograma()
        {
            _cadenaConexion = string.Empty;
            _mensaje = string.Empty;
        }

        #endregion

        #region Método Insertar
        // Los métodos de la capa de BL son un PUENTE a la capa de DA
        //Y en la capa de BL se aplicarían las comprobaciones y REGLAS DEL NEGOCIO

        public int Insertar(EntidadadPrograma programa)
        {
            int cod = 0;

            DAPrograma accesoDatos = new DAPrograma(_cadenaConexion);

            try
            {
                cod = accesoDatos.Insertar(programa);
            }
            catch (Exception)
            {
                throw;
            }
            return cod;
        }

        #endregion

        #region Modificar

        public int Modificar(EntidadadPrograma programa)
        {
            int filasAfectadas = 0;
            DAPrograma accesoDatos = new DAPrograma(_cadenaConexion);

            try
            {
                filasAfectadas = accesoDatos.Modificar(programa);
            }
            catch (Exception)
            {
                throw;
            }

            return filasAfectadas;
        }

        #endregion

        #region Para el método lista un programa

        public DataSet listarProgramas(string condicion, string orden)
        {
            DataSet DS;
            DAPrograma accesoDatos = new DAPrograma(_cadenaConexion);

            try
            {
                DS = accesoDatos.listarProgramas(condicion, orden);
            }
            catch (Exception)
            {
                throw;
            }
            return DS;
        }

        #endregion

        #region listarProgramas con un parámetro

        public List<EntidadadPrograma> listarProgramas(string condicion)
        {
            List<EntidadadPrograma> listarProgramas;
            DAPrograma accesoDatos = new DAPrograma(_cadenaConexion);

            try
            {
                listarProgramas = accesoDatos.listarProgramas(condicion);
            }
            catch (Exception)
            {
                throw;
            }
            return listarProgramas;
        }

        #endregion

        #region ObtenerPrograma

        public EntidadadPrograma ObtenerPrograma(int cod)
        {
            EntidadadPrograma programa;
            DAPrograma accesoDatos = new DAPrograma(_cadenaConexion);

            try
            {
                programa = accesoDatos.ObtenerPrograma(cod);
                
            }
            catch (Exception)
            {
                throw;
            }
            return programa;
        }

        #endregion

        #region EliminarPrograma

        public int EliminarPrograma(int cod)
        {
            int filasEliminadas = 0; // Se inicializa lo que se devolverá
            DAPrograma accesoDatos = new DAPrograma(_cadenaConexion);

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
