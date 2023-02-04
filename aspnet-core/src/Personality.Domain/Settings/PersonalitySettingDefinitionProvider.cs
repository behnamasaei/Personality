using Volo.Abp.Settings;

namespace Personality.Settings;

public class PersonalitySettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(PersonalitySettings.MySetting1));
    }
}
