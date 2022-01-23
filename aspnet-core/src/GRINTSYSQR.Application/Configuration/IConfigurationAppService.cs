using System.Threading.Tasks;
using GRINTSYSQR.Configuration.Dto;

namespace GRINTSYSQR.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
