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
            this.label1 = new System.Windows.Forms.Label();
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
            this.label3 = new System.Windows.Forms.Label();
            this.btnReceta = new BotonModerno();
            this.txbcosto = new TextBoxModerno();
            this.panelModerno1 = new Llamen_a_Dios.PanelModerno();
            this.lbllistausu = new System.Windows.Forms.Label();
            this.groupBoxModerno1 = new Llamen_a_Dios.GroupBoxModerno();
            this.label6 = new System.Windows.Forms.Label();
            this.DGVStck = new System.Windows.Forms.DataGridView();
            this.tbPrecioPromocion = new TextBoxModerno();
            this.CBFiltro = new Llamen_a_Dios.ComboBoxModerno();
            this.BtnLimpiar = new BotonModerno();
            this.pnlBuscador = new System.Windows.Forms.Panel();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.TBBuscar = new TextBoxModerno();
            this.label5 = new System.Windows.Forms.Label();
            this.CBCategoria = new Llamen_a_Dios.ComboBoxModerno();
            this.tbnombre = new TextBoxModerno();
            this.CBEstado = new Llamen_a_Dios.ComboBoxModerno();
            this.btnBorrar = new BotonModerno();
            this.Btlimc = new BotonModerno();
            this.BtnGuardar = new BotonModerno();
            this.tbPrecio = new TextBoxModerno();
            this.TBStock = new TextBoxModerno();
            this.tbdesc = new TextBoxModerno();
            this.TBCodigo = new TextBoxModerno();
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
            this.CostoProduccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelModerno1.SuspendLayout();
            this.groupBoxModerno1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVStck)).BeginInit();
            this.pnlBuscador.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(237)))), ((int)(((byte)(218)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(48)))), ((int)(((byte)(23)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 1080);
            this.label1.TabIndex = 26;
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
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(237)))), ((int)(((byte)(218)))));
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(48)))), ((int)(((byte)(23)))));
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
            this.lblrepetir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(237)))), ((int)(((byte)(218)))));
            this.lblrepetir.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrepetir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(48)))), ((int)(((byte)(23)))));
            this.lblrepetir.Location = new System.Drawing.Point(27, 471);
            this.lblrepetir.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblrepetir.Name = "lblrepetir";
            this.lblrepetir.Size = new System.Drawing.Size(60, 25);
            this.lblrepetir.TabIndex = 57;
            this.lblrepetir.Text = "Precio";
            // 
            // lblcat
            // 
            this.lblcat.AutoSize = true;
            this.lblcat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(237)))), ((int)(((byte)(218)))));
            this.lblcat.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(48)))), ((int)(((byte)(23)))));
            this.lblcat.Location = new System.Drawing.Point(32, 709);
            this.lblcat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblcat.Name = "lblcat";
            this.lblcat.Size = new System.Drawing.Size(88, 25);
            this.lblcat.TabIndex = 56;
            this.lblcat.Text = "Categoria";
            // 
            // lblrol
            // 
            this.lblrol.AutoSize = true;
            this.lblrol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(237)))), ((int)(((byte)(218)))));
            this.lblrol.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(48)))), ((int)(((byte)(23)))));
            this.lblrol.Location = new System.Drawing.Point(32, 376);
            this.lblrol.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblrol.Name = "lblrol";
            this.lblrol.Size = new System.Drawing.Size(55, 25);
            this.lblrol.TabIndex = 55;
            this.lblrol.Text = "Stock";
            // 
            // lbldsc
            // 
            this.lbldsc.AutoSize = true;
            this.lbldsc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(237)))), ((int)(((byte)(218)))));
            this.lbldsc.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldsc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(48)))), ((int)(((byte)(23)))));
            this.lbldsc.Location = new System.Drawing.Point(26, 278);
            this.lbldsc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbldsc.Name = "lbldsc";
            this.lbldsc.Size = new System.Drawing.Size(104, 25);
            this.lbldsc.TabIndex = 51;
            this.lbldsc.Text = "Descripcion";
            // 
            // lblnombre
            // 
            this.lblnombre.AutoSize = true;
            this.lblnombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(237)))), ((int)(((byte)(218)))));
            this.lblnombre.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(48)))), ((int)(((byte)(23)))));
            this.lblnombre.Location = new System.Drawing.Point(24, 182);
            this.lblnombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(78, 25);
            this.lblnombre.TabIndex = 50;
            this.lblnombre.Text = "Nombre";
            // 
            // lblcodigo
            // 
            this.lblcodigo.AutoSize = true;
            this.lblcodigo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(237)))), ((int)(((byte)(218)))));
            this.lblcodigo.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcodigo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(48)))), ((int)(((byte)(23)))));
            this.lblcodigo.Location = new System.Drawing.Point(28, 88);
            this.lblcodigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblcodigo.Name = "lblcodigo";
            this.lblcodigo.Size = new System.Drawing.Size(121, 25);
            this.lblcodigo.TabIndex = 49;
            this.lblcodigo.Text = "N# Referencia";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(237)))), ((int)(((byte)(218)))));
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(48)))), ((int)(((byte)(23)))));
            this.label4.Location = new System.Drawing.Point(32, 792);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 25);
            this.label4.TabIndex = 68;
            this.label4.Text = "Estado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(237)))), ((int)(((byte)(218)))));
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(48)))), ((int)(((byte)(23)))));
            this.label3.Location = new System.Drawing.Point(26, 563);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 25);
            this.label3.TabIndex = 94;
            this.label3.Text = "Costo de Produccion";
            // 
            // btnReceta
            // 
            this.btnReceta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(114)))), ((int)(((byte)(13)))));
            this.btnReceta.ColorBorde = System.Drawing.Color.White;
            this.btnReceta.ColorClick = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(114)))), ((int)(((byte)(13)))));
            this.btnReceta.ColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(113)))), ((int)(((byte)(34)))));
            this.btnReceta.ColorIconoHover = System.Drawing.Color.White;
            this.btnReceta.ColorTextoHover = System.Drawing.Color.White;
            this.btnReceta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReceta.FlatAppearance.BorderSize = 0;
            this.btnReceta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceta.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.btnReceta.ForeColor = System.Drawing.Color.White;
            this.btnReceta.GrosorBorde = 0;
            this.btnReceta.IconChar = FontAwesome.Sharp.IconChar.Receipt;
            this.btnReceta.IconColor = System.Drawing.Color.White;
            this.btnReceta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReceta.IconSize = 25;
            this.btnReceta.Location = new System.Drawing.Point(31, 661);
            this.btnReceta.Name = "btnReceta";
            this.btnReceta.RadioBorde = 5;
            this.btnReceta.Size = new System.Drawing.Size(228, 45);
            this.btnReceta.TabIndex = 96;
            this.btnReceta.Text = "Asignar Receta";
            this.btnReceta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReceta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReceta.UseVisualStyleBackColor = false;
            this.btnReceta.Click += new System.EventHandler(this.btnReceta_Click);
            // 
            // txbcosto
            // 
            this.txbcosto.BackColor = System.Drawing.Color.White;
            this.txbcosto.ColorBorde = System.Drawing.Color.Gray;
            this.txbcosto.ColorBordeFocus = System.Drawing.Color.CornflowerBlue;
            this.txbcosto.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txbcosto.ForeColor = System.Drawing.Color.DimGray;
            this.txbcosto.GrosorBorde = 2;
            this.txbcosto.Location = new System.Drawing.Point(33, 600);
            this.txbcosto.MaxLength = 32767;
            this.txbcosto.Name = "txbcosto";
            this.txbcosto.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txbcosto.PasswordChar = '\0';
            this.txbcosto.RadioBorde = 5;
            this.txbcosto.ReadOnly = false;
            this.txbcosto.Size = new System.Drawing.Size(114, 37);
            this.txbcosto.TabIndex = 95;
            this.txbcosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txbcosto.UseSystemPasswordChar = false;
            // 
            // panelModerno1
            // 
            this.panelModerno1.BackColor = System.Drawing.Color.Transparent;
            this.panelModerno1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(203)))), ((int)(((byte)(154)))));
            this.panelModerno1.BorderRadius = 15;
            this.panelModerno1.Controls.Add(this.lbllistausu);
            this.panelModerno1.Location = new System.Drawing.Point(353, 141);
            this.panelModerno1.Name = "panelModerno1";
            this.panelModerno1.RedondearAbajo = false;
            this.panelModerno1.Size = new System.Drawing.Size(1176, 100);
            this.panelModerno1.TabIndex = 92;
            // 
            // lbllistausu
            // 
            this.lbllistausu.AutoSize = true;
            this.lbllistausu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(203)))), ((int)(((byte)(154)))));
            this.lbllistausu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllistausu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(48)))), ((int)(((byte)(23)))));
            this.lbllistausu.Location = new System.Drawing.Point(30, 37);
            this.lbllistausu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbllistausu.Name = "lbllistausu";
            this.lbllistausu.Size = new System.Drawing.Size(109, 28);
            this.lbllistausu.TabIndex = 42;
            this.lbllistausu.Text = "Inventario";
            // 
            // groupBoxModerno1
            // 
            this.groupBoxModerno1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.groupBoxModerno1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.groupBoxModerno1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.groupBoxModerno1.BorderRadius = 15;
            this.groupBoxModerno1.BorderSize = 2;
            this.groupBoxModerno1.Controls.Add(this.label6);
            this.groupBoxModerno1.Controls.Add(this.DGVStck);
            this.groupBoxModerno1.Controls.Add(this.tbPrecioPromocion);
            this.groupBoxModerno1.Controls.Add(this.CBFiltro);
            this.groupBoxModerno1.Controls.Add(this.BtnLimpiar);
            this.groupBoxModerno1.Controls.Add(this.pnlBuscador);
            this.groupBoxModerno1.Controls.Add(this.label5);
            this.groupBoxModerno1.Location = new System.Drawing.Point(353, 222);
            this.groupBoxModerno1.Name = "groupBoxModerno1";
            this.groupBoxModerno1.RedondearAbajo = true;
            this.groupBoxModerno1.Size = new System.Drawing.Size(1176, 746);
            this.groupBoxModerno1.TabIndex = 93;
            this.groupBoxModerno1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(31, 72);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 28);
            this.label6.TabIndex = 76;
            this.label6.Text = "Buscar por:";
            // 
            // DGVStck
            // 
            this.DGVStck.AllowUserToAddRows = false;
            this.DGVStck.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVStck.BackgroundColor = System.Drawing.Color.White;
            this.DGVStck.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVStck.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGVStck.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVStck.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVStck.ColumnHeadersHeight = 40;
            this.DGVStck.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
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
            this.CostoProduccion,
            this.Fecha});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVStck.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGVStck.EnableHeadersVisualStyles = false;
            this.DGVStck.Location = new System.Drawing.Point(30, 129);
            this.DGVStck.Margin = new System.Windows.Forms.Padding(4);
            this.DGVStck.MultiSelect = false;
            this.DGVStck.Name = "DGVStck";
            this.DGVStck.ReadOnly = true;
            this.DGVStck.RowHeadersVisible = false;
            this.DGVStck.RowHeadersWidth = 51;
            this.DGVStck.RowTemplate.Height = 40;
            this.DGVStck.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVStck.Size = new System.Drawing.Size(1116, 514);
            this.DGVStck.TabIndex = 48;
            this.DGVStck.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVStck_CellContentClick);
            this.DGVStck.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DGVStck_CellPainting);
            // 
            // tbPrecioPromocion
            // 
            this.tbPrecioPromocion.BackColor = System.Drawing.Color.White;
            this.tbPrecioPromocion.ColorBorde = System.Drawing.Color.Gray;
            this.tbPrecioPromocion.ColorBordeFocus = System.Drawing.Color.CornflowerBlue;
            this.tbPrecioPromocion.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.tbPrecioPromocion.ForeColor = System.Drawing.Color.DimGray;
            this.tbPrecioPromocion.GrosorBorde = 2;
            this.tbPrecioPromocion.Location = new System.Drawing.Point(1056, 744);
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
            this.tbPrecioPromocion.Visible = false;
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
            this.CBFiltro.Location = new System.Drawing.Point(147, 65);
            this.CBFiltro.MinimumSize = new System.Drawing.Size(150, 30);
            this.CBFiltro.Name = "CBFiltro";
            this.CBFiltro.Padding = new System.Windows.Forms.Padding(1);
            this.CBFiltro.SelectedIndex = -1;
            this.CBFiltro.SelectedItem = null;
            this.CBFiltro.SelectedValue = null;
            this.CBFiltro.Size = new System.Drawing.Size(202, 43);
            this.CBFiltro.TabIndex = 77;
            this.CBFiltro.ValueMember = "";
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
            this.BtnLimpiar.Location = new System.Drawing.Point(1097, 66);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.RadioBorde = 5;
            this.BtnLimpiar.Rotation = 180D;
            this.BtnLimpiar.Size = new System.Drawing.Size(48, 36);
            this.BtnLimpiar.TabIndex = 78;
            this.BtnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnLimpiar.UseVisualStyleBackColor = true;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // pnlBuscador
            // 
            this.pnlBuscador.Controls.Add(this.iconPictureBox1);
            this.pnlBuscador.Controls.Add(this.TBBuscar);
            this.pnlBuscador.Location = new System.Drawing.Point(374, 66);
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(237)))), ((int)(((byte)(218)))));
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(48)))), ((int)(((byte)(23)))));
            this.label5.Location = new System.Drawing.Point(1050, 703);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 25);
            this.label5.TabIndex = 70;
            this.label5.Text = "Precio Promo";
            this.label5.Visible = false;
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
            this.CBCategoria.Location = new System.Drawing.Point(29, 753);
            this.CBCategoria.MinimumSize = new System.Drawing.Size(150, 30);
            this.CBCategoria.Name = "CBCategoria";
            this.CBCategoria.Padding = new System.Windows.Forms.Padding(1);
            this.CBCategoria.SelectedIndex = -1;
            this.CBCategoria.SelectedItem = null;
            this.CBCategoria.SelectedValue = null;
            this.CBCategoria.Size = new System.Drawing.Size(228, 36);
            this.CBCategoria.TabIndex = 90;
            this.CBCategoria.ValueMember = "";
            // 
            // tbnombre
            // 
            this.tbnombre.BackColor = System.Drawing.Color.White;
            this.tbnombre.ColorBorde = System.Drawing.Color.Gray;
            this.tbnombre.ColorBordeFocus = System.Drawing.Color.CornflowerBlue;
            this.tbnombre.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.tbnombre.ForeColor = System.Drawing.Color.DimGray;
            this.tbnombre.GrosorBorde = 2;
            this.tbnombre.Location = new System.Drawing.Point(29, 224);
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
            this.CBEstado.Location = new System.Drawing.Point(29, 829);
            this.CBEstado.MinimumSize = new System.Drawing.Size(150, 30);
            this.CBEstado.Name = "CBEstado";
            this.CBEstado.Padding = new System.Windows.Forms.Padding(1);
            this.CBEstado.SelectedIndex = -1;
            this.CBEstado.SelectedItem = null;
            this.CBEstado.SelectedValue = null;
            this.CBEstado.Size = new System.Drawing.Size(227, 36);
            this.CBEstado.TabIndex = 88;
            this.CBEstado.ValueMember = "";
            // 
            // btnBorrar
            // 
            this.btnBorrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(99)))), ((int)(((byte)(69)))));
            this.btnBorrar.ColorBorde = System.Drawing.Color.Empty;
            this.btnBorrar.ColorClick = System.Drawing.Color.Red;
            this.btnBorrar.ColorHover = System.Drawing.Color.Firebrick;
            this.btnBorrar.ColorIconoHover = System.Drawing.Color.White;
            this.btnBorrar.ColorTextoHover = System.Drawing.Color.White;
            this.btnBorrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBorrar.FlatAppearance.BorderSize = 0;
            this.btnBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrar.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.btnBorrar.ForeColor = System.Drawing.Color.White;
            this.btnBorrar.GrosorBorde = 3;
            this.btnBorrar.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.btnBorrar.IconColor = System.Drawing.Color.White;
            this.btnBorrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBorrar.IconSize = 25;
            this.btnBorrar.Location = new System.Drawing.Point(30, 1006);
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
            this.Btlimc.ColorBorde = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(48)))), ((int)(((byte)(23)))));
            this.Btlimc.ColorClick = System.Drawing.Color.Empty;
            this.Btlimc.ColorHover = System.Drawing.Color.Empty;
            this.Btlimc.ColorIconoHover = System.Drawing.Color.Empty;
            this.Btlimc.ColorTextoHover = System.Drawing.Color.Empty;
            this.Btlimc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btlimc.FlatAppearance.BorderSize = 0;
            this.Btlimc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btlimc.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.Btlimc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(48)))), ((int)(((byte)(23)))));
            this.Btlimc.GrosorBorde = 3;
            this.Btlimc.IconChar = FontAwesome.Sharp.IconChar.Redo;
            this.Btlimc.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(48)))), ((int)(((byte)(23)))));
            this.Btlimc.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Btlimc.IconSize = 25;
            this.Btlimc.Location = new System.Drawing.Point(29, 951);
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
            this.BtnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(114)))), ((int)(((byte)(13)))));
            this.BtnGuardar.ColorBorde = System.Drawing.Color.White;
            this.BtnGuardar.ColorClick = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(114)))), ((int)(((byte)(13)))));
            this.BtnGuardar.ColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(113)))), ((int)(((byte)(34)))));
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
            this.BtnGuardar.Location = new System.Drawing.Point(29, 893);
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
            this.tbPrecio.Location = new System.Drawing.Point(29, 507);
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
            this.TBStock.Location = new System.Drawing.Point(30, 420);
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
            this.tbdesc.Location = new System.Drawing.Point(30, 323);
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
            this.TBCodigo.Location = new System.Drawing.Point(29, 128);
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
            // BtnSelect
            // 
            this.BtnSelect.FillWeight = 20F;
            this.BtnSelect.HeaderText = "";
            this.BtnSelect.MinimumWidth = 6;
            this.BtnSelect.Name = "BtnSelect";
            this.BtnSelect.ReadOnly = true;
            // 
            // IdProducto
            // 
            this.IdProducto.HeaderText = "Id";
            this.IdProducto.MinimumWidth = 6;
            this.IdProducto.Name = "IdProducto";
            this.IdProducto.ReadOnly = true;
            this.IdProducto.Visible = false;
            // 
            // Codigo
            // 
            this.Codigo.FillWeight = 98.45684F;
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.MinimumWidth = 6;
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.FillWeight = 98.45684F;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Descripcion
            // 
            this.Descripcion.FillWeight = 98.45684F;
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.MinimumWidth = 6;
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // IdCategoria
            // 
            this.IdCategoria.HeaderText = "IdCategoria";
            this.IdCategoria.MinimumWidth = 6;
            this.IdCategoria.Name = "IdCategoria";
            this.IdCategoria.ReadOnly = true;
            this.IdCategoria.Visible = false;
            // 
            // Categoria
            // 
            this.Categoria.FillWeight = 98.45684F;
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.MinimumWidth = 6;
            this.Categoria.Name = "Categoria";
            this.Categoria.ReadOnly = true;
            // 
            // Stock
            // 
            this.Stock.FillWeight = 98.45684F;
            this.Stock.HeaderText = "Stock";
            this.Stock.MinimumWidth = 6;
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            // 
            // Precio
            // 
            this.Precio.FillWeight = 98.45684F;
            this.Precio.HeaderText = "Precio";
            this.Precio.MinimumWidth = 6;
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            // 
            // Promocion
            // 
            this.Promocion.FillWeight = 98.45684F;
            this.Promocion.HeaderText = "Promocion";
            this.Promocion.MinimumWidth = 6;
            this.Promocion.Name = "Promocion";
            this.Promocion.ReadOnly = true;
            this.Promocion.Visible = false;
            // 
            // Valor
            // 
            this.Valor.HeaderText = "Valor";
            this.Valor.MinimumWidth = 6;
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            this.Valor.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "EstadoValor";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // CostoProduccion
            // 
            this.CostoProduccion.HeaderText = "CostoProduccion";
            this.CostoProduccion.MinimumWidth = 6;
            this.CostoProduccion.Name = "CostoProduccion";
            this.CostoProduccion.ReadOnly = true;
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.MinimumWidth = 6;
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Visible = false;
            // 
            // FrmStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1595, 1080);
            this.Controls.Add(this.btnReceta);
            this.Controls.Add(this.txbcosto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panelModerno1);
            this.Controls.Add(this.groupBoxModerno1);
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
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmStock";
            this.Text = "FrmStock";
            this.Load += new System.EventHandler(this.FrmStock_Load);
            this.panelModerno1.ResumeLayout(false);
            this.panelModerno1.PerformLayout();
            this.groupBoxModerno1.ResumeLayout(false);
            this.groupBoxModerno1.PerformLayout();
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
        private System.Windows.Forms.Panel pnlBuscador;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private TextBoxModerno TBBuscar;
        private BotonModerno BtnLimpiar;
        private ComboBoxModerno CBFiltro;
        private System.Windows.Forms.Label label6;
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
        private PanelModerno panelModerno1;
        private GroupBoxModerno groupBoxModerno1;
        private TextBoxModerno txbcosto;
        private System.Windows.Forms.Label label3;
        private BotonModerno btnReceta;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn CostoProduccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
    }
}