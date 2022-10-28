using Common.Query;
using Shop.Query.Aggregates.Users.DTOs;

namespace Shop.Query.Aggregates.Users.GetByFilter;
public class GetUserByFilterQuery : QueryFilter<UserFilterResult, UserFilterParams>
{
    public GetUserByFilterQuery(UserFilterParams filterParams) : base(filterParams)
    {
    }
}
