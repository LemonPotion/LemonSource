using LeMail.Application.Interfaces.Repository;
using LeMail.Domain.Entities;

namespace LeMail.Persistence.Repositories;

public class ReviewerRepository : RepositoryBase<Reviewer>, IReviewerRepository
{
    public ReviewerRepository(DatabaseContext dbContext) : base(dbContext)
    {
        
    }
}