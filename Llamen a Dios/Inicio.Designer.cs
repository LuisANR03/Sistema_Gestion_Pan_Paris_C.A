namespace Llamen_a_Dios
{
    partial class Inicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.MenuTitulo = new System.Windows.Forms.MenuStrip();
            this.MenuUs = new FontAwesome.Sharp.IconMenuItem();
            this.MenuVentas = new FontAwesome.Sharp.IconMenuItem();
            this.submenuregistrarventa = new FontAwesome.Sharp.IconMenuItem();
            this.submenudetalleventa = new FontAwesome.Sharp.IconMenuItem();
            this.MenuClient = new FontAwesome.Sharp.IconMenuItem();
            this.MenuInformes = new FontAwesome.Sharp.IconMenuItem();
            this.MenuStock = new FontAwesome.Sharp.IconMenuItem();
            this.submenuinv = new FontAwesome.Sharp.IconMenuItem();
            this.submenucategorias = new FontAwesome.Sharp.IconMenuItem();
            this.MenuAcerca = new FontAwesome.Sharp.IconMenuItem();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.Textotitulo = new System.Windows.Forms.Label();
            this.Contenedor = new System.Windows.Forms.Panel();
            this.labeluser = new System.Windows.Forms.Label();
            this.lblnombreuser = new System.Windows.Forms.Label();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.MenuTitulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuTitulo
            // 
            this.MenuTitulo.BackColor = System.Drawing.Color.White;
            this.MenuTitulo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuUs,
            this.MenuVentas,
            this.MenuClient,
            this.MenuInformes,
            this.MenuStock,
            this.MenuAcerca});
            this.MenuTitulo.Location = new System.Drawing.Point(0, 60);
            this.MenuTitulo.Name = "MenuTitulo";
            this.MenuTitulo.Size = new System.Drawing.Size(1064, 73);
            this.MenuTitulo.TabIndex = 0;
            this.MenuTitulo.Text = "menuStrip1";
            // 
            // MenuUs
            // 
            this.MenuUs.AutoSize = false;
            this.MenuUs.IconChar = FontAwesome.Sharp.IconChar.UsersGear;
            this.MenuUs.IconColor = System.Drawing.Color.Black;
            this.MenuUs.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.MenuUs.IconSize = 50;
            this.MenuUs.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuUs.Name = "MenuUs";
            this.MenuUs.Size = new System.Drawing.Size(80, 69);
            this.MenuUs.Text = "Usuarios";
            this.MenuUs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuUs.Click += new System.EventHandler(this.MenuUs_Click);
            // 
            // MenuVentas
            // 
            this.MenuVentas.AutoSize = false;
            this.MenuVentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuregistrarventa,
            this.submenudetalleventa});
            this.MenuVentas.IconChar = FontAwesome.Sharp.IconChar.Tag;
            this.MenuVentas.IconColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MenuVentas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.MenuVentas.IconSize = 50;
            this.MenuVentas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuVentas.Name = "MenuVentas";
            this.MenuVentas.Size = new System.Drawing.Size(80, 69);
            this.MenuVentas.Text = "Ventas";
            this.MenuVentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // submenuregistrarventa
            // 
            this.submenuregistrarventa.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuregistrarventa.IconColor = System.Drawing.Color.Black;
            this.submenuregistrarventa.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuregistrarventa.Name = "submenuregistrarventa";
            this.submenuregistrarventa.Size = new System.Drawing.Size(180, 22);
            this.submenuregistrarventa.Text = "Registrar";
            this.submenuregistrarventa.Click += new System.EventHandler(this.submenuregistrarventa_Click);
            // 
            // submenudetalleventa
            // 
            this.submenudetalleventa.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenudetalleventa.IconColor = System.Drawing.Color.Black;
            this.submenudetalleventa.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenudetalleventa.Name = "submenudetalleventa";
            this.submenudetalleventa.Size = new System.Drawing.Size(180, 22);
            this.submenudetalleventa.Text = "Ver Detalles";
            this.submenudetalleventa.Click += new System.EventHandler(this.submenudetalleventa_Click);
            // 
            // MenuClient
            // 
            this.MenuClient.AutoSize = false;
            this.MenuClient.IconChar = FontAwesome.Sharp.IconChar.UserGroup;
            this.MenuClient.IconColor = System.Drawing.Color.Black;
            this.MenuClient.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.MenuClient.IconSize = 50;
            this.MenuClient.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuClient.Name = "MenuClient";
            this.MenuClient.Size = new System.Drawing.Size(80, 69);
            this.MenuClient.Text = "Clientes";
            this.MenuClient.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuClient.Click += new System.EventHandler(this.MenuClient_Click);
            // 
            // MenuInformes
            // 
            this.MenuInformes.AutoSize = false;
            this.MenuInformes.IconChar = FontAwesome.Sharp.IconChar.ChartBar;
            this.MenuInformes.IconColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MenuInformes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.MenuInformes.IconSize = 50;
            this.MenuInformes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuInformes.Name = "MenuInformes";
            this.MenuInformes.Size = new System.Drawing.Size(80, 69);
            this.MenuInformes.Text = "Informes";
            this.MenuInformes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuInformes.Click += new System.EventHandler(this.MenuInformes_Click);
            // 
            // MenuStock
            // 
            this.MenuStock.AutoSize = false;
            this.MenuStock.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuinv,
            this.submenucategorias});
            this.MenuStock.IconChar = FontAwesome.Sharp.IconChar.BoxOpen;
            this.MenuStock.IconColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MenuStock.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.MenuStock.IconSize = 50;
            this.MenuStock.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuStock.Name = "MenuStock";
            this.MenuStock.Size = new System.Drawing.Size(80, 69);
            this.MenuStock.Text = "Stock";
            this.MenuStock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // submenuinv
            // 
            this.submenuinv.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuinv.IconColor = System.Drawing.Color.Black;
            this.submenuinv.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuinv.Name = "submenuinv";
            this.submenuinv.Size = new System.Drawing.Size(180, 22);
            this.submenuinv.Text = "Inventario";
            this.submenuinv.Click += new System.EventHandler(this.submenuinv_Click);
            // 
            // submenucategorias
            // 
            this.submenucategorias.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenucategorias.IconColor = System.Drawing.Color.Black;
            this.submenucategorias.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenucategorias.Name = "submenucategorias";
            this.submenucategorias.Size = new System.Drawing.Size(180, 22);
            this.submenucategorias.Text = "Categorias";
            this.submenucategorias.Click += new System.EventHandler(this.submenucategorias_Click);
            // 
            // MenuAcerca
            // 
            this.MenuAcerca.AutoSize = false;
            this.MenuAcerca.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            this.MenuAcerca.IconColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MenuAcerca.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.MenuAcerca.IconSize = 50;
            this.MenuAcerca.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuAcerca.Name = "MenuAcerca";
            this.MenuAcerca.Size = new System.Drawing.Size(80, 69);
            this.MenuAcerca.Text = "Acerca de";
            this.MenuAcerca.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuAcerca.Click += new System.EventHandler(this.MenuAcerca_Click);
            // 
            // Menu
            // 
            this.Menu.AutoSize = false;
            this.Menu.BackColor = System.Drawing.Color.SteelBlue;
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Menu.Size = new System.Drawing.Size(1064, 60);
            this.Menu.TabIndex = 1;
            this.Menu.Text = "menuStrip2";
            // 
            // Textotitulo
            // 
            this.Textotitulo.AutoSize = true;
            this.Textotitulo.BackColor = System.Drawing.Color.SteelBlue;
            this.Textotitulo.Font = new System.Drawing.Font("Roboto", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Textotitulo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Textotitulo.Location = new System.Drawing.Point(12, 9);
            this.Textotitulo.Name = "Textotitulo";
            this.Textotitulo.Size = new System.Drawing.Size(103, 33);
            this.Textotitulo.TabIndex = 2;
            this.Textotitulo.Text = "Tienda";
            // 
            // Contenedor
            // 
            this.Contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Contenedor.Location = new System.Drawing.Point(0, 133);
            this.Contenedor.Name = "Contenedor";
            this.Contenedor.Size = new System.Drawing.Size(1064, 528);
            this.Contenedor.TabIndex = 3;
            // 
            // labeluser
            // 
            this.labeluser.AutoSize = true;
            this.labeluser.BackColor = System.Drawing.Color.SteelBlue;
            this.labeluser.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeluser.ForeColor = System.Drawing.SystemColors.Control;
            this.labeluser.Location = new System.Drawing.Point(926, 19);
            this.labeluser.Name = "labeluser";
            this.labeluser.Size = new System.Drawing.Size(48, 13);
            this.labeluser.TabIndex = 4;
            this.labeluser.Text = "Usuario:";
            this.labeluser.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblnombreuser
            // 
            this.lblnombreuser.AutoSize = true;
            this.lblnombreuser.BackColor = System.Drawing.Color.SteelBlue;
            this.lblnombreuser.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnombreuser.ForeColor = System.Drawing.SystemColors.Control;
            this.lblnombreuser.Location = new System.Drawing.Point(973, 19);
            this.lblnombreuser.Name = "lblnombreuser";
            this.lblnombreuser.Size = new System.Drawing.Size(66, 13);
            this.lblnombreuser.TabIndex = 5;
            this.lblnombreuser.Text = "Cargando ...";
            this.lblnombreuser.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.White;
            this.iconButton1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.DoorOpen;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 21;
            this.iconButton1.Location = new System.Drawing.Point(1024, 85);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(28, 27);
            this.iconButton1.TabIndex = 6;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 661);
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.lblnombreuser);
            this.Controls.Add(this.labeluser);
            this.Controls.Add(this.Contenedor);
            this.Controls.Add(this.Textotitulo);
            this.Controls.Add(this.MenuTitulo);
            this.Controls.Add(this.Menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuTitulo;
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.MenuTitulo.ResumeLayout(false);
            this.MenuTitulo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuTitulo;
        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.Label Textotitulo;
        private FontAwesome.Sharp.IconMenuItem MenuUs;
        private FontAwesome.Sharp.IconMenuItem MenuVentas;
        private FontAwesome.Sharp.IconMenuItem MenuClient;
        private FontAwesome.Sharp.IconMenuItem MenuInformes;
        private FontAwesome.Sharp.IconMenuItem MenuStock;
        private FontAwesome.Sharp.IconMenuItem MenuAcerca;
        private System.Windows.Forms.Panel Contenedor;
        private System.Windows.Forms.Label labeluser;
        private System.Windows.Forms.Label lblnombreuser;
        private FontAwesome.Sharp.IconMenuItem submenuregistrarventa;
        private FontAwesome.Sharp.IconMenuItem submenudetalleventa;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconMenuItem submenuinv;
        private FontAwesome.Sharp.IconMenuItem submenucategorias;
    }
}

