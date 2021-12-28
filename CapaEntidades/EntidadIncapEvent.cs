using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class EntidadIncapEvent
    {
        #region Atributos

        private int cod_incap_event;
        private int cod_entrenador;
        private DateTime dia_inicio_IE;
        private DateTime dia_fin_IE;
        private string observaciones;
        private bool existe;

        #endregion

        #region Propiedades

        public int Cod_incap_event { get => cod_incap_event; set => cod_incap_event = value; }
        public int Cod_entrenador { get => cod_entrenador; set => cod_entrenador = value; }
        public DateTime Dia_inicio_IE { get => dia_inicio_IE; set => dia_inicio_IE = value; }
        public DateTime Dia_fin_IE { get => dia_fin_IE; set => dia_fin_IE = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
        public bool Existe { get => existe; set => existe = value; }

        #endregion

        #region Constructores

        public EntidadIncapEvent(int cod_incap_event, int cod_entrenador, DateTime dia_inicio_IE, DateTime dia_fin_IE, string observaciones, bool existe)
        {
            this.cod_incap_event = cod_incap_event;
            this.cod_entrenador = cod_entrenador;
            this.dia_inicio_IE = dia_inicio_IE;
            this.dia_fin_IE = dia_fin_IE;
            this.observaciones = observaciones;
            this.Existe = existe;
        }

        public EntidadIncapEvent()
        {
            this.cod_incap_event = 0;
            this.cod_entrenador = 0;
            this.dia_inicio_IE = new DateTime();
            this.dia_fin_IE = new DateTime();
            this.observaciones = string.Empty;
            this.Existe = false;
        }

        #endregion

        //Aún no se usarán métodos para las entidades ya que se utilizan solo para el movimiento de info
    }
}
