namespace Llamen_a_Dios.Modales
{
    partial class mdRecetas
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
            this.panelModerno1 = new Llamen_a_Dios.PanelModerno();
            this.btnReceta = new BotonModerno();
            this.lbllistausu = new System.Windows.Forms.Label();
            this.groupBoxModerno1 = new Llamen_a_Dios.GroupBoxModerno();
            this.label6 = new System.Windows.Forms.Label();
            this.DGVStck = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IdIngrediente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CBFiltro = new Llamen_a_Dios.ComboBoxModerno();
            this.BtnLimpiar = new BotonModerno();
            this.pnlBuscador = new System.Windows.Forms.Panel();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.TBBuscar = new TextBoxModerno();
            this.btnCancelar = new BotonModerno();
            this.panelModerno1.SuspendLayout();
            this.groupBoxModerno1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVStck)).BeginInit();
            this.pnlBuscador.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelModerno1
            // 
            this.panelModerno1.BackColor = System.Drawing.Color.Transparent;
            this.panelModerno1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(203)))), ((int)(((byte)(154)))));
            this.panelModerno1.BorderRadius = 15;
            this.panelModerno1.Controls.Add(this.btnCancelar);
            this.panelModerno1.Controls.Add(this.btnReceta);
            this.panelModerno1.Controls.Add(this.lbllistausu);
            this.panelModerno1.Location = new System.Drawing.Point(55, 9);
            this.panelModerno1.Name = "panelModerno1";
            this.panelModerno1.RedondearAbajo = false;
            this.panelModerno1.Size = new System.Drawing.Size(1176, 100);
            this.panelModerno1.TabIndex = 96;
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
            this.btnReceta.Location = new System.Drawing.Point(917, 30);
            this.btnReceta.Name = "btnReceta";
            this.btnReceta.RadioBorde = 5;
            this.btnReceta.Size = new System.Drawing.Size(228, 45);
            this.btnReceta.TabIndex = 98;
            this.btnReceta.Text = "Guardar Receta";
            this.btnReceta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReceta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReceta.UseVisualStyleBackColor = false;
            this.btnReceta.Click += new System.EventHandler(this.btnReceta_Click);
            // 
            // lbllistausu
            // 
            this.lbllistausu.AutoSize = true;
            this.lbllistausu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(203)))), ((int)(((byte)(154)))));
            this.lbllistausu.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllistausu.ForeColor = System.Drawing.Color.White;
            this.lbllistausu.Location = new System.Drawing.Point(30, 34);
            this.lbllistausu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbllistausu.Name = "lbllistausu";
            this.lbllistausu.Size = new System.Drawing.Size(148, 31);
            this.lbllistausu.TabIndex = 42;
            this.lbllistausu.Text = "Ingredientes";
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
            this.groupBoxModerno1.Controls.Add(this.CBFiltro);
            this.groupBoxModerno1.Controls.Add(this.BtnLimpiar);
            this.groupBoxModerno1.Controls.Add(this.pnlBuscador);
            this.groupBoxModerno1.Location = new System.Drawing.Point(55, 90);
            this.groupBoxModerno1.Name = "groupBoxModerno1";
            this.groupBoxModerno1.RedondearAbajo = true;
            this.groupBoxModerno1.Size = new System.Drawing.Size(1176, 669);
            this.groupBoxModerno1.TabIndex = 97;
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
            this.Seleccionar,
            this.IdIngrediente,
            this.Nombre,
            this.Costo,
            this.Cantidad});
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
            this.DGVStck.RowHeadersVisible = false;
            this.DGVStck.RowHeadersWidth = 51;
            this.DGVStck.RowTemplate.Height = 40;
            this.DGVStck.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVStck.Size = new System.Drawing.Size(1116, 514);
            this.DGVStck.TabIndex = 48;
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "✔";
            this.Seleccionar.MinimumWidth = 6;
            this.Seleccionar.Name = "Seleccionar";
            // 
            // IdIngrediente
            // 
            this.IdIngrediente.HeaderText = "IdIngrediente";
            this.IdIngrediente.MinimumWidth = 6;
            this.IdIngrediente.Name = "IdIngrediente";
            this.IdIngrediente.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IdIngrediente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.IdIngrediente.Visible = false;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Ingrediente";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Nombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Costo
            // 
            this.Costo.HeaderText = "Costo Un";
            this.Costo.MinimumWidth = 6;
            this.Costo.Name = "Costo";
            this.Costo.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cant. a usar";
            this.Cantidad.MinimumWidth = 6;
            this.Cantidad.Name = "Cantidad";
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
            // 
            // pnlBuscador
            // 
            this.pnlBuscador.Controls.Add(this.iconPictureBox1);
            this.pnlBuscador.Controls.Add(this.TBBuscar);
            this.pnlBuscador.Location = new System.Drawing.Point(374, 66);
            this.pnlBuscador.Name = "pnlBuscador";
            this.pnlBuscador.Size = new System.Drawing.Size(714, 43);
            this.pnlBuscador.TabIndex = 79;
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
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.ColorBorde = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(48)))), ((int)(((byte)(23)))));
            this.btnCancelar.ColorClick = System.Drawing.Color.LightCoral;
            this.btnCancelar.ColorHover = System.Drawing.Color.Red;
            this.btnCancelar.ColorIconoHover = System.Drawing.Color.White;
            this.btnCancelar.ColorTextoHover = System.Drawing.Color.White;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(48)))), ((int)(((byte)(23)))));
            this.btnCancelar.GrosorBorde = 3;
            this.btnCancelar.IconChar = FontAwesome.Sharp.IconChar.Redo;
            this.btnCancelar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(48)))), ((int)(((byte)(23)))));
            this.btnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancelar.IconSize = 25;
            this.btnCancelar.Location = new System.Drawing.Point(653, 30);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.RadioBorde = 5;
            this.btnCancelar.Size = new System.Drawing.Size(228, 45);
            this.btnCancelar.TabIndex = 99;
            this.btnCancelar.Text = "Regresar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // mdRecetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1287, 769);
            this.Controls.Add(this.panelModerno1);
            this.Controls.Add(this.groupBoxModerno1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "mdRecetas";
            this.Text = "mdRecetas";
            this.Load += new System.EventHandler(this.mdRecetas_Load);
            this.panelModerno1.ResumeLayout(false);
            this.panelModerno1.PerformLayout();
            this.groupBoxModerno1.ResumeLayout(false);
            this.groupBoxModerno1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVStck)).EndInit();
            this.pnlBuscador.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PanelModerno panelModerno1;
        private System.Windows.Forms.Label lbllistausu;
        private GroupBoxModerno groupBoxModerno1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView DGVStck;
        private ComboBoxModerno CBFiltro;
        private BotonModerno BtnLimpiar;
        private System.Windows.Forms.Panel pnlBuscador;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private TextBoxModerno TBBuscar;
        private BotonModerno btnReceta;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdIngrediente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Costo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private BotonModerno btnCancelar;
    }
}