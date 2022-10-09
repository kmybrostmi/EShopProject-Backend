using Common.Domain;

namespace Shop.Domain.UserAgg;

public class UserWallet : BaseEntity
{
    public Guid UserId { get; internal set; }
}

