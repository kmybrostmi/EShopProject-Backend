using Common.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.SiteEntities.Repository;
public interface IBannerRepository : IBaseRepository<BannerEntity>
{
    void Delete(BannerEntity banner);
}
