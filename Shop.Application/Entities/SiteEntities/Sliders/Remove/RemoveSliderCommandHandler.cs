using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application.Aggregates._Utilities;
using Shop.Domain.Entities.SiteEntities.Repository;

namespace Shop.Application.Entities.SiteEntities.Sliders.Remove;

internal class RemoveSliderCommandHandler : IBaseCommandHandler<RemoveSliderCommand>
{
    private readonly ISliderRepository _repository;
    private readonly IFileService _fileService;

    public RemoveSliderCommandHandler(ISliderRepository repository,IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;
    }
    public async Task<OperationResult> Handle(RemoveSliderCommand request, CancellationToken cancellationToken)
    {
        var slider = await _repository.GetTracking(request.SliderId);
        if (slider == null)
            return OperationResult.NotFound();

        _repository.Delete(slider);
        await _repository.Save();
        _fileService.DeleteFile(Directories.SliderImages, slider.ImageName);
        return OperationResult.Success();
    }
}