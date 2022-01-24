using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration; // Para utilizar ConfigurationManager

namespace SitioWeb
{
    public static class clsConfiguracion
    {
        //Se crea un método para enviar la cadena de conexion y SE DEFINE ESTATICA PARA UTILIZAR EL GET SIN HACER UNA INSTANCIA
        public static string getConnectionString
        {
            get
            {
                return ConfigurationManager.AppSettings["ConnectionString"];
            }
        }

    }
}