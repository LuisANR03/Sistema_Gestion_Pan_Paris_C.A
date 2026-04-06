namespace Llamen_a_Dios
{
    partial class FrmStock
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
            this.lbllistausu = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DGVStck = new System.Windows.Forms.DataGridView();
            this.BtnSelect = new System.Windows.Forms.DataGridViewButtonColumn();
            this.IdProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Promocion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbindice = new System.Windows.Forms.TextBox();
            this.txtid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblrepetir = new System.Windows.Forms.Label();
            this.lblcat = new System.Windows.Forms.Label();
            this.lblrol = new System.Windows.Forms.Label();
            this.lbldsc = new System.Windows.Forms.Label();
            this.lblnombre = new System.Windows.Forms.Label();
            this.lblcodigo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlBuscador = new System.Windows.Forms.Panel();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.TBBuscar = new TextBoxModerno();
            this.BtnLimpiar = new BotonModerno();
            this.CBFiltro = new Llamen_a_Dios.ComboBoxModerno();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbnombre = new TextBoxModerno();
            this.CBEstado = new Llamen_a_Dios.ComboBoxModerno();
            this.btnBorrar = new BotonModerno();
            this.Btlimc = new BotonModerno();
            this.BtnGuardar = new BotonModerno();
            this.tbPrecio = new TextBoxModerno();
            this.TBStock = new TextBoxModerno();
            this.tbdesc = new TextBoxModerno();
            this.TBCodigo = new TextBoxModerno();
            this.CBCategoria = new Llamen_a_Dios.ComboBoxModerno();
            this.tbPrecioPromocion = new TextBoxModerno();
            ((System.ComponentModel.ISupportInitialize)(this.DGVStck)).BeginInit();
            this.pnlBuscador.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbllistausu
            // 
            this.lbllistausu.AutoSize = true;
            this.lbllistausu.BackColor = System.Drawing.Color.DarkBlue;
            this.lbllistausu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllistausu.ForeColor = System.Drawing.Color.White;
            this.lbllistausu.Location = new System.Drawing.Point(378, 35);
            this.lbllistausu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbllistausu.Name = "lbllistausu";
            this.lbllistausu.Size = new System.Drawing.Size(109, 28);
            this.lbllistausu.TabIndex = 42;
            this.lbllistausu.Text = "Inventario";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 1080);
            this.label1.TabIndex = 26;
            // 
            // DGVStck
            // 
            this.DGVStck.AllowUserToAddRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVStck.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGVStck.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVStck.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BtnSelect,
            this.IdProducto,
            this.Codigo,
            this.Nombre,
            this.Descripcion,
            this.IdCategoria,
            this.Categoria,
            this.Stock,
            this.Precio,
            this.Promocion,
            this.Valor,
            this.dataGridViewTextBoxColumn2,
            this.Fecha});
            this.DGVStck.Location = new System.Drawing.Point(383, 191);
            this.DGVStck.Margin = new System.Windows.Forms.Padding(4);
            this.DGVStck.MultiSelect = false;
            this.DGVStck.Name = "DGVStck";
            this.DGVStck.ReadOnly = true;
            this.DGVStck.RowHeadersWidth = 51;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.DGVStck.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DGVStck.RowTemplate.Height = 28;
            this.DGVStck.Size = new System.Drawing.Size(1116, 836);
            this.DGVStck.TabIndex = 48;
            this.DGVStck.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVStck_CellContentClick);
            this.DGVStck.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DGVStck_CellPainting);
            // 
            // BtnSelect
            // 
            this.BtnSelect.HeaderText = "";
            this.BtnSelect.MinimumWidth = 6;
            this.BtnSelect.Name = "BtnSelect";
            this.BtnSelect.ReadOnly = true;
            this.BtnSelect.Width = 30;
            // 
            // IdProducto
            // 
            this.IdProducto.HeaderText = "Id";
            this.IdProducto.MinimumWidth = 6;
            this.IdProducto.Name = "IdProducto";
            this.IdProducto.ReadOnly = true;
            this.IdProducto.Visible = false;
            this.IdProducto.Width = 125;
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.MinimumWidth = 6;
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 125;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 125;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.MinimumWidth = 6;
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 125;
            // 
            // IdCategoria
            // 
            this.IdCategoria.HeaderText = "IdCategoria";
            this.IdCategoria.MinimumWidth = 6;
            this.IdCategoria.Name = "IdCategoria";
            this.IdCategoria.ReadOnly = true;
            this.IdCategoria.Visible = false;
            this.IdCategoria.Width = 125;
            // 
            // Categoria
            // 
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.MinimumWidth = 6;
            this.Categoria.Name = "Categoria";
            this.Categoria.ReadOnly = true;
            this.Categoria.Width = 125;
            // 
            // Stock
            // 
            this.Stock.HeaderText = "Stock";
            this.Stock.MinimumWidth = 6;
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            this.Stock.Width = 125;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.MinimumWidth = 6;
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            this.Precio.Width = 125;
            // 
            // Promocion
            // 
            this.Promocion.HeaderText = "Promocion";
            this.Promocion.MinimumWidth = 6;
            this.Promocion.Name = "Promocion";
            this.Promocion.ReadOnly = true;
            this.Promocion.Width = 125;
            // 
            // Valor
            // 
            this.Valor.HeaderText = "Valor";
            this.Valor.MinimumWidth = 6;
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            this.Valor.Visible = false;
            this.Valor.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "EstadoValor";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.MinimumWidth = 6;
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Visible = false;
            this.Fecha.Width = 125;
            // 
            // tbindice
            // 
            this.tbindice.Location = new System.Drawing.Point(186, 51);
            this.tbindice.Margin = new System.Windows.Forms.Padding(4);
            this.tbindice.Name = "tbindice";
            this.tbindice.Size = new System.Drawing.Size(34, 22);
            this.tbindice.TabIndex = 66;
            this.tbindice.Text = "-1";
            this.tbindice.Visible = false;
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(229, 51);
            this.txtid.Margin = new System.Windows.Forms.Padding(4);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(34, 22);
            this.txtid.TabIndex = 63;
            this.txtid.Text = "0";
            this.txtid.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DarkBlue;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(42, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 31);
            this.label2.TabIndex = 62;
            this.label2.Text = "Detalles de Stock";
            // 
            // lblrepetir
            // 
            this.lblrepetir.AutoSize = true;
            this.lblrepetir.BackColor = System.Drawing.Color.DarkBlue;
            this.lblrepetir.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrepetir.ForeColor = System.Drawing.Color.White;
            this.lblrepetir.Location = new System.Drawing.Point(21, 523);
            this.lblrepetir.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblrepetir.Name = "lblrepetir";
            this.lblrepetir.Size = new System.Drawing.Size(60, 25);
            this.lblrepetir.TabIndex = 57;
            this.lblrepetir.Text = "Precio";
            // 
            // lblcat
            // 
            this.lblcat.AutoSize = true;
            this.lblcat.BackColor = System.Drawing.Color.DarkBlue;
            this.lblcat.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcat.ForeColor = System.Drawing.Color.White;
            this.lblcat.Location = new System.Drawing.Point(26, 629);
            this.lblcat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblcat.Name = "lblcat";
            this.lblcat.Size = new System.Drawing.Size(88, 25);
            this.lblcat.TabIndex = 56;
            this.lblcat.Text = "Categoria";
            // 
            // lblrol
            // 
            this.lblrol.AutoSize = true;
            this.lblrol.BackColor = System.Drawing.Color.DarkBlue;
            this.lblrol.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrol.ForeColor = System.Drawing.Color.White;
            this.lblrol.Location = new System.Drawing.Point(25, 413);
            this.lblrol.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblrol.Name = "lblrol";
            this.lblrol.Size = new System.Drawing.Size(55, 25);
            this.lblrol.TabIndex = 55;
            this.lblrol.Text = "Stock";
            // 
            // lbldsc
            // 
            this.lbldsc.AutoSize = true;
            this.lbldsc.BackColor = System.Drawing.Color.DarkBlue;
            this.lbldsc.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldsc.ForeColor = System.Drawing.Color.White;
            this.lbldsc.Location = new System.Drawing.Point(19, 312);
            this.lbldsc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbldsc.Name = "lbldsc";
            this.lbldsc.Size = new System.Drawing.Size(104, 25);
            this.lbldsc.TabIndex = 51;
            this.lbldsc.Text = "Descripcion";
            // 
            // lblnombre
            // 
            this.lblnombre.AutoSize = true;
            this.lblnombre.BackColor = System.Drawing.Color.DarkBlue;
            this.lblnombre.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnombre.ForeColor = System.Drawing.Color.White;
            this.lblnombre.Location = new System.Drawing.Point(17, 216);
            this.lblnombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(78, 25);
            this.lblnombre.TabIndex = 50;
            this.lblnombre.Text = "Nombre";
            // 
            // lblcodigo
            // 
            this.lblcodigo.AutoSize = true;
            this.lblcodigo.BackColor = System.Drawing.Color.DarkBlue;
            this.lblcodigo.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcodigo.ForeColor = System.Drawing.Color.White;
            this.lblcodigo.Location = new System.Drawing.Point(21, 115);
            this.lblcodigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblcodigo.Name = "lblcodigo";
            this.lblcodigo.Size = new System.Drawing.Size(121, 25);
            this.lblcodigo.TabIndex = 49;
            this.lblcodigo.Text = "N# Referencia";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.DarkBlue;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(29, 721);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 25);
            this.label4.TabIndex = 68;
            this.label4.Text = "Estado";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.DarkBlue;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(146, 523);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 25);
            this.label5.TabIndex = 70;
            this.label5.Text = "Precio Promo";
            // 
            // pnlBuscador
            // 
            this.pnlBuscador.Controls.Add(this.iconPictureBox1);
            this.pnlBuscador.Controls.Add(this.TBBuscar);
            this.pnlBuscador.Location = new System.Drawing.Point(727, 128);
            this.pnlBuscador.Name = "pnlBuscador";
            this.pnlBuscador.Size = new System.Drawing.Size(714, 43);
            this.pnlBuscador.TabIndex = 79;
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
            this.BtnLimpiar.Location = new System.Drawing.Point(1450, 128);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.RadioBorde = 5;
            this.BtnLimpiar.Rotation = 180D;
            this.BtnLimpiar.Size = new System.Drawing.Size(48, 36);
            this.BtnLimpiar.TabIndex = 78;
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
            this.CBFiltro.Location = new System.Drawing.Point(500, 127);
            this.CBFiltro.MinimumSize = new System.Drawing.Size(150, 30);
            this.CBFiltro.Name = "CBFiltro";
            this.CBFiltro.Padding = new System.Windows.Forms.Padding(1);
            this.CBFiltro.SelectedIndex = -1;
            this.CBFiltro.SelectedItem = null;
            this.CBFiltro.Size = new System.Drawing.Size(202, 43);
            this.CBFiltro.TabIndex = 77;
            this.CBFiltro.ValueMember = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(384, 134);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 28);
            this.label6.TabIndex = 76;
            this.label6.Text = "Buscar por:";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.DarkBlue;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(294, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1303, 85);
            this.label3.TabIndex = 80;
            // 
            // tbnombre
            // 
            this.tbnombre.BackColor = System.Drawing.Color.White;
            this.tbnombre.ColorBorde = System.Drawing.Color.Gray;
            this.tbnombre.ColorBordeFocus = System.Drawing.Color.CornflowerBlue;
            this.tbnombre.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.tbnombre.ForeColor = System.Drawing.Color.DimGray;
            this.tbnombre.GrosorBorde = 2;
            this.tbnombre.Location = new System.Drawing.Point(23, 260);
            this.tbnombre.MaxLength = 32767;
            this.tbnombre.Name = "tbnombre";
            this.tbnombre.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tbnombre.PasswordChar = '\0';
            this.tbnombre.RadioBorde = 5;
            this.tbnombre.ReadOnly = false;
            this.tbnombre.Size = new System.Drawing.Size(252, 37);
            this.tbnombre.TabIndex = 89;
            this.tbnombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbnombre.UseSystemPasswordChar = false;
            // 
            // CBEstado
            // 
            this.CBEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.CBEstado.BackColorModerno = System.Drawing.Color.WhiteSmoke;
            this.CBEstado.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.CBEstado.BorderRadius = 8;
            this.CBEstado.BorderSize = 1;
            this.CBEstado.DataSource = null;
            this.CBEstado.DisplayMember = "";
            this.CBEstado.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.CBEstado.ForeColor = System.Drawing.Color.DimGray;
            this.CBEstado.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(66)))), ((int)(((byte)(210)))));
            this.CBEstado.Location = new System.Drawing.Point(29, 764);
            this.CBEstado.MinimumSize = new System.Drawing.Size(150, 30);
            this.CBEstado.Name = "CBEstado";
            this.CBEstado.Padding = new System.Windows.Forms.Padding(1);
            this.CBEstado.SelectedIndex = -1;
            this.CBEstado.SelectedItem = null;
            this.CBEstado.Size = new System.Drawing.Size(227, 36);
            this.CBEstado.TabIndex = 88;
            this.CBEstado.ValueMember = "";
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
            this.btnBorrar.Location = new System.Drawing.Point(29, 982);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.RadioBorde = 5;
            this.btnBorrar.Size = new System.Drawing.Size(228, 45);
            this.btnBorrar.TabIndex = 87;
            this.btnBorrar.Text = "Eliminar";
            this.btnBorrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBorrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBorrar.UseVisualStyleBackColor = false;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // Btlimc
            // 
            this.Btlimc.BackColor = System.Drawing.Color.White;
            this.Btlimc.ColorBorde = System.Drawing.Color.RoyalBlue;
            this.Btlimc.ColorClick = System.Drawing.Color.CornflowerBlue;
            this.Btlimc.ColorHover = System.Drawing.Color.RoyalBlue;
            this.Btlimc.ColorIconoHover = System.Drawing.Color.White;
            this.Btlimc.ColorTextoHover = System.Drawing.Color.White;
            this.Btlimc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btlimc.FlatAppearance.BorderSize = 0;
            this.Btlimc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btlimc.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.Btlimc.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Btlimc.GrosorBorde = 3;
            this.Btlimc.IconChar = FontAwesome.Sharp.IconChar.Redo;
            this.Btlimc.IconColor = System.Drawing.Color.RoyalBlue;
            this.Btlimc.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Btlimc.IconSize = 25;
            this.Btlimc.Location = new System.Drawing.Point(28, 916);
            this.Btlimc.Name = "Btlimc";
            this.Btlimc.RadioBorde = 5;
            this.Btlimc.Size = new System.Drawing.Size(228, 45);
            this.Btlimc.TabIndex = 86;
            this.Btlimc.Text = "Limpiar";
            this.Btlimc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btlimc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btlimc.UseVisualStyleBackColor = false;
            this.Btlimc.Click += new System.EventHandler(this.Btlimc_Click);
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
            this.BtnGuardar.Location = new System.Drawing.Point(28, 843);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.RadioBorde = 5;
            this.BtnGuardar.Size = new System.Drawing.Size(228, 45);
            this.BtnGuardar.TabIndex = 85;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // tbPrecio
            // 
            this.tbPrecio.BackColor = System.Drawing.Color.White;
            this.tbPrecio.ColorBorde = System.Drawing.Color.Gray;
            this.tbPrecio.ColorBordeFocus = System.Drawing.Color.CornflowerBlue;
            this.tbPrecio.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.tbPrecio.ForeColor = System.Drawing.Color.DimGray;
            this.tbPrecio.GrosorBorde = 2;
            this.tbPrecio.Location = new System.Drawing.Point(26, 564);
            this.tbPrecio.MaxLength = 32767;
            this.tbPrecio.Name = "tbPrecio";
            this.tbPrecio.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tbPrecio.PasswordChar = '\0';
            this.tbPrecio.RadioBorde = 5;
            this.tbPrecio.ReadOnly = false;
            this.tbPrecio.Size = new System.Drawing.Size(114, 37);
            this.tbPrecio.TabIndex = 84;
            this.tbPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbPrecio.UseSystemPasswordChar = false;
            // 
            // TBStock
            // 
            this.TBStock.BackColor = System.Drawing.Color.White;
            this.TBStock.ColorBorde = System.Drawing.Color.Gray;
            this.TBStock.ColorBordeFocus = System.Drawing.Color.CornflowerBlue;
            this.TBStock.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.TBStock.ForeColor = System.Drawing.Color.DimGray;
            this.TBStock.GrosorBorde = 2;
            this.TBStock.Location = new System.Drawing.Point(24, 461);
            this.TBStock.MaxLength = 32767;
            this.TBStock.Name = "TBStock";
            this.TBStock.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.TBStock.PasswordChar = '\0';
            this.TBStock.RadioBorde = 5;
            this.TBStock.ReadOnly = false;
            this.TBStock.Size = new System.Drawing.Size(252, 37);
            this.TBStock.TabIndex = 83;
            this.TBStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TBStock.UseSystemPasswordChar = false;
            // 
            // tbdesc
            // 
            this.tbdesc.BackColor = System.Drawing.Color.White;
            this.tbdesc.ColorBorde = System.Drawing.Color.Gray;
            this.tbdesc.ColorBordeFocus = System.Drawing.Color.CornflowerBlue;
            this.tbdesc.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.tbdesc.ForeColor = System.Drawing.Color.DimGray;
            this.tbdesc.GrosorBorde = 2;
            this.tbdesc.Location = new System.Drawing.Point(24, 359);
            this.tbdesc.MaxLength = 32767;
            this.tbdesc.Name = "tbdesc";
            this.tbdesc.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tbdesc.PasswordChar = '\0';
            this.tbdesc.RadioBorde = 5;
            this.tbdesc.ReadOnly = false;
            this.tbdesc.Size = new System.Drawing.Size(252, 37);
            this.tbdesc.TabIndex = 82;
            this.tbdesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbdesc.UseSystemPasswordChar = false;
            // 
            // TBCodigo
            // 
            this.TBCodigo.BackColor = System.Drawing.Color.White;
            this.TBCodigo.ColorBorde = System.Drawing.Color.Gray;
            this.TBCodigo.ColorBordeFocus = System.Drawing.Color.CornflowerBlue;
            this.TBCodigo.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.TBCodigo.ForeColor = System.Drawing.Color.DimGray;
            this.TBCodigo.GrosorBorde = 2;
            this.TBCodigo.Location = new System.Drawing.Point(22, 166);
            this.TBCodigo.MaxLength = 32767;
            this.TBCodigo.Name = "TBCodigo";
            this.TBCodigo.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.TBCodigo.PasswordChar = '\0';
            this.TBCodigo.RadioBorde = 5;
            this.TBCodigo.ReadOnly = false;
            this.TBCodigo.Size = new System.Drawing.Size(252, 37);
            this.TBCodigo.TabIndex = 81;
            this.TBCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TBCodigo.UseSystemPasswordChar = false;
            // 
            // CBCategoria
            // 
            this.CBCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.CBCategoria.BackColorModerno = System.Drawing.Color.WhiteSmoke;
            this.CBCategoria.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.CBCategoria.BorderRadius = 8;
            this.CBCategoria.BorderSize = 1;
            this.CBCategoria.DataSource = null;
            this.CBCategoria.DisplayMember = "";
            this.CBCategoria.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.CBCategoria.ForeColor = System.Drawing.Color.DimGray;
            this.CBCategoria.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(66)))), ((int)(((byte)(210)))));
            this.CBCategoria.Location = new System.Drawing.Point(28, 669);
            this.CBCategoria.MinimumSize = new System.Drawing.Size(150, 30);
            this.CBCategoria.Name = "CBCategoria";
            this.CBCategoria.Padding = new System.Windows.Forms.Padding(1);
            this.CBCategoria.SelectedIndex = -1;
            this.CBCategoria.SelectedItem = null;
            this.CBCategoria.Size = new System.Drawing.Size(228, 36);
            this.CBCategoria.TabIndex = 90;
            this.CBCategoria.ValueMember = "";
            // 
            // tbPrecioPromocion
            // 
            this.tbPrecioPromocion.BackColor = System.Drawing.Color.White;
            this.tbPrecioPromocion.ColorBorde = System.Drawing.Color.Gray;
            this.tbPrecioPromocion.ColorBordeFocus = System.Drawing.Color.CornflowerBlue;
            this.tbPrecioPromocion.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.tbPrecioPromocion.ForeColor = System.Drawing.Color.DimGray;
            this.tbPrecioPromocion.GrosorBorde = 2;
            this.tbPrecioPromocion.Location = new System.Drawing.Point(152, 564);
            this.tbPrecioPromocion.MaxLength = 32767;
            this.tbPrecioPromocion.Name = "tbPrecioPromocion";
            this.tbPrecioPromocion.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tbPrecioPromocion.PasswordChar = '\0';
            this.tbPrecioPromocion.RadioBorde = 5;
            this.tbPrecioPromocion.ReadOnly = false;
            this.tbPrecioPromocion.Size = new System.Drawing.Size(114, 37);
            this.tbPrecioPromocion.TabIndex = 91;
            this.tbPrecioPromocion.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbPrecioPromocion.UseSystemPasswordChar = false;
            // 
            // FrmStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1595, 1080);
            this.Controls.Add(this.tbPrecioPromocion);
            this.Controls.Add(this.CBCategoria);
            this.Controls.Add(this.tbnombre);
            this.Controls.Add(this.CBEstado);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.Btlimc);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.tbPrecio);
            this.Controls.Add(this.TBStock);
            this.Controls.Add(this.tbdesc);
            this.Controls.Add(this.TBCodigo);
            this.Controls.Add(this.pnlBuscador);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.CBFiltro);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbindice);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblrepetir);
            this.Controls.Add(this.lblcat);
            this.Controls.Add(this.lblrol);
            this.Controls.Add(this.lbldsc);
            this.Controls.Add(this.lblnombre);
            this.Controls.Add(this.lblcodigo);
            this.Controls.Add(this.DGVStck);
            this.Controls.Add(this.lbllistausu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmStock";
            this.Text = "FrmStock";
            this.Load += new System.EventHandler(this.FrmStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVStck)).EndInit();
            this.pnlBuscador.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbllistausu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGVStck;
        private System.Windows.Forms.TextBox tbindice;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblrepetir;
        private System.Windows.Forms.Label lblcat;
        private System.Windows.Forms.Label lblrol;
        private System.Windows.Forms.Label lbldsc;
        private System.Windows.Forms.Label lblnombre;
        private System.Windows.Forms.Label lblcodigo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewButtonColumn BtnSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Promocion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.Panel pnlBuscador;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private TextBoxModerno TBBuscar;
        private BotonModerno BtnLimpiar;
        private ComboBoxModerno CBFiltro;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private TextBoxModerno tbnombre;
        private ComboBoxModerno CBEstado;
        private BotonModerno btnBorrar;
        private BotonModerno Btlimc;
        private BotonModerno BtnGuardar;
        private TextBoxModerno tbPrecio;
        private TextBoxModerno TBStock;
        private TextBoxModerno tbdesc;
        private TextBoxModerno TBCodigo;
        private ComboBoxModerno CBCategoria;
        private TextBoxModerno tbPrecioPromocion;
    }
}