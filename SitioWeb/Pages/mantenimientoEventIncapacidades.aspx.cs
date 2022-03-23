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
    public partial class mantenimientoEventIncapacidades : System.Web.UI.Page
    {
        //CODE BEHIND:

        string script; // Variable Global

        #region Método Limpiar
        public void limpiar()
        {
            txtCodEntrenador.Text = string.Empty;         
            txtObservaciones.Text = string.Empty;
        }
        #endregion

        #region Generar Entidad

        private EntidadIncapEvent GenerarEntidad()
        {
            EntidadIncapEvent incapEvent = new EntidadIncapEvent();

            // Si la variable session tiene algo, se le ingresa a la entidad para saber cual modificar
            if (Session["cod_EventIncapacidades"] != null)
            {
                incapEvent.Cod_incap_event = int.Parse(Session["cod_EventIncapacidades"].ToString());
                incapEvent.Existe = true;
            }
            // Si la variable no tiene ningún COD se crea uno nuevo
            else
            {
                incapEvent.Cod_incap_event = -1;
                incapEvent.Existe = false;
            }

            //Estos otros txt se les ingresa el resto de info
            incapEvent.Cod_entrenador=int.Parse(txtCodEntrenador.Text);
            incapEvent.Dia_inicio_IE= CalDiaInicio.SelectedDate;// Establece la fecha o obtiene el método selectedDate
            incapEvent.Dia_fin_IE= CalDiaFin.SelectedDate;
            incapEvent.Observaciones= txtObservaciones.Text;            

            return incapEvent;
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            EntidadIncapEvent incapEvent;
            BLIncapEvent logica = new BLIncapEvent(clsConfiguracion.getConnectionString);
            int cod;
            try
            {
                if (!Page.IsPostBack)
                {
                    //Se usa una variable session para enviar del otro formulario a este el COD o el identity para saber si el registro existe
                    //Si la variable de SESION contiene un valor, MODIFICAMOS un registro 
                    if (Session["cod_EventIncapacidades"] != null)
                    {
                        cod = int.Parse(Session["cod_EventIncapacidades"].ToString());
                        incapEvent = logica.ObtenerIncapEvent(cod);

                        if (incapEvent.Existe)
                        {
                            txtCodIncapEvent.Text = incapEvent.Cod_incap_event.ToString();
                            txtCodEntrenador.Text= incapEvent.Cod_entrenador.ToString();
                            CalDiaInicio.SelectedDate = incapEvent.Dia_inicio_IE; // Establece la fecha o obtiene el método selectedDate
                            CalDiaFin.SelectedDate = incapEvent.Dia_fin_IE;
                            txtObservaciones.Text = incapEvent.Observaciones;

                            lblCodIncapEvent.Visible = true;
                            txtCodIncapEvent.Visible = true;
                        }
                        else
                        {
                            script = string.Format("javascript:mostrarMensaje('Incapacidad o Evento no encontrado')");
                            ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", script, true);
                        }
                    }
                    //Si la SESION no contenía nada, es decir si es CREAR un cliente nuevo
                    else
                    {
                        limpiar();
                        txtCodIncapEvent.Text = "-1";

                        lblCodIncapEvent.Visible = false;
                        txtCodIncapEvent.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                {
                    script = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                    ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", script, true);

                    //Redireccionar (regresar) al formulario principal
                    Response.Redirect("evento_incapcidad.aspx");
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            EntidadIncapEvent incapEvent;
            BLIncapEvent logica = new BLIncapEvent(clsConfiguracion.getConnectionString);
            int resultado;

            try
            {
                incapEvent = GenerarEntidad();

                if (!string.IsNullOrEmpty(txtCodEntrenador.Text)) // Los campos deben ser requeridos
                {
                    // Si el cliente ya existe, se MODIFICA
                    if (incapEvent.Existe)
                    {
                        resultado = logica.Modificar(incapEvent);
                    }
                    // Si el cliente no existe, se CREA uno nuevo
                    else
                    {
                        resultado = logica.Insertar(incapEvent);
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

                    Response.Redirect("evento_incapcidad.aspx"); // Lo manda la formulario devuelta ya que cancela
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("evento_incapcidad.aspx");
        }
    }
}