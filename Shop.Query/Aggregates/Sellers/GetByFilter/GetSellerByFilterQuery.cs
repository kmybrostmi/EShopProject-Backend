using Common.Query;
using Shop.Query.Aggregates.Sellers.DTOs;

namespace Shop.Query.Aggregates.Sellers.GetByFilter;
public class GetSellerByFilterQuery : QueryFilter<SellerFilterResult, SellerFilterParams>
{
    public GetSellerByFilterQuery(SellerFilterParams filterParams) : base(filterParams)
    {
    }
}
