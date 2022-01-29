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
            txtProvincia.Text = string.Empty;
            txtDistrito.Text = string.Empty;
            txtCanton.Text = string.Empty;
            RBActivo.Checked = true;
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
            entrenador.Nombre_modulo = txtNombre.Text;
            entrenador.Horas_duracion = Convert.ToInt32(cboHoras.SelectedValue);
            entrenador.Requesitos_modulo = txtRequesitos.Text;

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
                            txtNombre.Text = modulo.Nombre_modulo;
                            cboHoras.SelectedIndex = modulo.Horas_duracion;
                            txtRequesitos.Text = modulo.Requesitos_modulo;

                            lblCodModulo.Visible = true;
                            txtCodModulo.Visible = true;
                        }
                        else
                        {
                            script = string.Format("javascript:mostrarMensaje('Módulo no encontrado')");
                            ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", script, true);
                        }
                    }
                    //Si la SESION no contenía nada, es decir si es CREAR un cliente nuevo
                    else
                    {
                        limpiar();
                        txtCodModulo.Text = "-1";

                        lblCodModulo.Visible = false;
                        txtCodModulo.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                {
                    script = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                    ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", script, true);

                    //Redireccionar (regresar) al formulario principal
                    Response.Redirect("modulo.aspx");
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            EntidadModulo modulo;
            BLModulo logica = new BLModulo(clsConfiguracion.getConnectionString);
            int resultado;

            try
            {
                modulo = GenerarEntidad();

                if (!string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtRequesitos.Text)) // Los campos deben ser requeridos
                {
                    // Si el cliente ya existe, se MODIFICA
                    if (modulo.Existe)
                    {
                        resultado = logica.Modificar(modulo);
                    }
                    // Si el cliente no existe, se CREA uno nuevo
                    else
                    {
                        resultado = logica.Insertar(modulo);
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

                    Response.Redirect("modulo.aspx"); // Lo manda la formulario devuelta ya que cancela
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("entrenador.aspx");
        }
    }
}