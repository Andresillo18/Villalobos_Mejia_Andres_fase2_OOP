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
    public partial class FrmEdicionProgram : System.Web.UI.Page
    {
        //CODE BEHIND:

        string script; // Variable Global

        #region Método Limpiar
        public void limpiar()
        {
            txtCodPrograma.Text = string.Empty;
            txtNombre.Text = string.Empty;
            RBInactivo.Checked = true;
            txtDescripcion.Text = string.Empty;
            txtObservaciones.Text = string.Empty;
        }
        #endregion

        #region Generar Entidad

        private EntidadPrograma GenerarEntidad()
        {
            EntidadPrograma programa = new EntidadPrograma();

            // Si tiene la variable session se le ingresa algo
            if (Session["cod_programa"] != null)
            {
                programa.Cod_programa = int.Parse(Session["cod_programa"].ToString());
                programa.Existe = true;
            }
            // Si la variable no tiene ningún COD se crea uno nuevo
            else
            {
                programa.Cod_programa = -1;
                programa.Existe = false;
            }

            //Estos otro txt se les ingresa el resto de info
            programa.Nombre_programa = txtNombre.Text;
            programa.Descripcion_programa = txtDescripcion.Text;

            if (RBActivo.Checked)
            {
                programa.Estado = "Activo";
            }
            else if (RBInactivo.Checked)
            {
                programa.Estado = "Inactivo";
            }

            programa.Observaciones_programa = txtObservaciones.Text;

            return programa;
        }

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            EntidadPrograma programa;
            BLPrograma logica = new BLPrograma(clsConfiguracion.getConnectionString);
            int cod;
            try
            {
                if (!Page.IsPostBack)
                {
                    //Se usa una variable session para enviar del otro formulario a este el COD o el identity para saber si el registro existe
                    //Si la variable de SESION contiene un valor, MODIFICAMOS un registro 
                    if (Session["cod_programa"] != null)
                    {
                        cod = int.Parse(Session["cod_programa"].ToString());
                        programa = logica.ObtenerPrograma(cod);

                        if (programa.Existe)
                        {
                            txtCodPrograma.Text = programa.Cod_programa.ToString();
                            txtNombre.Text = programa.Nombre_programa;
                            txtDescripcion.Text = programa.Descripcion_programa;

                            if (programa.Estado == "Activo")
                            {
                                RBActivo.Checked = true;
                            }
                            else if (programa.Estado == "Inactivo")
                            {
                                RBInactivo.Checked = true;
                            }

                            txtObservaciones.Text = programa.Observaciones_programa;

                            lblCodPrograma.Visible = true;
                            txtCodPrograma.Visible = true;
                        }
                        else
                        {
                            script = string.Format("javascript:mostrarMensaje('Cliente no encontrado')");
                            ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", script, true);
                        }
                    }
                    //Si la SESION no contenía nada, es decir si es CREAR un cliente nuevo
                    else
                    {
                        limpiar();
                        txtCodPrograma.Text = "-1";

                        lblCodPrograma.Visible = false;
                        txtCodPrograma.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                {
                    script = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                    ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", script, true);

                    //Redireccionar (regresar) al formulario principal
                    Response.Redirect("Default.aspx");
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            EntidadPrograma programa;
            BLPrograma logica = new BLPrograma(clsConfiguracion.getConnectionString);
            int resultado;

            try
            {
                programa = GenerarEntidad();

                if (!string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtDescripcion.Text)) // Los campos deben ser requeridos
                {
                    // Si el cliente ya existe, se MODIFICA
                    if (programa.Existe)
                    {
                        resultado = logica.Modificar(programa);
                    }
                    // Si el cliente no existe, se CREA uno nuevo
                    else
                    {
                        resultado = logica.Insertar(programa);
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

                    Response.Redirect("Default.aspx"); // Lo manda la formulario devuelta ya que cancela
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            //Si le da cancelar lo manda al formulario que estaba
            Response.Redirect("default.aspx");
        }

    }
}