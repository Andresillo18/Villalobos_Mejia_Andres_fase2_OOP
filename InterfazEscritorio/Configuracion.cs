using System;
using System.Collections.Generic;
using System.Text;

namespace InterfazEscritorio
{
    class Configuracion
    {
        //Esta clase servirá para pasar a todas las capas la cadena de conexión de la BD, lo obtiene del archivo de 
        //Settings.settings, de la carpeta Properties
        public static string getConnectionString
        {
            get
            {
                return Properties.Settings.Default.ConnectionString;
            }
        }
    }
}
