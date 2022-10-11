using Common.Domain.Repository;
using Shop.Domain.SellerAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Aggregates.SellerAgg.Repository;
public interface ISellerRepository : IBaseRepository<Seller>
{
}
