using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class EntidadCertificacion
    {
        #region Atributos

        private int cod_certificacion;
        private int cod_entrenador;
        private bool gimnasio_especifi;
        private bool natacion_especifi;
        private bool maraton_especifi;
        private bool ciclismo_especifi;
        private bool existe;

        #endregion

        #region Propiedades

        public int Cod_certificacion { get => cod_certificacion; set => cod_certificacion = value; }
        public int Cod_entrenador { get => cod_entrenador; set => cod_entrenador = value; }
        public bool Gimnasio_especifi { get => gimnasio_especifi; set => gimnasio_especifi = value; }
        public bool Natacion_especifi { get => natacion_especifi; set => natacion_especifi = value; }
        public bool Maraton_especifi { get => maraton_especifi; set => maraton_especifi = value; }
        public bool Ciclismo_especifi { get => ciclismo_especifi; set => ciclismo_especifi = value; }
        public bool Existe { get => existe; set => existe = value; }

        #endregion

        #region Constructores

        public EntidadCertificacion(int cod_entrenador, bool gimnasio_especifi, bool natacion_especifi, bool maraton_especifi, bool ciclismo_especifi, bool existe, int cod_certificacion)
        {
            this.cod_entrenador = cod_entrenador;
            this.gimnasio_especifi = gimnasio_especifi;
            this.natacion_especifi = natacion_especifi;
            this.maraton_especifi = maraton_especifi;
            this.ciclismo_especifi = ciclismo_especifi;
            this.Existe = existe;
            this.Cod_certificacion = cod_certificacion;
        }

        public EntidadCertificacion()
        {
            this.Cod_certificacion = 0;
            this.cod_entrenador = 0;
            this.gimnasio_especifi = false;
            this.natacion_especifi = false;
            this.maraton_especifi = false;
            this.ciclismo_especifi = false;
            this.Existe = false;
        }

        #endregion
    }
}
