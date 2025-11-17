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
            this.TbCedula = new System.Windows.Forms.TextBox();
            this.TbPsw = new System.Windows.Forms.TextBox();
            this.txtCedula = new System.Windows.Forms.Label();
            this.txtpsw = new System.Windows.Forms.Label();
            this.BtonIngreso = new FontAwesome.Sharp.IconButton();
            this.BotonCancel = new FontAwesome.Sharp.IconButton();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            this.SuspendLayout();
            // 
            // Picture
            // 
            this.Picture.Image = ((System.Drawing.Image)(resources.GetObject("Picture.Image")));
            this.Picture.Location = new System.Drawing.Point(0, 0);
            this.Picture.Name = "Picture";
            this.Picture.Size = new System.Drawing.Size(207, 212);
            this.Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Picture.TabIndex = 2;
            this.Picture.TabStop = false;
            // 
            // TbCedula
            // 
            this.TbCedula.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.TbCedula.Location = new System.Drawing.Point(280, 51);
            this.TbCedula.Name = "TbCedula";
            this.TbCedula.Size = new System.Drawing.Size(209, 23);
            this.TbCedula.TabIndex = 3;
            // 
            // TbPsw
            // 
            this.TbPsw.BackColor = System.Drawing.SystemColors.Window;
            this.TbPsw.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbPsw.Location = new System.Drawing.Point(280, 120);
            this.TbPsw.Name = "TbPsw";
            this.TbPsw.PasswordChar = '*';
            this.TbPsw.Size = new System.Drawing.Size(209, 23);
            this.TbPsw.TabIndex = 4;
            this.TbPsw.TextChanged += new System.EventHandler(this.TbPsw_TextChanged);
            this.TbPsw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbPsw_KeyPress);
            // 
            // txtCedula
            // 
            this.txtCedula.AutoSize = true;
            this.txtCedula.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.txtCedula.Location = new System.Drawing.Point(280, 32);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(73, 15);
            this.txtCedula.TabIndex = 5;
            this.txtCedula.Text = "Documento";
            // 
            // txtpsw
            // 
            this.txtpsw.AutoSize = true;
            this.txtpsw.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.txtpsw.Location = new System.Drawing.Point(280, 101);
            this.txtpsw.Name = "txtpsw";
            this.txtpsw.Size = new System.Drawing.Size(72, 15);
            this.txtpsw.TabIndex = 6;
            this.txtpsw.Text = "Contraseña";
            // 
            // BtonIngreso
            // 
            this.BtonIngreso.BackColor = System.Drawing.Color.White;
            this.BtonIngreso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtonIngreso.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.BtonIngreso.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BtonIngreso.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.BtonIngreso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtonIngreso.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtonIngreso.IconChar = FontAwesome.Sharp.IconChar.DoorOpen;
            this.BtonIngreso.IconColor = System.Drawing.Color.ForestGreen;
            this.BtonIngreso.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtonIngreso.IconSize = 25;
            this.BtonIngreso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtonIngreso.Location = new System.Drawing.Point(280, 161);
            this.BtonIngreso.Name = "BtonIngreso";
            this.BtonIngreso.Size = new System.Drawing.Size(92, 31);
            this.BtonIngreso.TabIndex = 7;
            this.BtonIngreso.Text = "Ingresar";
            this.BtonIngreso.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtonIngreso.UseVisualStyleBackColor = false;
            this.BtonIngreso.Click += new System.EventHandler(this.BtonIngreso_Click);
            // 
            // BotonCancel
            // 
            this.BotonCancel.BackColor = System.Drawing.Color.White;
            this.BotonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BotonCancel.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.BotonCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BotonCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.BotonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BotonCancel.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.BotonCancel.IconChar = FontAwesome.Sharp.IconChar.CircleXmark;
            this.BotonCancel.IconColor = System.Drawing.Color.DarkRed;
            this.BotonCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BotonCancel.IconSize = 25;
            this.BotonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BotonCancel.Location = new System.Drawing.Point(397, 161);
            this.BotonCancel.Name = "BotonCancel";
            this.BotonCancel.Size = new System.Drawing.Size(92, 31);
            this.BotonCancel.TabIndex = 8;
            this.BotonCancel.Text = "Cancelar";
            this.BotonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BotonCancel.UseVisualStyleBackColor = false;
            this.BotonCancel.Click += new System.EventHandler(this.BotonCancel_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(482, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(557, 211);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BotonCancel);
            this.Controls.Add(this.BtonIngreso);
            this.Controls.Add(this.txtpsw);
            this.Controls.Add(this.txtCedula);
            this.Controls.Add(this.TbPsw);
            this.Controls.Add(this.TbCedula);
            this.Controls.Add(this.Picture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox Picture;
        private System.Windows.Forms.TextBox TbCedula;
        private System.Windows.Forms.TextBox TbPsw;
        private System.Windows.Forms.Label txtCedula;
        private System.Windows.Forms.Label txtpsw;
        private FontAwesome.Sharp.IconButton BtonIngreso;
        private FontAwesome.Sharp.IconButton BotonCancel;
        private System.Windows.Forms.Button button1;
    }
}