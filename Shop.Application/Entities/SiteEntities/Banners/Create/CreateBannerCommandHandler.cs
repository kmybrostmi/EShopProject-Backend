using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application.Aggregates._Utilities;
using Shop.Domain.Entities.SiteEntities;
using Shop.Domain.Entities.SiteEntities.Repository;

namespace Shop.Application.Entities.SiteEntities.Banners.Create;

public class CreateBannerCommandHandler : IBaseCommandHandler<CreateBannerCommand>
{
    private readonly IBannerRepository _repository;
    private readonly IFileService _fileService;

    public CreateBannerCommandHandler(IBannerRepository repository,IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;
    }
    public async Task<OperationResult> Handle(CreateBannerCommand request, CancellationToken cancellationToken)
    {
        var imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile,Directories.BannerImages); 

        var banner = new BannerEntity(request.Link,imageName,request.BannerPosition);

        await _repository.AddAsync(banner);
        await _repository.Save();
        return OperationResult.Success();
    }
}


