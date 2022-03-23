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
    public partial class mantenimientoMatricula : System.Web.UI.Page
    {
        //CODE BEHIND:

        string script; // Variable Global

        #region Método Limpiar
        public void limpiar()
        {
            txtCodAtleta.Text = string.Empty;
            txtCodModAbiert.Text = string.Empty;
            CalFechaMatricula.Text = string.Empty;
            txtNotaFinal.Text = string.Empty;
            txtMontoCancelado.Text = string.Empty;
        }
        #endregion

        #region Generar Entidad

        private EntidadMatricula GenerarEntidad()
        {
            EntidadMatricula matricula = new EntidadMatricula();

            // Si la variable session tiene algo, se le ingresa a la entidad para saber cual modificar
            if (Session["cod_matricula"] != null)
            {
                matricula.Cod_mod_abierto = int.Parse(Session["cod_matricula"].ToString());
                matricula.Actividad = true;
            }
            // Si la variable no tiene ningún COD se crea uno nuevo
            else
            {
                matricula.Cod_mod_abierto = -1;
                matricula.Actividad = false;
            }

            //Estos otros txt se les ingresa el resto de info
            matricula.Cod_atleta = Convert.ToInt32(txtCodAtleta.Text);
            matricula.Cod_mod_abierto = Convert.ToInt32(txtCodModAbiert.Text);
            matricula.Fecha_matri = Convert.ToDateTime(CalFechaMatricula.Text);
            matricula.Estado = CBEstado.SelectedValue;
            //matricula.Nota_final = Convert.ToDecimal(txtNotaFinal.Text);
            matricula.Monto_cancelado = Convert.ToInt32(txtMontoCancelado.Text);
            matricula.Tipo_cobro = CBTipoCobro.SelectedValue;
            matricula.Tipo_pago = CBTipoPago.SelectedValue;

            return matricula;
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            EntidadMatricula matricula;
            BLMatricula logica = new BLMatricula(clsConfiguracion.getConnectionString);
            int cod;
            try
            {
                if (!Page.IsPostBack)
                {
                    //Se usa una variable session para enviar del otro formulario a este el COD o el identity para saber si el registro existe
                    //Si la variable de SESION contiene un valor, MODIFICAMOS un registro 
                    if (Session["cod_matricula"] != null)
                    {
                        cod = int.Parse(Session["cod_matricula"].ToString());
                        matricula = logica.ObtenerMatricula(cod);

                        if (matricula.Actividad)
                        {
                            txtCodModAbiert.Text = matricula.Cod_matricula.ToString();
                            txtCodAtleta.Text = matricula.Cod_atleta.ToString();
                            txtCodModAbiert.Text = matricula.Cod_mod_abierto.ToString();
                            CalFechaMatricula.Text = matricula.Fecha_matri.ToString();
                            CBEstado.SelectedValue = matricula.Estado;
                            txtNotaFinal.Text = matricula.Nota_final.ToString();
                            txtMontoCancelado.Text = matricula.Monto_cancelado.ToString();
                            CBTipoCobro.SelectedValue = matricula.Tipo_cobro;
                            CBTipoPago.SelectedValue = matricula.Tipo_pago;

                            lblCodMatricula.Visible = true;
                            txtCodMatricula.Visible = true;
                        }
                        else
                        {
                            script = string.Format("javascript:mostrarMensaje('Matrícula no encontrado')");
                            ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", script, true);
                        }
                    }
                    //Si la SESION no contenía nada, es decir si es CREAR un cliente nuevo
                    else
                    {
                        limpiar();
                        txtCodMatricula.Text = "-1";

                        lblCodMatricula.Visible = false;
                        txtCodMatricula.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                {
                    script = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                    ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", script, true);

                    //Redireccionar (regresar) al formulario principal
                    Response.Redirect("matricula.aspx");
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            EntidadMatricula matricula;
            BLMatricula logica = new BLMatricula(clsConfiguracion.getConnectionString);
            int resultado;

            try
            {
                matricula = GenerarEntidad();

                if (!string.IsNullOrEmpty(txtCodAtleta.Text) && !string.IsNullOrEmpty(txtCodModAbiert.Text) && !string.IsNullOrEmpty(CalFechaMatricula.Text) && !string.IsNullOrEmpty(txtNotaFinal.Text) && !string.IsNullOrEmpty(txtMontoCancelado.Text)) // Los campos deben ser requeridos
                {
                    // Si el cliente ya existe, se MODIFICA
                    if (matricula.Actividad)
                    {
                        resultado = logica.Modificar(matricula);
                    }
                    // Si el cliente no existe, se CREA uno nuevo
                    else
                    {
                        resultado = logica.Insertar(matricula);
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

                    Response.Redirect("matricula.aspx"); // Lo manda la formulario devuelta ya que cancela
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("matricula.aspx");
        }
    }
}