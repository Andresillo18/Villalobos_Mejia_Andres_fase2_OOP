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
    public partial class atleta : System.Web.UI.Page
    {
        //CODE BEHIND

        string script = "";//Variable Global

        #region CargarListaDataSet
        private void CargarListaDataSet(string condicion = "", string orden = "")
        {
            BLAtleta logica = new BLAtleta(clsConfiguracion.getConnectionString); // Se hace una instancia de la capa lógica
            DataSet DSAtleta;

            try
            {
                DSAtleta = logica.listarAtletas(condicion, orden);
                if (DSAtleta != null)
                {
                    grdAtletas.DataSource = DSAtleta;
                    grdAtletas.DataMember = DSAtleta.Tables[0].TableName; // la primera tabla devuelta

                    grdAtletas.DataBind(); // Es necesario para que se visualicen los datos, los enlaza
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

        protected void lnkModificar_Command(object sender, CommandEventArgs e)
        {
            //Aquí se le asigna el valor de session, que será lo que le enviará el ID al otro formulario

            // En el valor de SESION es el valor que contenga el Command ( EvaL() )
            Session["cod_atleta"] = e.CommandArgument.ToString();

            // Redireccionamos al otro formulario (FrmClientes)

            Response.Redirect("mantenimientoAtleta.aspx");
        }

        protected void lnkEliminar_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString()); // Se lee el ID, se usa el evento Eval() y esta es la forma de tener el objeto en un int
            BLAtleta logica = new BLAtleta(clsConfiguracion.getConnectionString);
            EntidadAtleta atleta = new EntidadAtleta();

            try
            {
                atleta = logica.ObtenerAtleta(id); // Le devuelve la consulta o el registro según el ID al presionar ELIMINAR Así se sabe si existe                
                if (atleta.Estado) // En este caso usa un estado para saber si es existe
                {
                    if (logica.EliminarAtleta(id) > 0)
                    {

                        script = string.Format("javascript:mostrarMensaje('Atleta eliminado satisfactoriamente')");
                        ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", script, true);

                        CargarListaDataSet();
                        txtAtleta.Text = "";
                    }
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
            Session.Remove("cod_atleta");

            // Redireccionamos al otro formulario:
            Response.Redirect("mantenimientoAtleta.aspx");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string condicion = string.Format("NOMBRE_ATLETA LIKE '%{0}%'", txtAtleta.Text); // Se une todo en un string para hacer la condición según lo que escriba el usuario
                CargarListaDataSet(condicion);
            }
            catch (Exception ex)
            {
                script = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", script, true);
            }
        }

        protected void grdAtletas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdAtletas.PageIndex = e.NewPageIndex;
            CargarListaDataSet();
        }
    }
}