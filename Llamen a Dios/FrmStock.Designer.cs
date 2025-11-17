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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbllistausu = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DGVStck = new System.Windows.Forms.DataGridView();
            this.tbindice = new System.Windows.Forms.TextBox();
            this.CBCategoria = new System.Windows.Forms.ComboBox();
            this.txtid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBorrar = new FontAwesome.Sharp.IconButton();
            this.Btlimc = new FontAwesome.Sharp.IconButton();
            this.BtnGuardar = new FontAwesome.Sharp.IconButton();
            this.TBStock = new System.Windows.Forms.TextBox();
            this.lblrepetir = new System.Windows.Forms.Label();
            this.lblcat = new System.Windows.Forms.Label();
            this.lblrol = new System.Windows.Forms.Label();
            this.tbdesc = new System.Windows.Forms.TextBox();
            this.tbnombre = new System.Windows.Forms.TextBox();
            this.TBCodigo = new System.Windows.Forms.TextBox();
            this.lbldsc = new System.Windows.Forms.Label();
            this.lblnombre = new System.Windows.Forms.Label();
            this.lblcodigo = new System.Windows.Forms.Label();
            this.tbPrecio = new System.Windows.Forms.TextBox();
            this.CBEstado = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPrecioPromocion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CBFiltro = new System.Windows.Forms.ComboBox();
            this.BtnLimpiar = new FontAwesome.Sharp.IconButton();
            this.label3 = new System.Windows.Forms.Label();
            this.TBBuscar = new System.Windows.Forms.TextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.DGVStck)).BeginInit();
            this.SuspendLayout();
            // 
            // lbllistausu
            // 
            this.lbllistausu.AutoSize = true;
            this.lbllistausu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.lbllistausu.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllistausu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(157)))), ((int)(((byte)(217)))));
            this.lbllistausu.Location = new System.Drawing.Point(246, 33);
            this.lbllistausu.Name = "lbllistausu";
            this.lbllistausu.Size = new System.Drawing.Size(105, 25);
            this.lbllistausu.TabIndex = 42;
            this.lbllistausu.Text = "Inventario";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(157)))), ((int)(((byte)(217)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 533);
            this.label1.TabIndex = 26;
            // 
            // DGVStck
            // 
            this.DGVStck.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVStck.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
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
            this.DGVStck.Location = new System.Drawing.Point(251, 76);
            this.DGVStck.MultiSelect = false;
            this.DGVStck.Name = "DGVStck";
            this.DGVStck.ReadOnly = true;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.DGVStck.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVStck.RowTemplate.Height = 28;
            this.DGVStck.Size = new System.Drawing.Size(774, 399);
            this.DGVStck.TabIndex = 48;
            this.DGVStck.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVStck_CellContentClick);
            this.DGVStck.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DGVStck_CellPainting);
            // 
            // tbindice
            // 
            this.tbindice.Location = new System.Drawing.Point(149, 41);
            this.tbindice.Name = "tbindice";
            this.tbindice.Size = new System.Drawing.Size(28, 20);
            this.tbindice.TabIndex = 66;
            this.tbindice.Text = "-1";
            this.tbindice.Visible = false;
            // 
            // CBCategoria
            // 
            this.CBCategoria.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.CBCategoria.FormattingEnabled = true;
            this.CBCategoria.Location = new System.Drawing.Point(22, 337);
            this.CBCategoria.Name = "CBCategoria";
            this.CBCategoria.Size = new System.Drawing.Size(189, 23);
            this.CBCategoria.TabIndex = 65;
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(183, 41);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(28, 20);
            this.txtid.TabIndex = 63;
            this.txtid.Text = "0";
            this.txtid.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(157)))), ((int)(((byte)(217)))));
            this.label2.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.label2.Location = new System.Drawing.Point(20, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 25);
            this.label2.TabIndex = 62;
            this.label2.Text = "Detalles de Usuario";
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
            this.btnBorrar.Location = new System.Drawing.Point(22, 492);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(189, 27);
            this.btnBorrar.TabIndex = 61;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBorrar.UseVisualStyleBackColor = false;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // Btlimc
            // 
            this.Btlimc.BackColor = System.Drawing.Color.White;
            this.Btlimc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btlimc.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.Btlimc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.Btlimc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.Btlimc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btlimc.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.Btlimc.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Btlimc.IconChar = FontAwesome.Sharp.IconChar.Brush;
            this.Btlimc.IconColor = System.Drawing.Color.RoyalBlue;
            this.Btlimc.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Btlimc.IconSize = 18;
            this.Btlimc.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btlimc.Location = new System.Drawing.Point(22, 459);
            this.Btlimc.Name = "Btlimc";
            this.Btlimc.Rotation = 180D;
            this.Btlimc.Size = new System.Drawing.Size(189, 27);
            this.Btlimc.TabIndex = 60;
            this.Btlimc.Text = "Limpiar";
            this.Btlimc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btlimc.UseVisualStyleBackColor = false;
            this.Btlimc.Click += new System.EventHandler(this.Btlimc_Click);
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
            this.BtnGuardar.Location = new System.Drawing.Point(22, 426);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(189, 27);
            this.BtnGuardar.TabIndex = 59;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // TBStock
            // 
            this.TBStock.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.TBStock.Location = new System.Drawing.Point(22, 229);
            this.TBStock.Name = "TBStock";
            this.TBStock.PasswordChar = '0';
            this.TBStock.Size = new System.Drawing.Size(189, 23);
            this.TBStock.TabIndex = 58;
            this.TBStock.Text = "0";
            // 
            // lblrepetir
            // 
            this.lblrepetir.AutoSize = true;
            this.lblrepetir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(157)))), ((int)(((byte)(217)))));
            this.lblrepetir.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.lblrepetir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.lblrepetir.Location = new System.Drawing.Point(19, 258);
            this.lblrepetir.Name = "lblrepetir";
            this.lblrepetir.Size = new System.Drawing.Size(43, 15);
            this.lblrepetir.TabIndex = 57;
            this.lblrepetir.Text = "Precio";
            // 
            // lblcat
            // 
            this.lblcat.AutoSize = true;
            this.lblcat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(157)))), ((int)(((byte)(217)))));
            this.lblcat.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.lblcat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.lblcat.Location = new System.Drawing.Point(20, 317);
            this.lblcat.Name = "lblcat";
            this.lblcat.Size = new System.Drawing.Size(61, 15);
            this.lblcat.TabIndex = 56;
            this.lblcat.Text = "Categoria";
            // 
            // lblrol
            // 
            this.lblrol.AutoSize = true;
            this.lblrol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(157)))), ((int)(((byte)(217)))));
            this.lblrol.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.lblrol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.lblrol.Location = new System.Drawing.Point(19, 208);
            this.lblrol.Name = "lblrol";
            this.lblrol.Size = new System.Drawing.Size(40, 15);
            this.lblrol.TabIndex = 55;
            this.lblrol.Text = "Stock";
            // 
            // tbdesc
            // 
            this.tbdesc.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.tbdesc.Location = new System.Drawing.Point(22, 174);
            this.tbdesc.Name = "tbdesc";
            this.tbdesc.Size = new System.Drawing.Size(189, 23);
            this.tbdesc.TabIndex = 54;
            // 
            // tbnombre
            // 
            this.tbnombre.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.tbnombre.Location = new System.Drawing.Point(22, 124);
            this.tbnombre.Name = "tbnombre";
            this.tbnombre.Size = new System.Drawing.Size(189, 23);
            this.tbnombre.TabIndex = 53;
            // 
            // TBCodigo
            // 
            this.TBCodigo.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.TBCodigo.Location = new System.Drawing.Point(22, 67);
            this.TBCodigo.Name = "TBCodigo";
            this.TBCodigo.Size = new System.Drawing.Size(189, 23);
            this.TBCodigo.TabIndex = 52;
            // 
            // lbldsc
            // 
            this.lbldsc.AutoSize = true;
            this.lbldsc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(157)))), ((int)(((byte)(217)))));
            this.lbldsc.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.lbldsc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.lbldsc.Location = new System.Drawing.Point(19, 153);
            this.lbldsc.Name = "lbldsc";
            this.lbldsc.Size = new System.Drawing.Size(75, 15);
            this.lbldsc.TabIndex = 51;
            this.lbldsc.Text = "Descripcion";
            // 
            // lblnombre
            // 
            this.lblnombre.AutoSize = true;
            this.lblnombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(157)))), ((int)(((byte)(217)))));
            this.lblnombre.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.lblnombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.lblnombre.Location = new System.Drawing.Point(19, 106);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(52, 15);
            this.lblnombre.TabIndex = 50;
            this.lblnombre.Text = "Nombre";
            // 
            // lblcodigo
            // 
            this.lblcodigo.AutoSize = true;
            this.lblcodigo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(157)))), ((int)(((byte)(217)))));
            this.lblcodigo.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.lblcodigo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.lblcodigo.Location = new System.Drawing.Point(19, 43);
            this.lblcodigo.Name = "lblcodigo";
            this.lblcodigo.Size = new System.Drawing.Size(89, 15);
            this.lblcodigo.TabIndex = 49;
            this.lblcodigo.Text = "N# Referencia";
            // 
            // tbPrecio
            // 
            this.tbPrecio.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.tbPrecio.Location = new System.Drawing.Point(23, 282);
            this.tbPrecio.Name = "tbPrecio";
            this.tbPrecio.Size = new System.Drawing.Size(85, 23);
            this.tbPrecio.TabIndex = 67;
            this.tbPrecio.Text = "0";
            // 
            // CBEstado
            // 
            this.CBEstado.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.CBEstado.FormattingEnabled = true;
            this.CBEstado.Location = new System.Drawing.Point(22, 393);
            this.CBEstado.Name = "CBEstado";
            this.CBEstado.Size = new System.Drawing.Size(189, 23);
            this.CBEstado.TabIndex = 69;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(157)))), ((int)(((byte)(217)))));
            this.label4.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.label4.Location = new System.Drawing.Point(22, 369);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 15);
            this.label4.TabIndex = 68;
            this.label4.Text = "Estado";
            // 
            // tbPrecioPromocion
            // 
            this.tbPrecioPromocion.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.tbPrecioPromocion.Location = new System.Drawing.Point(127, 282);
            this.tbPrecioPromocion.Name = "tbPrecioPromocion";
            this.tbPrecioPromocion.Size = new System.Drawing.Size(85, 23);
            this.tbPrecioPromocion.TabIndex = 71;
            this.tbPrecioPromocion.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(157)))), ((int)(((byte)(217)))));
            this.label5.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.label5.Location = new System.Drawing.Point(128, 258);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 15);
            this.label5.TabIndex = 70;
            this.label5.Text = "Precio Promo";
            // 
            // CBFiltro
            // 
            this.CBFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBFiltro.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBFiltro.FormattingEnabled = true;
            this.CBFiltro.Location = new System.Drawing.Point(685, 39);
            this.CBFiltro.Name = "CBFiltro";
            this.CBFiltro.Size = new System.Drawing.Size(122, 23);
            this.CBFiltro.TabIndex = 75;
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
            this.BtnLimpiar.Location = new System.Drawing.Point(981, 37);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(42, 25);
            this.BtnLimpiar.TabIndex = 74;
            this.BtnLimpiar.UseVisualStyleBackColor = false;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.label3.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(157)))), ((int)(((byte)(217)))));
            this.label3.Location = new System.Drawing.Point(596, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 18);
            this.label3.TabIndex = 73;
            this.label3.Text = "Buscar por:";
            // 
            // TBBuscar
            // 
            this.TBBuscar.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.TBBuscar.Location = new System.Drawing.Point(813, 38);
            this.TBBuscar.Name = "TBBuscar";
            this.TBBuscar.Size = new System.Drawing.Size(160, 23);
            this.TBBuscar.TabIndex = 72;
            this.TBBuscar.TextChanged += new System.EventHandler(this.TBBuscar_TextChanged);
            // 
            // BtnSelect
            // 
            this.BtnSelect.HeaderText = "";
            this.BtnSelect.Name = "BtnSelect";
            this.BtnSelect.ReadOnly = true;
            this.BtnSelect.Width = 30;
            // 
            // IdProducto
            // 
            this.IdProducto.HeaderText = "Id";
            this.IdProducto.Name = "IdProducto";
            this.IdProducto.ReadOnly = true;
            this.IdProducto.Visible = false;
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // IdCategoria
            // 
            this.IdCategoria.HeaderText = "IdCategoria";
            this.IdCategoria.Name = "IdCategoria";
            this.IdCategoria.ReadOnly = true;
            this.IdCategoria.Visible = false;
            // 
            // Categoria
            // 
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.Name = "Categoria";
            this.Categoria.ReadOnly = true;
            // 
            // Stock
            // 
            this.Stock.HeaderText = "Stock";
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            // 
            // Promocion
            // 
            this.Promocion.HeaderText = "Promocion";
            this.Promocion.Name = "Promocion";
            this.Promocion.ReadOnly = true;
            // 
            // Valor
            // 
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            this.Valor.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "EstadoValor";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Visible = false;
            // 
            // FrmStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1037, 533);
            this.Controls.Add(this.CBFiltro);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TBBuscar);
            this.Controls.Add(this.tbPrecioPromocion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CBEstado);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbPrecio);
            this.Controls.Add(this.tbindice);
            this.Controls.Add(this.CBCategoria);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.Btlimc);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.TBStock);
            this.Controls.Add(this.lblrepetir);
            this.Controls.Add(this.lblcat);
            this.Controls.Add(this.lblrol);
            this.Controls.Add(this.tbdesc);
            this.Controls.Add(this.tbnombre);
            this.Controls.Add(this.TBCodigo);
            this.Controls.Add(this.lbldsc);
            this.Controls.Add(this.lblnombre);
            this.Controls.Add(this.lblcodigo);
            this.Controls.Add(this.DGVStck);
            this.Controls.Add(this.lbllistausu);
            this.Controls.Add(this.label1);
            this.Name = "FrmStock";
            this.Text = "FrmStock";
            this.Load += new System.EventHandler(this.FrmStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVStck)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbllistausu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGVStck;
        private System.Windows.Forms.TextBox tbindice;
        private System.Windows.Forms.ComboBox CBCategoria;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton btnBorrar;
        private FontAwesome.Sharp.IconButton Btlimc;
        private FontAwesome.Sharp.IconButton BtnGuardar;
        private System.Windows.Forms.TextBox TBStock;
        private System.Windows.Forms.Label lblrepetir;
        private System.Windows.Forms.Label lblcat;
        private System.Windows.Forms.Label lblrol;
        private System.Windows.Forms.TextBox tbdesc;
        private System.Windows.Forms.TextBox tbnombre;
        private System.Windows.Forms.TextBox TBCodigo;
        private System.Windows.Forms.Label lbldsc;
        private System.Windows.Forms.Label lblnombre;
        private System.Windows.Forms.Label lblcodigo;
        private System.Windows.Forms.TextBox tbPrecio;
        private System.Windows.Forms.ComboBox CBEstado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPrecioPromocion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CBFiltro;
        private FontAwesome.Sharp.IconButton BtnLimpiar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBBuscar;
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
    }
}