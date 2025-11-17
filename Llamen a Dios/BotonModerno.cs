using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;
using FontAwesome.Sharp;

public class BotonModerno : IconButton
{
    // --- VARIABLES PRIVADAS ---

    // Colores de Fondo
    private Color colorFondoHover = Color.CornflowerBlue;
    private Color colorFondoClick = Color.RoyalBlue;
    private Color colorFondoOriginal;

    // Colores de Texto
    private Color colorTextoHover = Color.White;
    private Color colorTextoOriginal;

    // Colores de Ícono
    private Color colorIconoHover = Color.White;
    private Color colorIconoOriginal;

    // Bordes
    private int radioBorde = 20;
    private int grosorBorde = 0;
    private Color colorBorde = Color.White;

    public BotonModerno()
    {
        this.FlatStyle = FlatStyle.Flat;
        this.FlatAppearance.BorderSize = 0; // Apaga el borde cuadrado nativo
        this.Size = new Size(150, 40);
        this.Cursor = Cursors.Hand;

        // Configuraciones iniciales recomendadas
        this.IconColor = Color.White;
        this.IconSize = 25;
        this.ForeColor = Color.White;
        this.TextImageRelation = TextImageRelation.ImageBeforeText;
        this.ImageAlign = ContentAlignment.MiddleCenter;
    }

    // --- PROPIEDADES PARA EL DISEÑADOR (Visual Studio Properties) ---

    // *Nombres corregidos para evitar errores en el Designer*
    [Category("Colores Modernos - Fondo")]
    [Description("Color de fondo cuando el ratón está encima.")]
    public Color ColorHover { get { return colorFondoHover; } set { colorFondoHover = value; } }

    [Category("Colores Modernos - Fondo")]
    [Description("Color de fondo cuando se hace clic.")]
    public Color ColorClick { get { return colorFondoClick; } set { colorFondoClick = value; } }

    [Category("Colores Modernos - Texto/Ícono")]
    [Description("Color del texto cuando el ratón está encima.")]
    public Color ColorTextoHover { get { return colorTextoHover; } set { colorTextoHover = value; } }

    [Category("Colores Modernos - Texto/Ícono")]
    [Description("Color del ícono cuando el ratón está encima.")]
    public Color ColorIconoHover { get { return colorIconoHover; } set { colorIconoHover = value; } }

    [Category("Bordes Modernos")]
    [Description("Qué tan redondos son los bordes del botón.")]
    public int RadioBorde { get { return radioBorde; } set { radioBorde = value; this.Invalidate(); } }

    [Category("Bordes Modernos")]
    [Description("El grosor del borde. Ponlo en 0 para quitarlo.")]
    public int GrosorBorde { get { return grosorBorde; } set { grosorBorde = value; this.Invalidate(); } }

    [Category("Bordes Modernos")]
    [Description("El color del borde redondeado.")]
    public Color ColorBorde { get { return colorBorde; } set { colorBorde = value; this.Invalidate(); } }

    // --- EVENTOS DEL RATÓN ---

    protected override void OnMouseEnter(EventArgs e)
    {
        base.OnMouseEnter(e);

        // Guardamos los colores originales antes de cambiarlos
        colorFondoOriginal = this.BackColor;
        colorTextoOriginal = this.ForeColor;
        colorIconoOriginal = this.IconColor;

        // Aplicamos los colores de "Hover"
        this.BackColor = colorFondoHover;
        this.ForeColor = colorTextoHover;
        this.IconColor = colorIconoHover;
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);

        // Restauramos los colores originales al quitar el ratón
        this.BackColor = colorFondoOriginal;
        this.ForeColor = colorTextoOriginal;
        this.IconColor = colorIconoOriginal;
    }

    protected override void OnMouseDown(MouseEventArgs mevent)
    {
        base.OnMouseDown(mevent);
        // Al hacer clic, aplicamos el color de click (solo fondo)
        this.BackColor = colorFondoClick;
    }

    protected override void OnMouseUp(MouseEventArgs mevent)
    {
        base.OnMouseUp(mevent);
        // Al soltar el clic, regresamos a los colores de hover
        this.BackColor = colorFondoHover;
        this.ForeColor = colorTextoHover;
        this.IconColor = colorIconoHover;
    }

    // --- DIBUJO AVANZADO (FONDO Y BORDE) ---

    private GraphicsPath ObtenerRuta(Rectangle rect, int radio)
    {
        GraphicsPath ruta = new GraphicsPath();
        float tamañoCurva = radio * 2F;

        if (radio <= 0)
        {
            ruta.AddRectangle(rect);
            return ruta;
        }

        ruta.StartFigure();
        ruta.AddArc(rect.X, rect.Y, tamañoCurva, tamañoCurva, 180, 90);
        ruta.AddArc(rect.Right - tamañoCurva, rect.Y, tamañoCurva, tamañoCurva, 270, 90);
        ruta.AddArc(rect.Right - tamañoCurva, rect.Bottom - tamañoCurva, tamañoCurva, tamañoCurva, 0, 90);
        ruta.AddArc(rect.X, rect.Bottom - tamañoCurva, tamañoCurva, tamañoCurva, 90, 90);
        ruta.CloseFigure();

        return ruta;
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);

        pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        Rectangle areaSuperficie = this.ClientRectangle;
        GraphicsPath rutaSuperficie = ObtenerRuta(areaSuperficie, radioBorde);
        this.Region = new Region(rutaSuperficie);

        // Si se configuró un grosor de borde, lo dibujamos siguiendo la misma curva
        if (grosorBorde >= 1)
        {
            using (Pen lapizBorde = new Pen(colorBorde, grosorBorde))
            {
                lapizBorde.Alignment = PenAlignment.Inset;
                pevent.Graphics.DrawPath(lapizBorde, rutaSuperficie);
            }
        }
    }
}