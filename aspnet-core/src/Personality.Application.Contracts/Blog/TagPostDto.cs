using System;
using Volo.Abp.Application.Dtos;

namespace Personality.Blog;

public class TagPostDto : AuditedEntityDto<Guid>
{
    
    public Guid PostId { get; set; }
    public PostDto Post { get; set; }
    public Guid TagId { get; set; }
    public TagDto Tag { get; set; }
}