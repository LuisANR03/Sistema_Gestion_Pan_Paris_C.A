namespace Llamen_a_Dios
{
    partial class FrmCategoria
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
            this.label4 = new System.Windows.Forms.Label();
            this.CbEstado = new System.Windows.Forms.ComboBox();
            this.TBBuscar = new System.Windows.Forms.TextBox();
            this.txtid = new System.Windows.Forms.TextBox();
            this.lbllistcat = new System.Windows.Forms.Label();
            this.CBFiltro = new System.Windows.Forms.ComboBox();
            this.DGVCat = new System.Windows.Forms.DataGridView();
            this.BtnSelect = new System.Windows.Forms.DataGridViewButtonColumn();
            this.IdCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EdoValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.lblestado = new System.Windows.Forms.Label();
            this.tbDescripcion = new System.Windows.Forms.TextBox();
            this.lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnLimpiar = new FontAwesome.Sharp.IconButton();
            this.BtnBuscar = new FontAwesome.Sharp.IconButton();
            this.btnBorrar = new FontAwesome.Sharp.IconButton();
            this.BtnLimc = new FontAwesome.Sharp.IconButton();
            this.BtnGuardar = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCat)).BeginInit();
            this.SuspendLayout();
            // 
            // tbindice
            // 
            this.tbindice.Location = new System.Drawing.Point(168, 122);
            this.tbindice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbindice.Name = "tbindice";
            this.tbindice.Size = new System.Drawing.Size(34, 26);
            this.tbindice.TabIndex = 58;
            this.tbindice.Text = "-1";
            this.tbindice.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(144)))), ((int)(((byte)(211)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(685, 41);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 24);
            this.label4.TabIndex = 55;
            this.label4.Text = "Buscar por:";
            // 
            // CbEstado
            // 
            this.CbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CbEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbEstado.FormattingEnabled = true;
            this.CbEstado.Location = new System.Drawing.Point(34, 302);
            this.CbEstado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CbEstado.Name = "CbEstado";
            this.CbEstado.Size = new System.Drawing.Size(235, 28);
            this.CbEstado.TabIndex = 53;
            // 
            // TBBuscar
            // 
            this.TBBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.TBBuscar.Location = new System.Drawing.Point(956, 36);
            this.TBBuscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TBBuscar.Name = "TBBuscar";
            this.TBBuscar.Size = new System.Drawing.Size(199, 26);
            this.TBBuscar.TabIndex = 51;
            this.TBBuscar.TextChanged += new System.EventHandler(this.TBBuscar_TextChanged);
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(240, 122);
            this.txtid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(34, 26);
            this.txtid.TabIndex = 50;
            this.txtid.Text = "0";
            this.txtid.Visible = false;
            // 
            // lbllistcat
            // 
            this.lbllistcat.AutoSize = true;
            this.lbllistcat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(144)))), ((int)(((byte)(211)))));
            this.lbllistcat.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllistcat.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbllistcat.Location = new System.Drawing.Point(342, 32);
            this.lbllistcat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbllistcat.Name = "lbllistcat";
            this.lbllistcat.Size = new System.Drawing.Size(248, 31);
            this.lbllistcat.TabIndex = 49;
            this.lbllistcat.Text = "Lista de Categorias";
            // 
            // CBFiltro
            // 
            this.CBFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBFiltro.FormattingEnabled = true;
            this.CBFiltro.Location = new System.Drawing.Point(796, 38);
            this.CBFiltro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CBFiltro.Name = "CBFiltro";
            this.CBFiltro.Size = new System.Drawing.Size(152, 28);
            this.CBFiltro.TabIndex = 57;
            // 
            // DGVCat
            // 
            this.DGVCat.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVCat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVCat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVCat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BtnSelect,
            this.IdCategoria,
            this.Descripcion,
            this.EstadoValor,
            this.EdoValor});
            this.DGVCat.Location = new System.Drawing.Point(349, 86);
            this.DGVCat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DGVCat.MultiSelect = false;
            this.DGVCat.Name = "DGVCat";
            this.DGVCat.ReadOnly = true;
            this.DGVCat.RowHeadersWidth = 51;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.DGVCat.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVCat.RowTemplate.Height = 28;
            this.DGVCat.Size = new System.Drawing.Size(341, 499);
            this.DGVCat.TabIndex = 48;
            this.DGVCat.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVCat_CellContentClick);
            this.DGVCat.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DGVCat_CellPainting);
            // 
            // BtnSelect
            // 
            this.BtnSelect.HeaderText = "";
            this.BtnSelect.MinimumWidth = 6;
            this.BtnSelect.Name = "BtnSelect";
            this.BtnSelect.ReadOnly = true;
            this.BtnSelect.Width = 30;
            // 
            // IdCategoria
            // 
            this.IdCategoria.HeaderText = "Id";
            this.IdCategoria.MinimumWidth = 6;
            this.IdCategoria.Name = "IdCategoria";
            this.IdCategoria.ReadOnly = true;
            this.IdCategoria.Visible = false;
            this.IdCategoria.Width = 125;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.MinimumWidth = 6;
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 125;
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
            // EdoValor
            // 
            this.EdoValor.HeaderText = "Estado";
            this.EdoValor.MinimumWidth = 6;
            this.EdoValor.Name = "EdoValor";
            this.EdoValor.ReadOnly = true;
            this.EdoValor.Width = 125;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(82)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(35, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 31);
            this.label2.TabIndex = 47;
            this.label2.Text = "Detalles de Usuario";
            // 
            // lblestado
            // 
            this.lblestado.AutoSize = true;
            this.lblestado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(82)))));
            this.lblestado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblestado.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblestado.Location = new System.Drawing.Point(30, 269);
            this.lblestado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblestado.Name = "lblestado";
            this.lblestado.Size = new System.Drawing.Size(61, 20);
            this.lblestado.TabIndex = 42;
            this.lblestado.Text = "Estado";
            // 
            // tbDescripcion
            // 
            this.tbDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.tbDescripcion.Location = new System.Drawing.Point(34, 175);
            this.tbDescripcion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbDescripcion.Name = "tbDescripcion";
            this.tbDescripcion.Size = new System.Drawing.Size(240, 26);
            this.tbDescripcion.TabIndex = 37;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(82)))));
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbl.Location = new System.Drawing.Point(30, 132);
            this.lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(99, 20);
            this.lbl.TabIndex = 34;
            this.lbl.Text = "Descripcion";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(82)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 1080);
            this.label1.TabIndex = 33;
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
            this.BtnLimpiar.Location = new System.Drawing.Point(1224, 36);
            this.BtnLimpiar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(52, 31);
            this.BtnLimpiar.TabIndex = 56;
            this.BtnLimpiar.UseVisualStyleBackColor = false;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.BackColor = System.Drawing.Color.White;
            this.BtnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBuscar.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.BtnBuscar.IconColor = System.Drawing.Color.Black;
            this.BtnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnBuscar.IconSize = 18;
            this.BtnBuscar.Location = new System.Drawing.Point(1164, 36);
            this.BtnBuscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(52, 31);
            this.BtnBuscar.TabIndex = 52;
            this.BtnBuscar.UseVisualStyleBackColor = false;
            // 
            // btnBorrar
            // 
            this.btnBorrar.BackColor = System.Drawing.Color.White;
            this.btnBorrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBorrar.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.btnBorrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Firebrick;
            this.btnBorrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.btnBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnBorrar.ForeColor = System.Drawing.Color.Firebrick;
            this.btnBorrar.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.btnBorrar.IconColor = System.Drawing.Color.Firebrick;
            this.btnBorrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBorrar.IconSize = 16;
            this.btnBorrar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBorrar.Location = new System.Drawing.Point(34, 488);
            this.btnBorrar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(236, 34);
            this.btnBorrar.TabIndex = 46;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBorrar.UseVisualStyleBackColor = false;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // BtnLimc
            // 
            this.BtnLimc.BackColor = System.Drawing.Color.White;
            this.BtnLimc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLimc.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.BtnLimc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.BtnLimc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.BtnLimc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLimc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.BtnLimc.ForeColor = System.Drawing.Color.RoyalBlue;
            this.BtnLimc.IconChar = FontAwesome.Sharp.IconChar.Brush;
            this.BtnLimc.IconColor = System.Drawing.Color.RoyalBlue;
            this.BtnLimc.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnLimc.IconSize = 18;
            this.BtnLimc.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnLimc.Location = new System.Drawing.Point(34, 446);
            this.BtnLimc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnLimc.Name = "BtnLimc";
            this.BtnLimc.Rotation = 180D;
            this.BtnLimc.Size = new System.Drawing.Size(236, 34);
            this.BtnLimc.TabIndex = 45;
            this.BtnLimc.Text = "Limpiar";
            this.BtnLimc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnLimc.UseVisualStyleBackColor = false;
            this.BtnLimc.Click += new System.EventHandler(this.BtnLimc_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.BackColor = System.Drawing.Color.White;
            this.BtnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.ForestGreen;
            this.BtnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.ForestGreen;
            this.BtnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGreen;
            this.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.ForeColor = System.Drawing.Color.ForestGreen;
            this.BtnGuardar.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.BtnGuardar.IconColor = System.Drawing.Color.ForestGreen;
            this.BtnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnGuardar.IconSize = 16;
            this.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnGuardar.Location = new System.Drawing.Point(34, 405);
            this.BtnGuardar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(236, 34);
            this.BtnGuardar.TabIndex = 44;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // FrmCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(144)))), ((int)(((byte)(211)))));
            this.ClientSize = new System.Drawing.Size(1595, 1080);
            this.Controls.Add(this.tbindice);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CbEstado);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.TBBuscar);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.lbllistcat);
            this.Controls.Add(this.CBFiltro);
            this.Controls.Add(this.DGVCat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.BtnLimc);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.lblestado);
            this.Controls.Add(this.tbDescripcion);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "FrmCategoria";
            this.Text = "FrmCategoria";
            this.Load += new System.EventHandler(this.FrmCategoria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVCat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbindice;
        private FontAwesome.Sharp.IconButton BtnLimpiar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CbEstado;
        private FontAwesome.Sharp.IconButton BtnBuscar;
        private System.Windows.Forms.TextBox TBBuscar;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Label lbllistcat;
        private System.Windows.Forms.ComboBox CBFiltro;
        private System.Windows.Forms.DataGridView DGVCat;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton btnBorrar;
        private FontAwesome.Sharp.IconButton BtnLimc;
        private FontAwesome.Sharp.IconButton BtnGuardar;
        private System.Windows.Forms.Label lblestado;
        private System.Windows.Forms.TextBox tbDescripcion;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewButtonColumn BtnSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn EdoValor;
    }
}