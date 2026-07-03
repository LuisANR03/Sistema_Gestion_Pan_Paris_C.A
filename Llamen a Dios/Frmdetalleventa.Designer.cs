namespace Llamen_a_Dios
{
    partial class Frmdetalleventa
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
            this.DGV = new System.Windows.Forms.DataGridView();
            this.pnlBuscador = new System.Windows.Forms.Panel();
            this.btnBuscador = new FontAwesome.Sharp.IconPictureBox();
            this.txtBusqueda = new TextBoxModerno();
            this.label3 = new System.Windows.Forms.Label();
            this.cbBusqueda = new Llamen_a_Dios.ComboBoxModerno();
            this.btnLimpiar = new BotonModerno();
            this.dtpInicio = new Llamen_a_Dios.ModernDatePicker();
            this.dtpFin = new Llamen_a_Dios.ModernDatePicker();
            this.lbldetalles = new System.Windows.Forms.Label();
            this.panelModerno1 = new Llamen_a_Dios.PanelModerno();
            this.groupBoxModerno1 = new Llamen_a_Dios.GroupBoxModerno();
            this.btnBuscarFecha = new FontAwesome.Sharp.IconPictureBox();
            this.Boton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.IdVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cajero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.pnlBuscador.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscador)).BeginInit();
            this.panelModerno1.SuspendLayout();
            this.groupBoxModerno1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscarFecha)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV.BackgroundColor = System.Drawing.Color.White;
            this.DGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.ColumnHeadersHeight = 40;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Boton,
            this.IdVenta,
            this.NFactura,
            this.FechaVenta,
            this.Cliente,
            this.Cajero,
            this.Vendedor,
            this.Total});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(51)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGV.EnableHeadersVisualStyles = false;
            this.DGV.Location = new System.Drawing.Point(27, 179);
            this.DGV.Margin = new System.Windows.Forms.Padding(4);
            this.DGV.MultiSelect = false;
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.RowHeadersVisible = false;
            this.DGV.RowHeadersWidth = 51;
            this.DGV.RowTemplate.Height = 40;
            this.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV.Size = new System.Drawing.Size(1286, 835);
            this.DGV.TabIndex = 36;
            this.DGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellContentClick);
            // 
            // pnlBuscador
            // 
            this.pnlBuscador.Controls.Add(this.btnBuscador);
            this.pnlBuscador.Controls.Add(this.txtBusqueda);
            this.pnlBuscador.Location = new System.Drawing.Point(915, 102);
            this.pnlBuscador.Name = "pnlBuscador";
            this.pnlBuscador.Size = new System.Drawing.Size(333, 43);
            this.pnlBuscador.TabIndex = 75;
            // 
            // btnBuscador
            // 
            this.btnBuscador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscador.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscador.ForeColor = System.Drawing.Color.LightGray;
            this.btnBuscador.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnBuscador.IconColor = System.Drawing.Color.LightGray;
            this.btnBuscador.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnBuscador.IconSize = 35;
            this.btnBuscador.Location = new System.Drawing.Point(11, 5);
            this.btnBuscador.Name = "btnBuscador";
            this.btnBuscador.Size = new System.Drawing.Size(35, 36);
            this.btnBuscador.TabIndex = 44;
            this.btnBuscador.TabStop = false;
            this.btnBuscador.Click += new System.EventHandler(this.btnBuscador_Click);
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.BackColor = System.Drawing.Color.White;
            this.txtBusqueda.ColorBorde = System.Drawing.Color.Gray;
            this.txtBusqueda.ColorBordeFocus = System.Drawing.Color.Gray;
            this.txtBusqueda.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txtBusqueda.ForeColor = System.Drawing.Color.DimGray;
            this.txtBusqueda.GrosorBorde = 0;
            this.txtBusqueda.Location = new System.Drawing.Point(56, 2);
            this.txtBusqueda.MaxLength = 32767;
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtBusqueda.PasswordChar = '\0';
            this.txtBusqueda.RadioBorde = 5;
            this.txtBusqueda.ReadOnly = false;
            this.txtBusqueda.Size = new System.Drawing.Size(391, 40);
            this.txtBusqueda.TabIndex = 43;
            this.txtBusqueda.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBusqueda.UseSystemPasswordChar = false;
            this.txtBusqueda._TextChanged += new System.EventHandler(this.txtBusqueda__TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(579, 106);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 28);
            this.label3.TabIndex = 73;
            this.label3.Text = "Buscar por:";
            // 
            // cbBusqueda
            // 
            this.cbBusqueda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbBusqueda.BackColorModerno = System.Drawing.Color.WhiteSmoke;
            this.cbBusqueda.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbBusqueda.BorderRadius = 8;
            this.cbBusqueda.BorderSize = 1;
            this.cbBusqueda.DataSource = null;
            this.cbBusqueda.DisplayMember = "";
            this.cbBusqueda.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cbBusqueda.ForeColor = System.Drawing.Color.DimGray;
            this.cbBusqueda.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(66)))), ((int)(((byte)(210)))));
            this.cbBusqueda.Location = new System.Drawing.Point(695, 102);
            this.cbBusqueda.MinimumSize = new System.Drawing.Size(150, 30);
            this.cbBusqueda.Name = "cbBusqueda";
            this.cbBusqueda.Padding = new System.Windows.Forms.Padding(1);
            this.cbBusqueda.SelectedIndex = -1;
            this.cbBusqueda.SelectedItem = null;
            this.cbBusqueda.SelectedValue = null;
            this.cbBusqueda.Size = new System.Drawing.Size(202, 43);
            this.cbBusqueda.TabIndex = 74;
            this.cbBusqueda.ValueMember = "";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.ColorBorde = System.Drawing.Color.White;
            this.btnLimpiar.ColorClick = System.Drawing.Color.AliceBlue;
            this.btnLimpiar.ColorHover = System.Drawing.Color.Gainsboro;
            this.btnLimpiar.ColorIconoHover = System.Drawing.Color.Black;
            this.btnLimpiar.ColorTextoHover = System.Drawing.Color.White;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.GrosorBorde = 0;
            this.btnLimpiar.IconChar = FontAwesome.Sharp.IconChar.Brush;
            this.btnLimpiar.IconColor = System.Drawing.Color.Black;
            this.btnLimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLimpiar.IconSize = 25;
            this.btnLimpiar.Location = new System.Drawing.Point(1264, 105);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.RadioBorde = 5;
            this.btnLimpiar.Rotation = 180D;
            this.btnLimpiar.Size = new System.Drawing.Size(48, 36);
            this.btnLimpiar.TabIndex = 77;
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // dtpInicio
            // 
            this.dtpInicio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpInicio.Location = new System.Drawing.Point(27, 110);
            this.dtpInicio.MinimumSize = new System.Drawing.Size(4, 35);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(236, 35);
            this.dtpInicio.TabIndex = 78;
            // 
            // dtpFin
            // 
            this.dtpFin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFin.Location = new System.Drawing.Point(282, 110);
            this.dtpFin.MinimumSize = new System.Drawing.Size(4, 35);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(236, 35);
            this.dtpFin.TabIndex = 79;
            // 
            // lbldetalles
            // 
            this.lbldetalles.AutoSize = true;
            this.lbldetalles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.lbldetalles.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldetalles.ForeColor = System.Drawing.Color.White;
            this.lbldetalles.Location = new System.Drawing.Point(40, 27);
            this.lbldetalles.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbldetalles.Name = "lbldetalles";
            this.lbldetalles.Size = new System.Drawing.Size(209, 31);
            this.lbldetalles.TabIndex = 74;
            this.lbldetalles.Text = "Detalles de Ventas";
            // 
            // panelModerno1
            // 
            this.panelModerno1.BackColor = System.Drawing.Color.Transparent;
            this.panelModerno1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.panelModerno1.BorderRadius = 15;
            this.panelModerno1.Controls.Add(this.lbldetalles);
            this.panelModerno1.Location = new System.Drawing.Point(107, 41);
            this.panelModerno1.Name = "panelModerno1";
            this.panelModerno1.RedondearAbajo = false;
            this.panelModerno1.Size = new System.Drawing.Size(1349, 95);
            this.panelModerno1.TabIndex = 80;
            // 
            // groupBoxModerno1
            // 
            this.groupBoxModerno1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.groupBoxModerno1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.groupBoxModerno1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.groupBoxModerno1.BorderRadius = 15;
            this.groupBoxModerno1.BorderSize = 2;
            this.groupBoxModerno1.Controls.Add(this.btnBuscarFecha);
            this.groupBoxModerno1.Controls.Add(this.dtpInicio);
            this.groupBoxModerno1.Controls.Add(this.DGV);
            this.groupBoxModerno1.Controls.Add(this.btnLimpiar);
            this.groupBoxModerno1.Controls.Add(this.dtpFin);
            this.groupBoxModerno1.Controls.Add(this.pnlBuscador);
            this.groupBoxModerno1.Controls.Add(this.cbBusqueda);
            this.groupBoxModerno1.Controls.Add(this.label3);
            this.groupBoxModerno1.Location = new System.Drawing.Point(108, 59);
            this.groupBoxModerno1.Name = "groupBoxModerno1";
            this.groupBoxModerno1.RedondearAbajo = true;
            this.groupBoxModerno1.Size = new System.Drawing.Size(1348, 1050);
            this.groupBoxModerno1.TabIndex = 81;
            this.groupBoxModerno1.TabStop = false;
            // 
            // btnBuscarFecha
            // 
            this.btnBuscarFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscarFecha.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscarFecha.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarFecha.ForeColor = System.Drawing.Color.LightGray;
            this.btnBuscarFecha.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnBuscarFecha.IconColor = System.Drawing.Color.LightGray;
            this.btnBuscarFecha.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnBuscarFecha.IconSize = 35;
            this.btnBuscarFecha.Location = new System.Drawing.Point(524, 110);
            this.btnBuscarFecha.Name = "btnBuscarFecha";
            this.btnBuscarFecha.Size = new System.Drawing.Size(35, 36);
            this.btnBuscarFecha.TabIndex = 45;
            this.btnBuscarFecha.TabStop = false;
            this.btnBuscarFecha.Click += new System.EventHandler(this.btnBuscarFecha_Click);
            // 
            // Boton
            // 
            this.Boton.FillWeight = 8.672823F;
            this.Boton.HeaderText = "";
            this.Boton.MinimumWidth = 6;
            this.Boton.Name = "Boton";
            this.Boton.ReadOnly = true;
            // 
            // IdVenta
            // 
            this.IdVenta.HeaderText = "IdVenta";
            this.IdVenta.MinimumWidth = 6;
            this.IdVenta.Name = "IdVenta";
            this.IdVenta.ReadOnly = true;
            this.IdVenta.Visible = false;
            // 
            // NFactura
            // 
            this.NFactura.FillWeight = 20F;
            this.NFactura.HeaderText = "Factura";
            this.NFactura.MinimumWidth = 6;
            this.NFactura.Name = "NFactura";
            this.NFactura.ReadOnly = true;
            // 
            // FechaVenta
            // 
            this.FechaVenta.FillWeight = 22.88012F;
            this.FechaVenta.HeaderText = "Fecha";
            this.FechaVenta.MinimumWidth = 6;
            this.FechaVenta.Name = "FechaVenta";
            this.FechaVenta.ReadOnly = true;
            // 
            // Cliente
            // 
            this.Cliente.FillWeight = 22.88012F;
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.MinimumWidth = 6;
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
            // 
            // Cajero
            // 
            this.Cajero.FillWeight = 22.88012F;
            this.Cajero.HeaderText = "Cajero";
            this.Cajero.MinimumWidth = 6;
            this.Cajero.Name = "Cajero";
            this.Cajero.ReadOnly = true;
            // 
            // Vendedor
            // 
            this.Vendedor.HeaderText = "Vendedor";
            this.Vendedor.MinimumWidth = 6;
            this.Vendedor.Name = "Vendedor";
            this.Vendedor.ReadOnly = true;
            this.Vendedor.Visible = false;
            // 
            // Total
            // 
            this.Total.FillWeight = 22.88012F;
            this.Total.HeaderText = "Total";
            this.Total.MinimumWidth = 6;
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // Frmdetalleventa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1595, 1175);
            this.Controls.Add(this.panelModerno1);
            this.Controls.Add(this.groupBoxModerno1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frmdetalleventa";
            this.Text = "Frmdetalleventa";
            this.Load += new System.EventHandler(this.Frmdetalleventa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.pnlBuscador.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscador)).EndInit();
            this.panelModerno1.ResumeLayout(false);
            this.panelModerno1.PerformLayout();
            this.groupBoxModerno1.ResumeLayout(false);
            this.groupBoxModerno1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscarFecha)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Panel pnlBuscador;
        private FontAwesome.Sharp.IconPictureBox btnBuscador;
        private TextBoxModerno txtBusqueda;
        private System.Windows.Forms.Label label3;
        private ComboBoxModerno cbBusqueda;
        private BotonModerno btnLimpiar;
        private ModernDatePicker dtpInicio;
        private ModernDatePicker dtpFin;
        private System.Windows.Forms.Label lbldetalles;
        private PanelModerno panelModerno1;
        private GroupBoxModerno groupBoxModerno1;
        private FontAwesome.Sharp.IconPictureBox btnBuscarFecha;
        private System.Windows.Forms.DataGridViewButtonColumn Boton;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn NFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cajero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
    }
}