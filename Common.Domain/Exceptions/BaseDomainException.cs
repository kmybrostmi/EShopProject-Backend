namespace Shop.Domain.OrderAgg;

public class BaseDomainException : Exception
{
    public BaseDomainException()
    {
    }

    public BaseDomainException(string message) : base(message)
    {
    }
}
