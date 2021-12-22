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
    public partial class FrmModulosAbie : Form
    {
        EntidadModAbier modRegistrado;
        public FrmModulosAbie()
        {
            InitializeComponent();
        }

        #region Método para limpiar los campos

        private void limpiar()
        {
            txtCod_Modulo.Clear();
            txtCod_Entrenador.Clear();
            txtCod.Clear();
            txtHorarioModulos.Clear();
            DTFechaInicio.ResetText();
            txtObservaciones.Clear();
        }

        #endregion

        #region Método para generar una entidad

        private EntidadModAbier GenerarEntidad()
        {
            EntidadModAbier modAbierto;
            if (!string.IsNullOrEmpty(txtCod.Text))
            {
                modAbierto = modRegistrado; // Como ya fue seleccionado un programa, ese será modificado 
            }
            else
            {
                modAbierto = new EntidadModAbier();
            }

            //En este caso no es necesario el txtCod
            //modAbierto.Cod_mod_abierto = Convert.ToInt32(txtCod.Text);
            modAbierto.Cod_entrenador = Convert.ToInt32(txtCod_Entrenador.Text);
            modAbierto.Cod_mod = Convert.ToInt32(txtCod_Modulo.Text);
            modAbierto.Cod_hora_mod = Convert.ToInt32(txtHorarioModulos.Text);
            modAbierto.Fecha_inicio = Convert.ToDateTime(DTFechaInicio.Value);
            modAbierto.Observaciones = txtObservaciones.Text;

            return modAbierto;
        }
        #endregion

        #region Método para mostrar los registro regresados por la BD en el DataGridView

        private void MostrarListDS(string condicion = "", string orden = "")
        {
            BLModAbier logica = new BLModAbier(Configuracion.getConnectionString);
            DataSet DSModulosAbier;

            try
            {
                DSModulosAbier = logica.listarModulos(condicion, orden); // Retorna un DataSet
                grdListaModAbier.DataSource = DSModulosAbier; // Le ingresa a la fuente de la DataGridView el DataSet para mostrarlo

                grdListaModAbier.DataMember = DSModulosAbier.Tables["ModulosAbiertos"].TableName;// Especifica el nombre de la tabla del DataSet
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Método para cargar los datos de un programa en los textBoxs
        
        private void cargarModuloAbier(int cod)
        {
            EntidadModAbier modAbierto;
            BLModAbier logica = new BLModAbier(Configuracion.getConnectionString);

            try
            {
                modAbierto = logica.ObtenerModulo(cod);
                if (modAbierto != null) // Si obtuvó algo
                {
                    txtCod.Text = modAbierto.Cod_mod_abierto.ToString();
                    txtCod_Entrenador.Text = modAbierto.Cod_entrenador.ToString();
                    txtCod_Modulo.Text = modAbierto.Cod_mod.ToString();
                    txtHorarioModulos.Text = modAbierto.Cod_hora_mod.ToString();
                    DTFechaInicio.Value = modAbierto.Fecha_inicio;
                    txtObservaciones.Text = modAbierto.Observaciones;

                    modRegistrado = modAbierto;
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

        private void FrmModulosAbie_Load(object sender, EventArgs e)
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EntidadModAbier modAbierto;
            int resultado; // Lo que retornará los métodos al obtener un progreso
            BLModAbier logica = new BLModAbier(Configuracion.getConnectionString);

            try
            {
                if (!String.IsNullOrEmpty(txtCod.Text)) //Debe tener datos en los txtboxs para poder eliminar
                {
                    //busca primero el programa antes de borrarlo para ver si existe
                    modAbierto = logica.ObtenerModulo(Convert.ToInt32(txtCod.Text));

                    if (modAbierto != null)
                    {
                        MessageBox.Show($"Esta seguro que lo desea eliminar?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                        resultado = logica.EliminarModuloAbier(Convert.ToInt32(txtCod.Text)); // Si pudo encontralo lo borra

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

        private void btnCrear_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void grdListaModAbier_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int cod = 0;
            try
            {
                cod = (int)grdListaModAbier.SelectedRows[0].Cells[0].Value;
                cargarModuloAbier(cod);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
