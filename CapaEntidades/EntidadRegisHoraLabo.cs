using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class EntidadRegisHoraLabo
    {
        #region Atributos

        private int cod_regisHoraLabo;
        private int cod_entrenador;
        private DateTime dia_regisHoraLabo;
        private TimeSpan hora_inicio; // Se usa timeSpan porque solo se requiere que se ingrese la hora de parte del usuario
        private TimeSpan hora_fin;
        private bool existe;

        #endregion

        #region Propiedad

        public int Cod_regisHoraLabo { get => cod_regisHoraLabo; set => cod_regisHoraLabo = value; }
        public int Cod_entrenador { get => cod_entrenador; set => cod_entrenador = value; }
        public DateTime Dia_regisHoraLabo { get => dia_regisHoraLabo; set => dia_regisHoraLabo = value; }
        public TimeSpan Hora_inicio { get => hora_inicio; set => hora_inicio = value; }
        public TimeSpan Hora_fin { get => hora_fin; set => hora_fin = value; }
        public bool Existe { get => existe; set => existe = value; }

        #endregion

        #region Constructores

        public EntidadRegisHoraLabo(int cod_regisHoraLabo, int cod_entrenador, DateTime dia_regisHoraLabo, TimeSpan Hora_inicio, TimeSpan Hora_fin, bool existe)
        {
            this.cod_regisHoraLabo = cod_regisHoraLabo;
            this.cod_entrenador = cod_entrenador;
            this.dia_regisHoraLabo = dia_regisHoraLabo;
            this.hora_inicio = Hora_inicio;
            this.hora_fin = Hora_fin;
            this.existe = existe;
        }

        public EntidadRegisHoraLabo()
        {
            this.cod_regisHoraLabo = 0;
            this.cod_entrenador = 0;
            this.dia_regisHoraLabo = new DateTime();
            this.hora_inicio = new TimeSpan();
            this.hora_fin = new TimeSpan();
            this.existe = false;
        }
        #endregion
    }
}
