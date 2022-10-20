using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Aggregates.Comments.Edit;
public class EditCommentCommand:IBaseCommand
{
    public EditCommentCommand(Guid commentId, Guid userId, string text)
    {
        CommentId = commentId;
        UserId = userId;
        Text = text;
    }

    public Guid CommentId { get; set; }
    public Guid UserId { get; set; }
    public string Text { get; set; }
}

//public record CreateCommentCommand(Guid CommentId,string Text, Guid UserId,) : IBaseCommand;
