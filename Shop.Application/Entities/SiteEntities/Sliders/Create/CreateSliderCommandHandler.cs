﻿using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application.Aggregates._Utilities;
using Shop.Domain.Entities.SiteEntities;
using Shop.Domain.Entities.SiteEntities.Repository;

namespace Shop.Application.Entities.SiteEntities.Sliders.Create;

internal class CreateSliderCommandHandler : IBaseCommandHandler<CreateSliderCommand>
{
    private readonly ISliderRepository _repository;
    private readonly IFileService _fileService;

    public CreateSliderCommandHandler(ISliderRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;
    }
    public async Task<OperationResult> Handle(CreateSliderCommand request, CancellationToken cancellationToken)
    {
        var imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.BannerImages);

        var slider = new Slider(request.Title,request.Link, imageName); 

        await _repository.AddAsync(slider);
        await _repository.Save();
        return OperationResult.Success();
    }
}


