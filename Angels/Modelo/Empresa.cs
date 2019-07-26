using Angels.Clase;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Angels.Modelo
{
    public class Empresa
    {
        public string NombreComercial { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string TipoContribuyente { get; set; }
        public string FechaInscripcion { get; set; }
        public string FechaInicioActividad { get; set; }
        public string EstadoContribuyente { get; set; }
        public string CondicionContribuyente { get; set; }
        public string SistemaEmisionComprobante { get; set; }
        public string ActividadComercioExterior { get; set; }
        public string SistemaContabilidad { get; set; }
    }

    public class DBEmpresa
    {
        public DBEmpresa()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
        }


        Imagen img = new Imagen();
        public Empresa GetEmpresa(string Ruc, CookieContainer cookie)
        {
            Image image = img.UrlFromImage("http://www.sunat.gob.pe/cl-ti-itmrconsruc/captcha?accion=image&magic=2", cookie);
            string codigo = img.ImageFromText(image);
            Empresa empresa;
            try
            {
                //A este link le pasamos los datos , RUC y valor del captcha
                string myUrl = String.Format("http://www.sunat.gob.pe/cl-ti-itmrconsruc/jcrS00Alias?accion=consPorRuc&nroRuc={0}&codigo={1}", Ruc, codigo);
                HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(myUrl);
                myWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:23.0) Gecko/20100101 Firefox/23.0";
                myWebRequest.CookieContainer = cookie;
                myWebRequest.Credentials = CredentialCache.DefaultCredentials;
                myWebRequest.Proxy = null;
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myWebRequest.GetResponse();
                Stream myStream = myHttpWebResponse.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myStream);
                //Leemos los datos
                string xDat = HttpUtility.HtmlDecode(myStreamReader.ReadToEnd());
                if (xDat.Length <= 635)
                {
                    return null;
                }
                string[] tabla;
                xDat = xDat.Replace("     ", " ");
                xDat = xDat.Replace("    ", " ");
                xDat = xDat.Replace("   ", " ");
                xDat = xDat.Replace("  ", " ");
                xDat = xDat.Replace("( ", "(");
                xDat = xDat.Replace(" )", ")");
                //Lo convertimos a tabla o mejor dicho a un arreglo de string como se ve declarado arriba
                tabla = Regex.Split(xDat, "<td class");
                //separamos el arreglo que hasta ese momento tenia 1 solo item , y lo dividimos por la etiqueta tdclass
                //Esto lo hice porque cuando es persona el ruc empieza con 1 
                //y tiene un resultado distinto a cuando es empresa ...
                if (Ruc.StartsWith("1"))
                {
                    //tabla[17] = tabla[17].Replace("=\"bg\" colspan=3>", "");
                    //tabla[17] = tabla[17].Replace("</td>\r\n </tr>\r\n<!-- SE COMENTO POR INDICACION DEL PASE PAS20134EA20000207 -->\r\n<!-- <tr> -->\r\n<!-- ", "");
                    //vRazonSocial = (string)tabla[1];
                    //vDireccion = (string)tabla[17];

                    //RAZON SOCIAL
                    tabla[1] = tabla[1].Replace("=\"bg\" colspan=3>" + Ruc + " - ", "").Replace("</td>\r\n </tr>\r\n <tr>\r\n", "");

                    //TIPO CONTRIBUYENTE
                    tabla[3] = tabla[3].Replace("=\"bg\" colspan=3>", "").Replace("</td>\r\n </tr>\r\n <tr>\r\n", "").Replace("</td>", "").Replace("</tr>", "").Replace("<tr>", "");

                    //NOMBRE COMERCIAL
                    tabla[7] = tabla[7].Replace("=\"bg\" colspan=1>", "").Replace("</td>", "").Replace("</tr>", "").Replace("<tr>", "");

                    //DIRECCION
                    tabla[19] = tabla[19].Replace("=\"bg\" colspan=3>", "").Replace("</td>\r\n </tr>\r\n<!-- SE COMENTO POR INDICACION DEL PASE PAS20134EA20000207 -->\r\n<!-- <tr> -->\r\n<!-- ", "").Replace("</td>", "").Replace("</tr>", "").Replace("<tr>", "").Replace("�", "Ñ");

                    //FECHA INSCRIPCION
                    tabla[9] = tabla[9].Replace("=\"bg\" colspan=1>", "").Replace("</td>", "").Replace("</tr>", "").Replace("<tr>", "").Remove(10);

                    //ESTADO CONTRIBUYENTE
                    tabla[12] = tabla[12].Replace("=\"bg\" colspan=1>", "").Replace("</td>", "").Replace("</tr>", "").Replace("<tr>", "");

                    //FECHA INICIO ACTIVIDAD
                    tabla[10] = tabla[10].Replace("=\"bg\" colspan=1>", "").Replace("</td>", "").Replace("</tr>", "").Replace("<tr>", "");

                    //CONDICION CONTRIBUYENTE
                    tabla[15] = tabla[15].Replace("=\"bg\" colspan=1>", "").Replace("</td>", "").Replace("</tr>", "").Replace("<tr>", "");

                    //SISTEMA DE EMISION DE COMPROBANTE
                    tabla[21] = tabla[21].Replace("=\"bg\" colspan=1>", "").Replace("</td>", "").Replace("</tr>", "").Replace("<tr>", "");

                    //ACTIVIDAD DE COMERCIO EXTERIOR
                    tabla[23] = tabla[23].Replace("=\"bg\" colspan=1>", "").Replace("</td>", "").Replace("</tr>", "").Replace("<tr>", "");

                    //SISTEMA CONTABILIDAD
                    tabla[25] = tabla[25].Replace("=\"bg\" colspan=3>", "").Replace("</td>", "").Replace("</tr>", "").Replace("<tr>", "").Replace("<!--I#P_SNADE003-1#20141109#CFS-->", "").Replace("<!--", "");

                    empresa = new Empresa
                    {
                        NombreComercial = tabla[7].ToString().Trim(),
                        RazonSocial = tabla[1].ToString().Trim(),
                        Direccion = tabla[19].ToString().Trim(),
                        TipoContribuyente = tabla[3].Trim(),
                        FechaInscripcion = tabla[9].ToString().Trim(),
                        FechaInicioActividad = tabla[10].ToString().Trim(),
                        EstadoContribuyente = tabla[12].ToString().Trim(),
                        CondicionContribuyente = tabla[15].ToString().Trim(),

                        SistemaEmisionComprobante = tabla[21].ToString().Trim(),
                        ActividadComercioExterior = tabla[23].ToString().Trim(),
                        SistemaContabilidad = tabla[25].ToString().Trim(),
                    };


                    return empresa;
                }
                //RUC 20
                else if (Ruc.StartsWith("2"))
                {
                    //RAZON SOCIAL
                    tabla[1] = tabla[1].Replace("=\"bg\" colspan=3>" + Ruc + " - ", "").Replace("</td>\r\n </tr>\r\n <tr>\r\n", "");

                    //NOMBRE COMERCIAL
                    tabla[5] = tabla[5].Replace("=\"bg\" colspan=1>", "").Replace("</td>", "").Replace("</tr>", "").Replace("<tr>", "");

                    //TIPO CONTRIBUYENTE
                    tabla[3] = tabla[3].Replace("=\"bg\" colspan=3>", "").Replace("</td>\r\n </tr>\r\n <tr>\r\n", "").Replace("</td>", "").Replace("</tr>", "").Replace("<tr>", "");

                    //DIRECCION
                    tabla[15] = tabla[15].Replace("=\"bg\" colspan=3>", "").Replace("</td>\r\n </tr>\r\n<!-- SE COMENTO POR INDICACION DEL PASE PAS20134EA20000207 -->\r\n<!-- <tr> -->\r\n<!-- ", "").Replace("</td>", "").Replace("</tr>", "").Replace("<tr>", "").Replace("�", "Ñ");

                    //FECHA INSCRIPCION
                    tabla[7] = tabla[7].Replace("=\"bg\" colspan=1>", "").Replace("</td>", "").Replace("</tr>", "").Replace("<tr>", "").Remove(10);

                    //ESTADO CONTRIBUYENTE
                    tabla[10] = tabla[10].Replace("=\"bg\" colspan=1>", "").Replace("</td>", "").Replace("</tr>", "").Replace("<tr>", "");

                    //FECHA INICIO ACTIVIDAD
                    tabla[8] = tabla[8].Replace("=\"bg\" colspan=1>", "").Replace("</td>", "").Replace("</tr>", "").Replace("<tr>", "");

                    //CONDICION CONTRIBUYENTE
                    tabla[13] = tabla[13].Replace("=\"bg\" colspan=1>", "").Replace("</td>", "").Replace("</tr>", "").Replace("<tr>", "");

                    //SISTEMA DE EMISION DE COMPROBANTE
                    tabla[17] = tabla[17].Replace("=\"bg\" colspan=1>", "").Replace("</td>", "").Replace("</tr>", "").Replace("<tr>", "");

                    //ACTIVIDAD DE COMERCIO EXTERIOR
                    tabla[19] = tabla[19].Replace("=\"bg\" colspan=1>", "").Replace("</td>", "").Replace("</tr>", "").Replace("<tr>", "");

                    //SISTEMA CONTABILIDAD
                    tabla[21] = tabla[21].Replace("=\"bg\" colspan=3>", "").Replace("</td>", "").Replace("</tr>", "").Replace("<tr>", "").Replace("<!--I#P_SNADE003-1#20141109#CFS-->", "").Replace("<!--", "");

                    //-------------------------------

                    empresa = new Empresa
                    {
                        NombreComercial = tabla[5].ToString().Trim(),
                        RazonSocial = tabla[1].ToString().Trim(),
                        Direccion = tabla[15].ToString().Trim(),
                        TipoContribuyente = tabla[3].Trim(),
                        FechaInscripcion = tabla[7].ToString().Trim(),
                        FechaInicioActividad = tabla[8].ToString().Trim(),
                        EstadoContribuyente = tabla[10].ToString().Trim(),
                        CondicionContribuyente = tabla[13].ToString().Trim(),
                        SistemaEmisionComprobante = tabla[17].ToString().Trim(),
                        ActividadComercioExterior = tabla[19].ToString().Trim(),
                        SistemaContabilidad = tabla[21].ToString().Trim(),
                    };

                    return empresa;
                }
                else return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
