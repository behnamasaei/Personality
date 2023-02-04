using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Personality.Data;

/* This is used if database provider does't define
 * IPersonalityDbSchemaMigrator implementation.
 */
public class NullPersonalityDbSchemaMigrator : IPersonalityDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
