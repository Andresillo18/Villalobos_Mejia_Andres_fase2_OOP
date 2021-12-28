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
    public partial class FrmIncapEventos : Form
    {
        EntidadIncapEvent incapEventRegistrado;

        public FrmIncapEventos()
        {
            InitializeComponent();
        }


        #region Método para limpiar los campos

        private void limpiar()
        {
            txtCodIncapEvent.Clear();
            txtCodEntrenador.Clear();
            DTInicio.ResetText();
            DTFin.ResetText();
            txtObserv.Clear();
        }

        #endregion

        #region Método para generar una entidad

        private EntidadIncapEvent GenerarEntidad()
        {
            EntidadIncapEvent incapEvent;
            if (!string.IsNullOrEmpty(txtCodIncapEvent.Text))
            {
                incapEvent = incapEventRegistrado; // no se genera una entidad nueva
                incapEvent.Existe = true; // Si ya ha seleccionado un registro este pasa a que ya existe para ser modificado
            }
            else
            {
                incapEvent = new EntidadIncapEvent();
            }

            //En este caso no es necesario el txtCodHorMod
            //Pregunta cuales estan marcadas de los checkboxs y los guarda en la entidad los datos

            incapEvent.Cod_entrenador = Convert.ToInt32(txtCodEntrenador.Text);
            incapEvent.Dia_inicio_IE = DTInicio.Value;
            incapEvent.Dia_fin_IE = DTFin.Value;
            incapEvent.Observaciones = txtObserv.Text;

            return incapEvent;
        }
        #endregion

        #region Método para mostrar los registro regresados por la BD en el DataGridView

        private void MostrarListDS(string condicion = "", string orden = "")
        {
            BLIncapEvent logica = new BLIncapEvent(Configuracion.getConnectionString);
            DataSet DSIncapEvent;

            try
            {
                DSIncapEvent = logica.listarIncapEvent(condicion, orden); // Retorna un DataSet
                dgvIncapEvent.DataSource = DSIncapEvent; // Le ingresa a la fuente de la DataGridView el DataSet para mostrarlo

                dgvIncapEvent.DataMember = DSIncapEvent.Tables["incapacidades_eventos"].TableName;// Especifica el nombre de la tabla del DataSet
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Método para cargar los datos de un programa en los textBoxs

        private void cargarIncapEvent(int cod)
        {
            EntidadIncapEvent incapEvent;
            BLIncapEvent logica = new BLIncapEvent(Configuracion.getConnectionString);

            try
            {
                incapEvent = logica.ObtenerIncapEvent(cod);
                if (incapEvent != null) // Si obtuvó algo
                {
                    txtCodIncapEvent.Text = incapEvent.Cod_incap_event.ToString();
                    txtCodEntrenador.Text = incapEvent.Cod_entrenador.ToString();

                    DTInicio.Value = incapEvent.Dia_inicio_IE;
                    DTFin.Value = incapEvent.Dia_fin_IE;
                    txtObserv.Text = incapEvent.Observaciones;

                    incapEventRegistrado = incapEvent;
                }
                else
                {
                    MessageBox.Show("La incapacidad o Evento seleccionado no se encuentra en la Base de Datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarListDS();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #endregion

        #region Eventos

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmEntrenadores FrmEntrenadores = new FrmEntrenadores();
            FrmEntrenadores.Show();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void FrmIncapEventos_Load(object sender, EventArgs e)
        {
            try
            {
                MostrarListDS();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            BLIncapEvent logica = new BLIncapEvent(Configuracion.getConnectionString);
            EntidadIncapEvent incapEvent;
            int elResultado = 0;

            try
            {
                if (!string.IsNullOrEmpty(txtCodEntrenador.Text))
                {
                    // en este caso un usuario puede guardar los datos sin ser obligatorios
                    incapEvent = GenerarEntidad();
                    if (!incapEvent.Existe)
                    {
                        //MessageBox.Show(modulosPrograma.Cod_modulo.ToString());
                        elResultado = logica.Insertar(incapEvent);
                    }
                    else
                    {
                        elResultado = logica.Modificar(incapEvent);
                    }

                    if (elResultado > 0) // Si retorna algo alguna función se completa la acción
                    {
                        limpiar();

                        MessageBox.Show("Operación exitosa!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarListDS();
                    }
                    else
                    {
                        MessageBox.Show("No se pudó realizar la modificación correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("El campo de refencia del entrenador es obligatorio o el entrenador debe tener algún certificado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EntidadIncapEvent incapEvent;
            int resultado; // Lo que retornará los métodos al obtener un progreso
            BLIncapEvent logica = new BLIncapEvent(Configuracion.getConnectionString);

            try
            {
                if (!String.IsNullOrEmpty(txtCodIncapEvent.Text) && !String.IsNullOrEmpty(txtCodEntrenador.Text)) //Debe tener datos en los txtboxs para poder eliminar
                {
                    //busca primero el programa antes de borrarlo para ver si existe
                    incapEvent = logica.ObtenerIncapEvent(Convert.ToInt32(txtCodIncapEvent.Text));

                    if (incapEvent != null)
                    {
                        MessageBox.Show($"Esta seguro que lo desea eliminar?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                        resultado = logica.EliminarIncapEvent(Convert.ToInt32(txtCodIncapEvent.Text)); // Si pudo encontralo lo borra

                        MessageBox.Show($"Se han afectado {resultado} registros", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar();
                        MostrarListDS();
                    }
                    else
                    {
                        MessageBox.Show("La Incapacidad o Evento no existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    // No se sucede nada si no lo selecciona
                    MessageBox.Show("Debe Seleccionar un registro antes de eliminar algo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dgvIncapEvent_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int cod = 0;

            //MessageBox.Show("Campo 0: " + Convert.ToString(dgvIncapEvent.SelectedRows[0].Cells[0].Value));
            //MessageBox.Show("Campo 1: " + Convert.ToString(dgvIncapEvent.SelectedRows[0].Cells[1].Value));
            //MessageBox.Show("Campo 2: " + Convert.ToString(dgvIncapEvent.SelectedRows[0].Cells[2].Value));
            //MessageBox.Show("Campo 3: " + Convert.ToString(dgvIncapEvent.SelectedRows[0].Cells[3].Value));
            //MessageBox.Show("Campo 4: " + Convert.ToString(dgvIncapEvent.SelectedRows[0].Cells[4].Value));
            //MessageBox.Show("Campo 5: " + Convert.ToString(dgvIncapEvent.SelectedRows[0].Cells[5].Value));
            try
            {
                cod = (int)dgvIncapEvent.SelectedRows[0].Cells[1].Value;
                cargarIncapEvent(cod);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            #endregion

        }
    }
}
