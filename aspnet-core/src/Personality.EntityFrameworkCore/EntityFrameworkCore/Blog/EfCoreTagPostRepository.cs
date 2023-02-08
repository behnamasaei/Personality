using Personality.Blog;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Personality.EntityFrameworkCore.Blog;

public class EfCoreTagPostRepository : EfCoreRepository<PersonalityDbContext, TagPost>, ITagPostRepository
{
    public EfCoreTagPostRepository(IDbContextProvider<PersonalityDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}