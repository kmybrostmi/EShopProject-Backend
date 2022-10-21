using Shop.Domain.Aggregates.UserAgg.Repository;
using Shop.Domain.UserAgg;
using Shop.Infrastructure.Persistent.Ef.Aggregates._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.Ef.Aggregates.UserAgg;

internal class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(ShopDbContext context) : base(context)
    {
    }
}
