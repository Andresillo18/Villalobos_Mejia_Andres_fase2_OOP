using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class EntidadModAbier
    {
        #region Atributos

        private int cod_mod_abierto;
        private int cod_entrenador;
        private int cod_mod;
        private int cod_hora_mod;
        private DateTime fecha_inicio;
        private DateTime fecha_fin;
        private String observaciones;
        private bool existe;

        #endregion

        #region Propiedades

        public int Cod_mod_abierto { get => cod_mod_abierto; set => cod_mod_abierto = value; }
        public int Cod_entrenador { get => cod_entrenador; set => cod_entrenador = value; }
        public int Cod_mod { get => cod_mod; set => cod_mod = value; }
        public int Cod_hora_mod { get => cod_hora_mod; set => cod_hora_mod = value; }
        public DateTime Fecha_inicio { get => fecha_inicio; set => fecha_inicio = value; }
        public DateTime Fecha_fin { get => fecha_fin; set => fecha_fin = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
        public bool Existe { get => existe; set => existe = value; }

        #endregion

        #region Constructores

        public EntidadModAbier(int cod_mod_abierto, int cod_entrenador, int cod_mod, int cod_hora_mod, DateTime fecha_inicio, DateTime fecha_fin, string observaciones, bool existe)
        {
            this.cod_mod_abierto = cod_mod_abierto;
            this.cod_entrenador = cod_entrenador;
            this.cod_mod = cod_mod;
            this.cod_hora_mod = cod_hora_mod;
            this.fecha_inicio = fecha_inicio;
            this.fecha_fin = fecha_fin;
            this.observaciones = observaciones;
            this.existe = existe;
        }

        public EntidadModAbier()
        {
            this.cod_mod_abierto = 0;
            this.cod_entrenador = 0;
            this.cod_mod = 0;
            this.cod_hora_mod = 0;
            this.fecha_inicio = new DateTime();
            this.fecha_fin = new DateTime();
            this.observaciones = string.Empty;
            existe = false;
        }
        #endregion

        //Todavía no se ocupan métodos en las clases de las entidades porque no hay necesidad de realizar alguna acción especifica
    }
}
