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
            this.lblrol = new System.Windows.Forms.Label();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.lblrepetir = new System.Windows.Forms.Label();
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
            this.label4 = new System.Windows.Forms.Label();
            this.tbindice = new System.Windows.Forms.TextBox();
            this.pnlBuscador = new System.Windows.Forms.Panel();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.TBBuscar = new TextBoxModerno();
            this.BtnLimpiar = new BotonModerno();
            this.CBFiltro = new Llamen_a_Dios.ComboBoxModerno();
            this.CbEstado = new Llamen_a_Dios.ComboBoxModerno();
            this.CBRol = new Llamen_a_Dios.ComboBoxModerno();
            this.btnBorrar = new BotonModerno();
            this.Btlimpiar = new BotonModerno();
            this.BtnGuardar = new BotonModerno();
            this.tbContraseña = new TextBoxModerno();
            this.tbcorreo = new TextBoxModerno();
            this.tbnombre = new TextBoxModerno();
            this.tvCedula = new TextBoxModerno();
            this.panelModerno1 = new Llamen_a_Dios.PanelModerno();
            this.groupBoxModerno1 = new Llamen_a_Dios.GroupBoxModerno();
            ((System.ComponentModel.ISupportInitialize)(this.DGVUs)).BeginInit();
            this.pnlBuscador.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.panelModerno1.SuspendLayout();
            this.groupBoxModerno1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 1080);
            this.label1.TabIndex = 0;
            // 
            // txtCedul
            // 
            this.txtCedul.AutoSize = true;
            this.txtCedul.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.txtCedul.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txtCedul.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.txtCedul.Location = new System.Drawing.Point(30, 106);
            this.txtCedul.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtCedul.Name = "txtCedul";
            this.txtCedul.Size = new System.Drawing.Size(91, 23);
            this.txtCedul.TabIndex = 1;
            this.txtCedul.Text = "N# Cedula";
            // 
            // lblnombre
            // 
            this.lblnombre.AutoSize = true;
            this.lblnombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.lblnombre.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.lblnombre.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblnombre.Location = new System.Drawing.Point(37, 202);
            this.lblnombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(73, 23);
            this.lblnombre.TabIndex = 2;
            this.lblnombre.Text = "Nombre";
            // 
            // lblcorreo
            // 
            this.lblcorreo.AutoSize = true;
            this.lblcorreo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.lblcorreo.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.lblcorreo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblcorreo.Location = new System.Drawing.Point(37, 290);
            this.lblcorreo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblcorreo.Name = "lblcorreo";
            this.lblcorreo.Size = new System.Drawing.Size(62, 23);
            this.lblcorreo.TabIndex = 3;
            this.lblcorreo.Text = "Correo";
            // 
            // lblrol
            // 
            this.lblrol.AutoSize = true;
            this.lblrol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.lblrol.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.lblrol.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblrol.Location = new System.Drawing.Point(37, 375);
            this.lblrol.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblrol.Name = "lblrol";
            this.lblrol.Size = new System.Drawing.Size(34, 23);
            this.lblrol.TabIndex = 7;
            this.lblrol.Text = "Rol";
            // 
            // lblContraseña
            // 
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.lblContraseña.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.lblContraseña.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblContraseña.Location = new System.Drawing.Point(37, 449);
            this.lblContraseña.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(97, 23);
            this.lblContraseña.TabIndex = 10;
            this.lblContraseña.Text = "Contraseña";
            // 
            // lblrepetir
            // 
            this.lblrepetir.AutoSize = true;
            this.lblrepetir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.lblrepetir.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.lblrepetir.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblrepetir.Location = new System.Drawing.Point(37, 524);
            this.lblrepetir.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblrepetir.Name = "lblrepetir";
            this.lblrepetir.Size = new System.Drawing.Size(61, 23);
            this.lblrepetir.TabIndex = 11;
            this.lblrepetir.Text = "Estado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(49, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 31);
            this.label2.TabIndex = 19;
            this.label2.Text = "Detalles de Usuario";
            // 
            // DGVUs
            // 
            this.DGVUs.AllowUserToAddRows = false;
            this.DGVUs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVUs.BackgroundColor = System.Drawing.Color.White;
            this.DGVUs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVUs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGVUs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVUs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGVUs.ColumnHeadersHeight = 40;
            this.DGVUs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVUs.DefaultCellStyle = dataGridViewCellStyle4;
            this.DGVUs.EnableHeadersVisualStyles = false;
            this.DGVUs.Location = new System.Drawing.Point(0, 150);
            this.DGVUs.Margin = new System.Windows.Forms.Padding(4);
            this.DGVUs.MultiSelect = false;
            this.DGVUs.Name = "DGVUs";
            this.DGVUs.ReadOnly = true;
            this.DGVUs.RowHeadersVisible = false;
            this.DGVUs.RowHeadersWidth = 51;
            this.DGVUs.RowTemplate.Height = 40;
            this.DGVUs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVUs.Size = new System.Drawing.Size(1212, 499);
            this.DGVUs.TabIndex = 20;
            this.DGVUs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVUs_CellContentClick);
            this.DGVUs.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DGVUs_CellPainting);
            // 
            // BtnSelect
            // 
            this.BtnSelect.FillWeight = 20F;
            this.BtnSelect.HeaderText = "";
            this.BtnSelect.MinimumWidth = 6;
            this.BtnSelect.Name = "BtnSelect";
            this.BtnSelect.ReadOnly = true;
            this.BtnSelect.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // IdUsuario
            // 
            this.IdUsuario.HeaderText = "Id";
            this.IdUsuario.MinimumWidth = 6;
            this.IdUsuario.Name = "IdUsuario";
            this.IdUsuario.ReadOnly = true;
            this.IdUsuario.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.IdUsuario.Visible = false;
            // 
            // Cedula
            // 
            this.Cedula.FillWeight = 87.91444F;
            this.Cedula.HeaderText = "Documento";
            this.Cedula.MinimumWidth = 6;
            this.Cedula.Name = "Cedula";
            this.Cedula.ReadOnly = true;
            this.Cedula.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Nombre
            // 
            this.Nombre.FillWeight = 87.91444F;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Correo
            // 
            this.Correo.FillWeight = 87.91444F;
            this.Correo.HeaderText = "Correo";
            this.Correo.MinimumWidth = 6;
            this.Correo.Name = "Correo";
            this.Correo.ReadOnly = true;
            this.Correo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Clave
            // 
            this.Clave.HeaderText = "Clave";
            this.Clave.MinimumWidth = 6;
            this.Clave.Name = "Clave";
            this.Clave.ReadOnly = true;
            this.Clave.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Clave.Visible = false;
            // 
            // idRol
            // 
            this.idRol.HeaderText = "idRol";
            this.idRol.MinimumWidth = 6;
            this.idRol.Name = "idRol";
            this.idRol.ReadOnly = true;
            this.idRol.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.idRol.Visible = false;
            // 
            // DescRol
            // 
            this.DescRol.FillWeight = 87.91444F;
            this.DescRol.HeaderText = "Rol";
            this.DescRol.MinimumWidth = 6;
            this.DescRol.Name = "DescRol";
            this.DescRol.ReadOnly = true;
            this.DescRol.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // EstadoValor
            // 
            this.EstadoValor.HeaderText = "EstadoValor";
            this.EstadoValor.MinimumWidth = 6;
            this.EstadoValor.Name = "EstadoValor";
            this.EstadoValor.ReadOnly = true;
            this.EstadoValor.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.EstadoValor.Visible = false;
            // 
            // EdoValor
            // 
            this.EdoValor.FillWeight = 87.91444F;
            this.EdoValor.HeaderText = "Estado";
            this.EdoValor.MinimumWidth = 6;
            this.EdoValor.Name = "EdoValor";
            this.EdoValor.ReadOnly = true;
            this.EdoValor.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // lbllistausu
            // 
            this.lbllistausu.AutoSize = true;
            this.lbllistausu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(84)))), ((int)(((byte)(147)))));
            this.lbllistausu.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllistausu.ForeColor = System.Drawing.Color.White;
            this.lbllistausu.Location = new System.Drawing.Point(20, 35);
            this.lbllistausu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbllistausu.Name = "lbllistausu";
            this.lbllistausu.Size = new System.Drawing.Size(187, 31);
            this.lbllistausu.TabIndex = 21;
            this.lbllistausu.Text = "Lista de Usuarios";
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(252, 63);
            this.txtid.Margin = new System.Windows.Forms.Padding(4);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(34, 22);
            this.txtid.TabIndex = 22;
            this.txtid.Text = "0";
            this.txtid.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(7, 88);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 28);
            this.label4.TabIndex = 29;
            this.label4.Text = "Buscar por:";
            // 
            // tbindice
            // 
            this.tbindice.Location = new System.Drawing.Point(204, 63);
            this.tbindice.Margin = new System.Windows.Forms.Padding(4);
            this.tbindice.Name = "tbindice";
            this.tbindice.Size = new System.Drawing.Size(34, 22);
            this.tbindice.TabIndex = 32;
            this.tbindice.Text = "-1";
            this.tbindice.Visible = false;
            // 
            // pnlBuscador
            // 
            this.pnlBuscador.Controls.Add(this.iconPictureBox1);
            this.pnlBuscador.Controls.Add(this.TBBuscar);
            this.pnlBuscador.Location = new System.Drawing.Point(416, 80);
            this.pnlBuscador.Name = "pnlBuscador";
            this.pnlBuscador.Size = new System.Drawing.Size(714, 43);
            this.pnlBuscador.TabIndex = 46;
            this.pnlBuscador.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBuscador_Paint);
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.iconPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox1.ForeColor = System.Drawing.Color.LightGray;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.iconPictureBox1.IconColor = System.Drawing.Color.LightGray;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconPictureBox1.IconSize = 36;
            this.iconPictureBox1.Location = new System.Drawing.Point(11, 5);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(40, 36);
            this.iconPictureBox1.TabIndex = 44;
            this.iconPictureBox1.TabStop = false;
            // 
            // TBBuscar
            // 
            this.TBBuscar.BackColor = System.Drawing.Color.White;
            this.TBBuscar.ColorBorde = System.Drawing.Color.Gray;
            this.TBBuscar.ColorBordeFocus = System.Drawing.Color.Gray;
            this.TBBuscar.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.TBBuscar.ForeColor = System.Drawing.Color.DimGray;
            this.TBBuscar.GrosorBorde = 0;
            this.TBBuscar.Location = new System.Drawing.Point(61, 2);
            this.TBBuscar.MaxLength = 32767;
            this.TBBuscar.Name = "TBBuscar";
            this.TBBuscar.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.TBBuscar.PasswordChar = '\0';
            this.TBBuscar.RadioBorde = 5;
            this.TBBuscar.ReadOnly = false;
            this.TBBuscar.Size = new System.Drawing.Size(618, 40);
            this.TBBuscar.TabIndex = 43;
            this.TBBuscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TBBuscar.UseSystemPasswordChar = false;
            this.TBBuscar._TextChanged += new System.EventHandler(this.TBBuscar_TextChanged);
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.ColorBorde = System.Drawing.Color.White;
            this.BtnLimpiar.ColorClick = System.Drawing.Color.AliceBlue;
            this.BtnLimpiar.ColorHover = System.Drawing.Color.Gainsboro;
            this.BtnLimpiar.ColorIconoHover = System.Drawing.Color.Black;
            this.BtnLimpiar.ColorTextoHover = System.Drawing.Color.White;
            this.BtnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLimpiar.FlatAppearance.BorderSize = 0;
            this.BtnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLimpiar.ForeColor = System.Drawing.Color.White;
            this.BtnLimpiar.GrosorBorde = 0;
            this.BtnLimpiar.IconChar = FontAwesome.Sharp.IconChar.Brush;
            this.BtnLimpiar.IconColor = System.Drawing.Color.Black;
            this.BtnLimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnLimpiar.IconSize = 25;
            this.BtnLimpiar.Location = new System.Drawing.Point(1136, 80);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.RadioBorde = 5;
            this.BtnLimpiar.Rotation = 180D;
            this.BtnLimpiar.Size = new System.Drawing.Size(48, 36);
            this.BtnLimpiar.TabIndex = 45;
            this.BtnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnLimpiar.UseVisualStyleBackColor = true;
            this.BtnLimpiar.Click += new System.EventHandler(this.Btlimpiar_Click);
            // 
            // CBFiltro
            // 
            this.CBFiltro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.CBFiltro.BackColorModerno = System.Drawing.Color.WhiteSmoke;
            this.CBFiltro.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.CBFiltro.BorderRadius = 8;
            this.CBFiltro.BorderSize = 1;
            this.CBFiltro.DataSource = null;
            this.CBFiltro.DisplayMember = "";
            this.CBFiltro.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.CBFiltro.ForeColor = System.Drawing.Color.DimGray;
            this.CBFiltro.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(66)))), ((int)(((byte)(210)))));
            this.CBFiltro.Location = new System.Drawing.Point(122, 83);
            this.CBFiltro.MinimumSize = new System.Drawing.Size(150, 30);
            this.CBFiltro.Name = "CBFiltro";
            this.CBFiltro.Padding = new System.Windows.Forms.Padding(1);
            this.CBFiltro.SelectedIndex = -1;
            this.CBFiltro.SelectedItem = null;
            this.CBFiltro.SelectedValue = null;
            this.CBFiltro.Size = new System.Drawing.Size(202, 43);
            this.CBFiltro.TabIndex = 42;
            this.CBFiltro.ValueMember = "";
            // 
            // CbEstado
            // 
            this.CbEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.CbEstado.BackColorModerno = System.Drawing.Color.WhiteSmoke;
            this.CbEstado.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.CbEstado.BorderRadius = 8;
            this.CbEstado.BorderSize = 1;
            this.CbEstado.DataSource = null;
            this.CbEstado.DisplayMember = "";
            this.CbEstado.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.CbEstado.ForeColor = System.Drawing.Color.DimGray;
            this.CbEstado.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(66)))), ((int)(((byte)(210)))));
            this.CbEstado.Location = new System.Drawing.Point(34, 549);
            this.CbEstado.MinimumSize = new System.Drawing.Size(150, 30);
            this.CbEstado.Name = "CbEstado";
            this.CbEstado.Padding = new System.Windows.Forms.Padding(1);
            this.CbEstado.SelectedIndex = -1;
            this.CbEstado.SelectedItem = null;
            this.CbEstado.SelectedValue = null;
            this.CbEstado.Size = new System.Drawing.Size(252, 36);
            this.CbEstado.TabIndex = 41;
            this.CbEstado.ValueMember = "";
            // 
            // CBRol
            // 
            this.CBRol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.CBRol.BackColorModerno = System.Drawing.Color.WhiteSmoke;
            this.CBRol.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.CBRol.BorderRadius = 8;
            this.CBRol.BorderSize = 1;
            this.CBRol.DataSource = null;
            this.CBRol.DisplayMember = "";
            this.CBRol.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.CBRol.ForeColor = System.Drawing.Color.DimGray;
            this.CBRol.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(66)))), ((int)(((byte)(210)))));
            this.CBRol.Location = new System.Drawing.Point(35, 398);
            this.CBRol.MinimumSize = new System.Drawing.Size(150, 30);
            this.CBRol.Name = "CBRol";
            this.CBRol.Padding = new System.Windows.Forms.Padding(1);
            this.CBRol.SelectedIndex = -1;
            this.CBRol.SelectedItem = null;
            this.CBRol.SelectedValue = null;
            this.CBRol.Size = new System.Drawing.Size(252, 36);
            this.CBRol.TabIndex = 40;
            this.CBRol.ValueMember = "";
            // 
            // btnBorrar
            // 
            this.btnBorrar.BackColor = System.Drawing.Color.White;
            this.btnBorrar.ColorBorde = System.Drawing.Color.Firebrick;
            this.btnBorrar.ColorClick = System.Drawing.Color.Red;
            this.btnBorrar.ColorHover = System.Drawing.Color.Firebrick;
            this.btnBorrar.ColorIconoHover = System.Drawing.Color.White;
            this.btnBorrar.ColorTextoHover = System.Drawing.Color.White;
            this.btnBorrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBorrar.FlatAppearance.BorderSize = 0;
            this.btnBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrar.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.btnBorrar.ForeColor = System.Drawing.Color.Firebrick;
            this.btnBorrar.GrosorBorde = 3;
            this.btnBorrar.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.btnBorrar.IconColor = System.Drawing.Color.Firebrick;
            this.btnBorrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBorrar.IconSize = 25;
            this.btnBorrar.Location = new System.Drawing.Point(42, 777);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.RadioBorde = 5;
            this.btnBorrar.Size = new System.Drawing.Size(228, 45);
            this.btnBorrar.TabIndex = 39;
            this.btnBorrar.Text = "Eliminar";
            this.btnBorrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBorrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBorrar.UseVisualStyleBackColor = false;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // Btlimpiar
            // 
            this.Btlimpiar.BackColor = System.Drawing.Color.White;
            this.Btlimpiar.ColorBorde = System.Drawing.Color.RoyalBlue;
            this.Btlimpiar.ColorClick = System.Drawing.Color.CornflowerBlue;
            this.Btlimpiar.ColorHover = System.Drawing.Color.RoyalBlue;
            this.Btlimpiar.ColorIconoHover = System.Drawing.Color.White;
            this.Btlimpiar.ColorTextoHover = System.Drawing.Color.White;
            this.Btlimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btlimpiar.FlatAppearance.BorderSize = 0;
            this.Btlimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btlimpiar.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.Btlimpiar.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Btlimpiar.GrosorBorde = 3;
            this.Btlimpiar.IconChar = FontAwesome.Sharp.IconChar.Redo;
            this.Btlimpiar.IconColor = System.Drawing.Color.RoyalBlue;
            this.Btlimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Btlimpiar.IconSize = 25;
            this.Btlimpiar.Location = new System.Drawing.Point(42, 705);
            this.Btlimpiar.Name = "Btlimpiar";
            this.Btlimpiar.RadioBorde = 5;
            this.Btlimpiar.Size = new System.Drawing.Size(228, 45);
            this.Btlimpiar.TabIndex = 38;
            this.Btlimpiar.Text = "Limpiar";
            this.Btlimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btlimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btlimpiar.UseVisualStyleBackColor = false;
            this.Btlimpiar.Click += new System.EventHandler(this.Btlimpiar_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.BackColor = System.Drawing.Color.Green;
            this.BtnGuardar.ColorBorde = System.Drawing.Color.White;
            this.BtnGuardar.ColorClick = System.Drawing.Color.ForestGreen;
            this.BtnGuardar.ColorHover = System.Drawing.Color.Green;
            this.BtnGuardar.ColorIconoHover = System.Drawing.Color.White;
            this.BtnGuardar.ColorTextoHover = System.Drawing.Color.White;
            this.BtnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGuardar.FlatAppearance.BorderSize = 0;
            this.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardar.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.BtnGuardar.ForeColor = System.Drawing.Color.White;
            this.BtnGuardar.GrosorBorde = 0;
            this.BtnGuardar.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.BtnGuardar.IconColor = System.Drawing.Color.White;
            this.BtnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnGuardar.IconSize = 25;
            this.BtnGuardar.Location = new System.Drawing.Point(41, 629);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.RadioBorde = 5;
            this.BtnGuardar.Size = new System.Drawing.Size(228, 45);
            this.BtnGuardar.TabIndex = 37;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // tbContraseña
            // 
            this.tbContraseña.BackColor = System.Drawing.Color.White;
            this.tbContraseña.ColorBorde = System.Drawing.Color.Gray;
            this.tbContraseña.ColorBordeFocus = System.Drawing.Color.CornflowerBlue;
            this.tbContraseña.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.tbContraseña.ForeColor = System.Drawing.Color.DimGray;
            this.tbContraseña.GrosorBorde = 2;
            this.tbContraseña.Location = new System.Drawing.Point(34, 472);
            this.tbContraseña.MaxLength = 32767;
            this.tbContraseña.Name = "tbContraseña";
            this.tbContraseña.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tbContraseña.PasswordChar = '\0';
            this.tbContraseña.RadioBorde = 5;
            this.tbContraseña.ReadOnly = false;
            this.tbContraseña.Size = new System.Drawing.Size(252, 37);
            this.tbContraseña.TabIndex = 36;
            this.tbContraseña.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbContraseña.UseSystemPasswordChar = false;
            // 
            // tbcorreo
            // 
            this.tbcorreo.BackColor = System.Drawing.Color.White;
            this.tbcorreo.ColorBorde = System.Drawing.Color.Gray;
            this.tbcorreo.ColorBordeFocus = System.Drawing.Color.CornflowerBlue;
            this.tbcorreo.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.tbcorreo.ForeColor = System.Drawing.Color.DimGray;
            this.tbcorreo.GrosorBorde = 2;
            this.tbcorreo.Location = new System.Drawing.Point(34, 319);
            this.tbcorreo.MaxLength = 32767;
            this.tbcorreo.Name = "tbcorreo";
            this.tbcorreo.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tbcorreo.PasswordChar = '\0';
            this.tbcorreo.RadioBorde = 5;
            this.tbcorreo.ReadOnly = false;
            this.tbcorreo.Size = new System.Drawing.Size(252, 37);
            this.tbcorreo.TabIndex = 35;
            this.tbcorreo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbcorreo.UseSystemPasswordChar = false;
            // 
            // tbnombre
            // 
            this.tbnombre.BackColor = System.Drawing.Color.White;
            this.tbnombre.ColorBorde = System.Drawing.Color.Gray;
            this.tbnombre.ColorBordeFocus = System.Drawing.Color.CornflowerBlue;
            this.tbnombre.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.tbnombre.ForeColor = System.Drawing.Color.DimGray;
            this.tbnombre.GrosorBorde = 2;
            this.tbnombre.Location = new System.Drawing.Point(34, 242);
            this.tbnombre.MaxLength = 32767;
            this.tbnombre.Name = "tbnombre";
            this.tbnombre.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tbnombre.PasswordChar = '\0';
            this.tbnombre.RadioBorde = 5;
            this.tbnombre.ReadOnly = false;
            this.tbnombre.Size = new System.Drawing.Size(252, 37);
            this.tbnombre.TabIndex = 34;
            this.tbnombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbnombre.UseSystemPasswordChar = false;
            // 
            // tvCedula
            // 
            this.tvCedula.BackColor = System.Drawing.Color.White;
            this.tvCedula.ColorBorde = System.Drawing.Color.Gray;
            this.tvCedula.ColorBordeFocus = System.Drawing.Color.CornflowerBlue;
            this.tvCedula.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.tvCedula.ForeColor = System.Drawing.Color.DimGray;
            this.tvCedula.GrosorBorde = 2;
            this.tvCedula.Location = new System.Drawing.Point(35, 150);
            this.tvCedula.MaxLength = 32767;
            this.tvCedula.Name = "tvCedula";
            this.tvCedula.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tvCedula.PasswordChar = '\0';
            this.tvCedula.RadioBorde = 5;
            this.tvCedula.ReadOnly = false;
            this.tvCedula.Size = new System.Drawing.Size(252, 37);
            this.tvCedula.TabIndex = 33;
            this.tvCedula.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tvCedula.UseSystemPasswordChar = false;
            // 
            // panelModerno1
            // 
            this.panelModerno1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(84)))), ((int)(((byte)(147)))));
            this.panelModerno1.BorderRadius = 15;
            this.panelModerno1.Controls.Add(this.lbllistausu);
            this.panelModerno1.Location = new System.Drawing.Point(348, 95);
            this.panelModerno1.Name = "panelModerno1";
            this.panelModerno1.RedondearAbajo = false;
            this.panelModerno1.Size = new System.Drawing.Size(1212, 100);
            this.panelModerno1.TabIndex = 81;
            // 
            // groupBoxModerno1
            // 
            this.groupBoxModerno1.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxModerno1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.groupBoxModerno1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.groupBoxModerno1.BorderRadius = 15;
            this.groupBoxModerno1.BorderSize = 2;
            this.groupBoxModerno1.Controls.Add(this.label4);
            this.groupBoxModerno1.Controls.Add(this.DGVUs);
            this.groupBoxModerno1.Controls.Add(this.pnlBuscador);
            this.groupBoxModerno1.Controls.Add(this.CBFiltro);
            this.groupBoxModerno1.Controls.Add(this.BtnLimpiar);
            this.groupBoxModerno1.Location = new System.Drawing.Point(348, 148);
            this.groupBoxModerno1.Name = "groupBoxModerno1";
            this.groupBoxModerno1.RedondearAbajo = true;
            this.groupBoxModerno1.Size = new System.Drawing.Size(1212, 671);
            this.groupBoxModerno1.TabIndex = 82;
            this.groupBoxModerno1.TabStop = false;
            // 
            // FormUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1595, 1080);
            this.Controls.Add(this.panelModerno1);
            this.Controls.Add(this.groupBoxModerno1);
            this.Controls.Add(this.CbEstado);
            this.Controls.Add(this.CBRol);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.Btlimpiar);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.tbContraseña);
            this.Controls.Add(this.tbcorreo);
            this.Controls.Add(this.tbnombre);
            this.Controls.Add(this.tvCedula);
            this.Controls.Add(this.tbindice);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblrepetir);
            this.Controls.Add(this.lblContraseña);
            this.Controls.Add(this.lblrol);
            this.Controls.Add(this.lblcorreo);
            this.Controls.Add(this.lblnombre);
            this.Controls.Add(this.txtCedul);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormUsuarios";
            this.Text = "FormUsuarios";
            this.Load += new System.EventHandler(this.FormUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVUs)).EndInit();
            this.pnlBuscador.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.panelModerno1.ResumeLayout(false);
            this.panelModerno1.PerformLayout();
            this.groupBoxModerno1.ResumeLayout(false);
            this.groupBoxModerno1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtCedul;
        private System.Windows.Forms.Label lblnombre;
        private System.Windows.Forms.Label lblcorreo;
        private System.Windows.Forms.Label lblrol;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.Label lblrepetir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DGVUs;
        private System.Windows.Forms.Label lbllistausu;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbindice;
        private TextBoxModerno tvCedula;
        private TextBoxModerno tbnombre;
        private TextBoxModerno tbcorreo;
        private TextBoxModerno tbContraseña;
        private BotonModerno BtnGuardar;
        private BotonModerno Btlimpiar;
        private BotonModerno btnBorrar;
        private ComboBoxModerno CBRol;
        private ComboBoxModerno CbEstado;
        private ComboBoxModerno CBFiltro;
        private TextBoxModerno TBBuscar;
        private BotonModerno BtnLimpiar;
        private System.Windows.Forms.Panel pnlBuscador;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
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
        private PanelModerno panelModerno1;
        private GroupBoxModerno groupBoxModerno1;
    }
}