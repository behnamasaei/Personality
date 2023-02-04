using System.Threading.Tasks;

namespace Personality.Data;

public interface IPersonalityDbSchemaMigrator
{
    Task MigrateAsync();
}
