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
    public partial class mantenimientoHorEntrenador : System.Web.UI.Page
    {
        //CODE BEHIND:

        string script; // Variable Global

        #region Método Limpiar
        public void limpiar()
        {
            txtCodEntrenador.Text = string.Empty;
            CBLunes.Checked = false;
            CBMartes.Checked = false;
            CBMiercoles.Checked = false;
            CBJueves.Checked = false;
            CBViernes.Checked = false;
            CBSabado.Checked = false;
            CBSabado.Checked = false;
            CBDomingo.Checked = false;
            txtTimeStart.Text = string.Empty;
            txtTimeEnd.Text = string.Empty;

        }
        #endregion

        #region Generar Entidad

        private EntidadHorarEntrenador GenerarEntidad()
        {
            EntidadHorarEntrenador horaEntrenador = new EntidadHorarEntrenador();

            // Si la variable session tiene algo, se le ingresa a la entidad para saber cual modificar
            if (Session["cod_horaEntrenador"] != null)
            {
                horaEntrenador.Cod_Horario_entrenador = int.Parse(Session["cod_horaEntrenador"].ToString());
                horaEntrenador.Existe = true;
            }
            // Si la variable no tiene ningún COD se crea uno nuevo
            else
            {
                horaEntrenador.Cod_Horario_entrenador = -1;
                horaEntrenador.Existe = false;
            }

            //Estos otros txt se les ingresa el resto de info
            horaEntrenador.Cod_entrenador = int.Parse(txtCodEntrenador.Text);

            if (CBLunes.Checked)
            {
                horaEntrenador.Dia_lunes = true;
            }
            else
            {
                horaEntrenador.Dia_lunes = false;
            }

            if (CBMartes.Checked)
            {
                horaEntrenador.Dia_martes = true;
            }
            else
            {
                horaEntrenador.Dia_martes = false;
            }

            if (CBMiercoles.Checked)
            {
                horaEntrenador.Dia_miercoles = true;
            }
            else
            {
                horaEntrenador.Dia_miercoles = false;
            }

            if (CBJueves.Checked)
            {
                horaEntrenador.Dia_jueves = true;
            }
            else
            {
                horaEntrenador.Dia_jueves = false;
            }

            if (CBViernes.Checked)
            {
                horaEntrenador.Dia_viernes = true;
            }
            else
            {
                horaEntrenador.Dia_viernes = false;
            }

            if (CBSabado.Checked)
            {
                horaEntrenador.Dia_sabado = true;
            }
            else
            {
                horaEntrenador.Dia_sabado = false;
            }

            if (CBDomingo.Checked)
            {
                horaEntrenador.Dia_domingo = true;
            }
            else
            {
                horaEntrenador.Dia_domingo = false;
            }
            
            horaEntrenador.Hora_inicio = TimeSpan.Parse(txtTimeStart.Text);
            horaEntrenador.Hora_fin = TimeSpan.Parse(txtTimeEnd.Text);

            return horaEntrenador;
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            EntidadHorarEntrenador HoraEntrenador;
            BLHorarEntrenador logica = new BLHorarEntrenador(clsConfiguracion.getConnectionString);
            int cod;
            try
            {
                if (!Page.IsPostBack)
                {
                    //Se usa una variable session para enviar del otro formulario a este el COD o el identity para saber si el registro existe
                    //Si la variable de SESION contiene un valor, MODIFICAMOS un registro 
                    if (Session["cod_horaEntrenador"] != null)
                    {
                        cod = int.Parse(Session["cod_horaEntrenador"].ToString());
                        HoraEntrenador = logica.ObtenerHorario(cod);

                        if (HoraEntrenador.Existe)
                        {
                            txtCodHoraEntrenador.Text = HoraEntrenador.Cod_Horario_entrenador.ToString();
                            txtCodEntrenador.Text = HoraEntrenador.Cod_entrenador.ToString();
                            if (HoraEntrenador.Dia_lunes == true)
                            {
                                CBLunes.Checked = true;
                            }
                            else
                            {
                                CBLunes.Checked = false;
                            }

                            if (HoraEntrenador.Dia_martes == true)
                            {
                                CBMartes.Checked = true;
                            }
                            else
                            {
                                CBMartes.Checked = false;
                            }
                            if (HoraEntrenador.Dia_miercoles == true)
                            {
                                CBMiercoles.Checked = true;
                            }
                            else
                            {
                                CBMiercoles.Checked = false;
                            }

                            if (HoraEntrenador.Dia_jueves == true)
                            {
                                CBJueves.Checked = true;
                            }
                            else
                            {
                                CBJueves.Checked = false;
                            }

                            if (HoraEntrenador.Dia_viernes == true)
                            {
                                CBViernes.Checked = true;
                            }
                            else
                            {
                                CBViernes.Checked = false;
                            }

                            if (HoraEntrenador.Dia_sabado == true)
                            {
                                CBSabado.Checked = true;
                            }
                            else
                            {
                                CBSabado.Checked = false;
                            }

                            if (HoraEntrenador.Dia_domingo == true)
                            {
                                CBDomingo.Checked = true;
                            }
                            else
                            {
                                CBDomingo.Checked = false;
                            }

                            txtTimeStart.Text = HoraEntrenador.Hora_inicio.ToString();
                            txtTimeEnd.Text = HoraEntrenador.Hora_fin.ToString();

                            lblCodHoraEntrenador.Visible = true;
                            txtCodHoraEntrenador.Visible = true;
                        }
                        else
                        {
                            script = string.Format("javascript:mostrarMensaje('Horario no encontrado')");
                            ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", script, true);
                        }
                    }
                    //Si la SESION no contenía nada, es decir si es CREAR un cliente nuevo
                    else
                    {
                        limpiar();
                        txtCodHoraEntrenador.Text = "-1";

                        lblCodHoraEntrenador.Visible = false;
                        txtCodHoraEntrenador.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                {
                    script = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                    ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", script, true);

                    //Redireccionar (regresar) al formulario principal
                    Response.Redirect("horarioEntrenador.aspx");
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            EntidadHorarEntrenador horaEntrenador;
            BLHorarEntrenador logica = new BLHorarEntrenador(clsConfiguracion.getConnectionString);
            int resultado;

            try
            {
                horaEntrenador = GenerarEntidad();

                // Si el cliente ya existe, se MODIFICA
                if (horaEntrenador.Existe)
                {
                    resultado = logica.Modificar(horaEntrenador);
                }
                // Si el cliente no existe, se CREA uno nuevo
                else
                {
                    resultado = logica.Insertar(horaEntrenador);
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

                    Response.Redirect("horarioEntrenador.aspx"); // Lo manda la formulario devuelta ya que cancela
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("horarioEntrenador.aspx");
        }
    }
}