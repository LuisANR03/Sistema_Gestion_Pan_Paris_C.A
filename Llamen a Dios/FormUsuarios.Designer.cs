namespace Llamen_a_Dios
{
    partial class FormUsuarios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCedul = new System.Windows.Forms.Label();
            this.lblnombre = new System.Windows.Forms.Label();
            this.lblcorreo = new System.Windows.Forms.Label();
            this.tvCedula = new System.Windows.Forms.TextBox();
            this.tbnombre = new System.Windows.Forms.TextBox();
            this.tbcorreo = new System.Windows.Forms.TextBox();
            this.lblrol = new System.Windows.Forms.Label();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.lblrepetir = new System.Windows.Forms.Label();
            this.tbContraseña = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DGVUs = new System.Windows.Forms.DataGridView();
            this.BtnSelect = new System.Windows.Forms.DataGridViewButtonColumn();
            this.IdUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Correo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idRol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescRol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EdoValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbllistausu = new System.Windows.Forms.Label();
            this.txtid = new System.Windows.Forms.TextBox();
            this.TBBuscar = new System.Windows.Forms.TextBox();
            this.CbEstado = new System.Windows.Forms.ComboBox();
            this.CBRol = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CBFiltro = new System.Windows.Forms.ComboBox();
            this.tbindice = new System.Windows.Forms.TextBox();
            this.BtnLimpiar = new FontAwesome.Sharp.IconButton();
            this.BtnBuscar = new FontAwesome.Sharp.IconButton();
            this.btnBorrar = new FontAwesome.Sharp.IconButton();
            this.Btlimpiar = new FontAwesome.Sharp.IconButton();
            this.BtnGuardar = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.DGVUs)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(82)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 488);
            this.label1.TabIndex = 0;
            // 
            // txtCedul
            // 
            this.txtCedul.AutoSize = true;
            this.txtCedul.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(82)))));
            this.txtCedul.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.txtCedul.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.txtCedul.Location = new System.Drawing.Point(24, 45);
            this.txtCedul.Name = "txtCedul";
            this.txtCedul.Size = new System.Drawing.Size(66, 15);
            this.txtCedul.TabIndex = 1;
            this.txtCedul.Text = "N# Cedula";
            // 
            // lblnombre
            // 
            this.lblnombre.AutoSize = true;
            this.lblnombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(82)))));
            this.lblnombre.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.lblnombre.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblnombre.Location = new System.Drawing.Point(24, 108);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(52, 15);
            this.lblnombre.TabIndex = 2;
            this.lblnombre.Text = "Nombre";
            // 
            // lblcorreo
            // 
            this.lblcorreo.AutoSize = true;
            this.lblcorreo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(82)))));
            this.lblcorreo.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.lblcorreo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblcorreo.Location = new System.Drawing.Point(24, 152);
            this.lblcorreo.Name = "lblcorreo";
            this.lblcorreo.Size = new System.Drawing.Size(44, 15);
            this.lblcorreo.TabIndex = 3;
            this.lblcorreo.Text = "Correo";
            // 
            // tvCedula
            // 
            this.tvCedula.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.tvCedula.Location = new System.Drawing.Point(27, 69);
            this.tvCedula.Name = "tvCedula";
            this.tvCedula.Size = new System.Drawing.Size(189, 23);
            this.tvCedula.TabIndex = 4;
            // 
            // tbnombre
            // 
            this.tbnombre.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.tbnombre.Location = new System.Drawing.Point(27, 126);
            this.tbnombre.Name = "tbnombre";
            this.tbnombre.Size = new System.Drawing.Size(189, 23);
            this.tbnombre.TabIndex = 5;
            // 
            // tbcorreo
            // 
            this.tbcorreo.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.tbcorreo.Location = new System.Drawing.Point(27, 176);
            this.tbcorreo.Name = "tbcorreo";
            this.tbcorreo.Size = new System.Drawing.Size(189, 23);
            this.tbcorreo.TabIndex = 6;
            // 
            // lblrol
            // 
            this.lblrol.AutoSize = true;
            this.lblrol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(82)))));
            this.lblrol.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.lblrol.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblrol.Location = new System.Drawing.Point(24, 213);
            this.lblrol.Name = "lblrol";
            this.lblrol.Size = new System.Drawing.Size(25, 15);
            this.lblrol.TabIndex = 7;
            this.lblrol.Text = "Rol";
            // 
            // lblContraseña
            // 
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(82)))));
            this.lblContraseña.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.lblContraseña.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblContraseña.Location = new System.Drawing.Point(24, 266);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(72, 15);
            this.lblContraseña.TabIndex = 10;
            this.lblContraseña.Text = "Contraseña";
            // 
            // lblrepetir
            // 
            this.lblrepetir.AutoSize = true;
            this.lblrepetir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(82)))));
            this.lblrepetir.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.lblrepetir.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblrepetir.Location = new System.Drawing.Point(24, 317);
            this.lblrepetir.Name = "lblrepetir";
            this.lblrepetir.Size = new System.Drawing.Size(46, 15);
            this.lblrepetir.TabIndex = 11;
            this.lblrepetir.Text = "Estado";
            // 
            // tbContraseña
            // 
            this.tbContraseña.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.tbContraseña.Location = new System.Drawing.Point(27, 291);
            this.tbContraseña.Name = "tbContraseña";
            this.tbContraseña.PasswordChar = '*';
            this.tbContraseña.Size = new System.Drawing.Size(189, 23);
            this.tbContraseña.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(82)))));
            this.label2.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(28, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 25);
            this.label2.TabIndex = 19;
            this.label2.Text = "Detalles de Usuario";
            // 
            // DGVUs
            // 
            this.DGVUs.AllowUserToAddRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVUs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGVUs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVUs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BtnSelect,
            this.IdUsuario,
            this.Cedula,
            this.Nombre,
            this.Correo,
            this.Clave,
            this.idRol,
            this.DescRol,
            this.EstadoValor,
            this.EdoValor});
            this.DGVUs.Location = new System.Drawing.Point(274, 69);
            this.DGVUs.MultiSelect = false;
            this.DGVUs.Name = "DGVUs";
            this.DGVUs.ReadOnly = true;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.DGVUs.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DGVUs.RowTemplate.Height = 28;
            this.DGVUs.Size = new System.Drawing.Size(756, 399);
            this.DGVUs.TabIndex = 20;
            this.DGVUs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVUs_CellContentClick);
            this.DGVUs.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DGVUs_CellPainting);
            // 
            // BtnSelect
            // 
            this.BtnSelect.HeaderText = "";
            this.BtnSelect.Name = "BtnSelect";
            this.BtnSelect.ReadOnly = true;
            this.BtnSelect.Width = 30;
            // 
            // IdUsuario
            // 
            this.IdUsuario.HeaderText = "Id";
            this.IdUsuario.Name = "IdUsuario";
            this.IdUsuario.ReadOnly = true;
            this.IdUsuario.Visible = false;
            // 
            // Cedula
            // 
            this.Cedula.HeaderText = "Nro Cedula";
            this.Cedula.Name = "Cedula";
            this.Cedula.ReadOnly = true;
            this.Cedula.Width = 150;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 180;
            // 
            // Correo
            // 
            this.Correo.HeaderText = "Correo";
            this.Correo.Name = "Correo";
            this.Correo.ReadOnly = true;
            this.Correo.Width = 150;
            // 
            // Clave
            // 
            this.Clave.HeaderText = "Clave";
            this.Clave.Name = "Clave";
            this.Clave.ReadOnly = true;
            this.Clave.Visible = false;
            // 
            // idRol
            // 
            this.idRol.HeaderText = "idRol";
            this.idRol.Name = "idRol";
            this.idRol.ReadOnly = true;
            this.idRol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.idRol.Visible = false;
            // 
            // DescRol
            // 
            this.DescRol.HeaderText = "Rol";
            this.DescRol.Name = "DescRol";
            this.DescRol.ReadOnly = true;
            // 
            // EstadoValor
            // 
            this.EstadoValor.HeaderText = "EstadoValor";
            this.EstadoValor.Name = "EstadoValor";
            this.EstadoValor.ReadOnly = true;
            this.EstadoValor.Visible = false;
            // 
            // EdoValor
            // 
            this.EdoValor.HeaderText = "Estado";
            this.EdoValor.Name = "EdoValor";
            this.EdoValor.ReadOnly = true;
            // 
            // lbllistausu
            // 
            this.lbllistausu.AutoSize = true;
            this.lbllistausu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(144)))), ((int)(((byte)(211)))));
            this.lbllistausu.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllistausu.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbllistausu.Location = new System.Drawing.Point(269, 22);
            this.lbllistausu.Name = "lbllistausu";
            this.lbllistausu.Size = new System.Drawing.Size(173, 25);
            this.lbllistausu.TabIndex = 21;
            this.lbllistausu.Text = "Lista de Usuarios";
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(188, 43);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(28, 20);
            this.txtid.TabIndex = 22;
            this.txtid.Text = "0";
            this.txtid.Visible = false;
            // 
            // TBBuscar
            // 
            this.TBBuscar.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.TBBuscar.Location = new System.Drawing.Point(760, 27);
            this.TBBuscar.Name = "TBBuscar";
            this.TBBuscar.Size = new System.Drawing.Size(160, 23);
            this.TBBuscar.TabIndex = 24;
            this.TBBuscar.TextChanged += new System.EventHandler(this.TBBuscar_TextChanged);
            // 
            // CbEstado
            // 
            this.CbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CbEstado.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbEstado.FormattingEnabled = true;
            this.CbEstado.Location = new System.Drawing.Point(27, 340);
            this.CbEstado.Name = "CbEstado";
            this.CbEstado.Size = new System.Drawing.Size(189, 23);
            this.CbEstado.TabIndex = 26;
            // 
            // CBRol
            // 
            this.CBRol.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.CBRol.FormattingEnabled = true;
            this.CBRol.Location = new System.Drawing.Point(27, 234);
            this.CBRol.Name = "CBRol";
            this.CBRol.Size = new System.Drawing.Size(189, 23);
            this.CBRol.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(144)))), ((int)(((byte)(211)))));
            this.label4.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(543, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 18);
            this.label4.TabIndex = 29;
            this.label4.Text = "Buscar por:";
            // 
            // CBFiltro
            // 
            this.CBFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBFiltro.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBFiltro.FormattingEnabled = true;
            this.CBFiltro.Location = new System.Drawing.Point(632, 28);
            this.CBFiltro.Name = "CBFiltro";
            this.CBFiltro.Size = new System.Drawing.Size(122, 23);
            this.CBFiltro.TabIndex = 31;
            // 
            // tbindice
            // 
            this.tbindice.Location = new System.Drawing.Point(154, 43);
            this.tbindice.Name = "tbindice";
            this.tbindice.Size = new System.Drawing.Size(28, 20);
            this.tbindice.TabIndex = 32;
            this.tbindice.Text = "-1";
            this.tbindice.Visible = false;
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.BackColor = System.Drawing.Color.White;
            this.BtnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLimpiar.Flip = FontAwesome.Sharp.FlipOrientation.Vertical;
            this.BtnLimpiar.IconChar = FontAwesome.Sharp.IconChar.Brush;
            this.BtnLimpiar.IconColor = System.Drawing.Color.Black;
            this.BtnLimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnLimpiar.IconSize = 18;
            this.BtnLimpiar.Location = new System.Drawing.Point(974, 27);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(42, 25);
            this.BtnLimpiar.TabIndex = 30;
            this.BtnLimpiar.UseVisualStyleBackColor = false;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.BackColor = System.Drawing.Color.White;
            this.BtnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBuscar.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.BtnBuscar.IconColor = System.Drawing.Color.Black;
            this.BtnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnBuscar.IconSize = 18;
            this.BtnBuscar.Location = new System.Drawing.Point(926, 27);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(42, 25);
            this.BtnBuscar.TabIndex = 25;
            this.BtnBuscar.UseVisualStyleBackColor = false;
            // 
            // btnBorrar
            // 
            this.btnBorrar.BackColor = System.Drawing.Color.White;
            this.btnBorrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBorrar.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.btnBorrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Firebrick;
            this.btnBorrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.btnBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrar.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.btnBorrar.ForeColor = System.Drawing.Color.Firebrick;
            this.btnBorrar.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.btnBorrar.IconColor = System.Drawing.Color.Firebrick;
            this.btnBorrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBorrar.IconSize = 16;
            this.btnBorrar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBorrar.Location = new System.Drawing.Point(27, 447);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(189, 27);
            this.btnBorrar.TabIndex = 18;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBorrar.UseVisualStyleBackColor = false;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // Btlimpiar
            // 
            this.Btlimpiar.BackColor = System.Drawing.Color.White;
            this.Btlimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btlimpiar.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.Btlimpiar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.Btlimpiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.Btlimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btlimpiar.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.Btlimpiar.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Btlimpiar.IconChar = FontAwesome.Sharp.IconChar.Brush;
            this.Btlimpiar.IconColor = System.Drawing.Color.RoyalBlue;
            this.Btlimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Btlimpiar.IconSize = 18;
            this.Btlimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btlimpiar.Location = new System.Drawing.Point(27, 414);
            this.Btlimpiar.Name = "Btlimpiar";
            this.Btlimpiar.Rotation = 180D;
            this.Btlimpiar.Size = new System.Drawing.Size(189, 27);
            this.Btlimpiar.TabIndex = 17;
            this.Btlimpiar.Text = "Limpiar";
            this.Btlimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btlimpiar.UseVisualStyleBackColor = false;
            this.Btlimpiar.Click += new System.EventHandler(this.Btlimpiar_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.BackColor = System.Drawing.Color.White;
            this.BtnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.ForestGreen;
            this.BtnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.ForestGreen;
            this.BtnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGreen;
            this.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardar.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.ForeColor = System.Drawing.Color.ForestGreen;
            this.BtnGuardar.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.BtnGuardar.IconColor = System.Drawing.Color.ForestGreen;
            this.BtnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnGuardar.IconSize = 16;
            this.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnGuardar.Location = new System.Drawing.Point(27, 381);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(189, 27);
            this.BtnGuardar.TabIndex = 16;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // FormUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(144)))), ((int)(((byte)(211)))));
            this.ClientSize = new System.Drawing.Size(1037, 488);
            this.Controls.Add(this.tbindice);
            this.Controls.Add(this.CBFiltro);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CBRol);
            this.Controls.Add(this.CbEstado);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.TBBuscar);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.lbllistausu);
            this.Controls.Add(this.DGVUs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.Btlimpiar);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.tbContraseña);
            this.Controls.Add(this.lblrepetir);
            this.Controls.Add(this.lblContraseña);
            this.Controls.Add(this.lblrol);
            this.Controls.Add(this.tbcorreo);
            this.Controls.Add(this.tbnombre);
            this.Controls.Add(this.tvCedula);
            this.Controls.Add(this.lblcorreo);
            this.Controls.Add(this.lblnombre);
            this.Controls.Add(this.txtCedul);
            this.Controls.Add(this.label1);
            this.Name = "FormUsuarios";
            this.Text = "FormUsuarios";
            this.Load += new System.EventHandler(this.FormUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVUs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtCedul;
        private System.Windows.Forms.Label lblnombre;
        private System.Windows.Forms.Label lblcorreo;
        private System.Windows.Forms.TextBox tvCedula;
        private System.Windows.Forms.TextBox tbnombre;
        private System.Windows.Forms.TextBox tbcorreo;
        private System.Windows.Forms.Label lblrol;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.Label lblrepetir;
        private System.Windows.Forms.TextBox tbContraseña;
        private FontAwesome.Sharp.IconButton BtnGuardar;
        private FontAwesome.Sharp.IconButton Btlimpiar;
        private FontAwesome.Sharp.IconButton btnBorrar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DGVUs;
        private System.Windows.Forms.Label lbllistausu;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.TextBox TBBuscar;
        private FontAwesome.Sharp.IconButton BtnBuscar;
        private System.Windows.Forms.ComboBox CbEstado;
        private System.Windows.Forms.ComboBox CBRol;
        private System.Windows.Forms.Label label4;
        private FontAwesome.Sharp.IconButton BtnLimpiar;
        private System.Windows.Forms.ComboBox CBFiltro;
        private System.Windows.Forms.DataGridViewButtonColumn BtnSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Correo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clave;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescRol;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn EdoValor;
        private System.Windows.Forms.TextBox tbindice;
    }
}