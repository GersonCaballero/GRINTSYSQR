using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace GRINTSYSQR.Controllers
{
    public abstract class GRINTSYSQRControllerBase: AbpController
    {
        protected GRINTSYSQRControllerBase()
        {
            LocalizationSourceName = GRINTSYSQRConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
