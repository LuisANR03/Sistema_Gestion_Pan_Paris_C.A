
using Entidades;

public class Usuario
{
    public int IdUsuario { get; set; }
    public string Cedula { get; set; }
    public string Nombre { get; set; }
    public string Correo { get; set; }
    public string Clave { get; set; }
    public bool Estado { get; set; }

    
    public Rol oRol { get; set; }
}