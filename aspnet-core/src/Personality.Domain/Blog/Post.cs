using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Personality.Blog;

public class Post : FullAuditedAggregateRoot<Guid>
{
    public string Title { get; set; }
    public string Slug { get; set; }
    public string ImageIndexAddress { get; set; }
    public string Content { get; set; }

    public BlogStatus Status { get; set; }

    // public ICollection<Tag> Tags { get; set; }
    public ICollection<TagPost> TagsPosts { get; set; }

    // public ICollection<Category> Categories { get; set; }
    public ICollection<CategoryPost> CategoryPosts { get; set; }


    public Post()
    {
        // Categories = new Collection<Category>();
        // Tags = new Collection<Tag>();
        TagsPosts = new Collection<TagPost>();
        CategoryPosts = new Collection<CategoryPost>();
    }

    public Post(Guid id) : base(id)
    {
    }

    public void AddCategory(Guid categoryId)
    {
        Check.NotNull(categoryId, nameof(categoryId));
        if (IsInCategory(categoryId))
        {
            return;
        }
        
        CategoryPosts.Add(new CategoryPost(postId: Id, categoryId));
    }

    public void AddTag(Guid tagId)
    {
        Check.NotNull(tagId, nameof(tagId));
        if (IsInTag(tagId))
        {
            return;
        }

        TagsPosts.Add(new TagPost(postId: Id, tagId));
    }

    private bool IsInCategory(Guid categoryId)
    {
        return CategoryPosts.Any(x => x.CategoryId == categoryId);
    }

    private bool IsInTag(Guid tagId)
    {
        return TagsPosts.Any(x => x.TagId == tagId);
    }
    
    public void RemoveAllCategories()
    {
        CategoryPosts.RemoveAll(x => x.PostId == Id);
    }

    public void RemoveAllTags()
    {
        TagsPosts.RemoveAll(x => x.PostId == Id);
    }
}