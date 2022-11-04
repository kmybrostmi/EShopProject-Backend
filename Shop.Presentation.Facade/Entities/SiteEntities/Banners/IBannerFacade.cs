using Common.Application;
using Shop.Application.Entities.SiteEntities.Banners.Create;
using Shop.Application.Entities.SiteEntities.Banners.Edit;
using Shop.Application.Entities.SiteEntities.Banners.Remove;
using Shop.Query.Entities.SiteEntities.Banner.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade.Entities.SiteEntities.Banners;
public interface IBannerFacade
{
    //Commands
    Task<OperationResult> CreateBanner(CreateBannerCommand command);
    Task<OperationResult> EditBanner(EditBannerCommand command);
    Task<OperationResult> RemoveBanner(Guid bannerId);


    //Queries
    Task<BannerDto?> GetBannerById(Guid id);
    Task<List<BannerDto>> GetBannersList();


}

