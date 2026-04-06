namespace Llamen_a_Dios
{
    partial class Frmregistrarventa
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
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
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txbtotalproductos = new TextBoxModerno();
            this.btnagregarproducto = new BotonModerno();
            this.btnbuscarproducto = new BotonModerno();
            this.txbproducto = new TextBoxModerno();
            this.btnbuscarcliente = new BotonModerno();
            this.txbcedula = new TextBoxModerno();
            this.txbcliente = new TextBoxModerno();
            this.txbfecha = new TextBoxModerno();
            this.txbcajero = new TextBoxModerno();
            this.cbvendedor = new Llamen_a_Dios.ComboBoxModerno();
            this.btnVenta = new BotonModerno();
            this.txbtotalpagar = new TextBoxModerno();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVStck)).BeginInit();
            this.SuspendLayout();
            // 
            // lbllistausu
            // 
            this.lbllistausu.BackColor = System.Drawing.Color.White;
            this.lbllistausu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllistausu.ForeColor = System.Drawing.Color.Black;
            this.lbllistausu.Location = new System.Drawing.Point(103, 34);
            this.lbllistausu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbllistausu.Name = "lbllistausu";
            this.lbllistausu.Size = new System.Drawing.Size(1376, 986);
            this.lbllistausu.TabIndex = 22;
            this.lbllistausu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.txbfecha);
            this.groupBox1.Controls.Add(this.txbcajero);
            this.groupBox1.Controls.Add(this.cbvendedor);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(144, 87);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(472, 123);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(219, 84);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 16);
            this.label4.TabIndex = 26;
            this.label4.Text = "Cajero";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(201, 25);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Vendedor(a)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(623, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 31);
            this.label1.TabIndex = 24;
            this.label1.Text = "Registrar Venta";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.btnbuscarcliente);
            this.groupBox2.Controls.Add(this.txbcedula);
            this.groupBox2.Controls.Add(this.txbcliente);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(719, 87);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(723, 123);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(217, 54);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 16);
            this.label6.TabIndex = 29;
            this.label6.Text = "Documento";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 53);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 28;
            this.label5.Text = "Nombre";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.btnagregarproducto);
            this.groupBox3.Controls.Add(this.btnbuscarproducto);
            this.groupBox3.Controls.Add(this.txbproducto);
            this.groupBox3.Controls.Add(this.DGVStck);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(144, 218);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(1298, 612);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 47);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 16);
            this.label7.TabIndex = 28;
            this.label7.Text = "Ref Producto";
            // 
            // DGVStck
            // 
            this.DGVStck.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.DGVStck.Location = new System.Drawing.Point(23, 90);
            this.DGVStck.Margin = new System.Windows.Forms.Padding(4);
            this.DGVStck.MultiSelect = false;
            this.DGVStck.Name = "DGVStck";
            this.DGVStck.ReadOnly = true;
            this.DGVStck.RowHeadersWidth = 51;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.DGVStck.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVStck.RowTemplate.Height = 28;
            this.DGVStck.Size = new System.Drawing.Size(1116, 836);
            this.DGVStck.TabIndex = 49;
            this.DGVStck.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVStck_CellContentClick_1);
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(164, 898);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 16);
            this.label8.TabIndex = 31;
            this.label8.Text = "Productos";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(345, 898);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 16);
            this.label9.TabIndex = 32;
            this.label9.Text = "Total a pagar";
            // 
            // txbtotalproductos
            // 
            this.txbtotalproductos.BackColor = System.Drawing.Color.White;
            this.txbtotalproductos.ColorBorde = System.Drawing.Color.Gray;
            this.txbtotalproductos.ColorBordeFocus = System.Drawing.Color.CornflowerBlue;
            this.txbtotalproductos.ForeColor = System.Drawing.Color.DimGray;
            this.txbtotalproductos.GrosorBorde = 2;
            this.txbtotalproductos.Location = new System.Drawing.Point(154, 917);
            this.txbtotalproductos.MaxLength = 32767;
            this.txbtotalproductos.Name = "txbtotalproductos";
            this.txbtotalproductos.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txbtotalproductos.PasswordChar = '\0';
            this.txbtotalproductos.RadioBorde = 15;
            this.txbtotalproductos.ReadOnly = false;
            this.txbtotalproductos.Size = new System.Drawing.Size(124, 38);
            this.txbtotalproductos.TabIndex = 33;
            this.txbtotalproductos.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txbtotalproductos.UseSystemPasswordChar = false;
            // 
            // btnagregarproducto
            // 
            this.btnagregarproducto.BackColor = System.Drawing.Color.White;
            this.btnagregarproducto.ColorBorde = System.Drawing.Color.Black;
            this.btnagregarproducto.ColorClick = System.Drawing.Color.RoyalBlue;
            this.btnagregarproducto.ColorHover = System.Drawing.Color.CornflowerBlue;
            this.btnagregarproducto.ColorIconoHover = System.Drawing.Color.White;
            this.btnagregarproducto.ColorTextoHover = System.Drawing.Color.White;
            this.btnagregarproducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnagregarproducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnagregarproducto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnagregarproducto.ForeColor = System.Drawing.Color.Black;
            this.btnagregarproducto.GrosorBorde = 0;
            this.btnagregarproducto.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnagregarproducto.IconColor = System.Drawing.Color.Black;
            this.btnagregarproducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnagregarproducto.IconSize = 35;
            this.btnagregarproducto.Location = new System.Drawing.Point(359, 37);
            this.btnagregarproducto.Name = "btnagregarproducto";
            this.btnagregarproducto.RadioBorde = 0;
            this.btnagregarproducto.Size = new System.Drawing.Size(159, 46);
            this.btnagregarproducto.TabIndex = 53;
            this.btnagregarproducto.Text = "Agregar";
            this.btnagregarproducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnagregarproducto.UseVisualStyleBackColor = false;
            this.btnagregarproducto.Click += new System.EventHandler(this.btnagregarproducto_Click);
            // 
            // btnbuscarproducto
            // 
            this.btnbuscarproducto.BackColor = System.Drawing.Color.White;
            this.btnbuscarproducto.ColorBorde = System.Drawing.Color.Black;
            this.btnbuscarproducto.ColorClick = System.Drawing.Color.RoyalBlue;
            this.btnbuscarproducto.ColorHover = System.Drawing.Color.CornflowerBlue;
            this.btnbuscarproducto.ColorIconoHover = System.Drawing.Color.White;
            this.btnbuscarproducto.ColorTextoHover = System.Drawing.Color.White;
            this.btnbuscarproducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscarproducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscarproducto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbuscarproducto.ForeColor = System.Drawing.Color.Black;
            this.btnbuscarproducto.GrosorBorde = 0;
            this.btnbuscarproducto.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnbuscarproducto.IconColor = System.Drawing.Color.Black;
            this.btnbuscarproducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnbuscarproducto.IconSize = 35;
            this.btnbuscarproducto.Location = new System.Drawing.Point(242, 37);
            this.btnbuscarproducto.Name = "btnbuscarproducto";
            this.btnbuscarproducto.RadioBorde = 0;
            this.btnbuscarproducto.Size = new System.Drawing.Size(82, 46);
            this.btnbuscarproducto.TabIndex = 51;
            this.btnbuscarproducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnbuscarproducto.UseVisualStyleBackColor = false;
            this.btnbuscarproducto.Click += new System.EventHandler(this.btnbuscarproducto_Click);
            // 
            // txbproducto
            // 
            this.txbproducto.BackColor = System.Drawing.Color.White;
            this.txbproducto.ColorBorde = System.Drawing.Color.Gray;
            this.txbproducto.ColorBordeFocus = System.Drawing.Color.CornflowerBlue;
            this.txbproducto.ForeColor = System.Drawing.Color.DimGray;
            this.txbproducto.GrosorBorde = 2;
            this.txbproducto.Location = new System.Drawing.Point(112, 37);
            this.txbproducto.MaxLength = 32767;
            this.txbproducto.Name = "txbproducto";
            this.txbproducto.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txbproducto.PasswordChar = '\0';
            this.txbproducto.RadioBorde = 15;
            this.txbproducto.ReadOnly = false;
            this.txbproducto.Size = new System.Drawing.Size(124, 38);
            this.txbproducto.TabIndex = 29;
            this.txbproducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txbproducto.UseSystemPasswordChar = false;
            // 
            // btnbuscarcliente
            // 
            this.btnbuscarcliente.BackColor = System.Drawing.Color.White;
            this.btnbuscarcliente.ColorBorde = System.Drawing.Color.Black;
            this.btnbuscarcliente.ColorClick = System.Drawing.Color.RoyalBlue;
            this.btnbuscarcliente.ColorHover = System.Drawing.Color.CornflowerBlue;
            this.btnbuscarcliente.ColorIconoHover = System.Drawing.Color.White;
            this.btnbuscarcliente.ColorTextoHover = System.Drawing.Color.White;
            this.btnbuscarcliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscarcliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscarcliente.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbuscarcliente.ForeColor = System.Drawing.Color.Black;
            this.btnbuscarcliente.GrosorBorde = 0;
            this.btnbuscarcliente.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnbuscarcliente.IconColor = System.Drawing.Color.Black;
            this.btnbuscarcliente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnbuscarcliente.IconSize = 35;
            this.btnbuscarcliente.Location = new System.Drawing.Point(463, 46);
            this.btnbuscarcliente.Name = "btnbuscarcliente";
            this.btnbuscarcliente.RadioBorde = 0;
            this.btnbuscarcliente.Size = new System.Drawing.Size(82, 46);
            this.btnbuscarcliente.TabIndex = 50;
            this.btnbuscarcliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnbuscarcliente.UseVisualStyleBackColor = false;
            // 
            // txbcedula
            // 
            this.txbcedula.BackColor = System.Drawing.Color.White;
            this.txbcedula.ColorBorde = System.Drawing.Color.Gray;
            this.txbcedula.ColorBordeFocus = System.Drawing.Color.CornflowerBlue;
            this.txbcedula.ForeColor = System.Drawing.Color.DimGray;
            this.txbcedula.GrosorBorde = 2;
            this.txbcedula.Location = new System.Drawing.Point(310, 46);
            this.txbcedula.MaxLength = 32767;
            this.txbcedula.Name = "txbcedula";
            this.txbcedula.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txbcedula.PasswordChar = '\0';
            this.txbcedula.RadioBorde = 15;
            this.txbcedula.ReadOnly = false;
            this.txbcedula.Size = new System.Drawing.Size(137, 38);
            this.txbcedula.TabIndex = 29;
            this.txbcedula.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txbcedula.UseSystemPasswordChar = false;
            // 
            // txbcliente
            // 
            this.txbcliente.BackColor = System.Drawing.Color.White;
            this.txbcliente.ColorBorde = System.Drawing.Color.Gray;
            this.txbcliente.ColorBordeFocus = System.Drawing.Color.CornflowerBlue;
            this.txbcliente.ForeColor = System.Drawing.Color.DimGray;
            this.txbcliente.GrosorBorde = 2;
            this.txbcliente.Location = new System.Drawing.Point(82, 48);
            this.txbcliente.MaxLength = 32767;
            this.txbcliente.Name = "txbcliente";
            this.txbcliente.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txbcliente.PasswordChar = '\0';
            this.txbcliente.RadioBorde = 15;
            this.txbcliente.ReadOnly = false;
            this.txbcliente.Size = new System.Drawing.Size(128, 36);
            this.txbcliente.TabIndex = 28;
            this.txbcliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txbcliente.UseSystemPasswordChar = false;
            // 
            // txbfecha
            // 
            this.txbfecha.BackColor = System.Drawing.Color.White;
            this.txbfecha.ColorBorde = System.Drawing.Color.Gray;
            this.txbfecha.ColorBordeFocus = System.Drawing.Color.CornflowerBlue;
            this.txbfecha.ForeColor = System.Drawing.Color.DimGray;
            this.txbfecha.GrosorBorde = 2;
            this.txbfecha.Location = new System.Drawing.Point(62, 46);
            this.txbfecha.MaxLength = 32767;
            this.txbfecha.Name = "txbfecha";
            this.txbfecha.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txbfecha.PasswordChar = '\0';
            this.txbfecha.RadioBorde = 15;
            this.txbfecha.ReadOnly = false;
            this.txbfecha.Size = new System.Drawing.Size(124, 38);
            this.txbfecha.TabIndex = 28;
            this.txbfecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txbfecha.UseSystemPasswordChar = false;
            // 
            // txbcajero
            // 
            this.txbcajero.BackColor = System.Drawing.Color.White;
            this.txbcajero.ColorBorde = System.Drawing.Color.Gray;
            this.txbcajero.ColorBordeFocus = System.Drawing.Color.CornflowerBlue;
            this.txbcajero.ForeColor = System.Drawing.Color.DimGray;
            this.txbcajero.GrosorBorde = 2;
            this.txbcajero.Location = new System.Drawing.Point(284, 75);
            this.txbcajero.MaxLength = 32767;
            this.txbcajero.Name = "txbcajero";
            this.txbcajero.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txbcajero.PasswordChar = '\0';
            this.txbcajero.RadioBorde = 15;
            this.txbcajero.ReadOnly = false;
            this.txbcajero.Size = new System.Drawing.Size(175, 41);
            this.txbcajero.TabIndex = 27;
            this.txbcajero.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txbcajero.UseSystemPasswordChar = false;
            // 
            // cbvendedor
            // 
            this.cbvendedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbvendedor.BackColorModerno = System.Drawing.Color.WhiteSmoke;
            this.cbvendedor.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbvendedor.BorderRadius = 8;
            this.cbvendedor.BorderSize = 1;
            this.cbvendedor.DataSource = null;
            this.cbvendedor.DisplayMember = "";
            this.cbvendedor.ForeColor = System.Drawing.Color.DimGray;
            this.cbvendedor.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(66)))), ((int)(((byte)(210)))));
            this.cbvendedor.Location = new System.Drawing.Point(287, 22);
            this.cbvendedor.MinimumSize = new System.Drawing.Size(150, 30);
            this.cbvendedor.Name = "cbvendedor";
            this.cbvendedor.Padding = new System.Windows.Forms.Padding(1);
            this.cbvendedor.SelectedIndex = -1;
            this.cbvendedor.SelectedItem = null;
            this.cbvendedor.Size = new System.Drawing.Size(172, 31);
            this.cbvendedor.TabIndex = 26;
            this.cbvendedor.ValueMember = "";
            // 
            // btnVenta
            // 
            this.btnVenta.BackColor = System.Drawing.Color.White;
            this.btnVenta.ColorBorde = System.Drawing.Color.Black;
            this.btnVenta.ColorClick = System.Drawing.Color.RoyalBlue;
            this.btnVenta.ColorHover = System.Drawing.Color.CornflowerBlue;
            this.btnVenta.ColorIconoHover = System.Drawing.Color.White;
            this.btnVenta.ColorTextoHover = System.Drawing.Color.White;
            this.btnVenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVenta.FlatAppearance.BorderSize = 0;
            this.btnVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVenta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVenta.ForeColor = System.Drawing.Color.Black;
            this.btnVenta.GrosorBorde = 2;
            this.btnVenta.IconChar = FontAwesome.Sharp.IconChar.Tag;
            this.btnVenta.IconColor = System.Drawing.Color.RoyalBlue;
            this.btnVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnVenta.IconSize = 35;
            this.btnVenta.Location = new System.Drawing.Point(1316, 898);
            this.btnVenta.Name = "btnVenta";
            this.btnVenta.RadioBorde = 10;
            this.btnVenta.Size = new System.Drawing.Size(126, 99);
            this.btnVenta.TabIndex = 30;
            this.btnVenta.Text = "Crear venta";
            this.btnVenta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnVenta.UseVisualStyleBackColor = false;
            // 
            // txbtotalpagar
            // 
            this.txbtotalpagar.BackColor = System.Drawing.Color.White;
            this.txbtotalpagar.ColorBorde = System.Drawing.Color.Gray;
            this.txbtotalpagar.ColorBordeFocus = System.Drawing.Color.CornflowerBlue;
            this.txbtotalpagar.ForeColor = System.Drawing.Color.DimGray;
            this.txbtotalpagar.GrosorBorde = 2;
            this.txbtotalpagar.Location = new System.Drawing.Point(324, 934);
            this.txbtotalpagar.MaxLength = 32767;
            this.txbtotalpagar.Name = "txbtotalpagar";
            this.txbtotalpagar.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txbtotalpagar.PasswordChar = '\0';
            this.txbtotalpagar.RadioBorde = 15;
            this.txbtotalpagar.ReadOnly = false;
            this.txbtotalpagar.Size = new System.Drawing.Size(124, 38);
            this.txbtotalpagar.TabIndex = 34;
            this.txbtotalpagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txbtotalpagar.UseSystemPasswordChar = false;
            // 
            // Frmregistrarventa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1595, 1080);
            this.Controls.Add(this.txbtotalpagar);
            this.Controls.Add(this.txbtotalproductos);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnVenta);
            this.Controls.Add(this.lbllistausu);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Frmregistrarventa";
            this.Text = "Frmregistrarventa";
            this.Load += new System.EventHandler(this.Frmregistrarventa_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVStck)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbllistausu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private ComboBoxModerno cbvendedor;
        private TextBoxModerno txbcajero;
        private BotonModerno btnVenta;
        private System.Windows.Forms.DataGridView DGVStck;
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
        private TextBoxModerno txbfecha;
        private BotonModerno btnbuscarcliente;
        private TextBoxModerno txbcedula;
        private TextBoxModerno txbcliente;
        private BotonModerno btnagregarproducto;
        private BotonModerno btnbuscarproducto;
        private TextBoxModerno txbproducto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private TextBoxModerno txbtotalproductos;
        private TextBoxModerno txbtotalpagar;
    }
}