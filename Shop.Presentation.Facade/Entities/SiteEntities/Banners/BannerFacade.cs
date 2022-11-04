using Common.Application;
using MediatR;
using Shop.Application.Entities.SiteEntities.Banners.Create;
using Shop.Application.Entities.SiteEntities.Banners.Edit;
using Shop.Application.Entities.SiteEntities.Banners.Remove;
using Shop.Query.Entities.SiteEntities.Banner.DTOs;
using Shop.Query.Entities.SiteEntities.Banner.GetById;
using Shop.Query.Entities.SiteEntities.Banner.GetList;

namespace Shop.Presentation.Facade.Entities.SiteEntities.Banners;

public class BannerFacade : IBannerFacade
{
    private readonly IMediator _mediator;

    public BannerFacade(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<OperationResult> CreateBanner(CreateBannerCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> EditBanner(EditBannerCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<BannerDto?> GetBannerById(Guid id)
    {
        return await _mediator.Send(new GetBannerByIdQuery(id));
    }

    public async Task<List<BannerDto>> GetBannersList()
    {
        return await _mediator.Send(new GetBannersListQuery());
    }

    public async Task<OperationResult> RemoveBanner(Guid bannerId)
    {
        return await _mediator.Send(new RemoveBannerCommand(bannerId));
    }
}
