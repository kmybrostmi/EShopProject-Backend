using Shop.Domain.Aggregates.CommentAgg.Repository;
using Shop.Domain.CommentAgg;
using Shop.Infrastructure.Persistent.Ef.Aggregates._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.Ef.Aggregates.CommentAgg;
internal class CommentRepository : BaseRepository<Comment>, ICommentRepository
{
    public CommentRepository(ShopDbContext context) : base(context)
    {
    }
}
