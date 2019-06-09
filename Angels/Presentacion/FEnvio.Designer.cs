namespace Angels
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvCorreos = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAdjuntar = new System.Windows.Forms.Button();
            this.dgvArchivos = new System.Windows.Forms.DataGridView();
            this.cnArchivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnQuitar = new System.Windows.Forms.DataGridViewImageColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCuerpo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAsunto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblEnviado = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblNoEnviado = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnImportar = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.cnCorreo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnEnviado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCorreos)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArchivos)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCorreos
            // 
            this.dgvCorreos.BackgroundColor = System.Drawing.Color.White;
            this.dgvCorreos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCorreos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cnCorreo,
            this.cnEnviado});
            this.dgvCorreos.Location = new System.Drawing.Point(498, 47);
            this.dgvCorreos.Name = "dgvCorreos";
            this.dgvCorreos.Size = new System.Drawing.Size(295, 334);
            this.dgvCorreos.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAdjuntar);
            this.groupBox1.Controls.Add(this.dgvArchivos);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCuerpo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtAsunto);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(479, 340);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de Envio de Correo:";
            // 
            // btnAdjuntar
            // 
            this.btnAdjuntar.Location = new System.Drawing.Point(61, 312);
            this.btnAdjuntar.Name = "btnAdjuntar";
            this.btnAdjuntar.Size = new System.Drawing.Size(61, 23);
            this.btnAdjuntar.TabIndex = 5;
            this.btnAdjuntar.Text = "...";
            this.btnAdjuntar.UseVisualStyleBackColor = true;
            this.btnAdjuntar.Click += new System.EventHandler(this.btnAdjuntar_Click);
            // 
            // dgvArchivos
            // 
            this.dgvArchivos.AllowUserToAddRows = false;
            this.dgvArchivos.AllowUserToDeleteRows = false;
            this.dgvArchivos.BackgroundColor = System.Drawing.Color.White;
            this.dgvArchivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArchivos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cnArchivo,
            this.cnQuitar});
            this.dgvArchivos.Location = new System.Drawing.Point(61, 235);
            this.dgvArchivos.Name = "dgvArchivos";
            this.dgvArchivos.Size = new System.Drawing.Size(409, 75);
            this.dgvArchivos.TabIndex = 4;
            this.dgvArchivos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArchivos_CellClick);
            // 
            // cnArchivo
            // 
            this.cnArchivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cnArchivo.HeaderText = "Archivos";
            this.cnArchivo.Name = "cnArchivo";
            this.cnArchivo.Width = 300;
            // 
            // cnQuitar
            // 
            this.cnQuitar.HeaderText = "Quitar";
            this.cnQuitar.Image = global::Angels.Properties.Resources.remove;
            this.cnQuitar.Name = "cnQuitar";
            this.cnQuitar.Width = 65;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Adjunto:";
            // 
            // txtCuerpo
            // 
            this.txtCuerpo.Location = new System.Drawing.Point(61, 64);
            this.txtCuerpo.Multiline = true;
            this.txtCuerpo.Name = "txtCuerpo";
            this.txtCuerpo.Size = new System.Drawing.Size(409, 156);
            this.txtCuerpo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cuerpo:";
            // 
            // txtAsunto
            // 
            this.txtAsunto.Location = new System.Drawing.Point(61, 31);
            this.txtAsunto.Name = "txtAsunto";
            this.txtAsunto.Size = new System.Drawing.Size(409, 20);
            this.txtAsunto.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Asunto:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 13);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(479, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Total:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(40, 20);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(35, 13);
            this.lblTotal.TabIndex = 7;
            this.lblTotal.Text = "0000";
            // 
            // lblEnviado
            // 
            this.lblEnviado.AutoSize = true;
            this.lblEnviado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnviado.ForeColor = System.Drawing.Color.Green;
            this.lblEnviado.Location = new System.Drawing.Point(130, 20);
            this.lblEnviado.Name = "lblEnviado";
            this.lblEnviado.Size = new System.Drawing.Size(35, 13);
            this.lblEnviado.TabIndex = 9;
            this.lblEnviado.Text = "0000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(83, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Enviado:";
            // 
            // lblNoEnviado
            // 
            this.lblNoEnviado.AutoSize = true;
            this.lblNoEnviado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoEnviado.ForeColor = System.Drawing.Color.Red;
            this.lblNoEnviado.Location = new System.Drawing.Point(244, 20);
            this.lblNoEnviado.Name = "lblNoEnviado";
            this.lblNoEnviado.Size = new System.Drawing.Size(35, 13);
            this.lblNoEnviado.TabIndex = 11;
            this.lblNoEnviado.Text = "0000";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(177, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "No Enviado:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTotal);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblNoEnviado);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.lblEnviado);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(199, 387);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(293, 48);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Información:";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Quitar";
            this.dataGridViewImageColumn1.Image = global::Angels.Properties.Resources.remove;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 65;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLimpiar.Image = global::Angels.Properties.Resources.clean;
            this.btnLimpiar.Location = new System.Drawing.Point(498, 3);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(112, 42);
            this.btnLimpiar.TabIndex = 14;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnImportar.Image = global::Angels.Properties.Resources.excel;
            this.btnImportar.Location = new System.Drawing.Point(616, 3);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(177, 42);
            this.btnImportar.TabIndex = 12;
            this.btnImportar.Text = "Importar";
            this.btnImportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Image = global::Angels.Properties.Resources.email;
            this.btnEnviar.Location = new System.Drawing.Point(498, 382);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(295, 52);
            this.btnEnviar.TabIndex = 2;
            this.btnEnviar.Text = "Enviar Correos";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEnviar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // cnCorreo
            // 
            this.cnCorreo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cnCorreo.HeaderText = "Correos";
            this.cnCorreo.Name = "cnCorreo";
            this.cnCorreo.Width = 180;
            // 
            // cnEnviado
            // 
            this.cnEnviado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cnEnviado.HeaderText = "Enviado";
            this.cnEnviado.Name = "cnEnviado";
            this.cnEnviado.Width = 50;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(798, 438);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvCorreos);
            this.Name = "Form1";
            this.Text = "Envio";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCorreos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArchivos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCorreos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCuerpo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAsunto;
        private System.Windows.Forms.DataGridView dgvArchivos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAdjuntar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblEnviado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblNoEnviado;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnArchivo;
        private System.Windows.Forms.DataGridViewImageColumn cnQuitar;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCorreo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cnEnviado;
    }
}

