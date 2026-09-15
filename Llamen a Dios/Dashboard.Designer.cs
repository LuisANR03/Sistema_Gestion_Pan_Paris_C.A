namespace Llamen_a_Dios
{
    partial class Dashboard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlAccentBar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlCardVentas = new System.Windows.Forms.Panel();
            this.lblTotalMes = new System.Windows.Forms.Label();
            this.lblVentasTitulo = new System.Windows.Forms.Label();
            this.pnlCardStock = new System.Windows.Forms.Panel();
            this.lblAlertasStock = new System.Windows.Forms.Label();
            this.lblStockTitulo = new System.Windows.Forms.Label();
            this.pnlCardProductos = new System.Windows.Forms.Panel();
            this.lblTotalProductos = new System.Windows.Forms.Label();
            this.lblProdTitulo = new System.Windows.Forms.Label();
            this.chartTopProductos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlHeader.SuspendLayout();
            this.pnlCardVentas.SuspendLayout();
            this.pnlCardStock.SuspendLayout();
            this.pnlCardProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.pnlAccentBar);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1333, 86);
            this.pnlHeader.TabIndex = 0;
            // 
            // pnlAccentBar
            // 
            this.pnlAccentBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(158)))), ((int)(((byte)(87)))));
            this.pnlAccentBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAccentBar.Location = new System.Drawing.Point(0, 81);
            this.pnlAccentBar.Margin = new System.Windows.Forms.Padding(4);
            this.pnlAccentBar.Name = "pnlAccentBar";
            this.pnlAccentBar.Size = new System.Drawing.Size(1333, 5);
            this.pnlAccentBar.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.lblTitle.Location = new System.Drawing.Point(33, 22);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(448, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Panel de Control - Pan de Paris";
            // 
            // pnlCardVentas
            // 
            this.pnlCardVentas.BackColor = System.Drawing.Color.White;
            this.pnlCardVentas.Controls.Add(this.lblTotalMes);
            this.pnlCardVentas.Controls.Add(this.lblVentasTitulo);
            this.pnlCardVentas.Location = new System.Drawing.Point(41, 123);
            this.pnlCardVentas.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCardVentas.Name = "pnlCardVentas";
            this.pnlCardVentas.Size = new System.Drawing.Size(373, 135);
            this.pnlCardVentas.TabIndex = 1;
            // 
            // lblTotalMes
            // 
            this.lblTotalMes.AutoSize = true;
            this.lblTotalMes.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.lblTotalMes.Location = new System.Drawing.Point(16, 55);
            this.lblTotalMes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalMes.Name = "lblTotalMes";
            this.lblTotalMes.Size = new System.Drawing.Size(126, 50);
            this.lblTotalMes.TabIndex = 1;
            this.lblTotalMes.Text = "$ 0.00";
            // 
            // lblVentasTitulo
            // 
            this.lblVentasTitulo.AutoSize = true;
            this.lblVentasTitulo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVentasTitulo.ForeColor = System.Drawing.Color.DarkGray;
            this.lblVentasTitulo.Location = new System.Drawing.Point(20, 18);
            this.lblVentasTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVentasTitulo.Name = "lblVentasTitulo";
            this.lblVentasTitulo.Size = new System.Drawing.Size(150, 23);
            this.lblVentasTitulo.TabIndex = 0;
            this.lblVentasTitulo.Text = "VENTAS DEL MES";
            // 
            // pnlCardStock
            // 
            this.pnlCardStock.BackColor = System.Drawing.Color.White;
            this.pnlCardStock.Controls.Add(this.lblAlertasStock);
            this.pnlCardStock.Controls.Add(this.lblStockTitulo);
            this.pnlCardStock.Location = new System.Drawing.Point(467, 123);
            this.pnlCardStock.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCardStock.Name = "pnlCardStock";
            this.pnlCardStock.Size = new System.Drawing.Size(373, 135);
            this.pnlCardStock.TabIndex = 2;
            // 
            // lblAlertasStock
            // 
            this.lblAlertasStock.AutoSize = true;
            this.lblAlertasStock.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlertasStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.lblAlertasStock.Location = new System.Drawing.Point(16, 55);
            this.lblAlertasStock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAlertasStock.Name = "lblAlertasStock";
            this.lblAlertasStock.Size = new System.Drawing.Size(43, 50);
            this.lblAlertasStock.TabIndex = 1;
            this.lblAlertasStock.Text = "0";
            // 
            // lblStockTitulo
            // 
            this.lblStockTitulo.AutoSize = true;
            this.lblStockTitulo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockTitulo.ForeColor = System.Drawing.Color.DarkGray;
            this.lblStockTitulo.Location = new System.Drawing.Point(20, 18);
            this.lblStockTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStockTitulo.Name = "lblStockTitulo";
            this.lblStockTitulo.Size = new System.Drawing.Size(168, 23);
            this.lblStockTitulo.TabIndex = 0;
            this.lblStockTitulo.Text = "ALERTAS DE STOCK";
            // 
            // pnlCardProductos
            // 
            this.pnlCardProductos.BackColor = System.Drawing.Color.White;
            this.pnlCardProductos.Controls.Add(this.lblTotalProductos);
            this.pnlCardProductos.Controls.Add(this.lblProdTitulo);
            this.pnlCardProductos.Location = new System.Drawing.Point(893, 123);
            this.pnlCardProductos.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCardProductos.Name = "pnlCardProductos";
            this.pnlCardProductos.Size = new System.Drawing.Size(373, 135);
            this.pnlCardProductos.TabIndex = 3;
            // 
            // lblTotalProductos
            // 
            this.lblTotalProductos.AutoSize = true;
            this.lblTotalProductos.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalProductos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(158)))), ((int)(((byte)(87)))));
            this.lblTotalProductos.Location = new System.Drawing.Point(16, 55);
            this.lblTotalProductos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalProductos.Name = "lblTotalProductos";
            this.lblTotalProductos.Size = new System.Drawing.Size(43, 50);
            this.lblTotalProductos.TabIndex = 1;
            this.lblTotalProductos.Text = "0";
            // 
            // lblProdTitulo
            // 
            this.lblProdTitulo.AutoSize = true;
            this.lblProdTitulo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProdTitulo.ForeColor = System.Drawing.Color.DarkGray;
            this.lblProdTitulo.Location = new System.Drawing.Point(20, 18);
            this.lblProdTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProdTitulo.Name = "lblProdTitulo";
            this.lblProdTitulo.Size = new System.Drawing.Size(168, 23);
            this.lblProdTitulo.TabIndex = 0;
            this.lblProdTitulo.Text = "TOTAL PRODUCTOS";
            // 
            // chartTopProductos
            // 
            this.chartTopProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            chartArea1.Name = "ChartArea1";
            this.chartTopProductos.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartTopProductos.Legends.Add(legend1);
            this.chartTopProductos.Location = new System.Drawing.Point(41, 295);
            this.chartTopProductos.Margin = new System.Windows.Forms.Padding(4);
            this.chartTopProductos.Name = "chartTopProductos";
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            series1.Legend = "Legend1";
            series1.Name = "Unidades";
            this.chartTopProductos.Series.Add(series1);
            this.chartTopProductos.Size = new System.Drawing.Size(1225, 443);
            this.chartTopProductos.TabIndex = 4;
            this.chartTopProductos.Text = "chartTopProductos";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(1333, 788);
            this.Controls.Add(this.chartTopProductos);
            this.Controls.Add(this.pnlCardProductos);
            this.Controls.Add(this.pnlCardStock);
            this.Controls.Add(this.pnlCardVentas);
            this.Controls.Add(this.pnlHeader);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard Gerencial";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlCardVentas.ResumeLayout(false);
            this.pnlCardVentas.PerformLayout();
            this.pnlCardStock.ResumeLayout(false);
            this.pnlCardStock.PerformLayout();
            this.pnlCardProductos.ResumeLayout(false);
            this.pnlCardProductos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopProductos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlAccentBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlCardVentas;
        private System.Windows.Forms.Label lblVentasTitulo;
        private System.Windows.Forms.Label lblTotalMes;
        private System.Windows.Forms.Panel pnlCardStock;
        private System.Windows.Forms.Label lblStockTitulo;
        private System.Windows.Forms.Label lblAlertasStock;
        private System.Windows.Forms.Panel pnlCardProductos;
        private System.Windows.Forms.Label lblProdTitulo;
        private System.Windows.Forms.Label lblTotalProductos;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTopProductos;
    }
}