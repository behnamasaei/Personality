using System;
using Volo.Abp.Application.Dtos;

namespace Personality.Blog;

public class CategoryPostDto : AuditedEntityDto<Guid>
{
    public Guid PostId { get; set; }
    public PostDto Post { get; set; }
    public Guid CategoryId { get; set; }
    public CategoryDto Category { get; set; }
}