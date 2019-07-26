using Angels.Clase;
using Angels.Modelo;
using Angels.Presentacion.Presentacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Angels.Presentacion
{
    public partial class FLogin : Form
    {
        public FLogin()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += FLogin_KeyDown;
        }

        private void FLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F5)
            {
                FLicencia frm = new FLicencia();
                frm.ShowDialog();
            }
        }

        string usuario, contraseña;

        private void pbxFacebook_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/SoftwareAngelsx");
        }

        private void pbxYoutube_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/channel/UC21OAyBS8vDOcOH-QElpeMQ");
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if(txtUsuario.Text.ToUpper().Equals(usuario.ToUpper()) && txtContraseña.Text.ToUpper().Equals(contraseña.ToUpper()))
            {
                Sesion.ListarConfiguracion();

                FPrincipal frm = new FPrincipal();
                frm.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Credenciales Incorrectas",Aplicacion.Software,MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

       

        private void pbxVista_Click(object sender, EventArgs e)
        {
            if(txtContraseña.PasswordChar.Equals('•'))
            {
                txtContraseña.PasswordChar = txtUsuario.PasswordChar;
            }
            else
            {
                txtContraseña.PasswordChar = '•';
            }
        }

        private void txtContraseña_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnIngresar_Click(sender,e);
            }
        }

        private void FLogin_Load(object sender, EventArgs e)
        {
            usuario = ConfigurationManager.AppSettings["susuario"];
            contraseña = ConfigurationManager.AppSettings["scontraseña"];
        }
    }
}
