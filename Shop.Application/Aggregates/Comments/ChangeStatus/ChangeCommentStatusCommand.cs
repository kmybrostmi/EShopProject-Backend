using Common.Application;
using Shop.Domain.CommentAgg;

namespace Shop.Application.Aggregates.Comments.ChangeStatus;
public class ChangeCommentStatusCommand:IBaseCommand
{
    public Guid CommentId { get; set; }
    public CommentStatus CommentStatus { get; set; }
}
