using Common.Domain.Repository;
using Shop.Domain.CategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Aggregates.CategoryAgg.Repository;
public interface ICategoryRepository : IBaseRepository<Category>
{
}
