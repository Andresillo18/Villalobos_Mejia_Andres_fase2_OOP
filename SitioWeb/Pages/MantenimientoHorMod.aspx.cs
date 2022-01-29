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
    public partial class MantenimientoHorMod : System.Web.UI.Page
    {
        //CODE BEHIND:

        string script; // Variable Global

        #region Método Limpiar
        public void limpiar()
        {
            CBLunes.Checked = false;
            CBMartes.Checked = false;
            CBMiercoles.Checked = false;
            CBJueves.Checked = false;
            CBViernes.Checked = false;
            CBSabado.Checked = false;
            CBSabado.Checked = false;
            CBDomingo.Checked = false;

        }
        #endregion

        #region Generar Entidad

        private EntidadHorarMod GenerarEntidad()
        {
            EntidadHorarMod horaMod = new EntidadHorarMod();

            // Si la variable session tiene algo, se le ingresa a la entidad para saber cual modificar
            if (Session["horaMod"] != null)
            {
                horaMod.Cod_Horario_Modulos = int.Parse(Session["horaMod"].ToString());
                horaMod.Existe = true;
            }
            // Si la variable no tiene ningún COD se crea uno nuevo
            else
            {
                horaMod.Cod_Horario_Modulos = -1;
                horaMod.Existe = false;
            }

            //Estos otros txt se les ingresa el resto de info
            if (CBLunes.Checked)
            {
                horaMod.Dia_lunes = true;
            }
            else
            {
                horaMod.Dia_lunes = false;
            }

            if (CBMartes.Checked)
            {
                horaMod.Dia_martes = true;
            }
            else
            {
                horaMod.Dia_martes = false;
            }

            if (CBMiercoles.Checked)
            {
                horaMod.Dia_miercoles = true;
            }
            else
            {
                horaMod.Dia_miercoles = false;
            }

            if (CBJueves.Checked)
            {
                horaMod.Dia_jueves = true;
            }
            else
            {
                horaMod.Dia_jueves = false;
            }

            if (CBViernes.Checked)
            {
                horaMod.Dia_viernes = true;
            }
            else
            {
                horaMod.Dia_viernes = false;
            }

            if (CBSabado.Checked)
            {
                horaMod.Dia_sabado = true;
            }
            else
            {
                horaMod.Dia_sabado = false;
            }

            if (CBDomingo.Checked)
            {
                horaMod.Dia_domingo = true;
            }
            else
            {
                horaMod.Dia_domingo = false;
            }

            horaMod.Hora_inicio = TimeSpan.Parse(txtTimeStart.Text);
            horaMod.Hora_fin = TimeSpan.Parse(txtTimeEnd.Text);

            return horaMod;
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            EntidadHorarMod HoraMod;
            BLHorarMod logica = new BLHorarMod(clsConfiguracion.getConnectionString);
            int cod;
            try
            {
                if (!Page.IsPostBack)
                {
                    //Se usa una variable session para enviar del otro formulario a este el COD o el identity para saber si el registro existe
                    //Si la variable de SESION contiene un valor, MODIFICAMOS un registro 
                    if (Session["horaMod"] != null)
                    {
                        cod = int.Parse(Session["horaMod"].ToString());
                        HoraMod = logica.ObtenerHorario(cod);

                        if (HoraMod.Existe)
                        {
                            txtCodHoraMod.Text = HoraMod.Cod_Horario_Modulos.ToString();
                            if (HoraMod.Dia_lunes == true)
                            {
                                CBLunes.Checked = true;
                            }
                            else
                            {
                                CBLunes.Checked = false;
                            }

                            if (HoraMod.Dia_martes == true)
                            {
                                CBMartes.Checked = true;
                            }
                            else
                            {
                                CBMartes.Checked = false;
                            }
                            if (HoraMod.Dia_miercoles == true)
                            {
                                CBMiercoles.Checked = true;
                            }
                            else
                            {
                                CBMiercoles.Checked = false;
                            }

                            if (HoraMod.Dia_jueves == true)
                            {
                                CBJueves.Checked = true;
                            }
                            else
                            {
                                CBJueves.Checked = false;
                            }

                            if (HoraMod.Dia_viernes == true)
                            {
                                CBViernes.Checked = true;
                            }
                            else
                            {
                                CBViernes.Checked = false;
                            }

                            if (HoraMod.Dia_sabado == true)
                            {
                                CBSabado.Checked = true;
                            }
                            else
                            {
                                CBSabado.Checked = false;
                            }

                            if (HoraMod.Dia_domingo == true)
                            {
                                CBDomingo.Checked = true;
                            }
                            else
                            {
                                CBDomingo.Checked = false;
                            }

                            txtTimeStart.Text = HoraMod.Hora_inicio.ToString();
                            txtTimeEnd.Text = HoraMod.Hora_fin.ToString();

                            lblCodHoraMod.Visible = true;
                            txtCodHoraMod.Visible = true;
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
                        txtCodHoraMod.Text = "-1";

                        lblCodHoraMod.Visible = false;
                        txtCodHoraMod.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                {
                    script = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                    ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", script, true);

                    //Redireccionar (regresar) al formulario principal
                    Response.Redirect("horarioModulo.aspx");
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            EntidadHorarMod horaMod;
            BLHorarMod logica = new BLHorarMod(clsConfiguracion.getConnectionString);
            int resultado;

            try
            {
                horaMod = GenerarEntidad();

                // Si el cliente ya existe, se MODIFICA
                if (horaMod.Existe)
                {
                    resultado = logica.Modificar(horaMod);
                }
                // Si el cliente no existe, se CREA uno nuevo
                else
                {
                    resultado = logica.Insertar(horaMod);
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

                    Response.Redirect("horarioModulo.aspx"); // Lo manda la formulario devuelta ya que cancela
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("horarioModulo.aspx");
        }
    }
}