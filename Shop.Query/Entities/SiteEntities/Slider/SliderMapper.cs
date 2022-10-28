using Shop.Domain.Entities.SiteEntities;
using Shop.Query.Entities.SiteEntities.Banner.DTOs;
using Shop.Query.Entities.SiteEntities.Slider.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Entities.SiteEntities.Slider;
public static class SliderMapper
{
    public static SliderDto? Map(this SliderEntity? slider)
    {
        if (slider == null)
            return null;

        return new()
        {
            CreateDate = slider.CreateDate,
            Id = slider.Id,
            ImageName = slider.ImageName,
            Link = slider.Link,
            Title = slider.Title,
        };
    }

    public static List<SliderDto> Map(this List<SliderEntity> sliders)
    {
        if (sliders == null)
            return null;

        var model = new List<SliderDto>();

        sliders.ForEach(slider =>
        {
            model.Add(new SliderDto()
            {
                CreateDate = slider.CreateDate,
                Id = slider.Id,
                ImageName = slider.ImageName,
                Link = slider.Link,
                Title = slider.Title,
            });
        });
        return model;
    }
}


