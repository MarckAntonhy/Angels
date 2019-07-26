using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Angels.Clase;
using Angels.Modelo;

namespace Angels.Presentacion
{
    public partial class FConfiguracion : Form
    {
        Funcion fn = new Funcion();
        public FConfiguracion()
        {
            InitializeComponent();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if(!txtContraseña.Text.Equals(txtConfirmar.Text))
            {
                MessageBox.Show("Las Contraseñas no coinciden",Aplicacion.Software,MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtContraseña.Focus();
                return;
            }

            if (!txtSContraseña.Text.Equals(txtSConfirmar.Text))
            {
                MessageBox.Show("Las Contraseñas del sistema no coinciden", Aplicacion.Software, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSContraseña.Focus();
                return;
            }


            fn.ActualizarSettings("alias", txtAlias.Text);
            fn.ActualizarSettings("correo", txtCorreo.Text);
            fn.ActualizarSettings("correo",txtCorreo.Text);
            fn.ActualizarSettings("contraseña", txtConfirmar.Text);
            fn.ActualizarSettings("contraseña", txtContraseña.Text);
            fn.ActualizarSettings("puerto", txtPuerto.Text);
            fn.ActualizarSettings("smtp", txtSmtp.Text);
            fn.ActualizarSettings("susuario", txtSUsuario.Text);
            fn.ActualizarSettings("scontraseña", txtSContraseña.Text);

            Sesion.ListarConfiguracion();

            MessageBox.Show("Datos Actualizados",Aplicacion.Software,MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Close();
        }

        private void FConfiguracion_Load(object sender, EventArgs e)
        {
            txtAlias.Text = ConfigurationManager.AppSettings["alias"];
            txtCorreo.Text = ConfigurationManager.AppSettings["correo"];
            txtConfirmar.Text = ConfigurationManager.AppSettings["contraseña"];
            txtContraseña.Text = ConfigurationManager.AppSettings["contraseña"];
            txtPuerto.Text = ConfigurationManager.AppSettings["puerto"];
            txtSmtp.Text = ConfigurationManager.AppSettings["smtp"];
            txtSUsuario.Text = ConfigurationManager.AppSettings["SUSUARIO"];
            txtSContraseña.Text = ConfigurationManager.AppSettings["scontraseña"];
            txtSConfirmar.Text = ConfigurationManager.AppSettings["scontraseña"];
        }

       
    }
}
