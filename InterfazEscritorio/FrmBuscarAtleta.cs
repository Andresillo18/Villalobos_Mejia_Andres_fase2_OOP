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

        public List<EntidadAtleta> listarAtletas(String condicion)
        {
            List<EntidadAtleta> listaAtletas; //Se inicializa lo que se creará
            DataSet TablaDS = new DataSet();

            SqlConnection conexion = new SqlConnection(Configuracion.getConnectionString);
            SqlDataAdapter adaptador;

            String sentencia = "SELECT COD_ATLETA,ID_ATLETA, NOMBRE_ATLETA, APELLIDO1_ATLETA, FECHA_NACIMIENTO_ATLETA FROM ATLETAS";

            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = string.Format("{0} WHERE {1}", sentencia, condicion); //Format funciona para concatenar variables
            }

            try
            {
                adaptador = new SqlDataAdapter(sentencia, conexion); // Aquí se usa el adaptador para unirse BD 
                adaptador.Fill(TablaDS, "atletas"); // Se llena el DataSer con la BD

                //***Sentencia linQ para convertir el DataSet en una lista 
                listaAtletas = (from DataRow fila in TablaDS.Tables["atletas"].Rows
                                select new EntidadAtleta()
                                {
                                    Cod_atleta = (int)fila[0],
                                    Identificacion = fila[1].ToString(),
                                    Nombre = fila[2].ToString(),
                                    Apellido1 = fila[3].ToString(),                                                                    
                                    Fecha_nacimiento = Convert.ToDateTime(fila[4]),
                               
                                }).ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return listaAtletas;
        }

        #region Método CargarListaArray

        private void CargarListaArray(string condicion = "")
        { 
            List<EntidadAtleta> atletas;

            try
            {
                atletas= listarAtletas(condicion);
                if (atletas.Count > 0) //si la lista tiene algo entonces...
                {
                    grdListaAtletas.DataSource = atletas;//cargue en el datagridview lo que tiene la lista
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
            if (grdListaAtletas.SelectedRows.Count > 0) //si ha seleccionado una fila
            {
                cod_atleta = (int)grdListaAtletas.SelectedRows[0].Cells[0].Value;
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
