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

namespace Angels.Presentacion
{
    public partial class FLicencia : Form
    {
        Funcion fn = new Funcion();
        public FLicencia()
        {
            InitializeComponent();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            fn.ActualizarSettings("serial",txtSerial.Text);

            MessageBox.Show("Licencia Actualizada",Aplicacion.Software,MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Close();
        }

        private void FLicencia_Load(object sender, EventArgs e)
        {
            
        }
    }
}
