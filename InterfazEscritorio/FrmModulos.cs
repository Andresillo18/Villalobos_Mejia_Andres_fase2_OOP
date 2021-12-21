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
    public partial class FrmModulos : Form
    {
        EntidadModulo modRegistrado; // Variable de forma global
        EntidadModulosPrograma modulosPrograma;

        public FrmModulos()
        {
            InitializeComponent();
        }


        #region Método para limpiar los campos

        private void limpiar()
        {
            txtCod.Clear();
            txtNombre.Clear();
            txtHorasDuracion.Text = "";
            txtRequesitos.Clear();
            txtCodPrograma.Clear();
        }

        #endregion

        #region Método para generar una entidad

        private EntidadModulo GenerarEntidad(EntidadModulosPrograma modulosPrograma)
        {
            EntidadModulo modulo;
            if (!string.IsNullOrEmpty(txtCod.Text))
            {
                modulo = modRegistrado; // Como ya fue seleccionado un programa, ese será modificado 
            }
            else
            {
                modulo = new EntidadModulo();
            }

            //En este caso no es necesario el txtCod
            modulo.Nombre_modulo = txtNombre.Text;
            modulo.Horas_duracion = Convert.ToInt32(txtHorasDuracion.Text);
            modulo.Requesitos_modulo = txtRequesitos.Text;

            //modulosPrograma.Cod_programa = modulosPrograma.IdentityGenerado;
            //modulosPrograma.Cod_modulo = Convert.ToInt32(txtCod.Text);

            return modulo;
        }
        #endregion

        #region Método para mostrar los registro regresados por la BD en el DataGridView

        private void MostrarListDS(string condicion = "", string orden = "")
        {
            BLModulo logica = new BLModulo(Configuracion.getConnectionString);
            DataSet DSModulos;

            try
            {
                DSModulos = logica.listarModulos(condicion, orden); // Retorna un DataSet
                dgvModulos.DataSource = DSModulos; // Le ingresa a la fuente de la DataGridView el DataSet para mostrarlo

                dgvModulos.DataMember = DSModulos.Tables["Modulos"].TableName;// Especifica el nombre de la tabla del DataSet
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Método para cargar los datos de un programa en los textBoxs

        private void cargarModulo(int cod)
        {
            EntidadModulo modulo;
            BLModulo logica = new BLModulo(Configuracion.getConnectionString);

            try
            {
                modulo = logica.ObtenerModulo(cod);
                if (modulo != null) // Si obtuvó algo
                {
                    txtCod.Text = modulo.Cod_modulo.ToString();
                    txtNombre.Text = modulo.Nombre_modulo;
                    txtHorasDuracion.Text = modulo.Horas_duracion.ToString();
                    txtRequesitos.Text = modulo.Requesitos_modulo;

                    modRegistrado = modulo;
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
        
        private void FrmModulos_Load(object sender, EventArgs e)
        {
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            BLModulo logica = new BLModulo(Configuracion.getConnectionString);
            EntidadModulo modulo;
            int elResultado = 0;

            try
            {
                // Hace que todos los campos sean obligatorios
                if (!string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtHorasDuracion.Text) && !string.IsNullOrEmpty(txtRequesitos.Text) && !string.IsNullOrEmpty(txtCodPrograma.Text))
                {
                    modulo = GenerarEntidad(modulosPrograma);
                    if (!modulo.Existe)
                    {
                        //MessageBox.Show(modulosPrograma.Cod_modulo.ToString());
                        elResultado = logica.Insertar(modulo, modulosPrograma);
                    }
                    else
                    {
                        //elResultado = logica.Modificar(modulo);
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
            EntidadModulo modulo;
            int resultado; // Lo que retornará los métodos al obtener un progreso
            BLModulo logica = new BLModulo(Configuracion.getConnectionString);

            try
            {
                if (!String.IsNullOrEmpty(txtCod.Text)) //Debe tener datos en los txtboxs para poder eliminar
                {
                    //busca primero el programa antes de borrarlo para ver si existe
                    modulo = logica.ObtenerModulo(Convert.ToInt32(txtCod.Text));

                    if (modulo != null)
                    {
                        MessageBox.Show($"Esta seguro que lo desea eliminar?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                        resultado = logica.EliminarModulo(Convert.ToInt32(txtCod.Text)); // Si pudo encontralo lo borra

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

        private void dgvModulos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int cod = 0;
            try
            {
                cod = (int)dgvModulos.SelectedRows[0].Cells[0].Value;
                cargarModulo(cod);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        #endregion
    }
}
