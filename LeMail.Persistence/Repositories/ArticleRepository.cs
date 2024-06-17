using LeMail.Application.Interfaces.Repository;
using LeMail.Domain.Entities;

namespace LeMail.Persistence.Repositories;

public class ArticleRepository : RepositoryBase<Article>, IArticleRepository
{
    public ArticleRepository(DatabaseContext dbContext) : base(dbContext)
    {
    }
}