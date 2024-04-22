namespace LeMail.Domain.Entities;


public abstract class BaseEntity
{
    public Guid Id { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj == null)
            return false;
        else if (obj is not BaseEntity baseEntity)
            return false;
        else if (baseEntity.Id != Id)
            return false;
        else if (this.GetHashCode() != baseEntity.GetHashCode())
            return false;
        return true;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}