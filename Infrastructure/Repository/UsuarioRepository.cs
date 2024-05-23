using Core.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
public class UsuarioRepository : GenericRepository<Usuario>, IUsuario
{
    public UsuarioRepository(WebApiBaguerContext context) : base(context)
    { 
    }

    public async Task<Usuario> GetByUsernameAsync(string username)
    {
        return await _context.Usuarios
            .Include(u => u.RolId)
            .FirstOrDefaultAsync(u => u.NombreUsuario.ToLower() == username.ToLower());
    }
}
