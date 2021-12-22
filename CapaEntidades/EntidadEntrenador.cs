using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class EntidadEntrenador : EntidadPersona
    {
        #region Atributos

        private int cod_entrenador;

        #endregion

        #region Propiedades

        public int Cod_entrenador { get => cod_entrenador; set => cod_entrenador = value; }

        #endregion

        #region Constructor

        public EntidadEntrenador(string identificacion, string nombre, string apellido1, string apellido2, int telefono1, int telefono2, string correo, DateTime fecha_nacimiento, string provincia, string distrito, string canton, bool estado, int cod_entrenador) : base(identificacion, nombre, apellido1, apellido2, telefono1, telefono2, correo, fecha_nacimiento, provincia, distrito, canton, estado)
        {
            this.cod_entrenador = cod_entrenador;
        }


        public EntidadEntrenador() : base()
        {
            this.cod_entrenador = 0;
        }

        #endregion
    }
}
