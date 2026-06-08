using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Llamen_a_Dios
{
    public class GroupBoxModerno : GroupBox
    {
        // Propiedades configurables desde el Diseñador
        private int borderRadius = 15;
        private Color borderColor = Color.FromArgb(226, 232, 240); // Gris claro moderno
        private int borderSize = 2;
        private Color backgroundColor = Color.White;
        private bool redondearAbajo = true; // ¡AQUÍ ESTÁ LA PROPIEDAD!

        public int BorderRadius
        {
            get { return borderRadius; }
            set { borderRadius = value; this.Invalidate(); }
        }

        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; this.Invalidate(); }
        }

        public int BorderSize
        {
            get { return borderSize; }
            set { borderSize = value; this.Invalidate(); }
        }

        public Color BackgroundColor
        {
            get { return backgroundColor; }
            set { backgroundColor = value; this.Invalidate(); }
        }

        public bool RedondearAbajo
        {
            get { return redondearAbajo; }
            set { redondearAbajo = value; this.Invalidate(); }
        }

        public GroupBoxModerno()
        {
            this.DoubleBuffered = true;
            this.BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // ESCUDO 1: Evitar que intente dibujar si el tamaño es muy pequeño o inválido
            if (this.Width <= 1 || this.Height <= 1) return;

            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            int textHeight = (int)graphics.MeasureString(this.Text, this.Font).Height;

            // ESCUDO 2: Evitar alturas negativas
            int altoReal = this.Height - (textHeight / 2) - 1;
            if (altoReal <= 0) return;

            Rectangle rectBackground = new Rectangle(0, textHeight / 2, this.Width - 1, altoReal);

            GraphicsPath pathBorder = GetFigurePath(rectBackground, borderRadius);

            // 1. Dibujar el fondo del contenedor
            using (SolidBrush brushBackground = new SolidBrush(backgroundColor))
            {
                graphics.FillPath(brushBackground, pathBorder);
            }

            // 2. Dibujar el borde redondeado
            if (borderSize > 0)
            {
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    graphics.DrawPath(penBorder, pathBorder);
                }
            }

            // 3. Dibujar el Texto (Título del GroupBox)
            if (!string.IsNullOrEmpty(this.Text))
            {
                using (SolidBrush brushText = new SolidBrush(this.ForeColor))
                {
                    SizeF textSize = graphics.MeasureString(this.Text, this.Font);
                    RectangleF textRect = new RectangleF(10, 0, textSize.Width, textSize.Height);

                    using (SolidBrush brushParent = new SolidBrush(this.Parent?.BackColor ?? backgroundColor))
                    {
                        graphics.FillRectangle(brushParent, textRect);
                    }

                    graphics.DrawString(this.Text, this.Font, brushText, textRect.Location);
                }
            }
        }

        // Método auxiliar para calcular las curvas de las esquinas
        private GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            // ESCUDO 3: Si la curva es más grande que el cuadro, limitarla
            if (curveSize > rect.Width) curveSize = rect.Width - 1;
            if (curveSize > rect.Height) curveSize = rect.Height - 1;

            if (curveSize <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            path.StartFigure();

            // Esquinas Superiores (Siempre redondas)
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);

            // Esquinas Inferiores
            if (redondearAbajo)
            {
                path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
                path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            }
            else
            {
                // Cuadradas (Líneas rectas hacia las esquinas inferiores)
                path.AddLine(rect.Right, rect.Bottom, rect.X, rect.Bottom);
            }

            path.CloseFigure();
            return path;
        }
    }
}