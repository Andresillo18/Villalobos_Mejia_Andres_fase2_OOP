using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class EntidadHorarMod : EntidadHorario
    {
        #region Atributos

        private int cod_Horario_Modulos;       

        #endregion

        #region Propiedades

        public int Cod_Horario_Modulos { get => cod_Horario_Modulos; set => cod_Horario_Modulos = value; }

        #endregion

        #region Constructores

        // Se llama al constructor que hereda y se le envian los parámetros que recibe ambos, incluyendo base ()
        public EntidadHorarMod(bool dia_lunes, bool dia_martes, bool dia_miercoles, bool dia_jueves, bool dia_viernes, bool dia_sabado, bool dia_domingo, TimeSpan hora_inicio, TimeSpan hora_fin,bool existe, int cod_Horario_Modulos) :base (dia_lunes, dia_martes, dia_miercoles, dia_jueves, dia_viernes, dia_sabado, dia_domingo, hora_inicio, hora_fin, existe)
        {
            this.cod_Horario_Modulos = cod_Horario_Modulos;
        }

        public EntidadHorarMod() : base() // lo hereda pero el vacío
        {
            this.cod_Horario_Modulos = 0;
        }
        #endregion
    }
}
