using Shop.Domain.SellerAgg;
using Shop.Query.Aggregates.Sellers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Aggregates.Sellers;
public static class SellerMapper
{
    public static SellerDto? Map(this Seller? seller)
    {
        if (seller == null)
            return null;

        return new()
        {
            Id = seller.Id,
            UserId = seller.UserId,
            ShopName = seller.ShopName,
            CreateDate = seller.CreateDate,
            NationalCode = seller.NationalCode,
            Status = seller.Status
        };
    }

    public static SellerDto MapFilter(this Seller seller)
    {
        if (seller == null)
            return null;

        return new()
        {
            Id = seller.Id,
            UserId = seller.UserId,
            ShopName = seller.ShopName,
            CreateDate = seller.CreateDate,
            NationalCode = seller.NationalCode,
            Status = seller.Status
        };
    }
}


