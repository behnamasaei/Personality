using System;
using System.Threading.Tasks;
using Personality.Blog.Interface;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Personality.Blog;

public class CategoryPostAppService : 
    CrudAppService<
        CategoryPost, //The Category entity
        CategoryPostDto, //Used to show Categories
        Guid, //Primary key of the Category entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateCategoryPostDto>, //Used to create/update a Category
    ICategoryPostAppService //implement the ICategoryAppService
{
    public CategoryPostAppService(IRepository<CategoryPost, Guid> repository) : base(repository)
    {
    }
}