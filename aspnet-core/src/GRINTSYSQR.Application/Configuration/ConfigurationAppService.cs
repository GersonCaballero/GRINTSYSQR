using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using GRINTSYSQR.Configuration.Dto;

namespace GRINTSYSQR.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : GRINTSYSQRAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
