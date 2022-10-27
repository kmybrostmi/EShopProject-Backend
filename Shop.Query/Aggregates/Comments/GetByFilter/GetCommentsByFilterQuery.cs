using Common.Query;
using Common.Query.Filter;
using Shop.Query.Aggregates.Comments.DTOs;

namespace Shop.Query.Aggregates.Comments.GetByFilter;

public class GetCommentsByFilterQuery : QueryFilter<CommentFilterResult, CommentFilterParams>
{
    public GetCommentsByFilterQuery(CommentFilterParams filterParams) : base(filterParams)
    {
    }
}

