using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Personality.Blog;

public interface ICategoryPostRepository : IRepository<CategoryPost>
{
    public Task DeleteCategoriesAsync(List<CategoryPost> categoryPosts);
}