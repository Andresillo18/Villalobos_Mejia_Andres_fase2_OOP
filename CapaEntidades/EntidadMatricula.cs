using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class EntidadMatricula
    {
        #region Atributos

        private int cod_matricula;
        private int cod_atleta;
        private int cod_mod_abierto;
        private DateTime fecha_matri;
        private string estado;
        private decimal nota_final;
        private int monto_cancelado;
        private string tipo_cobro;
        private string tipo_pago;
        private bool actividad;     

        #endregion

        #region Propiedades

        public int Cod_atleta { get => cod_atleta; set => cod_atleta = value; }
        public int Cod_mod_abierto { get => cod_mod_abierto; set => cod_mod_abierto = value; }
        public DateTime Fecha_matri { get => fecha_matri; set => fecha_matri = value; }
        public string Estado { get => estado; set => estado = value; }
        public decimal Nota_final { get => nota_final; set => nota_final = value; }
        public int Monto_cancelado { get => monto_cancelado; set => monto_cancelado = value; }
        public string Tipo_cobro { get => tipo_cobro; set => tipo_cobro = value; }
        public string Tipo_pago { get => tipo_pago; set => tipo_pago = value; }
        public bool Actividad { get => actividad; set => actividad = value; }
        public int Cod_matricula { get => cod_matricula; set => cod_matricula = value; }

        #endregion

        #region Contructores

        public EntidadMatricula(int cod_atleta, int cod_mod_abierto, DateTime fecha_matri, string estado, decimal nota_final, int monto_cancelado, string tipo_cobro, string tipo_pago, bool actividad, int cod_matricula)
        {
            this.cod_atleta = cod_atleta;
            this.cod_mod_abierto = cod_mod_abierto;
            this.fecha_matri = fecha_matri;
            this.estado = estado;
            this.nota_final = nota_final;
            this.monto_cancelado = monto_cancelado;
            this.tipo_cobro = tipo_cobro;
            this.tipo_pago = tipo_pago;
            this.actividad = actividad;
            this.cod_matricula = cod_matricula;
        }

        public EntidadMatricula()
        {
            this.cod_atleta = 0;
            this.cod_mod_abierto = 0;
            this.fecha_matri = new DateTime();
            this.estado = string.Empty;
            this.nota_final = 0;
            this.monto_cancelado = 0;
            this.tipo_cobro = string.Empty;
            this.tipo_pago = string.Empty;
            this.actividad = false;
            this.cod_matricula = 0;
        }
        #endregion
    }
}
