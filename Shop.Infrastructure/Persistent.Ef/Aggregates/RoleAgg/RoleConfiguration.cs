using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.ProductAgg;
using Shop.Domain.RoleAgg;

namespace Shop.Infrastructure.Persistent.Ef.Aggregates.RoleAgg;

internal class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Role", "Role");

        builder.HasKey(c => c.Id);

        builder.Property(b => b.Title)
            .IsRequired().HasMaxLength(50);

        //One To Many
        builder.OwnsMany(b => b.Permissions, option =>
        {
            option.ToTable("RolePermission", "Role");

            option.HasKey(c => c.Id);   
        });
    }
}
