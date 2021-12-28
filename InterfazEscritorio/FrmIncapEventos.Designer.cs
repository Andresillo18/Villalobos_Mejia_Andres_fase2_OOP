
namespace InterfazEscritorio
{
    partial class FrmIncapEventos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmIncapEventos));
            this.dgvIncapEvent = new System.Windows.Forms.DataGridView();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCrear = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtObserv = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DTFin = new System.Windows.Forms.DateTimePicker();
            this.DTInicio = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCodEntrenador = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodIncapEvent = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCod = new System.Windows.Forms.TextBox();
            this.cod_incap_event = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cod_entrenador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dia_inicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dia_fin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncapEvent)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvIncapEvent
            // 
            this.dgvIncapEvent.AllowUserToAddRows = false;
            this.dgvIncapEvent.AllowUserToDeleteRows = false;
            this.dgvIncapEvent.AllowUserToResizeColumns = false;
            this.dgvIncapEvent.AllowUserToResizeRows = false;
            this.dgvIncapEvent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIncapEvent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cod_incap_event,
            this.cod_entrenador,
            this.dia_inicio,
            this.dia_fin,
            this.observaciones});
            this.dgvIncapEvent.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvIncapEvent.Location = new System.Drawing.Point(0, 245);
            this.dgvIncapEvent.Name = "dgvIncapEvent";
            this.dgvIncapEvent.RowHeadersWidth = 51;
            this.dgvIncapEvent.RowTemplate.Height = 29;
            this.dgvIncapEvent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIncapEvent.Size = new System.Drawing.Size(945, 226);
            this.dgvIncapEvent.TabIndex = 43;
            this.dgvIncapEvent.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIncapEvent_CellDoubleClick);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.PowderBlue;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(421, 477);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(130, 69);
            this.btnGuardar.TabIndex = 42;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.PowderBlue;
            this.btnEliminar.Image = global::InterfazEscritorio.Properties.Resources.outline_clear_black_24dp;
            this.btnEliminar.Location = new System.Drawing.Point(569, 477);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(130, 69);
            this.btnEliminar.TabIndex = 41;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCrear
            // 
            this.btnCrear.BackColor = System.Drawing.Color.PowderBlue;
            this.btnCrear.Image = global::InterfazEscritorio.Properties.Resources.outline_create_black_24dp;
            this.btnCrear.Location = new System.Drawing.Point(260, 477);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(130, 69);
            this.btnCrear.TabIndex = 40;
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
            this.panel1.TabIndex = 39;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Controls.Add(this.txtObserv);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.DTFin);
            this.panel2.Controls.Add(this.DTInicio);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.linkLabel1);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtCodEntrenador);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtCodIncapEvent);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(945, 233);
            this.panel2.TabIndex = 25;
            // 
            // txtObserv
            // 
            this.txtObserv.Location = new System.Drawing.Point(641, 152);
            this.txtObserv.MaxLength = 500;
            this.txtObserv.Multiline = true;
            this.txtObserv.Name = "txtObserv";
            this.txtObserv.Size = new System.Drawing.Size(180, 66);
            this.txtObserv.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(478, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 23);
            this.label3.TabIndex = 22;
            this.label3.Text = "Observaciones:";
            // 
            // DTFin
            // 
            this.DTFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTFin.Location = new System.Drawing.Point(641, 100);
            this.DTFin.Name = "DTFin";
            this.DTFin.Size = new System.Drawing.Size(155, 27);
            this.DTFin.TabIndex = 21;
            // 
            // DTInicio
            // 
            this.DTInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTInicio.Location = new System.Drawing.Point(641, 42);
            this.DTInicio.Name = "DTInicio";
            this.DTInicio.Size = new System.Drawing.Size(155, 27);
            this.DTInicio.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Square721 BT", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(478, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 21);
            this.label2.TabIndex = 19;
            this.label2.Text = "Fecha de Fin:";
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
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(68, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 23);
            this.label7.TabIndex = 17;
            this.label7.Text = "COD:";
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
            this.label4.Location = new System.Drawing.Point(469, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 21);
            this.label4.TabIndex = 13;
            this.label4.Text = "Fecha de Inicio:";
            // 
            // txtCodIncapEvent
            // 
            this.txtCodIncapEvent.Enabled = false;
            this.txtCodIncapEvent.Location = new System.Drawing.Point(172, 45);
            this.txtCodIncapEvent.Name = "txtCodIncapEvent";
            this.txtCodIncapEvent.Size = new System.Drawing.Size(125, 27);
            this.txtCodIncapEvent.TabIndex = 1;
            this.txtCodIncapEvent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // cod_incap_event
            // 
            this.cod_incap_event.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cod_incap_event.DataPropertyName = "COD_INCAPACIDADES_EVENTOS";
            this.cod_incap_event.HeaderText = "Cod";
            this.cod_incap_event.MinimumWidth = 6;
            this.cod_incap_event.Name = "cod_incap_event";
            this.cod_incap_event.Width = 65;
            // 
            // cod_entrenador
            // 
            this.cod_entrenador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cod_entrenador.DataPropertyName = "COD_ENTRENADOR";
            this.cod_entrenador.HeaderText = "Cod Entrenador";
            this.cod_entrenador.MinimumWidth = 6;
            this.cod_entrenador.Name = "cod_entrenador";
            // 
            // dia_inicio
            // 
            this.dia_inicio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dia_inicio.DataPropertyName = "DIA_INICIO_INCAPACIDADES_EVENTOS";
            this.dia_inicio.HeaderText = "Día de Inicio";
            this.dia_inicio.MinimumWidth = 6;
            this.dia_inicio.Name = "dia_inicio";
            // 
            // dia_fin
            // 
            this.dia_fin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dia_fin.DataPropertyName = "DIA_FINAL_INCAPACIDADES_EVENTOS";
            this.dia_fin.HeaderText = "Día de Fin";
            this.dia_fin.MinimumWidth = 6;
            this.dia_fin.Name = "dia_fin";
            // 
            // observaciones
            // 
            this.observaciones.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.observaciones.DataPropertyName = "OBSERVACIONES_INCAPACIDADES_EVENTOS";
            this.observaciones.HeaderText = "Observaciones";
            this.observaciones.MinimumWidth = 6;
            this.observaciones.Name = "observaciones";
            // 
            // FrmIncapEventos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 552);
            this.Controls.Add(this.dgvIncapEvent);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmIncapEventos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Incapacitaciones o Eventos";
            this.Load += new System.EventHandler(this.FrmIncapEventos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncapEvent)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvIncapEvent;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCodEntrenador;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCodIncapEvent;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCod;
        private System.Windows.Forms.TextBox txtObserv;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DTFin;
        private System.Windows.Forms.DateTimePicker DTInicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_incap_event;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_entrenador;
        private System.Windows.Forms.DataGridViewTextBoxColumn dia_inicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn dia_fin;
        private System.Windows.Forms.DataGridViewTextBoxColumn observaciones;
    }
}