using LeMail.Application.Interfaces.Repository;
using LeMail.Domain.Entities;

namespace LeMail.Persistence.Repositories;

public class ReviewRepository : RepositoryBase<Review>, IReviewRepository
{
    public ReviewRepository(DatabaseContext dbContext) : base(dbContext)
    {
    }
}