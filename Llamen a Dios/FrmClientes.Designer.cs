namespace Llamen_a_Dios
{
    partial class FrmClientes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbid = new System.Windows.Forms.TextBox();
            this.lbllistausu = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblnombre = new System.Windows.Forms.Label();
            this.txtCedul = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Telefono = new System.Windows.Forms.Label();
            this.DGVUs = new System.Windows.Forms.DataGridView();
            this.BtnSelect = new System.Windows.Forms.DataGridViewButtonColumn();
            this.IdCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Correo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tlf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbindice = new System.Windows.Forms.TextBox();
            this.pnlBuscador = new System.Windows.Forms.Panel();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.TBBuscar = new TextBoxModerno();
            this.BtnLimpiar = new BotonModerno();
            this.CBFiltro = new Llamen_a_Dios.ComboBoxModerno();
            this.label6 = new System.Windows.Forms.Label();
            this.CBestado = new Llamen_a_Dios.ComboBoxModerno();
            this.btnBorrar = new BotonModerno();
            this.BtnLim = new BotonModerno();
            this.BtnGuardar = new BotonModerno();
            this.tbdir = new TextBoxModerno();
            this.tbtlf = new TextBoxModerno();
            this.tbcorreo = new TextBoxModerno();
            this.tbCedula = new TextBoxModerno();
            this.lblrepetir = new System.Windows.Forms.Label();
            this.tbnombre = new TextBoxModerno();
            ((System.ComponentModel.ISupportInitialize)(this.DGVUs)).BeginInit();
            this.pnlBuscador.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbid
            // 
            this.tbid.Location = new System.Drawing.Point(241, 68);
            this.tbid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbid.Name = "tbid";
            this.tbid.Size = new System.Drawing.Size(34, 22);
            this.tbid.TabIndex = 45;
            this.tbid.Text = "0";
            this.tbid.Visible = false;
            // 
            // lbllistausu
            // 
            this.lbllistausu.AutoSize = true;
            this.lbllistausu.BackColor = System.Drawing.Color.DarkBlue;
            this.lbllistausu.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllistausu.ForeColor = System.Drawing.Color.White;
            this.lbllistausu.Location = new System.Drawing.Point(390, 33);
            this.lbllistausu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbllistausu.Name = "lbllistausu";
            this.lbllistausu.Size = new System.Drawing.Size(180, 31);
            this.lbllistausu.TabIndex = 44;
            this.lbllistausu.Text = "Lista de Clientes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DarkBlue;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(52, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 31);
            this.label2.TabIndex = 42;
            this.label2.Text = "Detalles de Clientes";
            // 
            // lblnombre
            // 
            this.lblnombre.AutoSize = true;
            this.lblnombre.BackColor = System.Drawing.Color.DarkBlue;
            this.lblnombre.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnombre.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblnombre.Location = new System.Drawing.Point(41, 207);
            this.lblnombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(73, 23);
            this.lblnombre.TabIndex = 28;
            this.lblnombre.Text = "Nombre";
            // 
            // txtCedul
            // 
            this.txtCedul.AutoSize = true;
            this.txtCedul.BackColor = System.Drawing.Color.DarkBlue;
            this.txtCedul.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCedul.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.txtCedul.Location = new System.Drawing.Point(43, 112);
            this.txtCedul.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtCedul.Name = "txtCedul";
            this.txtCedul.Size = new System.Drawing.Size(91, 23);
            this.txtCedul.TabIndex = 27;
            this.txtCedul.Text = "N# Cedula";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkBlue;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 1080);
            this.label1.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.DarkBlue;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(41, 307);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 23);
            this.label4.TabIndex = 52;
            this.label4.Text = "Correo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.DarkBlue;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(37, 403);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 23);
            this.label5.TabIndex = 54;
            this.label5.Text = "Telefono";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(391, 157);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 28);
            this.label3.TabIndex = 57;
            this.label3.Text = "Buscar por:";
            // 
            // Telefono
            // 
            this.Telefono.AutoSize = true;
            this.Telefono.BackColor = System.Drawing.Color.DarkBlue;
            this.Telefono.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Telefono.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Telefono.Location = new System.Drawing.Point(39, 502);
            this.Telefono.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Telefono.Name = "Telefono";
            this.Telefono.Size = new System.Drawing.Size(81, 23);
            this.Telefono.TabIndex = 61;
            this.Telefono.Text = "Direccion";
            // 
            // DGVUs
            // 
            this.DGVUs.AllowUserToAddRows = false;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVUs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.DGVUs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVUs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BtnSelect,
            this.IdCliente,
            this.Cedula,
            this.Nombre,
            this.Correo,
            this.Tlf,
            this.Direccion,
            this.Valor,
            this.EstadoValor});
            this.DGVUs.Location = new System.Drawing.Point(396, 225);
            this.DGVUs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DGVUs.MultiSelect = false;
            this.DGVUs.Name = "DGVUs";
            this.DGVUs.ReadOnly = true;
            this.DGVUs.RowHeadersWidth = 51;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            this.DGVUs.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.DGVUs.RowTemplate.Height = 28;
            this.DGVUs.Size = new System.Drawing.Size(1117, 499);
            this.DGVUs.TabIndex = 62;
            this.DGVUs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVUs_CellContentClick);
            this.DGVUs.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DGVUs_CellPainting);
            // 
            // BtnSelect
            // 
            this.BtnSelect.HeaderText = "";
            this.BtnSelect.MinimumWidth = 6;
            this.BtnSelect.Name = "BtnSelect";
            this.BtnSelect.ReadOnly = true;
            this.BtnSelect.Width = 30;
            // 
            // IdCliente
            // 
            this.IdCliente.HeaderText = "Id";
            this.IdCliente.MinimumWidth = 6;
            this.IdCliente.Name = "IdCliente";
            this.IdCliente.ReadOnly = true;
            this.IdCliente.Visible = false;
            this.IdCliente.Width = 125;
            // 
            // Cedula
            // 
            this.Cedula.HeaderText = "Cedula";
            this.Cedula.MinimumWidth = 6;
            this.Cedula.Name = "Cedula";
            this.Cedula.ReadOnly = true;
            this.Cedula.Width = 125;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 125;
            // 
            // Correo
            // 
            this.Correo.HeaderText = "Correo";
            this.Correo.MinimumWidth = 6;
            this.Correo.Name = "Correo";
            this.Correo.ReadOnly = true;
            this.Correo.Width = 125;
            // 
            // Tlf
            // 
            this.Tlf.HeaderText = "Telefono";
            this.Tlf.MinimumWidth = 6;
            this.Tlf.Name = "Tlf";
            this.Tlf.ReadOnly = true;
            this.Tlf.Width = 150;
            // 
            // Direccion
            // 
            this.Direccion.HeaderText = "Direccion";
            this.Direccion.MinimumWidth = 6;
            this.Direccion.Name = "Direccion";
            this.Direccion.ReadOnly = true;
            this.Direccion.Width = 150;
            // 
            // Valor
            // 
            this.Valor.HeaderText = "Estado";
            this.Valor.MinimumWidth = 6;
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            this.Valor.Visible = false;
            this.Valor.Width = 125;
            // 
            // EstadoValor
            // 
            this.EstadoValor.HeaderText = "EstadoValor";
            this.EstadoValor.MinimumWidth = 6;
            this.EstadoValor.Name = "EstadoValor";
            this.EstadoValor.ReadOnly = true;
            this.EstadoValor.Visible = false;
            this.EstadoValor.Width = 125;
            // 
            // tbindice
            // 
            this.tbindice.Location = new System.Drawing.Point(199, 68);
            this.tbindice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbindice.Name = "tbindice";
            this.tbindice.Size = new System.Drawing.Size(34, 22);
            this.tbindice.TabIndex = 63;
            this.tbindice.Text = "-1";
            this.tbindice.Visible = false;
            // 
            // pnlBuscador
            // 
            this.pnlBuscador.Controls.Add(this.iconPictureBox1);
            this.pnlBuscador.Controls.Add(this.TBBuscar);
            this.pnlBuscador.Location = new System.Drawing.Point(734, 151);
            this.pnlBuscador.Name = "pnlBuscador";
            this.pnlBuscador.Size = new System.Drawing.Size(714, 43);
            this.pnlBuscador.TabIndex = 67;
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
            this.TBBuscar.Size = new System.Drawing.Size(650, 40);
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
            this.BtnLimpiar.Location = new System.Drawing.Point(1464, 151);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.RadioBorde = 5;
            this.BtnLimpiar.Rotation = 180D;
            this.BtnLimpiar.Size = new System.Drawing.Size(48, 36);
            this.BtnLimpiar.TabIndex = 66;
            this.BtnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnLimpiar.UseVisualStyleBackColor = true;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
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
            this.CBFiltro.Location = new System.Drawing.Point(507, 153);
            this.CBFiltro.MinimumSize = new System.Drawing.Size(150, 30);
            this.CBFiltro.Name = "CBFiltro";
            this.CBFiltro.Padding = new System.Windows.Forms.Padding(1);
            this.CBFiltro.SelectedIndex = -1;
            this.CBFiltro.SelectedItem = null;
            this.CBFiltro.Size = new System.Drawing.Size(202, 43);
            this.CBFiltro.TabIndex = 65;
            this.CBFiltro.ValueMember = "";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.DarkBlue;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(318, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(1278, 85);
            this.label6.TabIndex = 68;
            // 
            // CBestado
            // 
            this.CBestado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.CBestado.BackColorModerno = System.Drawing.Color.WhiteSmoke;
            this.CBestado.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.CBestado.BorderRadius = 8;
            this.CBestado.BorderSize = 1;
            this.CBestado.DataSource = null;
            this.CBestado.DisplayMember = "";
            this.CBestado.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.CBestado.ForeColor = System.Drawing.Color.DimGray;
            this.CBestado.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(66)))), ((int)(((byte)(210)))));
            this.CBestado.Location = new System.Drawing.Point(38, 630);
            this.CBestado.MinimumSize = new System.Drawing.Size(150, 30);
            this.CBestado.Name = "CBestado";
            this.CBestado.Padding = new System.Windows.Forms.Padding(1);
            this.CBestado.SelectedIndex = -1;
            this.CBestado.SelectedItem = null;
            this.CBestado.Size = new System.Drawing.Size(252, 36);
            this.CBestado.TabIndex = 78;
            this.CBestado.ValueMember = "";
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
            this.btnBorrar.Location = new System.Drawing.Point(47, 859);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.RadioBorde = 5;
            this.btnBorrar.Size = new System.Drawing.Size(228, 45);
            this.btnBorrar.TabIndex = 76;
            this.btnBorrar.Text = "Eliminar";
            this.btnBorrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBorrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBorrar.UseVisualStyleBackColor = false;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // BtnLim
            // 
            this.BtnLim.BackColor = System.Drawing.Color.White;
            this.BtnLim.ColorBorde = System.Drawing.Color.RoyalBlue;
            this.BtnLim.ColorClick = System.Drawing.Color.CornflowerBlue;
            this.BtnLim.ColorHover = System.Drawing.Color.RoyalBlue;
            this.BtnLim.ColorIconoHover = System.Drawing.Color.White;
            this.BtnLim.ColorTextoHover = System.Drawing.Color.White;
            this.BtnLim.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLim.FlatAppearance.BorderSize = 0;
            this.BtnLim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLim.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.BtnLim.ForeColor = System.Drawing.Color.RoyalBlue;
            this.BtnLim.GrosorBorde = 3;
            this.BtnLim.IconChar = FontAwesome.Sharp.IconChar.Redo;
            this.BtnLim.IconColor = System.Drawing.Color.RoyalBlue;
            this.BtnLim.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnLim.IconSize = 25;
            this.BtnLim.Location = new System.Drawing.Point(47, 790);
            this.BtnLim.Name = "BtnLim";
            this.BtnLim.RadioBorde = 5;
            this.BtnLim.Size = new System.Drawing.Size(228, 45);
            this.BtnLim.TabIndex = 75;
            this.BtnLim.Text = "Limpiar";
            this.BtnLim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnLim.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnLim.UseVisualStyleBackColor = false;
            this.BtnLim.Click += new System.EventHandler(this.BtnLim_Click);
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
            this.BtnGuardar.Location = new System.Drawing.Point(46, 714);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.RadioBorde = 5;
            this.BtnGuardar.Size = new System.Drawing.Size(228, 45);
            this.BtnGuardar.TabIndex = 74;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // tbdir
            // 
            this.tbdir.BackColor = System.Drawing.Color.White;
            this.tbdir.ColorBorde = System.Drawing.Color.Gray;
            this.tbdir.ColorBordeFocus = System.Drawing.Color.CornflowerBlue;
            this.tbdir.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.tbdir.ForeColor = System.Drawing.Color.DimGray;
            this.tbdir.GrosorBorde = 2;
            this.tbdir.Location = new System.Drawing.Point(38, 546);
            this.tbdir.MaxLength = 32767;
            this.tbdir.Name = "tbdir";
            this.tbdir.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tbdir.PasswordChar = '\0';
            this.tbdir.RadioBorde = 5;
            this.tbdir.ReadOnly = false;
            this.tbdir.Size = new System.Drawing.Size(252, 37);
            this.tbdir.TabIndex = 73;
            this.tbdir.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbdir.UseSystemPasswordChar = false;
            // 
            // tbtlf
            // 
            this.tbtlf.BackColor = System.Drawing.Color.White;
            this.tbtlf.ColorBorde = System.Drawing.Color.Gray;
            this.tbtlf.ColorBordeFocus = System.Drawing.Color.CornflowerBlue;
            this.tbtlf.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.tbtlf.ForeColor = System.Drawing.Color.DimGray;
            this.tbtlf.GrosorBorde = 2;
            this.tbtlf.Location = new System.Drawing.Point(38, 445);
            this.tbtlf.MaxLength = 32767;
            this.tbtlf.Name = "tbtlf";
            this.tbtlf.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tbtlf.PasswordChar = '\0';
            this.tbtlf.RadioBorde = 5;
            this.tbtlf.ReadOnly = false;
            this.tbtlf.Size = new System.Drawing.Size(252, 37);
            this.tbtlf.TabIndex = 72;
            this.tbtlf.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbtlf.UseSystemPasswordChar = false;
            // 
            // tbcorreo
            // 
            this.tbcorreo.BackColor = System.Drawing.Color.White;
            this.tbcorreo.ColorBorde = System.Drawing.Color.Gray;
            this.tbcorreo.ColorBordeFocus = System.Drawing.Color.CornflowerBlue;
            this.tbcorreo.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.tbcorreo.ForeColor = System.Drawing.Color.DimGray;
            this.tbcorreo.GrosorBorde = 2;
            this.tbcorreo.Location = new System.Drawing.Point(38, 347);
            this.tbcorreo.MaxLength = 32767;
            this.tbcorreo.Name = "tbcorreo";
            this.tbcorreo.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tbcorreo.PasswordChar = '\0';
            this.tbcorreo.RadioBorde = 5;
            this.tbcorreo.ReadOnly = false;
            this.tbcorreo.Size = new System.Drawing.Size(252, 37);
            this.tbcorreo.TabIndex = 71;
            this.tbcorreo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbcorreo.UseSystemPasswordChar = false;
            // 
            // tbCedula
            // 
            this.tbCedula.BackColor = System.Drawing.Color.White;
            this.tbCedula.ColorBorde = System.Drawing.Color.Gray;
            this.tbCedula.ColorBordeFocus = System.Drawing.Color.CornflowerBlue;
            this.tbCedula.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.tbCedula.ForeColor = System.Drawing.Color.DimGray;
            this.tbCedula.GrosorBorde = 2;
            this.tbCedula.Location = new System.Drawing.Point(38, 153);
            this.tbCedula.MaxLength = 32767;
            this.tbCedula.Name = "tbCedula";
            this.tbCedula.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tbCedula.PasswordChar = '\0';
            this.tbCedula.RadioBorde = 5;
            this.tbCedula.ReadOnly = false;
            this.tbCedula.Size = new System.Drawing.Size(252, 37);
            this.tbCedula.TabIndex = 70;
            this.tbCedula.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbCedula.UseSystemPasswordChar = false;
            // 
            // lblrepetir
            // 
            this.lblrepetir.AutoSize = true;
            this.lblrepetir.BackColor = System.Drawing.Color.DarkBlue;
            this.lblrepetir.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.lblrepetir.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblrepetir.Location = new System.Drawing.Point(42, 595);
            this.lblrepetir.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblrepetir.Name = "lblrepetir";
            this.lblrepetir.Size = new System.Drawing.Size(61, 23);
            this.lblrepetir.TabIndex = 69;
            this.lblrepetir.Text = "Estado";
            // 
            // tbnombre
            // 
            this.tbnombre.BackColor = System.Drawing.Color.White;
            this.tbnombre.ColorBorde = System.Drawing.Color.Gray;
            this.tbnombre.ColorBordeFocus = System.Drawing.Color.CornflowerBlue;
            this.tbnombre.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.tbnombre.ForeColor = System.Drawing.Color.DimGray;
            this.tbnombre.GrosorBorde = 2;
            this.tbnombre.Location = new System.Drawing.Point(38, 247);
            this.tbnombre.MaxLength = 32767;
            this.tbnombre.Name = "tbnombre";
            this.tbnombre.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tbnombre.PasswordChar = '\0';
            this.tbnombre.RadioBorde = 5;
            this.tbnombre.ReadOnly = false;
            this.tbnombre.Size = new System.Drawing.Size(252, 37);
            this.tbnombre.TabIndex = 79;
            this.tbnombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbnombre.UseSystemPasswordChar = false;
            // 
            // FrmClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1595, 1080);
            this.Controls.Add(this.tbnombre);
            this.Controls.Add(this.CBestado);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.BtnLim);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.tbdir);
            this.Controls.Add(this.tbtlf);
            this.Controls.Add(this.tbcorreo);
            this.Controls.Add(this.tbCedula);
            this.Controls.Add(this.lblrepetir);
            this.Controls.Add(this.lbllistausu);
            this.Controls.Add(this.pnlBuscador);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.CBFiltro);
            this.Controls.Add(this.tbindice);
            this.Controls.Add(this.DGVUs);
            this.Controls.Add(this.Telefono);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblnombre);
            this.Controls.Add(this.txtCedul);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmClientes";
            this.Text = "FrmClientes";
            this.Load += new System.EventHandler(this.FrmClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVUs)).EndInit();
            this.pnlBuscador.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbid;
        private System.Windows.Forms.Label lbllistausu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblnombre;
        private System.Windows.Forms.Label txtCedul;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Telefono;
        private System.Windows.Forms.DataGridView DGVUs;
        private System.Windows.Forms.TextBox tbindice;
        private System.Windows.Forms.DataGridViewButtonColumn BtnSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Correo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tlf;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoValor;
        private System.Windows.Forms.Panel pnlBuscador;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private TextBoxModerno TBBuscar;
        private BotonModerno BtnLimpiar;
        private ComboBoxModerno CBFiltro;
        private System.Windows.Forms.Label label6;
        private ComboBoxModerno CBestado;
        private BotonModerno btnBorrar;
        private BotonModerno BtnLim;
        private BotonModerno BtnGuardar;
        private TextBoxModerno tbdir;
        private TextBoxModerno tbtlf;
        private TextBoxModerno tbcorreo;
        private TextBoxModerno tbCedula;
        private System.Windows.Forms.Label lblrepetir;
        private TextBoxModerno tbnombre;
    }
}