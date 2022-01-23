using System.Threading.Tasks;
using Abp.Application.Services;
using GRINTSYSQR.Authorization.Accounts.Dto;

namespace GRINTSYSQR.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
