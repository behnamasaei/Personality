using System;
using Personality.Blog.Interface;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Personality.Blog;

public class TagAppService :
    CrudAppService<
        Tag, //The Tag entity
        TagDto, //Used to show Tags
        Guid, //Primary key of the Tag entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateTagDto>, //Used to create/update a Tag
    ITagAppService
{
    public TagAppService(IRepository<Tag, Guid> repository)
        : base(repository)
    {

    }
}