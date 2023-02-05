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
        CreateMap<Category, CategoryDto>();
        CreateMap<Tag, TagDto>();
        CreateMap<CreateUpdateCategoryDto, Category>();
        CreateMap<CreateUpdateTagDto, Tag>();
    }
}