using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.ProductAgg.Service;
public interface IProductDomainService
{
    bool IsSlugExist(string slug);
}

