using System;

namespace CapaEntidades
{
    public class EntidadPrograma
    {
        #region Atributos

        private int cod_programa; // Aquí si se crea algo referente al campo IDENTITY porque esta Entidad funciona para mover datos
        private string nombre_programa;
        private string descripcion_programa;
        private string estado;
        private int cupo_programa;
        private string telefono_programa;
        private string email_programa;
        private string provincia_programa;
        private DateTime fecha_inicio_programa;
        private string observaciones_programa;
        private bool existe;

        #endregion

        #region Propiedades

        public int Cod_programa { get => cod_programa; set => cod_programa = value; }
        public string Nombre_programa { get => nombre_programa; set => nombre_programa = value; }
        public string Descripcion_programa { get => descripcion_programa; set => descripcion_programa = value; }
        public string Estado { get => estado; set => estado = value; }
        public int Cupo_programa { get => cupo_programa; set => cupo_programa = value; }
        public string Telefono_programa { get => telefono_programa; set => telefono_programa = value; }
        public string Email_programa { get => email_programa; set => email_programa = value; }
        public string Provincia_programa { get => provincia_programa; set => provincia_programa = value; }
        public DateTime Fecha_inicio_programa { get => fecha_inicio_programa; set => fecha_inicio_programa = value; }
        public string Observaciones_programa { get => observaciones_programa; set => observaciones_programa = value; }
        public bool Existe { get => existe; set => existe = value; }

        #endregion

        #region Constructores

        public EntidadPrograma(int cod_programa, string nombre_programa, string descripcion_programa, string estado, int cupo_programa, string telefono_programa, string email_programa, string provincia_programa, DateTime fecha_inicio_programa, string observaciones_programa)
        {
            this.cod_programa = cod_programa;
            this.nombre_programa = nombre_programa;
            this.descripcion_programa = descripcion_programa;
            this.estado = estado;
            this.cupo_programa = cupo_programa;
            this.telefono_programa = telefono_programa;
            this.email_programa = email_programa;
            this.provincia_programa = provincia_programa;
            this.fecha_inicio_programa = fecha_inicio_programa;
            this.observaciones_programa = observaciones_programa;
            this.existe = true;
        }


        public EntidadPrograma()
        {
            this.cod_programa = 0;
            this.nombre_programa = string.Empty;
            this.descripcion_programa = string.Empty;
            this.estado = string.Empty;
            this.cupo_programa = 0;
            this.telefono_programa = string.Empty;
            this.email_programa = string.Empty;
            this.provincia_programa = string.Empty;
            this.fecha_inicio_programa = new DateTime(); ;
            this.observaciones_programa = string.Empty;
            this.existe = false;
        }
        #endregion

        // No hay necesidad de crear métodos porque las entidades solo funcionan para mover información
    }
}
