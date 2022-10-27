using Common.Query;
using Shop.Domain.CommentAgg;

namespace Shop.Query.Aggregates.Comments.DTOs;
public class CommentDto:BaseDto
{
    public Guid ProductId { get; set; }
    public Guid UserId { get; set; }
    public string UserFullName { get; set; }
    public string ProductTitle { get; set; }
    public string Text { get; set; }
    public CommentStatus Status { get; set; }
}

