using Common.Domain.Repository;
using Shop.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Aggregates.ProductAgg.Repository;
public interface IProductRepository : IBaseRepository<Product>
{
}
