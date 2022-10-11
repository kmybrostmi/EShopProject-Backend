using Common.Domain.Repository;
using Shop.Domain.CommentAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Aggregates.CommentAgg.Repository;
public interface ICommentRepository : IBaseRepository<Comment>
{
}
