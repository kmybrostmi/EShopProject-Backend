using Common.Query;
using Shop.Query.Aggregates.Categories.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Aggregates.Categories.GetByParentId;
public class GetCategoryByParentIdQuery:IQuery<List<ChildCategoryDto>>
{
    public GetCategoryByParentIdQuery(Guid parentId)
    {
        ParentId = parentId;
    }

    public Guid ParentId { get; set; }
}


