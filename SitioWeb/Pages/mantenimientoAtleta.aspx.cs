using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data; // Se ocupa para el uso de dataset y para guardar la información para la tabla

using CapaLogicaNegocio;
using CapaEntidades;

namespace SitioWeb.Pages
{
    public partial class mantenimientoAtleta : System.Web.UI.Page
    {
        //CODE BEHIND:

        string script; // Variable Global

        #region Método Limpiar
        public void limpiar()
        {
            txtNombre.Text = string.Empty;
            txtApellido1.Text = string.Empty;
            txtApellido2.Text = string.Empty;
            txtTelefono1.Text = string.Empty;
            txtTelefono2.Text = string.Empty;
            CBGenero.Text = string.Empty;
            CBProvincia.Text = string.Empty;
            txtDistrito.Text = string.Empty;
            txtCanton.Text = string.Empty;

        }
        #endregion

        #region Generar Entidad

        private EntidadAtleta GenerarEntidad()
        {
            EntidadAtleta atleta = new EntidadAtleta();

            // Si la variable session tiene algo, se le ingresa a la entidad para saber cual modificar
            if (Session["cod_atleta"] != null)
            {
                atleta.Cod_atleta = int.Parse(Session["cod_atleta"].ToString());
                atleta.Estado = true;
            }
            // Si la variable no tiene ningún COD se crea uno nuevo
            else
            {
                atleta.Cod_atleta = -1;
                atleta.Estado = false;
            }

            //Estos otros txt se les ingresa el resto de info
            atleta.Identificacion = txtIdEntrenador.Text;
            atleta.Nombre = txtNombre.Text;
            atleta.Apellido1 = txtApellido1.Text;
            atleta.Apellido2 = txtApellido2.Text;
            atleta.Telefono1 = txtTelefono1.Text;
            atleta.Telefono2 = txtTelefono2.Text;
            atleta.Genero = CBGenero.Text;
            atleta.Fecha_nacimiento = CalFechaNacimiento.SelectedDate;
            atleta.Provincia = CBProvincia.Text;
            atleta.Distrito = txtDistrito.Text;
            atleta.Canton = txtDistrito.Text;
         

            return atleta;
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            EntidadAtleta atleta;
            BLAtleta logica = new BLAtleta(clsConfiguracion.getConnectionString);
            int cod;
            try
            {
                if (!Page.IsPostBack)
                {
                    //Se usa una variable session para enviar del otro formulario a este el COD o el identity para saber si el registro existe
                    //Si la variable de SESION contiene un valor, MODIFICAMOS un registro 
                    if (Session["cod_atleta"] != null)
                    {
                        cod = int.Parse(Session["cod_atleta"].ToString());
                        atleta = logica.ObtenerAtleta(cod);

                        if (atleta.Estado) // Se pregunta por el estado para saber si existe
                        {
                            txtCodEntrenador.Text = atleta.Cod_atleta.ToString();
                            txtIdEntrenador.Text = atleta.Identificacion;
                            txtNombre.Text = atleta.Nombre;
                            txtApellido1.Text = atleta.Apellido1;
                            txtApellido2.Text = atleta.Apellido2;
                            txtTelefono1.Text = atleta.Telefono1;
                            txtTelefono2.Text = atleta.Telefono2;
                            CBGenero.Text = atleta.Correo;
                            CalFechaNacimiento.SelectedDate = atleta.Fecha_nacimiento;
                            CBProvincia.Text = atleta.Provincia;
                            txtDistrito.Text = atleta.Distrito;
                            txtCanton.Text = atleta.Canton;
                            if (atleta.Estado == true)
                            {
                                RBActivo.Checked = true;
                            }
                            else if (atleta.Estado == false)
                            {
                                RBInactivo.Checked = true;
                            }

                            lblCodEntrenador.Visible = true;
                            txtCodEntrenador.Visible = true;
                        }
                        else
                        {
                            script = string.Format("javascript:mostrarMensaje('Atleta no encontrado')");
                            ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", script, true);
                        }
                    }
                    //Si la SESION no contenía nada, es decir si es CREAR un cliente nuevo
                    else
                    {
                        limpiar();
                        RBActivo.Checked = true;
                        txtCodEntrenador.Text = "-1";

                        lblCodEntrenador.Visible = false;
                        txtCodEntrenador.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                {
                    script = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                    ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", script, true);

                    //Redireccionar (regresar) al formulario principal
                    Response.Redirect("atleta.aspx");
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            EntidadAtleta atleta;
            BLAtleta logica = new BLAtleta(clsConfiguracion.getConnectionString);
            int resultado;

            try
            {
                atleta = GenerarEntidad();

                if (!string.IsNullOrEmpty(txtIdEntrenador.Text) && !string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtApellido1.Text) && !string.IsNullOrEmpty(txtApellido2.Text) && !string.IsNullOrEmpty(txtTelefono1.Text) && !string.IsNullOrEmpty(CBProvincia.Text) && !string.IsNullOrEmpty(txtDistrito.Text) && !string.IsNullOrEmpty(txtCanton.Text)) // Los campos deben ser requeridos
                {
                    // Si el cliente ya existe, se MODIFICA
                    if (atleta.Estado)
                    {
                        resultado = logica.Modificar(atleta);
                    }
                    // Si el cliente no existe, se CREA uno nuevo
                    else
                    {
                        resultado = logica.Insertar(atleta);
                    }
                    if (resultado > 0)
                    {
                        script = string.Format("javascript:mostrarMensaje('Operación realizada satisfactoriamente')");
                        ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", script, true);
                    }
                    else
                    {
                        script = string.Format("javascript:mostrarMensaje('No se pudo ejecutar la operación')");
                        ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", script, true);
                    }
                }
                else
                {
                    script = string.Format("javascript:mostrarMensaje('Debe ingresar la información en los campos')");
                    ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", script, true);
                }

            }
            catch (Exception ex)
            {
                {
                    script = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                    ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", script, true);

                    Response.Redirect("entrenador.aspx"); // Lo manda la formulario devuelta ya que cancela
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("atleta.aspx");
        }
    }
}