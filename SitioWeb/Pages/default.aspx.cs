using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data; // Se ocupa para el uso de dataset y para guardar la información para la tabla

using CapaLogicaNegocio;
using CapaEntidades;

namespace SitioWeb
{
    public partial class _default : System.Web.UI.Page
    {
        //CODE BEHIND

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack) // Si la página no es la primera vez que se carga que se cargue la BD 
                {
                    CargarListaDataSet();
                }
            }
            catch (Exception)
            {
                //throw;
                // De momento no vamos a incluir nada en el catch
            }

        }

        #region CargarListaDataSet
        private void CargarListaDataSet(string condicion = "", string orden = "")
        {
            BLPrograma logica = new BLPrograma(clsConfiguracion.getConnectionString); // Se hace una instancia de la capa lógica
            DataSet DSClientes;

            try
            {
                DSClientes = logica.listarProgramas(condicion, orden);
                if (DSClientes != null)
                {
                    grdLista.DataSource = DSClientes;
                    grdLista.DataMember = DSClientes.Tables[0].TableName; // la primera tabla devuelta

                    grdLista.DataBind(); // Es necesario para que se visualicen los datos, los enlaza
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

    }
}