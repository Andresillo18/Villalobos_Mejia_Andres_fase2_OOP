using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaEntidades;
using CapaLogicaNegocio;

namespace InterfazEscritorio
{
    public partial class FrmProgramas : Form
    {
        EntidadadPrograma programaRegistrado; // Cargará los datos de un programa en los campos

        public FrmProgramas()
        {
            InitializeComponent();
        }

        #region Eventos

        private void FrmProgramas_Load(object sender, EventArgs e)
        {
            RDInactivo.Select(); // Seleccion una de las opciones de radio
        }

        #endregion

        #region Método para limpiar los campos

        private void limpiar()
        {
            txtCod.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtCupo.Clear();
            txtTelefono.Clear();
            txtProvincia.Clear();
            DTFechaInicio.ResetText(); //**refresh
            txtObservaciones.Clear();
        }

        #endregion
    }
}
