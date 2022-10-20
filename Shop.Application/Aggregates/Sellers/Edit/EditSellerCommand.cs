using Common.Application;
using Shop.Domain.SellerAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Aggregates.Sellers.Edit;
public class EditSellerCommand:IBaseCommand
{
    public EditSellerCommand(Guid sellerId, string shopName, string nationalCode, SellerStatus sellerStatus)
    {
        SellerId = sellerId;
        ShopName = shopName;
        NationalCode = nationalCode;
        SellerStatus = sellerStatus;
    }

    public Guid SellerId { get; set; }
    public string ShopName { get; set; }
    public string NationalCode { get; set; }
    public SellerStatus SellerStatus { get; set; }

}



