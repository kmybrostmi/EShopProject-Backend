using Shop.Domain.Aggregates.RoleAgg.Repository;
using Shop.Domain.RoleAgg;
using Shop.Infrastructure.Persistent.Ef.Aggregates._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.Aggregates.RoleAgg;
internal class RoleRepository : BaseRepository<Role>, IRoleRepository
{
    public RoleRepository(ShopDbContext context) : base(context)
    {
    }
}
