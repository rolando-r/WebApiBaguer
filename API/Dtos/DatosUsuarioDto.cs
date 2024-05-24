using System.Text.Json.Serialization;

namespace API.Dtos;
public class DatosUsuarioDto
{
    public string Message { get; set; }
    public bool IsAuthenticated { get; set; }
    public string UserName { get; set; }
    public string Nombre { get; set; }
    public List<string> Roles { get; set; }
    public string Token { get; set; }

    [JsonIgnore] // ->Este atributo restringe al propietario ver el resultado
    public string RefreshToken { get; set; }
    public DateTime RefreshTokenExpiration { get; set; } 
}