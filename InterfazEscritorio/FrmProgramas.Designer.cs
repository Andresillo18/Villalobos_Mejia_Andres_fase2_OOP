
namespace InterfazEscritorio
{
    partial class FrmProgramas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProgramas));
            this.label1 = new System.Windows.Forms.Label();
            this.txtCod = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.RDInactivo = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtProvincia = new System.Windows.Forms.TextBox();
            this.DTFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.txtCupo = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.RDActivo = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.grdListaProgramas = new System.Windows.Forms.DataGridView();
            this.btnCrear = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.cod_programa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_prog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion_prog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cupo_prog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefono_prog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email_prog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.provincia_prog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_inicio_prog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_fin_prog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observaciones_prog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdListaProgramas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(14, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "COD:";
            // 
            // txtCod
            // 
            this.txtCod.Enabled = false;
            this.txtCod.Location = new System.Drawing.Point(70, 9);
            this.txtCod.Name = "txtCod";
            this.txtCod.Size = new System.Drawing.Size(125, 27);
            this.txtCod.TabIndex = 1;
            this.txtCod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(642, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Provincia:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(14, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cupo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(748, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Estado:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.AcceptsTab = true;
            this.txtDescripcion.Location = new System.Drawing.Point(551, 13);
            this.txtDescripcion.MaxLength = 150;
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(174, 55);
            this.txtDescripcion.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(447, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Descripción:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(298, 12);
            this.txtNombre.MaxLength = 40;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(125, 27);
            this.txtNombre.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(219, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "Nombre:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtObservaciones);
            this.panel1.Controls.Add(this.RDInactivo);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtProvincia);
            this.panel1.Controls.Add(this.DTFechaInicio);
            this.panel1.Controls.Add(this.txtCupo);
            this.panel1.Controls.Add(this.txtTelefono);
            this.panel1.Controls.Add(this.RDActivo);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtNombre);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtDescripcion);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtCod);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(945, 233);
            this.panel1.TabIndex = 12;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(508, 104);
            this.txtEmail.MaxLength = 20;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(125, 27);
            this.txtEmail.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(434, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 23);
            this.label7.TabIndex = 18;
            this.label7.Text = "Email:";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(585, 163);
            this.txtObservaciones.MaxLength = 500;
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(202, 56);
            this.txtObservaciones.TabIndex = 8;
            // 
            // RDInactivo
            // 
            this.RDInactivo.AutoSize = true;
            this.RDInactivo.Location = new System.Drawing.Point(825, 44);
            this.RDInactivo.Name = "RDInactivo";
            this.RDInactivo.Size = new System.Drawing.Size(82, 24);
            this.RDInactivo.TabIndex = 13;
            this.RDInactivo.TabStop = true;
            this.RDInactivo.Text = "Inactivo";
            this.RDInactivo.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(455, 164);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(124, 23);
            this.label9.TabIndex = 15;
            this.label9.Text = "Observaciones:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(14, 164);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 23);
            this.label10.TabIndex = 16;
            this.label10.Text = "Fecha Inicio:";
            // 
            // txtProvincia
            // 
            this.txtProvincia.Location = new System.Drawing.Point(731, 108);
            this.txtProvincia.MaxLength = 20;
            this.txtProvincia.Name = "txtProvincia";
            this.txtProvincia.Size = new System.Drawing.Size(125, 27);
            this.txtProvincia.TabIndex = 6;
            // 
            // DTFechaInicio
            // 
            this.DTFechaInicio.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DTFechaInicio.Location = new System.Drawing.Point(124, 164);
            this.DTFechaInicio.Name = "DTFechaInicio";
            this.DTFechaInicio.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DTFechaInicio.Size = new System.Drawing.Size(296, 27);
            this.DTFechaInicio.TabIndex = 7;
            // 
            // txtCupo
            // 
            this.txtCupo.Location = new System.Drawing.Point(88, 96);
            this.txtCupo.MaxLength = 200;
            this.txtCupo.Name = "txtCupo";
            this.txtCupo.Size = new System.Drawing.Size(125, 27);
            this.txtCupo.TabIndex = 4;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(303, 99);
            this.txtTelefono.MaxLength = 15;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(125, 27);
            this.txtTelefono.TabIndex = 5;
            // 
            // RDActivo
            // 
            this.RDActivo.AutoSize = true;
            this.RDActivo.Location = new System.Drawing.Point(825, 10);
            this.RDActivo.Name = "RDActivo";
            this.RDActivo.Size = new System.Drawing.Size(72, 24);
            this.RDActivo.TabIndex = 12;
            this.RDActivo.TabStop = true;
            this.RDActivo.Text = "Activo";
            this.RDActivo.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(219, 100);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 23);
            this.label11.TabIndex = 17;
            this.label11.Text = "Teléfono:";
            // 
            // grdListaProgramas
            // 
            this.grdListaProgramas.AllowUserToAddRows = false;
            this.grdListaProgramas.AllowUserToDeleteRows = false;
            this.grdListaProgramas.AllowUserToResizeColumns = false;
            this.grdListaProgramas.AllowUserToResizeRows = false;
            this.grdListaProgramas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdListaProgramas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cod_programa,
            this.nombre_prog,
            this.descripcion_prog,
            this.estado,
            this.cupo_prog,
            this.telefono_prog,
            this.email_prog,
            this.provincia_prog,
            this.fecha_inicio_prog,
            this.fecha_fin_prog,
            this.observaciones_prog});
            this.grdListaProgramas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdListaProgramas.Location = new System.Drawing.Point(0, 239);
            this.grdListaProgramas.Name = "grdListaProgramas";
            this.grdListaProgramas.RowHeadersWidth = 51;
            this.grdListaProgramas.RowTemplate.Height = 29;
            this.grdListaProgramas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdListaProgramas.Size = new System.Drawing.Size(945, 213);
            this.grdListaProgramas.TabIndex = 13;
            this.grdListaProgramas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdListaProgramas_CellDoubleClick);
            // 
            // btnCrear
            // 
            this.btnCrear.BackColor = System.Drawing.Color.PowderBlue;
            this.btnCrear.Image = global::InterfazEscritorio.Properties.Resources.outline_create_black_24dp;
            this.btnCrear.Location = new System.Drawing.Point(242, 471);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(130, 69);
            this.btnCrear.TabIndex = 14;
            this.btnCrear.Text = "Crear";
            this.btnCrear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCrear.UseVisualStyleBackColor = false;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.PowderBlue;
            this.btnEliminar.Image = global::InterfazEscritorio.Properties.Resources.outline_clear_black_24dp;
            this.btnEliminar.Location = new System.Drawing.Point(566, 471);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(130, 69);
            this.btnEliminar.TabIndex = 16;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.PowderBlue;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(408, 471);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(130, 69);
            this.btnGuardar.TabIndex = 17;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // cod_programa
            // 
            this.cod_programa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cod_programa.DataPropertyName = "COD_PROGRAMA";
            this.cod_programa.HeaderText = "Cod";
            this.cod_programa.MinimumWidth = 6;
            this.cod_programa.Name = "cod_programa";
            this.cod_programa.Width = 65;
            // 
            // nombre_prog
            // 
            this.nombre_prog.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombre_prog.DataPropertyName = "NOMBRE_PROGRAMA";
            this.nombre_prog.HeaderText = "Nombre";
            this.nombre_prog.MinimumWidth = 6;
            this.nombre_prog.Name = "nombre_prog";
            // 
            // descripcion_prog
            // 
            this.descripcion_prog.DataPropertyName = "DESCRIPCION_PROGRAMA";
            this.descripcion_prog.HeaderText = "Descripción";
            this.descripcion_prog.MinimumWidth = 6;
            this.descripcion_prog.Name = "descripcion_prog";
            this.descripcion_prog.Visible = false;
            this.descripcion_prog.Width = 125;
            // 
            // estado
            // 
            this.estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.estado.DataPropertyName = "ESTADO";
            this.estado.HeaderText = "Estado";
            this.estado.MinimumWidth = 6;
            this.estado.Name = "estado";
            // 
            // cupo_prog
            // 
            this.cupo_prog.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cupo_prog.DataPropertyName = "CUPO_PROGRAMA";
            this.cupo_prog.HeaderText = "Cupo";
            this.cupo_prog.MinimumWidth = 6;
            this.cupo_prog.Name = "cupo_prog";
            // 
            // telefono_prog
            // 
            this.telefono_prog.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.telefono_prog.DataPropertyName = "TELEFONO_PROGRAMA";
            this.telefono_prog.HeaderText = "Teléfono";
            this.telefono_prog.MinimumWidth = 6;
            this.telefono_prog.Name = "telefono_prog";
            // 
            // email_prog
            // 
            this.email_prog.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.email_prog.DataPropertyName = "EMAIL_PROGRAMA";
            this.email_prog.HeaderText = "Email";
            this.email_prog.MinimumWidth = 6;
            this.email_prog.Name = "email_prog";
            // 
            // provincia_prog
            // 
            this.provincia_prog.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.provincia_prog.DataPropertyName = "PROVINCIA_PROGRAMA";
            this.provincia_prog.HeaderText = "Provincia";
            this.provincia_prog.MinimumWidth = 6;
            this.provincia_prog.Name = "provincia_prog";
            // 
            // fecha_inicio_prog
            // 
            this.fecha_inicio_prog.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fecha_inicio_prog.DataPropertyName = "FECHA_INICIO_PROGRAMA";
            this.fecha_inicio_prog.HeaderText = "Inicio";
            this.fecha_inicio_prog.MinimumWidth = 6;
            this.fecha_inicio_prog.Name = "fecha_inicio_prog";
            // 
            // fecha_fin_prog
            // 
            this.fecha_fin_prog.DataPropertyName = "FECHA_FIN_PROGRAMA";
            this.fecha_fin_prog.HeaderText = "Fin";
            this.fecha_fin_prog.MinimumWidth = 6;
            this.fecha_fin_prog.Name = "fecha_fin_prog";
            this.fecha_fin_prog.Width = 102;
            // 
            // observaciones_prog
            // 
            this.observaciones_prog.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.observaciones_prog.DataPropertyName = "OBSERVACIONES_PROGRAMA";
            this.observaciones_prog.HeaderText = "Observaciones";
            this.observaciones_prog.MinimumWidth = 6;
            this.observaciones_prog.Name = "observaciones_prog";
            this.observaciones_prog.Visible = false;
            // 
            // FrmProgramas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 552);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.grdListaProgramas);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "FrmProgramas";
            this.Text = "Programas";
            this.Load += new System.EventHandler(this.FrmProgramas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdListaProgramas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker DTFechaInicio;
        private System.Windows.Forms.RadioButton RDInactivo;
        private System.Windows.Forms.RadioButton RDActivo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtProvincia;
        private System.Windows.Forms.TextBox txtCupo;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.DataGridView grdListaProgramas;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_programa;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_prog;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion_prog;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn cupo_prog;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefono_prog;
        private System.Windows.Forms.DataGridViewTextBoxColumn email_prog;
        private System.Windows.Forms.DataGridViewTextBoxColumn provincia_prog;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_inicio_prog;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_fin_prog;
        private System.Windows.Forms.DataGridViewTextBoxColumn observaciones_prog;
    }
}