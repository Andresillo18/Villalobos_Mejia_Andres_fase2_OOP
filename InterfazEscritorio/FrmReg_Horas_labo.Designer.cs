
namespace InterfazEscritorio
{
    partial class FrmReg_Horas_labo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReg_Horas_labo));
            this.dgvRegHoraLabo = new System.Windows.Forms.DataGridView();
            this.cod_registro_horalabo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cod_entrenador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dia_registro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hora_inicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hora_final = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCrear = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.DTHoraFin = new System.Windows.Forms.DateTimePicker();
            this.DTHoraInicio = new System.Windows.Forms.DateTimePicker();
            this.DTDiaRegis = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCodEntrenador = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodReg_Horas = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCod = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegHoraLabo)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRegHoraLabo
            // 
            this.dgvRegHoraLabo.AllowUserToAddRows = false;
            this.dgvRegHoraLabo.AllowUserToDeleteRows = false;
            this.dgvRegHoraLabo.AllowUserToResizeColumns = false;
            this.dgvRegHoraLabo.AllowUserToResizeRows = false;
            this.dgvRegHoraLabo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegHoraLabo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cod_registro_horalabo,
            this.cod_entrenador,
            this.dia_registro,
            this.hora_inicio,
            this.hora_final});
            this.dgvRegHoraLabo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvRegHoraLabo.Location = new System.Drawing.Point(0, 239);
            this.dgvRegHoraLabo.Name = "dgvRegHoraLabo";
            this.dgvRegHoraLabo.RowHeadersWidth = 51;
            this.dgvRegHoraLabo.RowTemplate.Height = 29;
            this.dgvRegHoraLabo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRegHoraLabo.Size = new System.Drawing.Size(945, 254);
            this.dgvRegHoraLabo.TabIndex = 48;
            this.dgvRegHoraLabo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegHoraLabo_CellDoubleClick);
            // 
            // cod_registro_horalabo
            // 
            this.cod_registro_horalabo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cod_registro_horalabo.DataPropertyName = "COD_REGISTRO_HORALABO";
            this.cod_registro_horalabo.HeaderText = "Cod";
            this.cod_registro_horalabo.MinimumWidth = 6;
            this.cod_registro_horalabo.Name = "cod_registro_horalabo";
            this.cod_registro_horalabo.Width = 65;
            // 
            // cod_entrenador
            // 
            this.cod_entrenador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cod_entrenador.DataPropertyName = "COD_ENTRENADOR";
            this.cod_entrenador.HeaderText = "Cod Entrenador";
            this.cod_entrenador.MinimumWidth = 6;
            this.cod_entrenador.Name = "cod_entrenador";
            // 
            // dia_registro
            // 
            this.dia_registro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dia_registro.DataPropertyName = "DIA_REGISTRO_HORALABO";
            this.dia_registro.HeaderText = "Día registrado";
            this.dia_registro.MinimumWidth = 6;
            this.dia_registro.Name = "dia_registro";
            // 
            // hora_inicio
            // 
            this.hora_inicio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.hora_inicio.DataPropertyName = "HORA_INICIO_REGISTRO_HORALABO";
            this.hora_inicio.HeaderText = "Hora de Inicio";
            this.hora_inicio.MinimumWidth = 6;
            this.hora_inicio.Name = "hora_inicio";
            // 
            // hora_final
            // 
            this.hora_final.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.hora_final.DataPropertyName = "HORA_FINAL_REGISTRO_HORALABO";
            this.hora_final.HeaderText = "Hora Final";
            this.hora_final.MinimumWidth = 6;
            this.hora_final.Name = "hora_final";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.PowderBlue;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(421, 508);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(130, 69);
            this.btnGuardar.TabIndex = 47;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.PowderBlue;
            this.btnEliminar.Image = global::InterfazEscritorio.Properties.Resources.outline_clear_black_24dp;
            this.btnEliminar.Location = new System.Drawing.Point(569, 508);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(130, 69);
            this.btnEliminar.TabIndex = 46;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCrear
            // 
            this.btnCrear.BackColor = System.Drawing.Color.PowderBlue;
            this.btnCrear.Image = global::InterfazEscritorio.Properties.Resources.outline_create_black_24dp;
            this.btnCrear.Location = new System.Drawing.Point(260, 508);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(130, 69);
            this.btnCrear.TabIndex = 45;
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
            this.panel1.TabIndex = 44;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.DTHoraFin);
            this.panel2.Controls.Add(this.DTHoraInicio);
            this.panel2.Controls.Add(this.DTDiaRegis);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.linkLabel1);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtCodEntrenador);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtCodReg_Horas);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(945, 233);
            this.panel2.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Square721 BT", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(382, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 21);
            this.label5.TabIndex = 24;
            this.label5.Text = "Hora de Fin:";
            // 
            // DTHoraFin
            // 
            this.DTHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DTHoraFin.Location = new System.Drawing.Point(544, 157);
            this.DTHoraFin.Name = "DTHoraFin";
            this.DTHoraFin.ShowUpDown = true;
            this.DTHoraFin.Size = new System.Drawing.Size(155, 27);
            this.DTHoraFin.TabIndex = 23;
            // 
            // DTHoraInicio
            // 
            this.DTHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DTHoraInicio.Location = new System.Drawing.Point(544, 100);
            this.DTHoraInicio.Name = "DTHoraInicio";
            this.DTHoraInicio.ShowUpDown = true;
            this.DTHoraInicio.Size = new System.Drawing.Size(155, 27);
            this.DTHoraInicio.TabIndex = 21;
            // 
            // DTDiaRegis
            // 
            this.DTDiaRegis.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTDiaRegis.Location = new System.Drawing.Point(544, 45);
            this.DTDiaRegis.Name = "DTDiaRegis";
            this.DTDiaRegis.Size = new System.Drawing.Size(155, 27);
            this.DTDiaRegis.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Square721 BT", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(382, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 21);
            this.label2.TabIndex = 19;
            this.label2.Text = "Hora de Inicio:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(26, 159);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(140, 23);
            this.linkLabel1.TabIndex = 18;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "COD Entrenador:";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(35, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 23);
            this.label7.TabIndex = 17;
            this.label7.Text = "COD Registro:";
            // 
            // txtCodEntrenador
            // 
            this.txtCodEntrenador.Location = new System.Drawing.Point(172, 159);
            this.txtCodEntrenador.Name = "txtCodEntrenador";
            this.txtCodEntrenador.Size = new System.Drawing.Size(125, 27);
            this.txtCodEntrenador.TabIndex = 16;
            this.txtCodEntrenador.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Square721 BT", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(382, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 21);
            this.label4.TabIndex = 13;
            this.label4.Text = "Día del Registro:";
            // 
            // txtCodReg_Horas
            // 
            this.txtCodReg_Horas.Enabled = false;
            this.txtCodReg_Horas.Location = new System.Drawing.Point(172, 45);
            this.txtCodReg_Horas.Name = "txtCodReg_Horas";
            this.txtCodReg_Horas.Size = new System.Drawing.Size(125, 27);
            this.txtCodReg_Horas.TabIndex = 1;
            this.txtCodReg_Horas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // FrmReg_Horas_labo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 578);
            this.Controls.Add(this.dgvRegHoraLabo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmReg_Horas_labo";
            this.Text = "FrmReg_Horas_labo";
            this.Load += new System.EventHandler(this.FrmReg_Horas_labo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegHoraLabo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRegHoraLabo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_registro_horalabo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_entrenador;
        private System.Windows.Forms.DataGridViewTextBoxColumn dia_registro;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora_inicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora_final;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker DTHoraFin;
        private System.Windows.Forms.DateTimePicker DTHoraInicio;
        private System.Windows.Forms.DateTimePicker DTDiaRegis;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCodEntrenador;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCodReg_Horas;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCod;
    }
}