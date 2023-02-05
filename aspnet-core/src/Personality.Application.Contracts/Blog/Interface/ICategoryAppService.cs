using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Personality.Blog.Interface;

public interface ICategoryAppService:
    ICrudAppService< //Defines CRUD methods
        CategoryDto, //Used to show categories
        Guid, //Primary key of the category entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateCategoryDto>
{
    
}