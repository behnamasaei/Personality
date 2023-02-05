using System;
using Personality.Blog.Interface;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Personality.Blog;

public class TagPostAppService :
    CrudAppService<
        TagPost, //The Tag entity
        TagPostDto, //Used to show Tags
        Guid, //Primary key of the Tag entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateTagPostDto>, //Used to create/update a Tag
    ITagPostAppService
{
    public TagPostAppService(IRepository<TagPost, Guid> repository) : base(repository)
    {
    }
}