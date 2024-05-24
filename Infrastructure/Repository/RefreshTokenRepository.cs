using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;

namespace Infrastructure.Repository;

public class RefreshTokenRepository : GenericRepository<RefreshToken>, IRefreshToken
{
    public RefreshTokenRepository(WebApiBaguerContext context) : base(context)
    { 
    }
}
