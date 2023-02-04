using System;
using Volo.Abp.Domain.Entities;

namespace Personality.Blog;

public class TagPost : Entity<Guid>
{
    public Guid PostId { get; set; }
    public Post Post { get; set; }
    public Guid TagId { get; set; }
    public Tag Tag { get; set; }
}