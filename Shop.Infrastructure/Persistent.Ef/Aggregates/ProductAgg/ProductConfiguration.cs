using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.OrderAgg;
using Shop.Domain.ProductAgg;

namespace Shop.Infrastructure.Persistent.Ef.Aggregates.ProductAgg;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product", "Product");
        builder.HasKey(b => b.Id);
        builder.HasIndex(b => b.Slug).IsUnique();

        builder.Property(b => b.Title).IsRequired().HasMaxLength(50);
        builder.Property(b => b.Description).IsRequired();
        builder.Property(b => b.ImageName).IsRequired().HasMaxLength(50);
        builder.Property(b => b.Slug).IsRequired().IsUnicode(false);


        //One To Many
        builder.OwnsMany(b => b.Images, options =>
        {
            options.ToTable("Images", "Product");

            options.HasKey(b => b.Id);
            options.Property(b => b.ImageName).IsRequired().HasMaxLength(100);

        });

        //One To Many
        builder.OwnsMany(b => b.Specifications, options =>
        {
            options.ToTable("Specifications", "Product");

            options.Property(b => b.Key).IsRequired().HasMaxLength(100);
            options.Property(b => b.Value).IsRequired().HasMaxLength(50);

        });

        //Value Object
        builder.OwnsOne(b => b.SeoData, config =>
        {
            config.Property(b => b.MetaDescription)
                .HasMaxLength(500)
                .HasColumnName("MetaDescription");

            config.Property(b => b.MetaTitle)
                .HasMaxLength(500)
                .HasColumnName("MetaTitle");

            config.Property(b => b.MetaKeyWords)
                .HasMaxLength(500)
                .HasColumnName("MetaKeyWords");

            config.Property(b => b.IndexPage)
                .HasColumnName("IndexPage");

            config.Property(b => b.Canonical)
                .HasMaxLength(500)
                .HasColumnName("Canonical");

            config.Property(b => b.Schema)
                .HasColumnName("Schema");
        });
    }
}
