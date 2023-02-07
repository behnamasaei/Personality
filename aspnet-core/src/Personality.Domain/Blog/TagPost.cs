using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace Personality.Blog;

public class TagPost : Entity
{
    public Guid PostId { get; set; }

    // public Post Post { get; set; }
    public Guid TagId { get; set; }
    // public Tag Tag { get; set; }

    public TagPost(Guid postId, Guid tagId)
    {
        PostId = postId;
        TagId = tagId;
    }

    public override object[] GetKeys()
    {
        return new object[] { PostId, TagId };
    }
}