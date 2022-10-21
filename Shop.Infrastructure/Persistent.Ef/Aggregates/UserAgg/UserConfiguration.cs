using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.UserAgg;

namespace Shop.Infrastructure.Persistent.Ef.Aggregates.UserAgg;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User", "User");
        builder.HasKey(b => b.Id);
        builder.HasIndex(b => b.PhoneNumber).IsUnique();
        builder.HasIndex(b => b.Email).IsUnique();

        //Properties
        builder.Property(b => b.Name).IsRequired().HasMaxLength(50);
        builder.Property(b => b.Family).IsRequired().HasMaxLength(50);
        builder.Property(b => b.Email).IsRequired().HasMaxLength(100);
        builder.Property(b => b.Password).IsRequired().HasMaxLength(100);


        //Value Object
        builder.OwnsOne(c => c.PhoneNumber, config =>
        {
            config.Property(b => b.Value)
                .HasColumnName("PhoneNumber")
                .IsRequired().HasMaxLength(11);
        });

        //One To Many
        builder.OwnsMany(b => b.Addresses, option =>
        {
            option.ToTable("Addresses", "User");
            option.HasKey(b => b.Id);
            option.HasIndex(b => b.UserId);

            //Properties
            option.Property(b => b.Shire).IsRequired().HasMaxLength(100);
            option.Property(b => b.City).IsRequired().HasMaxLength(100);
            option.Property(b => b.Name).IsRequired().HasMaxLength(50);
            option.Property(b => b.Family).IsRequired().HasMaxLength(50);
            option.Property(b => b.PostalCode).IsRequired().HasMaxLength(20);
            option.Property(b => b.PostalAddress).IsRequired().HasMaxLength(100);

            //Value Object
            option.OwnsOne(c => c.PhoneNumber, config =>
            {
                config.Property(b => b.Value)
                    .HasColumnName("PhoneNumber")
                    .IsRequired().HasMaxLength(11);
            });

            //Value Object
            option.OwnsOne(c => c.NationalCode, config =>
            {
                config.Property(b => b.Value)
                    .HasColumnName("NationalCode")
                    .IsRequired().HasMaxLength(10);
            });

        });

        //One To Many
        builder.OwnsMany(b => b.Roles, option =>
        {
            option.ToTable("Roles", "User");
            option.HasKey(b => b.Id);
            option.HasIndex(b => b.UserId);
            option.HasIndex(b => b.RoleId);
        });

        //One To Many
        builder.OwnsMany(b => b.Wallets, option =>
        {
            option.ToTable("Wallets", "User");
            option.HasKey(b => b.Id);
            option.HasIndex(b => b.UserId);

            //Properties
            option.Property(b => b.Description).IsRequired().HasMaxLength(1000);
        });

    }
}

