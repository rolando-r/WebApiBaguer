using Api.Interfaces;
using Core.Entities;

namespace Domain.Interfaces;

public interface IUsuario : IGenericRepository<Usuario>
{
    Task<Usuario> GetByUsernameAsync(string username);
}
