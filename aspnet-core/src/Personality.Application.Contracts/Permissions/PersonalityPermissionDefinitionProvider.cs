using Personality.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Personality.Permissions;

public class PersonalityPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(PersonalityPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(PersonalityPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<PersonalityResource>(name);
    }
}
