namespace Llamen_a_Dios
{
    partial class Inicio
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.PanelSidebar = new System.Windows.Forms.Panel();
            this.btnAcerca = new FontAwesome.Sharp.IconButton();
            this.PanelSubmenuStock = new System.Windows.Forms.Panel();
            this.submenucategorias = new System.Windows.Forms.Button();
            this.submenuinv = new System.Windows.Forms.Button();
            this.btnStock = new FontAwesome.Sharp.IconButton();
            this.btnInformes = new FontAwesome.Sharp.IconButton();
            this.btnClientes = new FontAwesome.Sharp.IconButton();
            this.PanelSubmenuVentas = new System.Windows.Forms.Panel();
            this.submenudetalleventa = new System.Windows.Forms.Button();
            this.submenuregistrarventa = new System.Windows.Forms.Button();
            this.btnVentas = new FontAwesome.Sharp.IconButton();
            this.btnUsuarios = new FontAwesome.Sharp.IconButton();
            this.PanelLogo = new System.Windows.Forms.Panel();
            this.Textotitulo = new System.Windows.Forms.Label();
            this.btnCerrarSesion = new FontAwesome.Sharp.IconButton();
            this.PanelHeader = new System.Windows.Forms.Panel();
            this.lblnombreuser = new System.Windows.Forms.Label();
            this.labeluser = new System.Windows.Forms.Label();
            this.Contenedor = new System.Windows.Forms.Panel();
            this.PanelSidebar.SuspendLayout();
            this.PanelSubmenuStock.SuspendLayout();
            this.PanelSubmenuVentas.SuspendLayout();
            this.PanelLogo.SuspendLayout();
            this.PanelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelSidebar
            // 
            this.PanelSidebar.AutoScroll = true;
            this.PanelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(78)))), ((int)(((byte)(216)))));
            this.PanelSidebar.Controls.Add(this.btnAcerca);
            this.PanelSidebar.Controls.Add(this.PanelSubmenuStock);
            this.PanelSidebar.Controls.Add(this.btnStock);
            this.PanelSidebar.Controls.Add(this.btnInformes);
            this.PanelSidebar.Controls.Add(this.btnClientes);
            this.PanelSidebar.Controls.Add(this.PanelSubmenuVentas);
            this.PanelSidebar.Controls.Add(this.btnVentas);
            this.PanelSidebar.Controls.Add(this.btnUsuarios);
            this.PanelSidebar.Controls.Add(this.PanelLogo);
            this.PanelSidebar.Controls.Add(this.btnCerrarSesion);
            this.PanelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelSidebar.Location = new System.Drawing.Point(0, 0);
            this.PanelSidebar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PanelSidebar.Name = "PanelSidebar";
            this.PanelSidebar.Size = new System.Drawing.Size(307, 1200);
            this.PanelSidebar.TabIndex = 0;
            // 
            // btnAcerca
            // 
            this.btnAcerca.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAcerca.FlatAppearance.BorderSize = 0;
            this.btnAcerca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcerca.ForeColor = System.Drawing.Color.White;
            this.btnAcerca.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            this.btnAcerca.IconColor = System.Drawing.Color.White;
            this.btnAcerca.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAcerca.IconSize = 32;
            this.btnAcerca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAcerca.Location = new System.Drawing.Point(0, 629);
            this.btnAcerca.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAcerca.Name = "btnAcerca";
            this.btnAcerca.Padding = new System.Windows.Forms.Padding(20, 0, 27, 0);
            this.btnAcerca.Size = new System.Drawing.Size(307, 62);
            this.btnAcerca.TabIndex = 0;
            this.btnAcerca.Text = "  Acerca de";
            this.btnAcerca.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAcerca.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAcerca.UseVisualStyleBackColor = true;
            this.btnAcerca.Click += new System.EventHandler(this.MenuAcerca_Click);
            // 
            // PanelSubmenuStock
            // 
            this.PanelSubmenuStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(138)))));
            this.PanelSubmenuStock.Controls.Add(this.submenucategorias);
            this.PanelSubmenuStock.Controls.Add(this.submenuinv);
            this.PanelSubmenuStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelSubmenuStock.Location = new System.Drawing.Point(0, 531);
            this.PanelSubmenuStock.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PanelSubmenuStock.Name = "PanelSubmenuStock";
            this.PanelSubmenuStock.Size = new System.Drawing.Size(307, 98);
            this.PanelSubmenuStock.TabIndex = 8;
            this.PanelSubmenuStock.Visible = false;
            // 
            // submenucategorias
            // 
            this.submenucategorias.Dock = System.Windows.Forms.DockStyle.Top;
            this.submenucategorias.FlatAppearance.BorderSize = 0;
            this.submenucategorias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submenucategorias.ForeColor = System.Drawing.Color.LightGray;
            this.submenucategorias.Location = new System.Drawing.Point(0, 49);
            this.submenucategorias.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.submenucategorias.Name = "submenucategorias";
            this.submenucategorias.Padding = new System.Windows.Forms.Padding(67, 0, 0, 0);
            this.submenucategorias.Size = new System.Drawing.Size(307, 49);
            this.submenucategorias.TabIndex = 0;
            this.submenucategorias.Text = "Categorías";
            this.submenucategorias.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.submenucategorias.UseVisualStyleBackColor = true;
            this.submenucategorias.Click += new System.EventHandler(this.submenucategorias_Click);
            // 
            // submenuinv
            // 
            this.submenuinv.Dock = System.Windows.Forms.DockStyle.Top;
            this.submenuinv.FlatAppearance.BorderSize = 0;
            this.submenuinv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submenuinv.ForeColor = System.Drawing.Color.LightGray;
            this.submenuinv.Location = new System.Drawing.Point(0, 0);
            this.submenuinv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.submenuinv.Name = "submenuinv";
            this.submenuinv.Padding = new System.Windows.Forms.Padding(67, 0, 0, 0);
            this.submenuinv.Size = new System.Drawing.Size(307, 49);
            this.submenuinv.TabIndex = 1;
            this.submenuinv.Text = "Inventario";
            this.submenuinv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.submenuinv.UseVisualStyleBackColor = true;
            this.submenuinv.Click += new System.EventHandler(this.submenuinv_Click);
            // 
            // btnStock
            // 
            this.btnStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStock.FlatAppearance.BorderSize = 0;
            this.btnStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStock.ForeColor = System.Drawing.Color.White;
            this.btnStock.IconChar = FontAwesome.Sharp.IconChar.BoxOpen;
            this.btnStock.IconColor = System.Drawing.Color.White;
            this.btnStock.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnStock.IconSize = 32;
            this.btnStock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStock.Location = new System.Drawing.Point(0, 469);
            this.btnStock.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStock.Name = "btnStock";
            this.btnStock.Padding = new System.Windows.Forms.Padding(20, 0, 27, 0);
            this.btnStock.Size = new System.Drawing.Size(307, 62);
            this.btnStock.TabIndex = 9;
            this.btnStock.Text = "  Stock";
            this.btnStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStock.UseVisualStyleBackColor = true;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // btnInformes
            // 
            this.btnInformes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInformes.FlatAppearance.BorderSize = 0;
            this.btnInformes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInformes.ForeColor = System.Drawing.Color.White;
            this.btnInformes.IconChar = FontAwesome.Sharp.IconChar.ChartBar;
            this.btnInformes.IconColor = System.Drawing.Color.White;
            this.btnInformes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnInformes.IconSize = 32;
            this.btnInformes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInformes.Location = new System.Drawing.Point(0, 407);
            this.btnInformes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnInformes.Name = "btnInformes";
            this.btnInformes.Padding = new System.Windows.Forms.Padding(20, 0, 27, 0);
            this.btnInformes.Size = new System.Drawing.Size(307, 62);
            this.btnInformes.TabIndex = 10;
            this.btnInformes.Text = "  Informes";
            this.btnInformes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInformes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInformes.UseVisualStyleBackColor = true;
            this.btnInformes.Click += new System.EventHandler(this.MenuInformes_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClientes.FlatAppearance.BorderSize = 0;
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.ForeColor = System.Drawing.Color.White;
            this.btnClientes.IconChar = FontAwesome.Sharp.IconChar.UserGroup;
            this.btnClientes.IconColor = System.Drawing.Color.White;
            this.btnClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClientes.IconSize = 32;
            this.btnClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.Location = new System.Drawing.Point(0, 345);
            this.btnClientes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Padding = new System.Windows.Forms.Padding(20, 0, 27, 0);
            this.btnClientes.Size = new System.Drawing.Size(307, 62);
            this.btnClientes.TabIndex = 11;
            this.btnClientes.Text = "  Clientes";
            this.btnClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.MenuClient_Click);
            // 
            // PanelSubmenuVentas
            // 
            this.PanelSubmenuVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(138)))));
            this.PanelSubmenuVentas.Controls.Add(this.submenudetalleventa);
            this.PanelSubmenuVentas.Controls.Add(this.submenuregistrarventa);
            this.PanelSubmenuVentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelSubmenuVentas.Location = new System.Drawing.Point(0, 247);
            this.PanelSubmenuVentas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PanelSubmenuVentas.Name = "PanelSubmenuVentas";
            this.PanelSubmenuVentas.Size = new System.Drawing.Size(307, 98);
            this.PanelSubmenuVentas.TabIndex = 7;
            this.PanelSubmenuVentas.Visible = false;
            // 
            // submenudetalleventa
            // 
            this.submenudetalleventa.Dock = System.Windows.Forms.DockStyle.Top;
            this.submenudetalleventa.FlatAppearance.BorderSize = 0;
            this.submenudetalleventa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submenudetalleventa.ForeColor = System.Drawing.Color.LightGray;
            this.submenudetalleventa.Location = new System.Drawing.Point(0, 49);
            this.submenudetalleventa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.submenudetalleventa.Name = "submenudetalleventa";
            this.submenudetalleventa.Padding = new System.Windows.Forms.Padding(67, 0, 0, 0);
            this.submenudetalleventa.Size = new System.Drawing.Size(307, 49);
            this.submenudetalleventa.TabIndex = 0;
            this.submenudetalleventa.Text = "Ver Detalles";
            this.submenudetalleventa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.submenudetalleventa.UseVisualStyleBackColor = true;
            this.submenudetalleventa.Click += new System.EventHandler(this.submenudetalleventa_Click);
            // 
            // submenuregistrarventa
            // 
            this.submenuregistrarventa.Dock = System.Windows.Forms.DockStyle.Top;
            this.submenuregistrarventa.FlatAppearance.BorderSize = 0;
            this.submenuregistrarventa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submenuregistrarventa.ForeColor = System.Drawing.Color.LightGray;
            this.submenuregistrarventa.Location = new System.Drawing.Point(0, 0);
            this.submenuregistrarventa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.submenuregistrarventa.Name = "submenuregistrarventa";
            this.submenuregistrarventa.Padding = new System.Windows.Forms.Padding(67, 0, 0, 0);
            this.submenuregistrarventa.Size = new System.Drawing.Size(307, 49);
            this.submenuregistrarventa.TabIndex = 1;
            this.submenuregistrarventa.Text = "Registrar Venta";
            this.submenuregistrarventa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.submenuregistrarventa.UseVisualStyleBackColor = true;
            this.submenuregistrarventa.Click += new System.EventHandler(this.submenuregistrarventa_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVentas.FlatAppearance.BorderSize = 0;
            this.btnVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentas.ForeColor = System.Drawing.Color.White;
            this.btnVentas.IconChar = FontAwesome.Sharp.IconChar.Tag;
            this.btnVentas.IconColor = System.Drawing.Color.White;
            this.btnVentas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnVentas.IconSize = 32;
            this.btnVentas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentas.Location = new System.Drawing.Point(0, 185);
            this.btnVentas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Padding = new System.Windows.Forms.Padding(20, 0, 27, 0);
            this.btnVentas.Size = new System.Drawing.Size(307, 62);
            this.btnVentas.TabIndex = 12;
            this.btnVentas.Text = "  Ventas";
            this.btnVentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVentas.UseVisualStyleBackColor = true;
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUsuarios.FlatAppearance.BorderSize = 0;
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarios.ForeColor = System.Drawing.Color.White;
            this.btnUsuarios.IconChar = FontAwesome.Sharp.IconChar.UsersGear;
            this.btnUsuarios.IconColor = System.Drawing.Color.White;
            this.btnUsuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnUsuarios.IconSize = 32;
            this.btnUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuarios.Location = new System.Drawing.Point(0, 123);
            this.btnUsuarios.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Padding = new System.Windows.Forms.Padding(20, 0, 27, 0);
            this.btnUsuarios.Size = new System.Drawing.Size(307, 62);
            this.btnUsuarios.TabIndex = 13;
            this.btnUsuarios.Text = "  Usuarios";
            this.btnUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.MenuUs_Click);
            // 
            // PanelLogo
            // 
            this.PanelLogo.Controls.Add(this.Textotitulo);
            this.PanelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelLogo.Location = new System.Drawing.Point(0, 0);
            this.PanelLogo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PanelLogo.Name = "PanelLogo";
            this.PanelLogo.Size = new System.Drawing.Size(307, 123);
            this.PanelLogo.TabIndex = 0;
            // 
            // Textotitulo
            // 
            this.Textotitulo.AutoSize = true;
            this.Textotitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Textotitulo.ForeColor = System.Drawing.Color.White;
            this.Textotitulo.Location = new System.Drawing.Point(33, 43);
            this.Textotitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Textotitulo.Name = "Textotitulo";
            this.Textotitulo.Size = new System.Drawing.Size(165, 41);
            this.Textotitulo.TabIndex = 2;
            this.Textotitulo.Text = "GD Tienda";
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCerrarSesion.FlatAppearance.BorderSize = 0;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.White;
            this.btnCerrarSesion.IconChar = FontAwesome.Sharp.IconChar.DoorOpen;
            this.btnCerrarSesion.IconColor = System.Drawing.Color.White;
            this.btnCerrarSesion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCerrarSesion.IconSize = 32;
            this.btnCerrarSesion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarSesion.Location = new System.Drawing.Point(0, 1126);
            this.btnCerrarSesion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Padding = new System.Windows.Forms.Padding(20, 0, 27, 0);
            this.btnCerrarSesion.Size = new System.Drawing.Size(307, 74);
            this.btnCerrarSesion.TabIndex = 14;
            this.btnCerrarSesion.Text = "  Cerrar Sesión";
            this.btnCerrarSesion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarSesion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // PanelHeader
            // 
            this.PanelHeader.BackColor = System.Drawing.Color.White;
            this.PanelHeader.Controls.Add(this.lblnombreuser);
            this.PanelHeader.Controls.Add(this.labeluser);
            this.PanelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelHeader.Location = new System.Drawing.Point(307, 0);
            this.PanelHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PanelHeader.Name = "PanelHeader";
            this.PanelHeader.Size = new System.Drawing.Size(1613, 74);
            this.PanelHeader.TabIndex = 1;
            // 
            // lblnombreuser
            // 
            this.lblnombreuser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblnombreuser.AutoSize = true;
            this.lblnombreuser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnombreuser.ForeColor = System.Drawing.Color.Black;
            this.lblnombreuser.Location = new System.Drawing.Point(1429, 27);
            this.lblnombreuser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblnombreuser.Name = "lblnombreuser";
            this.lblnombreuser.Size = new System.Drawing.Size(92, 20);
            this.lblnombreuser.TabIndex = 0;
            this.lblnombreuser.Text = "Cargando ...";
            // 
            // labeluser
            // 
            this.labeluser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labeluser.AutoSize = true;
            this.labeluser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeluser.ForeColor = System.Drawing.Color.Gray;
            this.labeluser.Location = new System.Drawing.Point(1354, 27);
            this.labeluser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labeluser.Name = "labeluser";
            this.labeluser.Size = new System.Drawing.Size(62, 20);
            this.labeluser.TabIndex = 1;
            this.labeluser.Text = "Usuario:";
            // 
            // Contenedor
            // 
            this.Contenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.Contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Contenedor.Location = new System.Drawing.Point(307, 74);
            this.Contenedor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Contenedor.Name = "Contenedor";
            this.Contenedor.Size = new System.Drawing.Size(1613, 1126);
            this.Contenedor.TabIndex = 2;
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1200);
            this.Controls.Add(this.Contenedor);
            this.Controls.Add(this.PanelHeader);
            this.Controls.Add(this.PanelSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.PanelSidebar.ResumeLayout(false);
            this.PanelSubmenuStock.ResumeLayout(false);
            this.PanelSubmenuVentas.ResumeLayout(false);
            this.PanelLogo.ResumeLayout(false);
            this.PanelLogo.PerformLayout();
            this.PanelHeader.ResumeLayout(false);
            this.PanelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel PanelSidebar;
        private System.Windows.Forms.Panel PanelLogo;
        private System.Windows.Forms.Panel PanelHeader;
        private System.Windows.Forms.Panel Contenedor;
        private System.Windows.Forms.Label Textotitulo;
        private System.Windows.Forms.Label labeluser;
        private System.Windows.Forms.Label lblnombreuser;

        // Botones Principales
        private FontAwesome.Sharp.IconButton btnUsuarios;
        private FontAwesome.Sharp.IconButton btnVentas;
        private FontAwesome.Sharp.IconButton btnClientes;
        private FontAwesome.Sharp.IconButton btnInformes;
        private FontAwesome.Sharp.IconButton btnStock;
        private FontAwesome.Sharp.IconButton btnAcerca;
        private FontAwesome.Sharp.IconButton btnCerrarSesion;

        // Nuevos Paneles y Botones para el Menú Acordeón
        private System.Windows.Forms.Panel PanelSubmenuVentas;
        private System.Windows.Forms.Button submenudetalleventa;
        private System.Windows.Forms.Button submenuregistrarventa;
        private System.Windows.Forms.Panel PanelSubmenuStock;
        private System.Windows.Forms.Button submenucategorias;
        private System.Windows.Forms.Button submenuinv;
    }
}