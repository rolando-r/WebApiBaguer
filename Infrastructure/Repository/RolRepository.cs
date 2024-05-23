using Core.Entities;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repository;
public class RolRepository : GenericRepository<Rol>, IRol
{
    public RolRepository(WebApiBaguerContext context) : base(context)
    { 
    }
}
