namespace Common.Domain;
public class BaseEntity
{
    public Guid Id { get; protected set; }
    public DateTime CreateDate { get; private set; }

    public BaseEntity()
    {
        CreateDate = DateTime.Now;
    }
}
