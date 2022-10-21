using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.SiteEntities;

namespace Shop.Infrastructure.Persistent.Ef.Entities.SiteEntities.Slider;

internal class SliderConfiguration : IEntityTypeConfiguration<SliderEntity>
{
    public void Configure(EntityTypeBuilder<SliderEntity> builder)
    {
        builder.Property(b => b.ImageName)
           .HasMaxLength(120).IsRequired();

        builder.Property(b => b.Title)
            .HasMaxLength(120);

        builder.Property(b => b.Link)
            .HasMaxLength(500);
    }
}
