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
using Angels.Presentacion;
using System.Configuration;
using Angels.Modelo;
using System.Net.Mime;
using System.Diagnostics;

namespace Angels
{
    public partial class FEnvio : Form
    {
        public FEnvio()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += Form1_KeyDown;
        }

        Funcion fn = new Funcion();

        string serialBeta = "1d6d7feb48603ac7dd8c090d2c54bc2e";
        string serialPremium = "96bfaf8a1e950cbed0c3f4a554cf0525";

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F5)
            {
                FConfiguracion frm = new FConfiguracion();
                frm.ShowDialog();

                cliente = new SmtpClient(Sesion.smtp, Sesion.Puerto);
                Sesion.ListarConfiguracion();
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validacion()) return;

                Cursor = Cursors.WaitCursor;
                
                string correos = "";
                foreach (DataGridViewRow row in dgvCorreos.Rows)
                {
                    var correo = row.Cells["cnCorreo"].Value;

                    if (correo != null)
                    {
                        correos += correo.ToString().Trim() + ",";
                    }
                    else break;
                }

                string adjunto = "";
                foreach (DataGridViewRow rowAdjunto in dgvArchivos.Rows)
                {
                    string rutaArchivo = rowAdjunto.Cells["cnArchivo"].Value.ToString();

                    if (File.Exists(rutaArchivo))
                    {
                        adjunto += rutaArchivo + "|";
                    }
                }

                if(SendMail(correos, txtAsunto.Text, adjunto, txtCuerpo.Text))
                {
                    MessageBox.Show("Envio de Correo finalizado", Aplicacion.Software, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,Aplicacion.Software,MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            finally
            {
                Cursor = Cursors.Default;

                if(!fn.Premium())
                {
                    Process.Start(Link.Publicidad);
                }
            }
        }

      

        private bool validacion()
        {
            if(lblVersion.Text.Equals("SIN VERSION"))
            {
                MessageBox.Show("No cuentas con ninguna versión",Aplicacion.Software,MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }

            if(lblVersion.Text.Equals("BETA"))
            {
                for (int i = 2; i < dgvCorreos.Rows.Count - 1; i++)
                {
                    dgvCorreos.Rows.Remove(dgvCorreos.Rows[i]);
                }
            }

            return true;
        }

        private readonly char[] _delimitadorCc = { ',' };
        private readonly char[] _delimitadorAdjunto = { '|' };


        
        public bool SendMail(string destinatarios, string asunto, string adjuntos, string cuerpo)
        {
            try
            {
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress(Sesion.Correo, Sesion.Alias);

                

                //Configuracion 
                correo.BodyEncoding = System.Text.Encoding.UTF8;
                correo.IsBodyHtml = true;

                if(pictureBox1.Image != null)
                {
                    //Vista
                    AlternateView avHtml = AlternateView.CreateAlternateViewFromString(txtCuerpo.Text + "<br/><img src=cid:Imagen1>", null, "text/html");
                    LinkedResource lr = new LinkedResource(pictureBox1.ImageLocation, MediaTypeNames.Image.Jpeg);
                    lr.ContentId = "Imagen1";
                    avHtml.LinkedResources.Add(lr);
                    correo.AlternateViews.Add(avHtml);
                    correo.Body = lr.ContentId;
                }
                else
                {
                    correo.Body = txtCuerpo.Text;
                }
                

                

                correo.Subject = asunto;
                correo.SubjectEncoding = System.Text.Encoding.UTF8;
                
                //Destinatarios
                if (!string.IsNullOrWhiteSpace(destinatarios))
                {
                    string[] cadena = destinatarios.Split(_delimitadorCc);
                    foreach (string word in cadena)
                    {
                        if(!string.IsNullOrWhiteSpace(word))
                        {
                            correo.To.Add(word.Trim());
                        }
                    }
                }

                if (!string.IsNullOrWhiteSpace(adjuntos))
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
                cliente.Credentials = new NetworkCredential(Sesion.Correo, Sesion.Contraseña);
                cliente.EnableSsl = true;
                cliente.Send(correo);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Aplicacion.Software, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
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
            if(e.ColumnIndex == dgvArchivos.Columns["cnQuitar"].Index && e.RowIndex >= 0)
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
                lblCantidad.Text = "0";
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
                MessageBox.Show(ex.Message, Aplicacion.Software, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                Cursor = Cursors.Default;
                cantidad();
            }


        }

        private void dgvCorreos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            cantidad();
        }

        private void cantidad()
        {
            lblCantidad.Text = (dgvCorreos.Rows.Count - 1).ToString();
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            Image image = btnEnviar.Image;
            Clipboard.SetImage(image);
            txtCuerpo.Paste();
        }

        SmtpClient cliente;
        private void FEnvio_Load(object sender, EventArgs e)
        {
            cliente = new SmtpClient(Sesion.smtp, Sesion.Puerto);
            
            verVersion();
            cantidad();
        }

        private void verVersion()
        {
            string serial =  ConfigurationManager.AppSettings["serial"];

            if(serial.Equals(serialBeta))
            {
                lblVersion.Text = "BETA";
            }
            else if(serial.Equals(serialPremium))
            {
                lblVersion.Text = "PREMIUM";
            }
            else
            {
                lblVersion.Text = "SIN VERSION";
            }
        }

        private void FEnvio_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void dgvCorreos_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            cantidad();
        }

        private void btnAsignarImagen_Click(object sender, EventArgs e)
        {
            string filtro = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"; 
            var ruta = abrirDirectorio(filtro, "Seleccionar Imagem");

            if(ruta != null)
            {
                pictureBox1.ImageLocation = ruta;
            }
        }

        private string abrirDirectorio(string filtro,string titulo)
        {
            OpenFileDialog openfile1 = new OpenFileDialog();
            try
            {
                string ruta = "";
                
                openfile1.Filter = filtro;
                openfile1.Title = titulo;
                if (openfile1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (!openfile1.FileName.Equals(""))
                    {
                        ruta = openfile1.FileName;

                        return ruta;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message,Aplicacion.Software,MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return null;
            }
            finally
            {
                openfile1.Dispose();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }
    }
}
