namespace LeMail.Persistence;
/// <summary>
/// Initializer for database
/// </summary>
public class DbInitializer
{
    public static void Initialize(DatabaseContext dbContext)
    {
        dbContext.Database.EnsureCreated();
    }
}