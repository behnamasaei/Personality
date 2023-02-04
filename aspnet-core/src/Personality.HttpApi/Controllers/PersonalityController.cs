using Personality.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Personality.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class PersonalityController : AbpControllerBase
{
    protected PersonalityController()
    {
        LocalizationResource = typeof(PersonalityResource);
    }
}
