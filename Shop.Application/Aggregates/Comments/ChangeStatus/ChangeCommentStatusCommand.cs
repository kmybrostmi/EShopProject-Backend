using Common.Application;
using Shop.Domain.CommentAgg;

namespace Shop.Application.Aggregates.Comments.ChangeStatus;
public class ChangeCommentStatusCommand:IBaseCommand
{
    public ChangeCommentStatusCommand(Guid commentId, CommentStatus commentStatus)
    {
        CommentId = commentId;
        CommentStatus = commentStatus;
    }

    public Guid CommentId { get; set; }
    public CommentStatus CommentStatus { get; set; }
}
