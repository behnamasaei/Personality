using System;
using Volo.Abp.Application.Dtos;

namespace Personality.Blog;

public class CategoryPostDto: EntityDto<Guid>
{
    public Guid PostId { get; set; }
    public Guid CategoryId { get; set; }
}