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
        private int identityGenerado;

        #endregion

        #region Propiedades

        public int Cod_programa { get => cod_programa; set => cod_programa = value; }
        public int Cod_modulo { get => cod_modulo; set => cod_modulo = value; }
        public int IdentityGenerado { get => identityGenerado; set => identityGenerado = value; }

        #endregion

        #region Constructores

        public EntidadModulosPrograma(int cod_programa, int cod_modulo, int identityGenerado)
        {
            this.cod_programa = cod_programa;
            this.cod_modulo = cod_modulo;
            this.identityGenerado = identityGenerado;
        }

        public EntidadModulosPrograma()
        {
            this.cod_programa = 0;
            this.cod_modulo = 0;
            identityGenerado = 0;
        }
        #endregion
    }
}
