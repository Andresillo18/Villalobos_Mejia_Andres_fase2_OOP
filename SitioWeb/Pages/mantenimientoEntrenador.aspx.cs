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
    public partial class mantenimientoEntrenador : System.Web.UI.Page
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
            txtCorreo.Text = string.Empty;
            CBProvincia.Text = string.Empty;
            txtDistrito.Text = string.Empty;
            txtCanton.Text = string.Empty;
            
        }
        #endregion

        #region Generar Entidad

        private EntidadEntrenador GenerarEntidad()
        {
            EntidadEntrenador entrenador = new EntidadEntrenador();

            // Si la variable session tiene algo, se le ingresa a la entidad para saber cual modificar
            if (Session["cod_entrenador"] != null)
            {
                entrenador.Cod_entrenador = int.Parse(Session["cod_entrenador"].ToString());
                entrenador.Estado= true;
            }
            // Si la variable no tiene ningún COD se crea uno nuevo
            else
            {
                entrenador.Cod_entrenador= -1;
                entrenador.Estado = false;
            }

            //Estos otros txt se les ingresa el resto de info
            entrenador.Identificacion = txtIdEntrenador.Text;
            entrenador.Nombre = txtNombre.Text;
            entrenador.Apellido1 = txtApellido1.Text;
            entrenador.Apellido2 = txtApellido2.Text;
            entrenador.Telefono1 = txtTelefono1.Text;
            entrenador.Telefono2 = txtTelefono2.Text;
            entrenador.Correo = txtCorreo.Text;
            entrenador.Fecha_nacimiento = CalFechaNacimiento.SelectedDate;
            entrenador.Provincia = CBProvincia.Text;
            entrenador.Distrito = txtDistrito.Text;
            entrenador.Canton = txtDistrito.Text;
            //if (RBActivo.Checked == true)
            //{
            //    entrenador.Estado = true;
            //}
            //else if (RBInactivo.Checked == true)
            //{
            //    entrenador.Estado = false;
            //}

            return entrenador;
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {            
            EntidadEntrenador entrenador;
            BLEntrenador logica = new BLEntrenador(clsConfiguracion.getConnectionString);
            int cod;
            try
            {
                if (!Page.IsPostBack)
                {
                    //Se usa una variable session para enviar del otro formulario a este el COD o el identity para saber si el registro existe
                    //Si la variable de SESION contiene un valor, MODIFICAMOS un registro 
                    if (Session["cod_entrenador"] != null)
                    {
                        cod = int.Parse(Session["cod_entrenador"].ToString());
                        entrenador = logica.ObtenerEntrenador(cod);

                        if (entrenador.Estado) // Se pregunta por el estado para saber si existe
                        {
                            txtCodEntrenador.Text = entrenador.Cod_entrenador.ToString();
                            txtIdEntrenador.Text = entrenador.Identificacion;
                            txtNombre.Text= entrenador.Nombre;
                            txtApellido1.Text = entrenador.Apellido1;
                            txtApellido2.Text = entrenador.Apellido2;
                            txtTelefono1.Text = entrenador.Telefono1;
                            txtTelefono2.Text = entrenador.Telefono2;
                            txtCorreo.Text = entrenador.Correo;
                            CalFechaNacimiento.SelectedDate = entrenador.Fecha_nacimiento;
                            CBProvincia.Text = entrenador.Provincia;
                            txtDistrito.Text = entrenador.Distrito;
                            txtCanton.Text = entrenador.Canton;
                            if (entrenador.Estado == true)
                            {
                                RBActivo.Checked = true;
                            }
                            else if (entrenador.Estado == false)
                            {
                                RBInactivo.Checked = true;
                            }

                            lblCodEntrenador.Visible = true;
                            txtCodEntrenador.Visible = true;
                        }
                        else
                        {
                            script = string.Format("javascript:mostrarMensaje('Entrenador no encontrado')");
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
                    Response.Redirect("entrenador.aspx");
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            EntidadEntrenador entrenador;
            BLEntrenador logica = new BLEntrenador(clsConfiguracion.getConnectionString);
            int resultado;

            try
            {
                entrenador = GenerarEntidad();

                if (!string.IsNullOrEmpty(txtIdEntrenador.Text) && !string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtApellido1.Text) && !string.IsNullOrEmpty(txtApellido2.Text) && !string.IsNullOrEmpty(txtTelefono1.Text)  && !string.IsNullOrEmpty(CBProvincia.Text) && !string.IsNullOrEmpty(txtDistrito.Text) && !string.IsNullOrEmpty(txtCanton.Text) ) // Los campos deben ser requeridos
                {
                    // Si el cliente ya existe, se MODIFICA
                    if (entrenador.Estado)
                    {
                        resultado = logica.Modificar(entrenador);
                    }
                    // Si el cliente no existe, se CREA uno nuevo
                    else
                    {
                        resultado = logica.Insertar(entrenador);
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
            Response.Redirect("entrenador.aspx");
        }
    }
}