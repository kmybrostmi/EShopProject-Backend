using Shop.Domain.Aggregates.SellerAgg.Interface;
using Shop.Domain.Aggregates.SellerAgg.Repository;
using Shop.Domain.SellerAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Aggregates.Sellers;
public class SellerDomainService : ISellerDomainService
{
    private readonly ISellerRepository _repository;

    public SellerDomainService(ISellerRepository repository)
    {
        _repository = repository;
    }
    public bool IsValidSellerInformation(Seller seller)
    {
        var result = _repository.Exists(x => x.UserId == seller.UserId || x.NationalCode == seller.NationalCode);
        return !result;
    }

    public bool NationalCodeExistsInDataBase(string nationalCode)
    {
        return _repository.Exists(x => x.NationalCode == nationalCode);
    }
}
