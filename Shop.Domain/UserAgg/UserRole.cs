using Common.Domain;

namespace Shop.Domain.UserAgg;

public class UserRole : BaseEntity
{
    public Guid UserId { get; internal set; }
}

