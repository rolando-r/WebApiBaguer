namespace Core.Entities;
public class Usuario : BaseEntity
{
    public string NombreUsuario { get; set; }
    public string Clave { get; set; }
    public string Nombre { get; set; }

    // Relaciones
    public int RolId { get; set; } // Unidireccional hacia la entidad rol
    public Rol Rol { get; set; }
}