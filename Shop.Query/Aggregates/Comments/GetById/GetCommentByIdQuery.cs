using Common.Query;
using Shop.Query.Aggregates.Comments.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Aggregates.Comments.GetById;
public class GetCommentByIdQuery:IQuery<CommentDto?>
{
    public Guid CommentId { get; set; }

    public GetCommentByIdQuery(Guid commentId)
    {
        CommentId = commentId;
    }
}
