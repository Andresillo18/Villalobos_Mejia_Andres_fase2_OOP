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
    public partial class FrmMatricula : Form
    {
        EntidadMatricula matriculaRegistrada;

        public FrmMatricula()
        {
            InitializeComponent();
        }

        #region Método para limpiar los campos

        private void limpiar()
        {
            txtCodMatricula.Clear();
            txtCod_Atleta.Clear();
            txtCod_ModuloAb.Clear();
            DTFechaMatricula.ResetText();
            CBEstado.Text = "";
            NPNotaFinal.ResetText();
            NPMontoCancelado.ResetText();
            CBTipoCobro.Text = "";
            CBTipoPago.Text = "";
        }

        #endregion

        #region Método para generar una entidad

        private EntidadMatricula GenerarEntidad()
        {
            EntidadMatricula matricula;
            if (!string.IsNullOrEmpty(txtCodMatricula.Text))
            {
                matricula = matriculaRegistrada; // Como ya fue seleccionado un programa, ese será modificado 
            }
            else
            {
                matricula = new EntidadMatricula();
            }

            //En este caso no es necesario el txtCodMatricula porque es IDENTITY
            //matricula.Cod_matricula = Convert.ToInt32(txtCodMatricula.Text);

            matricula.Cod_atleta = Convert.ToInt32(txtCod_Atleta.Text);
            matricula.Cod_mod_abierto = Convert.ToInt32(txtCod_ModuloAb.Text);
            matricula.Fecha_matri = DTFechaMatricula.Value;
            matricula.Estado = CBEstado.Text;
            matricula.Nota_final = Convert.ToDecimal(NPNotaFinal.Value);
            matricula.Monto_cancelado = Convert.ToInt32(NPMontoCancelado.Value);
            matricula.Tipo_cobro = CBTipoCobro.Text;
            matricula.Tipo_pago = CBTipoPago.Text;

            return matricula;
        }
        #endregion

        #region Método para mostrar los registro regresados por la BD en el DataGridView

        private void MostrarListDS(string condicion = "", string orden = "")
        {
            BLMatricula logica = new BLMatricula(Configuracion.getConnectionString);
            DataSet DSMatriculas;

            try
            {
                DSMatriculas = logica.listarMatriculas(condicion, orden); // Retorna un DataSet
                dgvMatriculas.DataSource = DSMatriculas; // Le ingresa a la fuente de la DataGridView el DataSet para mostrarlo

                dgvMatriculas.DataMember = DSMatriculas.Tables["matriculas"].TableName;// Especifica el nombre de la tabla del DataSet
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Método para cargar los datos de un programa en los textBoxs

        private void cargarMatricula(int cod)
        {
            EntidadMatricula matricula;
            BLMatricula logica = new BLMatricula(Configuracion.getConnectionString);

            try
            {
                matricula = logica.ObtenerMatricula(cod);
                if (matricula != null) // Si obtuvó algo
                {
                    txtCodMatricula.Text = matricula.Cod_matricula.ToString();
                    txtCod_Atleta.Text = matricula.Cod_atleta.ToString();
                    txtCod_ModuloAb.Text = matricula.Cod_mod_abierto.ToString();
                    DTFechaMatricula.Value = matricula.Fecha_matri;
                    CBEstado.Text = matricula.Estado.ToString();
                    NPNotaFinal.Value = matricula.Nota_final;
                    NPMontoCancelado.Value= matricula.Monto_cancelado;
                    CBTipoCobro.Text = matricula.Tipo_cobro.ToString();
                    CBTipoPago.Text = matricula.Tipo_pago.ToString();

                    matriculaRegistrada = matricula;
                }
                else
                {
                    MessageBox.Show("La matrícula seleccionado no se encuentra en la Base de Datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            FrmAtleta frmAtleta = new FrmAtleta();
            frmAtleta.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmModulosAbie frmModulosAbie = new FrmModulosAbie();
            frmModulosAbie.Show();
        }

        private void FrmMatricula_Load(object sender, EventArgs e)
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
            BLMatricula logica = new BLMatricula(Configuracion.getConnectionString);
            EntidadMatricula matricula;
            int elResultado = 0;

            try
            {
                // Hace que todos los campos sean obligatorios
                if (!string.IsNullOrEmpty(txtCod_Atleta.Text) && !string.IsNullOrEmpty(txtCod_ModuloAb.Text) && !string.IsNullOrEmpty(CBEstado.Text) && !string.IsNullOrEmpty(NPMontoCancelado.Text) && !string.IsNullOrEmpty(CBTipoCobro.Text) && !string.IsNullOrEmpty(CBTipoPago.Text))
                {
                    matricula = GenerarEntidad();
                    if (!matricula.Actividad) // Si esta activo o creada se ingresa o modifica
                    {
                        //MessageBox.Show(modulosPrograma.Cod_modulo.ToString());
                        elResultado = logica.Insertar(matricula);
                    }
                    else
                    {
                        elResultado = logica.Modificar(matricula);
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
            EntidadMatricula modAbierto;
            int resultado; // Lo que retornará los métodos al obtener un progreso
            BLMatricula logica = new BLMatricula(Configuracion.getConnectionString);

            try
            {
                if (!String.IsNullOrEmpty(txtCod_ModuloAb.Text)) //Debe tener datos en los txtboxs para poder eliminar
                {
                    //busca primero el programa antes de borrarlo para ver si existe
                    modAbierto = logica.ObtenerMatricula(Convert.ToInt32(txtCod_ModuloAb.Text));

                    if (modAbierto != null)
                    {
                        MessageBox.Show($"Esta seguro que lo desea eliminar?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                        resultado = logica.EliminarMatricula(Convert.ToInt32(txtCod_ModuloAb.Text)); // Si pudo encontralo lo borra

                        MessageBox.Show($"Se han afectado {resultado} registros", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar();
                        MostrarListDS();
                    }
                    else
                    {
                        MessageBox.Show("La matrícula no existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    // No se sucede nada si no lo selecciona
                    MessageBox.Show("Debe Seleccionar una matrícula antes de eliminar algo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void dgvMatriculas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int cod = 0;
            try
            {
                //MessageBox.Show("Campo 0: " + Convert.ToString(dgvMatriculas.SelectedRows[0].Cells[0].Value));
                //MessageBox.Show("Campo 1: " + Convert.ToString(dgvMatriculas.SelectedRows[0].Cells[1].Value));
                //MessageBox.Show("Campo 2: " + Convert.ToString(dgvMatriculas.SelectedRows[0].Cells[2].Value));
                //MessageBox.Show("Campo 3: " + Convert.ToString(dgvMatriculas.SelectedRows[0].Cells[3].Value));
                //MessageBox.Show("Campo 4: " + Convert.ToString(dgvMatriculas.SelectedRows[0].Cells[4].Value));
                //MessageBox.Show("Campo 5: " + Convert.ToString(dgvMatriculas.SelectedRows[0].Cells[5].Value));
                //MessageBox.Show("Campo 6: " + Convert.ToString(dgvMatriculas.SelectedRows[0].Cells[6].Value));
                //MessageBox.Show("Campo 7: " + Convert.ToString(dgvMatriculas.SelectedRows[0].Cells[7].Value));
                //MessageBox.Show("Campo 8: " + Convert.ToString(dgvMatriculas.SelectedRows[0].Cells[8].Value));

                cod = (int)dgvMatriculas.SelectedRows[0].Cells[0].Value;
                cargarMatricula(cod);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
