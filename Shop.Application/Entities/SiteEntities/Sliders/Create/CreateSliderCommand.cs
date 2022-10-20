using Common.Application;
using Microsoft.AspNetCore.Http;
using Shop.Domain.Entities.SiteEntities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Entities.SiteEntities.Sliders.Create;
public class CreateSliderCommand:IBaseCommand
{
    public CreateSliderCommand(string link, IFormFile imageFile, string title)
    {
        Link = link;
        ImageFile = imageFile;
        Title = title;
    }

    public string Link { get; set; }
    public IFormFile ImageFile { get; set; }
    public string Title { get; set; }
}


