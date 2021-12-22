
namespace InterfazEscritorio
{
    partial class FrmHorarMod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHorarMod));
            this.dgvHorarMod = new System.Windows.Forms.DataGridView();
            this.cod_horar_modulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lunes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.martes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Requesitos_modulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jueves = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viernes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sabado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doming = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inicio_horario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fin_horario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCrear = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DTFinHorar = new System.Windows.Forms.DateTimePicker();
            this.DTInicioHorar = new System.Windows.Forms.DateTimePicker();
            this.CBSabado = new System.Windows.Forms.CheckBox();
            this.CBMiercoles = new System.Windows.Forms.CheckBox();
            this.CBDomingo = new System.Windows.Forms.CheckBox();
            this.CBJueves = new System.Windows.Forms.CheckBox();
            this.CBViernes = new System.Windows.Forms.CheckBox();
            this.CBMartes = new System.Windows.Forms.CheckBox();
            this.CBLunes = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCod = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorarMod)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvHorarMod
            // 
            this.dgvHorarMod.AllowUserToAddRows = false;
            this.dgvHorarMod.AllowUserToDeleteRows = false;
            this.dgvHorarMod.AllowUserToResizeColumns = false;
            this.dgvHorarMod.AllowUserToResizeRows = false;
            this.dgvHorarMod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHorarMod.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cod_horar_modulo,
            this.lunes,
            this.martes,
            this.Requesitos_modulo,
            this.jueves,
            this.viernes,
            this.sabado,
            this.doming,
            this.inicio_horario,
            this.fin_horario});
            this.dgvHorarMod.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvHorarMod.Location = new System.Drawing.Point(0, 245);
            this.dgvHorarMod.Name = "dgvHorarMod";
            this.dgvHorarMod.RowHeadersWidth = 51;
            this.dgvHorarMod.RowTemplate.Height = 29;
            this.dgvHorarMod.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHorarMod.Size = new System.Drawing.Size(945, 226);
            this.dgvHorarMod.TabIndex = 28;
            // 
            // cod_horar_modulo
            // 
            this.cod_horar_modulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cod_horar_modulo.DataPropertyName = "COD_HORARIO_MODULOS";
            this.cod_horar_modulo.HeaderText = "Cod";
            this.cod_horar_modulo.MinimumWidth = 6;
            this.cod_horar_modulo.Name = "cod_horar_modulo";
            this.cod_horar_modulo.Width = 65;
            // 
            // lunes
            // 
            this.lunes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.lunes.DataPropertyName = "DIA_LUNES";
            this.lunes.HeaderText = "Lunes";
            this.lunes.MinimumWidth = 6;
            this.lunes.Name = "lunes";
            // 
            // martes
            // 
            this.martes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.martes.DataPropertyName = "DIA_MARTES";
            this.martes.HeaderText = "Martes";
            this.martes.MinimumWidth = 6;
            this.martes.Name = "martes";
            // 
            // Requesitos_modulo
            // 
            this.Requesitos_modulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Requesitos_modulo.DataPropertyName = "DIA_MIERCOLES";
            this.Requesitos_modulo.HeaderText = "Miércoles";
            this.Requesitos_modulo.MinimumWidth = 6;
            this.Requesitos_modulo.Name = "Requesitos_modulo";
            // 
            // jueves
            // 
            this.jueves.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.jueves.DataPropertyName = "DIA_JUEVES";
            this.jueves.HeaderText = "Jueves";
            this.jueves.MinimumWidth = 6;
            this.jueves.Name = "jueves";
            // 
            // viernes
            // 
            this.viernes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.viernes.DataPropertyName = "DIA_VIERNES";
            this.viernes.HeaderText = "Viernes";
            this.viernes.MinimumWidth = 6;
            this.viernes.Name = "viernes";
            // 
            // sabado
            // 
            this.sabado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sabado.DataPropertyName = "DIA_SABADO";
            this.sabado.HeaderText = "Sábado";
            this.sabado.MinimumWidth = 6;
            this.sabado.Name = "sabado";
            // 
            // doming
            // 
            this.doming.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.doming.DataPropertyName = "DIA_DOMINGO";
            this.doming.HeaderText = "Domingo";
            this.doming.MinimumWidth = 6;
            this.doming.Name = "doming";
            // 
            // inicio_horario
            // 
            this.inicio_horario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.inicio_horario.DataPropertyName = "HORA_INICIO_HORARIO";
            this.inicio_horario.HeaderText = "Hora de Inicio";
            this.inicio_horario.MinimumWidth = 6;
            this.inicio_horario.Name = "inicio_horario";
            // 
            // fin_horario
            // 
            this.fin_horario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fin_horario.DataPropertyName = "HORA_FIN_HORARIO";
            this.fin_horario.HeaderText = "Hora de Fin";
            this.fin_horario.MinimumWidth = 6;
            this.fin_horario.Name = "fin_horario";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.PowderBlue;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(402, 477);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(130, 69);
            this.btnGuardar.TabIndex = 27;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.PowderBlue;
            this.btnEliminar.Image = global::InterfazEscritorio.Properties.Resources.outline_clear_black_24dp;
            this.btnEliminar.Location = new System.Drawing.Point(550, 477);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(130, 69);
            this.btnEliminar.TabIndex = 26;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnCrear
            // 
            this.btnCrear.BackColor = System.Drawing.Color.PowderBlue;
            this.btnCrear.Image = global::InterfazEscritorio.Properties.Resources.outline_create_black_24dp;
            this.btnCrear.Location = new System.Drawing.Point(241, 477);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(130, 69);
            this.btnCrear.TabIndex = 25;
            this.btnCrear.Text = "Crear";
            this.btnCrear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCrear.UseVisualStyleBackColor = false;
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
            this.panel1.TabIndex = 24;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.DTFinHorar);
            this.panel2.Controls.Add(this.DTInicioHorar);
            this.panel2.Controls.Add(this.CBSabado);
            this.panel2.Controls.Add(this.CBMiercoles);
            this.panel2.Controls.Add(this.CBDomingo);
            this.panel2.Controls.Add(this.CBJueves);
            this.panel2.Controls.Add(this.CBViernes);
            this.panel2.Controls.Add(this.CBMartes);
            this.panel2.Controls.Add(this.CBLunes);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(945, 233);
            this.panel2.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(28, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 23);
            this.label5.TabIndex = 14;
            this.label5.Text = "Hora Fin:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(386, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 23);
            this.label4.TabIndex = 13;
            this.label4.Text = "Días:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(26, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "Hora Inicio:";
            // 
            // DTFinHorar
            // 
            this.DTFinHorar.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DTFinHorar.Location = new System.Drawing.Point(129, 157);
            this.DTFinHorar.Name = "DTFinHorar";
            this.DTFinHorar.ShowUpDown = true;
            this.DTFinHorar.Size = new System.Drawing.Size(112, 27);
            this.DTFinHorar.TabIndex = 11;
            // 
            // DTInicioHorar
            // 
            this.DTInicioHorar.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DTInicioHorar.Location = new System.Drawing.Point(129, 106);
            this.DTInicioHorar.Name = "DTInicioHorar";
            this.DTInicioHorar.ShowUpDown = true;
            this.DTInicioHorar.Size = new System.Drawing.Size(112, 27);
            this.DTInicioHorar.TabIndex = 10;
            // 
            // CBSabado
            // 
            this.CBSabado.AutoSize = true;
            this.CBSabado.Location = new System.Drawing.Point(598, 83);
            this.CBSabado.Name = "CBSabado";
            this.CBSabado.Size = new System.Drawing.Size(82, 24);
            this.CBSabado.TabIndex = 8;
            this.CBSabado.Text = "Sábado";
            this.CBSabado.UseVisualStyleBackColor = true;
            // 
            // CBMiercoles
            // 
            this.CBMiercoles.AutoSize = true;
            this.CBMiercoles.Location = new System.Drawing.Point(464, 127);
            this.CBMiercoles.Name = "CBMiercoles";
            this.CBMiercoles.Size = new System.Drawing.Size(95, 24);
            this.CBMiercoles.TabIndex = 7;
            this.CBMiercoles.Text = "Miércoles";
            this.CBMiercoles.UseVisualStyleBackColor = true;
            // 
            // CBDomingo
            // 
            this.CBDomingo.AutoSize = true;
            this.CBDomingo.Location = new System.Drawing.Point(598, 127);
            this.CBDomingo.Name = "CBDomingo";
            this.CBDomingo.Size = new System.Drawing.Size(94, 24);
            this.CBDomingo.TabIndex = 6;
            this.CBDomingo.Text = "Domingo";
            this.CBDomingo.UseVisualStyleBackColor = true;
            // 
            // CBJueves
            // 
            this.CBJueves.AutoSize = true;
            this.CBJueves.Location = new System.Drawing.Point(464, 177);
            this.CBJueves.Name = "CBJueves";
            this.CBJueves.Size = new System.Drawing.Size(73, 24);
            this.CBJueves.TabIndex = 5;
            this.CBJueves.Text = "Jueves";
            this.CBJueves.UseVisualStyleBackColor = true;
            // 
            // CBViernes
            // 
            this.CBViernes.AutoSize = true;
            this.CBViernes.Location = new System.Drawing.Point(598, 37);
            this.CBViernes.Name = "CBViernes";
            this.CBViernes.Size = new System.Drawing.Size(79, 24);
            this.CBViernes.TabIndex = 4;
            this.CBViernes.Text = "Viernes";
            this.CBViernes.UseVisualStyleBackColor = true;
            // 
            // CBMartes
            // 
            this.CBMartes.AutoSize = true;
            this.CBMartes.Location = new System.Drawing.Point(464, 83);
            this.CBMartes.Name = "CBMartes";
            this.CBMartes.Size = new System.Drawing.Size(76, 24);
            this.CBMartes.TabIndex = 3;
            this.CBMartes.Text = "Martes";
            this.CBMartes.UseVisualStyleBackColor = true;
            // 
            // CBLunes
            // 
            this.CBLunes.AutoSize = true;
            this.CBLunes.Location = new System.Drawing.Point(464, 37);
            this.CBLunes.Name = "CBLunes";
            this.CBLunes.Size = new System.Drawing.Size(68, 24);
            this.CBLunes.TabIndex = 2;
            this.CBLunes.Text = "Lunes";
            this.CBLunes.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(41, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "COD:";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(116, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 27);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // FrmHorarMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 552);
            this.Controls.Add(this.dgvHorarMod);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.panel1);
            this.Name = "FrmHorarMod";
            this.Text = "FrmHorarMod";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorarMod)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHorarMod;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCod;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DTFinHorar;
        private System.Windows.Forms.DateTimePicker DTInicioHorar;
        private System.Windows.Forms.CheckBox CBSabado;
        private System.Windows.Forms.CheckBox CBMiercoles;
        private System.Windows.Forms.CheckBox CBDomingo;
        private System.Windows.Forms.CheckBox CBJueves;
        private System.Windows.Forms.CheckBox CBViernes;
        private System.Windows.Forms.CheckBox CBMartes;
        private System.Windows.Forms.CheckBox CBLunes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_horar_modulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn lunes;
        private System.Windows.Forms.DataGridViewTextBoxColumn martes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Requesitos_modulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn jueves;
        private System.Windows.Forms.DataGridViewTextBoxColumn viernes;
        private System.Windows.Forms.DataGridViewTextBoxColumn sabado;
        private System.Windows.Forms.DataGridViewTextBoxColumn doming;
        private System.Windows.Forms.DataGridViewTextBoxColumn inicio_horario;
        private System.Windows.Forms.DataGridViewTextBoxColumn fin_horario;
    }
}