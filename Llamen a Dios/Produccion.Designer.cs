namespace Llamen_a_Dios
{
    partial class Produccion
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnGuardar = new BotonModerno();
            this.btnSugerenciaIA = new BotonModerno();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlAccent = new System.Windows.Forms.Panel();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.dgvProduccion = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSugerido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMerma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlContenedorGrid = new Llamen_a_Dios.PanelModerno();
            this.panelModerno1 = new Llamen_a_Dios.PanelModerno();
            this.groupBoxModerno1 = new Llamen_a_Dios.GroupBoxModerno();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduccion)).BeginInit();
            this.pnlContenedorGrid.SuspendLayout();
            this.panelModerno1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.btnGuardar);
            this.pnlHeader.Controls.Add(this.btnSugerenciaIA);
            this.pnlHeader.Controls.Add(this.panelModerno1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1595, 123);
            this.pnlHeader.TabIndex = 1;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(158)))), ((int)(((byte)(87)))));
            this.btnGuardar.ColorBorde = System.Drawing.Color.White;
            this.btnGuardar.ColorClick = System.Drawing.Color.RoyalBlue;
            this.btnGuardar.ColorHover = System.Drawing.Color.CornflowerBlue;
            this.btnGuardar.ColorIconoHover = System.Drawing.Color.White;
            this.btnGuardar.ColorTextoHover = System.Drawing.Color.White;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.GrosorBorde = 0;
            this.btnGuardar.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnGuardar.IconColor = System.Drawing.Color.White;
            this.btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardar.IconSize = 25;
            this.btnGuardar.Location = new System.Drawing.Point(1121, 45);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.RadioBorde = 20;
            this.btnGuardar.Size = new System.Drawing.Size(204, 49);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar Todo";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnSugerenciaIA
            // 
            this.btnSugerenciaIA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(84)))), ((int)(((byte)(147)))));
            this.btnSugerenciaIA.ColorBorde = System.Drawing.Color.White;
            this.btnSugerenciaIA.ColorClick = System.Drawing.Color.RoyalBlue;
            this.btnSugerenciaIA.ColorHover = System.Drawing.Color.CornflowerBlue;
            this.btnSugerenciaIA.ColorIconoHover = System.Drawing.Color.White;
            this.btnSugerenciaIA.ColorTextoHover = System.Drawing.Color.White;
            this.btnSugerenciaIA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSugerenciaIA.FlatAppearance.BorderSize = 0;
            this.btnSugerenciaIA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSugerenciaIA.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.btnSugerenciaIA.ForeColor = System.Drawing.Color.White;
            this.btnSugerenciaIA.GrosorBorde = 0;
            this.btnSugerenciaIA.IconChar = FontAwesome.Sharp.IconChar.MagicWandSparkles;
            this.btnSugerenciaIA.IconColor = System.Drawing.Color.White;
            this.btnSugerenciaIA.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSugerenciaIA.IconSize = 25;
            this.btnSugerenciaIA.Location = new System.Drawing.Point(870, 45);
            this.btnSugerenciaIA.Name = "btnSugerenciaIA";
            this.btnSugerenciaIA.RadioBorde = 20;
            this.btnSugerenciaIA.Size = new System.Drawing.Size(204, 49);
            this.btnSugerenciaIA.TabIndex = 4;
            this.btnSugerenciaIA.Text = "Sugerencia";
            this.btnSugerenciaIA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSugerenciaIA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSugerenciaIA.UseVisualStyleBackColor = false;
            this.btnSugerenciaIA.Click += new System.EventHandler(this.btnSugerenciaIA_Click);
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.White;
            this.lblSubtitulo.Location = new System.Drawing.Point(27, 68);
            this.lblSubtitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(447, 23);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "Gestione entradas de horno y registro de mermas diarias.";
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(23, 24);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(533, 43);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "Control de Producción";
            // 
            // pnlAccent
            // 
            this.pnlAccent.Location = new System.Drawing.Point(0, 0);
            this.pnlAccent.Name = "pnlAccent";
            this.pnlAccent.Size = new System.Drawing.Size(200, 100);
            this.pnlAccent.TabIndex = 0;
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(0, 0);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(100, 22);
            this.txtBusqueda.TabIndex = 0;
            // 
            // lblBuscar
            // 
            this.lblBuscar.Location = new System.Drawing.Point(0, 0);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(100, 23);
            this.lblBuscar.TabIndex = 0;
            // 
            // dgvProduccion
            // 
            this.dgvProduccion.AllowUserToAddRows = false;
            this.dgvProduccion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProduccion.BackgroundColor = System.Drawing.Color.White;
            this.dgvProduccion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProduccion.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvProduccion.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProduccion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvProduccion.ColumnHeadersHeight = 40;
            this.dgvProduccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProduccion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colProducto,
            this.colStock,
            this.colSugerido,
            this.colEntrada,
            this.colMerma});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProduccion.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvProduccion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProduccion.EnableHeadersVisualStyles = false;
            this.dgvProduccion.Location = new System.Drawing.Point(0, 0);
            this.dgvProduccion.Margin = new System.Windows.Forms.Padding(4);
            this.dgvProduccion.MultiSelect = false;
            this.dgvProduccion.Name = "dgvProduccion";
            this.dgvProduccion.RowHeadersVisible = false;
            this.dgvProduccion.RowHeadersWidth = 51;
            this.dgvProduccion.RowTemplate.Height = 40;
            this.dgvProduccion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvProduccion.Size = new System.Drawing.Size(1400, 615);
            this.dgvProduccion.TabIndex = 0;
            // 
            // colId
            // 
            this.colId.MinimumWidth = 6;
            this.colId.Name = "colId";
            this.colId.Visible = false;
            // 
            // colProducto
            // 
            this.colProducto.HeaderText = "PRODUCTO";
            this.colProducto.MinimumWidth = 6;
            this.colProducto.Name = "colProducto";
            this.colProducto.ReadOnly = true;
            // 
            // colStock
            // 
            this.colStock.HeaderText = "STOCK ACTUAL";
            this.colStock.MinimumWidth = 6;
            this.colStock.Name = "colStock";
            this.colStock.ReadOnly = true;
            // 
            // colSugerido
            // 
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.colSugerido.DefaultCellStyle = dataGridViewCellStyle7;
            this.colSugerido.HeaderText = "IA SUGERIDO";
            this.colSugerido.MinimumWidth = 6;
            this.colSugerido.Name = "colSugerido";
            this.colSugerido.ReadOnly = true;
            // 
            // colEntrada
            // 
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(255)))), ((int)(((byte)(250)))));
            this.colEntrada.DefaultCellStyle = dataGridViewCellStyle8;
            this.colEntrada.HeaderText = "HORNEADO (+)";
            this.colEntrada.MinimumWidth = 6;
            this.colEntrada.Name = "colEntrada";
            // 
            // colMerma
            // 
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.colMerma.DefaultCellStyle = dataGridViewCellStyle9;
            this.colMerma.HeaderText = "MERMA (-)";
            this.colMerma.MinimumWidth = 6;
            this.colMerma.Name = "colMerma";
            // 
            // pnlContenedorGrid
            // 
            this.pnlContenedorGrid.BackColor = System.Drawing.Color.White;
            this.pnlContenedorGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.pnlContenedorGrid.BorderRadius = 15;
            this.pnlContenedorGrid.Controls.Add(this.dgvProduccion);
            this.pnlContenedorGrid.Location = new System.Drawing.Point(33, 197);
            this.pnlContenedorGrid.Margin = new System.Windows.Forms.Padding(4);
            this.pnlContenedorGrid.Name = "pnlContenedorGrid";
            this.pnlContenedorGrid.RedondearAbajo = true;
            this.pnlContenedorGrid.Size = new System.Drawing.Size(1400, 615);
            this.pnlContenedorGrid.TabIndex = 0;
            // 
            // panelModerno1
            // 
            this.panelModerno1.BackColor = System.Drawing.Color.Transparent;
            this.panelModerno1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.panelModerno1.BorderRadius = 15;
            this.panelModerno1.Controls.Add(this.groupBoxModerno1);
            this.panelModerno1.Controls.Add(this.lblSubtitulo);
            this.panelModerno1.Controls.Add(this.lblTitulo);
            this.panelModerno1.Location = new System.Drawing.Point(12, 3);
            this.panelModerno1.Name = "panelModerno1";
            this.panelModerno1.RedondearAbajo = false;
            this.panelModerno1.Size = new System.Drawing.Size(1421, 864);
            this.panelModerno1.TabIndex = 93;
            // 
            // groupBoxModerno1
            // 
            this.groupBoxModerno1.BackColor = System.Drawing.Color.White;
            this.groupBoxModerno1.BackgroundColor = System.Drawing.Color.White;
            this.groupBoxModerno1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.groupBoxModerno1.BorderRadius = 15;
            this.groupBoxModerno1.BorderSize = 2;
            this.groupBoxModerno1.Location = new System.Drawing.Point(3, 118);
            this.groupBoxModerno1.Name = "groupBoxModerno1";
            this.groupBoxModerno1.RedondearAbajo = true;
            this.groupBoxModerno1.Size = new System.Drawing.Size(1457, 756);
            this.groupBoxModerno1.TabIndex = 4;
            this.groupBoxModerno1.TabStop = false;
            this.groupBoxModerno1.Text = "groupBoxModerno1";
            // 
            // Produccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(1595, 1080);
            this.Controls.Add(this.pnlContenedorGrid);
            this.Controls.Add(this.pnlHeader);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Produccion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Producción - Pan de Paris";
            this.Load += new System.EventHandler(this.Produccion_Load);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduccion)).EndInit();
            this.pnlContenedorGrid.ResumeLayout(false);
            this.panelModerno1.ResumeLayout(false);
            this.panelModerno1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.DataGridView dgvProduccion;
        private Llamen_a_Dios.PanelModerno pnlContenedorGrid;
        private System.Windows.Forms.Panel pnlAccent;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Label lblBuscar;

        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSugerido;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMerma;
        private BotonModerno btnGuardar;
        private BotonModerno btnSugerenciaIA;
        private PanelModerno panelModerno1;
        private GroupBoxModerno groupBoxModerno1;
    }
}