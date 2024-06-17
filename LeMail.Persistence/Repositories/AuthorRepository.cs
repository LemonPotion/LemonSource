using LeMail.Application.Interfaces.Repository;
using LeMail.Domain.Entities;

namespace LeMail.Persistence.Repositories;

public class AuthorRepository : RepositoryBase<Author>,IAuthorRepository
{
    public AuthorRepository(DatabaseContext dbContext) : base(dbContext)
    {
    }
}