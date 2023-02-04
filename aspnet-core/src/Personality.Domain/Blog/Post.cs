using System;
using System.Collections;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace Personality.Blog;

public class Post : FullAuditedAggregateRoot<Guid>
{
    public string Title { get; set; }
    public string Slug { get; set; }
    public string ImageIndexAddress { get; set; }
    public string Content { get; set; }
    public BlogStatus Status { get; set; }
    public ICollection<Tag> Tags { get; set; }
    public ICollection<TagPost> TagsPosts { get; set; }
    
    public ICollection<Category> Categories { get; set; }
    public ICollection<CategoryPost> CategoryPosts { get; set; }

}