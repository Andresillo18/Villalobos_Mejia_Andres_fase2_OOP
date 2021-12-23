using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class EntidadAtleta : EntidadPersona
    {
        #region Atributos

        private int cod_atleta;
        private String genero;

        #endregion

        #region Propiedades

        public int Cod_atleta { get => cod_atleta; set => cod_atleta = value; }
        public string Genero { get => genero; set => genero = value; }

        #endregion

        #region Constructor

        //: base() llama al constructor de la clase que se hereda para darle valores a sus atributos, se deben enviar cuando se usa
        public EntidadAtleta(string identificacion, string nombre, string apellido1, string apellido2, string telefono1, string telefono2, string correo, DateTime fecha_nacimiento, string provincia, string distrito, string canton, bool estado, int cod_atleta, string genero) : base( identificacion, nombre, apellido1, apellido2, telefono1, telefono2, correo, fecha_nacimiento, provincia, distrito, canton, estado)
        {
            this.cod_atleta = cod_atleta;
            this.genero = genero;
        }

        public EntidadAtleta() : base()
        {
            this.cod_atleta =0;
            this.genero = string.Empty;
        }
        #endregion
    }
}
