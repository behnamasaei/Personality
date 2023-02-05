﻿using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Personality.Blog.Interface;

public interface ICategoryPostAppService:
    ICrudAppService< //Defines CRUD methods
        CategoryPostDto, //Used to show tags
        Guid, //Primary key of the tag entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateCategoryPostDto>
{
    
}