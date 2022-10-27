using Shop.Domain.ProductAgg.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Aggregates.Products;
public class ProductDomainService : IProductDomainService
{
    public bool IsSlugExist(string slug)
    {
        throw new NotImplementedException();
    }
}
