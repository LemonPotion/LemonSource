using System.Text.Json;
namespace LeMail.Domain.ValueObjects;

public class BaseValueObject
{
    public override bool Equals(object? obj)
    {
        if (obj is not BaseValueObject baseValueObject)
            return false;
        var serializedThis = Serialize(this);
        var serializedValueObject = Serialize(baseValueObject);
        if (serializedValueObject != serializedThis)
            return false;
        return true;
    }

    public string Serialize(BaseValueObject baseValueObject)
    {
        var serializedValueObject = JsonSerializer.Serialize(baseValueObject);
        return serializedValueObject;
    }
    public override int GetHashCode()
    {
        return Serialize(this).GetHashCode();
    }
}