using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

[DefaultEvent("_TextChanged")]
public class TextBoxModerno : UserControl
{
    // --- VARIABLES PRIVADAS ---
    private Color colorBorde = Color.Gray;
    private Color colorBordeFocus = Color.CornflowerBlue;
    private int grosorBorde = 2;
    private int radioBorde = 15;
    private bool estaEnfocado = false;

    // El TextBox real que irá adentro de nuestro diseño
    private TextBox textBox1;

    // Evento personalizado para cuando cambie el texto
    public event EventHandler _TextChanged;

    public TextBoxModerno()
    {
        // Configuramos el TextBox interno
        textBox1 = new TextBox();
        textBox1.BorderStyle = BorderStyle.None;
        textBox1.Dock = DockStyle.Fill;
        textBox1.BackColor = this.BackColor;
        textBox1.Font = this.Font;

        // Eventos para saber si el usuario está escribiendo o hizo clic
        textBox1.Enter += new EventHandler(TextBox1_Enter);
        textBox1.Leave += new EventHandler(TextBox1_Leave);
        textBox1.TextChanged += new EventHandler(TextBox1_TextChanged);

        // Agregamos el TextBox a nuestro Control de Usuario
        this.Controls.Add(textBox1);

        // Configuramos nuestro Control de Usuario (El contenedor)
        this.Padding = new Padding(10, 7, 10, 7);
        this.Size = new Size(250, 30);
        this.BackColor = Color.White;
        this.ForeColor = Color.DimGray;
    }

    // --- PROPIEDADES PARA EL DISEÑADOR (BORDES) ---

    [Category("Bordes Modernos")]
    public Color ColorBorde
    {
        get { return colorBorde; }
        set { colorBorde = value; this.Invalidate(); }
    }

    [Category("Bordes Modernos")]
    [Description("Color del borde cuando el usuario hace clic para escribir.")]
    public Color ColorBordeFocus
    {
        get { return colorBordeFocus; }
        set { colorBordeFocus = value; }
    }

    [Category("Bordes Modernos")]
    public int GrosorBorde
    {
        get { return grosorBorde; }
        set { grosorBorde = value; this.Invalidate(); }
    }

    [Category("Bordes Modernos")]
    public int RadioBorde
    {
        get { return radioBorde; }
        set { radioBorde = value; this.Invalidate(); }
    }

    // --- PROPIEDADES DEL TEXTBOX ---

    [Category("Propiedades TextBox")]
    [Browsable(true)]
    public override string Text
    {
        get { return textBox1.Text; }
        set { textBox1.Text = value; }
    }

    [Category("Propiedades TextBox")]
    [Browsable(true)]
    [Description("Alineación del texto (Izquierda, Centro, Derecha).")]
    public HorizontalAlignment TextAlign
    {
        get { return textBox1.TextAlign; }
        set { textBox1.TextAlign = value; }
    }

    [Category("Propiedades TextBox")]
    [Description("Ponlo en True para contraseñas (oculta los caracteres).")]
    public bool UseSystemPasswordChar
    {
        get { return textBox1.UseSystemPasswordChar; }
        set { textBox1.UseSystemPasswordChar = value; }
    }

    [Category("Propiedades TextBox")]
    public char PasswordChar
    {
        get { return textBox1.PasswordChar; }
        set { textBox1.PasswordChar = value; }
    }

    // Mantenemos sincronizados los colores y fuentes
    public override Color BackColor
    {
        get { return base.BackColor; }
        set { base.BackColor = value; textBox1.BackColor = value; }
    }

    public override Color ForeColor
    {
        get { return base.ForeColor; }
        set { base.ForeColor = value; textBox1.ForeColor = value; }
    }

    public override Font Font
    {
        get { return base.Font; }
        set { base.Font = value; textBox1.Font = value; if (this.DesignMode) ActualizarAltura(); }
    }

    // --- MÉTODOS Y PROPIEDADES EXTRA MUY ÚTILES ---

    [Category("Propiedades TextBox")]
    [Description("Limpia todo el texto del control.")]
    public void Clear()
    {
        textBox1.Clear();
    }

    [Category("Propiedades TextBox")]
    [Description("Pone el cursor parpadeando dentro de este cuadro de texto.")]
    public new void Select()
    {
        textBox1.Select();
        textBox1.Focus();
    }

    [Category("Propiedades TextBox")]
    [Description("Número máximo de caracteres permitidos. (0 = sin límite)")]
    public int MaxLength
    {
        get { return textBox1.MaxLength; }
        set { textBox1.MaxLength = value; }
    }

    [Category("Propiedades TextBox")]
    [Description("Indica si el texto es de solo lectura (no se puede editar).")]
    public bool ReadOnly
    {
        get { return textBox1.ReadOnly; }
        set { textBox1.ReadOnly = value; }
    }

    // --- EVENTOS DE ENFOQUE (Click adentro o afuera) ---

    private void TextBox1_Enter(object sender, EventArgs e)
    {
        estaEnfocado = true;
        this.Invalidate(); // Redibujar con el color de Focus
    }

    private void TextBox1_Leave(object sender, EventArgs e)
    {
        estaEnfocado = false;
        this.Invalidate(); // Redibujar con el color Normal
    }

    private void TextBox1_TextChanged(object sender, EventArgs e)
    {
        if (_TextChanged != null) _TextChanged.Invoke(sender, e);
    }

    // Ajusta la altura si se cambia el tamaño de la letra
    private void ActualizarAltura()
    {
        textBox1.Multiline = true;
        textBox1.MinimumSize = new Size(0, textBox1.Height);
        textBox1.Multiline = false;
        this.Height = textBox1.Height + this.Padding.Top + this.Padding.Bottom;
    }

    // --- DIBUJO DE LOS BORDES REDONDEADOS ---

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

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics graficos = e.Graphics;
        graficos.SmoothingMode = SmoothingMode.AntiAlias;

        Rectangle rectBorde = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
        GraphicsPath rutaBorde = ObtenerRuta(rectBorde, radioBorde);
        this.Region = new Region(ObtenerRuta(this.ClientRectangle, radioBorde)); // Cortar esquinas

        // Elegir el color dependiendo de si el usuario está escribiendo o no
        Color colorActual = estaEnfocado ? colorBordeFocus : colorBorde;

        if (grosorBorde >= 1)
        {
            using (Pen lapizBorde = new Pen(colorActual, grosorBorde))
            {
                lapizBorde.Alignment = PenAlignment.Inset;
                graficos.DrawPath(lapizBorde, rutaBorde);
            }
        }
    }
}