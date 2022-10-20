using Shop.Domain.SellerAgg;

namespace Shop.Domain.Aggregates.SellerAgg.Interface;
public interface ISellerDomainService
{
    bool IsValidSellerInformation(Seller seller);
    bool NationalCodeExistsInDataBase(string nationalCode);
}
