namespace Angels.Presentacion
{
    partial class FConsultaRuc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.cnRuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnNombreComercial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnRazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnTipoContribuyente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnFechaInscripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnFechaInicioActividad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnEstadoContribuyente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnCondicionContribuyente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnSistemaEmisionComprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnActividadComercioExterior = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnSistemaContabilidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnImportar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.BackColor = System.Drawing.Color.Lime;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.Black;
            this.btnBuscar.Image = global::Angels.Properties.Resources.buscar_32;
            this.btnBuscar.Location = new System.Drawing.Point(129, 12);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(1358, 41);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar Empresa";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvDatos
            // 
            this.dgvDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDatos.BackgroundColor = System.Drawing.Color.White;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cnRuc,
            this.cnNombreComercial,
            this.cnRazonSocial,
            this.cnDireccion,
            this.cnTipoContribuyente,
            this.cnFechaInscripcion,
            this.cnFechaInicioActividad,
            this.cnEstadoContribuyente,
            this.cnCondicionContribuyente,
            this.cnSistemaEmisionComprobante,
            this.cnActividadComercioExterior,
            this.cnSistemaContabilidad});
            this.dgvDatos.Location = new System.Drawing.Point(12, 12);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.Size = new System.Drawing.Size(1475, 465);
            this.dgvDatos.TabIndex = 2;
            // 
            // cnRuc
            // 
            this.cnRuc.HeaderText = "Ruc";
            this.cnRuc.Name = "cnRuc";
            // 
            // cnNombreComercial
            // 
            this.cnNombreComercial.HeaderText = "NombreComercial";
            this.cnNombreComercial.Name = "cnNombreComercial";
            // 
            // cnRazonSocial
            // 
            this.cnRazonSocial.HeaderText = "RazonSocial";
            this.cnRazonSocial.Name = "cnRazonSocial";
            // 
            // cnDireccion
            // 
            this.cnDireccion.HeaderText = "Direccion";
            this.cnDireccion.Name = "cnDireccion";
            // 
            // cnTipoContribuyente
            // 
            this.cnTipoContribuyente.HeaderText = "TipoContribuyente";
            this.cnTipoContribuyente.Name = "cnTipoContribuyente";
            // 
            // cnFechaInscripcion
            // 
            this.cnFechaInscripcion.HeaderText = "FechaInscripcion";
            this.cnFechaInscripcion.Name = "cnFechaInscripcion";
            // 
            // cnFechaInicioActividad
            // 
            this.cnFechaInicioActividad.HeaderText = "F. InicioActividad";
            this.cnFechaInicioActividad.Name = "cnFechaInicioActividad";
            // 
            // cnEstadoContribuyente
            // 
            this.cnEstadoContribuyente.HeaderText = "Est. Contribuyente";
            this.cnEstadoContribuyente.Name = "cnEstadoContribuyente";
            // 
            // cnCondicionContribuyente
            // 
            this.cnCondicionContribuyente.HeaderText = "Cond. Contribuyente";
            this.cnCondicionContribuyente.Name = "cnCondicionContribuyente";
            // 
            // cnSistemaEmisionComprobante
            // 
            this.cnSistemaEmisionComprobante.HeaderText = "SistemaEmision";
            this.cnSistemaEmisionComprobante.Name = "cnSistemaEmisionComprobante";
            // 
            // cnActividadComercioExterior
            // 
            this.cnActividadComercioExterior.HeaderText = "ComercioExterior";
            this.cnActividadComercioExterior.Name = "cnActividadComercioExterior";
            // 
            // cnSistemaContabilidad
            // 
            this.cnSistemaContabilidad.HeaderText = "SistemaContabilidad";
            this.cnSistemaContabilidad.Name = "cnSistemaContabilidad";
            // 
            // btnImportar
            // 
            this.btnImportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImportar.BackColor = System.Drawing.Color.White;
            this.btnImportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportar.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportar.ForeColor = System.Drawing.Color.Black;
            this.btnImportar.Image = global::Angels.Properties.Resources.excel;
            this.btnImportar.Location = new System.Drawing.Point(11, 12);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(112, 42);
            this.btnImportar.TabIndex = 13;
            this.btnImportar.Text = "Importar";
            this.btnImportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImportar.UseVisualStyleBackColor = false;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnImportar);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Location = new System.Drawing.Point(0, 513);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1502, 66);
            this.panel1.TabIndex = 15;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(13, 483);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1474, 23);
            this.progressBar1.TabIndex = 16;
            // 
            // FConsultaRuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1502, 578);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvDatos);
            this.Name = "FConsultaRuc";
            this.Text = "Consulta Ruc";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnRuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnNombreComercial;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnRazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnTipoContribuyente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnFechaInscripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnFechaInicioActividad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnEstadoContribuyente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCondicionContribuyente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnSistemaEmisionComprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnActividadComercioExterior;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnSistemaContabilidad;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}