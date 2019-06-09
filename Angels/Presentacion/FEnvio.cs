using Angels.Clase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace Angels
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                int total = dgvCorreos.Rows.Count - 1;
                int indice = 0;
                foreach (DataGridViewRow row in dgvCorreos.Rows)
                {
                    indice++;
                    string correo = (row.Cells["cnCorreo"].Value == null) ? "" : row.Cells["cnCorreo"].Value.ToString();

                    if (string.IsNullOrEmpty(correo)) break;

                    string adjunto = "";

                    foreach (DataGridViewRow rowAdjunto in dgvArchivos.Rows)
                    {
                        string rutaArchivo = rowAdjunto.Cells["cnArchivo"].Value.ToString();

                        if (File.Exists(rutaArchivo))
                        {
                            adjunto += rutaArchivo + "|";
                        }
                    }

                    int estadoEnvio = SendMail("MARCO", correo, "", txtAsunto.Text, adjunto, txtCuerpo.Text);
                    if (estadoEnvio.Equals(0))
                    {
                        row.Cells["cnEnviado"].Value = true;
                    }
                    else if(estadoEnvio.Equals(2))
                    {
                        return;
                    }

                    progressBar1.Value = indice * 100 / total;
                }

                MessageBox.Show("Envio de Correo finalizado",Aplicacion.Software,MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,Aplicacion.Software,MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            }
            finally
            {
                Cursor = Cursors.Default;
                progressBar1.Value = 0;
            }
        }

        private readonly char[] _delimitadorCc = { ',' };
        private readonly char[] _delimitadorAdjunto = { '|' };
        SmtpClient cliente = new SmtpClient("smtp.gmail.com", 587);
        MailMessage correo = new MailMessage();

        public int SendMail(string nombre, string destinatarios, string cc, string asunto, string adjuntos, string cuerpo)
        {
            try
            {
                correo.From = new MailAddress("marco98.vega@gmail.com", nombre);
                correo.Body = cuerpo;
                correo.Subject = asunto;
                if (destinatarios == "") { }
                else
                {
                    string[] cadena = destinatarios.Split(_delimitadorCc);
                    foreach (string word in cadena) correo.To.Add(word.Trim());
                }
                if (cc == "") { }
                else
                {
                    string[] cadena1 = cc.Split(_delimitadorCc);
                    foreach (string word in cadena1) correo.CC.Add(word.Trim());
                }
                if (adjuntos == "") { }
                else
                {
                    string[] cadena2 = adjuntos.Split(_delimitadorAdjunto);
                    foreach (string word in cadena2)
                    {
                        if(!string.IsNullOrEmpty(word))
                        {
                            correo.Attachments.Add(new Attachment(word));
                        }
                    }
                }
                cliente.Credentials = new NetworkCredential("marco98.vega@gmail.com", "g19.vega10jh.86.y");
                cliente.EnableSsl = true;
                cliente.Send(correo);
                return 0;
            }
            catch (Exception ex)
            {
                DialogResult msj = MessageBox.Show(ex.Message + " - Desea Continuar con el envio?", Aplicacion.Software, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (msj == DialogResult.OK) return 1; else return 2;
            }

        }

        private void btnAdjuntar_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Seleccionar Archivo";
            open.Multiselect = true;
            if(open.ShowDialog() == DialogResult.OK)
            {
                var archivos = open.FileNames;

                foreach (var item in archivos)
                {
                    dgvArchivos.Rows.Add(item);
                }
            }

            open.Dispose();
        }

        private void dgvArchivos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == dgvArchivos.Columns["cnQuitar"].Index && e.RowIndex > 0)
            {
                DialogResult msj = MessageBox.Show("Desea Quitar El Archivo Adjunto Selecionado",Aplicacion.Software,MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if(msj == DialogResult.OK)
                {
                    dgvArchivos.Rows.Remove(dgvArchivos.CurrentRow);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            DialogResult msj = MessageBox.Show("Desea Limpiar la lista de correos?",Aplicacion.Software,MessageBoxButtons.OKCancel,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
            if(msj == DialogResult.OK)
            {
                dgvCorreos.Rows.Clear();
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            try
            {
                string ruta = "";
                OpenFileDialog openfile1 = new OpenFileDialog();
                openfile1.Filter = "Excel Files |*.xlsx";
                openfile1.Title = "Seleccione el archivo de Excel";
                if (openfile1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (!openfile1.FileName.Equals(""))
                    {
                        Cursor = Cursors.WaitCursor;

                        dgvCorreos.Rows.Clear();
                        ruta = openfile1.FileName;
                        Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                        Workbook wb = excel.Workbooks.Open(ruta);
                        Worksheet excelSheet = wb.ActiveSheet;

                        for (int i = 2; i < excelSheet.Rows.Count; i++)
                        {
                            //Read the first cell 
                            var correo = excelSheet.Cells[i, 1].Value;

                            if (correo == null) return;

                            dgvCorreos.Rows.Add(correo.ToString(), false);
                        }
                        wb.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,Aplicacion.Software,MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            
        }
    }
}
