namespace LeMail.Domain.Entities;

/// <summary>
/// Base entity class
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Id of entity
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Equals override
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
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

    /// <summary>
    /// GetHasCodeOverride
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}