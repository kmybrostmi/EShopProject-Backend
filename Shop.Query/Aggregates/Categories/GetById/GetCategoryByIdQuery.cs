using Common.Query;
using Shop.Query.Aggregates.Categories.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Aggregates.Categories.GetById;
public class GetCategoryByIdQuery : IQuery<CategoryDto>
{
    public GetCategoryByIdQuery(Guid categoryId)
    {
        CategoryId = categoryId;
    }

    public Guid CategoryId { get; set; }
}

