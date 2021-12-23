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
            txtProvincia.Clear();
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
            }

            //En este caso no es necesario el txtCod
            //modAbierto.Cod_mod_abierto = Convert.ToInt32(txtCod.Text);
            entrenador.Cod_entrenador = Convert.ToInt32(txtCodEntrenador.Text);
            entrenador.Nombre = txtNombre.Text;
            entrenador.Apellido1= txtApellido1.Text;
            entrenador.Apellido2 = txtApellido2.Text;
            entrenador.Telefono1 = txtTelefono1.Text;
            entrenador.Telefono2 = txtTelefono2.Text;
            entrenador.Correo= txtEmail.Text;
            entrenador.Fecha_nacimiento = Convert.ToDateTime(DTFechaNacimie.Value);
            entrenador.Provincia= txtProvincia.Text;
            entrenador.Distrito= txtDistrito.Text;
            entrenador.Canton= txtCanton.Text;

            return entrenador;
        }
        #endregion

        #region Método para mostrar los registro regresados por la BD en el DataGridView

        private void MostrarListDS(string condicion = "", string orden = "")
        {
            BLEntrenador logica = new BLEntrenador(Configuracion.getConnectionString);
            DataSet DSModulosAbier;

            try
            {
                DSModulosAbier = logica.listarEntrenadores(condicion, orden); // Retorna un DataSet
                grdListaEntrenadores.DataSource = DSModulosAbier; // Le ingresa a la fuente de la DataGridView el DataSet para mostrarlo

                grdListaEntrenadores.DataMember = DSModulosAbier.Tables["entrenadores"].TableName;// Especifica el nombre de la tabla del DataSet
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
                    txtEmail.Text = entrenador.Correo;
                    DTFechaNacimie.Value = entrenador.Fecha_nacimiento;
                    txtProvincia.Text = entrenador.Provincia;
                    txtDistrito.Text = entrenador.Distrito;
                    txtCanton.Text = entrenador.Canton;
                    if (RBActivo.Checked)
                    {
                        entrenador.Estado = true;
                    }
                    else
                    {
                        entrenador.Estado = false;
                    }                   

                    entrenadorRegistrado =entrenador;
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

        private void FrmEntrenadores_Load(object sender, EventArgs e)
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
            BLModAbier logica = new BLModAbier(Configuracion.getConnectionString);
            EntidadModAbier modAbierto;
            int elResultado = 0;

            try
            {
                // Hace que todos los campos sean obligatorios
                if (!string.IsNullOrEmpty(txtCod_Entrenador.Text) && !string.IsNullOrEmpty(txtCod_Modulo.Text) && !string.IsNullOrEmpty(txtHorarioModulos.Text))
                {
                    modAbierto = GenerarEntidad();
                    if (!modAbierto.Existe)
                    {
                        //MessageBox.Show(modulosPrograma.Cod_modulo.ToString());
                        elResultado = logica.Insertar(modAbierto);
                    }
                    else
                    {
                        elResultado = logica.Modificar(modAbierto);
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
    }
}
