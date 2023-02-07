using System;
using Volo.Abp.Application.Dtos;

namespace Personality.Blog;

public class TagPostDto : EntityDto<Guid>
{
    
    public Guid PostId { get; set; }
    public Guid TagId { get; set; }
}