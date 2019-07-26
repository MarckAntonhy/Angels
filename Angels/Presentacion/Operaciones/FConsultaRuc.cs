using Angels.Clase;
using Angels.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Angels.Presentacion
{
    public partial class FConsultaRuc : Form
    {
        public FConsultaRuc()
        {
            InitializeComponent();
        }

        DBEmpresa dBEmpresa = new DBEmpresa();
        Funcion fn = new Funcion();
        EmpresaBeta myInfo;

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                if (myInfo == null)
                {
                    myInfo = new EmpresaBeta();
                }

                CookieContainer cookie = new CookieContainer();
                bool premium = Aplicacion.Licencia.Equals("PREMIUM");

                int cantidad = 0;
                int Total = dgvDatos.RowCount;

                foreach (DataGridViewRow row in dgvDatos.Rows)
                {
                    cantidad++;

                    if (row.Cells["cnRuc"].Value != null)
                    {
                        string ruc = row.Cells["cnRuc"].Value.ToString();

                        string codigoCatcher = myInfo.UseTesseract();

                        Empresa empresa = myInfo.GetInfo(ruc, codigoCatcher);

                        if (empresa != null)
                        {
                            row.Cells["cnActividadComercioExterior"].Value = empresa.ActividadComercioExterior;
                            row.Cells["cnCondicionContribuyente"].Value = empresa.CondicionContribuyente;
                            row.Cells["cnDireccion"].Value = empresa.Direccion;
                            row.Cells["cnEstadoContribuyente"].Value = empresa.EstadoContribuyente;
                            row.Cells["cnFechaInicioActividad"].Value = empresa.FechaInicioActividad;
                            row.Cells["cnFechaInscripcion"].Value = empresa.FechaInscripcion;
                            row.Cells["cnNombreComercial"].Value = empresa.NombreComercial;
                            row.Cells["cnRazonSocial"].Value = empresa.RazonSocial;
                            row.Cells["cnSistemaContabilidad"].Value = empresa.SistemaContabilidad;
                            row.Cells["cnSistemaEmisionComprobante"].Value = empresa.SistemaEmisionComprobante;
                            row.Cells["cnTipoContribuyente"].Value = empresa.TipoContribuyente;
                        }
                    }

                    progressBar1.Value = cantidad * 100 / Total;

                    if (!premium && cantidad.Equals(5))
                    {
                        break;
                    }
                }


                if(!premium)
                {
                    MessageBox.Show("La Version Beta, solo permite 5 Ruc(s) por busqueda",Aplicacion.Software,MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
                progressBar1.Value = 0;

                if(!fn.Premium())
                {
                    Process.Start(Link.Publicidad);
                }
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            try
            {
                string path = fn.FileOpen("Excel Files | *.xlsx", "Seleccione el archivo de Excel");

                if (string.IsNullOrEmpty(path)) return;

                Cursor = Cursors.WaitCursor;

                fn.ImportExcelFromGrid(dgvDatos, path);
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            fn.GridFromExcel(dgvDatos, progressBar1);
            progressBar1.Value = 0;
        }
    }
}
