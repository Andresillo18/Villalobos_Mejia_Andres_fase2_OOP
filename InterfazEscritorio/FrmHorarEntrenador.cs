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
    public partial class FrmHorarEntrenador : Form
    {
        EntidadHorarEntrenador horarioRegistrado;  // Variable global

        public FrmHorarEntrenador()
        {
            InitializeComponent();
        }

        private void FrmHorarEntrenadores_FormClosing(object sender, FormClosingEventArgs e)
        {
            //    FrmMenu menu = new FrmMenu();
            //    MessageBox.Show(menu.TituloForms.ToString());
            //    menu.TituloForms = "tituloForms";
        }

        #region Método para limpiar los campos

        private void limpiar()
        {
            txtCodHorarEntren.Clear();
            txtCodEntrenador.Clear();
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

        private EntidadHorarEntrenador GenerarEntidad()
        {
            EntidadHorarEntrenador horarEntrenador;
            if (!string.IsNullOrEmpty(txtCodHorarEntren.Text))
            {
                horarEntrenador = horarioRegistrado; // no se genera una entidad nueva, sino 
                horarEntrenador.Existe = true; // Si ya ha seleccionado un registro este pasa a que ya existe para ser modificado
            }
            else
            {
                horarEntrenador = new EntidadHorarEntrenador();
            }

            //En este caso no es necesario el txtCodHorMod
            //Pregunta cuales estan marcadas de los checkboxs y los guarda en la entidad los datos

            horarEntrenador.Cod_entrenador = Convert.ToInt32(txtCodEntrenador.Text);
            if (CBLunes.Checked)
            {
                horarEntrenador.Dia_lunes = true;
            }
            else
            {
                horarEntrenador.Dia_lunes = false;
            }

            if (CBMartes.Checked)
            {
                horarEntrenador.Dia_martes = true;
            }
            else
            {
                horarEntrenador.Dia_martes = false;
            }

            if (CBMiercoles.Checked)
            {
                horarEntrenador.Dia_miercoles = true;
            }
            else
            {
                horarEntrenador.Dia_miercoles = false;
            }

            if (CBJueves.Checked)
            {
                horarEntrenador.Dia_jueves = true;
            }
            else
            {
                horarEntrenador.Dia_jueves = false;
            }

            if (CBViernes.Checked)
            {
                horarEntrenador.Dia_viernes = true;
            }
            else
            {
                horarEntrenador.Dia_viernes = false;
            }

            if (CBSabado.Checked)
            {
                horarEntrenador.Dia_sabado = true;
            }
            else
            {
                horarEntrenador.Dia_sabado = false;
            }

            if (CBDomingo.Checked)
            {
                horarEntrenador.Dia_domingo = true;
            }
            else
            {
                horarEntrenador.Dia_domingo = false;
            }

            horarEntrenador.Hora_inicio = DTInicioHorar.Value.TimeOfDay;
            horarEntrenador.Hora_fin = DTFinHorar.Value.TimeOfDay;

            return horarEntrenador;
        }
        #endregion

        #region Método para mostrar los registro regresados por la BD en el DataGridView

        private void MostrarListDS(string condicion = "", string orden = "")
        {
            BLHorarEntrenador logica = new BLHorarEntrenador(Configuracion.getConnectionString);
            DataSet DSHorarEntren;

            try
            {
                DSHorarEntren = logica.listarHorario(condicion, orden); // Retorna un DataSet
                dgvHorarEntrenador.DataSource = DSHorarEntren; // Le ingresa a la fuente de la DataGridView el DataSet para mostrarlo

                dgvHorarEntrenador.DataMember = DSHorarEntren.Tables["HorarEntrenador"].TableName;// Especifica el nombre de la tabla del DataSet
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Método para cargar los datos de un programa en los textBoxs

        private void cargarHorarEntren(int cod)
        {
            EntidadHorarEntrenador horarEntrenador;
            BLHorarEntrenador logica = new BLHorarEntrenador(Configuracion.getConnectionString);

            try
            {
                horarEntrenador = logica.ObtenerHorario(cod);
                if (horarEntrenador != null) // Si obtuvó algo
                {
                    txtCodHorarEntren.Text = horarEntrenador.Cod_Horario_entrenador.ToString();

                    // Aquí pregunta que si en la entidad esta TRUE que marque la casilla, sino la desmarca según el evento doubleClick**

                    txtCodEntrenador.Text = horarEntrenador.Cod_entrenador.ToString();
                    if (horarEntrenador.Dia_lunes == true)
                    {
                        CBLunes.Checked = true;
                    }
                    else
                    {
                        CBLunes.Checked = false;
                    }

                    if (horarEntrenador.Dia_martes == true)
                    {
                        CBMartes.Checked = true;
                    }
                    else
                    {
                        CBMartes.Checked = false;
                    }
                    if (horarEntrenador.Dia_miercoles == true)
                    {
                        CBMiercoles.Checked = true;
                    }
                    else
                    {
                        CBMiercoles.Checked = false;
                    }

                    if (horarEntrenador.Dia_jueves == true)
                    {
                        CBJueves.Checked = true;
                    }
                    else
                    {
                        CBJueves.Checked = false;
                    }

                    if (horarEntrenador.Dia_viernes == true)
                    {
                        CBViernes.Checked = true;
                    }
                    else
                    {
                        CBViernes.Checked = false;
                    }

                    if (horarEntrenador.Dia_sabado == true)
                    {
                        CBSabado.Checked = true;
                    }
                    else
                    {
                        CBSabado.Checked = false;
                    }

                    if (horarEntrenador.Dia_domingo == true)
                    {
                        CBDomingo.Checked = true;
                    }
                    else
                    {
                        CBDomingo.Checked = false;
                    }

                    // Convierte el tiempo de tipo time(0) en SQL a datetime para que se pueda leer
                    DTInicioHorar.Value = Convert.ToDateTime(horarEntrenador.Hora_inicio.ToString());
                    DTFinHorar.Value = Convert.ToDateTime(horarEntrenador.Hora_fin.ToString());

                    horarioRegistrado = horarEntrenador;
                }
                else
                {
                    MessageBox.Show("El Horario seleccionado no se encuentra en la Base de Datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void FrmHorarEntrenadores_Load(object sender, EventArgs e)
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
            BLHorarEntrenador logica = new BLHorarEntrenador(Configuracion.getConnectionString);
            EntidadHorarEntrenador horarEntrenador;
            int elResultado = 0;

            try
            {
                if (!string.IsNullOrEmpty(txtCodEntrenador.Text))
                {
                    // en este caso un usuario puede guardar los datos sin ser obligatorios
                    horarEntrenador = GenerarEntidad();
                    if (!horarEntrenador.Existe)
                    {
                        //MessageBox.Show(modulosPrograma.Cod_modulo.ToString());
                        elResultado = logica.Insertar(horarEntrenador);
                        MessageBox.Show("Test");
                    }
                    else
                    {
                        elResultado = logica.Modificar(horarEntrenador);
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
                    MessageBox.Show("El campo de refencia del entrenador es obligatorio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EntidadHorarEntrenador horarEntrenador;
            int resultado; // Lo que retornará los métodos al obtener un progreso
            BLHorarEntrenador logica = new BLHorarEntrenador(Configuracion.getConnectionString);

            try
            {
                if (!String.IsNullOrEmpty(txtCodHorarEntren.Text)) //Debe tener datos en los txtboxs para poder eliminar
                {
                    //busca primero el programa antes de borrarlo para ver si existe
                    horarEntrenador = logica.ObtenerHorario(Convert.ToInt32(txtCodHorarEntren.Text));

                    if (horarEntrenador != null)
                    {
                        MessageBox.Show($"Esta seguro que lo desea eliminar?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                        resultado = logica.EliminarHorarEntrenador(Convert.ToInt32(txtCodHorarEntren.Text)); // Si pudo encontralo lo borra

                        MessageBox.Show($"Se han afectado {resultado} registros", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar();
                        MostrarListDS();
                    }
                    else
                    {
                        MessageBox.Show("El Horario no existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    // No se sucede nada si no lo selecciona
                    MessageBox.Show("Debe Seleccionar un Horario antes de eliminar algo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dgvHorarEntrenador_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int cod = 0;
            try
            {
                cod = (int)dgvHorarEntrenador.SelectedRows[0].Cells[0].Value;
                cargarHorarEntren(cod);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            FrmEntrenador FrmEntrenadores = new FrmEntrenador();
            FrmEntrenadores.Show();
        }

        #endregion
    }
}
