using Common.Domain.Repository;
using Shop.Domain.UserAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Aggregates.UserAgg.Repository;
public interface IUserRepository : IBaseRepository<User>
{
}
