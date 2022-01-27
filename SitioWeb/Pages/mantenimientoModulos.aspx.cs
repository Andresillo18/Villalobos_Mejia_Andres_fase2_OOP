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
    public partial class mantenimientoModulos : System.Web.UI.Page
    {
        //CODE BEHIND:

        string script; // Variable Global

        #region Método Limpiar
        public void limpiar()
        {            
            txtNombre.Text = string.Empty;         
            txtRequesitos.Text = string.Empty;
        }
        #endregion

        #region Generar Entidad

        private EntidadModulo GenerarEntidad()
        {
            EntidadModulo modulo= new EntidadModulo();

            // Si la variable session tiene algo, se le ingresa a la entidad para saber cual modificar
            if (Session["cod_modulo"] != null)
            {
                modulo.Cod_modulo= int.Parse(Session["cod_modulo"].ToString());
                modulo.Existe = true;
            }
            // Si la variable no tiene ningún COD se crea uno nuevo
            else
            {
                modulo.Cod_modulo= -1;
                modulo.Existe = false;
            }

            //Estos otros txt se les ingresa el resto de info
            modulo.Nombre_modulo= txtNombre.Text;
            modulo.Horas_duracion= Convert.ToInt32(cboHoras.SelectedValue);
            modulo.Requesitos_modulo = txtRequesitos.Text;            

            return modulo;
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            EntidadModulo modulo;
            BLModulo logica = new BLModulo(clsConfiguracion.getConnectionString);
            int cod;
            try
            {
                if (!Page.IsPostBack)
                {
                    //Se usa una variable session para enviar del otro formulario a este el COD o el identity para saber si el registro existe
                    //Si la variable de SESION contiene un valor, MODIFICAMOS un registro 
                    if (Session["cod_modulo"] != null)
                    {
                        cod = int.Parse(Session["cod_modulo"].ToString());
                        modulo = logica.ObtenerModulo(cod);

                        if (modulo.Existe)
                        {
                            txtCodModulo.Text = modulo.Cod_modulo.ToString();
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

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("modulo.aspx");
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
    }
}