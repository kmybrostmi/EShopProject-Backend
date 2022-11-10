using Common.Application;
using MediatR;
using Shop.Application.Aggregates.Sellers.AddInventory;
using Shop.Application.Aggregates.Sellers.Create;
using Shop.Application.Aggregates.Sellers.Edit;
using Shop.Application.Aggregates.Sellers.EditInventory;
using Shop.Query.Aggregates.Sellers.DTOs;
using Shop.Query.Aggregates.Sellers.GetByFilter;
using Shop.Query.Aggregates.Sellers.GetById;
using Shop.Query.Aggregates.Sellers.GetByUserId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade.Aggregates.Sellers;
public class SellerFacade : ISellerFacade
{
    private readonly IMediator _mediator;

    public SellerFacade(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<OperationResult> AddSellerInventory(AddSellerInventoryCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> CreateSeller(CreateSellerCommand command)
    {
        return await _mediator.Send(command); ;
    }

    public async Task<OperationResult> EditSeller(EditSellerCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> EditSellerInventory(EditSellerInventoryCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<SellerFilterResult> GetSellerByFilter(SellerFilterParams filterParams)
    {
        return await _mediator.Send(new GetSellerByFilterQuery(filterParams));
    }

    public async Task<SellerDto?> GetSellerById(Guid id)
    {
        return await _mediator.Send(new GetSellerByIdQuery(id));
    }

    public async Task<SellerDto?> GetSellerByUserId(Guid userId)
    {
        return await _mediator.Send(new GetSellerByUserIdQuery(userId));    
    }
}
