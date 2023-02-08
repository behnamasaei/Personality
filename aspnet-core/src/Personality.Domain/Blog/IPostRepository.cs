using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace Personality.Blog;

public interface IPostRepository : IRepository<Post, Guid>
{
    Task<List<PostWithDetail>> GetListWithDetailAsync(PagedAndSortedResultRequestDto input,
        CancellationToken cancellationToken = default);

    Task<PostWithDetail> GetWithDetailAsync(Guid id, CancellationToken cancellationToken = default);

}