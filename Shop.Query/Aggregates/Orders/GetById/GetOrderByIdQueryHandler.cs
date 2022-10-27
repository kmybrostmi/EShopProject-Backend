using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.Aggregates.Orders.DTOs;

namespace Shop.Query.Aggregates.Orders.GetById;

internal class GetOrderByIdQueryHandler : IQueryHandler<GetOrderByIdQuery, OrderDto?>
{
    private readonly ShopDbContext _context;
    private readonly DapperContext _dapperContext;

    public GetOrderByIdQueryHandler(ShopDbContext context, DapperContext dapperContext)
    {
        _context = context;
        _dapperContext = dapperContext;
    }
    public async Task<OrderDto?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(f => f.Id == request.OrderId,cancellationToken);
        if (order == null)  
            return null;

        var orderDto = order.Map();
        orderDto.UserFullName = await _context.Users.Where(f => f.Id == orderDto.UserId)
            .Select(s => $"{s.Name} {s.Family}").FirstAsync(cancellationToken);

        orderDto.Items = await orderDto.GetOrderItems(_dapperContext);
        return orderDto;
    }
}

