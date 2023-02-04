using Volo.Abp.Modularity;

namespace Personality;

[DependsOn(
    typeof(PersonalityApplicationModule),
    typeof(PersonalityDomainTestModule)
    )]
public class PersonalityApplicationTestModule : AbpModule
{

}
