
namespace InterfazEscritorio
{
    partial class FrmAtleta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAtleta));
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCrear = new System.Windows.Forms.Button();
            this.grdListaAtletas = new System.Windows.Forms.DataGridView();
            this.Cod_entrenador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_entrenador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellido1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellido2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefono1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefono2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.provincia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.distrito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.canton = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaNacimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CBGenero = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtProvincia = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.DTFechaNacimie = new System.Windows.Forms.DateTimePicker();
            this.RBInactivo = new System.Windows.Forms.RadioButton();
            this.Nacimiento = new System.Windows.Forms.Label();
            this.RBActivo = new System.Windows.Forms.RadioButton();
            this.txtDistrito = new System.Windows.Forms.TextBox();
            this.txtApellido2 = new System.Windows.Forms.TextBox();
            this.txtTelefono1 = new System.Windows.Forms.TextBox();
            this.txtApellido1 = new System.Windows.Forms.TextBox();
            this.txtTelefono2 = new System.Windows.Forms.TextBox();
            this.txtCanton = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodAtleta = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCod = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdListaAtletas)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.PowderBlue;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(638, 497);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(130, 69);
            this.btnBuscar.TabIndex = 34;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.PowderBlue;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(345, 497);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(130, 69);
            this.btnGuardar.TabIndex = 33;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.PowderBlue;
            this.btnEliminar.Image = global::InterfazEscritorio.Properties.Resources.outline_clear_black_24dp;
            this.btnEliminar.Location = new System.Drawing.Point(496, 497);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(130, 69);
            this.btnEliminar.TabIndex = 32;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCrear
            // 
            this.btnCrear.BackColor = System.Drawing.Color.PowderBlue;
            this.btnCrear.Image = global::InterfazEscritorio.Properties.Resources.outline_create_black_24dp;
            this.btnCrear.Location = new System.Drawing.Point(194, 497);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(130, 69);
            this.btnCrear.TabIndex = 31;
            this.btnCrear.Text = "Crear";
            this.btnCrear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCrear.UseVisualStyleBackColor = false;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // grdListaAtletas
            // 
            this.grdListaAtletas.AllowUserToAddRows = false;
            this.grdListaAtletas.AllowUserToDeleteRows = false;
            this.grdListaAtletas.AllowUserToResizeColumns = false;
            this.grdListaAtletas.AllowUserToResizeRows = false;
            this.grdListaAtletas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdListaAtletas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cod_entrenador,
            this.id,
            this.nombre_entrenador,
            this.apellido1,
            this.apellido2,
            this.telefono1,
            this.telefono2,
            this.genero,
            this.provincia,
            this.distrito,
            this.canton,
            this.fechaNacimiento,
            this.estado});
            this.grdListaAtletas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdListaAtletas.Location = new System.Drawing.Point(3, 240);
            this.grdListaAtletas.Name = "grdListaAtletas";
            this.grdListaAtletas.RowHeadersWidth = 51;
            this.grdListaAtletas.RowTemplate.Height = 29;
            this.grdListaAtletas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdListaAtletas.Size = new System.Drawing.Size(945, 243);
            this.grdListaAtletas.TabIndex = 30;
            this.grdListaAtletas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdListaAtletas_CellDoubleClick);
            // 
            // Cod_entrenador
            // 
            this.Cod_entrenador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Cod_entrenador.DataPropertyName = "COD_ATLETA";
            this.Cod_entrenador.Frozen = true;
            this.Cod_entrenador.HeaderText = "Cod";
            this.Cod_entrenador.MinimumWidth = 6;
            this.Cod_entrenador.Name = "Cod_entrenador";
            this.Cod_entrenador.Width = 65;
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.id.DataPropertyName = "ID_ATLETA";
            this.id.Frozen = true;
            this.id.HeaderText = "ID";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.Width = 53;
            // 
            // nombre_entrenador
            // 
            this.nombre_entrenador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nombre_entrenador.DataPropertyName = "NOMBRE_ATLETA";
            this.nombre_entrenador.Frozen = true;
            this.nombre_entrenador.HeaderText = "Nombre";
            this.nombre_entrenador.MinimumWidth = 6;
            this.nombre_entrenador.Name = "nombre_entrenador";
            this.nombre_entrenador.Width = 93;
            // 
            // apellido1
            // 
            this.apellido1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.apellido1.DataPropertyName = "APELLIDO1_ATLETA";
            this.apellido1.Frozen = true;
            this.apellido1.HeaderText = "Apellido 1";
            this.apellido1.MinimumWidth = 6;
            this.apellido1.Name = "apellido1";
            this.apellido1.Width = 99;
            // 
            // apellido2
            // 
            this.apellido2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.apellido2.DataPropertyName = "APELLIDO2_ATLETA";
            this.apellido2.HeaderText = "Apellido 2";
            this.apellido2.MinimumWidth = 6;
            this.apellido2.Name = "apellido2";
            this.apellido2.Visible = false;
            this.apellido2.Width = 125;
            // 
            // telefono1
            // 
            this.telefono1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.telefono1.DataPropertyName = "TELEFONO1_ATLETA";
            this.telefono1.Frozen = true;
            this.telefono1.HeaderText = "Teléfono";
            this.telefono1.MinimumWidth = 6;
            this.telefono1.Name = "telefono1";
            this.telefono1.Width = 96;
            // 
            // telefono2
            // 
            this.telefono2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.telefono2.DataPropertyName = "TELEFONO2_ATLETA";
            this.telefono2.HeaderText = "Teléfono 2";
            this.telefono2.MinimumWidth = 6;
            this.telefono2.Name = "telefono2";
            this.telefono2.Visible = false;
            this.telefono2.Width = 125;
            // 
            // genero
            // 
            this.genero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.genero.DataPropertyName = "GENERO";
            this.genero.Frozen = true;
            this.genero.HeaderText = "Genero";
            this.genero.MinimumWidth = 6;
            this.genero.Name = "genero";
            this.genero.Visible = false;
            this.genero.Width = 125;
            // 
            // provincia
            // 
            this.provincia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.provincia.DataPropertyName = "PROVINCIA_ATLETA";
            this.provincia.HeaderText = "Provincia";
            this.provincia.MinimumWidth = 6;
            this.provincia.Name = "provincia";
            this.provincia.Width = 98;
            // 
            // distrito
            // 
            this.distrito.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.distrito.DataPropertyName = "DISTRITO_ATLETA";
            this.distrito.HeaderText = "Distrito";
            this.distrito.MinimumWidth = 6;
            this.distrito.Name = "distrito";
            this.distrito.Width = 87;
            // 
            // canton
            // 
            this.canton.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.canton.DataPropertyName = "CANTON_ATLETA";
            this.canton.HeaderText = "Cantón";
            this.canton.MinimumWidth = 6;
            this.canton.Name = "canton";
            this.canton.Visible = false;
            this.canton.Width = 125;
            // 
            // fechaNacimiento
            // 
            this.fechaNacimiento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fechaNacimiento.DataPropertyName = "FECHA_NACIMIENTO_ATLETA";
            this.fechaNacimiento.HeaderText = "Fecha de Nacimiento";
            this.fechaNacimiento.MinimumWidth = 6;
            this.fechaNacimiento.Name = "fechaNacimiento";
            // 
            // estado
            // 
            this.estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.estado.DataPropertyName = "ESTADO_ATLETA";
            this.estado.HeaderText = "Estado";
            this.estado.MinimumWidth = 6;
            this.estado.Name = "estado";
            this.estado.Width = 83;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtCod);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(945, 233);
            this.panel1.TabIndex = 29;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel2.Controls.Add(this.CBGenero);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtProvincia);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtID);
            this.panel2.Controls.Add(this.DTFechaNacimie);
            this.panel2.Controls.Add(this.RBInactivo);
            this.panel2.Controls.Add(this.Nacimiento);
            this.panel2.Controls.Add(this.RBActivo);
            this.panel2.Controls.Add(this.txtDistrito);
            this.panel2.Controls.Add(this.txtApellido2);
            this.panel2.Controls.Add(this.txtTelefono1);
            this.panel2.Controls.Add(this.txtApellido1);
            this.panel2.Controls.Add(this.txtTelefono2);
            this.panel2.Controls.Add(this.txtCanton);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtNombre);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtCodAtleta);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(945, 232);
            this.panel2.TabIndex = 24;
            // 
            // CBGenero
            // 
            this.CBGenero.FormattingEnabled = true;
            this.CBGenero.Items.AddRange(new object[] {
            "M",
            "F"});
            this.CBGenero.Location = new System.Drawing.Point(107, 95);
            this.CBGenero.Name = "CBGenero";
            this.CBGenero.Size = new System.Drawing.Size(130, 28);
            this.CBGenero.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(23, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 23);
            this.label8.TabIndex = 30;
            this.label8.Text = "Genero:";
            // 
            // txtProvincia
            // 
            this.txtProvincia.FormattingEnabled = true;
            this.txtProvincia.Items.AddRange(new object[] {
            "Alajuela",
            "San José",
            "Guanacaste",
            "Puntarenas",
            "Heredia",
            "Cartago",
            "Limón"});
            this.txtProvincia.Location = new System.Drawing.Point(101, 167);
            this.txtProvincia.Name = "txtProvincia";
            this.txtProvincia.Size = new System.Drawing.Size(141, 28);
            this.txtProvincia.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(231, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 23);
            this.label7.TabIndex = 29;
            this.label7.Text = "Identificación:";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(353, 27);
            this.txtID.MaxLength = 30;
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(125, 27);
            this.txtID.TabIndex = 1;
            // 
            // DTFechaNacimie
            // 
            this.DTFechaNacimie.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTFechaNacimie.Location = new System.Drawing.Point(589, 172);
            this.DTFechaNacimie.Name = "DTFechaNacimie";
            this.DTFechaNacimie.Size = new System.Drawing.Size(125, 27);
            this.DTFechaNacimie.TabIndex = 13;
            // 
            // RBInactivo
            // 
            this.RBInactivo.AutoSize = true;
            this.RBInactivo.Location = new System.Drawing.Point(816, 193);
            this.RBInactivo.Name = "RBInactivo";
            this.RBInactivo.Size = new System.Drawing.Size(82, 24);
            this.RBInactivo.TabIndex = 15;
            this.RBInactivo.TabStop = true;
            this.RBInactivo.Text = "Inactivo";
            this.RBInactivo.UseVisualStyleBackColor = true;
            // 
            // Nacimiento
            // 
            this.Nacimiento.AutoSize = true;
            this.Nacimiento.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Nacimiento.Location = new System.Drawing.Point(481, 172);
            this.Nacimiento.Name = "Nacimiento";
            this.Nacimiento.Size = new System.Drawing.Size(102, 23);
            this.Nacimiento.TabIndex = 7;
            this.Nacimiento.Text = "Nacimiento:";
            // 
            // RBActivo
            // 
            this.RBActivo.AutoSize = true;
            this.RBActivo.Location = new System.Drawing.Point(816, 147);
            this.RBActivo.Name = "RBActivo";
            this.RBActivo.Size = new System.Drawing.Size(72, 24);
            this.RBActivo.TabIndex = 14;
            this.RBActivo.TabStop = true;
            this.RBActivo.Text = "Activo";
            this.RBActivo.UseVisualStyleBackColor = true;
            // 
            // txtDistrito
            // 
            this.txtDistrito.Location = new System.Drawing.Point(350, 147);
            this.txtDistrito.Name = "txtDistrito";
            this.txtDistrito.Size = new System.Drawing.Size(125, 27);
            this.txtDistrito.TabIndex = 11;
            // 
            // txtApellido2
            // 
            this.txtApellido2.Location = new System.Drawing.Point(808, 88);
            this.txtApellido2.MaxLength = 20;
            this.txtApellido2.Name = "txtApellido2";
            this.txtApellido2.Size = new System.Drawing.Size(125, 27);
            this.txtApellido2.TabIndex = 4;
            // 
            // txtTelefono1
            // 
            this.txtTelefono1.Location = new System.Drawing.Point(581, 88);
            this.txtTelefono1.MaxLength = 15;
            this.txtTelefono1.Name = "txtTelefono1";
            this.txtTelefono1.Size = new System.Drawing.Size(125, 27);
            this.txtTelefono1.TabIndex = 5;
            // 
            // txtApellido1
            // 
            this.txtApellido1.Location = new System.Drawing.Point(808, 27);
            this.txtApellido1.MaxLength = 20;
            this.txtApellido1.Name = "txtApellido1";
            this.txtApellido1.Size = new System.Drawing.Size(125, 27);
            this.txtApellido1.TabIndex = 3;
            // 
            // txtTelefono2
            // 
            this.txtTelefono2.Location = new System.Drawing.Point(353, 92);
            this.txtTelefono2.MaxLength = 15;
            this.txtTelefono2.Name = "txtTelefono2";
            this.txtTelefono2.Size = new System.Drawing.Size(125, 27);
            this.txtTelefono2.TabIndex = 6;
            // 
            // txtCanton
            // 
            this.txtCanton.Location = new System.Drawing.Point(350, 192);
            this.txtCanton.Name = "txtCanton";
            this.txtCanton.Size = new System.Drawing.Size(125, 27);
            this.txtCanton.TabIndex = 12;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(490, 31);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 23);
            this.label13.TabIndex = 13;
            this.label13.Text = "Nombre:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(712, 92);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 23);
            this.label12.TabIndex = 12;
            this.label12.Text = "Apellido 2:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(487, 89);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 23);
            this.label11.TabIndex = 11;
            this.label11.Text = "Teléfono:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(245, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 23);
            this.label10.TabIndex = 10;
            this.label10.Text = "Teléfono 2:";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label.Location = new System.Drawing.Point(11, 167);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(83, 23);
            this.label.TabIndex = 8;
            this.label.Text = "Provincia:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(258, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 23);
            this.label6.TabIndex = 6;
            this.label6.Text = "Cantón:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(259, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 23);
            this.label5.TabIndex = 5;
            this.label5.Text = "Distrito:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(712, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Apellido 1:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(727, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Estado:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(581, 27);
            this.txtNombre.MaxLength = 30;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(125, 27);
            this.txtNombre.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(11, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "COD Atleta:";
            // 
            // txtCodAtleta
            // 
            this.txtCodAtleta.Enabled = false;
            this.txtCodAtleta.Location = new System.Drawing.Point(133, 25);
            this.txtCodAtleta.Name = "txtCodAtleta";
            this.txtCodAtleta.Size = new System.Drawing.Size(92, 27);
            this.txtCodAtleta.TabIndex = 1;
            this.txtCodAtleta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(147, 109);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 27);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(33, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "COD:";
            // 
            // txtCod
            // 
            this.txtCod.Enabled = false;
            this.txtCod.Location = new System.Drawing.Point(113, 21);
            this.txtCod.Name = "txtCod";
            this.txtCod.Size = new System.Drawing.Size(125, 27);
            this.txtCod.TabIndex = 1;
            this.txtCod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FrmAtleta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 578);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.grdListaAtletas);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmAtleta";
            this.Text = "Atletas";
            this.Load += new System.EventHandler(this.FrmAtletas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdListaAtletas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.DataGridView grdListaAtletas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox txtProvincia;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.RadioButton RBInactivo;
        private System.Windows.Forms.RadioButton RBActivo;
        private System.Windows.Forms.DateTimePicker DTFechaNacimie;
        private System.Windows.Forms.TextBox txtDistrito;
        private System.Windows.Forms.TextBox txtApellido2;
        private System.Windows.Forms.TextBox txtTelefono1;
        private System.Windows.Forms.Label Nacimiento;
        private System.Windows.Forms.TextBox txtApellido1;
        private System.Windows.Forms.TextBox txtTelefono2;
        private System.Windows.Forms.TextBox txtCanton;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodAtleta;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCod;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cod_entrenador;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_entrenador;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellido1;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellido2;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefono1;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefono2;
        private System.Windows.Forms.DataGridViewTextBoxColumn genero;
        private System.Windows.Forms.DataGridViewTextBoxColumn provincia;
        private System.Windows.Forms.DataGridViewTextBoxColumn distrito;
        private System.Windows.Forms.DataGridViewTextBoxColumn canton;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaNacimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.ComboBox CBGenero;
        private System.Windows.Forms.Label label8;
    }
}