using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
public class UsuarioRepository : GenericRepository<Usuario>, IUsuario
{
    public UsuarioRepository(WebApiBaguerContext context) : base(context)
    { 
    }
    public override async Task<(int totalRegistros,IEnumerable<Usuario> registros)> GetAllAsync(int pageIndex,int pageSize,string search)
     {
        var query = _context.Usuarios as IQueryable<Usuario>;
        if(!string.IsNullOrEmpty(search))
        {
            query  = query.Where(p => p.Username.ToLower().Contains(search));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(u => u.RefreshTokens)
                                .Skip((pageIndex-1)*pageSize)
                                .Take(pageSize)
                                .ToListAsync();
        return ( totalRegistros, registros);
     }

    public async Task<Usuario> GetByRefreshTokenAsync(string refreshToken)
    {
        return await _context.Usuarios
            .Include(u => u.Roles)
            .Include(u => u.RefreshTokens)
            .FirstOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == refreshToken));
    }

    public async Task<Usuario> GetByUsernameAsync(string username)
    {
        return await _context.Usuarios
            .Include(u => u.Roles)
            .Include(u => u.RefreshTokens)
            .FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
    }
}
