using Angels.Clase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Angels.Presentacion.Presentacion
{
    public partial class FPrincipal : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        string serialBeta = "1d6d7feb48603ac7dd8c090d2c54bc2e";
        string serialPremium = "96bfaf8a1e950cbed0c3f4a554cf0525";

        public FPrincipal()
        {
            InitializeComponent();
        }

        private void MEnviarCorreo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FEnvio);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }

            //Abrir Formulario dentro del MDI.
            FEnvio frm = new FEnvio();
            frm.MdiParent = this;
            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frm.Show();

        }

        private void MConsoltaRUC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form FrmEvitarMultipleForm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FConsultaRuc);

            if (FrmEvitarMultipleForm != null)
            {
                //si la instancia existe la pongo en primer plano
                FrmEvitarMultipleForm.BringToFront();
                return;
            }

            //Abrir Formulario dentro del MDI.
            FConsultaRuc frm = new FConsultaRuc();
            frm.MdiParent = this;
            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frm.Show();
        }

        private void FPrincipal_Load(object sender, EventArgs e)
        {
            string serial = ConfigurationManager.AppSettings["serial"];

            if (serial.Equals(serialBeta))
            {
                Aplicacion.Licencia = "BETA";
            }
            else if (serial.Equals(serialPremium))
            {
                Aplicacion.Licencia = "PREMIUM";
            }
            else
            {
                Aplicacion.Licencia = "SIN VERSION";
            }

            lblMVersion.Caption = Aplicacion.Licencia;
        }

        private void FPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult msj = MessageBox.Show("Desea Cerrar la Aplicación?",Aplicacion.Software,MessageBoxButtons.OKCancel,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);

            if(msj == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else
            {
                Application.ExitThread();
            }
        }

        private void MConfigurar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
            //Abrir Formulario dentro del MDI.
            FConfiguracion frm = new FConfiguracion();
            frm.ShowDialog();
        }
    }
}
