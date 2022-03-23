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
    public partial class mantenimientoCertificacion : System.Web.UI.Page
    {
        //CODE BEHIND:

        string script; // Variable Global

        #region Método Limpiar
        public void limpiar()
        {
            txtCodEntrenador.Text = string.Empty;
            CBGimnasio.Checked = false;
            CBNatacion.Checked = false;
            CBMaraton.Checked = false;
            CBCiclismo.Checked = false;            
        }
        #endregion

        #region Generar Entidad

        private EntidadCertificacion GenerarEntidad()
        {
            EntidadCertificacion certificacion = new EntidadCertificacion();

            // Si la variable session tiene algo, se le ingresa a la entidad para saber cual modificar
            if (Session["cod_certificacion"] != null)
            {
                certificacion.Cod_certificacion = int.Parse(Session["cod_certificacion"].ToString());
                certificacion.Existe = true;
            }
            // Si la variable no tiene ningún COD se crea uno nuevo
            else
            {
                certificacion.Cod_certificacion = -1;
                certificacion.Existe = false;
            }

            //Estos otros txt se les ingresa el resto de info
            certificacion.Cod_entrenador = int.Parse(txtCodEntrenador.Text);

            if (CBGimnasio.Checked)
            {
                certificacion.Gimnasio_especifi = true;
            }
            else
            {
                certificacion.Gimnasio_especifi = false;
            }

            if (CBNatacion.Checked)
            {
                certificacion.Natacion_especifi= true;
            }
            else
            {
                certificacion.Natacion_especifi= false;
            }

            if (CBMaraton.Checked)
            {
                certificacion.Maraton_especifi= true;
            }
            else
            {
                certificacion.Maraton_especifi= false;
            }

            if (CBCiclismo.Checked)
            {
                certificacion.Ciclismo_especifi= true;
            }
            else
            {
                certificacion.Ciclismo_especifi= false;
            }

            return certificacion;
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            EntidadCertificacion certificacion;
            BLCertificacion logica = new BLCertificacion(clsConfiguracion.getConnectionString);
            int cod;
            try
            {
                if (!Page.IsPostBack)
                {
                    //Se usa una variable session para enviar del otro formulario a este el COD o el identity para saber si el registro existe
                    //Si la variable de SESION contiene un valor, MODIFICAMOS un registro 
                    if (Session["cod_certificacion"] != null)
                    {
                        cod = int.Parse(Session["cod_certificacion"].ToString());
                        certificacion = logica.ObtenerCertificacion(cod);

                        if (certificacion.Existe)
                        {
                            txtCodCertificacion.Text = certificacion.Cod_certificacion.ToString();
                            txtCodEntrenador.Text = certificacion.Cod_entrenador.ToString();
                            if (certificacion.Gimnasio_especifi == true)
                            {
                                CBGimnasio.Checked = true;
                            }
                            else
                            {
                                CBGimnasio.Checked = false;
                            }

                            if (certificacion.Natacion_especifi== true)
                            {
                                CBNatacion.Checked = true;
                            }
                            else
                            {
                                CBNatacion.Checked = false;
                            }
                            if (certificacion.Maraton_especifi == true)
                            {
                                CBMaraton.Checked = true;
                            }
                            else
                            {
                                CBMaraton.Checked = false;
                            }

                            if (certificacion.Ciclismo_especifi== true)
                            {
                                CBCiclismo.Checked = true;
                            }
                            else
                            {
                                CBCiclismo.Checked = false;
                            }                         

                            lblCodCertificacion.Visible = true;
                            txtCodCertificacion.Visible = true;
                        }
                        else
                        {
                            script = string.Format("javascript:mostrarMensaje('Certificación no encontrado')");
                            ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", script, true);
                        }
                    }
                    //Si la SESION no contenía nada, es decir si es CREAR un cliente nuevo
                    else
                    {
                        limpiar();
                        txtCodCertificacion.Text = "-1";

                        lblCodCertificacion.Visible = false;
                        txtCodCertificacion.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                {
                    script = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                    ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", script, true);

                    //Redireccionar (regresar) al formulario principal
                    Response.Redirect("certificacion.aspx");
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("certificacion.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            EntidadCertificacion certificacion;
            BLCertificacion logica = new BLCertificacion(clsConfiguracion.getConnectionString);
            int resultado;

            try
            {
                certificacion = GenerarEntidad();

                // Si el cliente ya existe, se MODIFICA
                if (certificacion.Existe)
                {
                    resultado = logica.Modificar(certificacion);
                }
                // Si el cliente no existe, se CREA uno nuevo
                else
                {
                    resultado = logica.Insertar(certificacion);
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

                    Response.Redirect("certificacion.aspx"); // Lo manda la formulario devuelta ya que cancela
                }
            }
        }
    }
}