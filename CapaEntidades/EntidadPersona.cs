using System;
using System.Data.SqlClient; // UTILIZAR ADO .NET
using System.Data; // Se utiliza para el acceso a datos
using System.Linq;
using System.Collections.Generic;
using CapaEntidades;

namespace CapaEntidades
{ // Clase para heredar
    public abstract class EntidadPersona // Se hace abstracta para poder heredarla
    {
        #region Atributos

        private string identificacion;
        private string nombre;
        private string apellido1;
        private string apellido2;
        private string telefono1;
        private string telefono2;
        private string correo;
        private DateTime fecha_nacimiento;
        private string provincia;
        private string distrito;
        private string canton;
        private bool estado;

        #endregion

        #region Propiedades

        public string Identificacion { get => identificacion; set => identificacion = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido1 { get => apellido1; set => apellido1 = value; }
        public string Apellido2 { get => apellido2; set => apellido2 = value; }
        public string Telefono1 { get => telefono1; set => telefono1 = value; }
        public string Telefono2 { get => telefono2; set => telefono2 = value; }
        public string Correo { get => correo; set => correo = value; }
        public DateTime Fecha_nacimiento { get => fecha_nacimiento; set => fecha_nacimiento = value; }
        public string Provincia { get => provincia; set => provincia = value; }
        public string Distrito { get => distrito; set => distrito = value; }
        public string Canton { get => canton; set => canton = value; }
        public bool Estado { get => estado; set => estado = value; }

        #endregion

        #region Constructores

        public EntidadPersona(string identificacion, string nombre, string apellido1, string apellido2, string telefono1, string telefono2, string correo, DateTime fecha_nacimiento, string provincia, string distrito, string canton, bool estado)
        {
            this.identificacion = identificacion;
            this.nombre = nombre;
            this.apellido1 = apellido1;
            this.apellido2 = apellido2;
            this.telefono1 = telefono1;
            this.telefono2 = telefono2;
            this.correo = correo;
            this.fecha_nacimiento = fecha_nacimiento;
            this.provincia = provincia;
            this.distrito = distrito;
            this.canton = canton;
            this.estado = estado;
        }

        public EntidadPersona()
        {
            this.identificacion = string.Empty;
            this.nombre = string.Empty;
            this.apellido1 = string.Empty;
            this.apellido2 = string.Empty;
            this.telefono1 = string.Empty;
            this.telefono2 = string.Empty;
            this.correo = string.Empty;
            this.fecha_nacimiento = new DateTime();
            this.provincia = string.Empty;
            this.distrito = string.Empty;
            this.canton = string.Empty;
            this.estado = false;
        }

        #endregion

        #region Método abstracto 

        // Este método no tiene nada pero se puede implementar la clase que lo hereda, es caracterizado por no tener los {}
        //public abstract int Insertar();

        //public abstract int Modificar();

        //public abstract DataSet listarPersona();

        //public abstract int eliminarPersona();

        #endregion
    }
}
