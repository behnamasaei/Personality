using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Personality.Blog;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Personality.EntityFrameworkCore.Blog;

public class EfCorePostRepository : EfCoreRepository<PersonalityDbContext, Post, Guid>, IPostRepository
{

    public EfCorePostRepository(IDbContextProvider<PersonalityDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<List<PostWithDetail>> GetListWithDetailAsync(PagedAndSortedResultRequestDto input,
        CancellationToken cancellationToken = default)
    {
        var query = await ApplyFilterAsync();
        return await query
            .OrderBy(ordering: !string.IsNullOrWhiteSpace(input.Sorting)
                ? input.Sorting
                : nameof(PostWithDetail.CreationTime))
            .PageBy(input.SkipCount, input.MaxResultCount)
            .ToListAsync(GetCancellationToken(cancellationToken));
    }

    public async Task<PostWithDetail> GetWithDetailAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var query = await ApplyFilterAsync();
        return await query
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
    }

    

    private async Task<IQueryable<PostWithDetail>> ApplyFilterAsync()
    {
        var dbContext = await GetDbContextAsync();

        return (await GetDbSetAsync())
            .Include(x => x.CategoryPosts)
            .Select(x => new PostWithDetail
            {
                Id = x.Id,
                Title = x.Title,
                Slug = x.Slug,
                ImageIndexAddress = x.ImageIndexAddress,
                Content = x.Content,
                Status = x.Status,
                LastModifierId = x.LastModifierId,
                CreationTime = x.CreationTime,
                Tags = (from postTags in x.TagsPosts
                    join tag in dbContext.Set<Tag>() on postTags.TagId equals tag.Id
                    select tag).ToList(),

                TagPosts = (from tagsPost in x.TagsPosts
                join tag in dbContext.Set<TagPost>() on tagsPost.TagId equals tag.TagId
                select tag).ToList(),
                
                Categories = (from postCategories in x.CategoryPosts
                    join category in dbContext.Set<Category>() on postCategories.CategoryId equals category.Id
                    select category).ToList(),
                
                CategoryPosts = (from categoriesPost in x.CategoryPosts
                    join category in dbContext.Set<CategoryPost>() on categoriesPost.CategoryId equals category.CategoryId
                    select category).ToList()
            })
            .Where(x => x.IsDeleted == false)
            .AsNoTracking();
    }


}