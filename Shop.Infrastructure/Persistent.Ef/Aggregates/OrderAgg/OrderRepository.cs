using Shop.Domain.Aggregates.OrderAgg.Repository;
using Shop.Domain.OrderAgg;
using Shop.Infrastructure.Persistent.Ef.Aggregates._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.Ef.Aggregates.OrderAgg;

internal class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(ShopDbContext context) : base(context)
    {
    }

    public Task<Order> GetCurrentUserOrder(Guid userId)
    {
        throw new NotImplementedException();
    }
}

