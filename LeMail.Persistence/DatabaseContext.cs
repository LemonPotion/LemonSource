using LeMail.Domain.Entities;
using LeMail.Persistence.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace LeMail.Persistence;
/// <summary>
/// Database context class 
/// </summary>
public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }
    /// <summary>
    /// User entity DbSet
    /// </summary>
    public DbSet<User> Users { get; set; }
    /// <summary>
    /// Contact entity DbSet
    /// </summary>
    public DbSet<Contact> Contacts { get; set; }
    /// <summary>
    /// Message entity DbSet
    /// </summary>
    public DbSet<Message> Messages { get; set; }
    /// <summary>
    /// Applying configurations 
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new ContactConfiguration());
        modelBuilder.ApplyConfiguration(new MessageConfiguration());
    }
}