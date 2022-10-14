using Common.Application;
using Common.Domain.ValueObjects;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Aggregates.Categories.Remove;
public class DeleteCategoryCommand : IBaseCommand
{
    public Guid CategoryId { get; set; }
    public Guid ParentId { get; set; }
}


