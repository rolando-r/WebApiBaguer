namespace Core.Entities;
public class Usuario
{
    public int UsuarioId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Nombre { get; set; }
    public ICollection<Rol> Roles { get; set; } = new HashSet<Rol>();
    public ICollection<UsuarioRoles> UsuarioRoles { get; set; }
    public ICollection<RefreshToken> RefreshTokens { get; set; }  = new HashSet<RefreshToken>();
}