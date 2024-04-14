using LeMail.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LeMail.Application.Interfaces;

public interface IDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Message> Messages { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}