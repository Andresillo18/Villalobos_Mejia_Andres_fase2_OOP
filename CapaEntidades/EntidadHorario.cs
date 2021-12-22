using System;
using System.Data.SqlClient; // UTILIZAR ADO .NET
using System.Data; // Se utiliza para el acceso a datos
using System.Linq;
using System.Collections.Generic;
using CapaEntidades;

namespace CapaEntidades
{
    public abstract class EntidadHorario
    {
        #region Atributos

        private bool dia_lunes;
        private bool dia_martes;
        private bool dia_miercoles;
        private bool dia_jueves;
        private bool dia_viernes;
        private bool dia_sabado;
        private bool dia_domingo;
        private TimeSpan hora_inicio;
        private TimeSpan hora_fin;
        private bool existe;

        #endregion

        #region Propiedades

        public bool Dia_lunes { get => dia_lunes; set => dia_lunes = value; }
        public bool Dia_martes { get => dia_martes; set => dia_martes = value; }
        public bool Dia_miercoles { get => dia_miercoles; set => dia_miercoles = value; }
        public bool Dia_jueves { get => dia_jueves; set => dia_jueves = value; }
        public bool Dia_viernes { get => dia_viernes; set => dia_viernes = value; }
        public bool Dia_sabado { get => dia_sabado; set => dia_sabado = value; }
        public bool Dia_domingo { get => dia_domingo; set => dia_domingo = value; }
        public TimeSpan Hora_inicio { get => hora_inicio; set => hora_inicio = value; }
        public TimeSpan Hora_fin { get => hora_fin; set => hora_fin = value; }
        public bool Existe { get => existe; set => existe = value; }

        #endregion

        #region constructores

        public EntidadHorario(bool dia_lunes, bool dia_martes, bool dia_miercoles, bool dia_jueves, bool dia_viernes, bool dia_sabado, bool dia_domingo, TimeSpan hora_inicio, TimeSpan hora_fin, bool existe)
        {
            this.dia_lunes = dia_lunes;
            this.dia_martes = dia_martes;
            this.dia_miercoles = dia_miercoles;
            this.dia_jueves = dia_jueves;
            this.dia_viernes = dia_viernes;
            this.dia_sabado = dia_sabado;
            this.dia_domingo = dia_domingo;
            this.hora_inicio = hora_inicio;
            this.hora_fin = hora_fin;
            this.existe = existe;
        }

        public EntidadHorario()
        {
            this.dia_lunes = false;
            this.dia_martes = false;
            this.dia_miercoles = false;
            this.dia_jueves = false;
            this.dia_viernes = false;
            this.dia_sabado = false;
            this.dia_domingo = false;
            this.hora_inicio = new TimeSpan();
            this.hora_fin = new TimeSpan();
            this.existe = false;
        }

        #endregion

        #region Método abstracto 

        // Este método no tiene nada pero se puede implementar la clase que lo hereda, es caracterizado por no tener los {}
        //public abstract int Insertar();

        //public abstract int Modificar();

        //public abstract DataSet listarHorarios();

        //public abstract int eliminarHorario();

        #endregion
    }
}
