using System;
using Volo.Abp.Domain.Entities;

namespace Personality.Blog;

public class CategoryPost : Entity<Guid>
{
    public Guid PostId { get; set; }
    public Post Post { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
}