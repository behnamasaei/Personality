using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Personality.Blog;

public class PostDto : AuditedEntityDto<Guid>
{
    
    public string Title { get; set; }
    public string Slug { get; set; }
    public string ImageIndexAddress { get; set; }
    public string Content { get; set; }
    public BlogStatus Status { get; set; }
    public ICollection<TagDto> Tags { get; set; }
    public ICollection<CategoryDto> Categories { get; set; }
}