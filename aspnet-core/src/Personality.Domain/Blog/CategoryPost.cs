using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace Personality.Blog;

public class CategoryPost : Entity
{
    public Guid PostId { get; set; }

    // public Post Post { get; set; }
    public Guid CategoryId { get; set; }
    // public Category Category { get; set; }

    public CategoryPost(Guid postId, Guid categoryId)
    {
        PostId = postId;
        CategoryId = categoryId;
    }

    public override object[] GetKeys()
    {
        return new object[] { PostId, CategoryId };
    }
}