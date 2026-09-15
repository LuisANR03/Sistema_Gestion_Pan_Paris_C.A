namespace Llamen_a_Dios
{
    partial class FrmIngredientes
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
            this.tbindice = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblrepetir = new System.Windows.Forms.Label();
            this.lblrol = new System.Windows.Forms.Label();
            this.tbStock = new System.Windows.Forms.Label();
            this.lblnombre = new System.Windows.Forms.Label();
            this.txtstockminm = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbUnidad = new Llamen_a_Dios.ComboBoxModerno();
            this.panelModerno1 = new Llamen_a_Dios.PanelModerno();
            this.lbllistausu = new System.Windows.Forms.Label();
            this.groupBoxModerno1 = new Llamen_a_Dios.GroupBoxModerno();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.BtnSelect = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Idingrediente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnidadMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockMinimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBuscador = new System.Windows.Forms.Panel();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.TBBuscar = new TextBoxModerno();
            this.CBFiltro = new Llamen_a_Dios.ComboBoxModerno();
            this.BtnLimpiar = new BotonModerno();
            this.cbEstado = new Llamen_a_Dios.ComboBoxModerno();
            this.btnBorrar = new BotonModerno();
            this.Btlimpiar = new BotonModerno();
            this.BtnGuardar = new BotonModerno();
            this.tbcorreo = new TextBoxModerno();
            this.tbnombre = new TextBoxModerno();
            this.txtStockMinimo = new TextBoxModerno();
            this.panelModerno1.SuspendLayout();
            this.groupBoxModerno1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.pnlBuscador.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbindice
            // 
            this.tbindice.Location = new System.Drawing.Point(221, 63);
            this.tbindice.Margin = new System.Windows.Forms.Padding(4);
            this.tbindice.Name = "tbindice";
            this.tbindice.Size = new System.Drawing.Size(34, 22);
            this.tbindice.TabIndex = 92;
            this.tbindice.Text = "-1";
            this.tbindice.Visible = false;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(269, 63);
            this.txtId.Margin = new System.Windows.Forms.Padding(4);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(34, 22);
            this.txtId.TabIndex = 91;
            this.txtId.Text = "0";
            this.txtId.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(237)))), ((int)(((byte)(218)))));
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(48)))), ((int)(((byte)(23)))));
            this.label2.Location = new System.Drawing.Point(27, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(272, 31);
            this.label2.TabIndex = 90;
            this.label2.Text = "Detalles de Ingredientes";
            // 
            // lblrepetir
            // 
            this.lblrepetir.AutoSize = true;
            this.lblrepetir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(237)))), ((int)(((byte)(218)))));
            this.lblrepetir.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.lblrepetir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(48)))), ((int)(((byte)(23)))));
            this.lblrepetir.Location = new System.Drawing.Point(35, 515);
            this.lblrepetir.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblrepetir.Name = "lblrepetir";
            this.lblrepetir.Size = new System.Drawing.Size(61, 23);
            this.lblrepetir.TabIndex = 89;
            this.lblrepetir.Text = "Estado";
            // 
            // lblrol
            // 
            this.lblrol.AutoSize = true;
            this.lblrol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(237)))), ((int)(((byte)(218)))));
            this.lblrol.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.lblrol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(48)))), ((int)(((byte)(23)))));
            this.lblrol.Location = new System.Drawing.Point(35, 321);
            this.lblrol.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblrol.Name = "lblrol";
            this.lblrol.Size = new System.Drawing.Size(151, 23);
            this.lblrol.TabIndex = 87;
            this.lblrol.Text = "Unidad de Medida";
            // 
            // tbStock
            // 
            this.tbStock.AutoSize = true;
            this.tbStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(237)))), ((int)(((byte)(218)))));
            this.tbStock.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.tbStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(48)))), ((int)(((byte)(23)))));
            this.tbStock.Location = new System.Drawing.Point(36, 236);
            this.tbStock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tbStock.Name = "tbStock";
            this.tbStock.Size = new System.Drawing.Size(50, 23);
            this.tbStock.TabIndex = 86;
            this.tbStock.Text = "Stock";
            // 
            // lblnombre
            // 
            this.lblnombre.AutoSize = true;
            this.lblnombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(237)))), ((int)(((byte)(218)))));
            this.lblnombre.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.lblnombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(48)))), ((int)(((byte)(23)))));
            this.lblnombre.Location = new System.Drawing.Point(36, 148);
            this.lblnombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(73, 23);
            this.lblnombre.TabIndex = 85;
            this.lblnombre.Text = "Nombre";
            // 
            // txtstockminm
            // 
            this.txtstockminm.AutoSize = true;
            this.txtstockminm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(237)))), ((int)(((byte)(218)))));
            this.txtstockminm.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txtstockminm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(48)))), ((int)(((byte)(23)))));
            this.txtstockminm.Location = new System.Drawing.Point(35, 413);
            this.txtstockminm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtstockminm.Name = "txtstockminm";
            this.txtstockminm.Size = new System.Drawing.Size(113, 23);
            this.txtstockminm.TabIndex = 84;
            this.txtstockminm.Text = "Stock Minimo";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(237)))), ((int)(((byte)(218)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 1080);
            this.label1.TabIndex = 83;
            // 
            // cbUnidad
            // 
            this.cbUnidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbUnidad.BackColorModerno = System.Drawing.Color.WhiteSmoke;
            this.cbUnidad.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbUnidad.BorderRadius = 8;
            this.cbUnidad.BorderSize = 1;
            this.cbUnidad.DataSource = null;
            this.cbUnidad.DisplayMember = "";
            this.cbUnidad.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cbUnidad.ForeColor = System.Drawing.Color.DimGray;
            this.cbUnidad.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(66)))), ((int)(((byte)(210)))));
            this.cbUnidad.Location = new System.Drawing.Point(33, 361);
            this.cbUnidad.MinimumSize = new System.Drawing.Size(150, 30);
            this.cbUnidad.Name = "cbUnidad";
            this.cbUnidad.Padding = new System.Windows.Forms.Padding(1);
            this.cbUnidad.SelectedIndex = -1;
            this.cbUnidad.SelectedItem = null;
            this.cbUnidad.SelectedValue = null;
            this.cbUnidad.Size = new System.Drawing.Size(252, 36);
            this.cbUnidad.TabIndex = 104;
            this.cbUnidad.ValueMember = "";
            // 
            // panelModerno1
            // 
            this.panelModerno1.BackColor = System.Drawing.Color.Transparent;
            this.panelModerno1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(203)))), ((int)(((byte)(154)))));
            this.panelModerno1.BorderRadius = 15;
            this.panelModerno1.Controls.Add(this.lbllistausu);
            this.panelModerno1.Location = new System.Drawing.Point(365, 95);
            this.panelModerno1.Name = "panelModerno1";
            this.panelModerno1.RedondearAbajo = false;
            this.panelModerno1.Size = new System.Drawing.Size(1212, 100);
            this.panelModerno1.TabIndex = 102;
            // 
            // lbllistausu
            // 
            this.lbllistausu.AutoSize = true;
            this.lbllistausu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(203)))), ((int)(((byte)(154)))));
            this.lbllistausu.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllistausu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(48)))), ((int)(((byte)(23)))));
            this.lbllistausu.Location = new System.Drawing.Point(20, 35);
            this.lbllistausu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbllistausu.Name = "lbllistausu";
            this.lbllistausu.Size = new System.Drawing.Size(227, 31);
            this.lbllistausu.TabIndex = 21;
            this.lbllistausu.Text = "Lista de Ingredientes";
            // 
            // groupBoxModerno1
            // 
            this.groupBoxModerno1.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxModerno1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.groupBoxModerno1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.groupBoxModerno1.BorderRadius = 15;
            this.groupBoxModerno1.BorderSize = 2;
            this.groupBoxModerno1.Controls.Add(this.label4);
            this.groupBoxModerno1.Controls.Add(this.dgvData);
            this.groupBoxModerno1.Controls.Add(this.pnlBuscador);
            this.groupBoxModerno1.Controls.Add(this.CBFiltro);
            this.groupBoxModerno1.Controls.Add(this.BtnLimpiar);
            this.groupBoxModerno1.Location = new System.Drawing.Point(365, 148);
            this.groupBoxModerno1.Name = "groupBoxModerno1";
            this.groupBoxModerno1.RedondearAbajo = true;
            this.groupBoxModerno1.Size = new System.Drawing.Size(1212, 671);
            this.groupBoxModerno1.TabIndex = 103;
            this.groupBoxModerno1.TabStop = false;
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
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeight = 40;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BtnSelect,
            this.Idingrediente,
            this.Nombre,
            this.StockActual,
            this.UnidadMedida,
            this.StockMinimo,
            this.EstadoValor,
            this.Estado});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(0, 150);
            this.dgvData.Margin = new System.Windows.Forms.Padding(4);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 51;
            this.dgvData.RowTemplate.Height = 40;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1212, 499);
            this.dgvData.TabIndex = 20;
            this.dgvData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellContentClick);
            this.dgvData.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvData_CellPainting);
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
            // Idingrediente
            // 
            this.Idingrediente.HeaderText = "Id";
            this.Idingrediente.MinimumWidth = 6;
            this.Idingrediente.Name = "Idingrediente";
            this.Idingrediente.ReadOnly = true;
            this.Idingrediente.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Idingrediente.Visible = false;
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
            // StockActual
            // 
            this.StockActual.FillWeight = 87.91444F;
            this.StockActual.HeaderText = "Stock";
            this.StockActual.MinimumWidth = 6;
            this.StockActual.Name = "StockActual";
            this.StockActual.ReadOnly = true;
            this.StockActual.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // UnidadMedida
            // 
            this.UnidadMedida.FillWeight = 87.91444F;
            this.UnidadMedida.HeaderText = "Unidad";
            this.UnidadMedida.MinimumWidth = 6;
            this.UnidadMedida.Name = "UnidadMedida";
            this.UnidadMedida.ReadOnly = true;
            this.UnidadMedida.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // StockMinimo
            // 
            this.StockMinimo.HeaderText = "StockMinimo";
            this.StockMinimo.MinimumWidth = 6;
            this.StockMinimo.Name = "StockMinimo";
            this.StockMinimo.ReadOnly = true;
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
            // Estado
            // 
            this.Estado.FillWeight = 87.91444F;
            this.Estado.HeaderText = "Estado";
            this.Estado.MinimumWidth = 6;
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // pnlBuscador
            // 
            this.pnlBuscador.Controls.Add(this.iconPictureBox1);
            this.pnlBuscador.Controls.Add(this.TBBuscar);
            this.pnlBuscador.Location = new System.Drawing.Point(416, 80);
            this.pnlBuscador.Name = "pnlBuscador";
            this.pnlBuscador.Size = new System.Drawing.Size(714, 43);
            this.pnlBuscador.TabIndex = 46;
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
            // 
            // cbEstado
            // 
            this.cbEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbEstado.BackColorModerno = System.Drawing.Color.WhiteSmoke;
            this.cbEstado.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbEstado.BorderRadius = 8;
            this.cbEstado.BorderSize = 1;
            this.cbEstado.DataSource = null;
            this.cbEstado.DisplayMember = "";
            this.cbEstado.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cbEstado.ForeColor = System.Drawing.Color.DimGray;
            this.cbEstado.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(66)))), ((int)(((byte)(210)))));
            this.cbEstado.Location = new System.Drawing.Point(33, 563);
            this.cbEstado.MinimumSize = new System.Drawing.Size(150, 30);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Padding = new System.Windows.Forms.Padding(1);
            this.cbEstado.SelectedIndex = -1;
            this.cbEstado.SelectedItem = null;
            this.cbEstado.SelectedValue = null;
            this.cbEstado.Size = new System.Drawing.Size(252, 36);
            this.cbEstado.TabIndex = 101;
            this.cbEstado.ValueMember = "";
            // 
            // btnBorrar
            // 
            this.btnBorrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(99)))), ((int)(((byte)(69)))));
            this.btnBorrar.ColorBorde = System.Drawing.Color.Empty;
            this.btnBorrar.ColorClick = System.Drawing.Color.Red;
            this.btnBorrar.ColorHover = System.Drawing.Color.Firebrick;
            this.btnBorrar.ColorIconoHover = System.Drawing.Color.Empty;
            this.btnBorrar.ColorTextoHover = System.Drawing.Color.Empty;
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
            this.btnBorrar.Location = new System.Drawing.Point(40, 777);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.RadioBorde = 5;
            this.btnBorrar.Size = new System.Drawing.Size(228, 45);
            this.btnBorrar.TabIndex = 99;
            this.btnBorrar.Text = "Eliminar";
            this.btnBorrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBorrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBorrar.UseVisualStyleBackColor = false;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // Btlimpiar
            // 
            this.Btlimpiar.BackColor = System.Drawing.Color.White;
            this.Btlimpiar.ColorBorde = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(48)))), ((int)(((byte)(23)))));
            this.Btlimpiar.ColorClick = System.Drawing.Color.Empty;
            this.Btlimpiar.ColorHover = System.Drawing.Color.Empty;
            this.Btlimpiar.ColorIconoHover = System.Drawing.Color.Empty;
            this.Btlimpiar.ColorTextoHover = System.Drawing.Color.Empty;
            this.Btlimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btlimpiar.FlatAppearance.BorderSize = 0;
            this.Btlimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btlimpiar.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.Btlimpiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(48)))), ((int)(((byte)(23)))));
            this.Btlimpiar.GrosorBorde = 3;
            this.Btlimpiar.IconChar = FontAwesome.Sharp.IconChar.Redo;
            this.Btlimpiar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(48)))), ((int)(((byte)(23)))));
            this.Btlimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Btlimpiar.IconSize = 25;
            this.Btlimpiar.Location = new System.Drawing.Point(40, 705);
            this.Btlimpiar.Name = "Btlimpiar";
            this.Btlimpiar.RadioBorde = 5;
            this.Btlimpiar.Size = new System.Drawing.Size(228, 45);
            this.Btlimpiar.TabIndex = 98;
            this.Btlimpiar.Text = "Limpiar";
            this.Btlimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btlimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btlimpiar.UseVisualStyleBackColor = false;
            this.Btlimpiar.Click += new System.EventHandler(this.Btlimpiar_Click);
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
            this.BtnGuardar.Location = new System.Drawing.Point(39, 629);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.RadioBorde = 5;
            this.BtnGuardar.Size = new System.Drawing.Size(228, 45);
            this.BtnGuardar.TabIndex = 97;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // tbcorreo
            // 
            this.tbcorreo.BackColor = System.Drawing.Color.White;
            this.tbcorreo.ColorBorde = System.Drawing.Color.Gray;
            this.tbcorreo.ColorBordeFocus = System.Drawing.Color.CornflowerBlue;
            this.tbcorreo.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.tbcorreo.ForeColor = System.Drawing.Color.DimGray;
            this.tbcorreo.GrosorBorde = 2;
            this.tbcorreo.Location = new System.Drawing.Point(33, 271);
            this.tbcorreo.MaxLength = 32767;
            this.tbcorreo.Name = "tbcorreo";
            this.tbcorreo.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tbcorreo.PasswordChar = '\0';
            this.tbcorreo.RadioBorde = 5;
            this.tbcorreo.ReadOnly = false;
            this.tbcorreo.Size = new System.Drawing.Size(252, 37);
            this.tbcorreo.TabIndex = 95;
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
            this.tbnombre.Location = new System.Drawing.Point(33, 188);
            this.tbnombre.MaxLength = 32767;
            this.tbnombre.Name = "tbnombre";
            this.tbnombre.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tbnombre.PasswordChar = '\0';
            this.tbnombre.RadioBorde = 5;
            this.tbnombre.ReadOnly = false;
            this.tbnombre.Size = new System.Drawing.Size(252, 37);
            this.tbnombre.TabIndex = 94;
            this.tbnombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbnombre.UseSystemPasswordChar = false;
            // 
            // txtStockMinimo
            // 
            this.txtStockMinimo.BackColor = System.Drawing.Color.White;
            this.txtStockMinimo.ColorBorde = System.Drawing.Color.Gray;
            this.txtStockMinimo.ColorBordeFocus = System.Drawing.Color.CornflowerBlue;
            this.txtStockMinimo.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txtStockMinimo.ForeColor = System.Drawing.Color.DimGray;
            this.txtStockMinimo.GrosorBorde = 2;
            this.txtStockMinimo.Location = new System.Drawing.Point(33, 454);
            this.txtStockMinimo.MaxLength = 32767;
            this.txtStockMinimo.Name = "txtStockMinimo";
            this.txtStockMinimo.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtStockMinimo.PasswordChar = '\0';
            this.txtStockMinimo.RadioBorde = 5;
            this.txtStockMinimo.ReadOnly = false;
            this.txtStockMinimo.Size = new System.Drawing.Size(252, 37);
            this.txtStockMinimo.TabIndex = 93;
            this.txtStockMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtStockMinimo.UseSystemPasswordChar = false;
            // 
            // FrmIngredientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1595, 1080);
            this.Controls.Add(this.cbUnidad);
            this.Controls.Add(this.panelModerno1);
            this.Controls.Add(this.groupBoxModerno1);
            this.Controls.Add(this.cbEstado);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.Btlimpiar);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.tbcorreo);
            this.Controls.Add(this.tbnombre);
            this.Controls.Add(this.txtStockMinimo);
            this.Controls.Add(this.tbindice);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblrepetir);
            this.Controls.Add(this.lblrol);
            this.Controls.Add(this.tbStock);
            this.Controls.Add(this.lblnombre);
            this.Controls.Add(this.txtstockminm);
            this.Controls.Add(this.label1);
            this.Name = "FrmIngredientes";
            this.Text = "FrmIngredientes";
            this.Load += new System.EventHandler(this.FrmIngredientes_Load);
            this.panelModerno1.ResumeLayout(false);
            this.panelModerno1.PerformLayout();
            this.groupBoxModerno1.ResumeLayout(false);
            this.groupBoxModerno1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.pnlBuscador.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PanelModerno panelModerno1;
        private System.Windows.Forms.Label lbllistausu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlBuscador;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private TextBoxModerno TBBuscar;
        private ComboBoxModerno CBFiltro;
        private BotonModerno BtnLimpiar;
        private GroupBoxModerno groupBoxModerno1;
        private System.Windows.Forms.DataGridView dgvData;
        private ComboBoxModerno cbEstado;
        private BotonModerno btnBorrar;
        private BotonModerno Btlimpiar;
        private BotonModerno BtnGuardar;
        private TextBoxModerno tbcorreo;
        private TextBoxModerno tbnombre;
        private TextBoxModerno txtStockMinimo;
        private System.Windows.Forms.TextBox tbindice;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblrepetir;
        private System.Windows.Forms.Label lblrol;
        private System.Windows.Forms.Label tbStock;
        private System.Windows.Forms.Label lblnombre;
        private System.Windows.Forms.Label txtstockminm;
        private System.Windows.Forms.Label label1;
        private ComboBoxModerno cbUnidad;
        private System.Windows.Forms.DataGridViewButtonColumn BtnSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn Idingrediente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnidadMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockMinimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
    }
}