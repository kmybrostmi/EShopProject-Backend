using Microsoft.EntityFrameworkCore;
using Shop.Domain.Aggregates.CategoryAgg.Repository;
using Shop.Domain.CategoryAgg;
using Shop.Infrastructure.Persistent.Ef.Aggregates._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.Aggregates.CategoryAgg;
internal class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ShopDbContext context) : base(context)
    {
    }

    public async Task<bool> DeleteCategory(Guid categoryId)
    {
        var category = await Context.Categories.Include(x=>x.Childs)
                                                                    .ThenInclude(x=>x.Childs)
                                                                    .FirstOrDefaultAsync(x => x.Id == categoryId);
        if (category == null)
            return false;

        var isExistsProduct = await Context.Products.AnyAsync(x => x.CategoryId == categoryId ||
                                                                    x.SubCategoryId == categoryId ||
                                                                    x.SecondarySubCategoryId == categoryId);
        if (isExistsProduct)
            return false;
        if(category.Childs.Any(c=>c.Childs.Any()))
        {
            Context.RemoveRange(category.Childs.SelectMany(c=>c.Childs));
        }
        Context.RemoveRange(category.Childs);
        Context.RemoveRange(category);
        return true;
    }
}
