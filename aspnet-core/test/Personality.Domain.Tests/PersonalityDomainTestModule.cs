using Personality.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Personality;

[DependsOn(
    typeof(PersonalityEntityFrameworkCoreTestModule)
    )]
public class PersonalityDomainTestModule : AbpModule
{

}
