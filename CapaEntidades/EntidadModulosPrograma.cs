using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class EntidadModulosPrograma
    {
        #region Atributos

        private int cod_programa;
        private int cod_modulo; 

        #endregion

        #region Propiedades

        public int Cod_programa { get => cod_programa; set => cod_programa = value; }
        public int Cod_modulo { get => cod_modulo; set => cod_modulo = value; }

        #endregion

        #region Constructores

        public EntidadModulosPrograma(int cod_programa, int cod_modulo)
        {
            this.cod_programa = cod_programa;
            this.cod_modulo = cod_modulo;
        }

        public EntidadModulosPrograma()
        {
            this.cod_programa = 0;
            this.cod_modulo = 0;
        }
        #endregion
    }
}
