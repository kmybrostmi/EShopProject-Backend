﻿using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure;
using Shop.Query.Aggregates.Comments.DTOs;

namespace Shop.Query.Aggregates.Comments.GetByFilter;

public class GetCommentsByFilterQueryHandler : IQueryHandler<GetCommentsByFilterQuery, CommentFilterResult>
{
    private readonly ShopDbContext _context;

    public GetCommentsByFilterQueryHandler(ShopDbContext context)
    {
        _context = context;
    }
    public async Task<CommentFilterResult> Handle(GetCommentsByFilterQuery request, CancellationToken cancellationToken)
    {
        var @params = request.FilterParams;

        var result = _context.Comments.OrderByDescending(o => o.CreateDate).AsQueryable();

        if (@params.ProductId != null)
            result = result.Where(r => r.UserId == @params.ProductId);

        if (@params.CommentStatus != null)
            result = result.Where(r => r.Status == @params.CommentStatus);

        if (@params.UserId != null)
            result = result.Where(r => r.UserId == @params.UserId);

        if (@params.StartDate != null)
            result = result.Where(r => r.CreateDate.Date >= @params.StartDate.Value.Date);

        if (@params.EndDate != null)
            result = result.Where(r => r.CreateDate.Date <= @params.EndDate.Value.Date);

        var skip = (@params.PageId - 1) * @params.Take;
        var model = new CommentFilterResult()
        {
            Data = await result.Skip(skip).Take(@params.Take)
                .Select(comment => comment.MapFilterComment())
                .ToListAsync(cancellationToken),
            FilterParams = @params
        };
        model.GeneratePaging(result, @params.Take, @params.PageId);
        return model;
    }
}

