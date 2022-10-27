using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure;
using Shop.Query.Aggregates.Comments.DTOs;

namespace Shop.Query.Aggregates.Comments.GetById;

public class GetCommentByIdQueryHandler : IQueryHandler<GetCommentByIdQuery, CommentDto?>
{
    private readonly ShopDbContext _context;

    public GetCommentByIdQueryHandler(ShopDbContext context)
    {
        _context = context;
    }
    public async Task<CommentDto?> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Comments.FirstOrDefaultAsync(f => f.Id == request.CommentId,cancellationToken);
        return result.Map();
    }
}