using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities.Auditing;

namespace Personality.Blog;

public class Tag : FullAuditedAggregateRoot<Guid>
{
    public string Name { get; set; }
    public string Slug { get; set; }
    public BlogStatus Status { get; set; }
    public ICollection<Post> Posts { get; set; }
    public ICollection<TagPost> TagsPosts { get; set; }

    public Tag()
    {
        Posts = new Collection<Post>();
        TagsPosts = new Collection<TagPost>();
    }

    public Tag(Guid id) : base(id)
    {
    }
    
    
}