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
    public partial class FrmEntrenadores : Form
    {
        EntidadEntrenador entrenadorRegistrado; //Variable global
        public FrmEntrenadores()
        {
            InitializeComponent();
        }

        #region Método para limpiar los campos

        private void limpiar()
        {
            txtCodEntrenador.Clear();
            txtID.Clear();
            txtNombre.Clear();
            txtApellido1.Clear();
            txtApellido2.Clear();
            txtTelefono1.Clear();
            txtTelefono2.Clear();
            txtEmail.Clear();
            DTFechaNacimie.ResetText();
            txtProvincia.Text = "";
            txtDistrito.Clear();
            txtCanton.Clear();
            txtDistrito.Clear();
            RBInactivo.Select();
        }

        #endregion

        #region Método para generar una entidad

        private EntidadEntrenador GenerarEntidad()
        {
            EntidadEntrenador entrenador;
            if (!string.IsNullOrEmpty(txtCodEntrenador.Text))
            {
                entrenador = entrenadorRegistrado; // Como ya fue seleccionado un programa, ese será modificado 
            }
            else
            {
                entrenador = new EntidadEntrenador();
                //MessageBox.Show("Test2");
            }

            //En este caso no es necesario el txtCodEntrenador            
            //entrenador.Cod_entrenador = Convert.ToInt32(txtCodEntrenador.Text);
            entrenador.Identificacion = txtID.Text;
            entrenador.Nombre = txtNombre.Text;
            entrenador.Apellido1 = txtApellido1.Text;
            entrenador.Apellido2 = txtApellido2.Text;
            entrenador.Telefono1 = txtTelefono1.Text;
            entrenador.Telefono2 = txtTelefono2.Text;
            entrenador.Correo = txtEmail.Text;
            entrenador.Fecha_nacimiento = Convert.ToDateTime(DTFechaNacimie.Value);
            entrenador.Provincia = txtProvincia.Text;
            entrenador.Distrito = txtDistrito.Text;
            entrenador.Canton = txtCanton.Text;

            return entrenador;
        }
        #endregion

        #region Método para mostrar los registro regresados por la BD en el DataGridView

        private void MostrarListDS(string condicion = "", string orden = "")
        {
            BLEntrenador logica = new BLEntrenador(Configuracion.getConnectionString);
            DataSet DSEntrenadores;

            try
            {
                DSEntrenadores = logica.listarEntrenadores(condicion, orden); // Retorna un DataSet
                grdListaEntrenadores.DataSource = DSEntrenadores; // Le ingresa a la fuente de la DataGridView el DataSet para mostrarlo

                grdListaEntrenadores.DataMember = DSEntrenadores.Tables["entrenadores"].TableName;// Especifica el nombre de la tabla del DataSet
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Método para cargar los datos de un programa en los textBoxs

        private void cargarEntrenador(int cod)
        {
            EntidadEntrenador entrenador;
            BLEntrenador logica = new BLEntrenador(Configuracion.getConnectionString);

            try
            {
                entrenador = logica.ObtenerEntrenador(cod);                
                if (entrenador != null) // Si obtuvó algo
                {
                    txtCodEntrenador.Text = entrenador.Cod_entrenador.ToString();
                    txtID.Text = entrenador.Identificacion;
                    txtNombre.Text = entrenador.Nombre;
                    txtApellido1.Text = entrenador.Apellido1;
                    txtApellido2.Text = entrenador.Apellido2;
                    txtTelefono1.Text = entrenador.Telefono1;
                    txtTelefono2.Text = entrenador.Telefono2;
                    txtEmail.Text = entrenador.Correo;
                    DTFechaNacimie.Value = entrenador.Fecha_nacimiento;
                    txtProvincia.Text = entrenador.Provincia;
                    txtDistrito.Text = entrenador.Distrito;
                    txtCanton.Text = entrenador.Canton;
                    // Si en la entidad esta activo el entrenador se activo el RadioButton, sino se pone desactivado
                    if (entrenador.Estado)
                    {
                        RBActivo.Checked = true;
                    }
                    else
                    {
                        RBInactivo.Checked = true;
                    }

                    entrenadorRegistrado = entrenador;
                }
                else
                {
                    MessageBox.Show("El Entrenador seleccionado no se encuentra en la Base de Datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void FrmEntrenadores_Load(object sender, EventArgs e)
        {
            txtID.Select();
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
            BLEntrenador logica = new BLEntrenador(Configuracion.getConnectionString);
            EntidadEntrenador entrenador;
            int elResultado = 0;

            try
            {
                // Hace que todos los campos sean obligatorios
                if (!string.IsNullOrEmpty(txtID.Text) && !string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtApellido1.Text) && !string.IsNullOrEmpty(txtApellido2.Text) && !string.IsNullOrEmpty(txtTelefono1.Text) && !string.IsNullOrEmpty(txtProvincia.Text) && !string.IsNullOrEmpty(txtDistrito.Text) && !string.IsNullOrEmpty(txtDistrito.Text) && !string.IsNullOrEmpty(txtCanton.Text))
                {
                    entrenador = GenerarEntidad();
                    //MessageBox.Show("Test");
                    if (!entrenador.Estado)
                    {
                        //MessageBox.Show(modulosPrograma.Cod_modulo.ToString());
                        elResultado = logica.Insertar(entrenador);
                    }
                    else
                    {
                        elResultado = logica.Modificar(entrenador);
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
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EntidadEntrenador entrenador;
            int resultado; // Lo que retornará los métodos al obtener un progreso
            BLEntrenador logica = new BLEntrenador(Configuracion.getConnectionString);

            try
            {
                if (!String.IsNullOrEmpty(txtCodEntrenador.Text)) //Debe tener datos en los txtboxs para poder eliminar
                {
                    //busca primero el programa antes de borrarlo para ver si existe
                    entrenador = logica.ObtenerEntrenador(Convert.ToInt32(txtCodEntrenador.Text));

                    if (entrenador != null)
                    {
                        MessageBox.Show($"Esta seguro que lo desea eliminar?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                        resultado = logica.EliminarEntrenador(Convert.ToInt32(txtCodEntrenador.Text)); // Si pudo encontralo lo borra

                        MessageBox.Show($"Se han afectado {resultado} registros", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar();
                        MostrarListDS();
                    }
                    else
                    {
                        MessageBox.Show("El entrenador no existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    // No se sucede nada si no lo selecciona
                    MessageBox.Show("Debe Seleccionar un entrenador antes de eliminar algo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void grdListaEntrenadores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int cod = 0;
            try
            {
                cod = (int)grdListaEntrenadores.SelectedRows[0].Cells[0].Value;
                cargarEntrenador(cod);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion
    }
}
