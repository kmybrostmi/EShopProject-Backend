using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.CategoryAgg;
using Shop.Domain.OrderAgg;

namespace Shop.Infrastructure.Persistent.Ef.Aggregates.OrderAgg;

internal class OrderConfiguration : IEntityTypeConfiguration<Order>
{

    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders", "Order");

        builder.HasKey(b => b.Id);
       c

        //One To Many
        builder.OwnsMany(b => b.Items, option =>
        {
            option.ToTable("Items", "Order");
            option.HasKey(b => b.Id);
            option.HasIndex(b => b.InventoryId);
            option.HasIndex(b => b.OrderId);
        });

        ///One To One
        builder.OwnsOne(b => b.Address, option =>
        {
            option.HasKey(b => b.Id);
            option.ToTable("Addresses", "Order");

            option.Property(b => b.Shire)
                .IsRequired().HasMaxLength(100);

            option.Property(b => b.City)
                .IsRequired().HasMaxLength(100);

            option.Property(b => b.Name)
                .IsRequired().HasMaxLength(50);

            option.Property(b => b.Family)
                .IsRequired().HasMaxLength(50);

            option.Property(b => b.PhoneNumber)
                .IsRequired().HasMaxLength(12);

            option.Property(b => b.NationalCode)
                .IsRequired().HasMaxLength(10);

            option.Property(b => b.PostalCode)
                .IsRequired().HasMaxLength(20);
        });

        //Value Object
        builder.OwnsOne(b => b.Discount, option =>
        {
            option.Property(b => b.DiscountTitle)
                .IsRequired()
                .HasMaxLength(100);
        });

        //Value Object
        builder.OwnsOne(b => b.OrderShipping, option =>
        {
            option.Property(b => b.ShippingType)
                .IsRequired(false)
                .HasMaxLength(100);
        });
    }
}


