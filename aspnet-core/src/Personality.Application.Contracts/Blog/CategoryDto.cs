using System;
using Volo.Abp.Application.Dtos;

namespace Personality.Blog;

public class CategoryDto : EntityDto<Guid>
{
    public string Name { get; set; }
    public string Slug { get; set; }
    public BlogStatus Status { get; set; }
}