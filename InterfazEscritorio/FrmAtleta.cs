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
    public partial class FrmAtleta : Form
    {
        //Variables Globales:
        EntidadAtleta atletaRegistrado;

        FrmBuscarAtleta formularioBuscar; // Se inicializa una de tipo del formulario 

        public FrmAtleta()
        {
            InitializeComponent();
        }

        #region Método para limpiar los campos

        private void limpiar()
        {
            txtCodAtleta.Clear();
            txtID.Clear();
            txtNombre.Clear();
            txtApellido1.Clear();
            txtApellido2.Clear();
            txtTelefono1.Clear();
            txtTelefono2.Clear();
            CBGenero.Text = "";
            txtProvincia.Text = "";
            txtDistrito.Clear();
            txtCanton.Clear();
            txtDistrito.Clear();
            DTFechaNacimie.ResetText();
            RBInactivo.Select();
        }

        #endregion

        #region Método para generar una entidad

        private EntidadAtleta GenerarEntidad()
        {
            EntidadAtleta atleta;
            if (!string.IsNullOrEmpty(txtCodAtleta.Text))
            {
                atleta = atletaRegistrado; // Como ya fue seleccionado un programa, ese será modificado 
            }
            else
            {
                atleta = new EntidadAtleta();
            }

            //En este caso no es necesario el txtCodEntrenador            
            //entrenador.Cod_entrenador = Convert.ToInt32(txtCodEntrenador.Text);
            atleta.Identificacion = txtID.Text;
            atleta.Nombre = txtNombre.Text;
            atleta.Apellido1 = txtApellido1.Text;
            atleta.Apellido2 = txtApellido2.Text;
            atleta.Telefono1 = txtTelefono1.Text;
            atleta.Telefono2 = txtTelefono2.Text;
            atleta.Genero = CBGenero.Text;
            atleta.Provincia = txtProvincia.Text;
            atleta.Distrito = txtDistrito.Text;
            atleta.Canton = txtCanton.Text;
            atleta.Fecha_nacimiento = Convert.ToDateTime(DTFechaNacimie.Value);

            return atleta;
        }
        #endregion

        #region Método para mostrar los registro regresados por la BD en el DataGridView

        private void MostrarListDS(string condicion = "", string orden = "")
        {
            BLAtleta logica = new BLAtleta(Configuracion.getConnectionString);
            DataSet DSAtletas;

            try
            {
                DSAtletas = logica.listarAtletas(condicion, orden); // Retorna un DataSet
                grdListaAtletas.DataSource = DSAtletas; // Le ingresa a la fuente de la DataGridView el DataSet para mostrarlo

                grdListaAtletas.DataMember = DSAtletas.Tables["atletas"].TableName;// Especifica el nombre de la tabla del DataSet
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Método para cargar los datos de un programa en los textBoxs

        private void cargarAtleta(int cod)
        {
            EntidadAtleta atleta;
            BLAtleta logica = new BLAtleta(Configuracion.getConnectionString);

            try
            {
                atleta = logica.ObtenerAtleta(cod);
                if (atleta != null) // Si obtuvó algo
                { 
                    txtCodAtleta.Text = atleta.Cod_atleta.ToString();
                    txtID.Text = atleta.Identificacion;
                    txtNombre.Text = atleta.Nombre;
                    txtApellido1.Text = atleta.Apellido1;
                    txtApellido2.Text = atleta.Apellido2;
                    txtTelefono1.Text = atleta.Telefono1;
                    txtTelefono2.Text = atleta.Telefono2;
                    CBGenero.Text = atleta.Genero;
                    txtProvincia.Text = atleta.Provincia;
                    txtDistrito.Text = atleta.Distrito;
                    txtCanton.Text = atleta.Canton;
                    DTFechaNacimie.Value = atleta.Fecha_nacimiento;
                    // Si en la entidad esta activo el entrenador se activo el RadioButton, sino se pone desactivado
                    if (atleta.Estado)
                    {
                        RBActivo.Checked = true;
                    }
                    else
                    {
                        RBInactivo.Checked = true;
                    }

                    atletaRegistrado = atleta;
                }
                else
                {
                    MessageBox.Show("El Atleta seleccionado no se encuentra en la Base de Datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void FrmAtletas_Load(object sender, EventArgs e)
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
            BLAtleta logica = new BLAtleta(Configuracion.getConnectionString);
            EntidadAtleta atleta;
            int elResultado = 0;

            try
            {
                // Hace que todos los campos sean obligatorios
                if (!string.IsNullOrEmpty(txtID.Text) && !string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtApellido1.Text) && !string.IsNullOrEmpty(txtApellido2.Text) && !string.IsNullOrEmpty(txtTelefono1.Text) && !string.IsNullOrEmpty(txtProvincia.Text) && !string.IsNullOrEmpty(txtDistrito.Text) && !string.IsNullOrEmpty(txtDistrito.Text) && !string.IsNullOrEmpty(txtCanton.Text))
                {
                    atleta = GenerarEntidad();
                    if (!atleta.Estado)
                    {
                        //MessageBox.Show(modulosPrograma.Cod_modulo.ToString());
                        elResultado = logica.Insertar(atleta);
                    }
                    else
                    {
                        elResultado = logica.Modificar(atleta);
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
            EntidadAtleta atleta;
            int resultado; // Lo que retornará los métodos al obtener un progreso
            BLAtleta logica = new BLAtleta(Configuracion.getConnectionString);

            try
            {
                if (!String.IsNullOrEmpty(txtCodAtleta.Text)) //Debe tener datos en los txtboxs para poder eliminar
                {
                    //busca primero el programa antes de borrarlo para ver si existe
                    atleta = logica.ObtenerAtleta(Convert.ToInt32(txtCodAtleta.Text));

                    if (atleta != null)
                    {
                        MessageBox.Show($"Esta seguro que lo desea eliminar?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                        resultado = logica.EliminarAtleta(Convert.ToInt32(txtCodAtleta.Text)); // Si pudo encontralo lo borra

                        MessageBox.Show($"Se han afectado {resultado} registros", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar();
                        MostrarListDS();
                    }
                    else
                    {
                        MessageBox.Show("El Atleta no existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    // No se sucede nada si no lo selecciona
                    MessageBox.Show("Debe Seleccionar un atleta antes de eliminar algún registro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void grdListaAtletas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int cod = 0;
            try
            {
                cod = (int)grdListaAtletas.SelectedRows[0].Cells[0].Value;
                cargarAtleta(cod);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            formularioBuscar = new FrmBuscarAtleta(); // Se crea el objeto
            formularioBuscar.Aceptar += new EventHandler(Aceptar); // Se le envia un evento al objeto
            // Especificamos que deseamos utilizar el evento Aceptar

            formularioBuscar.ShowDialog();
        }

        #endregion

        #region Evento Aceptar
        // Esto es una forma de pasar el ID desde un formulario a otro

        private void Aceptar(object id, EventArgs e)
        //implementa el evento aceptar y recibe un id el cual se manda desde el formulario que se abre y aqui se carga el cliente
        {
            try
            {
                int idCliente = (int)id;
                if (idCliente != -1)
                {
                    cargarAtleta(idCliente);
                }
                else
                {
                    limpiar();
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
