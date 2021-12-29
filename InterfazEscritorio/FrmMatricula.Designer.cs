
namespace InterfazEscritorio
{
    partial class FrmMatricula
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMatricula));
            this.dgvModulos = new System.Windows.Forms.DataGridView();
            this.cod_atleta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cod_modulo_abierto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_matricula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado_matricula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monto_cancelado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCrear = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCodMatricula = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CBTipoPago = new System.Windows.Forms.ComboBox();
            this.CBTipoCobro = new System.Windows.Forms.ComboBox();
            this.NPMontoCancelado = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NPNotaFinal = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.CBEstado = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.DTFechaMatricula = new System.Windows.Forms.DateTimePicker();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.txtCod_Entrenador = new System.Windows.Forms.TextBox();
            this.txtCod_Modulo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModulos)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NPMontoCancelado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NPNotaFinal)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvModulos
            // 
            this.dgvModulos.AllowUserToAddRows = false;
            this.dgvModulos.AllowUserToDeleteRows = false;
            this.dgvModulos.AllowUserToResizeColumns = false;
            this.dgvModulos.AllowUserToResizeRows = false;
            this.dgvModulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModulos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cod_atleta,
            this.cod_modulo_abierto,
            this.fecha_matricula,
            this.estado_matricula,
            this.monto_cancelado});
            this.dgvModulos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvModulos.Location = new System.Drawing.Point(0, 249);
            this.dgvModulos.Name = "dgvModulos";
            this.dgvModulos.RowHeadersWidth = 51;
            this.dgvModulos.RowTemplate.Height = 29;
            this.dgvModulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvModulos.Size = new System.Drawing.Size(945, 242);
            this.dgvModulos.TabIndex = 28;
            // 
            // cod_atleta
            // 
            this.cod_atleta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cod_atleta.DataPropertyName = "COD_ATLETA";
            this.cod_atleta.HeaderText = "Cod Atleta";
            this.cod_atleta.MinimumWidth = 6;
            this.cod_atleta.Name = "cod_atleta";
            this.cod_atleta.Width = 101;
            // 
            // cod_modulo_abierto
            // 
            this.cod_modulo_abierto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cod_modulo_abierto.DataPropertyName = "COD_MODULO_ABIERTO";
            this.cod_modulo_abierto.HeaderText = "Cod Módulo Abierto";
            this.cod_modulo_abierto.MinimumWidth = 6;
            this.cod_modulo_abierto.Name = "cod_modulo_abierto";
            // 
            // fecha_matricula
            // 
            this.fecha_matricula.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fecha_matricula.DataPropertyName = "FECHA_MATRICULA";
            this.fecha_matricula.HeaderText = "Fecha de Matrícula";
            this.fecha_matricula.MinimumWidth = 6;
            this.fecha_matricula.Name = "fecha_matricula";
            // 
            // estado_matricula
            // 
            this.estado_matricula.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.estado_matricula.DataPropertyName = "ESTADO";
            this.estado_matricula.HeaderText = "Estado";
            this.estado_matricula.MinimumWidth = 6;
            this.estado_matricula.Name = "estado_matricula";
            // 
            // monto_cancelado
            // 
            this.monto_cancelado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.monto_cancelado.DataPropertyName = "MONTO_CANCELADO";
            this.monto_cancelado.HeaderText = "Monto Cancelado";
            this.monto_cancelado.MinimumWidth = 6;
            this.monto_cancelado.Name = "monto_cancelado";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.PowderBlue;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(416, 497);
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
            this.btnEliminar.Location = new System.Drawing.Point(583, 497);
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
            this.btnCrear.Location = new System.Drawing.Point(250, 497);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(130, 69);
            this.btnCrear.TabIndex = 25;
            this.btnCrear.Text = "Crear";
            this.btnCrear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCrear.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Controls.Add(this.txtCodMatricula);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.CBTipoPago);
            this.panel1.Controls.Add(this.CBTipoCobro);
            this.panel1.Controls.Add(this.NPMontoCancelado);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.NPNotaFinal);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CBEstado);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.DTFechaMatricula);
            this.panel1.Controls.Add(this.linkLabel2);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.txtCod_Entrenador);
            this.panel1.Controls.Add(this.txtCod_Modulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(945, 243);
            this.panel1.TabIndex = 29;
            // 
            // txtCodMatricula
            // 
            this.txtCodMatricula.Location = new System.Drawing.Point(187, 31);
            this.txtCodMatricula.MaxLength = 200;
            this.txtCodMatricula.Name = "txtCodMatricula";
            this.txtCodMatricula.ReadOnly = true;
            this.txtCodMatricula.Size = new System.Drawing.Size(125, 27);
            this.txtCodMatricula.TabIndex = 37;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(24, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 23);
            this.label7.TabIndex = 36;
            this.label7.Text = "Cod Matrícula:";
            // 
            // CBTipoPago
            // 
            this.CBTipoPago.FormattingEnabled = true;
            this.CBTipoPago.Items.AddRange(new object[] {
            "Transferencia",
            "Sinpe",
            "Tarjeta",
            "Efectivo"});
            this.CBTipoPago.Location = new System.Drawing.Point(788, 133);
            this.CBTipoPago.Name = "CBTipoPago";
            this.CBTipoPago.Size = new System.Drawing.Size(151, 28);
            this.CBTipoPago.TabIndex = 35;
            // 
            // CBTipoCobro
            // 
            this.CBTipoCobro.FormattingEnabled = true;
            this.CBTipoCobro.Items.AddRange(new object[] {
            "Curso",
            "Curso y Matricula"});
            this.CBTipoCobro.Location = new System.Drawing.Point(788, 79);
            this.CBTipoCobro.Name = "CBTipoCobro";
            this.CBTipoCobro.Size = new System.Drawing.Size(151, 28);
            this.CBTipoCobro.TabIndex = 34;
            // 
            // NPMontoCancelado
            // 
            this.NPMontoCancelado.Location = new System.Drawing.Point(472, 190);
            this.NPMontoCancelado.Maximum = new decimal(new int[] {
            200000,
            0,
            0,
            0});
            this.NPMontoCancelado.Name = "NPMontoCancelado";
            this.NPMontoCancelado.Size = new System.Drawing.Size(150, 27);
            this.NPMontoCancelado.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(659, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 23);
            this.label6.TabIndex = 32;
            this.label6.Text = "Tipo de Cobro:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(659, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 23);
            this.label5.TabIndex = 31;
            this.label5.Text = "Tipo de Pago:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(319, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 23);
            this.label4.TabIndex = 30;
            this.label4.Text = "Monto cancelado:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(357, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 23);
            this.label3.TabIndex = 29;
            this.label3.Text = "Nota Final:";
            // 
            // NPNotaFinal
            // 
            this.NPNotaFinal.Location = new System.Drawing.Point(472, 129);
            this.NPNotaFinal.Name = "NPNotaFinal";
            this.NPNotaFinal.Size = new System.Drawing.Size(150, 27);
            this.NPNotaFinal.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(368, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 23);
            this.label1.TabIndex = 28;
            this.label1.Text = "Estado:";
            // 
            // CBEstado
            // 
            this.CBEstado.FormattingEnabled = true;
            this.CBEstado.Items.AddRange(new object[] {
            "En curso",
            "Abandonó",
            "Aprovado",
            "Reprovado"});
            this.CBEstado.Location = new System.Drawing.Point(471, 75);
            this.CBEstado.Name = "CBEstado";
            this.CBEstado.Size = new System.Drawing.Size(151, 28);
            this.CBEstado.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(32, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 23);
            this.label2.TabIndex = 26;
            this.label2.Text = "Referencias:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(368, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(158, 23);
            this.label10.TabIndex = 25;
            this.label10.Text = "Fecha de Matrícula:";
            // 
            // DTFechaMatricula
            // 
            this.DTFechaMatricula.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DTFechaMatricula.Location = new System.Drawing.Point(544, 23);
            this.DTFechaMatricula.Name = "DTFechaMatricula";
            this.DTFechaMatricula.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DTFechaMatricula.Size = new System.Drawing.Size(296, 27);
            this.DTFechaMatricula.TabIndex = 24;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.linkLabel2.LinkColor = System.Drawing.Color.Black;
            this.linkLabel2.Location = new System.Drawing.Point(6, 182);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(175, 23);
            this.linkLabel2.TabIndex = 21;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "COD Módulo Abierto:";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(32, 138);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(100, 23);
            this.linkLabel1.TabIndex = 20;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "COD Atleta:";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // txtCod_Entrenador
            // 
            this.txtCod_Entrenador.Location = new System.Drawing.Point(187, 134);
            this.txtCod_Entrenador.MaxLength = 200;
            this.txtCod_Entrenador.Name = "txtCod_Entrenador";
            this.txtCod_Entrenador.Size = new System.Drawing.Size(125, 27);
            this.txtCod_Entrenador.TabIndex = 2;
            // 
            // txtCod_Modulo
            // 
            this.txtCod_Modulo.Location = new System.Drawing.Point(187, 182);
            this.txtCod_Modulo.MaxLength = 40;
            this.txtCod_Modulo.Name = "txtCod_Modulo";
            this.txtCod_Modulo.Size = new System.Drawing.Size(125, 27);
            this.txtCod_Modulo.TabIndex = 3;
            // 
            // FrmMatricula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 578);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvModulos);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnCrear);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmMatricula";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Matriculas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvModulos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NPMontoCancelado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NPNotaFinal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvModulos;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker DTFechaMatricula;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox txtCod_Entrenador;
        private System.Windows.Forms.TextBox txtCod_Modulo;
        private System.Windows.Forms.NumericUpDown NPMontoCancelado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown NPNotaFinal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CBEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_atleta;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_modulo_abierto;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_matricula;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado_matricula;
        private System.Windows.Forms.DataGridViewTextBoxColumn monto_cancelado;
        private System.Windows.Forms.ComboBox CBTipoPago;
        private System.Windows.Forms.ComboBox CBTipoCobro;
        private System.Windows.Forms.TextBox txtCodMatricula;
        private System.Windows.Forms.Label label7;
    }
}