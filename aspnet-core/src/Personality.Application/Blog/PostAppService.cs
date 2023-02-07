using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Personality.Blog.Interface;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Personality.Blog;

public class PostAppService :
    PersonalityAppService,
    IPostAppService
{
    private readonly IRepository<Post, Guid> _postRepository;
    private readonly IPostRepository _postRepositoryN;

    public PostAppService(
        IRepository<Post, Guid> postRepository,
        IPostRepository postRepositoryN)
    {
        _postRepository = postRepository;
        _postRepositoryN = postRepositoryN;
    }

    public async Task<PostDto> GetAsync(Guid id)
    {
        var post = await _postRepositoryN.GetAsync(id);
        return ObjectMapper.Map<PostWithDetail, PostDto>(post);
    }

    public async Task<PagedResultDto<PostDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        var posts = await _postRepositoryN.GetListAsync(input);

        var result = new PagedResultDto<PostDto>();
        result.TotalCount = await _postRepository.GetCountAsync();
        result.Items = ObjectMapper.Map<List<PostWithDetail>, List<PostDto>>(posts);

        return result;
    }


    public async Task<PostDto> CreateAsync(CreateUpdatePostDto input)
    {
        input.Id = Guid.NewGuid();

        input.TagsPosts = input.TagsPosts.Select(s =>
        {
            s.PostId = input.Id;
            return s;
        }).ToList();

        input.CategoryPosts = input.CategoryPosts.Select(s =>
        {
            s.PostId = input.Id;
            return s;
        }).ToList();

        var result = await _postRepository.InsertAsync(
            ObjectMapper.Map<CreateUpdatePostDto, Post>(input),
            autoSave: true);
        await CurrentUnitOfWork.CompleteAsync();

        return await this.GetAsync(input.Id);
    }

    public async Task<PostDto> UpdateAsync(Guid id, CreateUpdatePostDto input)
    {
        var post = await _postRepository.UpdateAsync(
            ObjectMapper.Map<CreateUpdatePostDto, Post>(input),
            autoSave: true);
        await CurrentUnitOfWork.CompleteAsync();
        return ObjectMapper.Map<Post, PostDto>(post);
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}