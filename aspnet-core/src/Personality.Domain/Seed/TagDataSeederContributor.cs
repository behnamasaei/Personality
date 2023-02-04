using System;
using System.Threading.Tasks;
using Personality.Blog;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Personality.Seed;

public class TagDataSeederContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Tag, Guid> _tagRepository;
    private readonly IRepository<Category, Guid> _categoryRepository;

    public TagDataSeederContributor(IRepository<Tag, Guid> tagRepository,
        IRepository<Category, Guid> categoryRepository)
    {
        _tagRepository = tagRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _tagRepository.GetCountAsync() <= 0)
        {
            #region Tag seed

            await _tagRepository.InsertAsync(
                new Tag
                {
                    Name = "C#",
                    Slug = "c_sharp",
                    Status = BlogStatus.Publish
                },
                autoSave: true);

            await _tagRepository.InsertAsync(
                new Tag
                {
                    Name = "C#",
                    Slug = "c_sharp",
                    Status = BlogStatus.Publish
                },
                autoSave: true);

            await _tagRepository.InsertAsync(
                new Tag
                {
                    Name = "html",
                    Slug = "html",
                    Status = BlogStatus.Publish
                },
                autoSave: true);

            await _tagRepository.InsertAsync(
                new Tag
                {
                    Name = "css",
                    Slug = "css",
                    Status = BlogStatus.Publish
                },
                autoSave: true);

            await _tagRepository.InsertAsync(
                new Tag
                {
                    Name = "Asp .net",
                    Slug = "aspnet",
                    Status = BlogStatus.Publish
                },
                autoSave: true);

            await _tagRepository.InsertAsync(
                new Tag
                {
                    Name = "azure",
                    Slug = "azure",
                    Status = BlogStatus.Draft
                },
                autoSave: true);

            await _tagRepository.InsertAsync(
                new Tag
                {
                    Name = "python",
                    Slug = "phthon",
                    Status = BlogStatus.Draft
                },
                autoSave: true);

            #endregion
        }

        if (await _categoryRepository.GetCountAsync() <= 0)
        {
            #region Categor seed

            await _categoryRepository.InsertAsync(
                new Category
                {
                    Name = "الگو های طراحی",
                    Slug = "design_pattern",
                    Status = BlogStatus.Publish
                },
                autoSave: true);

            await _categoryRepository.InsertAsync(
                new Category
                {
                    Name = "پایگاه داده",
                    Slug = "database",
                    Status = BlogStatus.Publish
                },
                autoSave: true);

            await _categoryRepository.InsertAsync(
                new Category
                {
                    Name = "react",
                    Slug = "react",
                    Status = BlogStatus.Publish
                },
                autoSave: true);


            await _categoryRepository.InsertAsync(
                new Category
                {
                    Name = "angular",
                    Slug = "angular",
                    Status = BlogStatus.Publish
                },
                autoSave: true);

            await _categoryRepository.InsertAsync(
                new Category
                {
                    Name = "vue.js",
                    Slug = "vuejs",
                    Status = BlogStatus.Draft
                },
                autoSave: true);

            #endregion
        }
    }
}