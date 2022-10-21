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
    Task<InventoryResult?> GetInventoryById(Guid id);  
}



public class InventoryResult
{
    public Guid Id { get; set; }
    public Guid SellerId { get; set; }
    public Guid ProductId { get; set; }
    public int Count { get; set; }
    public int Price { get; set; }
}

