using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities.Auditing;

namespace Personality.Blog;

public class Category : FullAuditedAggregateRoot<Guid>
{
    public string Name { get; set; }
    public string Slug { get; set; }
    public BlogStatus Status { get; set; }
    public ICollection<Post> Posts { get; set; }
    public ICollection<CategoryPost> CategoryPosts { get; set; }

    public Category()
    {
        Posts = new Collection<Post>();
        CategoryPosts = new Collection<CategoryPost>();
    }

    public Category(Guid id) : base(id)
    {
    }
}