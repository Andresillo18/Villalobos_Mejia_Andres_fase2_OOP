﻿using System;
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
    public partial class abrirModulo : System.Web.UI.Page
    {
        //CODE BEHIND

        string script = "";//Variable Global

        #region CargarListaDataSet
        private void CargarListaDataSet(string condicion = "", string orden = "")
        {
            BLModAbier logica = new BLModAbier(clsConfiguracion.getConnectionString); // Se hace una instancia de la capa lógica
            DataSet DSModAbierto;

            try
            {
                DSModAbierto = logica.listarModulos(condicion, orden);
                if (DSModAbierto != null)
                {
                    grdModulos.DataSource = DSModAbierto;
                    grdModulos.DataMember = DSModAbierto.Tables[0].TableName; // la primera tabla devuelta

                    grdModulos.DataBind(); // Es necesario para que se visualicen los datos, los enlaza
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack) // Si la página no es la primera vez que se carga que se cargue la BD 
                {
                    CargarListaDataSet();
                }
            }
            catch (Exception ex)
            {
                script = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", script, true);

            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            // Eliminamos la variable de sesión, así no se confundirá que tiene la variable por el doble uso
            Session.Remove("cod_modulo");

            // Redireccionamos al otro formulario:
            Response.Redirect("mantenimientoModAbiert.aspx"); 
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string condicion = string.Format("COD_MODULO LIKE '%{0}%'", txtModuloAbierto.Text); // Se une todo en un string para hacer la condición según lo que escriba el usuario
                CargarListaDataSet(condicion);
            }
            catch (Exception ex)
            {
                script = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);

            }
        }

        protected void lnkModificar_Command(object sender, CommandEventArgs e)
        {
            //Aquí se le asigna el valor de session, que será lo que le enviará el ID al otro formulario
            // En el valor de SESION es el valor que contenga el Command ( EvaL() )
            Session["cod_modulo"] = e.CommandArgument.ToString();

            // Redireccionamos al otro formulario (FrmClientes)

            Response.Redirect("mantenimientoModAbiert.aspx");
        }

        protected void lnkEliminar_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString()); // Se lee el ID, se usa el evento Eval() y esta es la forma de tener el objeto en un int
            BLModAbier logica = new BLModAbier(clsConfiguracion.getConnectionString);
            EntidadModAbier modulo = new EntidadModAbier();

            try
            {
                modulo = logica.ObtenerModulo(id); // Le devuelve la consulta o el registro según el ID al presionar ELIMINAR Así se sabe si existe                
                if (modulo.Existe)
                {
                    if (logica.EliminarModuloAbier(id) > 0)
                    {

                        script = string.Format("javascript:mostrarMensaje('Programa eliminado satisfactoriamente')");
                        ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", script, true);

                        CargarListaDataSet();
                        txtModuloAbierto.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                script = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", script, true);

            }
        }

        protected void grdLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdModulos.PageIndex = e.NewPageIndex; // el método de cambio de página genera una nueva página al recibir el evento
            CargarListaDataSet();
        }
    }
}