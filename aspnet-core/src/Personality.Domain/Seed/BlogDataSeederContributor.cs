using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Personality.Blog;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Personality.Seed;

public class BlogDataSeederContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Post, Guid> _postRepository;
    private readonly IRepository<Tag, Guid> _tagRepository;
    private readonly IRepository<Category, Guid> _categoryRepository;

    public BlogDataSeederContributor(
        IRepository<Tag, Guid> tagRepository,
        IRepository<Category, Guid> categoryRepository,
        IRepository<Post, Guid> postRepository)
    {
        _postRepository = postRepository;
        _tagRepository = tagRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _categoryRepository.GetCountAsync() <= 0 &&
            await _tagRepository.GetCountAsync() <= 0 &&
            await _postRepository.GetCountAsync() <= 0)
        {
            #region Tag seed

            var tag_csharp = await _tagRepository.InsertAsync(
                new Tag(Guid.NewGuid())
                {
                    Name = "C#",
                    Slug = "c_sharp",
                    Status = BlogStatus.Publish
                },
                autoSave: true);

            var tag_html = await _tagRepository.InsertAsync(
                new Tag(Guid.NewGuid())
                {
                    Name = "html",
                    Slug = "html",
                    Status = BlogStatus.Publish
                },
                autoSave: true);

            var tag_css = await _tagRepository.InsertAsync(
                new Tag(Guid.NewGuid())
                {
                    Name = "css",
                    Slug = "css",
                    Status = BlogStatus.Publish
                },
                autoSave: true);

            var tag_asp = await _tagRepository.InsertAsync(
                new Tag(Guid.NewGuid())
                {
                    Name = "Asp .net",
                    Slug = "aspnet",
                    Status = BlogStatus.Publish
                },
                autoSave: true);

            var tag_azure = await _tagRepository.InsertAsync(
                new Tag(Guid.NewGuid())
                {
                    Name = "azure",
                    Slug = "azure",
                    Status = BlogStatus.Draft
                },
                autoSave: true);

            var tag_python = await _tagRepository.InsertAsync(
                new Tag(Guid.NewGuid())
                {
                    Name = "python",
                    Slug = "phthon",
                    Status = BlogStatus.Draft
                },
                autoSave: true);

            #endregion

            #region Categor seed

            var cat_scharp = await _categoryRepository.InsertAsync(
                new Category(Guid.NewGuid())
                {
                    Name = "سی شارپ",
                    Slug = "csharp",
                    Status = BlogStatus.Publish
                },
                autoSave: true);

            var cat_designPattern = await _categoryRepository.InsertAsync(
                new Category(Guid.NewGuid())
                {
                    Name = "الگو های طراحی",
                    Slug = "design_pattern",
                    Status = BlogStatus.Publish
                },
                autoSave: true);

            var cat_database = await _categoryRepository.InsertAsync(
                new Category(Guid.NewGuid())
                {
                    Name = "پایگاه داده",
                    Slug = "database",
                    Status = BlogStatus.Publish
                },
                autoSave: true);

            var cat_react = await _categoryRepository.InsertAsync(
                new Category(Guid.NewGuid())
                {
                    Name = "react",
                    Slug = "react",
                    Status = BlogStatus.Publish
                },
                autoSave: true);


            var cat_angular = await _categoryRepository.InsertAsync(
                new Category(Guid.NewGuid())
                {
                    Name = "angular",
                    Slug = "angular",
                    Status = BlogStatus.Publish
                },
                autoSave: true);

            var cat_vue = await _categoryRepository.InsertAsync(
                new Category(Guid.NewGuid())
                {
                    Name = "vue.js",
                    Slug = "vuejs",
                    Status = BlogStatus.Draft
                },
                autoSave: true);

            #endregion

            #region Post seed

            var Post1ID = Guid.NewGuid();

            var tagPost1 = new List<TagPost>();

            tagPost1.Add(new TagPost(postId: Post1ID, tagId: tag_csharp.Id));

            tagPost1.Add(new TagPost(postId: Post1ID, tagId: tag_asp.Id));

            var catPost1 = new List<CategoryPost>();

            catPost1.Add(new CategoryPost(postId: Post1ID, categoryId: cat_scharp.Id));

            var post1 = await _postRepository.InsertAsync(new Post(Post1ID)
            {
                Title = "پست اول",
                Slug = "post_1",
                ImageIndexAddress = "xxxx",
                Content = "متن پست اول",
                Status = BlogStatus.Publish,
                TagsPosts = tagPost1,
                CategoryPosts = catPost1
            });

            #endregion
        }
    }
}