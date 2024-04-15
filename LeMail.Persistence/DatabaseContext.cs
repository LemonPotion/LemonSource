using LeMail.Application.Interfaces;
using LeMail.Domain.Entities;
using LeMail.Persistence.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace LeMail.Persistence;

public class DatabaseContext : DbContext, IDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Message> Messages { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options ) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new ContactConfiguration());
        modelBuilder.ApplyConfiguration(new MessageConfiguration());
    }
}