namespace Llamen_a_Dios
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.Picture = new System.Windows.Forms.PictureBox();
            this.txtCedula = new System.Windows.Forms.Label();
            this.txtpsw = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tbmcedula = new TextBoxModerno();
            this.tbmcontraseña = new TextBoxModerno();
            this.btnmcerrar = new BotonModerno();
            this.btnmingresar = new BotonModerno();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            this.SuspendLayout();
            // 
            // Picture
            // 
            this.Picture.Image = ((System.Drawing.Image)(resources.GetObject("Picture.Image")));
            this.Picture.Location = new System.Drawing.Point(-1, -2);
            this.Picture.Margin = new System.Windows.Forms.Padding(4);
            this.Picture.Name = "Picture";
            this.Picture.Size = new System.Drawing.Size(437, 445);
            this.Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Picture.TabIndex = 2;
            this.Picture.TabStop = false;
            // 
            // txtCedula
            // 
            this.txtCedula.AutoSize = true;
            this.txtCedula.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCedula.Location = new System.Drawing.Point(595, 60);
            this.txtCedula.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(112, 25);
            this.txtCedula.TabIndex = 5;
            this.txtCedula.Text = "Documento";
            // 
            // txtpsw
            // 
            this.txtpsw.AutoSize = true;
            this.txtpsw.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpsw.Location = new System.Drawing.Point(593, 197);
            this.txtpsw.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtpsw.Name = "txtpsw";
            this.txtpsw.Size = new System.Drawing.Size(114, 25);
            this.txtpsw.TabIndex = 6;
            this.txtpsw.Text = "Contraseña";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(843, 45);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 9;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbmcedula
            // 
            this.tbmcedula.BackColor = System.Drawing.Color.White;
            this.tbmcedula.ColorBorde = System.Drawing.Color.Gray;
            this.tbmcedula.ColorBordeFocus = System.Drawing.Color.CornflowerBlue;
            this.tbmcedula.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbmcedula.ForeColor = System.Drawing.Color.DimGray;
            this.tbmcedula.GrosorBorde = 2;
            this.tbmcedula.Location = new System.Drawing.Point(598, 104);
            this.tbmcedula.MaxLength = 32767;
            this.tbmcedula.Name = "tbmcedula";
            this.tbmcedula.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tbmcedula.PasswordChar = '\0';
            this.tbmcedula.RadioBorde = 5;
            this.tbmcedula.ReadOnly = false;
            this.tbmcedula.Size = new System.Drawing.Size(408, 54);
            this.tbmcedula.TabIndex = 15;
            this.tbmcedula.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbmcedula.UseSystemPasswordChar = false;
            // 
            // tbmcontraseña
            // 
            this.tbmcontraseña.BackColor = System.Drawing.Color.White;
            this.tbmcontraseña.ColorBorde = System.Drawing.Color.Gray;
            this.tbmcontraseña.ColorBordeFocus = System.Drawing.Color.CornflowerBlue;
            this.tbmcontraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbmcontraseña.ForeColor = System.Drawing.Color.DimGray;
            this.tbmcontraseña.GrosorBorde = 2;
            this.tbmcontraseña.Location = new System.Drawing.Point(598, 244);
            this.tbmcontraseña.MaxLength = 32767;
            this.tbmcontraseña.Name = "tbmcontraseña";
            this.tbmcontraseña.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tbmcontraseña.PasswordChar = '*';
            this.tbmcontraseña.RadioBorde = 5;
            this.tbmcontraseña.ReadOnly = false;
            this.tbmcontraseña.Size = new System.Drawing.Size(408, 54);
            this.tbmcontraseña.TabIndex = 14;
            this.tbmcontraseña.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbmcontraseña.UseSystemPasswordChar = false;
            // 
            // btnmcerrar
            // 
            this.btnmcerrar.BackColor = System.Drawing.Color.White;
            this.btnmcerrar.ColorBorde = System.Drawing.Color.Red;
            this.btnmcerrar.ColorClick = System.Drawing.Color.DarkRed;
            this.btnmcerrar.ColorHover = System.Drawing.Color.Red;
            this.btnmcerrar.ColorIconoHover = System.Drawing.Color.White;
            this.btnmcerrar.ColorTextoHover = System.Drawing.Color.White;
            this.btnmcerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnmcerrar.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.btnmcerrar.FlatAppearance.BorderSize = 0;
            this.btnmcerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmcerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnmcerrar.ForeColor = System.Drawing.Color.Red;
            this.btnmcerrar.GrosorBorde = 2;
            this.btnmcerrar.IconChar = FontAwesome.Sharp.IconChar.CircleXmark;
            this.btnmcerrar.IconColor = System.Drawing.Color.Red;
            this.btnmcerrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnmcerrar.IconSize = 35;
            this.btnmcerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnmcerrar.Location = new System.Drawing.Point(805, 323);
            this.btnmcerrar.Name = "btnmcerrar";
            this.btnmcerrar.RadioBorde = 10;
            this.btnmcerrar.Size = new System.Drawing.Size(201, 50);
            this.btnmcerrar.TabIndex = 11;
            this.btnmcerrar.Text = "Salir";
            this.btnmcerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnmcerrar.UseVisualStyleBackColor = false;
            this.btnmcerrar.Click += new System.EventHandler(this.btnmcerrar_Click);
            // 
            // btnmingresar
            // 
            this.btnmingresar.BackColor = System.Drawing.Color.Green;
            this.btnmingresar.ColorBorde = System.Drawing.Color.LimeGreen;
            this.btnmingresar.ColorClick = System.Drawing.Color.PaleGreen;
            this.btnmingresar.ColorHover = System.Drawing.Color.ForestGreen;
            this.btnmingresar.ColorIconoHover = System.Drawing.Color.White;
            this.btnmingresar.ColorTextoHover = System.Drawing.Color.White;
            this.btnmingresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnmingresar.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnmingresar.FlatAppearance.BorderSize = 0;
            this.btnmingresar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PaleGreen;
            this.btnmingresar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.ForestGreen;
            this.btnmingresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmingresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnmingresar.ForeColor = System.Drawing.Color.White;
            this.btnmingresar.GrosorBorde = 2;
            this.btnmingresar.IconChar = FontAwesome.Sharp.IconChar.DoorOpen;
            this.btnmingresar.IconColor = System.Drawing.Color.White;
            this.btnmingresar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnmingresar.IconSize = 35;
            this.btnmingresar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnmingresar.Location = new System.Drawing.Point(598, 323);
            this.btnmingresar.Name = "btnmingresar";
            this.btnmingresar.RadioBorde = 10;
            this.btnmingresar.Size = new System.Drawing.Size(201, 50);
            this.btnmingresar.TabIndex = 10;
            this.btnmingresar.Text = "Ingresar";
            this.btnmingresar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnmingresar.UseVisualStyleBackColor = false;
            this.btnmingresar.Click += new System.EventHandler(this.btnmingresar_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1142, 442);
            this.Controls.Add(this.tbmcedula);
            this.Controls.Add(this.tbmcontraseña);
            this.Controls.Add(this.btnmcerrar);
            this.Controls.Add(this.btnmingresar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtpsw);
            this.Controls.Add(this.txtCedula);
            this.Controls.Add(this.Picture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox Picture;
        private System.Windows.Forms.Label txtCedula;
        private System.Windows.Forms.Label txtpsw;
        private System.Windows.Forms.Button button1;
        private BotonModerno btnmingresar;
        private BotonModerno btnmcerrar;
        private TextBoxModerno tbmcontraseña;
        private TextBoxModerno tbmcedula;
    }
}