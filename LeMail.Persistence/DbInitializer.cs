namespace LeMail.Persistence;

public class DbInitializer
{
    public static void Initialize(DatabaseContext dbContext)
    {
        dbContext.Database.EnsureCreated();
    }
}