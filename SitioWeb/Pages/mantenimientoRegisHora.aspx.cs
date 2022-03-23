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
    public partial class mantenimientoRegisHora : System.Web.UI.Page
    {
        //CODE BEHIND:

        string script; // Variable Global

        #region Método Limpiar
        public void limpiar()
        {
            txtCodEntrenador.Text = string.Empty;
            CalDiaRegistro.SelectedDate = DateTime.Today; //??
            txtTimeStart.Text = string.Empty;
            txtTimeEnd.Text = string.Empty;

        }
        #endregion

        #region Generar Entidad

        private EntidadRegisHoraLabo GenerarEntidad()
        {
            EntidadRegisHoraLabo horaLabo = new EntidadRegisHoraLabo();

            // Si la variable session tiene algo, se le ingresa a la entidad para saber cual modificar
            if (Session["cod_regisHoraLabo"] != null)
            {
                horaLabo.Cod_regisHoraLabo = int.Parse(Session["cod_regisHoraLabo"].ToString());
                horaLabo.Existe = true;
            }
            // Si la variable no tiene ningún COD se crea uno nuevo
            else
            {
                horaLabo.Cod_regisHoraLabo = -1;
                horaLabo.Existe = false;
            }

            //Estos otros txt se les ingresa el resto de info
            horaLabo.Cod_entrenador = int.Parse(txtCodEntrenador.Text);
            horaLabo.Dia_regisHoraLabo = CalDiaRegistro.SelectedDate;
            horaLabo.Hora_inicio = TimeSpan.Parse(txtTimeStart.Text);
            horaLabo.Hora_fin = TimeSpan.Parse(txtTimeEnd.Text);

            return horaLabo;
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            EntidadRegisHoraLabo horaLabo;
            BLRegisHoraLabo logica = new BLRegisHoraLabo(clsConfiguracion.getConnectionString);
            int cod;
            try
            {
                if (!Page.IsPostBack)
                {
                    //Se usa una variable session para enviar del otro formulario a este el COD o el identity para saber si el registro existe
                    //Si la variable de SESION contiene un valor, MODIFICAMOS un registro 
                    if (Session["cod_regisHoraLabo"] != null)
                    {
                        cod = int.Parse(Session["cod_regisHoraLabo"].ToString());
                        horaLabo = logica.ObtenerRegisHorasLabo(cod);

                        if (horaLabo.Existe)
                        {
                            txtCodRegHoras.Text = horaLabo.Cod_regisHoraLabo.ToString();
                            txtCodEntrenador.Text = horaLabo.Cod_entrenador.ToString();
                            CalDiaRegistro.SelectedDate = horaLabo.Dia_regisHoraLabo;

                            txtTimeStart.Text = horaLabo.Hora_inicio.ToString();
                            txtTimeEnd.Text = horaLabo.Hora_fin.ToString();

                            lblCodRegHoras.Visible = true;
                            txtCodRegHoras.Visible = true;
                        }
                        else
                        {
                            script = string.Format("javascript:mostrarMensaje('Horas laboradas no encontradas')");
                            ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", script, true);
                        }
                    }
                    //Si la SESION no contenía nada, es decir si es CREAR un cliente nuevo
                    else
                    {
                        limpiar();
                        txtCodRegHoras.Text = "-1";

                        lblCodRegHoras.Visible = false;
                        txtCodRegHoras.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                {
                    script = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                    ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", script, true);

                    //Redireccionar (regresar) al formulario principal
                    Response.Redirect("registroHora.aspx");
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            EntidadRegisHoraLabo horaLabo;
            BLRegisHoraLabo logica = new BLRegisHoraLabo(clsConfiguracion.getConnectionString);
            int resultado;

            try
            {
                horaLabo = GenerarEntidad();

                // Si el cliente ya existe, se MODIFICA
                if (horaLabo.Existe)
                {
                    resultado = logica.Modificar(horaLabo);
                }
                // Si el cliente no existe, se CREA uno nuevo
                else
                {
                    resultado = logica.Insertar(horaLabo);
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
            catch (Exception ex)
            {
                {
                    script = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                    ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", script, true);

                    Response.Redirect("registroHora.aspx"); // Lo manda la formulario devuelta ya que cancela
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("registroHora.aspx");
        }
    }
}