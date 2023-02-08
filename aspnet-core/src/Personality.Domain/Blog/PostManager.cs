using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Uow;

namespace Personality.Blog;

public class PostManager : DomainService
{
    private readonly IPostRepository _postRepository;
    private readonly ITagPostRepository _tagPostRepository;
    private readonly ICategoryPostRepository _categoryPostRepository;

    public PostManager(
        IPostRepository postRepository,
        ICategoryPostRepository categoryPostRepository, ITagPostRepository tagPostRepository)
    {
        _postRepository = postRepository;
        _categoryPostRepository = categoryPostRepository;
        _tagPostRepository = tagPostRepository;
    }

    public async Task<Post> CreateAsync(Post input)
    {
        var post = new Post(id: GuidGenerator.Create())
        {
            Title = input.Title,
            Content = input.Content,
            Slug = input.Slug,
            ImageIndexAddress = input.ImageIndexAddress,
            Status = input.Status,
            CreationTime = DateTime.Now
        };

        post.TagsPosts = input.TagsPosts.Select(s =>
        {
            s.PostId = post.Id;
            return s;
        }).ToList();

        post.CategoryPosts = input.CategoryPosts.Select(s =>
        {
            s.PostId = post.Id;
            return s;
        }).ToList();

        // await SetCategories(post, input.CategoryPosts.ToList());
        // await SetTags(post, input.TagsPosts.ToList());

        return await _postRepository.InsertAsync(post);
    }

    public async Task<Post> UpdateAsync(Guid id, Post input)
    {
        var postWithDetail = await _postRepository.GetWithDetailAsync(id);
        await _categoryPostRepository.DeleteManyAsync(postWithDetail.CategoryPosts, autoSave: true);
        await _tagPostRepository.DeleteManyAsync(postWithDetail.TagPosts, autoSave: true);


        var post = await _postRepository.GetAsync(x => x.Id == id);
        post.TagsPosts = input.TagsPosts.Select(s =>
        {
            s.PostId = post.Id;
            return s;
        }).ToList();

        post.CategoryPosts = input.CategoryPosts.Select(s =>
        {
            s.PostId = post.Id;
            return s;
        }).ToList();

        post.Title = input.Title;
        post.Slug = input.Slug;
        post.Content = input.Content;
        post.ImageIndexAddress = input.ImageIndexAddress;
        post.LastModificationTime = DateTime.Now;


        return await _postRepository.UpdateAsync(post, autoSave: true);
    }


    public async Task DeleteAsync(Guid id)
    {
        // var postWithDetail = await _postRepository.GetWithDetailAsync(id);
        // await _categoryPostRepository.DeleteManyAsync(postWithDetail.CategoryPosts, autoSave: true);
        // await _tagPostRepository.DeleteManyAsync(postWithDetail.TagPosts, autoSave: true);
        await _postRepository.DeleteAsync(x => x.Id == id, autoSave: true);
    }


    private async Task SetTags(Post post, [CanBeNull] List<TagPost> tagIds)
    {
        post.RemoveAllTags();
        foreach (var tag in tagIds)
        {
            post.AddTag(tag.TagId);
        }
    }

    private async Task SetCategories(Post post, [CanBeNull] List<CategoryPost> categoryIds)
    {
        post.RemoveAllCategories();
        foreach (var categoryId in categoryIds)
        {
            post.AddCategory(categoryId.CategoryId);
        }
    }
}