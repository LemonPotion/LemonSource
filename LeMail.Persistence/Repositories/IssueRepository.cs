using LeMail.Application.Interfaces.Repository;
using LeMail.Domain.Entities;

namespace LeMail.Persistence.Repositories;

public class IssueRepository : RepositoryBase<Issue>, IIssueRepository
{
    public IssueRepository(DatabaseContext dbContext) : base(dbContext)
    {
    }
}