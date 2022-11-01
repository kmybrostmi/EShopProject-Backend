using Common.Application;

namespace Shop.Application.Aggregates.Categories.Remove;
public class RemoveCategoryCommand : IBaseCommand
{
    public RemoveCategoryCommand(Guid categoryId)
    {
        CategoryId = categoryId;
    }

    public Guid CategoryId { get; set; }
}


