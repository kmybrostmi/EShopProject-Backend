using Common.Application;
using Shop.Domain.Aggregates.CommentAgg.Repository;

namespace Shop.Application.Aggregates.Comments.ChangeStatus;

public class ChangeCommentStatusCommandHandler : IBaseCommandHandler<ChangeCommentStatusCommand>
{
    private readonly ICommentRepository _repository;

    public ChangeCommentStatusCommandHandler(ICommentRepository repository)
    {
        _repository = repository;
    }
    public async Task<OperationResult> Handle(ChangeCommentStatusCommand request, CancellationToken cancellationToken)
    {
        var comment = await _repository.GetTracking(request.CommentId);
        if (comment == null)
            return OperationResult.NotFound();

        comment.ChangeStatus(request.CommentStatus);
        await _repository.Save();
        return OperationResult.Success();   

    }
}
