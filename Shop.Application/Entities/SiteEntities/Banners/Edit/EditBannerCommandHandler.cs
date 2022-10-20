﻿using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Common.Application.SecurityUtil;
using Microsoft.AspNetCore.Http;
using Shop.Application.Aggregates._Utilities;
using Shop.Domain.Entities.SiteEntities.Repository;

namespace Shop.Application.Entities.SiteEntities.Banners.Edit;

public class EditBannerCommandHandler : IBaseCommandHandler<EditBannerCommand>
{
    private readonly IBannerRepository _repository;
    private readonly IFileService _fileService;

    public EditBannerCommandHandler(IBannerRepository repository,IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;
    }
    public async Task<OperationResult> Handle(EditBannerCommand request, CancellationToken cancellationToken)
    {
        var banner = await _repository.GetTracking(request.BannerId);
        if (banner == null)
            return OperationResult.NotFound();

        var imageName = banner.ImageName;
        var oldImage = banner.ImageName;

        if (request.ImageFile.IsImage())
            imageName = await _fileService
                .SaveFileAndGenerateName(request.ImageFile, Directories.BannerImages);

        banner.Edit(request.Link, imageName, request.BannerPosition);

        DeleteOldImage(request.ImageFile, oldImage);
        await _repository.Save();
        return OperationResult.Success();
    }

    private void DeleteOldImage(IFormFile? imageFile, string oldImage)
    {
        if (imageFile.IsImage())
            _fileService.DeleteFile(Directories.BannerImages, oldImage);
    }
}


