using System;
using System.Collections.Generic;
using System.Text;
using Personality.Localization;
using Volo.Abp.Application.Services;

namespace Personality;

/* Inherit your application services from this class.
 */
public abstract class PersonalityAppService : ApplicationService
{
    protected PersonalityAppService()
    {
        LocalizationResource = typeof(PersonalityResource);
    }
}
