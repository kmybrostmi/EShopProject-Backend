using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Aggregates.Sellers.Create;
public class CreateSellerCommand:IBaseCommand
{
    public CreateSellerCommand(Guid userId, string shopName, string nationalCode)
    {
        UserId = userId;
        ShopName = shopName;
        NationalCode = nationalCode;
    }

    public Guid UserId { get; set; }
    public string ShopName { get; set; }
    public string NationalCode { get; set; }
}

