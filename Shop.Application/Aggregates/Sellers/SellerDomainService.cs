using Shop.Domain.Aggregates.SellerAgg.Interface;
using Shop.Domain.SellerAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Aggregates.Sellers;
public class SellerDomainService : ISellerDomainService
{
    public bool IsValidSellerInformation(Seller seller)
    {
        throw new NotImplementedException();
    }

    public bool NationalCodeExistsInDataBase(string nationalCode)
    {
        throw new NotImplementedException();
    }
}
