using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.RoleAgg;
using Shop.Domain.SellerAgg;

namespace Shop.Infrastructure.Persistent.Ef.Aggregates.SellerAgg;

internal class SellerConfiguration : IEntityTypeConfiguration<Seller>
{
    public void Configure(EntityTypeBuilder<Seller> builder)
    {
        builder.ToTable("Seller", "Seller");
        builder.HasKey(b => b.Id);
        builder.HasIndex(b => b.NationalCode).IsUnique();

        //Properties
        builder.Property(b => b.ShopName).IsRequired().HasMaxLength(50);
        builder.Property(b => b.NationalCode).IsRequired().HasMaxLength(11);

        //One To Many
        builder.OwnsMany(b => b.Inventories, option =>
        {
            option.ToTable("Inventories", "Seller");
            option.HasKey(b => b.Id);
            option.HasIndex(b => b.ProductId);
            option.HasIndex(b => b.SellerId);
        });
    }
}
