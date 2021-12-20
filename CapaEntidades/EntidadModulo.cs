using System;

namespace CapaEntidades
{
    public class EntidadModulo // Revisar que todas las clases de una capa esten public
    {
        #region Atributos

        private int cod_modulo; 
        private string nombre_modulo;
        private int horas_duracion;
        private string requesitos_modulo;
        private bool existe;

        #endregion

        #region Propiedades

        public int Cod_modulo { get => cod_modulo; set => cod_modulo = value; }
        public string Nombre_modulo { get => nombre_modulo; set => nombre_modulo = value; }
        public int Horas_duracion { get => horas_duracion; set => horas_duracion = value; }
        public string Requesitos_modulo { get => requesitos_modulo; set => requesitos_modulo = value; }
        public bool Existe { get => existe; set => existe = value; }

        #endregion

        #region Constructores

        public EntidadModulo(int cod_modulo, string nombre_modulo, int horas_duracion, string requesitos_modulo, bool existe)
        {
            this.cod_modulo = cod_modulo;
            this.nombre_modulo = nombre_modulo;
            this.horas_duracion = horas_duracion;
            this.requesitos_modulo = requesitos_modulo;
            this.existe = existe;
        }

        public EntidadModulo()
        { //vacío
            this.cod_modulo = 0;
            this.nombre_modulo = string.Empty;
            this.horas_duracion = 0;
            this.requesitos_modulo = string.Empty;
            this.existe = false;
        }
        #endregion
    }
}
