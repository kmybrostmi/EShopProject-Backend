
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.SiteEntities;

namespace Shop.Infrastructure.Persistent.Ef.Entities.SiteEntities.Banner;

internal class BannerConfiguration : IEntityTypeConfiguration<BannerEntity>
{
    public void Configure(EntityTypeBuilder<BannerEntity> builder)
    {
        builder.Property(b => b.ImageName)
            .HasMaxLength(120).IsRequired();

        builder.Property(b => b.Link)
            .HasMaxLength(500).IsRequired();
    }
}