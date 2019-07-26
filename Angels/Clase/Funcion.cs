using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Angels.Clase
{
    public class Funcion
    {
        /// Encripta una cadena
        public string Encriptar(string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        public string DesEncriptar(string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }


        public bool Premium()
        {
            return Aplicacion.Licencia.Equals("PREMIUM");
        }

        public void GridFromExcel(DataGridView tabla, ProgressBar progress)
        {
            int filasTotales = tabla.Rows.Count;

            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Application.Workbooks.Add(true);
            int ColumnIndex = 0;
            foreach (DataGridViewColumn col in tabla.Columns)
            {
                ColumnIndex++;
                excel.Cells[1, ColumnIndex] = col.Name;
            }
            int rowIndex = 0;
            foreach (DataGridViewRow row in tabla.Rows)
            {
                rowIndex++;
                ColumnIndex = 0;
                foreach (DataGridViewColumn col in tabla.Columns)
                {
                    ColumnIndex++;
                    excel.Cells[rowIndex + 1, ColumnIndex].Value = row.Cells[col.Name].Value.ToString();
                }

                progress.Value = (rowIndex * 100) / filasTotales;
            }
            excel.Visible = true;
            Worksheet worksheet = (Worksheet)excel.ActiveSheet;
            worksheet.Activate();
            MessageBox.Show("Exportación Exitosa", Aplicacion.Software, MessageBoxButtons.OK, MessageBoxIcon.Information);
            progress.Value = 0;

        }
        public void ActualizarSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }

        
        public void ImportExcelFromGrid(DataGridView gridView, string file)
        {
            try
            {
                gridView.Rows.Clear();
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                Workbook wb = excel.Workbooks.Open(file);
                Worksheet excelSheet = wb.ActiveSheet;

                for (int i = 2; i < excelSheet.Rows.Count; i++)
                {
                    //Read the first cell 
                    var correo = excelSheet.Cells[i, 1].Value;

                    if (correo == null) return;

                    gridView.Rows.Add(correo.ToString());
                }
                wb.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Aplicacion.Software, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public string FileOpen(string filter, string title)
        {
            string ruta = "";
            OpenFileDialog openfile1 = new OpenFileDialog();
            openfile1.Filter = filter;
            openfile1.Title = title;
            if (openfile1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return openfile1.FileName;
            }
            else return "";
        }

    }
}
