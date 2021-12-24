
namespace InterfazEscritorio
{
    partial class FrmCertificacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCertificacion));
            this.dgvCertificaciones = new System.Windows.Forms.DataGridView();
            this.cod_certificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cod_entrenador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gimnasio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.natacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maraton = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ciclismo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCrear = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCodEntrenador = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CBMaraton = new System.Windows.Forms.CheckBox();
            this.CBCiclismo = new System.Windows.Forms.CheckBox();
            this.CBNatacion = new System.Windows.Forms.CheckBox();
            this.CBGimnasio = new System.Windows.Forms.CheckBox();
            this.txtCodCertif = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCod = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCertificaciones)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCertificaciones
            // 
            this.dgvCertificaciones.AllowUserToAddRows = false;
            this.dgvCertificaciones.AllowUserToDeleteRows = false;
            this.dgvCertificaciones.AllowUserToResizeColumns = false;
            this.dgvCertificaciones.AllowUserToResizeRows = false;
            this.dgvCertificaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCertificaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cod_certificacion,
            this.cod_entrenador,
            this.gimnasio,
            this.natacion,
            this.maraton,
            this.ciclismo});
            this.dgvCertificaciones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCertificaciones.Location = new System.Drawing.Point(-3, 239);
            this.dgvCertificaciones.Name = "dgvCertificaciones";
            this.dgvCertificaciones.RowHeadersWidth = 51;
            this.dgvCertificaciones.RowTemplate.Height = 29;
            this.dgvCertificaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCertificaciones.Size = new System.Drawing.Size(945, 226);
            this.dgvCertificaciones.TabIndex = 38;
            this.dgvCertificaciones.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCertificaciones_CellDoubleClick);
            // 
            // cod_certificacion
            // 
            this.cod_certificacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cod_certificacion.DataPropertyName = "COD_CERTIFICACION";
            this.cod_certificacion.HeaderText = "Cod";
            this.cod_certificacion.MinimumWidth = 6;
            this.cod_certificacion.Name = "cod_certificacion";
            this.cod_certificacion.Width = 65;
            // 
            // cod_entrenador
            // 
            this.cod_entrenador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cod_entrenador.DataPropertyName = "COD_ENTRENADOR";
            this.cod_entrenador.HeaderText = "Cod Entrenador";
            this.cod_entrenador.MinimumWidth = 6;
            this.cod_entrenador.Name = "cod_entrenador";
            // 
            // gimnasio
            // 
            this.gimnasio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gimnasio.DataPropertyName = "GIMNASIO_ESPECIFICACION";
            this.gimnasio.HeaderText = "Gimnasio";
            this.gimnasio.MinimumWidth = 6;
            this.gimnasio.Name = "gimnasio";
            // 
            // natacion
            // 
            this.natacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.natacion.DataPropertyName = "NATACION_ESPECIFICACION";
            this.natacion.HeaderText = "Natación";
            this.natacion.MinimumWidth = 6;
            this.natacion.Name = "natacion";
            // 
            // maraton
            // 
            this.maraton.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.maraton.DataPropertyName = "MARATON_ESPECIFICACION";
            this.maraton.HeaderText = "Maratón";
            this.maraton.MinimumWidth = 6;
            this.maraton.Name = "maraton";
            // 
            // ciclismo
            // 
            this.ciclismo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ciclismo.DataPropertyName = "CICLISMO_ESPECIFICACION";
            this.ciclismo.HeaderText = "Ciclismo";
            this.ciclismo.MinimumWidth = 6;
            this.ciclismo.Name = "ciclismo";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.PowderBlue;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(420, 471);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(130, 69);
            this.btnGuardar.TabIndex = 37;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.PowderBlue;
            this.btnEliminar.Image = global::InterfazEscritorio.Properties.Resources.outline_clear_black_24dp;
            this.btnEliminar.Location = new System.Drawing.Point(568, 471);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(130, 69);
            this.btnEliminar.TabIndex = 36;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCrear
            // 
            this.btnCrear.BackColor = System.Drawing.Color.PowderBlue;
            this.btnCrear.Image = global::InterfazEscritorio.Properties.Resources.outline_create_black_24dp;
            this.btnCrear.Location = new System.Drawing.Point(259, 471);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(130, 69);
            this.btnCrear.TabIndex = 35;
            this.btnCrear.Text = "Crear";
            this.btnCrear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCrear.UseVisualStyleBackColor = false;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtCod);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(945, 233);
            this.panel1.TabIndex = 34;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateBlue;
            this.panel2.Controls.Add(this.linkLabel1);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtCodEntrenador);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.CBMaraton);
            this.panel2.Controls.Add(this.CBCiclismo);
            this.panel2.Controls.Add(this.CBNatacion);
            this.panel2.Controls.Add(this.CBGimnasio);
            this.panel2.Controls.Add(this.txtCodCertif);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(945, 233);
            this.panel2.TabIndex = 25;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(25, 126);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(140, 23);
            this.linkLabel1.TabIndex = 18;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "COD Entrenador:";
            this.linkLabel1.Click += new System.EventHandler(this.linkLabel1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(17, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 23);
            this.label7.TabIndex = 17;
            this.label7.Text = "COD Certificación:";
            // 
            // txtCodEntrenador
            // 
            this.txtCodEntrenador.Location = new System.Drawing.Point(172, 125);
            this.txtCodEntrenador.Name = "txtCodEntrenador";
            this.txtCodEntrenador.Size = new System.Drawing.Size(125, 27);
            this.txtCodEntrenador.TabIndex = 16;
            this.txtCodEntrenador.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Square721 BT", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(364, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(217, 21);
            this.label4.TabIndex = 13;
            this.label4.Text = "Tipos de Certificaciones:";
            // 
            // CBMaraton
            // 
            this.CBMaraton.AutoSize = true;
            this.CBMaraton.Location = new System.Drawing.Point(617, 141);
            this.CBMaraton.Name = "CBMaraton";
            this.CBMaraton.Size = new System.Drawing.Size(87, 24);
            this.CBMaraton.TabIndex = 7;
            this.CBMaraton.Text = "Maratón";
            this.CBMaraton.UseVisualStyleBackColor = true;
            // 
            // CBCiclismo
            // 
            this.CBCiclismo.AutoSize = true;
            this.CBCiclismo.Location = new System.Drawing.Point(617, 184);
            this.CBCiclismo.Name = "CBCiclismo";
            this.CBCiclismo.Size = new System.Drawing.Size(87, 24);
            this.CBCiclismo.TabIndex = 4;
            this.CBCiclismo.Text = "Ciclismo";
            this.CBCiclismo.UseVisualStyleBackColor = true;
            // 
            // CBNatacion
            // 
            this.CBNatacion.AutoSize = true;
            this.CBNatacion.Location = new System.Drawing.Point(617, 97);
            this.CBNatacion.Name = "CBNatacion";
            this.CBNatacion.Size = new System.Drawing.Size(91, 24);
            this.CBNatacion.TabIndex = 3;
            this.CBNatacion.Text = "Natación";
            this.CBNatacion.UseVisualStyleBackColor = true;
            // 
            // CBGimnasio
            // 
            this.CBGimnasio.AutoSize = true;
            this.CBGimnasio.Location = new System.Drawing.Point(617, 51);
            this.CBGimnasio.Name = "CBGimnasio";
            this.CBGimnasio.Size = new System.Drawing.Size(93, 24);
            this.CBGimnasio.TabIndex = 2;
            this.CBGimnasio.Text = "Gimnasio";
            this.CBGimnasio.UseVisualStyleBackColor = true;
            // 
            // txtCodCertif
            // 
            this.txtCodCertif.Enabled = false;
            this.txtCodCertif.Location = new System.Drawing.Point(172, 45);
            this.txtCodCertif.Name = "txtCodCertif";
            this.txtCodCertif.Size = new System.Drawing.Size(125, 27);
            this.txtCodCertif.TabIndex = 1;
            this.txtCodCertif.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(318, 97);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(101, 24);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "COD:";
            // 
            // txtCod
            // 
            this.txtCod.Enabled = false;
            this.txtCod.Location = new System.Drawing.Point(68, 23);
            this.txtCod.Name = "txtCod";
            this.txtCod.Size = new System.Drawing.Size(125, 27);
            this.txtCod.TabIndex = 1;
            this.txtCod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FrmCertificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 552);
            this.Controls.Add(this.dgvCertificaciones);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmCertificacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Certificaciones";
            this.Load += new System.EventHandler(this.FrmCertificacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCertificaciones)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCertificaciones;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCodEntrenador;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox CBMaraton;
        private System.Windows.Forms.CheckBox CBCiclismo;
        private System.Windows.Forms.CheckBox CBNatacion;
        private System.Windows.Forms.CheckBox CBGimnasio;
        private System.Windows.Forms.TextBox txtCodCertif;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCod;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_certificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_entrenador;
        private System.Windows.Forms.DataGridViewTextBoxColumn gimnasio;
        private System.Windows.Forms.DataGridViewTextBoxColumn natacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn maraton;
        private System.Windows.Forms.DataGridViewTextBoxColumn ciclismo;
    }
}