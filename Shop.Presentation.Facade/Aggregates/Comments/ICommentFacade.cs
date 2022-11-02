using Common.Application;
using Shop.Application.Aggregates.Comments.ChangeStatus;
using Shop.Application.Aggregates.Comments.Create;
using Shop.Application.Aggregates.Comments.Edit;
using Shop.Query.Aggregates.Comments.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade.Aggregates.Comments;
public interface ICommentFacade
{
    //Commands
    Task<OperationResult> CreateComment(CreateCommentCommand command);
    Task<OperationResult> EditComment(EditCommentCommand command);
    Task<OperationResult> ChangeCommentStatus(ChangeCommentStatusCommand command);

    //Queries
    Task<CommentDto?> GetCommentById(Guid id);   
    Task<CommentFilterResult> GetCommentByFilter(CommentFilterParams filterParams);
}


