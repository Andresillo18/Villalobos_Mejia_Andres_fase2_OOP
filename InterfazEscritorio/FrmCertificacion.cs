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
    public partial class FrmCertificacion : Form
    {
        EntidadCertificacion certificacionRegistrada;
        public FrmCertificacion()
        {
            InitializeComponent();
        }


        #region Método para limpiar los campos

        private void limpiar()
        {
            txtCodCertif.Clear();
            txtCodEntrenador.Clear();
            CBGimnasio.Checked = false;
            CBNatacion.Checked = false;
            CBMaraton.Checked = false;
            CBCiclismo.Checked = false;
        }

        #endregion

        #region Método para generar una entidad

        private EntidadCertificacion GenerarEntidad()
        {
            EntidadCertificacion certificacion;
            if (!string.IsNullOrEmpty(txtCodCertif.Text))
            {
                certificacion = certificacionRegistrada; // no se genera una entidad nueva, sino se usa la misma y se modifica
                certificacion.Existe = true; // Si ya ha seleccionado un registro este pasa a que ya existe para ser modificado
            }
            else
            {
                certificacion = new EntidadCertificacion();
            }

            //En este caso no es necesario el txtCodHorMod
            //Pregunta cuales estan marcadas de los checkboxs y los guarda en la entidad los datos

            certificacion.Cod_entrenador = Convert.ToInt32(txtCodEntrenador.Text);
            if (CBGimnasio.Checked)
            {
                certificacion.Gimnasio_especifi = true;
            }
            else
            {
                certificacion.Gimnasio_especifi = false;
            }

            if (CBNatacion.Checked)
            {
                certificacion.Natacion_especifi = true;
            }
            else
            {
                certificacion.Natacion_especifi = false;
            }

            if (CBMaraton.Checked)
            {
                certificacion.Maraton_especifi = true;
            }
            else
            {
                certificacion.Maraton_especifi = false;
            }

            if (CBCiclismo.Checked)
            {
                certificacion.Ciclismo_especifi = true;
            }
            else
            {
                certificacion.Ciclismo_especifi = false;
            }

            return certificacion;
        }
        #endregion

        #region Método para mostrar los registro regresados por la BD en el DataGridView

        private void MostrarListDS(string condicion = "", string orden = "")
        {
            BLCertificacion logica = new BLCertificacion(Configuracion.getConnectionString);
            DataSet DSHorarEntren;

            try
            {
                DSHorarEntren = logica.listarCertificacion(condicion, orden); // Retorna un DataSet
                dgvCertificaciones.DataSource = DSHorarEntren; // Le ingresa a la fuente de la DataGridView el DataSet para mostrarlo

                dgvCertificaciones.DataMember = DSHorarEntren.Tables["certificaciones"].TableName;// Especifica el nombre de la tabla del DataSet
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Método para cargar los datos de un programa en los textBoxs

        private void cargarCertificacion(int cod)
        {
            EntidadCertificacion certificacion;
            BLCertificacion logica = new BLCertificacion(Configuracion.getConnectionString);

            try
            {
                certificacion = logica.ObtenerCertificacion(cod);
                if (certificacion != null) // Si obtuvó algo
                {
                    txtCodCertif.Text = certificacion.Cod_certificacion.ToString();
                    txtCodEntrenador.Text = certificacion.Cod_entrenador.ToString();

                    // Aquí pregunta que si en la entidad esta TRUE que marque la casilla, sino la desmarca según el evento doubleClick**
                    if (certificacion.Gimnasio_especifi == true)
                    {
                        CBGimnasio.Checked = true;
                    }
                    else
                    {
                        CBGimnasio.Checked = false;
                    }

                    if (certificacion.Natacion_especifi == true)
                    {
                        CBNatacion.Checked = true;
                    }
                    else
                    {
                        CBNatacion.Checked = false;
                    }

                    if (certificacion.Maraton_especifi == true)
                    {
                        CBMaraton.Checked = true;
                    }
                    else
                    {
                        CBMaraton.Checked = false;
                    }

                    if (certificacion.Ciclismo_especifi == true)
                    {
                        CBCiclismo.Checked = true;
                    }
                    else
                    {
                        CBCiclismo.Checked = false;
                    }

                    certificacionRegistrada = certificacion;
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

        private void FrmCertificacion_Load(object sender, EventArgs e)
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
            BLCertificacion logica = new BLCertificacion(Configuracion.getConnectionString);
            EntidadCertificacion certificacion;
            int elResultado = 0;

            try
            {
                if (!string.IsNullOrEmpty(txtCodEntrenador.Text) && CBGimnasio.Checked == true && CBNatacion.Checked == true && CBMaraton.Checked == true && CBCiclismo.Checked == true)
                {
                    // en este caso un usuario puede guardar los datos sin ser obligatorios
                    certificacion = GenerarEntidad();
                    if (!certificacion.Existe)
                    {
                        //MessageBox.Show(modulosPrograma.Cod_modulo.ToString());
                        elResultado = logica.Insertar(certificacion);
                    }
                    else
                    {
                        elResultado = logica.Modificar(certificacion);
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
            EntidadCertificacion certificacion;
            int resultado; // Lo que retornará los métodos al obtener un progreso
            BLCertificacion logica = new BLCertificacion(Configuracion.getConnectionString);

            try
            {
                if (!String.IsNullOrEmpty(txtCodCertif.Text) && !String.IsNullOrEmpty(txtCodEntrenador.Text)) //Debe tener datos en los txtboxs para poder eliminar
                {
                    //busca primero el programa antes de borrarlo para ver si existe
                    certificacion = logica.ObtenerCertificacion(Convert.ToInt32(txtCodCertif.Text));

                    if (certificacion != null)
                    {
                        MessageBox.Show($"Esta seguro que lo desea eliminar?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                        resultado = logica.EliminarHorarEntrenador(Convert.ToInt32(txtCodCertif.Text)); // Si pudo encontralo lo borra

                        MessageBox.Show($"Se han afectado {resultado} registros", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar();
                        MostrarListDS();
                    }
                    else
                    {
                        MessageBox.Show("La certificación no existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    // No se sucede nada si no lo selecciona
                    MessageBox.Show("Debe Seleccionar una certificación antes de eliminar algo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            FrmEntrenador FrmEntrenadores = new FrmEntrenador();
            FrmEntrenadores.Show();
        }

        private void dgvCertificaciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int cod = 0;
            try
            {
                cod = (int)dgvCertificaciones.SelectedRows[0].Cells[0].Value;
                cargarCertificacion(cod);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
