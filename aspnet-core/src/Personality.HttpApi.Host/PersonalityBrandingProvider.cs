using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Personality;

[Dependency(ReplaceServices = true)]
public class PersonalityBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Personality";
}
