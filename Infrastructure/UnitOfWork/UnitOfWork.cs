using Infrastructure.Repository;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{

    RolRepository _rol;
    UsuarioRepository _usuario;
    RefreshTokenRepository _refreshToken;

    private readonly WebApiBaguerContext _context;
    public UnitOfWork(WebApiBaguerContext context)
    {
        _context = context;
    }

    public IRol Roles
    {
        get
        {
            _rol ??= new RolRepository(_context);
            return _rol;
        }
    }

    public IUsuario Usuarios
    {
        get
        {
            _usuario ??= new UsuarioRepository(_context);
            return _usuario;
        }
    }

    public IRefreshToken RefreshIRefreshTokens
    {
        get
        {
            _refreshToken ??= new RefreshTokenRepository(_context);
            return _refreshToken;
        }
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
