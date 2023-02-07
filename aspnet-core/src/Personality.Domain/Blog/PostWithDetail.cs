using System;
using System.Collections.Generic;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities.Auditing;

namespace Personality.Blog;

public class PostWithDetail : FullAuditedAggregateRoot<Guid>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public string ImageIndexAddress { get; set; }
    public string Content { get; set; }
    public BlogStatus Status { get; set; }
    public ICollection<Tag> Tags { get; set; }
    public ICollection<Category> Categories { get; set; }
}