using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CommentAgg;

namespace Shop.Infrastructure.Persistent.Ef.Aggregates.CommentAgg;

internal class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comment", "Comment");

        builder.HasKey(c => c.Id);  

        builder.Property(b => b.Text)
            .IsRequired().HasMaxLength(500);
    }
}
