using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Personality.Blog;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Personality.EntityFrameworkCore.Blog;

public class EfCoreCategoryPostRepository : EfCoreRepository<PersonalityDbContext, CategoryPost>,
    ICategoryPostRepository
{
    public EfCoreCategoryPostRepository(IDbContextProvider<PersonalityDbContext> dbContextProvider) : base(
        dbContextProvider)
    {
    }

    public async Task DeleteCategoriesAsync(List<CategoryPost> categoryPosts)
    {
        var dbContext = await GetDbContextAsync();
        var query = await ApplyFilterAsync();

        foreach (var categoryPost in categoryPosts)
        {
            var category =  query.Where(x => x.CategoryId == categoryPost.CategoryId &&
                                     x.PostId == categoryPost.PostId).First();
            if(category != null)
                dbContext.CategoryPosts.Remove(category);
        }

        await dbContext.SaveChangesAsync();
    }

    private async Task<IQueryable<CategoryPost>> ApplyFilterAsync()
    {
        return (await GetDbSetAsync());
    }
}