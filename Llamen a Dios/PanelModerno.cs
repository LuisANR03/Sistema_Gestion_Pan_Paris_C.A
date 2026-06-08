using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Llamen_a_Dios
{
    public class PanelModerno : Panel
    {
        private int borderRadius = 15;
        private Color backgroundColor = Color.FromArgb(37, 99, 235); // Azul por defecto
        private bool redondearAbajo = true; // NUEVA PROPIEDAD

        public int BorderRadius
        {
            get { return borderRadius; }
            set { borderRadius = value; this.Invalidate(); }
        }

        public Color BackgroundColor
        {
            get { return backgroundColor; }
            set { backgroundColor = value; this.Invalidate(); }
        }

        // Propiedad para activar o desactivar las curvas inferiores
        public bool RedondearAbajo
        {
            get { return redondearAbajo; }
            set { redondearAbajo = value; this.Invalidate(); }
        }

        public PanelModerno()
        {
            this.DoubleBuffered = true;
            this.BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // ESCUDO 1: Evitar crasheos en el diseñador si el tamaño es muy pequeño
            if (this.Width <= 0 || this.Height <= 0) return;

            base.OnPaint(e);
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);

            if (borderRadius > 0)
            {
                using (GraphicsPath path = GetFigurePath(rect, borderRadius))
                using (SolidBrush brush = new SolidBrush(backgroundColor))
                {
                    graphics.FillPath(brush, path);
                }
            }
            else
            {
                using (SolidBrush brush = new SolidBrush(backgroundColor))
                {
                    graphics.FillRectangle(brush, rect);
                }
            }
        }

        private GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            // ESCUDO 2: Evitar que la curva sea más grande que el panel
            if (curveSize > rect.Width) curveSize = rect.Width - 1;
            if (curveSize > rect.Height) curveSize = rect.Height - 1;

            if (curveSize <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            path.StartFigure();

            // Esquinas Superiores (Siempre redondas)
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90); // Arriba Izquierda
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90); // Arriba Derecha

            // Esquinas Inferiores
            if (redondearAbajo)
            {
                // Redondas
                path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90); // Abajo Derecha
                path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90); // Abajo Izquierda
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