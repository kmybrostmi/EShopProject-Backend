using Common.Application;

namespace Shop.Application.Entities.SiteEntities.Sliders.Remove;

internal class RemoveSliderCommandHandler : IBaseCommandHandler<RemoveSliderCommand>
{
    public Task<OperationResult> Handle(RemoveSliderCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}