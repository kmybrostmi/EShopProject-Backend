using Common.Domain;

namespace Shop.Domain.UserAgg;

public class UserAddress : BaseEntity
{
    public Guid UserId { get; internal set; }
}


