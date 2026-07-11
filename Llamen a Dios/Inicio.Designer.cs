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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.PanelSidebar = new System.Windows.Forms.Panel();
            this.btnAcerca = new FontAwesome.Sharp.IconButton();
            this.btnrespaldo = new FontAwesome.Sharp.IconButton();
            this.PanelSubmenuStock = new System.Windows.Forms.Panel();
            this.btnIngredientes = new System.Windows.Forms.Button();
            this.btnProduccion = new System.Windows.Forms.Button();
            this.submenuinv = new System.Windows.Forms.Button();
            this.btnStock = new FontAwesome.Sharp.IconButton();
            this.PanelSubmenuInformes = new System.Windows.Forms.Panel();
            this.submenucierrecaja = new System.Windows.Forms.Button();
            this.btnInformes = new FontAwesome.Sharp.IconButton();
            this.btnClientes = new FontAwesome.Sharp.IconButton();
            this.PanelSubmenuVentas = new System.Windows.Forms.Panel();
            this.submenudetalleventa = new System.Windows.Forms.Button();
            this.submenuregistrarventa = new System.Windows.Forms.Button();
            this.btnVentas = new FontAwesome.Sharp.IconButton();
            this.Btnasistente = new FontAwesome.Sharp.IconButton();
            this.btnUsuarios = new FontAwesome.Sharp.IconButton();
            this.btndashboard = new FontAwesome.Sharp.IconButton();
            this.PanelLogo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Textotitulo = new System.Windows.Forms.Label();
            this.btnCerrarSesion = new FontAwesome.Sharp.IconButton();
            this.PanelHeader = new System.Windows.Forms.Panel();
            this.lblHora = new System.Windows.Forms.Label();
            this.lblnombreuser = new System.Windows.Forms.Label();
            this.labeluser = new System.Windows.Forms.Label();
            this.Contenedor = new System.Windows.Forms.Panel();
            this.timerHora = new System.Windows.Forms.Timer(this.components);
            this.PanelSidebar.SuspendLayout();
            this.PanelSubmenuStock.SuspendLayout();
            this.PanelSubmenuInformes.SuspendLayout();
            this.PanelSubmenuVentas.SuspendLayout();
            this.PanelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PanelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelSidebar
            // 
            this.PanelSidebar.AutoScroll = true;
            this.PanelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.PanelSidebar.Controls.Add(this.btnAcerca);
            this.PanelSidebar.Controls.Add(this.btnrespaldo);
            this.PanelSidebar.Controls.Add(this.PanelSubmenuStock);
            this.PanelSidebar.Controls.Add(this.btnStock);
            this.PanelSidebar.Controls.Add(this.PanelSubmenuInformes);
            this.PanelSidebar.Controls.Add(this.btnInformes);
            this.PanelSidebar.Controls.Add(this.btnClientes);
            this.PanelSidebar.Controls.Add(this.PanelSubmenuVentas);
            this.PanelSidebar.Controls.Add(this.btnVentas);
            this.PanelSidebar.Controls.Add(this.Btnasistente);
            this.PanelSidebar.Controls.Add(this.btnUsuarios);
            this.PanelSidebar.Controls.Add(this.btndashboard);
            this.PanelSidebar.Controls.Add(this.PanelLogo);
            this.PanelSidebar.Controls.Add(this.btnCerrarSesion);
            this.PanelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelSidebar.Location = new System.Drawing.Point(0, 0);
            this.PanelSidebar.Margin = new System.Windows.Forms.Padding(4);
            this.PanelSidebar.Name = "PanelSidebar";
            this.PanelSidebar.Size = new System.Drawing.Size(307, 1200);
            this.PanelSidebar.TabIndex = 0;
            // 
            // btnAcerca
            // 
            this.btnAcerca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.btnAcerca.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAcerca.FlatAppearance.BorderSize = 0;
            this.btnAcerca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcerca.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.btnAcerca.ForeColor = System.Drawing.Color.White;
            this.btnAcerca.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            this.btnAcerca.IconColor = System.Drawing.Color.White;
            this.btnAcerca.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAcerca.IconSize = 32;
            this.btnAcerca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAcerca.Location = new System.Drawing.Point(0, 805);
            this.btnAcerca.Margin = new System.Windows.Forms.Padding(4);
            this.btnAcerca.Name = "btnAcerca";
            this.btnAcerca.Padding = new System.Windows.Forms.Padding(20, 0, 27, 0);
            this.btnAcerca.Size = new System.Drawing.Size(307, 62);
            this.btnAcerca.TabIndex = 0;
            this.btnAcerca.Text = "  Acerca de";
            this.btnAcerca.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAcerca.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAcerca.UseVisualStyleBackColor = false;
            this.btnAcerca.Click += new System.EventHandler(this.MenuAcerca_Click);
            // 
            // btnrespaldo
            // 
            this.btnrespaldo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnrespaldo.FlatAppearance.BorderSize = 0;
            this.btnrespaldo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnrespaldo.ForeColor = System.Drawing.Color.White;
            this.btnrespaldo.IconChar = FontAwesome.Sharp.IconChar.Database;
            this.btnrespaldo.IconColor = System.Drawing.Color.White;
            this.btnrespaldo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnrespaldo.IconSize = 32;
            this.btnrespaldo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnrespaldo.Location = new System.Drawing.Point(0, 1052);
            this.btnrespaldo.Margin = new System.Windows.Forms.Padding(4);
            this.btnrespaldo.Name = "btnrespaldo";
            this.btnrespaldo.Padding = new System.Windows.Forms.Padding(20, 0, 27, 0);
            this.btnrespaldo.Size = new System.Drawing.Size(307, 74);
            this.btnrespaldo.TabIndex = 18;
            this.btnrespaldo.Text = "  Crear Respaldo";
            this.btnrespaldo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnrespaldo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnrespaldo.UseVisualStyleBackColor = true;
            this.btnrespaldo.Click += new System.EventHandler(this.btnrespaldo_Click);
            // 
            // PanelSubmenuStock
            // 
            this.PanelSubmenuStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(138)))));
            this.PanelSubmenuStock.Controls.Add(this.btnIngredientes);
            this.PanelSubmenuStock.Controls.Add(this.btnProduccion);
            this.PanelSubmenuStock.Controls.Add(this.submenuinv);
            this.PanelSubmenuStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelSubmenuStock.Location = new System.Drawing.Point(0, 657);
            this.PanelSubmenuStock.Margin = new System.Windows.Forms.Padding(4);
            this.PanelSubmenuStock.Name = "PanelSubmenuStock";
            this.PanelSubmenuStock.Size = new System.Drawing.Size(307, 148);
            this.PanelSubmenuStock.TabIndex = 8;
            this.PanelSubmenuStock.Visible = false;
            // 
            // btnIngredientes
            // 
            this.btnIngredientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(84)))), ((int)(((byte)(147)))));
            this.btnIngredientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnIngredientes.FlatAppearance.BorderSize = 0;
            this.btnIngredientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngredientes.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.btnIngredientes.ForeColor = System.Drawing.Color.LightGray;
            this.btnIngredientes.Location = new System.Drawing.Point(0, 98);
            this.btnIngredientes.Margin = new System.Windows.Forms.Padding(4);
            this.btnIngredientes.Name = "btnIngredientes";
            this.btnIngredientes.Padding = new System.Windows.Forms.Padding(67, 0, 0, 0);
            this.btnIngredientes.Size = new System.Drawing.Size(307, 49);
            this.btnIngredientes.TabIndex = 3;
            this.btnIngredientes.Text = "Ingredientes";
            this.btnIngredientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIngredientes.UseVisualStyleBackColor = false;
            this.btnIngredientes.Click += new System.EventHandler(this.btnIngredientes_Click);
            // 
            // btnProduccion
            // 
            this.btnProduccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(84)))), ((int)(((byte)(147)))));
            this.btnProduccion.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProduccion.FlatAppearance.BorderSize = 0;
            this.btnProduccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduccion.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.btnProduccion.ForeColor = System.Drawing.Color.LightGray;
            this.btnProduccion.Location = new System.Drawing.Point(0, 49);
            this.btnProduccion.Margin = new System.Windows.Forms.Padding(4);
            this.btnProduccion.Name = "btnProduccion";
            this.btnProduccion.Padding = new System.Windows.Forms.Padding(67, 0, 0, 0);
            this.btnProduccion.Size = new System.Drawing.Size(307, 49);
            this.btnProduccion.TabIndex = 2;
            this.btnProduccion.Text = "Produccion";
            this.btnProduccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProduccion.UseVisualStyleBackColor = false;
            this.btnProduccion.Click += new System.EventHandler(this.btnProduccion_Click);
            // 
            // submenuinv
            // 
            this.submenuinv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(84)))), ((int)(((byte)(147)))));
            this.submenuinv.Dock = System.Windows.Forms.DockStyle.Top;
            this.submenuinv.FlatAppearance.BorderSize = 0;
            this.submenuinv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submenuinv.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.submenuinv.ForeColor = System.Drawing.Color.LightGray;
            this.submenuinv.Location = new System.Drawing.Point(0, 0);
            this.submenuinv.Margin = new System.Windows.Forms.Padding(4);
            this.submenuinv.Name = "submenuinv";
            this.submenuinv.Padding = new System.Windows.Forms.Padding(67, 0, 0, 0);
            this.submenuinv.Size = new System.Drawing.Size(307, 49);
            this.submenuinv.TabIndex = 1;
            this.submenuinv.Text = "Inventario";
            this.submenuinv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.submenuinv.UseVisualStyleBackColor = false;
            this.submenuinv.Click += new System.EventHandler(this.submenuinv_Click);
            // 
            // btnStock
            // 
            this.btnStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.btnStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStock.FlatAppearance.BorderSize = 0;
            this.btnStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStock.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.btnStock.ForeColor = System.Drawing.Color.White;
            this.btnStock.IconChar = FontAwesome.Sharp.IconChar.BoxOpen;
            this.btnStock.IconColor = System.Drawing.Color.White;
            this.btnStock.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnStock.IconSize = 32;
            this.btnStock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStock.Location = new System.Drawing.Point(0, 595);
            this.btnStock.Margin = new System.Windows.Forms.Padding(4);
            this.btnStock.Name = "btnStock";
            this.btnStock.Padding = new System.Windows.Forms.Padding(20, 0, 27, 0);
            this.btnStock.Size = new System.Drawing.Size(307, 62);
            this.btnStock.TabIndex = 9;
            this.btnStock.Text = "  Stock";
            this.btnStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStock.UseVisualStyleBackColor = false;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // PanelSubmenuInformes
            // 
            this.PanelSubmenuInformes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(138)))));
            this.PanelSubmenuInformes.Controls.Add(this.submenucierrecaja);
            this.PanelSubmenuInformes.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelSubmenuInformes.Location = new System.Drawing.Point(0, 544);
            this.PanelSubmenuInformes.Margin = new System.Windows.Forms.Padding(4);
            this.PanelSubmenuInformes.Name = "PanelSubmenuInformes";
            this.PanelSubmenuInformes.Size = new System.Drawing.Size(307, 51);
            this.PanelSubmenuInformes.TabIndex = 15;
            this.PanelSubmenuInformes.Visible = false;
            // 
            // submenucierrecaja
            // 
            this.submenucierrecaja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(84)))), ((int)(((byte)(147)))));
            this.submenucierrecaja.Dock = System.Windows.Forms.DockStyle.Top;
            this.submenucierrecaja.FlatAppearance.BorderSize = 0;
            this.submenucierrecaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submenucierrecaja.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.submenucierrecaja.ForeColor = System.Drawing.Color.LightGray;
            this.submenucierrecaja.Location = new System.Drawing.Point(0, 0);
            this.submenucierrecaja.Margin = new System.Windows.Forms.Padding(4);
            this.submenucierrecaja.Name = "submenucierrecaja";
            this.submenucierrecaja.Padding = new System.Windows.Forms.Padding(67, 0, 0, 0);
            this.submenucierrecaja.Size = new System.Drawing.Size(307, 49);
            this.submenucierrecaja.TabIndex = 0;
            this.submenucierrecaja.Text = "Cierre de Caja";
            this.submenucierrecaja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.submenucierrecaja.UseVisualStyleBackColor = false;
            this.submenucierrecaja.Click += new System.EventHandler(this.submenucierrecaja_Click);
            // 
            // btnInformes
            // 
            this.btnInformes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.btnInformes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInformes.FlatAppearance.BorderSize = 0;
            this.btnInformes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInformes.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.btnInformes.ForeColor = System.Drawing.Color.White;
            this.btnInformes.IconChar = FontAwesome.Sharp.IconChar.ChartBar;
            this.btnInformes.IconColor = System.Drawing.Color.White;
            this.btnInformes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnInformes.IconSize = 32;
            this.btnInformes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInformes.Location = new System.Drawing.Point(0, 482);
            this.btnInformes.Margin = new System.Windows.Forms.Padding(4);
            this.btnInformes.Name = "btnInformes";
            this.btnInformes.Padding = new System.Windows.Forms.Padding(20, 0, 27, 0);
            this.btnInformes.Size = new System.Drawing.Size(307, 62);
            this.btnInformes.TabIndex = 10;
            this.btnInformes.Text = "  Informes";
            this.btnInformes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInformes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInformes.UseVisualStyleBackColor = false;
            this.btnInformes.Click += new System.EventHandler(this.MenuInformes_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.btnClientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClientes.FlatAppearance.BorderSize = 0;
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.btnClientes.ForeColor = System.Drawing.Color.White;
            this.btnClientes.IconChar = FontAwesome.Sharp.IconChar.UserGroup;
            this.btnClientes.IconColor = System.Drawing.Color.White;
            this.btnClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClientes.IconSize = 32;
            this.btnClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.Location = new System.Drawing.Point(0, 420);
            this.btnClientes.Margin = new System.Windows.Forms.Padding(4);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Padding = new System.Windows.Forms.Padding(20, 0, 27, 0);
            this.btnClientes.Size = new System.Drawing.Size(307, 62);
            this.btnClientes.TabIndex = 11;
            this.btnClientes.Text = "  Clientes";
            this.btnClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClientes.UseVisualStyleBackColor = false;
            this.btnClientes.Click += new System.EventHandler(this.MenuClient_Click);
            // 
            // PanelSubmenuVentas
            // 
            this.PanelSubmenuVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(138)))));
            this.PanelSubmenuVentas.Controls.Add(this.submenudetalleventa);
            this.PanelSubmenuVentas.Controls.Add(this.submenuregistrarventa);
            this.PanelSubmenuVentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelSubmenuVentas.Location = new System.Drawing.Point(0, 322);
            this.PanelSubmenuVentas.Margin = new System.Windows.Forms.Padding(4);
            this.PanelSubmenuVentas.Name = "PanelSubmenuVentas";
            this.PanelSubmenuVentas.Size = new System.Drawing.Size(307, 98);
            this.PanelSubmenuVentas.TabIndex = 7;
            this.PanelSubmenuVentas.Visible = false;
            // 
            // submenudetalleventa
            // 
            this.submenudetalleventa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(84)))), ((int)(((byte)(147)))));
            this.submenudetalleventa.Dock = System.Windows.Forms.DockStyle.Top;
            this.submenudetalleventa.FlatAppearance.BorderSize = 0;
            this.submenudetalleventa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submenudetalleventa.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.submenudetalleventa.ForeColor = System.Drawing.Color.LightGray;
            this.submenudetalleventa.Location = new System.Drawing.Point(0, 49);
            this.submenudetalleventa.Margin = new System.Windows.Forms.Padding(4);
            this.submenudetalleventa.Name = "submenudetalleventa";
            this.submenudetalleventa.Padding = new System.Windows.Forms.Padding(67, 0, 0, 0);
            this.submenudetalleventa.Size = new System.Drawing.Size(307, 49);
            this.submenudetalleventa.TabIndex = 0;
            this.submenudetalleventa.Text = "Ver Detalles";
            this.submenudetalleventa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.submenudetalleventa.UseVisualStyleBackColor = false;
            this.submenudetalleventa.Click += new System.EventHandler(this.submenudetalleventa_Click);
            // 
            // submenuregistrarventa
            // 
            this.submenuregistrarventa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(84)))), ((int)(((byte)(147)))));
            this.submenuregistrarventa.Dock = System.Windows.Forms.DockStyle.Top;
            this.submenuregistrarventa.FlatAppearance.BorderSize = 0;
            this.submenuregistrarventa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submenuregistrarventa.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.submenuregistrarventa.ForeColor = System.Drawing.Color.LightGray;
            this.submenuregistrarventa.Location = new System.Drawing.Point(0, 0);
            this.submenuregistrarventa.Margin = new System.Windows.Forms.Padding(4);
            this.submenuregistrarventa.Name = "submenuregistrarventa";
            this.submenuregistrarventa.Padding = new System.Windows.Forms.Padding(67, 0, 0, 0);
            this.submenuregistrarventa.Size = new System.Drawing.Size(307, 49);
            this.submenuregistrarventa.TabIndex = 1;
            this.submenuregistrarventa.Text = "Registrar Venta";
            this.submenuregistrarventa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.submenuregistrarventa.UseVisualStyleBackColor = false;
            this.submenuregistrarventa.Click += new System.EventHandler(this.submenuregistrarventa_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.btnVentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVentas.FlatAppearance.BorderSize = 0;
            this.btnVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentas.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.btnVentas.ForeColor = System.Drawing.Color.White;
            this.btnVentas.IconChar = FontAwesome.Sharp.IconChar.Tag;
            this.btnVentas.IconColor = System.Drawing.Color.White;
            this.btnVentas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnVentas.IconSize = 32;
            this.btnVentas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentas.Location = new System.Drawing.Point(0, 260);
            this.btnVentas.Margin = new System.Windows.Forms.Padding(4);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Padding = new System.Windows.Forms.Padding(20, 0, 27, 0);
            this.btnVentas.Size = new System.Drawing.Size(307, 62);
            this.btnVentas.TabIndex = 12;
            this.btnVentas.Text = "  Ventas";
            this.btnVentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVentas.UseVisualStyleBackColor = false;
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // Btnasistente
            // 
            this.Btnasistente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.Btnasistente.Dock = System.Windows.Forms.DockStyle.Top;
            this.Btnasistente.FlatAppearance.BorderSize = 0;
            this.Btnasistente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btnasistente.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.Btnasistente.ForeColor = System.Drawing.Color.White;
            this.Btnasistente.IconChar = FontAwesome.Sharp.IconChar.Brain;
            this.Btnasistente.IconColor = System.Drawing.Color.White;
            this.Btnasistente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Btnasistente.IconSize = 32;
            this.Btnasistente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btnasistente.Location = new System.Drawing.Point(0, 198);
            this.Btnasistente.Margin = new System.Windows.Forms.Padding(4);
            this.Btnasistente.Name = "Btnasistente";
            this.Btnasistente.Padding = new System.Windows.Forms.Padding(20, 0, 27, 0);
            this.Btnasistente.Size = new System.Drawing.Size(307, 62);
            this.Btnasistente.TabIndex = 16;
            this.Btnasistente.Text = "  Asistente";
            this.Btnasistente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btnasistente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btnasistente.UseVisualStyleBackColor = false;
            this.Btnasistente.Click += new System.EventHandler(this.Btnasistente_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.btnUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUsuarios.FlatAppearance.BorderSize = 0;
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarios.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.btnUsuarios.ForeColor = System.Drawing.Color.White;
            this.btnUsuarios.IconChar = FontAwesome.Sharp.IconChar.UsersGear;
            this.btnUsuarios.IconColor = System.Drawing.Color.White;
            this.btnUsuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnUsuarios.IconSize = 32;
            this.btnUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuarios.Location = new System.Drawing.Point(0, 136);
            this.btnUsuarios.Margin = new System.Windows.Forms.Padding(4);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Padding = new System.Windows.Forms.Padding(20, 0, 27, 0);
            this.btnUsuarios.Size = new System.Drawing.Size(307, 62);
            this.btnUsuarios.TabIndex = 13;
            this.btnUsuarios.Text = "  Usuarios";
            this.btnUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUsuarios.UseVisualStyleBackColor = false;
            this.btnUsuarios.Click += new System.EventHandler(this.MenuUs_Click);
            // 
            // btndashboard
            // 
            this.btndashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.btndashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btndashboard.FlatAppearance.BorderSize = 0;
            this.btndashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndashboard.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.btndashboard.ForeColor = System.Drawing.Color.White;
            this.btndashboard.IconChar = FontAwesome.Sharp.IconChar.TachometerAltFast;
            this.btndashboard.IconColor = System.Drawing.Color.White;
            this.btndashboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btndashboard.IconSize = 32;
            this.btndashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndashboard.Location = new System.Drawing.Point(0, 74);
            this.btndashboard.Margin = new System.Windows.Forms.Padding(4);
            this.btndashboard.Name = "btndashboard";
            this.btndashboard.Padding = new System.Windows.Forms.Padding(20, 0, 27, 0);
            this.btndashboard.Size = new System.Drawing.Size(307, 62);
            this.btndashboard.TabIndex = 17;
            this.btndashboard.Text = "Dashboard";
            this.btndashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btndashboard.UseVisualStyleBackColor = false;
            this.btndashboard.Click += new System.EventHandler(this.btndashboard_Click);
            // 
            // PanelLogo
            // 
            this.PanelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(84)))), ((int)(((byte)(147)))));
            this.PanelLogo.Controls.Add(this.pictureBox1);
            this.PanelLogo.Controls.Add(this.Textotitulo);
            this.PanelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelLogo.Location = new System.Drawing.Point(0, 0);
            this.PanelLogo.Margin = new System.Windows.Forms.Padding(4);
            this.PanelLogo.Name = "PanelLogo";
            this.PanelLogo.Size = new System.Drawing.Size(307, 74);
            this.PanelLogo.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(85, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Textotitulo
            // 
            this.Textotitulo.AutoSize = true;
            this.Textotitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Textotitulo.ForeColor = System.Drawing.Color.White;
            this.Textotitulo.Location = new System.Drawing.Point(95, 15);
            this.Textotitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Textotitulo.Name = "Textotitulo";
            this.Textotitulo.Size = new System.Drawing.Size(187, 41);
            this.Textotitulo.TabIndex = 2;
            this.Textotitulo.Text = "Pan de Paris";
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
            this.btnCerrarSesion.Margin = new System.Windows.Forms.Padding(4);
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
            this.PanelHeader.BackColor = System.Drawing.Color.Black;
            this.PanelHeader.Controls.Add(this.lblHora);
            this.PanelHeader.Controls.Add(this.lblnombreuser);
            this.PanelHeader.Controls.Add(this.labeluser);
            this.PanelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelHeader.Location = new System.Drawing.Point(307, 0);
            this.PanelHeader.Margin = new System.Windows.Forms.Padding(4);
            this.PanelHeader.Name = "PanelHeader";
            this.PanelHeader.Size = new System.Drawing.Size(1613, 74);
            this.PanelHeader.TabIndex = 1;
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.BackColor = System.Drawing.Color.Black;
            this.lblHora.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.ForeColor = System.Drawing.Color.White;
            this.lblHora.Location = new System.Drawing.Point(75, 25);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(108, 23);
            this.lblHora.TabIndex = 2;
            this.lblHora.Text = "Cargando ...";
            // 
            // lblnombreuser
            // 
            this.lblnombreuser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblnombreuser.AutoSize = true;
            this.lblnombreuser.BackColor = System.Drawing.Color.Black;
            this.lblnombreuser.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblnombreuser.ForeColor = System.Drawing.Color.White;
            this.lblnombreuser.Location = new System.Drawing.Point(1429, 27);
            this.lblnombreuser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblnombreuser.Name = "lblnombreuser";
            this.lblnombreuser.Size = new System.Drawing.Size(108, 23);
            this.lblnombreuser.TabIndex = 0;
            this.lblnombreuser.Text = "Cargando ...";
            // 
            // labeluser
            // 
            this.labeluser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labeluser.AutoSize = true;
            this.labeluser.BackColor = System.Drawing.Color.Black;
            this.labeluser.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.labeluser.ForeColor = System.Drawing.Color.White;
            this.labeluser.Location = new System.Drawing.Point(1354, 27);
            this.labeluser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labeluser.Name = "labeluser";
            this.labeluser.Size = new System.Drawing.Size(72, 23);
            this.labeluser.TabIndex = 1;
            this.labeluser.Text = "Usuario:";
            // 
            // Contenedor
            // 
            this.Contenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.Contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Contenedor.Location = new System.Drawing.Point(307, 74);
            this.Contenedor.Margin = new System.Windows.Forms.Padding(4);
            this.Contenedor.Name = "Contenedor";
            this.Contenedor.Size = new System.Drawing.Size(1613, 1126);
            this.Contenedor.TabIndex = 2;
            this.Contenedor.Paint += new System.Windows.Forms.PaintEventHandler(this.Contenedor_Paint);
            // 
            // timerHora
            // 
            this.timerHora.Enabled = true;
            this.timerHora.Interval = 1000;
            this.timerHora.Tick += new System.EventHandler(this.timerHora_Tick);
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
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.PanelSidebar.ResumeLayout(false);
            this.PanelSubmenuStock.ResumeLayout(false);
            this.PanelSubmenuInformes.ResumeLayout(false);
            this.PanelSubmenuVentas.ResumeLayout(false);
            this.PanelLogo.ResumeLayout(false);
            this.PanelLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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

        // Paneles y Botones para el Menú Acordeón
        private System.Windows.Forms.Panel PanelSubmenuVentas;
        private System.Windows.Forms.Button submenudetalleventa;
        private System.Windows.Forms.Button submenuregistrarventa;
        private System.Windows.Forms.Panel PanelSubmenuStock;
        private System.Windows.Forms.Button submenuinv;

        // Declaraciones de las nuevas variables de Informes
        private System.Windows.Forms.Panel PanelSubmenuInformes;
        private System.Windows.Forms.Button submenucierrecaja;

        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Timer timerHora;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton Btnasistente;
        private FontAwesome.Sharp.IconButton btndashboard;
        private System.Windows.Forms.Button btnProduccion;
        private System.Windows.Forms.Button btnIngredientes;
        private FontAwesome.Sharp.IconButton btnrespaldo;
    }
}