using Common.Domain.Repository;
using Shop.Domain.OrderAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Aggregates.OrderAgg.Repository;
public interface IOrderRepository : IBaseRepository<Order>
{
}
