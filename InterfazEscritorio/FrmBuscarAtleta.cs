using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient; // UTILIZAR ADO .NET
using System.Linq;

using CapaLogicaNegocio;
using CapaEntidades;

namespace InterfazEscritorio
{
    public partial class FrmBuscarAtleta : Form
    {
        // Crear un nuevo evento para el formulario:
        public event EventHandler Aceptar;

        int cod_atleta;

        public FrmBuscarAtleta()
        {
            InitializeComponent();
        }

        #region Método CargarListaArray

        private void CargarListaArray(string condicion = "")
        {
            BLAtleta logica = new BLAtleta(Configuracion.getConnectionString);
            List<EntidadAtleta> atletas;

            try
            {
                atletas= logica.listarAtletas(condicion);
                if (atletas.Count > 0) //si la lista tiene algo entonces...
                {
                    grdAtletas.DataSource = atletas;//cargue en el datagridview lo que tiene la lista
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Método Seleccionar el ID de una fila

        private void Seleccionar()
        {
            if (grdAtletas.SelectedRows.Count > 0) //si ha seleccionado una fila
            {
                cod_atleta = (int)grdAtletas.SelectedRows[0].Cells[0].Value;
                Aceptar(cod_atleta, null);
                //le manda el id al evento aceptar que esta en el otro form
                Close();
            }
        }

        #endregion

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //No le envia nada si se cancela (el segundo parámetro es requerido, por eso se envia nulo)
            Aceptar(-1, null);
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Seleccionar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string condicion = string.Empty;
            //condicion que se usara para realizar el filtrado en los datos para recuperar el cliente deseado
            try
            {
                if (!string.IsNullOrEmpty(txtNombre.Text))//si no esta vacio
                {
                    //Es una consulta SQL con condición, para saber si hay algún nombre con lo escrito
                    condicion = string.Format("NOMBRE_ATLETA like '%{0}%'", txtNombre.Text.Trim()); // El .trim quita los espacios al rededor                    
                }

                CargarListaArray(condicion);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
