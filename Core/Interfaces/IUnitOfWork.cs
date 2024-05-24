using Core.Interfaces;

namespace Core.Interfaces;


public interface IUnitOfWork
{
    public IRol Roles { get; }
    public IUsuario Usuarios {get;}
    public IRefreshToken RefreshIRefreshTokens { get; }
    Task<int> SaveAsync();
}