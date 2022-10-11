using Common.Domain.Repository;
using Shop.Domain.RoleAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Aggregates.RoleAgg.Repository;
public interface IRoleRepository : IBaseRepository<Role>
{
}
