
namespace InterfazEscritorio
{
    partial class FrmModulosAbie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModulosAbie));
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCrear = new System.Windows.Forms.Button();
            this.grdListaModAbier = new System.Windows.Forms.DataGridView();
            this.cod_programa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_entrenador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cod_modulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cod_horario_modulos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_inicio_mod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_fin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observa_mod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.DTFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.txtHorarioModulos = new System.Windows.Forms.TextBox();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCod_Entrenador = new System.Windows.Forms.TextBox();
            this.txtCod_Modulo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCod = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdListaModAbier)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.PowderBlue;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(355, 382);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(114, 52);
            this.btnGuardar.TabIndex = 22;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.PowderBlue;
            this.btnEliminar.Image = global::InterfazEscritorio.Properties.Resources.outline_clear_black_24dp;
            this.btnEliminar.Location = new System.Drawing.Point(484, 382);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(114, 52);
            this.btnEliminar.TabIndex = 21;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCrear
            // 
            this.btnCrear.BackColor = System.Drawing.Color.PowderBlue;
            this.btnCrear.Image = global::InterfazEscritorio.Properties.Resources.outline_create_black_24dp;
            this.btnCrear.Location = new System.Drawing.Point(210, 382);
            this.btnCrear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(114, 52);
            this.btnCrear.TabIndex = 20;
            this.btnCrear.Text = "Crear";
            this.btnCrear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCrear.UseVisualStyleBackColor = false;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // grdListaModAbier
            // 
            this.grdListaModAbier.AllowUserToAddRows = false;
            this.grdListaModAbier.AllowUserToDeleteRows = false;
            this.grdListaModAbier.AllowUserToResizeColumns = false;
            this.grdListaModAbier.AllowUserToResizeRows = false;
            this.grdListaModAbier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdListaModAbier.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cod_programa,
            this.nombre_entrenador,
            this.cod_modulo,
            this.cod_horario_modulos,
            this.fecha_inicio_mod,
            this.fecha_fin,
            this.observa_mod});
            this.grdListaModAbier.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdListaModAbier.Location = new System.Drawing.Point(0, 199);
            this.grdListaModAbier.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdListaModAbier.Name = "grdListaModAbier";
            this.grdListaModAbier.RowHeadersWidth = 51;
            this.grdListaModAbier.RowTemplate.Height = 29;
            this.grdListaModAbier.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdListaModAbier.Size = new System.Drawing.Size(827, 170);
            this.grdListaModAbier.TabIndex = 19;
            this.grdListaModAbier.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdListaModAbier_CellDoubleClick);
            // 
            // cod_programa
            // 
            this.cod_programa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cod_programa.DataPropertyName = "COD_MODULO_ABIERTO";
            this.cod_programa.HeaderText = "Cod";
            this.cod_programa.MinimumWidth = 6;
            this.cod_programa.Name = "cod_programa";
            this.cod_programa.Width = 54;
            // 
            // nombre_entrenador
            // 
            this.nombre_entrenador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombre_entrenador.DataPropertyName = "COD_ENTRENADOR";
            this.nombre_entrenador.HeaderText = "Cod Entrenador";
            this.nombre_entrenador.MinimumWidth = 6;
            this.nombre_entrenador.Name = "nombre_entrenador";
            // 
            // cod_modulo
            // 
            this.cod_modulo.DataPropertyName = "COD_MODULO";
            this.cod_modulo.HeaderText = "Cod Módulo";
            this.cod_modulo.MinimumWidth = 6;
            this.cod_modulo.Name = "cod_modulo";
            this.cod_modulo.Width = 125;
            // 
            // cod_horario_modulos
            // 
            this.cod_horario_modulos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cod_horario_modulos.DataPropertyName = "COD_HORARIO_MODULOS";
            this.cod_horario_modulos.HeaderText = "Cod Horario";
            this.cod_horario_modulos.MinimumWidth = 6;
            this.cod_horario_modulos.Name = "cod_horario_modulos";
            // 
            // fecha_inicio_mod
            // 
            this.fecha_inicio_mod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fecha_inicio_mod.DataPropertyName = "FECHA_INICIO_MODULO";
            this.fecha_inicio_mod.HeaderText = "Fecha Inicio";
            this.fecha_inicio_mod.MinimumWidth = 6;
            this.fecha_inicio_mod.Name = "fecha_inicio_mod";
            // 
            // fecha_fin
            // 
            this.fecha_fin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fecha_fin.DataPropertyName = "FECHA_FINAL_MODULO";
            this.fecha_fin.HeaderText = "Fecha Fin";
            this.fecha_fin.MinimumWidth = 6;
            this.fecha_fin.Name = "fecha_fin";
            // 
            // observa_mod
            // 
            this.observa_mod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.observa_mod.DataPropertyName = "OBSERVACIONES_MODULO_ABIERTO";
            this.observa_mod.HeaderText = "Observaciones";
            this.observa_mod.MinimumWidth = 6;
            this.observa_mod.Name = "observa_mod";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.DTFechaInicio);
            this.panel1.Controls.Add(this.txtHorarioModulos);
            this.panel1.Controls.Add(this.linkLabel3);
            this.panel1.Controls.Add(this.linkLabel2);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.txtObservaciones);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtCod_Entrenador);
            this.panel1.Controls.Add(this.txtCod_Modulo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtCod);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(827, 195);
            this.panel1.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(556, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "Referencias:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(20, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 19);
            this.label10.TabIndex = 25;
            this.label10.Text = "Fecha Inicio:";
            // 
            // DTFechaInicio
            // 
            this.DTFechaInicio.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DTFechaInicio.Location = new System.Drawing.Point(142, 62);
            this.DTFechaInicio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DTFechaInicio.Name = "DTFechaInicio";
            this.DTFechaInicio.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DTFechaInicio.Size = new System.Drawing.Size(260, 23);
            this.DTFechaInicio.TabIndex = 24;
            // 
            // txtHorarioModulos
            // 
            this.txtHorarioModulos.Location = new System.Drawing.Point(670, 137);
            this.txtHorarioModulos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtHorarioModulos.MaxLength = 40;
            this.txtHorarioModulos.Name = "txtHorarioModulos";
            this.txtHorarioModulos.Size = new System.Drawing.Size(110, 23);
            this.txtHorarioModulos.TabIndex = 4;
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.linkLabel3.LinkColor = System.Drawing.Color.Black;
            this.linkLabel3.Location = new System.Drawing.Point(544, 133);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(92, 19);
            this.linkLabel3.TabIndex = 22;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "COD Horario:";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.linkLabel2.LinkColor = System.Drawing.Color.Black;
            this.linkLabel2.Location = new System.Drawing.Point(544, 98);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(94, 19);
            this.linkLabel2.TabIndex = 21;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "COD Módulo:";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(542, 64);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(114, 19);
            this.linkLabel1.TabIndex = 20;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "COD Entrenador:";
            this.linkLabel1.Click += new System.EventHandler(this.linkLabel1_Click);
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(142, 104);
            this.txtObservaciones.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtObservaciones.MaxLength = 500;
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(203, 62);
            this.txtObservaciones.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(20, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 19);
            this.label9.TabIndex = 15;
            this.label9.Text = "Observaciones:";
            // 
            // txtCod_Entrenador
            // 
            this.txtCod_Entrenador.Location = new System.Drawing.Point(670, 64);
            this.txtCod_Entrenador.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCod_Entrenador.MaxLength = 200;
            this.txtCod_Entrenador.Name = "txtCod_Entrenador";
            this.txtCod_Entrenador.Size = new System.Drawing.Size(110, 23);
            this.txtCod_Entrenador.TabIndex = 2;
            // 
            // txtCod_Modulo
            // 
            this.txtCod_Modulo.Location = new System.Drawing.Point(670, 98);
            this.txtCod_Modulo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCod_Modulo.MaxLength = 40;
            this.txtCod_Modulo.Name = "txtCod_Modulo";
            this.txtCod_Modulo.Size = new System.Drawing.Size(110, 23);
            this.txtCod_Modulo.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(67, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "COD:";
            // 
            // txtCod
            // 
            this.txtCod.Enabled = false;
            this.txtCod.Location = new System.Drawing.Point(142, 16);
            this.txtCod.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCod.Name = "txtCod";
            this.txtCod.Size = new System.Drawing.Size(110, 23);
            this.txtCod.TabIndex = 1;
            this.txtCod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FrmModulosAbie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 445);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.grdListaModAbier);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmModulosAbie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Módulos Abiertos";
            this.Load += new System.EventHandler(this.FrmModulosAbie_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdListaModAbier)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.DataGridView grdListaModAbier;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCod_Entrenador;
        private System.Windows.Forms.TextBox txtCod_Modulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCod;
        private System.Windows.Forms.TextBox txtHorarioModulos;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_programa;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_entrenador;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_modulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_horario_modulos;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_inicio_mod;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_fin;
        private System.Windows.Forms.DataGridViewTextBoxColumn observa_mod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker DTFechaInicio;
    }
}