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
    public partial class mantenimientoModAbiert : System.Web.UI.Page
    {
        //CODE BEHIND:

        string script; // Variable Global

        protected void Page_Load(object sender, EventArgs e)
        {
            EntidadModAbier modulo;
            BLModAbier logica = new BLModAbier(clsConfiguracion.getConnectionString);
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
                            txtCodEntrenador.Text = modulo.Cod_entrenador.ToString();
                            txtCodHorMod.Text = modulo.Cod_hora_mod.ToString();
                            txtCodMod.Text = modulo.Cod_mod.ToString();
                            CalFechaInicio.SelectedDate = modulo.Fecha_inicio;// Establece la fecha o obtiene el método selectedDate
                            txtObservaciones.Text = modulo.Observaciones.ToString();

                            lblCodModulo.Visible = true;
                            txtCodModAbiert.Visible = true;
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
                        txtCodModAbiert.Text = "-1";

                        lblCodModulo.Visible = false;
                        txtCodModAbiert.Visible = false;
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

        #region Método Limpiar
        public void limpiar()
        {
            txtCodEntrenador.Text = string.Empty;
            txtCodHorMod.Text = string.Empty;
            txtCodMod.Text = string.Empty;
            _ = CalFechaInicio.TodaysDate;
            txtObservaciones.Text = string.Empty;
        }
        #endregion

        #region Generar Entidad

        private EntidadModAbier GenerarEntidad()
        {
            EntidadModAbier modulo = new EntidadModAbier();

            // Si la variable session tiene algo, se le ingresa a la entidad para saber cual modificar
            if (Session["cod_modulo"] != null)
            {
                modulo.Cod_mod_abierto = int.Parse(Session["cod_modulo"].ToString());
                modulo.Existe = true;
            }
            // Si la variable no tiene ningún COD se crea uno nuevo
            else
            {
                modulo.Cod_mod_abierto = -1;
                modulo.Existe = false;
            }

            //Estos otros txt se les ingresa el resto de info
            modulo.Cod_entrenador = Convert.ToInt32(txtCodEntrenador.Text);
            modulo.Cod_mod = Convert.ToInt32(txtCodMod.Text);
            modulo.Cod_hora_mod= Convert.ToInt32(txtCodHorMod.Text);
            modulo.Fecha_inicio = CalFechaInicio.SelectedDate;// Establece la fecha o obtiene el método selectedDate
            modulo.Observaciones= txtObservaciones.Text;

            return modulo;
        }

        #endregion

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            EntidadModAbier modAbiert;
            BLModAbier logica = new BLModAbier(clsConfiguracion.getConnectionString);
            int resultado;

            try
            {
                modAbiert = GenerarEntidad();

                if (!string.IsNullOrEmpty(txtCodEntrenador.Text) && !string.IsNullOrEmpty(txtCodHorMod.Text) && !string.IsNullOrEmpty(txtCodHorMod.Text)) // Los campos deben ser requeridos
                {
                    // Si el cliente ya existe, se MODIFICA
                    if (modAbiert.Existe)
                    {
                        resultado = logica.Modificar(modAbiert);
                    }
                    // Si el cliente no existe, se CREA uno nuevo
                    else
                    {
                        resultado = logica.Insertar(modAbiert);
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

                    Response.Redirect("abrirModulo.aspx"); // Lo manda la formulario devuelta ya que cancela
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("abrirModulo.aspx");
        }
    }
}