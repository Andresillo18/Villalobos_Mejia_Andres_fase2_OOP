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

        #region Método para generar una entidad

        private EntidadadPrograma GenerarEntidad()
        {
            EntidadadPrograma programa;
            if (!string.IsNullOrEmpty(txtCod.Text))
            {
                programa = programaRegistrado; // Como ya fue seleccionado un programa, ese será modificado 
            }
            else
            {
                programa = new EntidadadPrograma();
            }

            //La casilla selecciona la transforma para que la entidad la entienda
            string checkedOrNot = "";
            if (RDActivo.Checked)
            {
                checkedOrNot = "Activo";
            }
            else
            {
                checkedOrNot = "Inactivo";
            }

            programa.Nombre_programa = txtNombre.Text;
            programa.Descripcion_programa = txtDescripcion.Text;
            programa.Estado = checkedOrNot;
            programa.Cupo_programa = Convert.ToInt32(txtCupo.Text);
            programa.Telefono_programa = txtTelefono.Text;
            programa.Email_programa = txtEmail.Text;
            programa.Provincia_programa = txtProvincia.Text;
            programa.Fecha_inicio_programa = DTFechaInicio.Value;
            programa.Observaciones_programa = txtObservaciones.Text;
            //programa.Existe = true;

            return programa;
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
            txtEmail.Clear();
            txtProvincia.Clear();
            DTFechaInicio.ResetText(); //**refresh
            txtObservaciones.Clear();
        }

        #endregion

        #region Método para mostrar los registro regresados por la BD en el DataGridView

        // Se envian parámetros default porque no se sabe cuando se usarán
        private void MostrarListDS(string condicion = "", string orden = "")
        {
            BLPrograma logica = new BLPrograma(Configuracion.getConnectionString); // Siempre se llama a la cama que esta abajo si es que se ocupa usar algo de la BD
            DataSet DSPrograma;

            try
            {
                DSPrograma = logica.listarProgramas(condicion, orden); // Retorna un DataSet
                grdListaProgramas.DataSource = DSPrograma; // Le ingresa a la fuente de la DataGridView el DataSet para mostrarlo

                grdListaProgramas.DataMember = DSPrograma.Tables["Programas"].TableName;// Especifica el nombre de la tabla del DataSet
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Método para cargar los datos de un programa en los textBoxs

        private void cargarElPrograma(int cod)
        {
            EntidadadPrograma programa;
            BLPrograma logica = new BLPrograma(Configuracion.getConnectionString);

            try
            {
                programa = logica.ObtenerPrograma(cod); // retorna los datos según el código del programa

                if (programa != null) // Si obtuvó algo
                {
                    txtCod.Text = programa.Cod_programa.ToString();
                    txtNombre.Text = programa.Nombre_programa;
                    txtDescripcion.Text = programa.Descripcion_programa;
                    RDActivo.Checked = true;
                    txtCupo.Text = programa.Cupo_programa.ToString();
                    txtTelefono.Text = programa.Telefono_programa;
                    txtEmail.Text = programa.Email_programa;
                    txtProvincia.Text = programa.Provincia_programa;
                    DTFechaInicio.Value = programa.Fecha_inicio_programa;
                    txtObservaciones.Text = programa.Observaciones_programa;

                    programaRegistrado = programa;
                }
                else
                {
                    MessageBox.Show("El programa seleccionado no se encuentra en la Base de Datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void FrmProgramas_Load(object sender, EventArgs e)
        {
            RDInactivo.Select(); // Seleccion una de las opciones de radio

            txtNombre.Select();

            try
            {
                MostrarListDS();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            BLPrograma logica = new BLPrograma(Configuracion.getConnectionString);// Se le crea un objeto de la clase lógica y se le pasa la conexión
            EntidadadPrograma programa;
            int elResultado;

            try
            {
                // Hace que todos los campos sean obligatorios
                if (!string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtDescripcion.Text) && !string.IsNullOrEmpty(txtDescripcion.Text) && !string.IsNullOrEmpty(txtCupo.Text) && !string.IsNullOrEmpty(txtTelefono.Text) )
                {
                    programa = GenerarEntidad();
                    if (!programa.Existe)
                    {
                        elResultado = logica.Insertar(programa);
                    }
                    else
                    {
                        elResultado = logica.Modificar(programa);
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
                    MessageBox.Show("Los datos son obligatorios", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                //**No se ocupa el throw más porque no se enviará a ninguna parte si hay una excepción, por eso se le avisa al usuario lo sucedido
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void grdListaProgramas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int cod = 0;
            try
            {
                //Para saber que tiene cada espacio
                //MessageBox.Show("Campo 0: " + Convert.ToString(grdListaProgramas.SelectedRows[0].Cells[0].Value));
                //MessageBox.Show("Campo 1: " + Convert.ToString(grdListaProgramas.SelectedRows[0].Cells[1].Value));
                //MessageBox.Show("Campo 2: " + Convert.ToString(grdListaProgramas.SelectedRows[0].Cells[2].Value));
                //MessageBox.Show("Campo 3: " + Convert.ToString(grdListaProgramas.SelectedRows[0].Cells[3].Value));
                //MessageBox.Show("Campo 4: " + Convert.ToString(grdListaProgramas.SelectedRows[0].Cells[4].Value));
                //MessageBox.Show("Campo 5: " + Convert.ToString(grdListaProgramas.SelectedRows[0].Cells[5].Value));
                //MessageBox.Show("Campo 6: " + Convert.ToString(grdListaProgramas.SelectedRows[0].Cells[6].Value));
                //MessageBox.Show("Campo 7: " + Convert.ToString(grdListaProgramas.SelectedRows[0].Cells[7].Value));
                //MessageBox.Show("Campo 8: " + Convert.ToString(grdListaProgramas.SelectedRows[0].Cells[8].Value));
                //MessageBox.Show("Campo 9: " + Convert.ToString(grdListaProgramas.SelectedRows[0].Cells[9].Value));

                cod = (int)grdListaProgramas.SelectedRows[0].Cells[1].Value; //Se toma la primera columna de la fila seleccionada
                cargarElPrograma(cod);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EntidadadPrograma programa;
            int resultado; // Lo que retornará los métodos al obtener un progreso
            BLPrograma logica = new BLPrograma(Configuracion.getConnectionString);

            try
            {
                if (!String.IsNullOrEmpty(txtCod.Text)) //Debe tener datos en los txtboxs para poder eliminar
                {
                    //busca primero el programa antes de borrarlo para ver si existe
                    programa = logica.ObtenerPrograma(Convert.ToInt32(txtCod.Text));

                    if (programa != null)
                    {
                        MessageBox.Show($"Esta seguro que lo desea eliminar?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                        resultado = logica.EliminarPrograma(Convert.ToInt32(txtCod.Text)); // Si pudo encontralo lo borra

                        MessageBox.Show($"Se han afectado {resultado} registros", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar();
                        MostrarListDS();
                    }
                    else
                    {
                        MessageBox.Show("El cliente no existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    // No se sucede nada si no lo selecciona
                    MessageBox.Show("Debe Seleccionar un programa antes de eliminar algo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        #endregion

    }
}
