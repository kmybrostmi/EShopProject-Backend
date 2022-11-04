using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application.Aggregates._Utilities;
using Shop.Domain.Entities.SiteEntities.Repository;

namespace Shop.Application.Entities.SiteEntities.Banners.Remove;

public class RemoveBannerCommandHandler : IBaseCommandHandler<RemoveBannerCommand>
{
    private readonly IBannerRepository _repository;
    private readonly IFileService _fileService;

    public RemoveBannerCommandHandler(IBannerRepository repository,IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;
    }
    public async Task<OperationResult> Handle(RemoveBannerCommand request, CancellationToken cancellationToken)
    {
        var banner = await _repository.GetTracking(request.BannerId);
        if (banner == null)
            return OperationResult.NotFound();

        _repository.Delete(banner);
        await _repository.Save();
        _fileService.DeleteFile(Directories.BannerImages, banner.ImageName);
        return OperationResult.Success();
    }
}

