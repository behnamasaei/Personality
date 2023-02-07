using AutoMapper;
using Personality.Blog;

namespace Personality;

public class PersonalityApplicationAutoMapperProfile : Profile
{
    public PersonalityApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Tag, TagDto>().ReverseMap();
        CreateMap<Post, PostDto>().ReverseMap();
        CreateMap<Post, PostWithDetail>().ReverseMap();
        CreateMap<PostDto, PostWithDetail>().ReverseMap();

        CreateMap<TagPost, TagPostDto>().ReverseMap();
        CreateMap<CategoryPost, CategoryPostDto>().ReverseMap();
        
        CreateMap<CreateUpdateCategoryDto, Category>().ReverseMap();
        CreateMap<CreateUpdateTagDto, Tag>().ReverseMap();
        CreateMap<CreateUpdatePostDto, Post>().ReverseMap();
        CreateMap<CreateUpdateTagPostDto, TagPost>().ReverseMap();
        CreateMap<CreateUpdateCategoryPostDto, CategoryPost>().ReverseMap();


    }
}