using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Llamen_a_Dios
{
    [DefaultEvent("OnSelectedIndexChanged")]
    public class ComboBoxModerno : UserControl
    {
        // Campos de apariencia
        private Color backColor = Color.WhiteSmoke;
        private Color iconColor = Color.FromArgb(25, 66, 210); // Azul de tu diseño
        private Color listBackColor = Color.FromArgb(230, 228, 245);
        private Color listTextColor = Color.DimGray;
        private Color borderColor = Color.FromArgb(200, 200, 200); // Gris clarito
        private int borderSize = 1;
        private int borderRadius = 8; // Radio del borde

        // Controles internos
        private ComboBox cmbList;
        private Label lblText;
        private Button btnIcon;

        // Eventos que vamos a exponer
        public event EventHandler OnSelectedIndexChanged;

        public ComboBoxModerno()
        {
            cmbList = new ComboBox();
            lblText = new Label();
            btnIcon = new Button();
            this.SuspendLayout();

            // Configurar ComboBox interno
            cmbList.BackColor = listBackColor;
            cmbList.Font = new Font(this.Font.Name, 10F);
            cmbList.ForeColor = listTextColor;
            cmbList.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbList.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
            cmbList.TextChanged += new EventHandler(ComboBox_TextChanged);

            // Configurar Botón de Icono (Flechita)
            btnIcon.Dock = DockStyle.Right;
            btnIcon.FlatStyle = FlatStyle.Flat;
            btnIcon.FlatAppearance.BorderSize = 0;
            btnIcon.BackColor = backColor;
            btnIcon.Size = new Size(30, 30);
            btnIcon.Cursor = Cursors.Hand;
            btnIcon.Click += new EventHandler(Icon_Click);
            btnIcon.Paint += new PaintEventHandler(Icon_Paint);

            // Configurar Label (Texto seleccionado)
            lblText.Dock = DockStyle.Fill;
            lblText.AutoSize = false;
            lblText.BackColor = backColor;
            lblText.TextAlign = ContentAlignment.MiddleLeft;
            lblText.Padding = new Padding(8, 0, 0, 0);
            lblText.Font = new Font("Segoe UI", 10F);
            lblText.ForeColor = Color.DimGray;
            lblText.Cursor = Cursors.Hand;
            lblText.Click += new EventHandler(Surface_Click);
            lblText.MouseEnter += new EventHandler(Surface_MouseEnter);
            lblText.MouseLeave += new EventHandler(Surface_MouseLeave);

            // Configurar UserControl
            this.Controls.Add(lblText);
            this.Controls.Add(btnIcon);
            this.Controls.Add(cmbList); // Se agrega pero queda oculto detrás
            this.MinimumSize = new Size(150, 30);
            this.Size = new Size(200, 35);
            this.ForeColor = Color.DimGray;
            this.Padding = new Padding(borderSize);
            this.BackColor = borderColor;
            this.ResumeLayout();
            AdjustComboBoxDimensions();
        }

        // --- PROPIEDADES EXPUESTAS ---
        [Category("Estilo Moderno")]
        public Color BackColorModerno
        {
            get { return backColor; }
            set { backColor = value; lblText.BackColor = backColor; btnIcon.BackColor = backColor; }
        }

        [Category("Estilo Moderno")]
        public Color IconColor
        {
            get { return iconColor; }
            set { iconColor = value; btnIcon.Invalidate(); }
        }

        [Category("Estilo Moderno")]
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; base.BackColor = borderColor; } // El backcolor base actúa como borde
        }

        [Category("Estilo Moderno")]
        public int BorderSize
        {
            get { return borderSize; }
            set { borderSize = value; this.Padding = new Padding(borderSize); AdjustComboBoxDimensions(); }
        }

        [Category("Estilo Moderno")]
        public int BorderRadius
        {
            get { return borderRadius; }
            set { borderRadius = value; this.Invalidate(); }
        }

        // --- PROPIEDADES DEL COMBOBOX INTERNO (Fundamentales para la base de datos) ---
        [Category("Datos")]
        public ComboBox.ObjectCollection Items => cmbList.Items;
        [Category("Datos")]
        public object DataSource { get => cmbList.DataSource; set => cmbList.DataSource = value; }
        [Category("Datos")]
        public string DisplayMember { get => cmbList.DisplayMember; set => cmbList.DisplayMember = value; }
        [Category("Datos")]
        public string ValueMember { get => cmbList.ValueMember; set => cmbList.ValueMember = value; }
        [Category("Datos")]
        public int SelectedIndex { get => cmbList.SelectedIndex; set => cmbList.SelectedIndex = value; }
        [Category("Datos")]
        public object SelectedItem { get => cmbList.SelectedItem; set => cmbList.SelectedItem = value; }

        // ¡AQUÍ ESTÁ LA PROPIEDAD QUE FALTABA PARA QUE NO DE ERROR!
        [Category("Datos")]
        [Bindable(true)]
        public object SelectedValue { get => cmbList.SelectedValue; set => cmbList.SelectedValue = value; }

        public override string Text
        {
            get { return lblText.Text; }
            set { lblText.Text = value; }
        }

        // --- MÉTODOS PRIVADOS Y DIBUJOS ---
        private void AdjustComboBoxDimensions()
        {
            cmbList.Width = lblText.Width;
            cmbList.Location = new Point()
            {
                X = this.Width - this.Padding.Right - cmbList.Width,
                Y = lblText.Bottom - cmbList.Height
            };
        }

        private void Surface_Click(object sender, EventArgs e)
        {
            cmbList.Select();
            if (cmbList.DropDownStyle == ComboBoxStyle.DropDownList)
                cmbList.DroppedDown = true; // Abre la lista al hacer clic
        }

        private void Icon_Click(object sender, EventArgs e)
        {
            cmbList.Select();
            cmbList.DroppedDown = true;
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OnSelectedIndexChanged != null)
                OnSelectedIndexChanged.Invoke(sender, e);

            // Mejora visual: solo actualiza si hay algo seleccionado
            if (cmbList.SelectedIndex >= 0)
                lblText.Text = cmbList.Text;
            else
                lblText.Text = string.Empty;
        }

        private void ComboBox_TextChanged(object sender, EventArgs e)
        {
            lblText.Text = cmbList.Text;
        }

        // Cambiar color al pasar el mouse
        private void Surface_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void Surface_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        // Dibujar bordes redondeados
        private GraphicsPath GetFigurePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Rectangle rectSurface = this.ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);
            int smoothSize = 2;

            if (borderRadius > 2) // Si tiene bordes redondeados
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
                using (Pen penSurface = new Pen(this.Parent.BackColor, smoothSize))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    this.Region = new Region(pathSurface);
                    e.Graphics.DrawPath(penSurface, pathSurface); // Borde del formulario padre
                    if (borderSize >= 1) e.Graphics.DrawPath(penBorder, pathBorder); // Borde de color
                }
            }
        }

        // Dibujar la flechita del DropDown a mano
        private void Icon_Paint(object sender, PaintEventArgs e)
        {
            int iconWidth = 12;
            int iconHeight = 6;
            var rectIcon = new Rectangle((btnIcon.Width - iconWidth) / 2, (btnIcon.Height - iconHeight) / 2, iconWidth, iconHeight);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (GraphicsPath path = new GraphicsPath())
            using (Pen pen = new Pen(iconColor, 2))
            {
                // Dibuja una "V" para la flecha
                path.AddLine(rectIcon.X, rectIcon.Y, rectIcon.X + (iconWidth / 2), rectIcon.Bottom);
                path.AddLine(rectIcon.X + (iconWidth / 2), rectIcon.Bottom, rectIcon.Right, rectIcon.Y);
                e.Graphics.DrawPath(pen, path);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AdjustComboBoxDimensions();
        }
    }
}