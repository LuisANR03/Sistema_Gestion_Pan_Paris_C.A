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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbid = new System.Windows.Forms.TextBox();
            this.lbllistausu = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbnombre = new System.Windows.Forms.TextBox();
            this.tbCedula = new System.Windows.Forms.TextBox();
            this.lblnombre = new System.Windows.Forms.Label();
            this.txtCedul = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBorrar = new FontAwesome.Sharp.IconButton();
            this.BtnLim = new FontAwesome.Sharp.IconButton();
            this.BtnGuardar = new FontAwesome.Sharp.IconButton();
            this.tbcorreo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbtlf = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CBFiltro = new System.Windows.Forms.ComboBox();
            this.BtnLimpiar = new FontAwesome.Sharp.IconButton();
            this.label3 = new System.Windows.Forms.Label();
            this.TBBuscar = new System.Windows.Forms.TextBox();
            this.tbdir = new System.Windows.Forms.TextBox();
            this.Telefono = new System.Windows.Forms.Label();
            this.DGVUs = new System.Windows.Forms.DataGridView();
            this.tbindice = new System.Windows.Forms.TextBox();
            this.CBestado = new System.Windows.Forms.ComboBox();
            this.BtnSelect = new System.Windows.Forms.DataGridViewButtonColumn();
            this.IdCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Correo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tlf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGVUs)).BeginInit();
            this.SuspendLayout();
            // 
            // tbid
            // 
            this.tbid.Location = new System.Drawing.Point(193, 54);
            this.tbid.Name = "tbid";
            this.tbid.Size = new System.Drawing.Size(28, 20);
            this.tbid.TabIndex = 45;
            this.tbid.Text = "0";
            this.tbid.Visible = false;
            // 
            // lbllistausu
            // 
            this.lbllistausu.AutoSize = true;
            this.lbllistausu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(157)))), ((int)(((byte)(217)))));
            this.lbllistausu.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllistausu.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbllistausu.Location = new System.Drawing.Point(310, 22);
            this.lbllistausu.Name = "lbllistausu";
            this.lbllistausu.Size = new System.Drawing.Size(166, 25);
            this.lbllistausu.TabIndex = 44;
            this.lbllistausu.Text = "Lista de Clientes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.label2.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(33, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 25);
            this.label2.TabIndex = 42;
            this.label2.Text = "Detalles de Clientes";
            // 
            // tbnombre
            // 
            this.tbnombre.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.tbnombre.Location = new System.Drawing.Point(35, 133);
            this.tbnombre.Name = "tbnombre";
            this.tbnombre.Size = new System.Drawing.Size(186, 23);
            this.tbnombre.TabIndex = 31;
            // 
            // tbCedula
            // 
            this.tbCedula.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.tbCedula.Location = new System.Drawing.Point(35, 80);
            this.tbCedula.Name = "tbCedula";
            this.tbCedula.Size = new System.Drawing.Size(186, 23);
            this.tbCedula.TabIndex = 30;
            // 
            // lblnombre
            // 
            this.lblnombre.AutoSize = true;
            this.lblnombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.lblnombre.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblnombre.Location = new System.Drawing.Point(35, 110);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(44, 13);
            this.lblnombre.TabIndex = 28;
            this.lblnombre.Text = "Nombre";
            // 
            // txtCedul
            // 
            this.txtCedul.AutoSize = true;
            this.txtCedul.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.txtCedul.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.txtCedul.Location = new System.Drawing.Point(34, 58);
            this.txtCedul.Name = "txtCedul";
            this.txtCedul.Size = new System.Drawing.Size(58, 13);
            this.txtCedul.TabIndex = 27;
            this.txtCedul.Text = "N# Cedula";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 488);
            this.label1.TabIndex = 26;
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
            this.btnBorrar.Location = new System.Drawing.Point(32, 452);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(189, 27);
            this.btnBorrar.TabIndex = 51;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBorrar.UseVisualStyleBackColor = false;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // BtnLim
            // 
            this.BtnLim.BackColor = System.Drawing.Color.White;
            this.BtnLim.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLim.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.BtnLim.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.BtnLim.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.BtnLim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLim.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.BtnLim.ForeColor = System.Drawing.Color.RoyalBlue;
            this.BtnLim.IconChar = FontAwesome.Sharp.IconChar.Brush;
            this.BtnLim.IconColor = System.Drawing.Color.RoyalBlue;
            this.BtnLim.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnLim.IconSize = 18;
            this.BtnLim.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnLim.Location = new System.Drawing.Point(32, 419);
            this.BtnLim.Name = "BtnLim";
            this.BtnLim.Rotation = 180D;
            this.BtnLim.Size = new System.Drawing.Size(189, 27);
            this.BtnLim.TabIndex = 50;
            this.BtnLim.Text = "Limpiar";
            this.BtnLim.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnLim.UseVisualStyleBackColor = false;
            this.BtnLim.Click += new System.EventHandler(this.BtnLim_Click);
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
            this.BtnGuardar.Location = new System.Drawing.Point(32, 386);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(189, 27);
            this.BtnGuardar.TabIndex = 49;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // tbcorreo
            // 
            this.tbcorreo.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.tbcorreo.Location = new System.Drawing.Point(35, 189);
            this.tbcorreo.Name = "tbcorreo";
            this.tbcorreo.Size = new System.Drawing.Size(186, 23);
            this.tbcorreo.TabIndex = 53;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(35, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 52;
            this.label4.Text = "Correo";
            // 
            // tbtlf
            // 
            this.tbtlf.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbtlf.Location = new System.Drawing.Point(33, 247);
            this.tbtlf.Name = "tbtlf";
            this.tbtlf.Size = new System.Drawing.Size(186, 23);
            this.tbtlf.TabIndex = 55;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(32, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 54;
            this.label5.Text = "Telefono";
            // 
            // CBFiltro
            // 
            this.CBFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBFiltro.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBFiltro.FormattingEnabled = true;
            this.CBFiltro.Location = new System.Drawing.Point(644, 28);
            this.CBFiltro.Name = "CBFiltro";
            this.CBFiltro.Size = new System.Drawing.Size(122, 23);
            this.CBFiltro.TabIndex = 59;
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
            this.BtnLimpiar.Location = new System.Drawing.Point(939, 26);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(42, 25);
            this.BtnLimpiar.TabIndex = 58;
            this.BtnLimpiar.UseVisualStyleBackColor = false;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(157)))), ((int)(((byte)(217)))));
            this.label3.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(555, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 18);
            this.label3.TabIndex = 57;
            this.label3.Text = "Buscar por:";
            // 
            // TBBuscar
            // 
            this.TBBuscar.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.TBBuscar.Location = new System.Drawing.Point(772, 27);
            this.TBBuscar.Name = "TBBuscar";
            this.TBBuscar.Size = new System.Drawing.Size(160, 23);
            this.TBBuscar.TabIndex = 56;
            this.TBBuscar.TextChanged += new System.EventHandler(this.TBBuscar_TextChanged);
            // 
            // tbdir
            // 
            this.tbdir.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.tbdir.Location = new System.Drawing.Point(32, 301);
            this.tbdir.Name = "tbdir";
            this.tbdir.Size = new System.Drawing.Size(189, 23);
            this.tbdir.TabIndex = 60;
            // 
            // Telefono
            // 
            this.Telefono.AutoSize = true;
            this.Telefono.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.Telefono.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Telefono.Location = new System.Drawing.Point(32, 277);
            this.Telefono.Name = "Telefono";
            this.Telefono.Size = new System.Drawing.Size(52, 13);
            this.Telefono.TabIndex = 61;
            this.Telefono.Text = "Direccion";
            // 
            // DGVUs
            // 
            this.DGVUs.AllowUserToAddRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVUs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
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
            this.DGVUs.Location = new System.Drawing.Point(308, 77);
            this.DGVUs.MultiSelect = false;
            this.DGVUs.Name = "DGVUs";
            this.DGVUs.ReadOnly = true;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.DGVUs.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DGVUs.RowTemplate.Height = 28;
            this.DGVUs.Size = new System.Drawing.Size(674, 399);
            this.DGVUs.TabIndex = 62;
            this.DGVUs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVUs_CellContentClick);
            this.DGVUs.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DGVUs_CellPainting);
            // 
            // tbindice
            // 
            this.tbindice.Location = new System.Drawing.Point(159, 54);
            this.tbindice.Name = "tbindice";
            this.tbindice.Size = new System.Drawing.Size(28, 20);
            this.tbindice.TabIndex = 63;
            this.tbindice.Text = "-1";
            this.tbindice.Visible = false;
            // 
            // CBestado
            // 
            this.CBestado.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.CBestado.FormattingEnabled = true;
            this.CBestado.Location = new System.Drawing.Point(32, 342);
            this.CBestado.Name = "CBestado";
            this.CBestado.Size = new System.Drawing.Size(189, 23);
            this.CBestado.TabIndex = 64;
            // 
            // BtnSelect
            // 
            this.BtnSelect.HeaderText = "";
            this.BtnSelect.Name = "BtnSelect";
            this.BtnSelect.ReadOnly = true;
            this.BtnSelect.Width = 30;
            // 
            // IdCliente
            // 
            this.IdCliente.HeaderText = "Id";
            this.IdCliente.Name = "IdCliente";
            this.IdCliente.ReadOnly = true;
            this.IdCliente.Visible = false;
            // 
            // Cedula
            // 
            this.Cedula.HeaderText = "Cedula";
            this.Cedula.Name = "Cedula";
            this.Cedula.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Correo
            // 
            this.Correo.HeaderText = "Correo";
            this.Correo.Name = "Correo";
            this.Correo.ReadOnly = true;
            // 
            // Tlf
            // 
            this.Tlf.HeaderText = "Telefono";
            this.Tlf.Name = "Tlf";
            this.Tlf.ReadOnly = true;
            this.Tlf.Width = 150;
            // 
            // Direccion
            // 
            this.Direccion.HeaderText = "Direccion";
            this.Direccion.Name = "Direccion";
            this.Direccion.ReadOnly = true;
            this.Direccion.Width = 150;
            // 
            // Valor
            // 
            this.Valor.HeaderText = "Estado";
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            this.Valor.Visible = false;
            // 
            // EstadoValor
            // 
            this.EstadoValor.HeaderText = "EstadoValor";
            this.EstadoValor.Name = "EstadoValor";
            this.EstadoValor.ReadOnly = true;
            this.EstadoValor.Visible = false;
            // 
            // FrmClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(157)))), ((int)(((byte)(217)))));
            this.ClientSize = new System.Drawing.Size(1037, 488);
            this.Controls.Add(this.CBestado);
            this.Controls.Add(this.tbindice);
            this.Controls.Add(this.DGVUs);
            this.Controls.Add(this.Telefono);
            this.Controls.Add(this.tbdir);
            this.Controls.Add(this.CBFiltro);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TBBuscar);
            this.Controls.Add(this.tbtlf);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbcorreo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.BtnLim);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.tbid);
            this.Controls.Add(this.lbllistausu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbnombre);
            this.Controls.Add(this.tbCedula);
            this.Controls.Add(this.lblnombre);
            this.Controls.Add(this.txtCedul);
            this.Controls.Add(this.label1);
            this.Name = "FrmClientes";
            this.Text = "FrmClientes";
            this.Load += new System.EventHandler(this.FrmClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVUs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbid;
        private System.Windows.Forms.Label lbllistausu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbnombre;
        private System.Windows.Forms.TextBox tbCedula;
        private System.Windows.Forms.Label lblnombre;
        private System.Windows.Forms.Label txtCedul;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton btnBorrar;
        private FontAwesome.Sharp.IconButton BtnLim;
        private FontAwesome.Sharp.IconButton BtnGuardar;
        private System.Windows.Forms.TextBox tbcorreo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbtlf;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CBFiltro;
        private FontAwesome.Sharp.IconButton BtnLimpiar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBBuscar;
        private System.Windows.Forms.TextBox tbdir;
        private System.Windows.Forms.Label Telefono;
        private System.Windows.Forms.DataGridView DGVUs;
        private System.Windows.Forms.TextBox tbindice;
        private System.Windows.Forms.ComboBox CBestado;
        private System.Windows.Forms.DataGridViewButtonColumn BtnSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Correo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tlf;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoValor;
    }
}