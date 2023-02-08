using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using AutoMapper.Internal.Mappers;
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
    private readonly IPostRepository _postRepository;
    private readonly PostManager _postManager;

    public PostAppService(
        IPostRepository postRepository,
        PostManager postManager)
    {
        _postManager = postManager;
        _postRepository = postRepository;
    }

    public async Task<PostDto> GetAsync(Guid id)
    {
        var post = await _postRepository.GetWithDetailAsync(id);
        return ObjectMapper.Map<PostWithDetail, PostDto>(post);
    }

    public async Task<PagedResultDto<PostDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        var posts = await _postRepository.GetListWithDetailAsync(input);

        var result = new PagedResultDto<PostDto>();
        result.TotalCount = await _postRepository.GetCountAsync();
        result.Items = ObjectMapper.Map<List<PostWithDetail>, List<PostDto>>(posts);

        return result;
    }


    public async Task<PostDto> CreateAsync(CreateUpdatePostDto input)
    {
        var result = await _postManager.CreateAsync(
            ObjectMapper.Map<CreateUpdatePostDto, Post>(input));

        return await GetAsync(result.Id);
    }

    public async Task<PostDto> UpdateAsync(Guid id, CreateUpdatePostDto input)
    {
        var result = await _postManager.UpdateAsync(id, ObjectMapper.Map<CreateUpdatePostDto, Post>(input));

        return await GetAsync(result.Id);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _postManager.DeleteAsync(id);
    }
}