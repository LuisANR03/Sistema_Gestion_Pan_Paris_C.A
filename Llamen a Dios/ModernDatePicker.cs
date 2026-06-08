using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Llamen_a_Dios
{
    public class ModernDatePicker : DateTimePicker
    {
        // Colores basados en tu diseño actual
        private Color colorFondo = Color.White;
        private Color colorTexto = Color.FromArgb(71, 85, 105);
        private Color colorBorde = Color.FromArgb(147, 51, 234); // Morado
        private int tamañoBorde = 1;

        public ModernDatePicker()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.MinimumSize = new Size(0, 35); // Altura moderna
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (Graphics g = this.CreateGraphics())
            using (Pen lapizBorde = new Pen(colorBorde, tamañoBorde))
            using (SolidBrush brochaFondo = new SolidBrush(colorFondo))
            using (SolidBrush brochaTexto = new SolidBrush(colorTexto))
            using (StringFormat formatoTexto = new StringFormat())
            {
                RectangleF areaCliente = new RectangleF(0, 0, this.Width - 0.5F, this.Height - 0.5F);
                RectangleF areaIcono = new RectangleF(areaCliente.Width - 35, 0, 35, this.Height);

                g.SmoothingMode = SmoothingMode.AntiAlias;

                // 1. Dibujar el fondo
                g.FillRectangle(brochaFondo, areaCliente);

                // 2. Dibujar el texto (La fecha)
                formatoTexto.LineAlignment = StringAlignment.Center;
                g.DrawString("   " + this.Text, this.Font, brochaTexto, areaCliente, formatoTexto);

                // 3. Dibujar un icono de flecha simple a la derecha
                PointF p1 = new PointF(areaIcono.X + 12, areaIcono.Y + 14);
                PointF p2 = new PointF(areaIcono.X + 22, areaIcono.Y + 14);
                PointF p3 = new PointF(areaIcono.X + 17, areaIcono.Y + 20);
                g.FillPolygon(new SolidBrush(colorBorde), new PointF[] { p1, p2, p3 });

                // 4. Dibujar el borde
                g.DrawRectangle(lapizBorde, areaCliente.X, areaCliente.Y, areaCliente.Width, areaCliente.Height);
            }
        }
    }
}