﻿using Common.Application;
using Shop.Domain.Aggregates.CommentAgg.Repository;
using Shop.Domain.CommentAgg;

namespace Shop.Application.Aggregates.Comments.Create;

public class CreateCommentCommandHandler : IBaseCommandHandler<CreateCommentCommand>
{
    private readonly ICommentRepository _repository;

    public CreateCommentCommandHandler(ICommentRepository repository)
    {
        _repository = repository;
    }
    public async Task<OperationResult> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment =  new Comment(request.UserId, request.ProductId,request.Text);
        await _repository.AddAsync(comment);
        await _repository.Save();
        return OperationResult.Success();

    }
}


