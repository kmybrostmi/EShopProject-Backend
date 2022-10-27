using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure;
using Shop.Query.Aggregates.Orders.DTOs;

namespace Shop.Query.Aggregates.Orders.GetByFilter;

public class GetOrdersByFilterQueryHandler : IQueryHandler<GetOrdersByFilterQuery, OrderFilterResult>
{
    private readonly ShopDbContext _context;

    public GetOrdersByFilterQueryHandler(ShopDbContext context)
    {
        _context = context;
    }
    public async Task<OrderFilterResult> Handle(GetOrdersByFilterQuery request, CancellationToken cancellationToken)
    {
        var @params = request.FilterParams;
        var result = _context.Orders.OrderByDescending(c => c.Id).AsQueryable();

        if (@params.Status != null)
            result = result.Where(r => r.OrderStatus == @params.Status);

        if (@params.UserId != null)
            result = result.Where(r => r.UserId == @params.UserId);

        if (@params.StartDate != null)
            result = result.Where(r => r.CreateDate.Date >= @params.StartDate.Value.Date);

        if (@params.EndDate != null)
            result = result.Where(r => r.CreateDate.Date <= @params.EndDate.Value.Date);

        var skip = (@params.PageId - 1) * @params.Take;
        var model = new OrderFilterResult()
        {
            Data = await result.Skip(skip).Take(@params.Take)
                .Select(order => order.MapFilterItem(_context))
                .ToListAsync(cancellationToken),
            FilterParams = @params
        };
        model.GeneratePaging(result, @params.Take, @params.PageId);
        return model;

    }
}
