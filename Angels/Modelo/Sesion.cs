using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angels.Modelo
{
    class Sesion
    {
        public static string Alias { get; set; }
        public static string Correo { get; set; }
        public static string Contraseña { get; set; }
        public static int Puerto { get; set; }
        public static string smtp { get; set; }

        public static void ListarConfiguracion()
        {
            Sesion.Contraseña = ConfigurationManager.AppSettings["contraseña"];
            Sesion.Correo = ConfigurationManager.AppSettings["correo"];
            Sesion.Puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            Sesion.smtp = ConfigurationManager.AppSettings["smtp"];
            Sesion.Alias = ConfigurationManager.AppSettings["alias"];
        }
    }
}
