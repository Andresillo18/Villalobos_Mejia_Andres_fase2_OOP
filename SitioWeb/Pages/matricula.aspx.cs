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
    public partial class matricula : System.Web.UI.Page
    {
        //CODE BEHIND

        string script = "";//Variable Global

        #region CargarListaDataSet
        private void CargarListaDataSet(string condicion = "", string orden = "")
        {
            BLMatricula logica = new BLMatricula(clsConfiguracion.getConnectionString); // Se hace una instancia de la capa lógica
            DataSet DSMatricula;

            try
            {
                DSMatricula = logica.listarMatriculas(condicion, orden);
                if (DSMatricula != null)
                {
                    grdMatriculas.DataSource = DSMatricula;
                    grdMatriculas.DataMember = DSMatricula.Tables[0].TableName; // la primera tabla devuelta

                    grdMatriculas.DataBind(); // Es necesario para que se visualicen los datos, los enlaza
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

        protected void lnkEliminar_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString()); // Se lee el ID, se usa el evento Eval() y esta es la forma de tener el objeto en un int
            BLMatricula logica = new BLMatricula(clsConfiguracion.getConnectionString);
            EntidadMatricula matricula = new EntidadMatricula();

            try
            {
                matricula = logica.ObtenerMatricula(id); // Le devuelve la consulta o el registro según el ID al presionar ELIMINAR Así se sabe si existe                
                if (matricula.Actividad)
                {
                    if (logica.EliminarMatricula(id) > 0)
                    {

                        script = string.Format("javascript:mostrarMensaje('Matrícula eliminada satisfactoriamente')");
                        ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", script, true);

                        CargarListaDataSet();                       
                    }
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
            Session["cod_matricula"] = e.CommandArgument.ToString();

            // Redireccionamos al otro formulario (FrmClientes)

            Response.Redirect("mantenimientoMatricula.aspx");
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            // Eliminamos la variable de sesión, así no se confundirá que tiene la variable por el doble uso
            Session.Remove("cod_matricula");

            // Redireccionamos al otro formulario:
            Response.Redirect("mantenimientoMatricula.aspx");
        }

        protected void grdLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdMatriculas.PageIndex = e.NewPageIndex; // el método de cambio de página genera una nueva página al recibir el evento
            CargarListaDataSet();
        }
    }
}