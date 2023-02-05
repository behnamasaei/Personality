using System;
using Personality.Blog.Interface;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Personality.Blog;

public class CategoryAppService :
    CrudAppService<
        Category, //The Category entity
        CategoryDto, //Used to show Categories
        Guid, //Primary key of the Category entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateCategoryDto>, //Used to create/update a Category
    ICategoryAppService //implement the ICategoryAppService
{
    public CategoryAppService(IRepository<Category, Guid> repository) : base(repository)
    {
    }
}