using Common.Application;
using MediatR;
using Shop.Application.Aggregates.Comments.ChangeStatus;
using Shop.Application.Aggregates.Comments.Create;
using Shop.Application.Aggregates.Comments.Edit;
using Shop.Query.Aggregates.Comments.DTOs;
using Shop.Query.Aggregates.Comments.GetByFilter;
using Shop.Query.Aggregates.Comments.GetById;

namespace Shop.Presentation.Facade.Aggregates.Comments;
internal class CommentFacade : ICommentFacade
{
    private readonly IMediator _mediator;

    public CommentFacade(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<OperationResult> ChangeCommentStatus(ChangeCommentStatusCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> CreateComment(CreateCommentCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> EditComment(EditCommentCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<CommentFilterResult> GetCommentByFilter(CommentFilterParams filterParams)
    {
        return await _mediator.Send(new GetCommentsByFilterQuery(filterParams));
    }

    public async Task<CommentDto?> GetCommentById(Guid id)
    {
        return await _mediator.Send(new GetCommentByIdQuery(id));   
    }
}
