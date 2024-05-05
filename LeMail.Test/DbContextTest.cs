using LeMail.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LeMail.Test;

public class DbContextTest
{
    public DatabaseContext DatabaseContext { get; set; }
    public DbContextTest()
    {
        var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=LeMail;Trusted_Connection=True;");
        DatabaseContext = new DatabaseContext(optionsBuilder.Options);
    }
}