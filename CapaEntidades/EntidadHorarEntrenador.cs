using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class EntidadHorarEntrenador : EntidadHorario // heredando de la clase abstracta de horario**
    {
        #region Atributos

        private int cod_Horario_entrenador;
        private int cod_entrenador; // La referencia de cual entrenador estará con este horario

        #endregion

        #region Propiedades

        public int Cod_Horario_entrenador { get => cod_Horario_entrenador; set => cod_Horario_entrenador = value; }
        public int Cod_entrenador { get => cod_entrenador; set => cod_entrenador = value; }

        #endregion

        #region Constructores

        public EntidadHorarEntrenador(bool dia_lunes, bool dia_martes, bool dia_miercoles, bool dia_jueves, bool dia_viernes, bool dia_sabado, bool dia_domingo, TimeSpan hora_inicio, TimeSpan hora_fin, int cod_Horario_entrenador, bool existe, int cod_entrenador = 0) : base(dia_lunes, dia_martes, dia_miercoles, dia_jueves, dia_viernes, dia_sabado, dia_domingo, hora_inicio, hora_fin, existe)
        {
            this.cod_Horario_entrenador = cod_Horario_entrenador;
            this.Cod_entrenador = cod_entrenador;
        }

        public EntidadHorarEntrenador() : base()
        {
            this.cod_Horario_entrenador = 0;
            this.cod_entrenador = 0;
        }

        #endregion
    }
}
