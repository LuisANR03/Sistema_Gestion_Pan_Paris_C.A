namespace Llamen_a_Dios
{
    partial class FormAnaliticaIA
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
            this.panelLateral = new System.Windows.Forms.Panel();
            this.btnAuditoriaCaja = new System.Windows.Forms.Button();
            this.btnSugerirCompras = new System.Windows.Forms.Button();
            this.btnAnalisisVentas = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.lblTituloLateral = new System.Windows.Forms.Label();
            this.panelCentral = new System.Windows.Forms.Panel();
            this.rtbResultadoIA = new System.Windows.Forms.RichTextBox();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblCargando = new System.Windows.Forms.Label();
            this.lblTituloSeccion = new System.Windows.Forms.Label();
            this.panelLateral.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelCentral.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLateral
            // 
            this.panelLateral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.panelLateral.Controls.Add(this.btnAuditoriaCaja);
            this.panelLateral.Controls.Add(this.btnSugerirCompras);
            this.panelLateral.Controls.Add(this.btnAnalisisVentas);
            this.panelLateral.Controls.Add(this.panelLogo);
            this.panelLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLateral.Location = new System.Drawing.Point(0, 0);
            this.panelLateral.Margin = new System.Windows.Forms.Padding(4);
            this.panelLateral.Name = "panelLateral";
            this.panelLateral.Size = new System.Drawing.Size(347, 862);
            this.panelLateral.TabIndex = 0;
            // 
            // btnAuditoriaCaja
            // 
            this.btnAuditoriaCaja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAuditoriaCaja.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAuditoriaCaja.FlatAppearance.BorderSize = 0;
            this.btnAuditoriaCaja.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnAuditoriaCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuditoriaCaja.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAuditoriaCaja.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAuditoriaCaja.Location = new System.Drawing.Point(0, 271);
            this.btnAuditoriaCaja.Margin = new System.Windows.Forms.Padding(4);
            this.btnAuditoriaCaja.Name = "btnAuditoriaCaja";
            this.btnAuditoriaCaja.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnAuditoriaCaja.Size = new System.Drawing.Size(347, 74);
            this.btnAuditoriaCaja.TabIndex = 3;
            this.btnAuditoriaCaja.Text = "🛡️ Auditoría de Caja";
            this.btnAuditoriaCaja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAuditoriaCaja.UseVisualStyleBackColor = true;
            this.btnAuditoriaCaja.Click += new System.EventHandler(this.btnAuditoriaCaja_Click);
            // 
            // btnSugerirCompras
            // 
            this.btnSugerirCompras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSugerirCompras.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSugerirCompras.FlatAppearance.BorderSize = 0;
            this.btnSugerirCompras.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnSugerirCompras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSugerirCompras.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSugerirCompras.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSugerirCompras.Location = new System.Drawing.Point(0, 197);
            this.btnSugerirCompras.Margin = new System.Windows.Forms.Padding(4);
            this.btnSugerirCompras.Name = "btnSugerirCompras";
            this.btnSugerirCompras.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnSugerirCompras.Size = new System.Drawing.Size(347, 74);
            this.btnSugerirCompras.TabIndex = 2;
            this.btnSugerirCompras.Text = "📦 Sugerir Compras";
            this.btnSugerirCompras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSugerirCompras.UseVisualStyleBackColor = true;
            this.btnSugerirCompras.Click += new System.EventHandler(this.btnSugerirCompras_Click);
            // 
            // btnAnalisisVentas
            // 
            this.btnAnalisisVentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnalisisVentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAnalisisVentas.FlatAppearance.BorderSize = 0;
            this.btnAnalisisVentas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnAnalisisVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnalisisVentas.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnalisisVentas.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAnalisisVentas.Location = new System.Drawing.Point(0, 123);
            this.btnAnalisisVentas.Margin = new System.Windows.Forms.Padding(4);
            this.btnAnalisisVentas.Name = "btnAnalisisVentas";
            this.btnAnalisisVentas.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnAnalisisVentas.Size = new System.Drawing.Size(347, 74);
            this.btnAnalisisVentas.TabIndex = 1;
            this.btnAnalisisVentas.Text = "📈 Análisis de Ventas";
            this.btnAnalisisVentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnalisisVentas.UseVisualStyleBackColor = true;
            this.btnAnalisisVentas.Click += new System.EventHandler(this.btnAnalisisVentas_Click_1);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.panelLogo.Controls.Add(this.lblTituloLateral);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Margin = new System.Windows.Forms.Padding(4);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(347, 123);
            this.panelLogo.TabIndex = 0;
            // 
            // lblTituloLateral
            // 
            this.lblTituloLateral.AutoSize = true;
            this.lblTituloLateral.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloLateral.ForeColor = System.Drawing.Color.White;
            this.lblTituloLateral.Location = new System.Drawing.Point(31, 43);
            this.lblTituloLateral.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTituloLateral.Name = "lblTituloLateral";
            this.lblTituloLateral.Size = new System.Drawing.Size(237, 37);
            this.lblTituloLateral.TabIndex = 0;
            this.lblTituloLateral.Text = "Dashboard IA 🧠";
            // 
            // panelCentral
            // 
            this.panelCentral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.panelCentral.Controls.Add(this.rtbResultadoIA);
            this.panelCentral.Controls.Add(this.panelHeader);
            this.panelCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCentral.Location = new System.Drawing.Point(347, 0);
            this.panelCentral.Margin = new System.Windows.Forms.Padding(4);
            this.panelCentral.Name = "panelCentral";
            this.panelCentral.Padding = new System.Windows.Forms.Padding(27, 25, 27, 25);
            this.panelCentral.Size = new System.Drawing.Size(1120, 862);
            this.panelCentral.TabIndex = 1;
            // 
            // rtbResultadoIA
            // 
            this.rtbResultadoIA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.rtbResultadoIA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbResultadoIA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbResultadoIA.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbResultadoIA.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.rtbResultadoIA.Location = new System.Drawing.Point(27, 111);
            this.rtbResultadoIA.Margin = new System.Windows.Forms.Padding(4);
            this.rtbResultadoIA.Name = "rtbResultadoIA";
            this.rtbResultadoIA.ReadOnly = true;
            this.rtbResultadoIA.Size = new System.Drawing.Size(1066, 726);
            this.rtbResultadoIA.TabIndex = 1;
            this.rtbResultadoIA.Text = "Selecciona una opción del panel lateral para comenzar el análisis...";
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.lblCargando);
            this.panelHeader.Controls.Add(this.lblTituloSeccion);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(27, 25);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(4);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1066, 86);
            this.panelHeader.TabIndex = 0;
            // 
            // lblCargando
            // 
            this.lblCargando.AutoSize = true;
            this.lblCargando.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargando.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.lblCargando.Location = new System.Drawing.Point(8, 49);
            this.lblCargando.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCargando.Name = "lblCargando";
            this.lblCargando.Size = new System.Drawing.Size(415, 25);
            this.lblCargando.TabIndex = 1;
            this.lblCargando.Text = "⏳ Analizando datos con IA, por favor espere...";
            this.lblCargando.Visible = false;
            // 
            // lblTituloSeccion
            // 
            this.lblTituloSeccion.AutoSize = true;
            this.lblTituloSeccion.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloSeccion.ForeColor = System.Drawing.Color.White;
            this.lblTituloSeccion.Location = new System.Drawing.Point(4, 0);
            this.lblTituloSeccion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTituloSeccion.Name = "lblTituloSeccion";
            this.lblTituloSeccion.Size = new System.Drawing.Size(433, 41);
            this.lblTituloSeccion.TabIndex = 0;
            this.lblTituloSeccion.Text = "Panel de Resultados Asistidos";
            // 
            // FormAnaliticaIA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 862);
            this.Controls.Add(this.panelCentral);
            this.Controls.Add(this.panelLateral);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1061, 605);
            this.Name = "FormAnaliticaIA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Analítica Avanzada con IA";
            this.panelLateral.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panelCentral.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLateral;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button btnAnalisisVentas;
        private System.Windows.Forms.Button btnAuditoriaCaja;
        private System.Windows.Forms.Button btnSugerirCompras;
        private System.Windows.Forms.Label lblTituloLateral;
        private System.Windows.Forms.Panel panelCentral;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTituloSeccion;
        private System.Windows.Forms.RichTextBox rtbResultadoIA;
        private System.Windows.Forms.Label lblCargando;
    }
}