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
    public partial class FrmHorarMod : Form
    {
        EntidadHorarMod horarioRegistrado;

        public FrmHorarMod()
        {
            InitializeComponent();
        }

        #region Método para limpiar los campos

        private void limpiar()
        {
            txtCodHorMod.Clear();
            DTInicioHorar.ResetText();
            DTFinHorar.ResetText();
            CBLunes.Checked = false;
            CBMartes.Checked = false;
            CBMiercoles.Checked = false;
            CBJueves.Checked = false;
            CBViernes.Checked = false;
            CBSabado.Checked = false;
            CBDomingo.Checked = false;
        }

        #endregion

        #region Método para generar una entidad

        private EntidadHorarMod GenerarEntidad()
        {
            EntidadHorarMod horarioMod;
            if (!string.IsNullOrEmpty(txtCodHorMod.Text))
            {
                horarioMod = horarioRegistrado; // no se genera una entidad nueva, sino 
                //MessageBox.Show("Test2");
                horarioMod.Existe = true; // Si ya ha seleccionado un registro este pasa a que ya existe para ser modificado
            }
            else
            {
                horarioMod = new EntidadHorarMod();
            }

            //En este caso no es necesario el txtCodHorMod
            //Pregunta cuales estan marcadas de los checkboxs y los guarda en la entidad los datos
            if (CBLunes.Checked)
            {
                horarioMod.Dia_lunes = true;
            }
            else
            {
                horarioMod.Dia_lunes = false;
            }

            if (CBMartes.Checked)
            {
                horarioMod.Dia_martes = true;
            }
            else
            {
                horarioMod.Dia_martes = false;
            }

            if (CBMiercoles.Checked)
            {
                horarioMod.Dia_miercoles = true;
            }
            else
            {
                horarioMod.Dia_miercoles = false;
            }

            if (CBJueves.Checked)
            {
                horarioMod.Dia_jueves = true;
            }
            else
            {
                horarioMod.Dia_jueves = false;
            }

            if (CBViernes.Checked)
            {
                horarioMod.Dia_viernes = true;
            }
            else
            {
                horarioMod.Dia_viernes = false;
            }

            if (CBSabado.Checked)
            {
                horarioMod.Dia_sabado = true;
            }
            else
            {
                horarioMod.Dia_sabado = false;
            }

            if (CBDomingo.Checked)
            {
                horarioMod.Dia_domingo = true;
            }
            else
            {
                horarioMod.Dia_domingo = false;
            }

            horarioMod.Hora_inicio = DTInicioHorar.Value.TimeOfDay;
            horarioMod.Hora_fin = DTFinHorar.Value.TimeOfDay;

            return horarioMod;
        }
        #endregion

        #region Método para mostrar los registro regresados por la BD en el DataGridView

        private void MostrarListDS(string condicion = "", string orden = "")
        {
            BLHorarMod logica = new BLHorarMod(Configuracion.getConnectionString);
            DataSet DSHorarMod;

            try
            {
                DSHorarMod = logica.listarHorario(condicion, orden); // Retorna un DataSet
                dgvHorarMod.DataSource = DSHorarMod; // Le ingresa a la fuente de la DataGridView el DataSet para mostrarlo

                dgvHorarMod.DataMember = DSHorarMod.Tables["HorarioMod"].TableName;// Especifica el nombre de la tabla del DataSet
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Método para cargar los datos de un programa en los textBoxs

        private void cargarHorarioMod(int cod)
        {
            EntidadHorarMod horarioMod;
            BLHorarMod logica = new BLHorarMod(Configuracion.getConnectionString);

            try
            {
                horarioMod = logica.ObtenerHorario(cod);
                if (horarioMod != null) // Si obtuvó algo
                {
                    txtCodHorMod.Text = horarioMod.Cod_Horario_Modulos.ToString();

                    // Aquí pregunta que si en la entidad esta TRUE que marque la casilla, sino la desmarca según el evento doubleClick**
                    if (horarioMod.Dia_lunes == true)
                    {
                        CBLunes.Checked = true;
                    }
                    else
                    {
                        CBLunes.Checked = false;
                    }

                    if (horarioMod.Dia_martes == true)
                    {
                        CBMartes.Checked = true;
                    }
                    else
                    {
                        CBMartes.Checked = false;
                    }
                    if (horarioMod.Dia_miercoles == true)
                    {
                        CBMiercoles.Checked = true;
                    }
                    else
                    {
                        CBMiercoles.Checked = false;
                    }

                    if (horarioMod.Dia_jueves == true)
                    {
                        CBJueves.Checked = true;
                    }
                    else
                    {
                        CBJueves.Checked = false;
                    }

                    if (horarioMod.Dia_viernes == true)
                    {
                        CBViernes.Checked = true;
                    }
                    else
                    {
                        CBViernes.Checked = false;
                    }

                    if (horarioMod.Dia_sabado == true)
                    {
                        CBSabado.Checked = true;
                    }
                    else
                    {
                        CBSabado.Checked = false;
                    }

                    if (horarioMod.Dia_domingo == true)
                    {
                        CBDomingo.Checked = true;
                    }
                    else
                    {
                        CBDomingo.Checked = false;
                    }

                    // Convierte el tiempo de tipo time(0) en SQL a datetime para que se pueda leer
                    DTInicioHorar.Value = Convert.ToDateTime(horarioMod.Hora_inicio.ToString()); 
                    DTFinHorar.Value = Convert.ToDateTime(horarioMod.Hora_fin.ToString());

                    horarioRegistrado = horarioMod;
                }
                else
                {
                    MessageBox.Show("El Módulo seleccionado no se encuentra en la Base de Datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnCrear_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void FrmHorarMod_Load(object sender, EventArgs e)
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
            BLHorarMod logica = new BLHorarMod(Configuracion.getConnectionString);
            EntidadHorarMod horarioMod;
            int elResultado = 0;

            try
            {
                // en este caso un usuario puede guardar los datos sin ser obligatorios
                horarioMod = GenerarEntidad();
                if (!horarioMod.Existe)
                {
                    //MessageBox.Show(modulosPrograma.Cod_modulo.ToString());
                    elResultado = logica.Insertar(horarioMod);
                }
                else
                {
                    elResultado = logica.Modificar(horarioMod);
                    MessageBox.Show("Test");
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EntidadHorarMod horarMod;
            int resultado; // Lo que retornará los métodos al obtener un progreso
            BLHorarMod logica = new BLHorarMod(Configuracion.getConnectionString);

            try
            {
                if (!String.IsNullOrEmpty(txtCodHorMod.Text)) //Debe tener datos en los txtboxs para poder eliminar
                {
                    //busca primero el programa antes de borrarlo para ver si existe
                    horarMod = logica.ObtenerHorario(Convert.ToInt32(txtCodHorMod.Text));

                    if (horarMod != null)
                    {
                        MessageBox.Show($"Esta seguro que lo desea eliminar?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                        resultado = logica.EliminarHorarioMod(Convert.ToInt32(txtCodHorMod.Text)); // Si pudo encontralo lo borra

                        MessageBox.Show($"Se han afectado {resultado} registros", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar();
                        MostrarListDS();
                    }
                    else
                    {
                        MessageBox.Show("El módulo no existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    // No se sucede nada si no lo selecciona
                    MessageBox.Show("Debe Seleccionar un módulo antes de eliminar algo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dgvHorarMod_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int cod = 0;
            try
            {
                cod = (int)dgvHorarMod.SelectedRows[0].Cells[0].Value;
                cargarHorarioMod(cod);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion
    }
}
