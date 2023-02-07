using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Personality.Blog.Interface;

public interface IPostAppService : 
    ICrudAppService< //Defines CRUD methods
        PostDto, //Used to show posts
        Guid, //Primary key of the post entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdatePostDto>
{
    
}