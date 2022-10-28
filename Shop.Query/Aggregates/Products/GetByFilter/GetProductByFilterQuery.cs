using Common.Query;
using Shop.Query.Aggregates.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Aggregates.Products.GetByFilter;
public class GetProductByFilterQuery : QueryFilter<ProductFilterResult, ProductFilterParams>
{
    public GetProductByFilterQuery(ProductFilterParams filterParams) : base(filterParams)
    {
    }
}
