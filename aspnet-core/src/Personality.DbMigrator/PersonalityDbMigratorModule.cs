using Personality.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Personality.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(PersonalityEntityFrameworkCoreModule),
    typeof(PersonalityApplicationContractsModule)
    )]
public class PersonalityDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
